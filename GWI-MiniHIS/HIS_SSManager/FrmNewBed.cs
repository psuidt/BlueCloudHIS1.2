using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_SSManager
{
    public partial class FrmNewBed : GWI.HIS.Windows.Controls.BaseForm
    {
        public string  tcNo;
        HIS.Model.SS_ROOM room;
        public FrmNewBed(HIS.Model.SS_ROOM _room)
        {
            InitializeComponent();
            room = _room;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNo.Text == "")
            {
                MessageBox.Show("请输入台次序号");
                return;
            }
            tcNo = txtNo.Text;
            HIS.SS_BLL.SsRoomBed roomop = new HIS.SS_BLL.SsRoomBed();
            if (roomop.IsExistBed(tcNo,room))  //* 20100518.0.02 输入台次时能输入相同的台次号
            {
                MessageBox.Show("该台次号已存在，请重新输入");
                return;
            }
            this.Close();           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tcNo = "";
            this.Close();
        }

        private void txtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(null, null);
            }
        }
    }
}
