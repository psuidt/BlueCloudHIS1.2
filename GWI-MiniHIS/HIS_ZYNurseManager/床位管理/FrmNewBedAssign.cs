using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.ZYNurse_BLL;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;
using HIS.Model;

namespace HIS_ZYNurseManager
{
    public partial class FrmNewBedAssign : GWI.HIS.Windows.Controls.BaseForm
    {
        
        private DataTable dt;
        private int patID;
        private string bedNO;
        private string patSEX;
        private string patName;
        private int mainDoc;
        private int deptid;
        OP_Bed op_bed = new OP_Bed();
        ZY_NURSE_BED bedinfo = new ZY_NURSE_BED();
        public FrmNewBedAssign(int currentDept,string bedNo)
        {
            deptid = currentDept;
            InitializeComponent();
            LoadDocName();
            bedNO = bedNo;            
            queryTextBox1.SetSelectionCardDataSource(dt);
           
            dataGridViewEx1.DataSource = op_bed.getPatNotAssignBed(currentDept);
            dataGridViewEx1.AutoGenerateColumns = false;
            if (dataGridViewEx1.Rows.Count > 0)
            {
                patID = Convert.ToInt32(dataGridViewEx1["peopleid", 0].Value.ToString());
                patSEX = dataGridViewEx1["sex", 0].Value.ToString();
                patName = dataGridViewEx1["name", 0].Value.ToString();
            }
            else
            {
                return;
            }            
        }
        /// <summary>
        /// 加载医生数据
        /// </summary>
        private void LoadDocName()
        {
           // dt = BaseData.GetUserData(BaseData.EmpType.医生);
            dt = op_bed.GetIndeptDoc(deptid); //update by heyan 2010.12.3 分床选医生时只显示本科室的医生
            dt.TableName = "UserDoc";
        }
        ///// <summary>
        ///// 主管医生输入
        ///// </summary>
        ///// <param name="sender"></param>
        ///// <param name="SelectedValue"></param>
        //private void queryTextBox1_AfterSelectedRow(object sender, object SelectedValue)
        //{
        //    if (SelectedValue != null)
        //    {
        //        DataRow dRow = (DataRow)SelectedValue;
        //        this.queryTextBox1.Text = dRow["NAME"].ToString();                
        //        mainDoc= Convert.ToInt32(dRow["code"].ToString());           
        //    }    
        //}

        private void dataGridViewEx1_CellClick(object sender, DataGridViewCellEventArgs e)
        {            
            if (dataGridViewEx1.Rows.Count > 0)
            {
                int rownum = dataGridViewEx1.CurrentCell.RowIndex;
                patID = Convert.ToInt32(dataGridViewEx1["peopleid", rownum].Value.ToString());
                patSEX = dataGridViewEx1["sex", rownum].Value.ToString();
                patName = dataGridViewEx1["name", rownum].Value.ToString();
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 分配床位确认
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmAssign_Click(object sender, EventArgs e)
        {
            try
            {
                
                if (patName==null||queryTextBox1.Text=="")
                {
                    MessageBox.Show("您还未录入主管医生或未选择病人信息，请录入完整后再进行操作", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.queryTextBox1.Focus();
                    return;
                }
                else
                {
                    if (op_bed.IsOut(patID))
                    {
                        MessageBox.Show("该病人已结算，不能分配床位，请刷新病人");
                        return;
                    }
                    bedinfo.BED_NO = bedNO;
                    bedinfo.PATLIST_ID = patID;
                    bedinfo.BED_SEX = patSEX;
                    bedinfo.DEPT_ID = deptid;
                    bedinfo.ZY_DOC = int.Parse(queryTextBox1.MemberValue.ToString());
                }
                DialogResult dr = MessageBox.Show("您确定将【" + bedNO + "】号床分配给病人【" + patName + "】吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    bool existresult = op_bed.getexitresult(patID);
                    if (existresult == false)
                    {
                        bool assignResult = op_bed.bedAssign(bedinfo, deptid);
                        if (assignResult == true)
                        {
                            MessageBox.Show("分配床位成功", "提示");
                            this.queryTextBox1.Clear();
                            dataGridViewEx1.AutoGenerateColumns = false;
                            dataGridViewEx1.DataSource = op_bed.getPatNotAssignBed(Convert.ToInt32(deptid));
                            mainDoc = 0;
                            patName = null;
                            this.Close();                            
                        }
                        else
                        {
                            MessageBox.Show("床位分配失败,该床位已有病人存在！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("该病人已分配床位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    return;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void ExitAssign_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dataGridViewEx1.AutoGenerateColumns = false;
                dataGridViewEx1.DataSource = op_bed.getPatNotAssignBedRecall(deptid);
            }
            else
            {
                dataGridViewEx1.AutoGenerateColumns = false;
                dataGridViewEx1.DataSource = op_bed.getPatNotAssignBed(deptid);
            }
        }
    }
}
