using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReportPal
{
    public partial class UiDemo : Form
    {
        public UiDemo()
        {
            InitializeComponent();
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressBar1.Value < 100)
                progressBar1.Value += 2;
            else
                progressBar1.Value = 0;
        }


        private void UiDemo_Load_1(object sender, EventArgs e)
        {
            timer1.Interval = 100;
            timer1.Start();

        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            MessageBox.Show("UI Demo button clicked!");
        }
    }
}
