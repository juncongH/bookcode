using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test09
{
    public partial class Form1 : Form
    {
        formula f = new formula();
        List<Point> point;

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
            double z = 0;
            f.Cal(point, 4330, 3600,out z);
        }
    }
}
