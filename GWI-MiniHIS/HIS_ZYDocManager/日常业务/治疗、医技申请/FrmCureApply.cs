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

namespace HIS_ZYDocManager.日常业务
{
    public partial class FrmCureApply : Form, Action.IFrmMediApplyView
    {
        public FrmCureApply()
        {
            InitializeComponent();
        }
        private User _currentUser;
        private Deptment _currentDept;
        private Action.FrmMediApplyController Controller;
        HIS.Model.ZY_PatList _zypatlist;
        private int deptId;       
        private decimal pr = 0; 
        public FrmCureApply(HIS.Model.ZY_PatList _patlist, long userid, long deptid)
        {
            InitializeComponent();
            _currentUser = new User(userid);
            _currentDept = new Deptment(deptid);
            _zypatlist = _patlist;
            Controller = new HIS_ZYDocManager.Action.FrmMediApplyController(this, HIS.ZYDoc_BLL.MediApply.MediType.治疗);
            Controller.GetPatlist();
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
      
        private void FrmCureApply_Load(object sender, EventArgs e)
        {
            Controller.getDept();
        }

        #region 事件
        //科室选择
        private void cbDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            deptId = Convert.ToInt32(this.cbDept.SelectedValue);
            DataTable JcItems = Controller.Items(HIS.ZYDoc_BLL.MediApply.MediType.治疗, deptId, 0);
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
                record.UNIT = XcConvert.IsNull(JcItems.Rows[i]["order_unit"].ToString(), "");
                record.ORDER_USAGE = XcConvert.IsNull(JcItems.Rows[i]["default_usage"].ToString(), "");              
                record.ITEM_CODE = XcConvert.IsNull(JcItems.Rows[i]["statitem_code"].ToString(), "");
                record.ORDER_PRICE = Convert.ToDecimal(XcConvert.IsNull(JcItems.Rows[i]["price"].ToString().Trim(),"0"));
                record.SEVERS_ID = Convert.ToInt32(JcItems.Rows[i]["item_id"]);
                record.MEMO = XcConvert.IsNull(JcItems.Rows[i]["BZ"].ToString(), "");
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
        // 选择项目
        private void ChkItemsBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue != 13)
            {
                return;
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
        //显示治疗费
        private void ChkItemsBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            #region 删除多余的项
            bool bb = false;
            for (int j = 0; j < this.listViewSel.Items.Count; j++)
            {
                bb = false;
                for (int i = 0; i < ChkItemsBox.CheckedItems.Count; i++)
                {
                    if (this.listViewSel.Items[j].SubItems[1].Text == ChkItemsBox.CheckedItems[i].ToString())
                    {
                        bb = true;
                    }
                }
                if (bb == false) //没有该项就移除，并更改后面的项值（序号+1）
                {
                    pr -= Convert.ToDecimal(this.listViewSel.Items[j].SubItems[2].Text) * Convert.ToInt32(this.listViewSel.Items[j].SubItems[3].Text);
                    this.listViewSel.Items[j].Remove();
                    for (int g = j; g < this.listViewSel.Items.Count; g++)
                    {
                        this.listViewSel.Items[g].Text = Convert.ToString((g + 1));
                    }
                }
            }
            #endregion
            int h = this.listViewSel.Items.Count + 1;
            bb = true;
            decimal p = 0;
            for (int i = 0; i <= ChkItemsBox.CheckedItems.Count - 1; i++)
            {
                p = ((HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i]).ORDER_PRICE;
                for (int j = 0; j < this.listViewSel.Items.Count; j++)
                {
                    bb = false;
                    if (((HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i]).ORDER_CONTENT.ToString() != this.listViewSel.Items[j].SubItems[1].Text)
                    {
                        bb = true;
                    }
                    else
                    {
                        break;
                    }
                }
                if (bb == true)//没有该项就添加
                {
                    System.Windows.Forms.ListViewItem litem = new ListViewItem();
                    litem.Text = h.ToString();
                    h++;
                    litem.SubItems.Add(((HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i]).ORDER_CONTENT.ToString());
                    litem.SubItems.Add(p.ToString());
                    litem.SubItems.Add("1");
                    this.listViewSel.Items.Add(litem);
                    pr += p;
                }
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

        private void listViewSel_SelectedIndexChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.listViewSel.Items.Count; i++)
            {
                this.listViewSel.Items[i].BackColor = Color.WhiteSmoke;
            }
            for (int j = 0; j < this.ChkItemsBox.Items.Count; j++)
            {
                if (this.listViewSel.SelectedItems.Count != 0)
                {
                    this.numUD.Value = Convert.ToDecimal(this.listViewSel.SelectedItems[0].SubItems[3].Text);
                    if (this.listViewSel.SelectedItems[0].SubItems[1].Text == ((HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[j]).ORDER_CONTENT.ToString())
                    {
                        this.ChkItemsBox.SelectedIndex = j;
                        return;
                    }
                }
            }
        }
        //提交
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
                MessageBox.Show("没有选择治疗项目！不能申请！", "提示");
                return;
            }
            if (richBrecord.Text.ToString().Trim() == "")
            {
                if (MessageBox.Show("简要病史没写！可以在打印后手工填写。\n你确定要生成医嘱吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }
            }
            else
            {
                if (MessageBox.Show("你确定要生成医嘱吗？", "提示", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                    return;
            }
            List<HIS.Model.ZY_DOC_ORDERRECORD> orders = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            HIS.Model.ZY_DOC_ORDERRECORD record;
            string selitem = "";
            int Num = 1;
            for (int j = 0; j < this.listViewSel.Items.Count; j++)
            {
                selitem = this.listViewSel.Items[j].SubItems[1].Text;
                Num = Convert.ToInt32(this.listViewSel.Items[j].SubItems[3].Text);
                for (int i = 0; i <= ChkItemsBox.CheckedItems.Count - 1; i++)
                {
                    if ((((HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i]).ORDER_CONTENT.ToString().Trim()) == selitem.Trim())
                    {
                        int YY = selitem.IndexOf("【", 0);
                        if (YY > 0)
                        {
                            selitem = selitem.Substring(0, YY);
                        }
                        record = (HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i];  
                        record.ORDER_BDATE = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;                      
                        record.OPRERATOR = Convert.ToInt32(_currentUser.EmployeeID);                      
                        record.AMOUNT = Num;                      
                        record.PRES_DEPTID = Convert.ToInt32(_currentDept.DeptID);
                        record.ORDER_DOC = Convert.ToInt32(_currentUser.EmployeeID);                      
                        orders.Add(record);
                        break;
                    }
                }
            }
            if (Controller.SaveCure(orders)) 
            {
                MessageBox.Show("治疗申请完成!\n生成医嘱成功!");
            }
        }
        //修改治疗次数
        private void numUD_ValueChanged(object sender, EventArgs e)
        {
            if (this.listViewSel.Items.Count == 0)
            {
                return;
            }
            this.listViewSel.SelectedItems[0].SubItems[3].Text = this.numUD.Value.ToString();
            this.listViewSel.SelectedItems[0].BackColor = Color.LightSteelBlue;
            pr = 0;
            for (int i = 0; i < this.listViewSel.Items.Count; i++)
            {
                pr += Convert.ToDecimal(this.listViewSel.Items[i].SubItems[2].Text) * Convert.ToInt32(this.listViewSel.Items[i].SubItems[3].Text);
            }
            lbPrice.Text = "合计 " + pr.ToString() + " 元";
        }

        private void numUD_Enter(object sender, EventArgs e)
        {
            if (this.listViewSel.SelectedItems.Count == 0 && this.listViewSel.Items.Count > 0)
            {
                this.listViewSel.Items[0].Selected = true;
            }
        }
        //打印
        private void btnPrint_Click(object sender, EventArgs e)
        {
            List<HIS.Model.ZY_DOC_ORDERRECORD> records = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            string ApplyName = "";
            if (tabControl1.SelectedIndex == 0)
            {
                records.Clear();
                ApplyName = "";
                for (int i = 0; i <= ChkItemsBox.CheckedItems.Count - 1; i++)
                {
                    HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
                    record = (HIS.Model.ZY_DOC_ORDERRECORD)ChkItemsBox.CheckedItems[i];
                    if (record.ORECORD_A2 == 0)
                    {
                        MessageBox.Show("您还没有提交治疗申请，请先提交，再打印");
                        return;
                    }
                    record.AMOUNT = this.Nums(record.ORDER_CONTENT);
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
                    record.ORDER_CONTENT = dt.Rows[i]["治疗项目"].ToString();
                    record.ORDER_PRICE = Convert.ToDecimal(dt.Rows[i]["治疗费"].ToString().Trim());
                    record.AMOUNT = Convert.ToDecimal(dt.Rows[i]["amount"].ToString().Trim());
                    record.ORDER_CONTENT = dt.Rows[i]["治疗项目"].ToString();
                    records.Add(record);
                }
            }

            try
            {

                DateTime dtime = this.dateTimePicker2.Value;
                string name = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(_currentUser.EmployeeID.ToString());
                string startPath = Application.StartupPath + "\\report\\治疗申请单.grf";
                if (!File.Exists(startPath))
                {
                    MessageBox.Show("报表文件不存在");
                    return;
                }
                Controller.CurePrint(startPath, _zypatlist, records, dtime, name, this.richBrecord.Text.Trim());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
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

        private void txtDM_Enter(object sender, EventArgs e)
        {
            txtDM.Text = "";
        }

        private void txtDM_Leave(object sender, EventArgs e)
        {
            txtDM.Text = "<拼音码>";
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

        //获得治疗申请次数
        private int Nums(string itemname)
        {
            int num = 1;
            for (int j = 0; j < this.listViewSel.Items.Count; j++)
            {
                string selitem = this.listViewSel.Items[j].SubItems[1].Text;
                if (itemname.Trim() == selitem.Trim())
                {
                    num = Convert.ToInt32(this.listViewSel.Items[j].SubItems[3].Text);
                    break;
                }
            }
            return num;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 1)
            {
                this.btnSend.Visible = false;
            }
            else
            {
                this.btnSend.Visible = true;
            }
            if (tabControl1.SelectedIndex == 1)
            {
                DateTime dateNow = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                dtBegin.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 00:00:00");
                dtend.Value = Convert.ToDateTime(dateNow.ToString("yyyy-MM-dd") + " 23:59:59");
            }
        }
        //治疗申请查询
        private void btnFind_Click(object sender, EventArgs e)
        {
            DateTime? Bdate = null;
            DateTime? Edate = null;
            Bdate = this.dtBegin.Value;
            Edate = this.dtend.Value;
            DataTable items = Controller.FindOrders(HIS.ZYDoc_BLL.MediApply.MediType.治疗, Bdate, Edate);
            decimal sum = 0;
            for (int i = 0; i < items.Rows.Count; i++)
            {
                sum = sum + Convert.ToDecimal(items.Rows[i]["治疗费"].ToString().Trim()) * Convert.ToDecimal(items.Rows[i]["amount"].ToString().Trim());
            }
            this.lbTotalFee.Text = sum.ToString();
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.DataSource = items;
        }

        private void BtnBrush_Click(object sender, EventArgs e)
        {
            Controller = new HIS_ZYDocManager.Action.FrmMediApplyController(this, HIS.ZYDoc_BLL.MediApply.MediType.治疗);
            Controller.GetPatlist();
            Controller.getDept();
        }  
              
    }
}
