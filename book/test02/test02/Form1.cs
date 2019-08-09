using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test02
{
    public partial class Form1 : Form
    {
        formula f = new formula();
        List<double> M = new List<double>();
        public Form1()
        {
            InitializeComponent();
            f.Readfile(M);
        }
        
    }
}
