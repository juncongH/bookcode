using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace test07
{

    class data
    {
        public string name;
        public double x;
        public double y;
        public double z;
        public double A;
        public double E;
        public double T;
        public double D;
    }

    class formula
    {
        public double Bp = 30.0 * Math.PI / 180.0;
        public double Lp = 114.0 * Math.PI / 180.0;
        public double xp=-2225669.7744;
        public double yp = 4998936.1598;
        public double zp = 3265908.9678;

        public void ReadFile(out double T,out List<data> Data)
        {
            Data = new List<data>();
            T = 0;
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog()==DialogResult.OK)
            {
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);
                string str = reader.ReadLine();
                str = new Regex("[\\s]+").Replace(str, " ");
                var arr = str.Split(' ');
                T = Convert.ToDouble(arr[4]) * 3600 + Convert.ToDouble(arr[5]) * 60 + Convert.ToDouble(arr[6]);
                str = reader.ReadLine();
                str = new Regex("[\\s]+").Replace(str, " ");
                data d;
                while (str!=null)
                {
                    str = new Regex("[\\s]+").Replace(str, " ");
                    arr = str.Split(' ');
                    d = new data();
                    d.name = arr[0];
                    d.x = Convert.ToDouble(arr[1]);
                    d.y = Convert.ToDouble(arr[2]);
                    d.z = Convert.ToDouble(arr[3]);

                    Data.Add(d);
                    str = reader.ReadLine();
                    
                }
            }
        }

        public void Cal(List<data> Data)
        {
            double X, Y, Z;
            double namuda, fai, faiM, delta;
            double F, A1, A2, A3, A4, t;
            double a0, a1, a2, a3, b0, b1, b2, b3;

            a0 = 0.1397 * 10e-7;
            a1 = -0.7451 * 10e-8;
            a2 = -0.5960 * 10e-7;
            a3 = 0.1192 * 10e-6;
            b0 = 0.1270 * 10e6;
            b1 = -0.1966 * 10e6;
            b2 = 0.6554 * 10e5;
            b3 = 0.2621 * 10e6;

            for (int i = 0; i < Data.Count; i++)
            {
                X = (-Math.Sin(Bp) * Math.Cos(Lp) * (Data[i].x - xp)) + (-Math.Sin(Bp) * Math.Sin(Lp) * (Data[i].y - yp)) + (Math.Cos(Bp) * (Data[i].z - zp));
                Y = (-Math.Sin(Lp) * (Data[i].x - xp)) + Math.Cos(Lp) * (Data[i].y - yp);
                Z = (Math.Cos(Bp) * Math.Cos(Lp) * (Data[i].x - xp)) + (Math.Cos(Bp) * Math.Sin(Lp) * (Data[i].y - yp)) + Math.Sin(Bp) * (Data[i].z - zp);

                Data[i].A = Math.Atan(Y / X);
                Data[i].E = Math.Atan2(Z, Math.Sqrt(X * X + Y * Y));

                delta = 0.0137 / (Data[i].E + 0.11) - 0.022;
                fai = Bp + delta * Math.Cos(Data[i].A);
                namuda = Lp + delta * Math.Sin(Data[i].A) / Math.Cos(fai);
                faiM = fai + 0.064 * Math.Cos(namuda - 1.617);

                F = 1 + 16 * Math.Pow((0.53 - Data[i].E), 3);
                A1 = 5 * 10e-9;
                A2 = a0 + a1 * faiM + a2 * faiM * faiM + a3 * Math.Pow(faiM, 3);
                A3 = 50400;
                A4 = b0 + b1 * faiM + b2 * faiM * faiM + b3 * Math.Pow(faiM, 3);
                t = 43200 * namuda + Form1.T;

                if(Math.Abs(2*Math.PI*(t-A3)/A4)<1.57)
                {
                    Data[i].T = F * (A1 + A2 * Math.Cos(Math.Abs(2 * Math.PI * (t - A3) / A4)));
                }
                else
                {
                    Data[i].T = F * A1;
                }

                Data[i].D = Data[i].T * 299792458;
            }
        }
    }
}
