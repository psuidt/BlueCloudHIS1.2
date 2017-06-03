using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;

namespace HIS_ZYNurseManager
{
    public partial class FrmNotAssignBed : GWI.HIS.Windows.Controls.BaseForm
    {
        OP_Bed op_bed = new OP_Bed();
        private int bedid;
        private string patname;
        private string sourcebedno;
        private int deptid;
        private int patlistid;
        public FrmNotAssignBed(int deptid,int bedid,string patname,int patlistid,string sourcebedno)
        {
            InitializeComponent();
            this.deptid = deptid;
            this.bedid = bedid;
            this.patname = patname;
            this.patlistid = patlistid;
            this.sourcebedno = sourcebedno;            
            cmbnobed.DisplayMember = "bed_no";
            cmbnobed.ValueMember = "bed_no";
            cmbnobed.DataSource = op_bed.getBedNotAssign(deptid);
        }

        private void btntransbed_Click(object sender, EventArgs e)
        {
            string bedno = cmbnobed.SelectedValue.ToString();
            string str = "您确定将病人" + patname + "从【" + sourcebedno + "】号床转到【" + bedno + "】号床吗？";
            DialogResult dr = MessageBox.Show(str, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                bool transresult = op_bed.setTransbed(bedid, bedno, deptid, patlistid);
                if (transresult == true)
                {
                    MessageBox.Show("科内转床成功！", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("科内转床失败，该床位可能已被占用，请退出重试！", "提示", MessageBoxButtons.OK);
                }                
                cmbnobed.DataSource = op_bed.getBedNotAssign(Convert.ToInt32(deptid));
                this.Close();                
            }
            else
            {
                return;
            }
        }        
    }
}
