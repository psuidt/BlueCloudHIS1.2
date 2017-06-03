using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

using HIS_ZYManager.Action;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.NccmManager;

namespace HIS_ZYManager
{
    //[20100511.2.01]
    public partial class FrmRegister : GWI.HIS.Windows.Controls.BaseMainForm,HIS_ZYManager.Action.IFrmRegisterView
    {
      
        //入院操作类型
        private enum RegType { 默认 = 0, 新证 = 1, 修改 = 2, 其他 = 3, 不可修改 = 4 };
                
        //控制器
        FrmRegisterController Controller;
        //病人信息
        List<ZY_PatList> _zyPatlists ;
        //病人入院信息
        ZY_PatList _zyPatlist;

        private User _currentUser;
        private Deptment _currentDept;
        private SearchPatList _searchPatList;


        public FrmRegister()
        {
            InitializeComponent();
        }       
        public FrmRegister(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            this.ToolControls_Enabled(RegType.默认);
            Controller = new FrmRegisterController(this);
        }
        public FrmRegister(long currentUserId, long currentDeptId, string chineseName,bool IsNotCharge)
        {
            InitializeComponent();

            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            this.ToolControls_Enabled(RegType.默认);
            Controller = new FrmRegisterController(this);
            this.ToolSB_Cost.Visible = IsNotCharge;
        }

        //关闭窗体
        private void ToolSB_Close_Click(object sender, EventArgs e)
        {
            this.ClearPatinfo();
            this.Close();
        }
        // 控制控件显示状态true 可写， false 不可写
        private void Controls_Enabled(bool b)
        {
            //this.tbInpatNo.Enabled = b;
            this.dtpregdate.Enabled = b;
            this.tbdiag.Enabled = b;
            this.tb_diag_bk.Enabled = b;
            this.tbpatName.Enabled = b;
            this.cbSex.Enabled = b;
            this.tBpatNumber.Enabled = b;
            this.dtpBridate.Enabled = b;
            this.tbGroup.Enabled = b;
            this.tbJob.Enabled = b;
            this.tbTell.Enabled = b;
            this.tbAddress.Enabled = b;
            this.tbregDeptCode.Enabled = b;
            this.tbBedNo.Enabled = b;
            this.tbCaseNo.Enabled = b;
            this.cbAccountType.Enabled = b;
            this.tbWorkNo.Enabled = b;
            this.cbCureState.Enabled = b;
            this.tbCureDocCode.Enabled = b;
            //this.tbOriginDoc.Enabled = b;
            //this.tbOriginDept.Enabled = b;
          
            //this.cbSex.SelectedIndex = 1;
        }
        // 按钮控件的现实控制
        private void ToolControls_Enabled(RegType regtype)
        {
            if (regtype == RegType.默认)
            {
                this.Controls_Enabled(false);
                this.ToolSB_New.Enabled = true;
                this.ToolSB_Cost.Enabled = false;
                this.ToolSB_Reg.Enabled = false;
                this.ToolSB_Del.Enabled = false;
                this.ToolSB_Alter.Enabled = false;
                //this.toolsb_look.Enabled = true;
            }
            else if (regtype == RegType.新证)
            {
                this.Controls_Enabled(true);
                this.ToolSB_New.Enabled = false;
                this.ToolSB_Cost.Enabled = false;
                this.ToolSB_Reg.Enabled = true;
                this.ToolSB_Del.Enabled = false;
                this.ToolSB_Alter.Enabled = false;
                //this.toolsb_look.Enabled = true;
                //this.tbInpatNo.Enabled = false;

                this.dtpregdate.Focus();
            }
            else if (regtype == RegType.修改)
            {
                this.Controls_Enabled(true);
                this.ToolSB_New.Enabled = true;
                this.ToolSB_Cost.Enabled = true;
                this.ToolSB_Reg.Enabled = false;
                this.ToolSB_Del.Enabled = true;
                this.ToolSB_Alter.Enabled = true;
                //this.toolsb_look.Enabled = true;
                this.tbInpatNo.Enabled = true;
                this.dtpregdate.Focus();
            }
            else if (regtype == RegType.其他)
            {
                this.Controls_Enabled(true);
                this.ToolSB_New.Enabled = true;
                this.ToolSB_Cost.Enabled = false;
                this.ToolSB_Reg.Enabled = false;
                this.ToolSB_Del.Enabled = false;
                this.ToolSB_Alter.Enabled = false;
                //this.toolsb_look.Enabled = false;
                this.tbInpatNo.Enabled = true;
                this.dtpregdate.Focus();
            }
            else if (regtype == RegType.不可修改)
            {
                this.Controls_Enabled(true);
                this.ToolSB_New.Enabled = false;
                this.ToolSB_Cost.Enabled = false;
                this.ToolSB_Reg.Enabled = true;
                this.ToolSB_Del.Enabled = false;
                this.ToolSB_Alter.Enabled = false;
                //this.toolsb_look.Enabled = true;
                this.tbInpatNo.Enabled = true;
                this.dtpregdate.Focus();
            }
            if (HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("008") == 0)
            {
                this.tbBedNo.Enabled = false;
                this.tbOriginDept.Enabled = false;
                this.tbOriginDoc.Enabled = false;
            }
        }       
        // 新证
        private void ToolSB_New_Click(object sender, EventArgs e)
        {
            
            this.ToolControls_Enabled(RegType.新证);
            this.ClearPatinfo();
            Controller.NewPat();
            _zyPatlist = zyPatList;

            this.tbMarkName.Text = _currentUser.Name;
        }
        // 绑定ZYPatList控件对象
        private void ClearPatinfo()
        {
            this.tbInpatNo.Text = "";
            //Entity
            this.tbpatName.Text = "";
            this.tb_regNum.Text = "";
            this.cbSex.Text = "";

            //this.tbInpatNo.Text = _patientinfo.CureNo;
            this.dtpregdate.Value = XcDate.ServerDateTime;
            this.tBpatNumber.Text = "";
            this.dtpBridate.Value = DateTime.Now;
            this.tbGroup.Text = "汉族";
            this.tbGroup.Tag = "HA";
            this.tbTell.Text = "";
            this.tbAddress.Text = "";
            this.tbCaseNo.Text = "";

            this.tbdiag.Text = "";
            this.tb_diag_bk.Text = "";
            this.tbregDeptCode.Text = "";//?
            this.tbBedNo.Text = "";//?
            this.cbCureState.Text = "";//?
            this.cbAccountType.SelectedIndex = 0;

            this.tbCureDocCode.Text = "";//?
            this.tbOriginDept.Text = "";//?
            this.tbOriginDoc.Text = "";//?
            this.tbWorkNo.Text = "";

            this.cbSex.SelectedIndex = 1;
            this.cbAge.SelectedIndex = 0;
            this.tbAge.Text = "0";

            this.txtDbName.Text = "";
            this.txtDbFee.Text = "0";

        }
        //验证必填信息
        private bool CheckPatInfo()
        {
            if ((this.tbdiag.Text == "") && this.tb_diag_bk.Text.Trim() == "")
            {
                MessageBox.Show("病人诊断不能为空！");
                this.tb_diag_bk.Focus();
                return false;
            }
            if (this.tbpatName.Text == "")
            {
                MessageBox.Show("病人姓名不能为空！");
                this.tbpatName.Focus();
                return false;
            }
            if (Encoding.Default.GetBytes(this.tbpatName.Text).Length > 10)
            {
                MessageBox.Show("病人姓名不能超过五个汉字！");
                this.tbpatName.Focus();
                return false;
            }
            if (this.tbregDeptCode.Text == "" || this.tbregDeptCode.MemberValue == null)
            {
                MessageBox.Show("入院科室不能为空！");
                this.tbregDeptCode.Focus();
                return false;
            }
            if (Convert.ToInt32(this.tbAge.Text) == 0)
            {
                MessageBox.Show("请输入合法年龄！");
                this.tbAge.Focus();
                return false;
            }

            if (HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("009") == 1)
            {
                if (this.tBpatNumber.Text.Trim() == "")
                {
                    MessageBox.Show("身份证号不能为空！");
                    this.tBpatNumber.Focus();
                    return false;
                }

                if (this.tbJob.Text.Trim() == "")
                {
                    MessageBox.Show("职业不能为空！");
                    this.tbJob.Focus();
                    return false;
                }

                if (this.tbTell.Text.Trim() == "")
                {
                    MessageBox.Show("电话号码不能为空！");
                    this.tbTell.Focus();
                    return false;
                }

                if (this.tbAddress.Text.Trim() == "")
                {
                    MessageBox.Show("家庭住址不能为空！");
                    this.tbAddress.Focus();
                    return false;

                }

                if (this.cbAccountType.SelectedIndex == 1 || this.cbAccountType.SelectedIndex == 2 || this.cbAccountType.SelectedIndex == 3)
                {
                    if (this.tbWorkNo.Text.Trim() == "")
                    {
                        MessageBox.Show("医疗证号不能为空！");
                        this.tbWorkNo.Focus();
                        return false;

                    }
                }
               
            }

            if (panel2.Visible == true)
            {
                if (this.txtDbName.Text.Trim() == "")
                {
                    MessageBox.Show("请输入担保人！");
                    this.txtDbName.Focus();
                    return false;
                }
                if (this.txtDbFee.Text.Trim() == "" || Convert.ToDecimal(this.txtDbFee.Text.Trim()) <= 0)
                {
                    MessageBox.Show("请正确输入担保金额！");
                    this.txtDbFee.Focus();
                    this.txtDbFee.SelectAll();
                    return false;
                }
            }

            return true;
        }

        //绑定ZYPatList对象==修改病人信息 和 入院病人信息 都是同一绑定
        //CurrDeptCode属性的写入有所不同
        private void BindZYPatList()
        {
            //Entity
            //int Length = Encoding.Default.GetBytes(this.tbpatName.Text.Trim()).Length;
            _zyPatlist.patientInfo.PatName = GWIString.FilterSpecial(this.tbpatName.Text);
            _zyPatlist.patientInfo.PatSex = this.cbSex.Text;
            _zyPatlist.patientInfo.PYM = PublicStaticFun.GetPyWbCode(this.tbpatName.Text)[0].ToString();
            _zyPatlist.patientInfo.WBM = PublicStaticFun.GetPyWbCode(this.tbpatName.Text)[1].ToString();
            //_patientinfo.CureNo = this.tbInpatNo.Text;
            //_patientinfo.CureNum = 1;
            _zyPatlist.patientInfo.PatNumber = GWIString.FilterSpecial(this.tBpatNumber.Text);
            _zyPatlist.patientInfo.PatBriDate = this.dtpBridate.Value;
            _zyPatlist.patientInfo.PatGroup = GWIString.FilterSpecial(this.tbGroup.Text);
            _zyPatlist.patientInfo.PatTEL = GWIString.FilterSpecial(this.tbTell.Text);
            _zyPatlist.patientInfo.PatAddress = GWIString.FilterSpecial(this.tbAddress.Text);
            _zyPatlist.patientInfo.PatCaseNo = GWIString.FilterSpecial(this.tbCaseNo.Text);
            _zyPatlist.patientInfo.MediCard = GWIString.FilterSpecial(this.tbWorkNo.Text);
            _zyPatlist.patientInfo.PATJOB = GWIString.FilterSpecial(this.tbJob.Text);
            _zyPatlist.patientInfo.ACCOUNTTYPE = this.cbAccountType.Text.ToString();//update zh 090616
            _zyPatlist.patientInfo.LinkMan = this.tblinkman.Text;
            _zyPatlist.patientInfo.LinkTel = this.tblinktel.Text;
            _zyPatlist.patientInfo.LinkAddress = this.tblinkaddress.Text;

            _zyPatlist.PatientCode = this.cbAccountType.SelectedValue.ToString();//add zh 090616
            //zy_patlist.CureNo = this.tbInpatNo.Text;
            _zyPatlist.CureDate = this.dtpregdate.Value;

            _zyPatlist.DiseaseCode = this.tbdiag.MemberValue == null ? "" : this.tbdiag.MemberValue.ToString();//?
            _zyPatlist.DiseaseName = Convert.ToString(GWIString.FilterSpecial(this.tbdiag.Text) + "|" + this.tb_diag_bk.Text.Trim()).Length > 20 ? Convert.ToString(GWIString.FilterSpecial(this.tbdiag.Text) + "|" + this.tb_diag_bk.Text.Trim()).Substring(0, 20) : Convert.ToString(GWIString.FilterSpecial(this.tbdiag.Text) + "|" + this.tb_diag_bk.Text.Trim());

            _zyPatlist.CureDeptCode = this.tbregDeptCode.MemberValue == null ? "" : this.tbregDeptCode.MemberValue.ToString();//?
            //_zyPatlist.CurrDeptCode = this.tbregDeptCode.MemberValue == null ? "" : this.tbregDeptCode.MemberValue.ToString();// add zenghao 20100714
            //zy_patlist.CurrDeptCode = "";
            _zyPatlist.BedCode = GWIString.FilterSpecial(this.tbBedNo.Text);//?
            _zyPatlist.CureState = this.cbCureState.Text;//?
            //经管
            
            //推荐人=门诊医生 
            _zyPatlist.OriginDocCode = this.tbCureDocCode.MemberValue == null ? "" : this.tbCureDocCode.MemberValue.ToString();//?;
            _zyPatlist.OriginDeptCode = this.tbCureDocCode.Tag == null ? "" : this.tbCureDocCode.Tag.ToString();//推荐科室 住院证得到
            _zyPatlist.CurrDeptCode = this.tbOriginDept.MemberValue == null ? "" : this.tbOriginDept.MemberValue.ToString();//主管科室
            _zyPatlist.CureDocCode = this.tbOriginDoc.MemberValue == null ? "" : this.tbOriginDoc.MemberValue.ToString();//?;
            _zyPatlist.MarkDate = XcDate.ServerDateTime;
            _zyPatlist.MarkEmpCode = _currentUser.EmployeeID.ToString();//?

            _zyPatlist.DbName = this.txtDbName.Text;
            _zyPatlist.DbFee = Convert.ToDecimal(this.txtDbFee.Text);

            //病人类型修改后的状态
            //if (zy_patlist.PatientInfo.ACCOUNTTYPE == "农合")
            //{
            //    zy_patlist.Nccm_NO = FrmNccm_NO;
            //}
            //else
            //{
            //    zy_patlist.Nccm_NO = "";
            //}

        }

        /// 绑定ZYPatList控件对象
        private void BindTBZYPatList()
        {
            //Entity
            this.tbpatName.Text = _zyPatlist.patientInfo.PatName;
            this.tb_regNum.Text = _zyPatlist.patientInfo.CureNum.ToString();
            this.cbSex.Text = _zyPatlist.patientInfo.PatSex;

            this.tbInpatNo.Text = _zyPatlist.patientInfo.CureNo;

            this.tBpatNumber.Text = _zyPatlist.patientInfo.PatNumber;
            _zyPatlist.patientInfo.PatBriDate = _zyPatlist.patientInfo.PatBriDate.ToString("yyyyMMdd") == "00010101" ? DateTime.Now : _zyPatlist.patientInfo.PatBriDate;
            this.dtpBridate.Value = _zyPatlist.patientInfo.PatBriDate;

            int year = DateTime.Now.Year - _zyPatlist.patientInfo.PatBriDate.Year;
            int month = DateTime.Now.Month - _zyPatlist.patientInfo.PatBriDate.Month;
            int day = DateTime.Now.Day - _zyPatlist.patientInfo.PatBriDate.Day;
            int hour = DateTime.Now.Hour - _zyPatlist.patientInfo.PatBriDate.Hour;

            if (year == 0)
            {
                if (month == 0)
                {
                    if (day == 0)
                    {
                        this.tbAge.Text = hour.ToString();
                        this.cbAge.SelectedIndex = 3;
                    }
                    else
                    {
                        this.tbAge.Text = day.ToString();
                        this.cbAge.SelectedIndex = 2;
                    }
                }
                else
                {
                    this.tbAge.Text = month.ToString();
                    this.cbAge.SelectedIndex = 1;
                }
            }
            else
            {
                this.tbAge.Text = year.ToString();
                this.cbAge.SelectedIndex = 0;
            }
            this.tbGroup.Text = _zyPatlist.patientInfo.PatGroup;
            this.tbGroup.Tag = "0";
            this.tbTell.Text = _zyPatlist.patientInfo.PatTEL;
            this.tbAddress.Text = _zyPatlist.patientInfo.PatAddress;
            this.tbCaseNo.Text = _zyPatlist.patientInfo.PatCaseNo;
            this.tbJob.Text = _zyPatlist.patientInfo.PATJOB;
            this.tblinkman.Text = _zyPatlist.patientInfo.LinkMan;
            this.tblinktel.Text = _zyPatlist.patientInfo.LinkTel;
            this.tblinkaddress.Text = _zyPatlist.patientInfo.LinkAddress;
            this.cbAccountType.SelectedValue = _zyPatlist.PatientCode == null ? "01" : _zyPatlist.PatientCode;

            this.tbInpatNo.Text = _zyPatlist.CureNo;
            this.dtpregdate.Value = _zyPatlist.CureDate.ToString("yyyyMMdd") == "00010101" ? DateTime.Now : _zyPatlist.CureDate;
            this.tbdiag.MemberValue = _zyPatlist.DiseaseCode;//?
            _zyPatlist.DiseaseName = _zyPatlist.DiseaseName == null ? "" : _zyPatlist.DiseaseName;
            string[] strdiag = _zyPatlist.DiseaseName.Split(new char[] { '|' });

            this.tbdiag.Text = strdiag[0];
            if (strdiag.Length < 2)
            {
                this.tb_diag_bk.Text = "";
            }
            else
            {
                this.tb_diag_bk.Text = strdiag[1];
            }
            this.tbregDeptCode.MemberValue = _zyPatlist.CureDeptCode;//?有个BUG
            //this.tbregDeptCode.Text = BaseData.GetDeptName(zy_patlist.CureDeptCode);
            this.tbBedNo.Text = _zyPatlist.BedCode;//?
            this.cbCureState.Text = _zyPatlist.CureState;//?
            this.tbWorkNo.Text = _zyPatlist.patientInfo.MediCard;
            this.tbOriginDoc.MemberValue = _zyPatlist.CureDocCode;//主管医生=经治医生?          
            this.tbOriginDept.MemberValue = _zyPatlist.CurrDeptCode;//主管科室
            this.tbCureDocCode.MemberValue = _zyPatlist.OriginDocCode;//推荐人

            this.tbMarkName.Text = _zyPatlist.MarkEmpName;
            //this.tbOriginDoc.MemberValue = zy_patlist.OriginDocCode;//?
            //this.tbOriginDoc.Text = BaseData.GetUserName(zy_patlist.OriginDocCode);//?
            //this.tbCureDocCode.Text = BaseData.GetUserName(zy_patlist.CureDocCode);
            //this.tbOriginDept.Text = BaseData.GetDeptName(zy_patlist.OriginDeptCode);//?

            this.txtDbName.Text = _zyPatlist.DbName;
            this.txtDbFee.Text = _zyPatlist.DbFee.ToString("0.00");
        }
        // 入院
        private void ToolSB_Reg_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPatInfo()) return;

                //20091025 临床不需要床号
                #region 
                //for (int i = 0; i < zypatlist.Count; i++)
                //{
                //    //update 同名病人提示判断更改到输入病人控件离开焦点
                //    //if (this.tbpatName.Text.Trim() == zypatlist[i].PatientInfo.PatName)
                //    //{
                //    //    if (MessageBox.Show("已有同名的病人存在，该病人是否继续保存入院？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //    //    {
                //    //        break;
                //    //    }
                //    //    else
                //    //    {
                //    //        return;
                //    //    }
                //    //}

                //    if (this.tbBedNo.Text.Trim() == zypatlist[i].BedCode)
                //    {
                //        if (MessageBox.Show("该床已有病人存在，是否继续保存入院？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                //        {
                //            break;
                //        }
                //        else
                //        {
                //            return;
                //        }
                //    }
                //}
                #endregion
                //入院后再产生住院号

                BindZYPatList();
                bool b= Controller.RegPat();
                
                if (b == true)
                {
                    MessageBox.Show("入院成功！","提示");

                    MessagePromptManager.Messenger senders = new MessagePromptManager.Messenger(_currentUser.UserID, _currentDept.DeptID, "");
                    MessagePromptManager.Messenger receiver = new MessagePromptManager.Messenger(-1,Convert.ToInt64(_zyPatlist.CureDeptCode),"");
                    MessagePromptManager.Messages message = new MessagePromptManager.Messages("003", "病人入院消息", "已经新入院了一个病人,姓名："+_zyPatlist.patientInfo.PatName+"，住院号为："+_zyPatlist.CureNo+"，请及时分配床位！");
                    senders.SendMessage(receiver, message);
                    this.ToolControls_Enabled(RegType.修改);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
            }
        }   
        // 取消入院
        private void ToolSB_Del_Click(object sender, EventArgs e)
        {
            try
            {
                if (_zyPatlist != null)
                {
                    if (MessageBox.Show("确定要取消该病人吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                    {
                        bool b = Controller.DelPat();
                        if (b == true)
                        {
                            MessageBox.Show("取消成功！");
                            this.ToolControls_Enabled(RegType.默认);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
            }
        }
        // 修改病人信息
        private void ToolSB_Alter_Click(object sender, EventArgs e)
        {
            try
            {
                if (!CheckPatInfo()) return;

                BindZYPatList();
                bool b = Controller.AlterPat();
                if (b == true)
                {
                    MessageBox.Show("修改成功！", "提示");
                    this.ToolControls_Enabled(RegType.修改);
                }
                else
                {
                    MessageBox.Show("修改失败，请重新刷新！", "提示");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message,"提示");
            }
        }
        // 双击查看修改入院病人信息
        private void lvPatList_DoubleClick(object sender, EventArgs e)
        {
            if (this.lvPatList.SelectedItems[0].Tag != null)
            {
                _zyPatlist = (ZY_PatList)this.lvPatList.SelectedItems[0].Tag;
                BindTBZYPatList();
                this.ToolControls_Enabled(RegType.修改);
            }
        }
        // 根据住院号搜索病人信息
        private void tbInpatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                CureNoKeyDown();
            }
        }

        private void CureNoKeyDown()
        {
            Controller.KeyDownCureNo();
            
            if (_zyPatlist != null)
            {

                if (_zyPatlist.PatType == "1" || _zyPatlist.PatType == "2")
                {

                    this.ToolControls_Enabled(RegType.修改);
                }
                else
                {
                    this.ToolControls_Enabled(RegType.不可修改);
                    this.dtpregdate.Value = DateTime.Now;
                }
                BindTBZYPatList();
            }
            else
            {
                //this.ToolControls_Enabled(RegType.新证);
                //this.ClearPatinfo();
                //Controller.NewPat();
                //_zyPatlist = zyPatList;
                this.dtpregdate.Focus();
                _zyPatlist = new ZY_PatList();
                //MessageBox.Show("您输入的住院号病人不存在！");
                //this.tbInpatNo.Text = "0";
                //this.ToolControls_Enabled(RegType.其他);
            }
        }
        // 刷新病人列表
        private void llabrush_Click(object sender, EventArgs e)
        {
            Controller.BrushPatList();
        }
        //收费
        private void ToolSB_Cost_Click(object sender, EventArgs e)
        {
            if (_zyPatlist != null)
            {
                if (_zyPatlist.PatType == "1" || _zyPatlist.PatType == "2")
                {

                    FrmCharge frmCharge = new FrmCharge(_zyPatlist, "住院收费");
                    frmCharge.currentDept = _currentDept;
                    frmCharge.currentUser = _currentUser;
                    frmCharge.WindowState = FormWindowState.Maximized;
                    frmCharge.MdiParent = this.MdiParent;
                    frmCharge.BindDataGrid();
                    ((GWMHIS.BussinessLogicLayer.Interfaces.IInvokForm)this.Parent.Parent.Parent).AddFormToTabPage(frmCharge);
                    frmCharge.Show();
                    //this.Close();
                }
                else
                {
                    MessageBox.Show("该病人不能收费操作！");
                }
            }
        }
        //显示时间筛选
        private void cbdate_CheckedChanged(object sender, EventArgs e)
        {
            if (this.cbdate.Checked)
            {
                this.dtpBegin.Enabled = true;
                this.dtpEnd.Enabled = true;
            }
            else
            {
                this.dtpBegin.Enabled = false;
                this.dtpEnd.Enabled = false;
            }
        }
        //显示科室筛选
        private void chbDept_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chbDept.Checked)
            {
                this.cbDept.Enabled = true;
            }
            else
            {
                this.cbDept.Enabled = false;
            }
        }
        //显示在院
        private void rbOut_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOut.Checked)
            {
                this.cbdate.Checked = true;
                this.chbDept.Checked = true;
            }
        }
        //显示出院
        private void rbin_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbOut.Checked)
            {
                this.cbdate.Checked = false;
                this.chbDept.Checked = false;
            }
        }
        //读卡
        private void button1_Click(object sender, EventArgs e)
        {
            FrmSearchPat fsp = new FrmSearchPat(Controller);
            fsp.ShowDialog();

            try
            {
                if (fsp.IsDiag)
                {
                    //如果以前有入院过，直接调出住院号
                    if (_zyPatlist.patientInfo.CureNo != null && _zyPatlist.patientInfo.CureNo != "")
                    {
                        //ZY_PatList zyp = _zyPatlist.GetPatInfo(_zyPatlist.patientInfo.CureNo);
                        //判断该病人是否在院，如果在院就是修改当前信息
                        if (_zyPatlist.PatType == "1" || _zyPatlist.PatType == "2")
                        {
                            this.ToolControls_Enabled(RegType.修改);
                        }
                        else
                        {
                            this.ToolControls_Enabled(RegType.不可修改);
                        }

                        //this.tbInpatNo.Text = _zyPatlist.patientInfo.CureNo;
                        //this.tbInpatNo.Focus();
                        //this.CureNoKeyDown();
                    }
                    else
                    {
                        this.ToolControls_Enabled(RegType.新证);

                    }
                    //绑定最新的病人信息
                    BindTBZYPatList();
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
            }
        }
        //显示维护监护人信息
        private void linkLabel1_Click(object sender, EventArgs e)
        {
            if (this.panel2.Visible)
            {
                this.panel2.Visible = false;
            }
            else
            {
                this.panel2.Visible = true;
            }
        }
        //年龄反算出生日期
        private void tbage_TextChanged(object sender, EventArgs e)
        {
            if (cbAge.SelectedIndex == 0)
            {
                this.dtpBridate.Value = DateTime.Now.AddYears(0 - Convert.ToInt32(this.tbAge.Text));
            }
            else if (cbAge.SelectedIndex == 1)
            {
                this.dtpBridate.Value = DateTime.Now.AddMonths(0 - Convert.ToInt32(this.tbAge.Text));
            }
            else if (cbAge.SelectedIndex == 2)
            {
                this.dtpBridate.Value = DateTime.Now.AddDays(0 - Convert.ToInt32(this.tbAge.Text));
            }
            else if (cbAge.SelectedIndex == 3)
            {
                this.dtpBridate.Value = DateTime.Now.AddHours(0 - Convert.ToInt32(this.tbAge.Text));
            }
            //this.dtpBridate.Value
        }
        //年龄反算出生日期
        private void cbAge_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbAge.SelectedIndex == 0)
            {
                this.dtpBridate.Value = DateTime.Now.AddYears(0 - Convert.ToInt32(this.tbAge.Text));
            }
            else if (cbAge.SelectedIndex == 1)
            {
                this.dtpBridate.Value = DateTime.Now.AddMonths(0 - Convert.ToInt32(this.tbAge.Text));
            }
            else if (cbAge.SelectedIndex == 2)
            {
                this.dtpBridate.Value = DateTime.Now.AddDays(0 - Convert.ToInt32(this.tbAge.Text));
            }
            else if (cbAge.SelectedIndex == 3)
            {
                this.dtpBridate.Value = DateTime.Now.AddHours(0 - Convert.ToInt32(this.tbAge.Text));
            }
        }
        //窗体加载事件
        private void FrmRegister_Load(object sender, EventArgs e)
        {
            //临床、经管显示内容不同
            if (HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("008") == 0)
            {
                this.tbBedNo.Enabled = false;
                this.tbOriginDoc.Enabled = false;
                this.tbOriginDept.Enabled = false;
                this.toolBack.Visible = false;
                this.label7.Enabled = false;
                this.label20.Enabled = false;
                this.label24.Enabled = false;
            }
            else
            {
                this.tbBedNo.Enabled = true;
                this.tbOriginDoc.Enabled = false;
                this.tbOriginDept.Enabled = false;
                this.toolBack.Visible = true;
                this.label7.Enabled = true;
                this.label20.Enabled = true;
                this.label24.Enabled = true;
            }
            //必填项
            if (HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("009") == 1)
            {
                this.label33.Visible = true;
                this.label34.Visible = true;
                this.label35.Visible = true;
                this.label36.Visible = true;
                this.label37.Visible = true;
                this.label38.Visible = true;
            }
            else
            {
                this.label33.Visible = false;
                this.label34.Visible = false;
                this.label35.Visible = false;
                this.label36.Visible = false;
                this.label37.Visible = false;
                this.label38.Visible = false;
            }
        }

        #region key
        private void dtpregdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tbdiag.Focus();
            }
        }

        private void tbpatName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cbSex.Focus();
            }
        }

        private void cbSex_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tBpatNumber.Focus();
            }
        }

        private void tBpatNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //this.dtpBridate.Focus();
                this.tbAge.Focus();
            }
        }

        private void dtpBridate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tbGroup.Focus();
            }
        }



        private void tbJob_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tbTell.Focus();
            }
        }

        private void tbTell_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tbAddress.Focus();
            }
        }

        private void tbAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tbregDeptCode.Focus();
            }
        }

        private void tbBedNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tbCaseNo.Focus();
            }
        }

        private void tbCaseNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cbAccountType.Focus();
            }
        }

        private void cbAccountType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tbWorkNo.Focus();
            }
        }

        private void tbWorkNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.cbCureState.Focus();
            }

        }

        private void cbCureState_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                this.tbCureDocCode.Focus();

            }
        }

        private void toolBack_Click(object sender, EventArgs e)
        {
            if (_zyPatlist != null)
            {
                if (MessageBox.Show("确定要召回该病人吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    bool b = Controller.BackPat();
                    if (b == true)
                    {
                        MessageBox.Show("召回成功！");
                    }
                }
            }
        }
        //窗体快捷键
        private void FrmRegister_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:

                    break;
                case Keys.F1:	//帮助

                    break;
                case Keys.F2:	//新证
                    if (ToolSB_New.Enabled)
                    {
                        ToolSB_New_Click(null, null);
                    }
                    break;
                case Keys.F3:	//入院
                    if (ToolSB_Reg.Enabled)
                    {
                        ToolSB_Reg_Click(null, null);
                    }
                    break;
                case Keys.F4:	//收费
                    //this.toolStrip1.Focus();
                    if (ToolSB_Cost.Enabled && ToolSB_Cost.Visible)
                    {
                        ToolSB_Cost_Click(null, null);
                    }
                    break;
                case Keys.F5:	//取消入院
                    if (ToolSB_Del.Enabled)
                    {
                        ToolSB_Del_Click(null, null);
                    }
                    break;
                case Keys.F6:	//出院召回
                    if (toolBack.Enabled)
                    {
                        toolBack_Click(null, null);
                    }
                    break;
                case Keys.F7:	//修改
                    if (ToolSB_Alter.Enabled)
                    {
                        ToolSB_Alter_Click(null, null);
                    }
                    break;
                default:
                    break;
            }
        }



        private void tbpatName_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
            //必须是新证时才加载历史病人信息
            #region 
            //[20100610.1.09]
            /*
            if (this.ToolSB_New.Enabled == false && Convert.ToInt32(this.tbInpatNo.Text) == 0)
            {
                DataTable dt = _zyPatlist.patientInfo.GetNccmPat_LH(SearchNccmPatType.病人姓名, this.tbpatName.Text.Trim());
                if (dt.Rows.Count > 0)
                {
                    FrmSearchPat fsp = new FrmSearchPat(Controller,this.tbpatName.Text.Trim());
                    fsp.ShowDialog();
                    try
                    {
                        if (fsp.IsDiag)
                        {
                            //如果以前有入院过，直接调出住院号
                            if (_zyPatlist.patientInfo.CureNo != null && _zyPatlist.patientInfo.CureNo != "")
                            {
                                //ZY_PatList zyp = _zyPatlist.GetPatInfo(_zyPatlist.patientInfo.CureNo);
                                //判断该病人是否在院，如果在院就是修改当前信息
                                if (_zyPatlist.PatType == "1" || _zyPatlist.PatType == "2")
                                {
                                    this.ToolControls_Enabled(RegType.修改);
                                }
                                else
                                {
                                    this.ToolControls_Enabled(RegType.不可修改);
                                }
                            }
                            else
                            {
                                this.ToolControls_Enabled(RegType.新证);
                                
                            }
                            BindTBZYPatList();
                        }
                    }
                    catch(Exception err)
                    {
                        MessageBox.Show(err.Message, "提示");
                    }
                }
            }
            */
            #endregion

        }

        private void tbGroup_Leave(object sender, EventArgs e)
        {
            if (this.tbGroup.Tag == null && this.tbGroup.Text != "")
            {
                this.tbGroup.Focus();
                this.tbGroup.SelectAll();
            }
            else if (this.tbGroup.Text.Trim() == "")
            {
                this.tbGroup.Tag = null;
            }
        }

        private void tbregDeptCode_Leave(object sender, EventArgs e)
        {
            //if (this.tbregDeptCode.MemberValue == null && this.tbregDeptCode.Text != "")
            //{
            //    this.tbregDeptCode.Focus();
            //    this.tbregDeptCode.SelectAll();
            //}
            //else if (this.tbregDeptCode.Text.Trim() == "")
            //{
            //    this.tbregDeptCode.MemberValue = null;
            //}
        }

        private void tbCureDocCode_Leave(object sender, EventArgs e)
        {
            //if (this.tbCureDocCode.MemberValue == null && this.tbCureDocCode.Text != "")
            //{
            //    this.tbCureDocCode.Focus();
            //    this.tbCureDocCode.SelectAll();
            //}
            //else if (this.tbCureDocCode.Text.Trim() == "")
            //{
            //    this.tbCureDocCode.MemberValue = null;
            //}
        }

        private void tbOriginDoc_Leave(object sender, EventArgs e)
        {
            //if (this.tbOriginDoc.MemberValue == null && this.tbOriginDoc.Text != "")
            //{
            //    this.tbOriginDoc.Focus();
            //    this.tbOriginDoc.SelectAll();
            //}
            //else if (this.tbOriginDoc.Text.Trim() == "")
            //{
            //    this.tbOriginDoc.MemberValue = null;
            //}
        }

        private void tbOriginDept_Leave(object sender, EventArgs e)
        {
            //if (this.tbOriginDept.MemberValue == null && this.tbOriginDept.Text != "")
            //{
            //    this.tbOriginDept.Focus();
            //    this.tbOriginDept.SelectAll();
            //}
            //else if (this.tbOriginDept.Text.Trim() == "")
            //{
            //    this.tbOriginDept.MemberValue = null;
            //}
        }



        private void tbpatName_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = GetInputLanguage(Constant.CustomImeMode);
        }

        /// 依据输入法描述获取输入法
        public static InputLanguage GetInputLanguage(string languageName)
        {
            foreach (InputLanguage l in InputLanguage.InstalledInputLanguages)
            {
                if (l.LayoutName.IndexOf(languageName) >= 0)
                {
                    return l;
                }
            }
            //如果当前输入法中无要查找的输入法则返回默认输入法
            return InputLanguage.DefaultInputLanguage;
        }

        private void tbAddress_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = GetInputLanguage(Constant.CustomImeMode);
        }

        private void tbAddress_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }


        private void tb_diag_bk_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                this.tbpatName.Focus();
            }
        }

        private void tb_diag_bk_Enter(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = GetInputLanguage(Constant.CustomImeMode);
        }

        private void tb_diag_bk_Leave(object sender, EventArgs e)
        {
            InputLanguage.CurrentInputLanguage = InputLanguage.DefaultInputLanguage;
        }

        private void tbOriginDept_AfterSelectedRow(object sender, object SelectedValue)
        {
            if (this.ToolSB_Reg.Enabled == true)
            {
                this.toolStrip1.Focus();
                this.ToolSB_Reg.Select();
            }
            else if (this.ToolSB_Alter.Enabled == true)
            {
                this.toolStrip1.Focus();
                this.ToolSB_Alter.Select();
            }
        }
        #endregion

        #region IFrmRegisterView 成员

        private void ShowCardWidth(GWI.HIS.Windows.Controls.QueryTextBox qtb)
        {
            if (qtb.Width > 250)
                qtb.SelectionCardWidth = qtb.Width;
        }

        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }

        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }

        public void Initialize(DataSet _dataSet)
        {
            ShowCardWidth(tbdiag);
            ShowCardWidth(tbGroup);
            ShowCardWidth(tbregDeptCode);
            ShowCardWidth(tbCureDocCode);
            ShowCardWidth(tbOriginDoc);
            ShowCardWidth(tbOriginDept);

            this.tbdiag.SetSelectionCardDataSource(_dataSet.Tables["Disease"]);
            this.tbGroup.SetSelectionCardDataSource(_dataSet.Tables["Nationco"]);
            this.tbregDeptCode.SetSelectionCardDataSource(_dataSet.Tables["Dept"]);
            this.tbCureDocCode.SetSelectionCardDataSource(_dataSet.Tables["User"]);
            this.tbOriginDoc.SetSelectionCardDataSource(_dataSet.Tables["UserDoc"]);
            this.tbOriginDept.SetSelectionCardDataSource(_dataSet.Tables["LCDept"]);

            this.cbAccountType.DataSource = _dataSet.Tables["PatientType"];
            this.cbAccountType.DisplayMember = "name";
            this.cbAccountType.ValueMember = "code";
        }

        public SearchPatList searchPatList
        {
            get
            {
                _searchPatList = new SearchPatList();
                if (chbDept.Checked)
                {
                    _searchPatList.DeptCode = this.cbDept.SelectedValue.ToString().Trim();
                }
                if (this.cbdate.Checked)
                {
                    _searchPatList.Bdate = this.dtpBegin.Value;
                    _searchPatList.Edate = this.dtpEnd.Value;
                }
                _searchPatList.rbIn = this.rbin.Checked;
                return _searchPatList;
            }
        }

        public DataTable cbDept_set
        {
            set
            {
                DataTable dt = value;
                this.cbDept.DataSource = dt;
                this.cbDept.DisplayMember = "name";
                this.cbDept.ValueMember = "code";
            }
        }

        public ZY_PatList zyPatList
        {
            get
            {
                return _zyPatlist;
            }
            set
            {
                _zyPatlist = value;
            }
        }

        public string InpatNo
        {
            get
            {
                return this.tbInpatNo.Text;
            }
            set
            {
                this.tbInpatNo.Text = value;
            }
        }

        public List<ZY_PatList> zyPatLists
        {
            set
            {
                this.lvPatList.Items.Clear();
                _zyPatlists = value;
                for (int i = 0; i < _zyPatlists.Count; i++)
                {
                    ListViewItem lstViewItem = new ListViewItem();
                    lstViewItem.SubItems.Clear();
                    lstViewItem.Tag = _zyPatlists[i];
                    lstViewItem.SubItems[0].Text = _zyPatlists[i].CureNo;
                    lstViewItem.SubItems.Add(_zyPatlists[i].patientInfo.PatName);
                    lstViewItem.SubItems.Add(_zyPatlists[i].patientInfo.PatSex);
                    lstViewItem.SubItems.Add(_zyPatlists[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                    this.lvPatList.Items.Add(lstViewItem);
                }
                this.label2.Text = _zyPatlists.Count + " 人";
            }
        }

        #endregion
    }
}
