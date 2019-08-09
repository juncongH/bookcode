using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test07
{
    public partial class Form1 : Form
    {
        List<data> Data;
        formula f = new formula();
        public static double T;

        public Form1()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.ReadFile(out T, out Data);
        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.Cal(Data);
        }
    }
}
