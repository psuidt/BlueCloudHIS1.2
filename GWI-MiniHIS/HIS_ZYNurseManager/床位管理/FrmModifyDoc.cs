using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;
using HIS.Model;

namespace HIS_ZYNurseManager
{
    public partial class FrmModifyDoc : GWI.HIS.Windows.Controls.BaseForm
    {
        private DataTable dt;
        private int economydoc;
        private int bedid;
        private int patlistid;
        private int _deptid;
        OP_Bed op_bed = new OP_Bed();
        public FrmModifyDoc(int bedid,int patlistid,int deptid)
        {
            InitializeComponent();
            this.bedid = bedid;
            this.patlistid = patlistid;
            _deptid = deptid;
            loadDocName();
            queryTextBox2.SetSelectionCardDataSource(dt);
        }
        /// <summary>
        /// 加载医生数据
        /// </summary>
        private void loadDocName()
        {
          //  dt = BaseData.GetUserData(BaseData.EmpType.医生);
            dt = op_bed.GetIndeptDoc(_deptid);
            dt.TableName = "UserDoc";
        }     
        private void btnalter_Click(object sender, EventArgs e)
        {
            if (queryTextBox2.Text == "")
            {
                MessageBox.Show("您还未录入主管医生，请录入完整后再进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.queryTextBox2.Focus();
                return;
            }
            else
            {
                economydoc = int.Parse(queryTextBox2.MemberValue.ToString());
            }
            bool jzresult = op_bed.updatejzdoc(bedid, economydoc, patlistid);
            if (jzresult == true)
            {
                MessageBox.Show("主管医生修改成功！", "提示", MessageBoxButtons.OK);
                queryTextBox2.Text = "";
                this.Close();
            }
            else
            {
                MessageBox.Show("主管医生修改失败！", "提示", MessageBoxButtons.OK);
                queryTextBox2.Text = "";
            }           
        }

        //private void queryTextBox2_AfterSelectedRow(object sender, object SelectedValue)
        //{
        //    DataRow dRow = (DataRow)SelectedValue;
        //    this.queryTextBox2.Text = dRow["NAME"].ToString();
        //    economydoc = Convert.ToInt32(dRow["code"].ToString()); 
        //}

          
    }       
}
