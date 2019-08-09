using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace test06
{
    class Point
    {
        public string name;
        public double x;
        public double y;
        public double d;
    }

    class formula
    {
        public List<Point> result = new List<Point>();

        double yuzhi = 5;

        public void ReadFile(out List<Point> point)
        {
            point = new List<Point>();
            Point p;

            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog()==DialogResult.OK)
            {
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);
                string str = reader.ReadLine();
                while (str != null)
                {
                    var arr = str.Split(',');
                    p = new Point();
                    p.name = arr[0];
                    p.x = Convert.ToDouble(arr[1]);
                    p.y = Convert.ToDouble(arr[2]);
                    str = reader.ReadLine();
                    point.Add(p);
                }
            }

        }

        public void  DP(List<Point> point)
        {
            double A, B, C;
            A = (point[point.Count - 1].y - point[0].y) / (point[point.Count - 1].x - point[0].x);
            B = -1;
            C = point[0].y - point[0].x * A;

            for(int i=0;i<=point.Count-1;i++)
            {
                point[i].d = (Math.Abs(A * point[i].x + B * point[i].y + C) / Math.Sqrt(A * A + B * B));
            }

            double dmax = 0;
            int index = 0;
            for(int i=0;i<point.Count-1;i++)
            {
                if (dmax < point[i].d)
                {
                    dmax = point[i].d;
                    index = i;
                }
            }

            Point p;
            if (point[index].d>=yuzhi)
            {
                List<Point> p1=new List<Point>();
                List<Point> p2 = new List<Point>();
               
                for(int i=0;i<=index;i++)
                {
                    p = new Point();
                    p = point[i];
                    p1.Add(p);
                }
                for(int j=index;j<=point.Count-1;j++)
                {
                    p = new Point();
                    p = point[j];
                    p2.Add(p);
                }
                DP(p1);
                DP(p2);
            }
            else
            {
                point.RemoveRange(1, point.Count - 2);
            }
            for (int i = 0; i < point.Count; i++)
            {
                p = new Point();
                p = point[i];
                result.Add(p);
                for (int j=0;j<result.Count-1; j++)
                {
                    if (result[j].name == p.name)
                        result.Remove(p);
                    if (result[j].d != 0)
                        result.Remove(result[j]);
                }
            }
        }
    }
}
