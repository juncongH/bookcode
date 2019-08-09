using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;

namespace LevelAdjust
{
    class Formula
    {
        //读取文件
        public void Readfile(out List<ViewData> DStations, out List<Station> CStations, out double H_start, out double H_end)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.RestoreDirectory = true;
            file.Filter = "All files(*.*)|*.*|Text files(*.txt)|*.txt";
            file.FilterIndex = 2;

            DStations = new List<ViewData>();
            CStations = new List<Station>();
            H_start = 0;
            H_end = 0;

            Station st;
            ViewData dt;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);

                string str = reader.ReadLine();
                var arr = str.Split(',');
                H_start = double.Parse(arr[1]);
                str = reader.ReadLine();
                arr = str.Split(',');
                H_end = double.Parse(arr[1]);

                int i = 0;
                str = reader.ReadLine();
                while (str != null)
                {
                    st = new Station();
                    dt = new ViewData();

                    arr = str.Split(',');
                    st.backName = arr[0];
                    st.forName = arr[1];
                    st.a1 = double.Parse(arr[2]);
                    st.a2 = double.Parse(arr[3]);
                    st.a3 = double.Parse(arr[4]);
                    st.a4 = double.Parse(arr[5]);
                    st.a5 = double.Parse(arr[6]);
                    st.a6 = double.Parse(arr[7]);
                    st.a7 = double.Parse(arr[8]);
                    st.a8 = double.Parse(arr[9]);

                    dt.order = i;
                    dt.backward = arr[0];
                    dt.forward = arr[1];
                    dt.backdis1 = arr[2];
                    dt.backview1 = arr[3];
                    dt.fordis1 = arr[4];
                    dt.forview1 = arr[5];
                    dt.fordis2 = arr[6];
                    dt.forview2 = arr[7];
                    dt.backdis2 = arr[8];
                    dt.backview2 = arr[9];

                    CStations.Add(st);
                    DStations.Add(dt);

                    i++;
                    str = reader.ReadLine();
                }
                reader.Close();
            }
            else
            {
                return;
            }
        }

        //手簿计算
        public void DataCalculate(double acc, Station S)
        {
            S.a9 = S.a4 - S.a6;
            S.a10 = S.a2 - S.a8;
            S.a11 = S.a10 - S.a9;

            S.a12 = S.a1 - S.a3;
            S.a13 = S.a7 - S.a5;
            S.a14 = (S.a12 + S.a13) / 2.0;
            S.a15 = S.a14 + acc;

            S.a16 = S.a2 - S.a4;
            S.a17 = S.a8 - S.a6;
            S.a18 = (S.a16 + S.a17) / 2.0;

            if (S.a1 > 80.0 || S.a3 > 80.0 || S.a5 > 80.0 || S.a7 > 80.0)
                MessageBox.Show("视线长度超限！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (S.a14 > 5.0)
                MessageBox.Show("前后视距差超限！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (S.a15 > 10.0)
                MessageBox.Show("前后视距累计差超限！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (S.a9 > 0.003 || S.a10 > 0.003)
                MessageBox.Show("黑红面读数差超限！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            if (S.a11 > 0.005)
                MessageBox.Show("黑红面高差之差超限！", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        //区分测段
        public void Station_Segment(List<Station> CStations, out List<Segment> Segments)
        {
            int n = CStations.Count;

            Segments = new List<Segment>();
            Segment sg = new Segment();

            double Dh = 0;
            double Dis = 0;

            for (int i = 0; i < n; i++)
            {
                if (CStations[i].backName != "-1")
                {
                    if (i == 0)
                    { }
                    else
                    {
                        Segments.Add(sg);
                    }

                    sg = new Segment();
                    sg.startname = CStations[i].backName;
                    Dh = 0;
                    Dis = 0;
                }
                Dh += CStations[i].a18;
                Dis += (CStations[i].a1 + CStations[i].a3) / 2.0 + (CStations[i].a5 + CStations[i].a7) / 2.0;
                sg.deltaH = Dh;
                sg.dis = Dis;
                sg.endname = CStations[i].forName;

                if (i == 18)
                {
                    Segments.Add(sg);
                }
            }
        }

        //高程平差
        public void LevAdjust(double H_start, double H_end, List<Segment> L)
        {
            //每段高差
            double h = 0;
            //高程闭合差
            double f;
            //总路线长度
            double len = 0;

            for (int i = 0; i < L.Count; i++)
            {
                h += L[i].deltaH;
                len +=L[i].dis;
            }
            f = h - (H_end - H_start);

            for (int i = 0; i < L.Count; i++)
            {
                L[i].v = -f * L[i].dis / len;
                if (i == 0)
                {
                    L[i].Hs = H_start;
                    L[i].He = L[i].v + H_start + L[i].deltaH;
                }

                else
                {
                    L[i].Hs = L[i - 1].He;
                    L[i].He = L[i].v + L[i - 1].He + L[i].deltaH;
                }
            }
        }

        //图形绘制
        public void DrawP(List<Segment> Segments, double H_start, out Series serP)
        {
            serP = new Series();
            serP.ChartType = SeriesChartType.Point;
            serP.Color = Color.Blue;

            DataPoint p;

            p = new DataPoint();
            p.SetValueXY(0, H_start);
            serP.Points.Add(p);

            double dis = 0;

            for (int i = 0; i < Segments.Count; i++)
            {
                dis += Segments[i].dis;

                p = new DataPoint();
                p.SetValueXY(dis, Segments[i].He);
                serP.Points.Add(p);
            }
        }

        //撰写报告
        //public void Report(List<Station> CStations, List<Segment> Segments, out string re_text)
        //{
             
        //}
        
    }
}
