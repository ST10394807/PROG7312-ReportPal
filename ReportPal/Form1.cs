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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnIssues_Click(object sender, EventArgs e)
        {
            using (var issues = new ReportIssuesForm())
            {
                issues.StartPosition = FormStartPosition.CenterParent;
                issues.ShowDialog(this);   // modal: user closes it to return to Main Menu
            }
        }

        private void btnEvents_Click(object sender, EventArgs e)
        {

        }

        private void btnServiceRequest_Click(object sender, EventArgs e)
        {

        }
    }
}
