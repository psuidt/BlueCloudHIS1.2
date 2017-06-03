using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;
using HIS.Model;

namespace HIS_ZYNurseManager
{
    public partial class FrmBedAssign : GWI.HIS.Windows.Controls.BaseMainForm
    {

        private int economydoc;
        private int       maindoc;
        private int       patID;
        private string    bedNO;
        private string    patSEX;
        private DataTable dt;        
        OP_Bed op_bed = new OP_Bed();
        DataTable beddt = new DataTable();
        ZY_NURSE_BED bedinfo = new ZY_NURSE_BED();
        ZY_NURSE_BED cancelbedinfo = new ZY_NURSE_BED();

        private User _currentUser; 
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }
        private Deptment _currentDept;
        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }               
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <param name="currentDeptId"></param>
        /// <param name="chineseName"></param>
        public FrmBedAssign(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            loadDocName();
            queryTextBox1.SetSelectionCardDataSource(dt);
            queryTextBox2.SetSelectionCardDataSource(dt);
            dataGridViewEx1.AutoGenerateColumns = false;
            dataGridViewEx1.DataSource = op_bed.getPatNotAssignBed(Convert.ToInt32(currentDept.DeptID));
            dataGridViewEx2.DataSource = op_bed.getBedNotAssign(Convert.ToInt32(currentDept.DeptID));
            loadpatbed();
            cmbnobed.DisplayMember = "bed_no";
            cmbnobed.ValueMember = "bed_no";
            cmbnobed.DataSource =op_bed.getBedNotAssign(Convert.ToInt32(currentDept.DeptID));
        }
        /// <summary>
        /// 默认床位和病人信息
        /// </summary>
        private void loadpatbed()
        {
            if (dataGridViewEx1.Rows.Count > 0 )
            {
                label9.Text = dataGridViewEx1[Column3.Name, 0].Value.ToString();
                patID=Convert.ToInt32(dataGridViewEx1[Column12.Name, 0].Value.ToString());
                patSEX = dataGridViewEx1[Column5.Name, 0].Value.ToString();
            }
            else
            {
                label9.Text = "";                
            }
            if (dataGridViewEx2.Rows.Count > 0)
            {
                label8.Text = dataGridViewEx2[Column7.Name, 0].Value.ToString();
                bedNO = dataGridViewEx2[Column7.Name, 0].Value.ToString();
            }
            else
            {
                label8.Text = "";
            }
        }
        /// <summary>
        /// 加载医生数据
        /// </summary>
        private void loadDocName()
        {
            dt = BaseData.GetUserData(BaseData.EmpType.医生);
            dt.TableName = "UserDoc";
        }
        /// <summary>
        /// 病人选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewEx1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)dataGridViewEx1.DataSource;
            label9.Text = dt.Rows[dataGridViewEx1.CurrentRow.Index][3].ToString();
            patID = Convert.ToInt32(dt.Rows[dataGridViewEx1.CurrentRow.Index][2]);
            patSEX = dt.Rows[dataGridViewEx1.CurrentRow.Index][4].ToString();
        }
        /// <summary>
        /// 床位选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewEx2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataTable dt = (DataTable)dataGridViewEx2.DataSource;
            label8.Text = dt.Rows[dataGridViewEx2.CurrentRow.Index][1].ToString();
            bedNO = dt.Rows[dataGridViewEx2.CurrentRow.Index][1].ToString();
        }   
        /// <summary>
        /// 病人床位确认分配
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmAssign_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridViewEx1.Rows.Count > 0 && dataGridViewEx2.Rows.Count > 0)
                {
                    bedinfo.BED_NO = bedNO;
                    bedinfo.PATLIST_ID = patID;
                    bedinfo.BED_SEX = patSEX;
                    bedinfo.DEPT_ID = Convert.ToInt32(currentDept.DeptID);
                }
                else
                {
                    MessageBox.Show("病人或床位为空，床位分配操作即将退出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }                
                if (bedinfo.ZY_DOC == 0)
                {
                    MessageBox.Show("您还未选择主管医生", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.queryTextBox1.Focus();
                    return;
                }
                bool existresult = op_bed.getexitresult(patID);                
                if (existresult == false)
                {
                    bool assignResult = op_bed.bedAssign(bedinfo,_currentDept.DeptID);
                    if (assignResult == true)
                    {
                        MessageBox.Show("分配床位成功", "提示", MessageBoxButtons.OK);
                        this.queryTextBox1.Clear();
                        dataGridViewEx1.DataSource = op_bed.getPatNotAssignBed(Convert.ToInt32(currentDept.DeptID));
                        dataGridViewEx2.DataSource = op_bed.getBedNotAssign(Convert.ToInt32(currentDept.DeptID));
                        cmbnobed.DataSource = op_bed.getBedNotAssign(Convert.ToInt32(currentDept.DeptID));//3月22日新加的，分配床位后及时分配更改未分床的状态
                        bedinfo.ZZ_DOC = 0;
                        bedinfo.ZY_DOC = 0;
                        loadpatbed();
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {

            }
        }
        /// <summary>
        /// 退出床位分配操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitAssign_Click(object sender, EventArgs e)
        {
            this.Close();
        }      
        /// <summary>
        /// ShowCard选择后对应操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="SelectedValue"></param>
        private void queryTextBox1_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (SelectedValue != null)
            {
                DataRow dRow = (DataRow)SelectedValue;
                this.queryTextBox1.Text = dRow["NAME"].ToString();
                if (zz_radioButton.Checked == true)
                {
                   bedinfo.ZZ_DOC =Convert.ToInt32(dRow["code"].ToString());
                }
                else if (zy_radioButton.Checked==true)
                {     
                    bedinfo.ZY_DOC=Convert.ToInt32(dRow["code"].ToString());
                }
                else
                {
                    MessageBox.Show("您未选择医生类型，请选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
             }                   
        }             
        /// <summary>
        ///医生类型选择触发操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zz_radioButton_Click(object sender, EventArgs e)
        {
            this.queryTextBox1.Clear();
            this.queryTextBox1.Focus();
        }
        /// <summary>
        /// 医生类型选择触发操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void zy_radioButton_Click(object sender, EventArgs e)
        {
            this.queryTextBox1.Clear();
            this.queryTextBox1.Focus();
        }             
        /// <summary>
        /// 选项卡对应操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPageControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPageControl1.SelectedTab.Text == "转床/取消分床")
            {
                dataGridViewEx3.DataSource = op_bed.getBedAssignInfo(Convert.ToInt32(currentDept.DeptID));
                cmbnobed.DisplayMember = "bed_no";
                cmbnobed.ValueMember = "bed_no";
                cmbnobed.DataSource = op_bed.getBedNotAssign(Convert.ToInt32(currentDept.DeptID));
            }
            else
            {
                dataGridViewEx1.DataSource = op_bed.getPatNotAssignBed(Convert.ToInt32(currentDept.DeptID));
                dataGridViewEx2.DataSource = op_bed.getBedNotAssign(Convert.ToInt32(currentDept.DeptID));
            }
        }
        /// <summary>
        /// 病人床位分配取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelAssign_Click(object sender, EventArgs e)
        {
           if (dataGridViewEx3.Rows.Count > 0)
           {
                int rownum = dataGridViewEx3.CurrentCell.RowIndex;
                long bedid = Convert.ToInt64(dataGridViewEx3[Column16.Name, rownum].Value.ToString());
                long patlistid = Convert.ToInt64(dataGridViewEx3[Column21.Name, rownum].Value.ToString());
                HIS.ZY_BLL.ObjectModel.CostManager.IcostManager IcM = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.CostManager.IcostManager>(typeof(HIS.ZY_BLL.DataModel.ZY_CostMaster));
                IcM.PatListID = Convert.ToInt32(patlistid);
                decimal costfee = IcM.GetPatFee().costFee;         
                if (costfee == Convert.ToDecimal(0))
                { 
                     bool cancelResult =op_bed.cancelAssign(patlistid);
                     if (cancelResult == true)
                     {
                         MessageBox.Show("取消分配成功", "提示", MessageBoxButtons.OK);
                         op_bed.updateBedFlag(Convert.ToInt32(patlistid));
                         cmbnobed.DisplayMember = "bed_no";
                         cmbnobed.ValueMember = "bed_no";
                         cmbnobed.DataSource = op_bed.getBedNotAssign(Convert.ToInt32(currentDept.DeptID));
                         dataGridViewEx3.DataSource = op_bed.getBedAssignInfo(Convert.ToInt32(currentDept.DeptID));
                     }
                     else
                     {
                         MessageBox.Show("取消分配床位失败，该病人已存在医嘱，不允许取消分床", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                     }
                }
                else
                {
                    MessageBox.Show("取消分配床位失败，该病人已产生记账费用，不允许取消分床", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("床位分配表已为空，床位取消操作即将退出！", "提示", MessageBoxButtons.OK);
                return;
            }     
        }
        /// <summary>
        /// 退出分配取消
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// 出院召回病人列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                dataGridViewEx1.DataSource = op_bed.getPatNotAssignBedRecall(Convert.ToInt32(currentDept.DeptID));
            }
            else
            {
                dataGridViewEx1.DataSource = op_bed.getPatNotAssignBed(Convert.ToInt32(currentDept.DeptID));
            }
        }
        /// <summary>
        /// 修改操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnalter_Click(object sender, EventArgs e)
        {
            int rownum = dataGridViewEx3.CurrentCell.RowIndex;
            int bedid =Convert.ToInt32(dataGridViewEx3[Column16.Name,rownum].Value.ToString());
            int patlistid = Convert.ToInt32(dataGridViewEx3[Column21.Name, rownum].Value.ToString());
            if (jzdoc.Checked == true)
            {
                bool jzresult=op_bed.updatejzdoc(bedid, economydoc,patlistid);
                if (jzresult == true)
                {
                    MessageBox.Show("主管医生修改成功！", "提示", MessageBoxButtons.OK);
                    queryTextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("主管医生修改失败！", "提示", MessageBoxButtons.OK);
                    queryTextBox2.Text = "";
                }             
            }
            else
            {
                bool zzresult = op_bed.updatezzdoc(bedid, economydoc);
                if (zzresult == true)
                {
                    MessageBox.Show("主治医生修改成功！", "提示", MessageBoxButtons.OK);
                    queryTextBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("主治医生修改失败！", "提示", MessageBoxButtons.OK);
                    queryTextBox2.Text = "";
                }       
            }
        }
        /// <summary>
        /// 修改主管医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="SelectedValue"></param>
        private void queryTextBox2_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (SelectedValue != null)
            {
                DataRow dRow = (DataRow)SelectedValue;
                this.queryTextBox2.Text = dRow["NAME"].ToString();
                if (jzdoc.Checked == true)
                {
                    economydoc= Convert.ToInt32(dRow["code"].ToString());
                }
                else if (zzdoc.Checked == true)
                {
                    maindoc = Convert.ToInt32(dRow["code"].ToString());
                }
                else
                {
                    MessageBox.Show("您未选择医生类型，请选择", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }         
        }
        /// <summary>
        /// 转床操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btntransbed_Click(object sender, EventArgs e)
        {
            int rownum = dataGridViewEx3.CurrentCell.RowIndex;
            int bedid = Convert.ToInt32(dataGridViewEx3[Column16.Name , rownum].Value.ToString());
            int patlistid = Convert.ToInt32(dataGridViewEx3[Column21.Name, rownum].Value.ToString());
            string patname = dataGridViewEx3[Column14.Name, rownum].Value.ToString();
            string currbedno=dataGridViewEx3[Column13.Name, rownum].Value.ToString();
            string bedno = cmbnobed.SelectedValue.ToString();
            string str = "您确定将病人" + patname + "从【" + currbedno + "】号床转到【" + bedno + "】号床吗？";
            DialogResult dr=MessageBox.Show(str,"确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                bool transresult = op_bed.setTransbed(bedid, bedno, _currentDept.DeptID, patlistid);
                if (transresult == true)
                {
                    MessageBox.Show("科内转床成功！", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("科内转床失败，该床位可能已被占用，请退出重试！", "提示", MessageBoxButtons.OK);
                }
                dataGridViewEx1.DataSource = op_bed.getPatNotAssignBed(Convert.ToInt32(currentDept.DeptID));
                dataGridViewEx2.DataSource = op_bed.getBedNotAssign(Convert.ToInt32(currentDept.DeptID));
                dataGridViewEx3.DataSource = op_bed.getBedAssignInfo(Convert.ToInt32(currentDept.DeptID));
                cmbnobed.DataSource = op_bed.getBedNotAssign(Convert.ToInt32(currentDept.DeptID));
            }
            else
            {
                return;
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            dataGridViewEx1.DataSource = op_bed.getPatNotAssignBed(Convert.ToInt32(currentDept.DeptID));
            dataGridViewEx2.DataSource = op_bed.getBedNotAssign(Convert.ToInt32(currentDept.DeptID));
        }       
     }
}
