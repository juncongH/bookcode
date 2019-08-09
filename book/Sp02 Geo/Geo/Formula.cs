using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
namespace Geo
{
    class Formula
    {
        //椭球基本参数计算
        public void af2e(double a, double f, out double b, out double e1, out double e2)
        {
            b = a - a * f;
            e1 = Math.Sqrt((a * a - b * b) / (a * a));
            e2 = Math.Sqrt((a * a - b * b) / (b * b));
        }

        //正算数据读取
        public void Readfile1(out double a, out double f, out List<DGeoLine> DLines, out List<GeoLine> Clines)
        {
            GeoLine cline;
            DGeoLine dline;
            a = 0;
            f = 0;
            Clines = new List<GeoLine>();
            DLines = new List<DGeoLine>();

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "All files(*.*)|*.*|text files(*.txt)|*.txt";
            file.FilterIndex = 2;
            file.InitialDirectory = Application.StartupPath;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);

                string str = reader.ReadLine();
                var arr = str.Split(',');
                a = double.Parse(arr[0]);
                f = 1.0 / double.Parse(arr[1]);

                str = reader.ReadLine();

                while (str != null)
                {
                    cline = new GeoLine();
                    dline = new DGeoLine();

                    arr = str.Split(',');
                    cline.Name1 = arr[0];
                    cline.B1 = double.Parse(arr[1]);
                    cline.L1 = double.Parse(arr[2]);
                    cline.A1 = double.Parse(arr[3]);
                    cline.S = double.Parse(arr[4]);
                    cline.Name2 = arr[5];

                    Clines.Add(cline);

                    dline.Name1 = cline.Name1;
                    dline.B1 = Dms2Str(cline.B1);
                    dline.L1 = Dms2Str(cline.L1);
                    dline.A1 = Dms2Str(cline.A1);
                    dline.S = cline.S.ToString("f3");
                    dline.Name2 = cline.Name2;

                    DLines.Add(dline);

                    str = reader.ReadLine();
                }
            }
            else
            {
                return;
            }
        }

        //反算数据读取
        public void Readfile2(out double a, out double f, out List<DGeoLine> DLines, out List<GeoLine> Clines)
        {
            GeoLine cline;
            DGeoLine dline;
            a = 0;
            f = 0;
            Clines = new List<GeoLine>();
            DLines = new List<DGeoLine>();

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "All files(*.*)|*.*|text files(*.txt)|*.txt";
            file.FilterIndex = 2;
            file.InitialDirectory = Application.StartupPath;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);

                string str = reader.ReadLine();
                var arr = str.Split(',');
                a = double.Parse(arr[0]);
                f = 1.0 / double.Parse(arr[1]);

                str = reader.ReadLine();

                while (str != null)
                {
                    cline = new GeoLine();
                    dline = new DGeoLine();

                    arr = str.Split(',');
                    cline.Name1 = arr[0];
                    cline.B1 = double.Parse(arr[1]);
                    cline.L1 = double.Parse(arr[2]);
                    cline.Name2 = arr[3];
                    cline.B2 = double.Parse(arr[4]);
                    cline.L2 = double.Parse(arr[5]);

                    Clines.Add(cline);

                    dline.Name1 = cline.Name1;
                    dline.B1 = Dms2Str(cline.B1);
                    dline.L1 = Dms2Str(cline.L1);
                    dline.B2 = Dms2Str(cline.B2);
                    dline.L2 = Dms2Str(cline.L2);
                    dline.Name2 = cline.Name2;

                    DLines.Add(dline);

                    str = reader.ReadLine();
                }
            }
            else
            {
                return;
            }
        }

        //计算参数A,B,C,arfa,beta,gama;
        public void ParameterCal(double a, double f, double sinA, out double A, out double B, out double C, out double alpha, out double beta, out double gama)
        {
            double b, e1, e2;
            af2e(a, f, out b, out e1, out e2);
            double cos2A = 1 - sinA * sinA;
            double k = Math.Sqrt(e2 * e2 * cos2A);

            A = (1.0 - k * k / 4.0 + Math.Pow(k, 4) * 7.0 / 64.0 - Math.Pow(k, 6) * 15.0 / 256.0) / b;
            B = (k * k / 4.0 - Math.Pow(k, 4) / 8.0 + Math.Pow(k, 6) * 37.0 / 512.0);
            C = Math.Pow(k, 4) / 128.0 - Math.Pow(k, 6) / 128.0;

            alpha = (e1 * e1 / 2.0 + Math.Pow(e1, 4) / 8.0 + Math.Pow(e1, 6) / 16.0) - (Math.Pow(e1, 4) / 16.0 + Math.Pow(e1, 6) / 16.0) * cos2A + (3.0 * Math.Pow(e1, 6) / 128.0) * cos2A * cos2A;
            beta = (Math.Pow(e1, 4) / 16.0 + Math.Pow(e1, 6) / 16.0) * cos2A - (Math.Pow(e1, 6) / 32.0) * cos2A * cos2A;
            gama = (Math.Pow(e1, 6) / 256.0) * cos2A * cos2A;
        }

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

        //正算公式
        public void GeolineZheng(double a, double f, double B1, double L1, double A1, double S, out double B2, out double L2, out double A2)
        {
            double b, e1, e2;
            af2e(a, f, out b, out e1, out  e2);

            double W1 = Math.Sqrt(1.0 - e1 * e1 * Math.Sin(B1) * Math.Sin(B1));
            double sinu1 = Math.Sin(B1) * Math.Sqrt(1.0 - e1 * e1) / W1;
            double cosu1 = Math.Cos(B1) / W1;

            double sinA0 = cosu1 * Math.Sin(A1);
            double cotsita1 = cosu1 * Math.Cos(A1) / sinu1;
            double sita1 = Math.Atan(1.0 / cotsita1);

            double A, B, C, alpha, beta, gama;
            ParameterCal(a, f, sinA0, out A, out B, out C, out alpha, out beta, out gama);

            double sita = A * S;
            double sita0 = A * S + B * Math.Sin(sita) * Math.Cos(2.0 * sita1 + sita) + C * Math.Sin(2.0 * sita) * Math.Cos(4.0 * sita1 + 2.0 * sita);

            while (Math.Abs(sita - sita0) <= 0.0000000001)
            {
                sita = sita0;
                sita0 = A * S + B * Math.Sin(sita) * Math.Cos(2.0 * sita1 + sita) + C * Math.Sin(2.0 * sita) * Math.Cos(4.0 * sita1 + 2.0 * sita);

            }

            double kesi = (alpha * sita + beta * Math.Sin(sita) * Math.Cos(2.0 * sita1 + sita) + gama * Math.Sin(2.0 * sita) * Math.Cos(4.0 * sita1 + 2.0 * sita)) * sinA0;

            double sinu2 = sinu1 * Math.Cos(sita) + cosu1 * Math.Cos(A1) * Math.Sin(sita);
            B2 = Math.Atan(sinu2 / (Math.Sqrt(1.0 - e1 * e1) * Math.Sqrt(1.0 - sinu2 * sinu2)));
            double lamta = Math.Atan(Math.Sin(A1) * Math.Sin(sita) / (cosu1 * Math.Cos(sita) - sinu1 * Math.Sin(sita) * Math.Cos(A1)));

            if (Math.Sin(A1) > 0)
            {
                if (Math.Tan(lamta) > 0)
                {
                    lamta = Math.Abs(lamta);
                }
                else
                {
                    lamta = Math.PI - Math.Abs(lamta);
                }
            }
            if (Math.Sin(A1) < 0)
            {
                if (Math.Tan(lamta) > 0)
                {
                    lamta = Math.Abs(lamta) - Math.PI;
                }
                else
                {
                    lamta = 0.0 - Math.Abs(lamta);
                }
            }

            L2 = L1 + lamta - kesi;
            A2 = Math.Atan(cosu1 * Math.Sin(A1) / (cosu1 * Math.Cos(sita) * Math.Cos(A1) - sinu1 * Math.Sin(sita)));
            if (Math.Sin(A1) > 0)
            {
                if (Math.Tan(A2) > 0)
                {
                    A2 = Math.Abs(A2) + Math.PI;
                }
                else
                {
                    A2 = 2.0 * Math.PI - Math.Abs(A2);
                }
            }
            if (Math.Sin(A1) < 0)
            {
                if (Math.Tan(A2) > 0)
                {
                    A2 = Math.Abs(A2);
                }
                else
                {
                    A2 = Math.PI - Math.Abs(A2);
                }
            }

        }

        //反算公式
        public void GeoLineFan(double a, double f, GeoLine G, out double S, out double A1, out double A2)
        {
            G.B1 = Dms2Rad(G.B1);
            G.B2 = Dms2Rad(G.B2);
            G.L1 = Dms2Rad(G.L1);
            G.L2 = Dms2Rad(G.L2);
            double e1 = Math.Sqrt((2 - f) * f);
            double u1, u2;
            double l;

            u1 = Math.Atan(Math.Sqrt(1 - e1 * e1) * Math.Tan(G.B1));
            u2 = Math.Atan(Math.Sqrt(1 - e1 * e1) * Math.Tan(G.B2));
            l = G.L2 - G.L1;

            double a1, a2, b1, b2;
            a1 = Math.Sin(u1) * Math.Sin(u2);
            a2 = Math.Cos(u1) * Math.Cos(u2);
            b1 = Math.Cos(u1) * Math.Sin(u2);
            b2 = Math.Sin(u1) * Math.Cos(u2);

            double namda, delta, delta1, sigma, sigma1;
            double A, B, C, arfa, beta, gama;
            double p, q, sinA0;
            delta = 0;

            //循环体
            do
            {
                namda = l + delta;
                p = Math.Cos(u2) * Math.Sin(namda);
                q = b1 - b2 * Math.Cos(namda);
                G.A1 = Math.Atan(p / q);
                if (p > 0)
                {
                    if (q > 0)
                        G.A1 = Math.Abs(G.A1);
                    else
                        G.A1 = Math.PI - Math.Abs(G.A1);
                }
                else
                {
                    if (q > 0)
                        G.A1 = 2 * Math.PI - Math.Abs(G.A1);
                    else
                        G.A1 = Math.PI + Math.Abs(G.A1);
                }
                if (G.A1 < 0)
                    G.A1 = G.A1 + 2 * Math.PI;
                if (G.A1 > 2 * Math.PI)
                    G.A1 = G.A1 - 2 * Math.PI;

                sigma = Math.Atan((p * Math.Sin(G.A1) + q * Math.Cos(G.A1)) / (a1 + a2 * Math.Cos(namda)));
                if (a1 + a2 * Math.Cos(namda) > 0)
                    sigma = Math.Abs(sigma);
                else
                    sigma = Math.PI - Math.Abs(sigma);

                sinA0 = Math.Cos(u1) * Math.Sin(G.A1);
                sigma1 = Math.Atan(Math.Tan(u1) / Math.Cos(G.A1));
                ParameterCal(a, f, sinA0, out A, out B, out C, out arfa, out beta, out gama);
                delta1 = delta;
                delta = (arfa * sigma + beta * Math.Cos(2 * sigma1 + sigma) * Math.Sin(sigma) + gama * Math.Sin(2 * sigma) * Math.Cos(4 * sigma1 + 2 * sigma)) * sinA0;
            } while (Math.Abs(delta - delta1) > 1e-10);

            sigma1 = Math.Atan(Math.Tan(u1) / Math.Cos(G.A1));
            G.S = ((sigma - B * Math.Sin(sigma) * Math.Cos(2 * sigma1 + sigma) - C * Math.Sin(2 * sigma) * Math.Cos(4 * sigma1 + 2 * sigma))) / A;
            G.A2 = Math.Atan(Math.Cos(u1) * Math.Sin(namda) / (b1 * Math.Cos(namda) - b2));
            if (G.A2 < 0)
                G.A2 = G.A2 + Math.PI * 2;
            if (G.A2 > Math.PI * 2.0)
                G.A2 = G.A2 - Math.PI * 2;
            if (G.A1 < Math.PI && G.A2 < Math.PI)
                G.A2 = G.A2 + Math.PI;
            if (G.A1 > Math.PI && G.A2 > Math.PI)
                G.A2 = G.A2 - Math.PI;

            S = G.S;
            A1 = G.A1;
            A2 = G.A2;
        }

        //绘图
        public void DrawLines()
    }
}
