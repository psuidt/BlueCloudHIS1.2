/*
 *update zenghao [20100506.01] 输入一个错误住院号后，输入正确住院号也提示“未将对象引用到实例”
 * 
 * 
 * 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL;
using HIS.ZY_BLL.ObjectModel.CostManager;
using HIS.ZY_BLL.ObjectModel;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS_ZYManager
{
    public partial class FrmCharge : ZYBaseFrom
    {
        ZY_ChargeList zy_ChargeList = null;
        public FrmCharge()
        {
            InitializeComponent();
            base.HIS_DoubleClick += new lvPatList_DoubleClickEvent(FrmCharge_HIS_DoubleClick);
            
            this.tbInpatNo.Focus();
            this.lbExtFee.Text = "0";
            this.lbChargeTolFee.Text = "0";
            this.lbCoseTolFee.Text = "0";
            this.cbType.SelectedIndex = 0;

            zy_ChargeList = new ZY_ChargeList();
        }

        public FrmCharge(ZY_PatList zypat,string titile)
        {
            InitializeComponent();
            this.cbType.SelectedIndex = 0;
            this.tbfee.Focus();
            base.HIS_DoubleClick += new lvPatList_DoubleClickEvent(FrmCharge_HIS_DoubleClick);

            this.Text = titile;
            base.zy_PatList = zypat;

            //实例化预交金对象
            zy_ChargeList = new ZY_ChargeList();
            zy_ChargeList.PatListID = base.zy_PatList.PatListID;
        }

        //双击病人列表
        private void FrmCharge_HIS_DoubleClick(object sender, EventArgs e)
        {
            zy_ChargeList.PatListID = base.zy_PatList.PatListID;
            this.BindDataGrid();
        }
        //绑定预交金
        public void BindDataGrid()
        {
            this.tbInpatNo.Text = base.zy_PatList.CureNo;
            this.tbpatName.Text = base.zy_PatList.patientInfo.PatName;
            this.tbpatDept.Text = base.zy_PatList.CurrDeptCode.Trim() == "" ?
                BaseNameFactory.GetName(baseNameType.科室名称,base.zy_PatList.CureDeptCode)
                : BaseNameFactory.GetName(baseNameType.科室名称,base.zy_PatList.CurrDeptCode);//当前科室代码
            
            this.tbbedno.Text = base.zy_PatList.BedCode;
            DataTable dt = zy_ChargeList.GetPatChargeList();
            decimal dec = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dec += Convert.ToDecimal(dt.Rows[i]["Total_Fee"]);
            }
            this.label9.Text = dec.ToString();
            IcostManager icM = ObjectFactory.GetObject<IcostManager>(typeof(ZY_CostMaster));
            icM.PatListID = zy_PatList.PatListID;
            PatFee patFee = icM.GetPatFee();
            this.lbChargeTolFee.Text = patFee.chargeFee.ToString();
            this.lbCoseTolFee.Text = patFee.costFee.ToString();
            this.lbExtFee.Text = patFee.surplusFee.ToString();

            this.dgBill.AutoGenerateColumns = false;
            this.dgBill.DataSource = dt;

            this.dgBill.SelectRow(dt.Rows.Count - 1);
        }
        
        //收费
        private void toolsbCost_Click(object sender, EventArgs e)
        {
            if (this.tbfee.Text.Trim() == "" || Convert.ToDecimal(this.tbfee.Text.Trim())<=0)
            {
                MessageBox.Show("请正确输入金额！");
                this.tbfee.Focus();
                this.tbfee.SelectAll();
                return;
            }
            if (base.zy_PatList == null || base.zy_PatList.PatType.Trim() == "3" || base.zy_PatList.PatType.Trim() == "4" || base.zy_PatList.PatType.Trim() == "5" )
            {
                MessageBox.Show("请正确指定一个病人或该病人已经出区！");
                this.tbInpatNo.Focus();
                return;
            }
            if (base.zy_PatList != null)
            {
                if (MessageBox.Show("确定要该病人收费[" + this.tbfee.Text + "]吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    zy_ChargeList = new ZY_ChargeList();
                    zy_ChargeList.PatListID = base.zy_PatList.PatListID;

                    zy_ChargeList.CureNo = base.zy_PatList.CureNo;
                    zy_ChargeList.BillNo = zy_ChargeList.GetBillNo(XcDate.ServerDateTime);
                    zy_ChargeList.ChargeCode = base.currentUser.EmployeeID.ToString();//?
                    zy_ChargeList.CostDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    zy_ChargeList.Delete_Flag = 0;
                    zy_ChargeList.FeeType = this.cbType.SelectedIndex;
                    zy_ChargeList.PatID = base.zy_PatList.PatID;
                    zy_ChargeList.PatListID = base.zy_PatList.PatListID;
                    zy_ChargeList.Record_Flag = 0;
                    zy_ChargeList.Total_Fee = Convert.ToDecimal(this.tbfee.Text);

                    zy_ChargeList.Add();

                    MessageBox.Show("收费成功！");
                    this.tbfee.Text = "";
                    this.BindDataGrid();
                }
            }
        }
        //允许输入数字
        private void tbfee_TextChanged(object sender, EventArgs e)
        {           
            if (!XcConvert.IsNumeric(this.tbfee.Text))
            {
                this.tbfee.Text = "";
            }
        }
        //根据住院号搜索病人信息
        // update zenghao [20100506.0.01]
        private void tbInpatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                //this.ToolControls_Enabled(RegType.修改);
                ZY_PatList zyplist = zy_PatList.GetPatInfo(this.tbInpatNo.Text);

                if (zyplist != null)
                {
                    base.zy_PatList = zyplist;
                    zy_ChargeList.PatListID = base.zy_PatList.PatListID;
                    this.BindDataGrid();
                }
                else
                {
                    MessageBox.Show("您输入的住院号病人不存在！");
                    this.tbInpatNo.Text = "0";
                }
            }
        }
        //作废
        private void toolSBDel_Click(object sender, EventArgs e)
        {
            if (base.zy_PatList == null || base.zy_PatList.PatType.Trim() == "3" || base.zy_PatList.PatType.Trim() == "4" || base.zy_PatList.PatType.Trim() == "5") return;
            if (((DataTable)this.dgBill.DataSource).Rows.Count == 0 || this.dgBill.CurrentCell==null) return;
            if (Convert.ToInt32(((DataTable)this.dgBill.DataSource).DefaultView.ToTable().Rows[this.dgBill.CurrentCell.RowIndex]["Record_Flag"]) != 0 || Convert.ToInt32(((DataTable)this.dgBill.DataSource).DefaultView.ToTable().Rows[this.dgBill.CurrentCell.RowIndex]["Delete_Flag"]) != 0)
            {
                MessageBox.Show("此条记录已做废或已结算，不能操作！");
                return;
            }
            if (((DataTable)this.dgBill.DataSource).DefaultView.ToTable().Rows[this.dgBill.CurrentCell.RowIndex]["AccountUserName"].ToString() !="")
            {
                MessageBox.Show("此条记录已经交帐，不能作废！");
                return;
            }
            if (MessageBox.Show("确定要作废吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                int chargeID = Convert.ToInt32(((DataTable)this.dgBill.DataSource).Rows[this.dgBill.CurrentCell.RowIndex]["ChargeListID"]);
                zy_ChargeList.ChargeListID = chargeID;
                zy_ChargeList.DelChargeList(base.currentUser.EmployeeID.ToString());// eList().DelChargeList(zyChargeList, _zyChargeList);
                this.BindDataGrid();
            }
        }
        //退费
        private void toolSBBack_Click(object sender, EventArgs e)
        {
            if (base.zy_PatList == null || base.zy_PatList.PatType.Trim() == "3" || base.zy_PatList.PatType.Trim() == "4" || base.zy_PatList.PatType.Trim() == "5") return;
            if (((DataTable)this.dgBill.DataSource).Rows.Count == 0 || this.dgBill.CurrentCell == null) return;
            if (Convert.ToInt32(((DataTable)this.dgBill.DataSource).DefaultView.ToTable().Rows[this.dgBill.CurrentCell.RowIndex]["Record_Flag"]) != 0 || Convert.ToInt32(((DataTable)this.dgBill.DataSource).DefaultView.ToTable().Rows[this.dgBill.CurrentCell.RowIndex]["Delete_Flag"]) != 0)
            {
                MessageBox.Show("此条记录已做废或已结算，不能操作！");
                return;
            }

            if (MessageBox.Show("确定要退费吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {

                if (HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("004") == 0 && zy_ChargeList.ChargeCode != base.currentUser.EmployeeID.ToString())
                {
                    MessageBox.Show("对不起，此笔费用您不能操作!");
                    return;
                }
                int chargeID = Convert.ToInt32(((DataTable)this.dgBill.DataSource).Rows[this.dgBill.CurrentCell.RowIndex]["ChargeListID"]);
                zy_ChargeList.ChargeListID = chargeID;

                zy_ChargeList.BackChargeList(base.currentUser.EmployeeID.ToString());
                this.BindDataGrid();
            }
        }
        //窗体快捷键
        private void FrmCharge_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:
                   
                    break;
                case Keys.F1:	//帮助

                    break;
                case Keys.F2:	//收费
                    toolsbCost_Click(null, null);
                    break;
                case Keys.F3:	//作废
                    toolSBDel_Click(null, null);
                    break;
                case Keys.F4:	//退费
                    toolSBBack_Click(null, null);
                    break;
                case Keys.F5:	//打印
                    toolSBPrint_Click(null, null);
                    break; 
                case (Keys.A|Keys.Alt):
                    this.tbfee.Focus();
                    break;
                case (Keys.Z|Keys.Alt):
                    this.tbInpatNo.Focus();
                    break;
              
                default:
                    break;
            }
        }
        //打印
        private void toolSBPrint_Click(object sender, EventArgs e)
        {
            if (((DataTable)this.dgBill.DataSource).Rows.Count == 0) return;
            if (Convert.ToInt32(((DataTable)this.dgBill.DataSource).DefaultView.ToTable().Rows[this.dgBill.CurrentCell.RowIndex]["Record_Flag"]) != 0 || Convert.ToInt32(((DataTable)this.dgBill.DataSource).DefaultView.ToTable().Rows[this.dgBill.CurrentCell.RowIndex]["Delete_Flag"]) != 0)
            {
                MessageBox.Show("此条是做废记录或已经结算，不能打印！");
                return;
            }
            if (MessageBox.Show("确定要打印吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
            {
                zy_ChargeList = (ZY_ChargeList)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(((DataTable)this.dgBill.DataSource).Copy(), this.dgBill.CurrentCell.RowIndex, zy_ChargeList);

                grproLib.GridppReport Report = new grproLib.GridppReport();
                string reportPath = Constant.ApplicationDirectory + "\\report\\住院收费收据.grf";
                Report.LoadFromFile(reportPath);
                GWI_DesReport.HisReport.FillRecordToReport(Report, zy_ChargeList);
                Report.ParameterByName("PatName").AsString = zy_PatList.patientInfo.PatName;
                Report.ParameterByName("DeptName").AsString = this.tbpatDept.Text;
                Report.ParameterByName("BedNO").AsString = zy_PatList.BedCode;
                Report.ParameterByName("Total_Fee1").AsString = zy_ChargeList.Total_Fee.ToString();
                Report.ParameterByName("PrintPerson").AsString = base.currentUser.Name;
                Report.ParameterByName("WorkName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;
                Report.Printer.PrinterName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport("住院收费收据.grf");
                if (Report.Printer.PrinterName == null || Report.Printer.PrinterName == "")
                {
                    MessageBox.Show("请先设置好此报表的打印机！", "询问", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (this.printType.Checked)
                {
                    Report.Print(false);
                }
                else
                {
                    Report.PrintPreview(false);
                }
            }
        }
        //双击打印
        private void dgBill_DoubleClick(object sender, EventArgs e)
        {
            toolSBPrint_Click(null, null);
        }
        //内容改变
        private void dgBill_CurrentCellChanged(object sender, EventArgs e)
        {
            if (this.dgBill.CurrentCell != null)
            {
                zy_ChargeList = (ZY_ChargeList)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(((DataTable)this.dgBill.DataSource).Copy(), this.dgBill.CurrentCell.RowIndex, zy_ChargeList);
                if (zy_ChargeList.AccountID == 0 && zy_ChargeList.ChargeCode == base.currentUser.EmployeeID.ToString())
                {
                    this.toolSBDel.Enabled = true;
                    this.toolSBBack.Enabled = false;
                }
                else
                {
                    this.toolSBDel.Enabled = false;
                    this.toolSBBack.Enabled = true;
                }
            }
        }
        //窗体加载事件
        private void FrmCharge_Load(object sender, EventArgs e)
        {
            //this.BindDataGrid();
        }
        //关闭
        private void toolSBClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
    }
}
