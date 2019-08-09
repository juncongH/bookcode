using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TinVolume
{
    class Formula
    {
        //文件读取
        public void ReadFile(out List<dataPoint> DPoints)
        {
            dataPoint p;
            DPoints = new List<dataPoint>();

            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "All files(*.*)|*.*|Text file(*.txt)|*.txt";
            file.FilterIndex = 2;
            file.InitialDirectory = Application.StartupPath;
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
                    p = new dataPoint();

                    p.Name = arr[0];
                    p.X = double.Parse(arr[1]);
                    p.Y = double.Parse(arr[2]);
                    p.H = double.Parse(arr[3]);
                    DPoints.Add(p);

                    str = reader.ReadLine();
                }
            }
            else
                return;
        }

        //建立Tin
        public void GetTin(List<Point> CPoints, out List<Triangle> TinTriangle)
        {
            //三角形列表T1
            List<Triangle> T1;
            //三角形列表T1_temp
            List<Triangle> T1_temp;
            //三角形列表T2
            List<Triangle> T2;
            //边列表SLines
            List<Line> SLines;
            //去除了公共边的边列表
            List<Line> SubSLines;

            //平面坐标的极值
            double xmax, xmin, ymax, ymin;
            xmax = xmin = CPoints[0].X;
            ymax = ymin = CPoints[0].Y;
            //初始矩形四点
            Point P1, P2, P3, P4;

            foreach (Point p in CPoints)
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
            P1 = new Point();
            P1.Name = "P1"; P1.X = xmin - 1.0; P1.Y = ymin - 1.0; P1.num = CPoints.Count;
            P2 = new Point();
            P2.Name = "P2"; P2.X = xmin - 1.0; P2.Y = ymax + 1.0; P2.num = CPoints.Count + 1;
            P3 = new Point();
            P3.Name = "P3"; P3.X = xmax + 1.0; P3.Y = ymax + 1.0; P3.num = CPoints.Count + 2;
            P4 = new Point();
            P4.Name = "P4"; P4.X = xmax + 1.0; P4.Y = ymin - 1.0; P4.num = CPoints.Count + 3;

            T1 = new List<Triangle>();
            Triangle tri = new Triangle();
            tri = tri.NewTriangle(P1, P2, P3);
            T1.Add(tri);
            tri = new Triangle();
            tri = tri.NewTriangle(P1, P3, P4);
            T1.Add(tri);

            foreach (Point pp in CPoints)
            {
                T1_temp = new List<Triangle>();
                T2 = new List<Triangle>();
                SLines = new List<Line>();
                SubSLines = new List<Line>();

                foreach (Triangle T1_tri in T1)
                {
                    if (IsinCircle(pp, T1_tri))
                        T2.Add(T1_tri);
                    else
                        T1_temp.Add(T1_tri);
                }

                foreach (Triangle T2_tri in T2)
                {
                    SLines.Add(T2_tri.l1);
                    SLines.Add(T2_tri.l2);
                    SLines.Add(T2_tri.l3);
                }

                foreach (Line ll in SLines)
                {
                    int Iscorline = 0;
                    foreach (Line lll in SLines)
                    {
                        if (ll.p1.num == lll.p1.num && ll.p2.num == lll.p2.num)
                            Iscorline++;
                    }
                    if (Iscorline == 1)
                        SubSLines.Add(ll);
                }

                T1 = new List<Triangle>();
                if (T1_temp.Count != 0)
                {
                    foreach (Triangle tt in T1_temp)
                    {
                        T1.Add(tt);
                    }
                }
                foreach (Line sl in SubSLines)
                {
                    Triangle ttt = new Triangle();
                    ttt = ttt.NewTriangle(sl, pp);
                    T1.Add(ttt);
                }
            }

            TinTriangle = new List<Triangle>();
            foreach (Triangle t2 in T1)
            {
                if (!(t2.p3.num == P1.num || t2.p3.num == P2.num || t2.p3.num == P3.num || t2.p3.num == P4.num))
                {
                    TinTriangle.Add(t2);
                }
            }

        }

        //判断待插入点是否在三角形外接圆之内
        public bool IsinCircle(Point p, Triangle tri)
        {
            double tx1 = tri.p1.X; double ty1 = tri.p1.Y;
            double tx2 = tri.p2.X; double ty2 = tri.p2.Y;
            double tx3 = tri.p3.X; double ty3 = tri.p3.Y;

            double x0 = ((ty2 - ty1) * (ty3 * ty3 - ty1 * ty1 + tx3 * tx3 - tx1 * tx1) - (ty3 - ty1) * (ty2 * ty2 - ty1 * ty1 + tx2 * tx2 - tx1 * tx1)) / ((tx3 - tx1) * (ty2 - ty1) - (tx2 - tx1) * (ty3 - ty1)) / 2.0;
            double y0 = ((tx2 - tx1) * (tx3 * tx3 - tx1 * tx1 + ty3 * ty3 - ty1 * ty1) - (tx3 - tx1) * (tx2 * tx2 - tx1 * tx1 + ty2 * ty2 - ty1 * ty1)) / ((ty3 - ty1) * (tx2 - tx1) - (ty2 - ty1) * (tx3 - tx1)) / 2.0;
            double r = Math.Sqrt((x0 - tx1) * (x0 - tx1) + (y0 - ty1) * (y0 - ty1));
            double r2 = Math.Sqrt((x0 - p.X) * (x0 - p.X) + (y0 - p.Y) * (y0 - p.Y));

            if (r2 < r)
                return true;
            else
                return false;
        }

        //计算体积
        public void GetVolume(double h0, List<Triangle> TinTriangle, out double V, out List<double> Vi)
        {
            double Si, Hi, vi;
            Vi = new List<double>();

            foreach (Triangle tri in TinTriangle)
            {
                Si = Math.Abs((tri.p2.X - tri.p1.X) * (tri.p3.Y - tri.p1.Y) - (tri.p3.X - tri.p1.X) * (tri.p2.Y - tri.p1.Y)) / 2.0;
                Hi = (tri.p1.H + tri.p2.H + tri.p3.H) / 3.0 - h0;
                vi = Si * Hi;
                Vi.Add(vi);
            }

            double v_temp;
            for (int i = 0; i < Vi.Count ; i++)
            {
                for (int j = 0; j < Vi.Count - 1 - i; j++)
                {
                    if (Vi[j] > Vi[j + 1])
                    {
                        v_temp = Vi[j + 1];
                        Vi[j + 1] = Vi[j];
                        Vi[j] = v_temp;
                    }
                }
            }
            V = 0;
            foreach (double v in Vi)
            {
                V += v;
            }

        }

        //报告撰写
        public void Report(List<Triangle> TinTriangle, List<double> Vi, double h0, double V, out string re_text)
        {
            re_text = "**********************************************************\n";
            re_text += "*************************基本信息*************************\n";
            re_text += "高程基准h0: " + h0 + "\n";
            re_text += "三角形个数: " + TinTriangle.Count + "\n";
            re_text += "体积V: " + V.ToString("f4") + "\n\n";

            re_text += "*************************前20个三角形*************************\n";
            re_text += "序号      " + "三个顶点名   " + "\n";
            for (int i = 0; i < 20; i++)
            {
                re_text += (i + 1) + "     " + TinTriangle[i].Name + "\n";
            }

            re_text += "*************************体积最小的5个三棱柱体积*************************\n";
            for (int i = 0; i < 5; i++)
            {
                re_text += Vi[i].ToString("f4") + "\n";
            }
            re_text += "*************************体积最大的5个三棱柱体积*************************\n";
            for (int i = Vi.Count - 5; i < Vi.Count; i++)
            {
                re_text += Vi[i].ToString("f4") + "\n";
            }
        }
    }
}


