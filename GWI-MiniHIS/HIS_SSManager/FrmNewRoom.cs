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
    public partial class FrmNewRoom : GWI.HIS.Windows.Controls.BaseForm
    {
        public string roomno;      
        public FrmNewRoom()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtRoomNo.Text == "")
            {
                MessageBox.Show("房间号不能为空");
                return;
            }            
            roomno = txtRoomNo.Text;
            HIS.SS_BLL.SsRoom roomop = new HIS.SS_BLL.SsRoom();
            if (roomop.IsExistRoom(roomno))
            {
                MessageBox.Show("该房间号已存在，请重新输入");
                return;
            }           
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            roomno = "";          
            this.Close();
        }

        private void txtRoomNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtRoomNo.Text == "")
                {
                    MessageBox.Show("房间号不能为空");
                    return;
                }
                roomno = txtRoomNo.Text;
                HIS.SS_BLL.SsRoom roomop = new HIS.SS_BLL.SsRoom();
                if (roomop.IsExistRoom(roomno))
                {
                    MessageBox.Show("该房间号已存在，请重新输入");
                    return;
                }
                this.Close();
            }
        } 
    }
}
