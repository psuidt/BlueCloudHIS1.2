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
using System.Runtime.InteropServices;//用到DllImport时候要引入的包


namespace HIS_ZYDocManager.日常业务
{
    public partial class FrmTestApply : Form, Action.IFrmMediApplyView
    {
        public FrmTestApply()
        {
            InitializeComponent();
        }
        private User _currentUser;
        private Deptment _currentDept;
        private Action.FrmMediApplyController Controller;
        HIS.Model.ZY_PatList _zypatlist;
        private int deptId;
        private int medicalClass;
        private decimal pr = 0;
        private bool IsChange = true;
        #region LIS接口动态库引入
        [DllImport("PlugInVisit.dll")]
        extern static bool hyInitHinstance(IntPtr Handle);
        [DllImport("PlugInVisit.dll")]
        extern static bool hyGetLISReportView(StringBuilder cPaitentID, StringBuilder cReqNum, string cFilePath);
        [DllImport("PlugInVisit.dll")]
        extern static bool hyFreeHinstance();
        #endregion
        public FrmTestApply(HIS.Model.ZY_PatList _patlist,long userid,long deptid)
        {
            InitializeComponent();
            _currentUser = new User(userid);
            _currentDept = new Deptment(deptid);
            _zypatlist = _patlist;
            Controller = new HIS_ZYDocManager.Action.FrmMediApplyController(this, HIS.ZYDoc_BLL.MediApply.MediType.检验);
            Controller.GetPatlist();
            if (Controller.ConnectLis())
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
        private void FrmTestApply_Load(object sender, EventArgs e)
        {
            Controller.getDept();
            this.cbSample.DataSource = Controller.Sample();
            this.cbSample.DisplayMember = "name";
            this.cbSample.ValueMember = "id";
            this.cbExplain.DataSource = Controller.Param();
            this.cbExplain.DisplayMember = "name";
            this.cbExplain.ValueMember = "id";
            this.cbExplain.Text = "";
        }
        private void FrmTestApply_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Controller.ConnectLis())
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
                DataRow[] rows = _dataSet.Tables["Type"].Select("dept_id = " + this.cbDept.SelectedValue.ToString() + "");
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

        #region 事件
        //科室选择
        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbExplain.Text = "";
            if (!this.IsChange)//不允许改变
            {
                this.IsChange = true;
                return;
            }
            if (cbDept.SelectedIndex >= 0)
            {
                Controller.BindData();
            }
        }
        //类型选择
        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbExplain.Text = "";
            if (!this.IsChange)//不允许改变
            {
                this.IsChange = true;
                return;
            }
            this.deptId = Convert.ToInt32(this.cbDept.SelectedValue);
            this.medicalClass = Convert.ToInt32(this.cbType.SelectedValue);
            DataTable JcItems = Controller.Items(HIS.ZYDoc_BLL.MediApply.MediType.检验, deptId, medicalClass);
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
                record.ORDER_PRICE = Convert.ToDecimal(JcItems.Rows[i]["price"].ToString().Trim());
                record.SEVERS_ID = Convert.ToInt32(JcItems.Rows[i]["item_id"]);
                record.MEMO = XcConvert.IsNull(JcItems.Rows[i]["BZ"].ToString(), "");
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
        }
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
            cbExplain.Text = "";           
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
          
            pr = 0;
            for (int i = 0; i <= ChkItemsBox.CheckedItems.Count - 1; i++)
            {

                p = ((HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i]).ORDER_PRICE;
                if (p.ToString() == "")
                {
                    continue;
                }
                pr += p;
                this.txtbz.Text = ((HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i]).MEMO;
                
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
        //选择项目
        private void ChkItemsBox_MouseDown(object sender, MouseEventArgs e)
        {
            cbExplain.Text = "";     
            lbPrice.Text = "0.0 元";
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
                MessageBox.Show("没有选择检验项目！不能申请！", "提示");
                return;
            }
            if (MessageBox.Show("你确定要生成医嘱吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                return;
            }
            List<HIS.Model.ZY_DOC_ORDERRECORD> orders = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            List<HIS.Model.ZY_DOC_TESTAPPLY> applys = new List<HIS.Model.ZY_DOC_TESTAPPLY>();
            HIS.Model.ZY_DOC_ORDERRECORD record;
            HIS.Model.ZY_DOC_TESTAPPLY apply;          
            for (int i = 0; i <= ChkItemsBox.CheckedItems.Count - 1; i++)
            {
                record = (HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i];                        
                record.ORDER_BDATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;               
                record.OPRERATOR = Convert.ToInt32(_currentUser.EmployeeID);              
                record.PRES_DEPTID =Convert.ToInt32(_currentDept.DeptID);
                record.ORDER_DOC =Convert.ToInt32(_currentUser.EmployeeID);              
                orders.Add(record);

                apply = new HIS.Model.ZY_DOC_TESTAPPLY();  
                apply.SAMPLE = this.cbSample.Text;             
                apply.EXPLAIN = this.cbExplain.Text;           
                applys.Add(apply);
            }
            cbExplain.Text = "";
            if (Controller.SaveTest(orders,applys))
            {
                MessageBox.Show("检查申请完成!\n生成医嘱成功!");               
            }          
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                this.btnSend.Visible = false;
                if (Controller.ConnectLis())
                {
                    this.btnResult.Visible = true;
                    // this.btnPhoto.Visible = true;
                }
                else
                {
                    this.btnResult.Visible = false;
                    // this.btnPhoto.Visible = false;
                }

            }
            else
            {
               this.btnResult.Visible = false;
                this.btnSend.Visible = true;
               this.btnPhoto.Visible = false;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                
                DateTime dateNow = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                dtBegin.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 00:00:00");
                dtend.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 23:59:59");
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            string ApplyName = "";
            List<HIS.Model.ZY_DOC_ORDERRECORD> records = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            if (tabControl1.SelectedIndex == 0)
            {
                records.Clear();
                ApplyName = this.cbType.Text.Trim();
                if (ChkItemsBox.CheckedItems.Count == 0)
                {
                    MessageBox.Show("请选择项目");
                    return;
                }
                for (int i = 0; i <= ChkItemsBox.CheckedItems.Count - 1; i++)
                {
                    HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
                    record = (HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i];
                    if (record.ORECORD_A2 == 0)
                    {
                        MessageBox.Show("您还没有提交检验申请，请先提交，再打印");
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
                    DataTable dt = (DataTable)dataGridView1.DataSource;
                    int i = dataGridView1.CurrentCell.RowIndex;
                    int orderid = Convert.ToInt32(dt.Rows[i]["orditem_id"].ToString());
                    ApplyName = Controller.GetItemName(orderid).Trim();
                    records.Clear();
                    HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
                    record = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, record);
                    record.ORDER_PRICE = Convert.ToDecimal(dt.Rows[i]["检查费"].ToString());
                    record.ORDER_CONTENT = dt.Rows[i]["检查项目"].ToString();
                    records.Add(record);
                }
            }
            try
            {
                DateTime dtime = this.dateTimePicker2.Value;
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
                    Controller.TestPrint(startPath, _zypatlist, records, dtime, name, cbSample.Text.Trim(), deptname, this.tbDiag.Text);
                }
                else
                {
                    Controller.TestPrint(startPath, _zypatlist, records, dtime, name, "", deptname, "");
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

        private void txtDM_Leave(object sender, EventArgs e)
        {
            txtDM.Text = "<拼音码>";
        }

        private void txtDM_Enter(object sender, EventArgs e)
        {
            txtDM.Text = "";
        }

        private void txtDM_KeyDown(object sender, KeyEventArgs e)
        {
            int sel = this.ChkItemsBox.SelectedIndex;
            if (e.KeyValue == 13 && this.ChkItemsBox.SelectedItems.Count != 0)
            {              
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
        #endregion

        #region  LIS接口
        //与LIS接口，查看检验报告单结果
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
                MessageBox.Show("此项检验还没有生成报告");
                return;
            }
            string orderid = dt.Rows[rowindex]["ID"].ToString();
            string patid = _zypatlist.CureNo.ToString();
            StringBuilder cPaitentID = new StringBuilder(patid);
            StringBuilder cReqNum = new StringBuilder(orderid);
            string filePath = Constant.ApplicationDirectory + "//Buffer//" + "Test.bmp";
            Bitmap image;
            try
            {
                if (hyGetLISReportView(cPaitentID, cReqNum, filePath))
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

        private void btnFind_Click(object sender, EventArgs e)
        {
            DateTime? Bdate = null;
            DateTime? Edate = null;
            Bdate = this.dtBegin.Value;
            Edate = this.dtend.Value;
            DataTable items = Controller.FindOrders(HIS.ZYDoc_BLL.MediApply.MediType.检验,Bdate,Edate);
            decimal sum = 0;
            for (int i = 0; i < items.Rows.Count; i++)
            {
                sum = sum + Convert.ToDecimal(items.Rows[i]["检查费"].ToString().Trim());
            }
            this.lbTotalFee.Text = sum.ToString();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = items;

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridView1 == null || dataGridView1.Rows.Count == 0 || dataGridView1.CurrentCell == null)
            {
                return;
            }
            if (!Controller.ConnectLis())
            {
                return;
            }
            DataTable dt = (DataTable)dataGridView1.DataSource;
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            if (dt.Rows[rowindex]["医嘱状态"].ToString() != "已生成报告")
            {
                MessageBox.Show("此项检验还没有生成报告");
                return;
            }
            string orderid = dt.Rows[rowindex]["ID"].ToString();
            string patid = _zypatlist.CureNo.ToString();
            StringBuilder cPaitentID = new StringBuilder(patid);
            StringBuilder cReqNum = new StringBuilder(orderid);
            string filePath = Constant.ApplicationDirectory + "//Buffer//" + "Test.bmp";
            Bitmap image;
            try
            {
                if (hyGetLISReportView(cPaitentID, cReqNum, filePath))
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
        #endregion

        private void BtnBrush_Click(object sender, EventArgs e)
        {
            Controller = new HIS_ZYDocManager.Action.FrmMediApplyController(this,HIS.ZYDoc_BLL.MediApply.MediType.检验);
            Controller.GetPatlist();
            Controller.getDept();
        }
    }
}
