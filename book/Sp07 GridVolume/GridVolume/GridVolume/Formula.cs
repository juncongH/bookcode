using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;
using System.Drawing;

namespace GridVolume
{
    class Formula
    {
        //读取数据文件
        public void ReadFile(out List<Point> DPoints)
        {
            Point p;
            DPoints = new List<Point>();

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

                while (str != null)
                {
                    arr = str.Split(',');
                    p = new Point();
                    p.Name = arr[0];
                    p.X = double.Parse(arr[1]);
                    p.Y = double.Parse(arr[2]);
                    p.H = double.Parse(arr[3]);
                    DPoints.Add(p);
                    str = reader.ReadLine();
                }
            }

        }

        //绘制散点图
        public void DrawPoints(List<Point> DPoints, out Series serP, out double xmax, out double xmin, out double ymax, out double ymin)
        {
            int n = DPoints.Count();
            xmin = xmax = DPoints[0].X;
            ymin = ymax = DPoints[0].Y;
            for (int i = 0; i < n; i++)
            {
                if (DPoints[i].X > xmax)
                    xmax = DPoints[i].X;
                if (DPoints[i].X < xmin)
                    xmin = DPoints[i].X;
                if (DPoints[i].Y > ymax)
                    ymax = DPoints[i].Y;
                if (DPoints[i].Y < ymin)
                    ymin = DPoints[i].Y;
            }
            serP = new Series();
            serP.ChartType = SeriesChartType.Point;
            serP.Color = Color.Blue;
            DataPoint p;
            for (int i = 0; i < n; i++)
            {
                p = new DataPoint();
                p.SetValueXY(DPoints[i].X, DPoints[i].Y);
                serP.Points.Add(p);
            }
        }

        //派生一个类，存储角度
        class OrderP : Point
        {
            public Point p { set; get; }
            public double angle { set; get; }
        }

        //生成凸包多边形
        public void Polygon(List<Point> CPoints, out Point P0, out List<Point> OPoints, out List<Point> PolyPoints1)
        {
            OPoints = new List<Point>();

            int n = CPoints.Count();
            double ymin = CPoints[0].Y;
            P0 = CPoints[0];
            for (int i = 0; i < n; i++)
            {
                if (CPoints[i].Y < ymin)
                {
                    ymin = CPoints[i].Y;
                    P0 = CPoints[i];
                }
            }

            List<OrderP> OrderPoint = new List<OrderP>();
            OrderP orderP;
            for (int i = 0; i < n; i++)
            {
                if (CPoints[i] != P0)
                {
                    orderP = new OrderP();
                    orderP.p = CPoints[i];
                    orderP.angle = Math.Atan2(CPoints[i].Y - P0.Y, CPoints[i].X - P0.X);
                    OrderPoint.Add(orderP);
                }
            }

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - 2 - i; j++)
                {
                    if (OrderPoint[j].angle > OrderPoint[j + 1].angle)
                    {
                        OrderP p = new OrderP();
                        p = OrderPoint[j + 1];
                        OrderPoint[j + 1] = OrderPoint[j];
                        OrderPoint[j] = p;
                    }
                }
            }

            for (int i = 0; i < OrderPoint.Count; i++)
            {
                if (i != OrderPoint.Count - 1)
                {
                    if (OrderPoint[i].angle != OrderPoint[i + 1].angle)
                    {
                        OPoints.Add(OrderPoint[i].p);
                    }
                    else
                        i++;
                }
                else
                {
                    OPoints.Add(OrderPoint[i].p);
                }

            }

            List<Point> PolyPoints = new List<Point>();
            PolyPoints.Add(P0);
            Point pi, pj, pk;
            double m;
            int count = OPoints.Count + 1;
            int n1 = count - 2;
            int pc = count;

            for (int i = 0; i < OPoints.Count; i++)
            {
                PolyPoints.Add(OPoints[i]);
            }

            for (int i = 1; i < n1; i++)
            {
                pi = PolyPoints[i];
                pj = PolyPoints[i + 1];
                pk = PolyPoints[i + 2];
                m = (pi.X - pj.X) * (pk.Y - pj.Y) - (pi.Y - pj.Y) * (pk.X - pj.X);
                if (m >= 0)
                {
                    for (int j = i + 1; j < count - 1; j++)
                    {
                        PolyPoints[j] = PolyPoints[j + 1];
                    }
                    i = 1;
                    pc--;
                    n1--;
                }
            }

            PolyPoints1 = new List<Point>();
            for (int i = 0; i < pc; i++)
            {
                PolyPoints1.Add(PolyPoints[i]);
            }

        }

        //绘制凸包多边形
        public void DrawPoly(List<Point> PolyPoints, out Series serL)
        {
            int n = PolyPoints.Count;
            serL = new Series();
            serL.ChartType = SeriesChartType.Line;
            serL.Color = Color.Red;
            DataPoint p;
            for (int i = 0; i < n; i++)
            {
                p = new DataPoint();
                p.SetValueXY(PolyPoints[i].X, PolyPoints[i].Y);
                serL.Points.Add(p);
            }
            p = new DataPoint();
            p.SetValueXY(PolyPoints[0].X, PolyPoints[0].Y);
            serL.Points.Add(p);
        }

        //建立格网
        public void Grid(double L, List<Point> PolyPoints, out List<GridPoint> GPoints, out double xmax, out double xmin, out double ymax, out double ymin)
        {
            xmax = xmin = PolyPoints[0].X;
            ymax = ymin = PolyPoints[0].Y;
            foreach (Point p in PolyPoints)
            {
                if (xmax < p.X)
                    xmax = p.X;
                if (xmin > p.X)
                    xmin = p.X;
                if (ymax < p.Y)
                    ymax = p.Y;
                if (ymin > p.Y)
                    ymin = p.Y;
            }

            PolyPoints.Add(PolyPoints[0]);
            int pn = PolyPoints.Count;

            GPoints = new List<GridPoint>();
            GridPoint g;
            double xi = (int)((xmax - xmin) / L);
            double yi = (int)((ymax - ymin) / L);
            for (int i = 0; i <= yi; i++)
            {
                for (int j = 0; j <= xi; j++)
                {
                    g = new GridPoint();
                    g.p1 = new Point();
                    g.p2 = new Point();
                    g.p3 = new Point();
                    g.p4 = new Point();
                    g.p0 = new Point();
                    g.p1.X = xmin + j * L;
                    g.p1.Y = ymin + i * L;
                    g.p2.X = xmin + (j + 1) * L;
                    g.p2.Y = ymin + i * L;
                    g.p3.X = xmin + (j + 1) * L;
                    g.p3.Y = ymin + (i + 1) * L;
                    g.p4.X = xmin + j * L;
                    g.p4.Y = ymin + (i + 1) * L;
                    g.p0.X = xmin + (j + 0.5) * L;
                    g.p0.Y = ymin + (i + 0.5) * L;

                    int xn = 0;
                    for (int k = 0; k < pn - 1; k++)
                    {
                        if ((g.p0.Y - PolyPoints[k].Y) * (g.p0.Y - PolyPoints[k + 1].Y) <= 0)
                        {
                            if ((PolyPoints[k + 1].X - PolyPoints[k].X) * (g.p0.Y - PolyPoints[k].Y) / (PolyPoints[k + 1].Y - PolyPoints[k].Y) + PolyPoints[k].X > g.p0.X)
                                xn++;
                        }
                    }
                    if (xn % 2 == 1)
                        g.InPoly = true;
                    else
                        g.InPoly = false;
                    GPoints.Add(g);
                }
            }

        }

        //绘制格网
        public void DrawGrid(double L, double xmax, double xmin, double ymax, double ymin, out List<Point> serGPoints)
        {
            int xi = (int)((xmax - xmin) / L + 1);
            int yi = (int)((ymax - ymin) / L + 1);
            Point p1; Point p2;
            serGPoints = new List<Point>();
            for (int i = 0; i <= xi; i++)
            {
                p1 = new Point();
                p1.X = xmin + i * L;
                p1.Y = ymin;
                p2 = new Point();
                p2.X = xmin + i * L;
                p2.Y = ymin + yi * L;

                if (i % 2 == 0)
                {
                    serGPoints.Add(p1);
                    serGPoints.Add(p2);
                }
                else
                {
                    serGPoints.Add(p2);
                    serGPoints.Add(p1);
                }
            }
            for (int i = yi; i >= 0; i--)
            {
                p1 = new Point();
                p1.X = xmin;
                p1.Y = ymin + i * L;
                p2 = new Point();
                p2.X = xmin + xi * L;
                p2.Y = ymin + i * L;

                if (yi % 2 == 1)
                {
                    if (i % 2 == 1)
                    {
                        serGPoints.Add(p2);
                        serGPoints.Add(p1);
                    }
                    else
                    {
                        serGPoints.Add(p1);
                        serGPoints.Add(p2);
                    }
                }
                else
                {
                    if (i % 2 == 0)
                    {
                        serGPoints.Add(p2);
                        serGPoints.Add(p1);
                    }
                    else
                    {
                        serGPoints.Add(p1);
                        serGPoints.Add(p2);
                    }
                }
            } 
        }

        //计算体积
        public void CVolume(double L, double h0, double r, List<Point> CPoints, List<GridPoint> GPoints, out double V)
        {
            V = 0;
            foreach (GridPoint gp in GPoints)
            {
                if (gp.InPoly == true)
                {
                    double h1 = 0; double h2 = 0; double h3 = 0; double h4 = 0;
                    GetHi(r, gp.p1, CPoints, out h1);
                    GetHi(r, gp.p2, CPoints, out h2);
                    GetHi(r, gp.p3, CPoints, out h3);
                    GetHi(r, gp.p4, CPoints, out h4);
                    V += ((h1 + h2 + h3 + h4) / 4.0 - h0) * L * L;
                }
            }
        }

        //反距离插值
        public void GetHi(double r, Point gpi, List<Point> CPoints, out double h)
        {
            double h_d = 0;
            double one_d = 0;
            foreach (Point p in CPoints)
            {
                if (p.X >= gpi.X - r && p.X <= gpi.X + r && p.Y >= gpi.Y - r && p.Y <= gpi.Y + r)
                {
                    double d = Math.Sqrt((p.X - gpi.X) * (p.X - gpi.X) + (p.Y - gpi.Y) * (p.Y - gpi.Y));
                    if (d <= r)
                    {
                        h_d += p.H / d;
                        one_d += 1.0 / d;
                    }

                }
            }
            h = h_d / one_d;
        }

        //报告
        public void Report(double L, double h0, double xmax, double xmin, double ymax, double ymin, List<GridPoint> GPoints, List<Point> PolyPoints, List<Point> CPoints, double V, out string re_text)
        {
            re_text = "**********************************************************\n";

            re_text += "*************************基本信息*************************\n";
            re_text += "数据点总数n： " + CPoints.Count + "\n";
            re_text += "X坐标最大值Xmax： " + xmax + "\n";
            re_text += "X坐标最小值Xmin： " + xmin + "\n";
            re_text += "Y坐标最大值Ymax： " + ymax + "\n";
            re_text += "Y坐标最小值Ymin： " + ymin + "\n";
            re_text += "凸包点总数:  " + (PolyPoints.Count - 1) + "\n";
            re_text += "格网边长L： " + L + "\n";
            re_text += "高程基准h0： " + h0 + "\n";
            re_text += "格网总数： " + GPoints.Count + "\n";
            re_text += "总体积V： " + V.ToString("f4") + "\n\n";

            re_text += "*************************凸包信息*************************\n";
            re_text += "点名        X坐标        Y坐标          Z坐标\n";
            int n = PolyPoints.Count;
            for (int i = 0; i < n - 1; i++)
            {
                re_text += PolyPoints[i].Name + "     " + PolyPoints[i].X.ToString("f3") + "     " + PolyPoints[i].Y.ToString("f3") + "     " + PolyPoints[i].H.ToString("f3") + "\n";
            }

        }
    }
}
