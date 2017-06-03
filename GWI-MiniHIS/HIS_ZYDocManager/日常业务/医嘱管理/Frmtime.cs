using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_ZYDocManager.日常业务
{
    public partial class Frmtime : GWI.HIS.Windows.Controls.BaseForm
    {
        public Frmtime()
        {
            InitializeComponent();
        }
        public DateTime dtime =Convert.ToDateTime( Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " "+ Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());// Convert.ToDateTime("0001-1-1 0:00:00");
        public DateTime OTime;
        public DateTime mindate;
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Focus();
            dtime =Convert.ToDateTime( this.dateTimePicker1.Text);
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dtime =Convert.ToDateTime( Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());// Convert.ToDateTime("0001-1-1 0:00:00");
            this.Close();
        }

        private void dateTimePicker1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                dtime = Convert.ToDateTime(this.dateTimePicker1.Text);
                this.Close();
            }
        }

        private void Frmtime_Load(object sender, EventArgs e)
        {
            this.dateTimePicker1.Value = OTime;
            this.dateTimePicker1.MinDate = mindate;
        }
    }
}
