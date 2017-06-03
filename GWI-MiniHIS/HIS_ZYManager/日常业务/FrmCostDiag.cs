using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS_ZYManager.InvoiceManager;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS_ZYManager
{
    public partial class FrmCostDiag : GWI.HIS.Windows.Controls.BaseForm, Action.IFrmCostDiagView
    {

        private Action.FrmCostController controller;
        Action.CostType costType;
        public bool isDiag = false;
        //是否使用系统发票
        int zyConfig005;

        // 结算类型(1中途,2出院,3欠费)
        public FrmCostDiag(Action.CostType _costType, Action.FrmCostController _controller)
        {
            InitializeComponent();

            costType = _costType;
            controller = _controller;
            controller.IfrmCostDiagView = this;

            zyConfig005 = HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("005");
        }

        //金额改变
        private void tbFee_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (costType == HIS_ZYManager.Action.CostType.欠费结算)
                {
                    decimal decPos = Convert.ToDecimal(this.tbpos.Text.Trim());
                    decimal decFee = Convert.ToDecimal(this.tbFee.Text.Trim());
                    if (!HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNumeric(this.tbpos.Text.Trim()) || decPos < 0 || (decFee + decPos) > _patFee.receiveFee)
                    {
                        this.tbFee.Text = "0";
                        this.tbFee.SelectAll();
                    }
                    decPos = Convert.ToDecimal(this.tbpos.Text.Trim());
                    decFee = Convert.ToDecimal(this.tbFee.Text.Trim());
                    this.tb_extra.Text = (_patFee.receiveFee - decPos - decFee).ToString("0.00");
                }
            }
            catch { }
        }
        //pos改变
        private void tbpos_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (costType == HIS_ZYManager.Action.CostType.出院结算)
                {
                    if (_patFee.receiveFee > 0)
                    {
                        decimal decPos = Convert.ToDecimal(this.tbpos.Text.Trim());
                        decimal decFee = Convert.ToDecimal(this.tbFee.Text.Trim());
                        if (!HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNumeric(this.tbpos.Text.Trim()) || decPos < 0 || decPos > _patFee.receiveFee)
                        {
                            this.tbpos.Text = "0";
                            this.tbpos.SelectAll();
                        }
                        decPos = Convert.ToDecimal(this.tbpos.Text.Trim());
                        decFee = Convert.ToDecimal(this.tbFee.Text.Trim());
                        this.tbFee.Text = (_patFee.receiveFee - decPos).ToString("0.00");
                    }
                }
                else if (costType == HIS_ZYManager.Action.CostType.欠费结算)
                {
                    decimal decPos = Convert.ToDecimal(this.tbpos.Text.Trim());
                    decimal decFee = Convert.ToDecimal(this.tbFee.Text.Trim());
                    if (!HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNumeric(this.tbpos.Text.Trim()) || decPos < 0 || (decFee + decPos) > _patFee.receiveFee)
                    {
                        this.tbpos.Text = "0";
                        this.tbpos.SelectAll();
                    }
                    decPos = Convert.ToDecimal(this.tbpos.Text.Trim());
                    decFee = Convert.ToDecimal(this.tbFee.Text.Trim());
                    this.tb_extra.Text = (_patFee.receiveFee - decFee - decPos).ToString("0.00");
                }
            }
            catch { }
        }
        //出院日期改变
        private void dtpOutDate_ValueChanged(object sender, EventArgs e)
        {
            TimeSpan ts = this.dtpOutDate.Value - _zyPatList.CureDate;
            this.tbNum.Text = ts.Days.ToString();
        }
        
        //调整发票号
        private void button1_Click(object sender, EventArgs e)
        {
            FrmAdjustInvoiceNo frmAdj = new FrmAdjustInvoiceNo(Convert.ToInt32(controller.user.EmployeeID));
            if (frmAdj.ShowDialog() == DialogResult.OK)
            {

                string perfCode = "";
                string strticketno = HIS.ZY_BLL.InvoiceManager.InvoiceManager.GetBillNumber(Convert.ToInt32(controller.user.EmployeeID), true, out perfCode);

                tbTicketNO.Text = perfCode + strticketno;
            }
        }

        //窗体加载事件
        private void FrmCostDiag_Load(object sender, EventArgs e)
        {

            controller.OnLoadData(costType);
            if (zyConfig005 == 0)
            {
                string perfCode = "";
                string strticketno = HIS.ZY_BLL.InvoiceManager.InvoiceManager.GetBillNumber(Convert.ToInt32(controller.user.EmployeeID), true, out perfCode);

                tbTicketNO.Text = perfCode + strticketno;
                tbTicketNO.ReadOnly = true;
                this.button1.Enabled = true;
            }
            else
            {
                tbTicketNO.Text = "";
                tbTicketNO.ReadOnly = false;
                this.button1.Enabled = false;
            }
        }
        //关闭
        private void button2_Click(object sender, EventArgs e)
        {
            isDiag = false;
            this.Close();
        }
        //检查数据是否有误
        private void CheckData()
        {
            if (costType == HIS_ZYManager.Action.CostType.欠费结算 && Convert.ToDecimal(this.tb_extra.Text.Trim()) == 0)
            {
                MessageBox.Show("没有结欠费用，不能用欠费结算！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (this.tbTicketNO.Text.Trim() == "")
            {
                MessageBox.Show("请输入实际发票号！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.tbTicketNO.Focus();
                return;
            }
            if (this.tbFee.Text.Trim() == "" && this.tbpos.Text.Trim() == "")
                return;
        }

        //确定
        private void btok_Click(object sender, EventArgs e)
        {

            CheckData();

            isDiag = true;
            this.Close();
        }

        #region IFrmCostDiagView 成员

        public void Initialize(DataSet _dataSet)
        {
            this.tbOutDept.SetSelectionCardDataSource(_dataSet.Tables["Dept"]);
            this.tbZD.SetSelectionCardDataSource(_dataSet.Tables["Disease"]);
        }

        public bool GroupBoxEnabled
        {
            set { this.groupBox1.Enabled = value; }
        }

        public bool tbFeeEnabled
        {
            set { this.tbFee.Enabled = value; }
        }

        public bool tbPosEnabled
        {
            set { this.tbpos.Enabled = value; }
        }

        public bool tbExtraEnabled
        {
            set { this.tb_extra.Enabled = value; }
        }

        public string LabTitle
        {
            set { this.label3.Text = value; }
        }
        private HIS.ZY_BLL.DataModel.ZY_PatList _zyPatList;
        public HIS.ZY_BLL.DataModel.ZY_PatList zyPatList
        {
            get
            {
                _zyPatList.OutDate = this.dtpOutDate.Value;
                _zyPatList.ReaLiveNum = Convert.ToInt32(this.tbNum.Text);
                _zyPatList.Out_Flag = this.cbOutType.SelectedIndex;
                _zyPatList.CurrDeptCode = this.tbOutDept.MemberValue == null ? "" : this.tbOutDept.MemberValue.ToString();
                _zyPatList.OutDiagnCode = this.tbZD.Tag == null ? "" : this.tbZD.Tag.ToString();
                _zyPatList.OutDiagnName = this.tbZD.Text.Trim();
                return _zyPatList;
            }
            set
            {
                _zyPatList = value;
                this.dtpOutDate.MinDate = _zyPatList.CureDate;
                this.dtpOutDate.Value = _zyPatList.OutDate.ToString("yyyyMMdd") == "00010101" ? DateTime.Now : _zyPatList.OutDate;
                this.cbOutType.SelectedIndex = _zyPatList.Out_Flag;
                this.tbOutDept.MemberValue = _zyPatList.CurrDeptCode == null ? _zyPatList.CureDeptCode : _zyPatList.CurrDeptCode;
                this.tbZD.Text = _zyPatList.OutDiagnName;
            }
        }
        private HIS.ZY_BLL.PatFee _patFee;
        public HIS.ZY_BLL.PatFee patFee
        {
            set
            {
                _patFee = value;
                this.textBox7.Text = _patFee.retreatFee.ToString("0.00");
                this.textBox6.Text = _patFee.receiveFee.ToString("0.00");
                this.tbSelfFee.Text = _patFee.selfFee.ToString("0.00");
                this.tbVillageFee.Text = _patFee.villageFee.ToString("0.00");
                this.tbfaoverFee.Text = _patFee.faoverFee.ToString("0.00");

            }
        }

        decimal HIS_ZYManager.Action.IFrmCostDiagView.tbFee
        {
            get
            {
                return Convert.ToDecimal(this.tbFee.Text.Trim());
            }
            set
            {
                this.tbFee.Text = value.ToString("0.00");
            }
        }

        public decimal tbPos
        {
            get
            {
                return Convert.ToDecimal(this.tbpos.Text.Trim());
            }
            set
            {
                this.tbpos.Text = value.ToString("0.00");
            }
        }

        public decimal tbExtra
        {
            get
            {
                return Convert.ToDecimal(this.tb_extra.Text.Trim());
            }
            set
            {
                this.tb_extra.Text = value.ToString("0.00");
            }
        }

        public HIS_ZYManager.Action.PrintTicketType Ptt
        {
            get
            {
                if (this.radioButton1.Checked == true)
                {
                    return HIS_ZYManager.Action.PrintTicketType.全额打印;
                }
                else if (this.radioButton2.Checked == true)
                {
                    return HIS_ZYManager.Action.PrintTicketType.只打自费;
                }
                else
                {
                    return HIS_ZYManager.Action.PrintTicketType.不打发票;
                }
            }
        }

        string HIS_ZYManager.Action.IFrmCostDiagView.tbTicketNO
        {
            get { return this.tbTicketNO.Text; }
        }

        #endregion

        #region key
        private void dtpOutDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbNum.Focus();
            }
        }

        private void tbNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.cbOutType.Focus();
            }
        }

        private void cbOutType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.tbOutDept.Focus();
            }
        }

        private void tbOutDept_Leave(object sender, EventArgs e)
        {
            if (this.tbOutDept.Tag == null && this.tbOutDept.Text != "")
            {
                this.tbOutDept.Focus();
                this.tbOutDept.SelectAll();
            }
        }

        private void tbZD_Leave(object sender, EventArgs e)
        {
            if (this.tbZD.Tag == null && this.tbZD.Text != "")
            {
                this.tbZD.Focus();
                this.tbZD.SelectAll();
            }
        }
        #endregion

    }
}
