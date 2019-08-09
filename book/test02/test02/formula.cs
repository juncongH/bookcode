using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace test02
{
    class formula
    {
        public void Readfile(List<double> M)
        {
            OpenFileDialog file = new OpenFileDialog();
            if(file.ShowDialog()==DialogResult.OK)
            {
                double m;
                string path = file.FileName.ToString();
                var reader = new StreamReader(path);
                string str = reader.ReadLine();
                if(str!=null)
                {
                    var arr = str.Split('\t');
                    for(int i=0;i<arr.Count()-1;i++)
                    {
                        for(int j=0;j<arr.Count()-1;j++)
                        {
                            m=new double();
                            m = Convert.ToDouble(arr[j]);
                            M.Add(m);
                        }
                    }
                    str = reader.ReadLine();
                }
            }
        }
    }
}
