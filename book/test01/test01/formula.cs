using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace test01
{
    class formula
    {
        public void transtime(string time,out double Y,out double M,out double D,out double H,out double N,out double S)
        {
            Y = Convert.ToDouble(time.Substring(0, 4));
            M = Convert.ToDouble(time.Substring(4, 2));
            D = Convert.ToDouble(time.Substring(6, 2));
            H = Convert.ToDouble(time.Substring(8, 2));
            N = Convert.ToDouble(time.Substring(10, 2));
            S = Convert.ToDouble(time.Substring(12, 2));
        }

        public void CalMJD(double D,double Y,double M,double H,double N,double S,out double MJD)
        {
            MJD = -678987.0 + 367.0 * Y - Math.Floor(7.0 / 4.0 * (Y + Math.Floor((M + 9.0) / 12.0))) - Math.Floor((275.0 * M) / 9.0) + D + H / 24.0 + N / 1440.0 + S / 86400.0;
        }

        public void CalSpeedAngle(data t1,data t2,out double speed,out double angle)
        {
            double t, l;
            double Y1, M1, D1, H1, N1, S1;
            double Y2, M2, D2, H2, N2, S2;
            transtime(t1.time, out Y1, out M1, out D1, out H1, out N1, out S1);
            transtime(t2.time, out Y2, out M2, out D2, out H2, out N2, out S2);
            t = (H2 - H1) * 3600.0 + (N2 - N1) * 60.0 + S2 - S1;
            l = Math.Sqrt((t1.x - t2.x) * (t1.x - t2.x) + (t1.y - t2.y) * (t1.y - t2.y));
            speed = l / t * 3.6;

            angle = Math.Atan2(t2.y - t1.y, t2.x - t1.x) * 180.0 / Math.PI;
        }

        public void ReadFile(out List<data> TaxiData)
        {
            data d;
            TaxiData = new List<data>();

            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog()==DialogResult.OK)
            {
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);
                string str = reader.ReadLine();
                str = reader.ReadLine();
                var arr = str.Split(',');
                while(str!=null)
                {
                    arr = str.Split(',');
                    d = new data();
                    d.name = arr[0];
                    d.status = arr[1];
                    d.time = arr[2];
                    d.x = Convert.ToDouble(arr[3]);
                    d.y = Convert.ToDouble(arr[4]);
                    TaxiData.Add(d);
                    str = reader.ReadLine();
                }
            }
        }

        public void Report(List<result> R,out string re_text)
        {
            re_text = "------------速度和方位角计算结果-------------";
            re_text += "\n";
            for(int i=0;i<R.Count;i++)
            {
                re_text += R[i].name+",";
                re_text += R[i].MJD1.ToString()+"-";
                re_text += R[i].MJD2.ToString()+",";
                re_text += R[i].speed.ToString() + ",";
                re_text += R[i].angle.ToString() + "\n";
            }
        }

    }
}
