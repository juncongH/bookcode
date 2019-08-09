using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Pro_Sec
{
    class Formula
    {
        //派生类用于计算内插高程
        class D_CPoint : Point
        {
            public double D;
        }

        //读取文件
        public void Readfile(out double H0, out List<Point> CPoints, out Point K0, out Point K1, out Point K2)
        {
            CPoints = new List<Point>();
            K0 = new Point();
            K1 = new Point();
            K2 = new Point();
            H0 = 0;

            Point pp;

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "All Files(*.*)|*.*|Text Files(*.txt)|*.txt";
            file.FilterIndex = 2;
            file.InitialDirectory = Application.StartupPath;
            file.RestoreDirectory = true;

            if (file.ShowDialog() == DialogResult.OK)
            {
                string path = file.FileName.ToString();
                StreamReader reader = new StreamReader(path);

                string str = reader.ReadLine();
                var arr = str.Split(',');

                H0 = double.Parse(arr[1]);

                str = reader.ReadLine();
                str = reader.ReadLine();
                str = reader.ReadLine();

                while (str != null)
                {
                    pp = new Point();
                    arr = str.Split(',');
                    pp.Name = arr[0];
                    pp.X = double.Parse(arr[1]);
                    pp.Y = double.Parse(arr[2]);
                    pp.H = double.Parse(arr[3]);

                    if (arr[0] == "K0")
                    {
                        K0 = pp;
                    }
                    if (arr[0] == "K1")
                    {
                        K1 = pp;
                    }
                    if (arr[0] == "K2")
                    {
                        K2 = pp;
                    }

                    CPoints.Add(pp);

                    str = reader.ReadLine();
                }
            }
            else
            {
                return;
            }
        }


        //方位角计算，返回弧度制
        public void CalAngle(double x1, double y1, double x2, double y2, out double alpha)
        {
            if ((x2 - x1) == 0)
            {
                if ((y2 - y1) > 0)
                    alpha = Math.PI / 2.0;
                else
                    alpha = Math.PI * 3.0 / 2.0;
            }
            else
            {
                alpha = Math.Atan((y2 - y1) / (x2 - x1));
                if ((y2 - y1 > 0))
                {
                    if ((x2 - x1 < 0))
                        alpha = Math.PI + alpha;
                }
                else
                {
                    if ((x2 - x1 < 0))
                        alpha = Math.PI + alpha;
                    else
                        alpha = Math.PI * 2.0 + alpha;
                }
            }
        }

        //计算内插点高程
        public void ComputeH(List<Point> CPoint, double X, double Y, out double H)
        {
            List<D_CPoint> D = new List<D_CPoint>();
            D_CPoint tmp;
            for (int i = 0; i < CPoint.Count; i++)
            {
                D_CPoint p = new D_CPoint();
                p.D = Math.Sqrt((X - CPoint[i].X) * (X - CPoint[i].X) + (Y - CPoint[i].Y) * (Y - CPoint[i].Y));
                p.H = CPoint[i].H;
                p.X = CPoint[i].X;
                p.Y = CPoint[i].Y;
                D.Add(p);
            }
            for (int i = 0; i < D.Count; i++)
            {
                for (int j = i; j < D.Count; j++)
                {
                    if (D[j].D < D[i].D)
                    {
                        tmp = new D_CPoint();
                        tmp = D[i];
                        D[i] = D[j];
                        D[j] = tmp;
                    }
                }
            }

            double CouH = 0, CouD = 0;
            for (int i = 0; i < 5; i++)
            {
                CouH = CouH + D[i].H / D[i].D;
                CouD = CouD + 1.0 / D[i].D;
            }

            H = CouH / CouD;
        }

        //计算内差点的坐标
        public void ComputePro_P(List<Point> CPoints, Point K0, Point K1, Point K2, out List<Point> Pro_P)
        {
            Pro_P = new List<Point>();
            Point pp;
            double delta = 10.0;

            double alpha01,alpha12;
            CalAngle(K0.X,K0.Y,K1.X,K1.Y,out alpha01);
            CalAngle(K1.X,K1.Y,K2.X,K2.Y,out alpha12);

            Pro_P.Add(K0);

            int i1 = (int)(Math.Sqrt((K0.X - K1.X) * (K0.X - K1.X) + (K0.Y - K1.Y) * (K0.Y - K1.Y))/delta);
            int i2 = (int)(Math.Sqrt((K2.X - K1.X) * (K2.X - K1.X) + (K2.Y - K1.Y) * (K2.Y - K1.Y))/delta);

            for (int i = 1; i <= i1; i++)
            {
                pp = new Point();

                double px = K0.X + i * delta * Math.Cos(alpha01);
                double py = K0.Y + i * delta * Math.Sin(alpha01);
                double ph = 0;
                ComputeH(CPoints, px, py, out ph);

                pp.X = px; pp.Y = py; pp.H = ph;
                Pro_P.Add(pp);
            }

            Pro_P.Add(K1);

            for (int i = 1; i <= i2; i++)
            {
                pp = new Point();

                double px = K1.X + i * delta * Math.Cos(alpha12);
                double py = K1.Y + i * delta * Math.Sin(alpha12);
                double ph = 0;
                ComputeH(CPoints, px, py, out ph);

                pp.X = px; pp.Y = py; pp.H = ph;
                Pro_P.Add(pp);
            }

            Pro_P.Add(K2);
        }

        //计算纵断面面积
        public void ComputePro_Area(List<Point> Pro_points, double h0, Point K0, Point K1, Point K2, out double pro_area)
        {
            int index = 0;
            double delta = 10.0;
            //两点间的面积
            double S;
            int count = Pro_points.Count;
            pro_area = 0;
            for (int i = 0; i < count; i++)
            {
                if (Pro_points[i].Name == "K1")
                    index = i;
            }
            //K1点前的总面积
            for (int i = 0; i < index - 1; i++)
            {
                S = (Pro_points[i].H + Pro_points[i + 1].H - 2.0 * h0) / 2.0 * delta;
                pro_area += S;
            }

            //K0 K1距离
            //K1 K2距离
            double d1 = Math.Sqrt(Math.Pow((Pro_points[index].X - Pro_points[0].X), 2) + Math.Pow((Pro_points[index].Y - Pro_points[0].Y), 2));
            double d2 = Math.Sqrt(Math.Pow((Pro_points[index].X - Pro_points[count-1].X), 2) + Math.Pow((Pro_points[index].Y - Pro_points[count-1].Y), 2));
            pro_area = pro_area + (Pro_points[index - 1].H + Pro_points[index].H - 2.0 * h0) / 2.0 * (d1 - (index - 1) * delta);

            for (int i = index; i < count - 1; i++)
            {
                S = (Pro_points[i].H + Pro_points[i + 1].H - 2.0 * h0) / 2.0 * delta;
                pro_area += S;
            }
            pro_area = pro_area + (Pro_points[count-1].H + Pro_points[count - 2].H - 2.0 * h0) / 2.0 * (d2 - (count - index - 1) * delta);
        }

        //计算横断面中心点
        public void ComputeMN(Point K0, Point K1, Point K2, out Point M, out Point N)
        {
            M = new Point();
            M.Name = "M";
            M.X = (K0.X + K1.X) / 2.0;
            M.Y = (K0.Y + K1.Y) / 2.0;

            N = new Point();
            N.Name = "N";
            N.X = (K1.X + K2.X) / 2.0;
            N.Y = (K1.Y + K2.Y) / 2.0;
        }
        //横断面面积计算
        public void Compute_Area(List<Point> M, double h0, out double Area)
        {
            Area = 0;
            double S;
            double delta = 10.0;
            for (int i = 0; i < M.Count - 1; i++)
            {
                S = (M[i].H + M[i + 1].H - 2 * h0) / 2.0 * delta;
                Area += S;
            }
        }

        //横断面M内插
        public void ComputeM_P(Point K0, Point K1, Point M, List<Point> CPoint, out List<Point> M_P)
        {
            double delta = 10.0;
            double A01;
            double Am;
            CalAngle(K0.X, K0.Y, K1.X, K1.Y, out A01);
            Am = A01 + Math.PI / 2.0;

            Point p;
            M_P = new List<Point>();
            for (int i = -5; i <= 5; i++)
            {
                double h;
                p = new Point();
                p.X = M.X + i * delta * Math.Cos(Am);
                p.Y = M.Y + i * delta * Math.Sin(Am);
                ComputeH(CPoint, p.X, p.Y, out h);
                p.H = h;
                M_P.Add(p);
            }
        }
        //横断面N内插
        public void ComputeN_P(Point K1, Point K2, Point N, List<Point> CPoint, out List<Point> N_P)
        {
            double delta = 10.0;
            double A12;
            double An;
            CalAngle(K1.X, K1.Y, K2.X, K2.Y, out A12);
            An = A12 + Math.PI / 2.0;

            Point p;
            N_P = new List<Point>();
            for (int i = -5; i <= 5; i++)
            {
                double h;
                p = new Point();
                p.X = N.X + i * delta * Math.Cos(An);
                p.Y = N.Y + i * delta * Math.Sin(An);
                ComputeH(CPoint, p.X, p.Y, out h);
                p.H = h;
                N_P.Add(p);
            }
        }

        //回执图形
        public void Draw(List<Point> Pro_P, List<Point> M_P, List<Point> N_P, List<Point> CPoints, out Series SerP, out Series SerPro, out Series SerPro1, out Series SerPro2, out Series SerM, out Series SerN)
        {
            SerP = new Series();
            SerPro = new Series();
            SerPro1 = new Series();
            SerPro2 = new Series();
            SerM = new Series();
            SerN = new Series();
            SerP.ChartType = SeriesChartType.Point;
            SerPro.ChartType = SeriesChartType.Line;
            SerPro1.ChartType = SeriesChartType.Line;
            SerPro2.ChartType = SeriesChartType.Line;
            SerM.ChartType = SeriesChartType.Area;
            SerN.ChartType = SeriesChartType.Area;

            DataPoint p = new DataPoint();

            for (int i = 0; i < CPoints.Count; i++)
            {
                p = new DataPoint();
                p.SetValueXY(CPoints[i].X, CPoints[i].Y);
                SerP.Points.Add(p);
            }

            for (int i = 0; i < Pro_P.Count; i++)
            {
                p = new DataPoint();
                p.SetValueXY(Pro_P[i].X, Pro_P[i].Y);
                SerPro.Points.Add(p);
            }
            for (int i = 0; i < M_P.Count; i++)
            {
                p = new DataPoint();
                p.SetValueXY(M_P[i].X, M_P[i].Y);
                SerPro1.Points.Add(p);
            }
            for (int i = 0; i < N_P.Count; i++)
            {
                p = new DataPoint();
                p.SetValueXY(N_P[i].X, N_P[i].Y);
                SerPro2.Points.Add(p);
            }

            for (int i = 0; i < M_P.Count; i++)
            {
                p = new DataPoint();
                p.SetValueXY(M_P[i].X, M_P[i].H);
                SerM.Points.Add(p);
            }

            for (int i = 0; i < N_P.Count; i++)
            {
                p = new DataPoint();
                p.SetValueXY(N_P[i].X,N_P[i].H);
                SerN.Points.Add(p);
            }
        }
    }
}
