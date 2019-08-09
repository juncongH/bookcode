using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace test04
{
    class data
    {
        public string original;
        public string destination;
        public int P;
    }

    class result
    {
        public string name;
        public int s;
    }


    
    class formula
    {
        public void ReadFile(out List<data> Data)
        {
            data d;
            Data = new List<data>();
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog()==DialogResult.OK)
            {
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);
                string str = reader.ReadLine();
  
                while(str!=null)
                {
                    var arr = str.Split(',');
                    d = new data();
                    d.original = arr[0].ToString();
                    d.destination = arr[1].ToString();
                    d.P = Convert.ToInt16(arr[2]);
                    str = reader.ReadLine();
                    Data.Add(d);
                }

            }
        }

        public void Cal(List<data> Data, List<result> U,out List<result> S)
        {
            data d;
            result u;
            S = new List<result>();
            result ori = new result();
            ori.name = "武大";
            ori.s = 0;
            S.Add(ori);

            while(U!=null)
            {
                result s = S[S.Count - 1];
                for(int i=0;i<Data.Count;i++)
                {
                    d = Data[i];
                    if(d.original==s.name)
                    {
                        for(int j=0;j<U.Count;j++)
                        {
                            u = U[j];
                            if(u.name==d.destination)
                            {
                                d.P = d.P + s.s;
                                if (d.P < u.s)
                                    u.s = d.P;
                            }
                        }
                    }
                }
                for(int i=0;i<U.Count-2;i++)
                {
                    int k = U[i].s;
                    for(int j=i+1;j<U.Count-2-i;j++)
                    {
                        int m = U[j].s;
                        if(m<k)
                        {
                            result tem;
                            tem = U[i];
                            U[i] = U[j];
                            U[j] = tem;
                        }
                    }
                }
                result t = U[0];
                S.Add(t);
                if (U.Count > 1)
                    U.Remove(t);
                else
                    break;
            }
        }
    }
}
