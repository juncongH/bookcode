using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace test09
{
    class Point
    {
        public string name;
        public double x;
        public double y;
        public double z;
        public double S;
    }

    class formula
    {
        public int n = 5;

        public void ReadFile(out List<Point> point)
        {
            point = new List<Point>();
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog()==DialogResult.OK)
            {
                Point p;
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);
                string str = reader.ReadLine();
                while(str!=null)
                {
                    var arr = str.Split(',');
                    p = new Point();
                    p.name = arr[0];
                    p.x = Convert.ToDouble(arr[1]);
                    p.y = Convert.ToDouble(arr[2]);
                    p.z = Convert.ToDouble(arr[3]);

                    str = reader.ReadLine();

                    point.Add(p);
                }
            }
        }

        public void Cal(List<Point> point,double x,double y,out double z)
        {
            for(int i=0; i<point.Count;i++)
            {
                point[i].S = Math.Sqrt((x - point[i].x) * (x - point[i].x) + (y - point[i].y) * (y - point[i].y));
            }

            Point tem;
            for(int i=0;i<point.Count;i++)
            {
                for(int j=i+1;j<point.Count-i-1;j++)
                {
                    if(point[i].S>point[j].S)
                    {
                        tem = point[i];
                        point[i]= point[j];
                        point[j] = tem;
                    }
                }
            }

            double hs = 0, s = 0;
            for(int i=0;i<n;i++)
            {
                hs += (point[i].z / point[i].S);
                s += (1.0 / point[i].S);
            }
            z = hs / s;
        }

        public void Save()
        {

        }
    }
}
