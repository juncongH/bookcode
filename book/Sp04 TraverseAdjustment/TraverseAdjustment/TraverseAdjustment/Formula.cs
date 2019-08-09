using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TraverseAdjustment
{
    class Formula
    {
        //度分秒转换为弧度
        public double Dms2Rad(double dms)
        {
            int sign = 1;
            double rad = 0, sec = 0;
            int deg = 0, min = 0;
            if (dms < 0)
            {
                sign = -1;
                dms = -dms;
            }
            deg = (int)(dms + 0.0001);
            min = (int)((dms - deg) * 100 + 0.0001);
            sec = (dms - deg - min / 100.0) * 10000.0;
            rad = (deg + min / 60.0 + sec / 3600.0) / 180.0 * Math.PI * sign;

            return rad;
        }

        //度分秒转换为带单位文本
        public string Dms2Str(double dms)
        {
            int sign = 1;
            double sec = 0;
            int deg = 0, min = 0;
            string str = null;
            if (dms < 0)
            {
                sign = -1;
                dms = -dms;
            }
            deg = (int)(dms + 0.0001);
            min = (int)((dms - deg) * 100 + 0.0001);
            sec = (dms - deg - min / 100.0) * 10000.0;
            str += deg.ToString() + "°" + min.ToString() + "′" + sec.ToString("f2") + "″";
            if (sign == -1)
                str = "-" + str;

            return str;
        }

        //弧度转换为度分秒
        public double Rad2Dms(double rad)
        {
            int sign = 1;
            double dms = 0, sec = 0;
            int deg = 0, min = 0;
            if (rad < 0)
            {
                sign = -1;
                rad = -rad;
            }
            dms = rad / Math.PI * 180.0;
            deg = (int)(dms + 0.0001);
            min = (int)((dms - deg) * 60.0 + 0.0001);
            sec = (dms - deg - min / 60.0) * 3600.0;
            dms = deg + min / 100.0 + sec / 10000.0;
            dms = sign * dms;

            return dms;
        }

        //用于计算起始方位角
        public double Azimuth1(double x1, double y1, double x2, double y2)
        {
            //atan2函数返回-180至180的弧度值
            double azimuth = Math.Atan2((y1 - y2), (x1 - x2));
            if (azimuth < 0)
                azimuth += 2.0 * Math.PI;

            return azimuth;
        }

        //计算某点下一条边的方位角
        public double Azimuth2(double alpha, double beta)
        {
            double azimuth = alpha + Math.PI + beta;
            if (azimuth >= 2.0 * Math.PI)
                azimuth -= 2.0 * Math.PI;

            return azimuth;
        }

        //读取文件数据
        public void Readfile(out double c1, out double c2, out double c3, out List<Point> SP, out List<Point> CP)
        {
            //SP是控制点数据，CP是用于计算的测量数据，c是仪器误差常数
            SP = new List<Point>();
            CP = new List<Point>();
            c1 = new double();
            c2 = new double();
            c3 = new double();

            OpenFileDialog file = new OpenFileDialog();
            file.InitialDirectory = Application.StartupPath;
            file.Filter = "All files(*.*)|*.*|text files(*.txt)|*.txt";
            file.FilterIndex = 2;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);

                string str = reader.ReadLine();
                var arr = str.Split(',');
                c1 = double.Parse(arr[0]); c2 = double.Parse(arr[1]); c3 = double.Parse(arr[2]);

                for (int i = 0; i < 4; i++)
                {
                    str = reader.ReadLine();
                    arr = str.Split(',');
                    Point p = new Point();
                    p.Name = arr[0]; p.X = double.Parse(arr[1]); p.Y = double.Parse(arr[2]);
                    SP.Add(p);
                }

                int count = 0;
                str = reader.ReadLine();
                while (str != null)
                {
                    string str2 = null;
                    str2 = reader.ReadLine();
                    if (str2.Contains("L"))
                    {
                        str2 = reader.ReadLine();
                        arr = str2.Split(',');
                        Point p = new Point();
                        p.Name = str; p.Angle = Dms2Rad(double.Parse(arr[2]));
                        CP.Add(p);
                        str = reader.ReadLine();
                    }
                    else if (str2.Contains("S"))
                    {
                        CP[count].S = double.Parse(str2.Split(',')[2]);
                        count++;
                        str = reader.ReadLine();
                    }
                }
            }
            else 
            {
                return;
            }

        }

        //撰写报告
        public string report(double allowance, double allowance2, double n1, double SigmaS, double fbeta, double fx, double fy, double SAzimuth, double EAzimuth, List<Point> CPoints, List<Point> SPoints)
        {
            string richtext = null;
            richtext += "****************************************************************\n";
            richtext += "************************附合导线平差计算************************\n\n";

            richtext += "****************************限差要求****************************\n";
            richtext += "方位角闭合差限差：" + allowance.ToString("f3") + "″\n";
            richtext += "导线全长相对闭合差限差：" + allowance2.ToString("f8") + "″\n\n";

            richtext += "**************************导线基本信息**************************\n";
            richtext += "测站数：" + n1 + "\n";
            richtext += "导线全长：" + SigmaS + "m\n";
            richtext += "方位角闭合差：" + (fbeta / Math.PI * 180.0 * 3600.0).ToString("f3") + "″\n";
            richtext += "各站角度改正值：" + (-fbeta / Math.PI * 180.0 * 3600.0 / 19.0).ToString("f3") + "″\n";
            richtext += "X坐标闭合差：" + fx + "m\n";
            richtext += "Y坐标闭合差：" + fy + "m\n\n";

            richtext += "****************************角度数据****************************\n";
            richtext += "                                                   方位角\n";
            richtext += "测站名                观测角                             \n";
            richtext += "                                                   方位角\n";
            richtext += "                                                   " + Dms2Str(Rad2Dms(SAzimuth)) + "\n";
            for (int i = 0; i < n1; i++)
            {
                richtext += CPoints[i].Name + "                " + Dms2Str(Rad2Dms(CPoints[i].Angle)) + "\n";
                richtext += "                                                   " + Dms2Str(Rad2Dms(CPoints[i].Azimuth)) + "\n";

            }

            richtext += "****************************站点坐标****************************\n";
            richtext += "测站名              X坐标              Y坐标\n";
            for (int i = 0; i < n1; i++)
            {
                richtext += CPoints[i].Name + "              " + CPoints[i].X.ToString("f4") + "              " + CPoints[i].Y.ToString("f4") + "\n";
            }


            return richtext;
        }
    }
}
