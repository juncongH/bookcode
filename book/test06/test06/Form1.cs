using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test06
{
    public partial class Form1 : Form
    {
        formula f = new formula();
        List<Point> point;
        List<Point> res = new List<Point>();


        public Form1()
        {
            InitializeComponent();
        }

        private void 打开ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.ReadFile(out point);
        }

        private void 计算ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            f.DP(point);
            res = f.result;
        }
    }
}
