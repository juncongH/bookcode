using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Trianglation
{
    class Formula
    {
        //读取文件
        public void Readfile(out List<Station> CStations, out List<DStation> DStations, out double H_start)
        {
            CStations = new List<Station>();
            DStations = new List<DStation>();
            H_start = 0;

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt";
            file.FilterIndex = 2;
            file.InitialDirectory = Application.StartupPath;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);

                string str = reader.ReadLine();
                var arr = str.Split(',');

                H_start = double.Parse(arr[1]);

                str = reader.ReadLine();

                Station cs;
                DStation ds;

                double n =1;

                while (str != null)
                {
                    cs = new Station();
                    ds = new DStation();

                    arr = str.Split(',');
                    cs.Seg_name = arr[0];
                    ds.Seg_name = arr[0];

                    if ((n % 2) == 1)
                    {
                        cs.toandfor = "往";
                        ds.toandfor = "往";
                    }
                    else
                    {
                        cs.toandfor = "返";
                        ds.toandfor = "返";
                    }
                    n++;

                    str = reader.ReadLine();
                    arr = str.Split(',');
                    cs.S = double.Parse(arr[0]);
                    cs.Alpha = double.Parse(arr[1]);
                    cs.i = double.Parse(arr[2]);
                    cs.v = double.Parse(arr[3]);
                    ds.S = arr[0];
                    ds.Alpha = arr[1];
                    ds.i = arr[2];
                    ds.v = arr[3];

                    CStations.Add(cs);
                    DStations.Add(ds);

                    str = reader.ReadLine();
                    arr = str.Split(',');
                    cs = new Station();
                    ds = new DStation();
                    if ((n % 2) == 1)
                    {
                        cs.toandfor = "往";
                        ds.toandfor = "往";
                    }
                    else
                    {
                        cs.toandfor = "返";
                        ds.toandfor = "返";
                    }
                    cs.S = double.Parse(arr[0]);
                    cs.Alpha = double.Parse(arr[1]);
                    cs.i = double.Parse(arr[2]);
                    cs.v = double.Parse(arr[3]);
                    ds.S = arr[0];
                    ds.Alpha = arr[1];
                    ds.i = arr[2];
                    ds.v = arr[3];

                    CStations.Add(cs);
                    DStations.Add(ds);

                    str = reader.ReadLine();
                }
                reader.Close();
            }
            else
            { return; }
        }

        //角度转弧度
        public double Dms2Rad(double dms)
        {
            int sign = 1;
            int deg, min;
            double sec, rad;
            if (dms < 0)
            {
                sign = -1;
                dms = -dms;
            }
            deg = (int)(dms + 0.0001);
            min = (int)((dms - deg) * 100.0 + 0.0001);
            sec = (dms - deg - min / 100.0) * 10000.0;
            rad = (deg + min / 60.0 + sec / 3600.0) / 180.0 * Math.PI * sign;
            return rad;
        }

        //手簿计算
        public List<Station> CalculStation(List<Station> S)
        {
            double af;
            double k = 0.15;
            double R = 6378137.0;
            for (int i = 0; i < S.Count; i++)
            {
                af = Dms2Rad(S[i].Alpha);

                S[i].D = S[i].S * Math.Cos(af);
                S[i].f = S[i].D * S[i].D / 2.0 / R + (-k * S[i].D * S[i].D / 2.0 / R);

                S[i].h = S[i].D * Math.Tan(af) + S[i].i - S[i].v + S[i].f;

            }
            for (int i = 0; i < S.Count; i = i + 2)
            {
                if (Math.Abs((S[i].h + S[i + 1].h)) > 60.0 * Math.Sqrt(S[i].D/1000.0)/1000.0)
                {
                    S[i].TorF = "F";
                    S[i].h_ave = (S[i].h - S[i + 1].h) / 2.0;
                    MessageBox.Show("对向观测高差较差超限！");
                }
                else
                {
                    S[i].TorF = "T";
                    S[i].h_ave = (S[i].h - S[i + 1].h) / 2.0;
                }
            }

            return S;
        }

        //图形绘制
        public void Drawp(List<HStation> HStations, out Series serp)
        {
            serp = new Series();
            serp.ChartType = SeriesChartType.Area;

            DataPoint p;
            double SigmaD = 0;
            int n = HStations.Count;

            p = new DataPoint();
            p.SetValueXY(0 , HStations[0].Hs);
            serp.Points.Add(p);

            for (int i = 0; i < n; i++)
            {
                SigmaD += HStations[i].D;

                p = new DataPoint();
                p.SetValueXY(SigmaD, HStations[i].He);
                serp.Points.Add(p);
            }
        }

        //平差计算
        public void LevelAdjust(List<Station> S, double H_start, out List<HStation> H)
        {
            H = new List<HStation>();

            HStation HStat;

            double fh = 0;
            double SigmaD = 0;
            double h, D, v, h_v, he, hs;
            string name;

            for (int i = 0; i < S.Count; i++)
            {
                SigmaD += S[i].D;
                if (i % 2 == 0)
                {
                    fh += S[i].h_ave;
                }
            }
            SigmaD /= 2.0;

            if (Math.Abs(fh) > 30.0 * Math.Sqrt(SigmaD / 1000.0) / 1000.0)
            {
                MessageBox.Show("高程闭合差超限！");
                return;
            }
            else
            {
                for (int i = 0; i < S.Count / 2; i++)
                {
                    HStat = new HStation();

                    name = S[2 * i].Seg_name;
                    h = S[2 * i].h_ave;
                    D = (S[2 * i].D + S[2 * i + 1].D) / 2.0;
                    v = -fh * D / SigmaD;
                    h_v = h + v;
                    if (i == 0)
                    {
                        hs = H_start;
                    }
                    else
                    {
                        hs = H[i - 1].He;
                    }
                    he = hs + h_v;

                    HStat.seg_name = name;
                    HStat.h = h;
                    HStat.D = D;
                    HStat.v = v;
                    HStat.h_v = h_v;
                    HStat.Hs = hs;
                    HStat.He = he;

                    H.Add(HStat);

                }
            }

        }

        //精度评定
        public void CalculError(List<HStation> H, out double u)
        {
            double C = 1000.0;
            double tmp = 0;
            for (int i = 0; i < H.Count; i++)
            {
                tmp = tmp + C / H[i].D * H[i].v * H[i].v;
            }
            u = Math.Sqrt(tmp);
        }
    }
}
