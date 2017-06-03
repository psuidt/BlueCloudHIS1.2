using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.ZY_BLL;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.ZYDoc_BLL;
using GWMHIS.BussinessLogicLayer.Classes;
using GWI.HIS.Windows.Controls;
using HIS.SYSTEM.PubicBaseClasses;
using System.IO;
using grproLib;
using System.Runtime.InteropServices;//用到DllImport时候要引入的包


namespace HIS_ZYDocManager.日常业务
{
    public partial class FrmCheckApply : Form, Action.IFrmMediApplyView
    {
        public FrmCheckApply()
        {
            InitializeComponent();
        }
        private DataRow[] dr;
        private User _currentUser;
        private Deptment _currentDept;
        private Action.FrmMediApplyController Controller;
        HIS.Model.ZY_PatList _zypatlist;
        private int deptId;
        private int medicalClass;
        private decimal pr = 0;
        private bool IsChange = true;      
        private DataTable place = new DataTable();
        DataTable JcItems = new DataTable();
        private string checkplace = "";
        private DataTable type = new DataTable();
        List<HIS.Model.ZY_DOC_CHECKAPPLY> applys;      
        #region  pacs接口引入动态库
        [DllImport("PlugInVisit.dll")]
        extern static bool hyInitHinstance(IntPtr Handle);
        [DllImport("PlugInVisit.dll")]
        extern static bool hyOpenPACSImageView(StringBuilder cPaitentID, StringBuilder cReqNum);
        [DllImport("PlugInVisit.dll")]
        extern static bool hyGetPACSReportView(StringBuilder cPaitentID, StringBuilder cReqNum, string cFilePath);
        [DllImport("PlugInVisit.dll")]
        extern static bool hyFreeHinstance();
        #endregion
        public FrmCheckApply(HIS.Model.ZY_PatList _patlist,long userid,long deptid)
        {
            InitializeComponent();           
            _currentUser = new User(userid);
            _currentDept=new Deptment (deptid);
            _zypatlist = _patlist;           
            Controller = new HIS_ZYDocManager.Action.FrmMediApplyController(this,HIS.ZYDoc_BLL.MediApply.MediType.检查);
            Controller.GetPatlist();
            place = Controller.GetCheckPlace(); 
            if (Controller.ConnectPacs())
            {
                try
                {
                    hyInitHinstance(this.Handle);
                }
                catch
                {
                }
            }
            
        }
        private void FrmCheckApply_Load(object sender, EventArgs e)
        {
            Controller.getDept();
        }
        private void FrmCheckApply_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Controller.ConnectPacs())
                {
                    hyFreeHinstance();
                }
            }
            catch
            {
 
            }
        }

        #region IView成员
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
            if (this.cbDept.SelectedIndex >= 0)
            {
                DataTable dt = _dataSet.Tables["Type"].Clone();
                DataRow[] rows = _dataSet.Tables["Type"].Select("dept_id = " +this.cbDept.SelectedValue.ToString()+ "");
                dt.Clear();
                this.cbType.DataSource = null;
                foreach (DataRow dr in rows)
                {
                    dt.Rows.Add(dr.ItemArray);
                }
                DataRow drr = dt.NewRow();
                drr["medical_class"] = 1000;
                drr["medical_class_name"] = "其他";
                dt.Rows.Add(drr);                
                this.cbType.DisplayMember = "medical_class_name";
                this.cbType.ValueMember = "medical_class";
                this.cbType.DataSource = dt;
            }    
            type=_dataSet.Tables["MediClass"];
        }

        #endregion

        #region view成员
        public void getDept(DataSet _dataSet)
        {
            if (_dataSet.Tables["Dept"].Rows.Count == 0)
            {
                MessageBox.Show("错误，未能取得检查科室信息！");
                return;
            }            
            this.cbDept.DisplayMember = "dept_name";
            this.cbDept.ValueMember = "dept_id";
            this.cbDept.DataSource = _dataSet.Tables["Dept"];
        }
        public HIS.Model.ZY_PatList BindPatControlData
        {
            set
            {
                this.txtCureNo.Text = value.CureNo;
                this.txtBedNo.Text = value.BedCode;
                this.txtPatName.Text = value.PatientInfo.PatName;
                this.txtPatSex.Text = value.PatientInfo.PatSex;
                string[] strdiag = value.DiseaseName.Split(new char[] { '|' });
                if (strdiag[0] == "")
                {
                    this.txtDiag.Text = strdiag[1].Replace("\r\n", "");
                }
                else
                {
                    this.txtDiag.Text = strdiag[0].Replace("\r\n", "");
                }             
                string age = HIS.SYSTEM.PubicBaseClasses.Age.GetAgeString(value.PatientInfo.PatBriDate, XcDate.ServerDateTime, 1);                
                this.txtPatAge.Text = age;
            }
        }

        public PatFee BindPatFeeControlData
        {
            set
            {
                this.lbChargeFee.Text = value.chargeFee.ToString();
                this.lbCostFee.Text = value.costFee.ToString();
                this.lbExtFee.Text = value.surplusFee.ToString();
                if (value.surplusFee < 0)
                {
                    this.lbExtFee.ForeColor = Color.Red;
                }
                else
                {
                    this.lbExtFee.ForeColor = Color.Black;
                }

            }
        }
        public HIS.Model.ZY_PatList zy_patlist_get
        {
            get
            {
                return _zypatlist;
            }
        }
        #endregion

        #region  事件
        //取消所有被Checked的项目
        private void SelectOne()
        {
            for (int i = 0; i < this.ChkItemsBox.Items.Count; i++)
            {
                this.ChkItemsBox.SetItemChecked(i, false);
            }
            this.lbPrice.Text = "0.0 元";
        }
        //选择项目事件
        private void ChkItemsBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 32 && chkMore.Checked == false)
            {
                SelectOne();
            }
            if (e.KeyValue != 13)
            {
                return;
            }
            if (this.chkMore.Checked == false)
            {
                SelectOne();
            }
            if (ChkItemsBox.GetItemChecked(this.ChkItemsBox.SelectedIndex) == false)
            {
                this.ChkItemsBox.SetItemChecked(this.ChkItemsBox.SelectedIndex, true);
            }
            else
            {
                this.ChkItemsBox.SetItemChecked(this.ChkItemsBox.SelectedIndex, false);
            }
            ChkItemsBox_SelectedIndexChanged(sender, e);
        }
        //检查费动态统计(录入页)
        private void ChkItemsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal p = 0;
            cmbPlace.Text = "";
            pr = 0;
            for (int i = 0; i <= ChkItemsBox.CheckedItems.Count - 1; i++)
            {
                p = ((HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i]).ORDER_PRICE;
                if (p.ToString() == "")
                {
                    continue;
                }
                pr += p;
            }
            if (ChkItemsBox.CheckedItems.Count > 1)
            {
                lbPrice.Text = "合计 " + pr.ToString() + " 元";
            }
            else
            {
                lbPrice.Text = pr.ToString() + " 元";
            }
        }
        //选择科室
        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsChange)//不允许改变
            {
                this.IsChange = true;
                return;
            }
            if (cbDept.SelectedIndex >= 0)
            {
                Controller.BindData();
                this.chkMore.Checked = false;
            }
        }
        //选择类型
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsChange)//不允许改变
            {
                this.IsChange = true;
                return;
            }
            this.deptId = Convert.ToInt32(this.cbDept.SelectedValue);
            this.medicalClass = Convert.ToInt32(this.cbType.SelectedValue);
            this.chkMore.Checked = false;
            this.tbtj.Text = "";
            this.tbhyjg.Text = "";
            this.tbxjg.Text = "";
            this.thother.Text = "";
            this.tbHIstory.Text = "";
            for (int i = 0; i < type.Rows.Count; i++)
            {
                if (type.Rows[i]["id"].ToString() == this.medicalClass.ToString())
                {
                    if (type.Rows[i]["multselect"].ToString() != "0")
                    {
                        //可多选
                        this.chkMore.Enabled = true;
                    }

                }
            }
            DataRow[] dr = place.Select("medical_class=" + this.medicalClass + "");
            for (int i = 0; i < dr.Length; i++)
            {
                cmbPlace.Items.Add(dr[i]["name"]);
            }
            if (dr.Length > 0)
            {
                cmbPlace.Text = dr[0]["name"].ToString().Trim();
            }
            if (this.cbType.Text == "CT")
            {
                this.cmbPlace.Enabled = true;
            }
            else
            {
                this.cmbPlace.Enabled = false;
            }
            JcItems = Controller.Items(HIS.ZYDoc_BLL.MediApply.MediType.检查, deptId, medicalClass);

            this.ChkItemsBox.Items.Clear();
            HIS.Model.ZY_DOC_ORDERRECORD record = null;
            for (int i = 0; i < JcItems.Rows.Count; i++)
            {
                record = new HIS.Model.ZY_DOC_ORDERRECORD();
                record.ORDER_CONTENT = XcConvert.IsNull(JcItems.Rows[i]["order_name"].ToString(), "");
                record.ORDER_DOC = Convert.ToInt32(_currentUser.EmployeeID);
                record.ITEM_TYPE = Convert.ToInt32(JcItems.Rows[i]["order_type"]);
                record.ORDITEM_ID = Convert.ToInt32(JcItems.Rows[i]["order_id"]);
                record.EXEC_DEPT = Convert.ToInt32(JcItems.Rows[i]["dept_id"]);
                record.ORDER_USAGE = XcConvert.IsNull(JcItems.Rows[i]["default_usage"].ToString(), "");
                record.ITEM_CODE = XcConvert.IsNull(JcItems.Rows[i]["statitem_code"].ToString(), "");
                record.ORDER_PRICE =   Convert.ToDecimal(XcConvert.IsNull(JcItems.Rows[i]["price"].ToString().Trim(),"0"));
                record.SEVERS_ID = Convert.ToInt32(JcItems.Rows[i]["item_id"]);
                record.UNIT = XcConvert.IsNull(JcItems.Rows[i]["order_unit"].ToString(), "");
                record.ORDER_SPEC = XcConvert.IsNull(JcItems.Rows[i]["py_code"].ToString(), "");
                record.ORECORD_A2 = 0;
                if (Convert.ToInt32(JcItems.Rows[i]["tc_flag"]) == 1)
                {
                    record.TC_ID = Convert.ToInt32(JcItems.Rows[i]["item_id"].ToString());                   
                }
                else
                {
                    record.TC_ID = 0;                   
                }
                this.ChkItemsBox.Items.Add(record);
            }
            lbPrice.Text = "0.00元";          
            if (this.cbType.Text.IndexOf("CT", 0) == 0)
            {
                this.chbox2.Visible = true;
                //this.chbox3.Visible = true;
                //this.chbox4.Visible = true;
            }
            else
            {
                this.chbox2.Visible = false;
               // this.chbox3.Visible = false;
               // this.chbox4.Visible = false;
            }
        }
        //选中项目
        private void ChkItemsBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.chkMore.Checked == false)
            {
                for (int i = 0; i < this.ChkItemsBox.Items.Count; i++)
                {
                    if (i != ChkItemsBox.SelectedIndex)
                    {
                        this.ChkItemsBox.SetItemChecked(i, false);
                    }
                }
            }
            lbPrice.Text = "0.0 元";
        }
        // 多选
        private void chkMore_CheckedChanged(object sender, EventArgs e)
        {
            if (this.ChkItemsBox.CheckedItems.Count != 1 && this.chkMore.Checked == false)
            {
                SelectOne();
            }
            if (this.chkMore.Checked)
            {
                this.cmbPlace.Text = "";
                this.cmbPlace.Enabled = false;
            }
            else
            {
                if (cbType.Text == "CT")
                {
                    this.cmbPlace.Enabled = true;
                }
            }
        }
        //提交，生成医嘱 
        private void btnSend_Click(object sender, EventArgs e)
        {
            //2010.1.8
            if (Controller.IsNotCanUse())
            {
                MessageBox.Show("该病人已出院，不能修改医嘱");
                return;
            }
            if (ChkItemsBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("没有选择检查项目！不能申请！", "提示");
                return;
            }
            if (MessageBox.Show("你确定要生成医嘱吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            List<HIS.Model.ZY_DOC_ORDERRECORD> orders = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            applys = new List<HIS.Model.ZY_DOC_CHECKAPPLY>();
            HIS.Model.ZY_DOC_ORDERRECORD record;
            HIS.Model.ZY_DOC_CHECKAPPLY apply;          
            for (int i = 0; i <= ChkItemsBox.CheckedItems.Count - 1; i++)
            {
                record = (HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i];        
                record.ORDER_BDATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;                
                record.OPRERATOR = Convert.ToInt32(_currentUser.EmployeeID);               
                record.PRES_DEPTID =Convert.ToInt32( _currentDept.DeptID);
                record.ORDER_DOC =Convert.ToInt32(_currentUser.EmployeeID);
                orders.Add(record);
                if (cmbPlace.Enabled && cmbPlace.Text != "")
                {
                    checkplace = this.cmbPlace.Text.Trim();
                }
                else
                {
                    checkplace = "";
                }
                apply = new HIS.Model.ZY_DOC_CHECKAPPLY();
                apply.CHECK_PLACE = checkplace;
                apply.MEDICAL_STATE = this.tbHIstory.Text; 
                applys.Add(apply);
            }
            if ( Controller.SaveCheck(orders,applys))
            {
                for (int i = 0; i < orders.Count; i++)
                {
                    if (applys[i].CHECK_PLACE != "")
                    {
                        string content = orders[i].ORDER_CONTENT;
                        orders[i].ORDER_CONTENT = content.Substring(content.IndexOf(")") + 1);
                    }
                }               
                MessageBox.Show("检查申请完成!\n生成医嘱成功!");                
            }            
        }
        //退出
        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();           
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                this.btnSend.Visible = false;
                if (Controller.ConnectPacs())
                {
                    this.btnResult.Visible = true;
                    this.btnPhoto.Visible = true;
                }
                else
                {
                    this.btnResult.Visible = false;
                    this.btnPhoto.Visible = false;
                }
            }
            else
            {
                this.btnSend.Visible = true;
                this.btnResult.Visible = false;
                this.btnPhoto.Visible = false;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                DateTime dateNow = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                dtBegin.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 00:00:00");
                dtend.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 23:59:59");
            }
        }
        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string ApplyName = "";
            List<HIS.Model.ZY_DOC_ORDERRECORD> records = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            if (this.tabControl1.SelectedIndex == 0)
            {
                records.Clear();
                ApplyName = this.cbType.Text.Trim();
                records.Clear();
                if (ChkItemsBox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("请选择项目");
                    return;
                }
                for (int i = 0; i <= ChkItemsBox.CheckedItems.Count - 1; i++)
                {
                    HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
                    record = (HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i];
                    if (record.ORECORD_A2 ==0 )//没有提交，不能打印
                    {
                        MessageBox.Show("您还没有提交检查申请，请先提交，再打印");
                        return;
                    }
                    records.Add(record);
                }
            }
            else
            {
                if (this.dataGridView1 == null || dataGridView1.Rows.Count == 0 || dataGridView1.CurrentCell == null)
                {
                    return;
                }
                else
                {
                    this.cmbPlace.Text = "";
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    int i = dataGridView1.CurrentCell.RowIndex;
                    int orderid = Convert.ToInt32(dt.Rows[i]["orditem_id"].ToString());
                    ApplyName = Controller.GetItemName(orderid).Trim(); 
                    records.Clear();
                    HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
                    record = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, record);
                    record.ORDER_PRICE = Convert.ToDecimal(XcConvert.IsNull(dt.Rows[i]["检查费"].ToString(),"0"));
                    record.ORDER_CONTENT = dt.Rows[i]["检查项目"].ToString();
                    records.Add(record);
                }
            }

            try
            {
                DateTime dtime = this.dateTimePicker1.Value;
                string name = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(_currentUser.EmployeeID.ToString());
                string deptname = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetDeptName(_currentDept.DeptID.ToString());
                string startPath = Application.StartupPath + "\\report\\住院医生_" + ApplyName + "申请单.grf";
                if (!File.Exists(startPath))
                {
                    MessageBox.Show("报表文件不存在");
                    return;
                }
                if (tabControl1.SelectedIndex == 0)
                {
                   Controller.CheckPrint(startPath, _zypatlist, records, dtime, name, this.tbHIstory.Text.Trim(), checkplace, deptname, this.tbtj.Text, this.tbxjg.Text, this.tbhyjg.Text, this.thother.Text);
                }
                else
                {
                    Controller.CheckPrint(startPath, _zypatlist, records, dtime, name, "", "", deptname, "", "", "", "");
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
        #endregion  
       
        #region 键盘事件
        private void txtDM_TextChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.ChkItemsBox.Items.Count; i++)
            {
                if (((HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.Items[i]).ORDER_SPEC.IndexOf(txtDM.Text.Trim().ToLower(), 0) == 0)
                {
                    this.ChkItemsBox.SelectedIndex = i;
                    break;
                }
            }
        }

        private void txtDM_KeyDown(object sender, KeyEventArgs e)
        {
            int sel = this.ChkItemsBox.SelectedIndex;
            if (e.KeyValue == 13 && this.ChkItemsBox.SelectedItems.Count != 0)
            {
                if (this.chkMore.Checked == false) SelectOne();
                if (this.ChkItemsBox.GetItemChecked(sel) == false)
                {
                    this.ChkItemsBox.SetItemChecked(sel, true);
                }
                else this.ChkItemsBox.SetItemChecked(sel, false);
                ChkItemsBox_SelectedIndexChanged(sender, e);
                txtDM.Text = "";
                this.ChkItemsBox.SelectedIndex = sel;
            }
            if (e.KeyValue == 40)
            {
                if (sel < this.ChkItemsBox.Items.Count - 1) this.ChkItemsBox.SelectedIndex++;
            }
            if (e.KeyValue == 39)
            {
                if (sel + 7 < this.ChkItemsBox.Items.Count) this.ChkItemsBox.SelectedIndex += 7;
            }
            if (e.KeyValue == 38)
            {
                if (sel > 0) this.ChkItemsBox.SelectedIndex--;
            }
            if (e.KeyValue == 37)
            {
                if (sel - 7 >= 0) this.ChkItemsBox.SelectedIndex -= 7;
            }
        }

        private void txtDM_Leave(object sender, EventArgs e)
        {
            txtDM.Text = "<拼音码>";
        }

        private void txtDM_Enter(object sender, EventArgs e)
        {
            txtDM.Text = "";
        }
        //CT选择
        private void chkBox_CheckedChanged(object sender, EventArgs e)
        {
            DataTable tempTb = JcItems.Copy();
            string str = "", str1 = "", str2 = "", str3 = "";
            if (chbox2.Checked == true) str1 = "order_name like '%平扫%' ";
            if (chbox3.Checked == true) str2 = "order_name like '%直接增强%' ";
            if (chbox4.Checked == true) str3 = "order_name like '%平扫＋增强%'";
            str = str1;
            if (str == "") str = str2;
            else if (str2 != "") str += "or " + str2;
            if (str == "") str = str3;
            else if (str3 != "") str += "or " + str3;
            dr = tempTb.Select(str);
            ChkItemsBox.Items.Clear();
            HIS.Model.ZY_DOC_ORDERRECORD record = null;
            if (dr == null)
            {
                return;
            }
            for (int i = 0; i < dr.Length; i++)
            {
                record = new HIS.Model.ZY_DOC_ORDERRECORD();
                record.ORDER_CONTENT = XcConvert.IsNull(dr[i]["order_name"].ToString(), "");
                record.ORDER_DOC = Convert.ToInt32(_currentUser.EmployeeID);
                record.ITEM_TYPE = Convert.ToInt32(dr[i]["order_type"]);
                record.ORDITEM_ID = Convert.ToInt32(dr[i]["order_id"]);
                record.EXEC_DEPT = Convert.ToInt32(dr[i]["dept_id"]);
                record.ORDER_USAGE = XcConvert.IsNull(dr[i]["default_usage"].ToString(), "");
                record.ITEM_CODE = XcConvert.IsNull(dr[i]["statitem_code"].ToString(), "");
                record.ORDER_PRICE = Convert.ToDecimal(XcConvert.IsNull(dr[i]["price"].ToString().Trim(), "0"));
                record.SEVERS_ID = Convert.ToInt32(dr[i]["item_id"]);
                record.UNIT = XcConvert.IsNull(dr[i]["order_unit"].ToString(), "");
                record.ORDER_SPEC = XcConvert.IsNull(dr[i]["py_code"].ToString(), "");               
                this.ChkItemsBox.Items.Add(record);
            }
        }
        #endregion

        #region 申请单查询与检查结果
        //按时间查询检查申请
        private void btnFind_Click(object sender, EventArgs e)
        {
            DateTime? Bdate = null;
            DateTime? Edate = null;
            Bdate = this.dtBegin.Value;
            Edate = this.dtend.Value;
            DataTable items = Controller.FindOrders(HIS.ZYDoc_BLL.MediApply.MediType.检查,Bdate,Edate);
            decimal sum = 0;
            for (int i = 0; i < items.Rows.Count; i++)
            {
                sum = sum + Convert.ToDecimal(items.Rows[i]["检查费"].ToString().Trim());
            }
            this.lbTotalFee.Text = sum.ToString();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = items;         
        }

        //与PACS接口，查看检查报告结果
        private void btnResult_Click(object sender, EventArgs e)
        {
            if (dataGridView1 == null || dataGridView1.Rows.Count == 0 || dataGridView1.CurrentCell == null)
            {
                return;
            }
            DataTable dt = (DataTable)dataGridView1.DataSource;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            if (dt.Rows[rowindex]["医嘱状态"].ToString() != "已生成报告")
            {
                MessageBox.Show("此项检查还没有生成报告");
                return;
            }
            string orderid = dt.Rows[rowindex]["ID"].ToString();
            string patid = _zypatlist.PatID.ToString();
            StringBuilder cPaitentID = new StringBuilder(patid);
            StringBuilder cReqNum = new StringBuilder(orderid);
            string filePath = Constant.ApplicationDirectory + "//Buffer//" + "Test.bmp";
            Bitmap image;
            try
            {
                if (hyGetPACSReportView(cPaitentID, cReqNum, filePath))
                {
                    image = new Bitmap(filePath);
                    HIS_ZYDocManager.日常业务.ImageReport imagereport = new ImageReport(image);
                    imagereport.ShowDialog();
                    image.Dispose();
                }
            }
            catch
            { }
        }

        private void btnPhoto_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            string orderid = dt.Rows[rowindex]["ID"].ToString();
            string id = _zypatlist.PatID.ToString();
            StringBuilder cPaitentID = new StringBuilder(id);
            StringBuilder cReqNum = new StringBuilder(orderid);
            try
            {
                hyOpenPACSImageView(cPaitentID, cReqNum);
            }
            catch
            { }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1 == null || dataGridView1.Rows.Count == 0 || dataGridView1.CurrentCell == null)
            {
                return;
            }
            if (!Controller.ConnectPacs())
            {
                return;
            }
            DataTable dt = (DataTable)dataGridView1.DataSource;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            if (dt.Rows[rowindex]["医嘱状态"].ToString() != "已生成报告")
            {
                MessageBox.Show("此项检查还没有生成报告");
                return;
            }          
            string orderid = dt.Rows[rowindex]["ID"].ToString();
            string patid = _zypatlist.PatID.ToString();
            StringBuilder cPaitentID = new StringBuilder(patid);
            StringBuilder cReqNum = new StringBuilder(orderid);
            string filePath = Constant.ApplicationDirectory + "//Buffer//" + "Test.bmp";
            Bitmap image;
            try
            {
                if (hyGetPACSReportView(cPaitentID, cReqNum, filePath))
                {
                    image = new Bitmap(filePath);
                    HIS_ZYDocManager.日常业务.ImageReport imagereport = new ImageReport(image);
                    imagereport.ShowDialog();
                    image.Dispose();
                }
            }
            catch
            {
 
            }
        }
        #endregion

        private void BtnBrush_Click(object sender, EventArgs e)
        {
            Controller = new HIS_ZYDocManager.Action.FrmMediApplyController(this, HIS.ZYDoc_BLL.MediApply.MediType.检查);
            Controller.GetPatlist();
            Controller.getDept();
        }

     
        
    }
}