using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace test05
{
    class data
    {
        public double Y;
        public double M;
        public double D;
        public double H;
        public double N;
        public double S;
    }


    class formula
    {
        public void ReadFile(out List<data> Data)
        {
            Data = new List<data>();
            data d;

            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog()==DialogResult.OK)
            {
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);
                string str = reader.ReadLine();
                while(str!=null)
                {
                    var arr = str.Split(' ');
                    d = new data();
                    d.Y = Convert.ToDouble(arr[0]);
                    d.M = Convert.ToDouble(arr[1]);
                    d.D = Convert.ToDouble(arr[2]);
                    d.H = Convert.ToDouble(arr[3]);
                    d.N = Convert.ToDouble(arr[4]);
                    d.S = Convert.ToDouble(arr[5]);

                    str = reader.ReadLine();

                    Data.Add(d);

                }
            }
        }

        public void CalJD(data d,out double JD)
        {
            JD = 1721013.5 + 367 * d.Y - Math.Floor(7.0 / 4.0 * (d.Y + Math.Floor((d.M + 9.0) / 12.0))) - Math.Floor(275 * d.M / 9.0) + d.D + d.H / 24.0 + d.N / 1440.0 + d.S / 86400.0;
        }

        public void CalGL(double JD,out data r)
        {
            int a, b, c, d, e;
            a = Convert.ToInt16(JD + 0.5);
            b = a + 1537;
            c = Convert.ToInt16((b - 122.1) / 365.25);
            d = Convert.ToInt16(365.25 * c);
            e = Convert.ToInt16((b - d) / 30.600);

            r = new data();
            
        }
    }
}
