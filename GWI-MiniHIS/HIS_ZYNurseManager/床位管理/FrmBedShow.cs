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
    public partial class FrmBedShow : GWI.HIS.Windows.Controls.BaseMainForm
    {
        Type type = null;
        private int patlistid;
        private string bedNO;        
        List<HIS.Model.ZY_PatList> patInfo;
        List<HIS.Model.ZY_NURSE_BED> bedInfo;
        OP_Bed op_bed = new OP_Bed();
        Op_BaseData op_BaseData = new Op_BaseData();
        HIS.Model.ZY_PatList zy_patlist;
        HIS.ZY_BLL.ObjectModel.CostManager.IcostManager IcM = null;  
        
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
        public FrmBedShow(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            CreateBedView();
            listView1.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);
            IcM = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.CostManager.IcostManager>(typeof(HIS.ZY_BLL.DataModel.ZY_CostMaster));

            btnTransDept.Visible = true;
            btnOut.Visible = true;

        }
        /// <summary>
        /// 加载病人信息
        /// </summary>
        private void CreateBedView()
        {

            patInfo = op_BaseData.getPatInfo(Convert.ToInt32(currentDept.DeptID));
            bedInfo = op_BaseData.getBedInfo(Convert.ToInt32(currentDept.DeptID));
            foreach (ZY_NURSE_BED bed in bedInfo) 
            {
                ListViewItem item = new ListViewItem();
                //判断当前床位是否有病人
                if (bed.PATLIST_ID == 0)
                {
                    //没有病人，直接绑定床位对象
                    item.Text = bed.BED_NO;
                    item.ImageIndex = 0;
                    item.Tag = bed;
                }
                else
                {
                    ZY_PatList patient = patInfo.Find(delegate(ZY_PatList p)
                    {
                        if (p != null)
                            return p.PatListID == bed.PATLIST_ID;
                        else
                            return false;
                    });
                    if (patient != null)
                    {
                        if (patient.PatientInfo.PatSex == "男")
                        {
                            item.Text = bed.BED_NO +" " +patient.PatientInfo.ACCOUNTTYPE + "\r\n" + patient.PatientInfo.PatName;
                            item.ImageIndex = 5;
                            item.Tag = patient;
                        }
                        else
                        {
                            item.Text = bed.BED_NO +" "+patient.PatientInfo.ACCOUNTTYPE + "\r\n" + patient.PatientInfo.PatName;
                            item.ImageIndex = 10;
                            item.Tag = patient;
                        }     
                    }
                    else
                    {
                        MessageBox.Show(bed.BED_NO + "数据异常");
                    }
                }
                listView1.Items.Add(item);
            }           
        }
        /// <summary>
        /// 切换病人事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0) return;
            object obj = listView1.SelectedItems[0].Tag;
            type = obj.GetType();
            if (type == typeof(ZY_PatList))
            {
                patlistid = ((ZY_PatList)obj).PatListID;
                inPatientPanel1.InPatientExtDB = new ApplyIInPatient(patlistid);
            }
            else if (type == typeof(ZY_NURSE_BED))
            {
                bedNO = ((ZY_NURSE_BED)obj).BED_NO;
                inPatientPanel1.Clear();
            }
            else
            {
                MessageBox.Show("Unkonw type");
            }          
        }  
        /// <summary>
        /// 新分配床位
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNewBedAssign_Click(object sender, EventArgs e)
        {           
            if (type == null)
            {
                MessageBox.Show("请您选择一张空床后再进行相应的操作！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (type == typeof(ZY_NURSE_BED))
            {
                FrmNewBedAssign frmNewBedAssign = new FrmNewBedAssign(Convert.ToInt32(_currentDept.DeptID),bedNO);
                frmNewBedAssign.MdiParent = this.MdiParent;
                frmNewBedAssign.WindowState = FormWindowState.Normal;
                frmNewBedAssign.ShowDialog();
                listView1.Clear();
                CreateBedView();
                type =null;
            }
            else
            {
                MessageBox.Show("该床位已有病人，请选择空床进行操作");
            }
        }              
        /// <summary>
        /// 取消分床
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancelBedAssgin_Click(object sender, EventArgs e)
        {
            if (type == null)
            {
                MessageBox.Show("请您选择一个在床病人后再进行相应的操作！", "提示", MessageBoxButtons.OK);
                return;
            }
            if (type == typeof(ZY_PatList))
            {         
                HIS.ZY_BLL.ObjectModel.CostManager.IcostManager IcM = HIS.ZY_BLL.ObjectModel.ObjectFactory.GetObject<HIS.ZY_BLL.ObjectModel.CostManager.IcostManager>(typeof(HIS.ZY_BLL.DataModel.ZY_CostMaster));
                IcM.PatListID = Convert.ToInt32(patlistid);
                decimal costfee = IcM.GetPatFee().costFee;
                if (costfee == Convert.ToDecimal(0))
                {
                    bool cancelResult = op_bed.cancelAssign(patlistid);
                    if (cancelResult == true)
                    {
                        MessageBox.Show("取消分配成功", "提示", MessageBoxButtons.OK);
                        //op_bed.updateBedFlag(Convert.ToInt32(patlistid));                       
                        listView1.Clear();
                        CreateBedView();
                        type = null;
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
                MessageBox.Show("您选择的是空床，请选择一个有病人的床进行操作！", "提示", MessageBoxButtons.OK);
                return;
            }  
         }
        /// <summary>
        /// 修改主管医生
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnModifyDoc_Click(object sender, EventArgs e)
        {
            if (type == null)
            {
                MessageBox.Show("请您选择一个在床病人后再进行相应的操作！", "提示", MessageBoxButtons.OK);
                return;
            }
            object obj = listView1.SelectedItems[0].Tag;
            type = obj.GetType();
            if (type == typeof(ZY_PatList))
            {
                string bedno = (((ZY_PatList)obj).BedCode).ToString();
                int bedid = op_BaseData.getBedId(Convert.ToInt32(currentDept.DeptID), bedno);
                FrmModifyDoc frmModifyDoc = new FrmModifyDoc(bedid, patlistid, Convert.ToInt32(_currentDept.DeptID));
                frmModifyDoc.MdiParent = this.MdiParent;
                frmModifyDoc.WindowState = FormWindowState.Normal;
                frmModifyDoc.ShowDialog();
                listView1.Clear();
                CreateBedView();
                type = null;
            }
            else
            {
                MessageBox.Show("您选中的是空床，请选择有病人的床位进行操作！", "提示", MessageBoxButtons.OK);
                return; 
            }
        }      
        /// <summary>
        /// 科内转床
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransferBed_Click(object sender, EventArgs e)
        {
            if (type == null)
            {
                MessageBox.Show("请您选择一个在床病人后再进行相应的操作！", "提示", MessageBoxButtons.OK);
                return;
            }
            object obj = listView1.SelectedItems[0].Tag;
            type = obj.GetType();
            if (type == typeof(ZY_PatList))
            {
                string patname = ((ZY_PatList)obj).PatientInfo.PatName;
                string sourcebedno = (((ZY_PatList)obj).BedCode).ToString();
                int patlistid = ((ZY_PatList)obj).PatListID;
                int bedid = op_BaseData.getBedId(Convert.ToInt32(currentDept.DeptID), sourcebedno);
                FrmNotAssignBed frmNotAssignBed = new FrmNotAssignBed(Convert.ToInt32(currentDept.DeptID), bedid, patname, patlistid, sourcebedno);
                frmNotAssignBed.MdiParent = this.MdiParent;
                frmNotAssignBed.WindowState = FormWindowState.Normal;
                frmNotAssignBed.ShowDialog();
                listView1.Clear();
                CreateBedView();
                type = null;
            }
            else
            {
                MessageBox.Show("您选中的是空床，请选择有病人的床位进行操作！", "提示", MessageBoxButtons.OK);
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
            listView1.Clear();
            CreateBedView();
            type = null;
        }
        /// <summary>
        /// 窗口关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCloseForm_Click(object sender, EventArgs e)
        {
            this.Close();
        }       
        /// <summary>
        /// 快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmBedShow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode== Keys.F2)
            {
                btnNewBedAssign.PerformClick();
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnCancelBedAssgin.PerformClick();
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnModifyDoc.PerformClick();
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnTransferBed.PerformClick(); 
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnRefresh.PerformClick();
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnCloseForm.PerformClick();
            }
            else if (e.KeyCode == Keys.F8)
            {
                btnTransDept.PerformClick();
            }
        }

        #region 右键事件
        private void 医嘱转抄ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrderTrans frmordertrans = new FrmOrderTrans(_currentUser.UserID, _currentDept.DeptID, "医嘱转抄");
            frmordertrans.MdiParent = this.MdiParent;
            frmordertrans.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmordertrans);
            frmordertrans.Show();
        }

        private void 账单录入ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFeeInput frmfeeinput = new FrmFeeInput(_currentUser.UserID, _currentDept.DeptID, "账单录入");
            frmfeeinput.MdiParent = this.MdiParent;
            frmfeeinput.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmfeeinput);
            frmfeeinput.Show();
        }

        private void 医嘱管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrderManager frmordermanager = new FrmOrderManager(_currentUser.UserID, _currentDept.DeptID, "医嘱管理");
            frmordermanager.MdiParent = this.MdiParent;
            frmordermanager.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmordermanager);
            frmordermanager.Show();
        }

        private void 医嘱执行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmOrderExec frmorderexec = new FrmOrderExec(_currentUser.UserID, _currentDept.DeptID, "医嘱执行");
            frmorderexec.MdiParent = this.MdiParent;
            frmorderexec.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmorderexec);
            frmorderexec.Show();
        }

        private void 病人出区ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPatOut frmpatout = new FrmPatOut(_currentUser.UserID, _currentDept.DeptID, "病人出区");
            frmpatout.MdiParent = this.MdiParent;
            frmpatout.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmpatout);
            frmpatout.Show();
        }

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            FrmOrderManager frmordermanager = new FrmOrderManager(_currentUser.UserID, _currentDept.DeptID, "医嘱管理");
            frmordermanager.MdiParent = this.MdiParent;
            frmordermanager.WindowState = FormWindowState.Maximized;
            ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmordermanager);
            frmordermanager.Show();
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnRefresh.PerformClick();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion


        /// <summary>
        ///  病人转科(只上经管需要)add by heyan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTransDept_Click(object sender, EventArgs e)
        {
            if (type == null)
            {
                MessageBox.Show("请您选择一个在床病人后再进行相应的操作！", "提示", MessageBoxButtons.OK);
                return;
            }
            object obj = listView1.SelectedItems[0].Tag;
            type = obj.GetType();
            if (type == typeof(ZY_PatList))
            {
                HIS.Model.ZY_PatList plist = (ZY_PatList)listView1.SelectedItems[0].Tag;
                FrmTransDept transdept = new FrmTransDept(plist, _currentDept.DeptID);
                transdept.ShowDialog();
                if (transdept.IsTrans)
                {
                    MessageBox.Show("转科成功");
                    listView1.Clear();
                    CreateBedView();
                    type = null;
                }               
            }
            else
            {
                MessageBox.Show("您选中的是空床，请选择有病人的床位进行操作！", "提示", MessageBoxButtons.OK);
                return;
            }
            
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (type == null)
            {
                MessageBox.Show("请您选择一个在床病人后再进行相应的操作！", "提示", MessageBoxButtons.OK);
                return;
            }
            object obj = listView1.SelectedItems[0].Tag;
            type = obj.GetType();
            if (type == typeof(ZY_PatList))
            {
                HIS.Model.ZY_PatList plist = (ZY_PatList)listView1.SelectedItems[0].Tag;
               string  strconfirm = "确认“" + plist.PatientInfo.PatName + "”定义出院吗？";
               if (MessageBox.Show(this, strconfirm, "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                   return;   
                HIS.ZYNurse_BLL.OP_Bed opbed = new HIS.ZYNurse_BLL.OP_Bed();
                if (opbed.OpPatout(plist))
                {
                    MessageBox.Show("病人出区成功，请及时到住院部结算");
                    listView1.Clear();
                    CreateBedView();
                    type = null;
                }
                else
                {
                    MessageBox.Show("病人出区失败");
                }
               
            }
            else
            {
                MessageBox.Show("您选中的是空床，请选择有病人的床位进行操作！", "提示", MessageBoxButtons.OK);
                return;
            }
        }
             
    } 
}
