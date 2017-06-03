using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL;
using HIS.ZY_BLL.ObjectModel.CostManager;
using HIS.ZY_BLL.ObjectModel.BaseData;


namespace HIS_ZYManager
{
    public partial class FrmCost : ZYBaseFrom,Action.IFrmCostView
    {
        private Action.FrmCostController controller;

        public FrmCost()
        {
            InitializeComponent();
            base.HIS_DoubleClick += new lvPatList_DoubleClickEvent(FrmCost_HIS_DoubleClick);
            IsCost = true;

           

            BrushPatList();
        }
        
        //清空控件显示数据
        private void ClearControlText()
        {
            this.tbInpatNo.Focus();

            this.tbInpatNo.Text = "0";
            this.tbpatName.Text = "";
            this.tbpatDept.Text = "";
            this.textBox6.Text = "0";
            this.textBox7.Text = "0";
            this.tb_faoverFee.Text = "0";
            this.tb_VillageFee.Text = "0";
            this.tb_SelfFee.Text = "0";
            this.tbAllChargeFee.Text = "0";
            this.tbAllCostFee.Text = "0";
          
            //this.tbNum.Text = "";
            this.textBox1.Text = "";
            //this.dtpOutDate.Value = System.DateTime.Now.Date;
            this.dgFee.DataSource = null;

            this.button3.Enabled = true;

            this.tbselfDrugFee.Text = "0.00";

            //base.zy_PatList = new ZY_PatList();
        }

        //双击病人列表
        private void FrmCost_HIS_DoubleClick(object sender, EventArgs e)
        {
          

            ChargePatData();

        }

        //打印住院发票
        public static void Print(int CostMasterID)
        {

            grproLib.GridppReport Report = new grproLib.GridppReport();
            string ReportPath;
            string PrinterName;
            Object invoice;

            //广东发票打印
            //ReportPath = Constant.ApplicationDirectory + "\\report\\住院发票.grf";
            //PrinterName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport("住院发票.grf");
            //invoice =InvoiceFactory.CreateInvoice(CostMasterID,"广东");
            //湖南发票打印
            ReportPath = Constant.ApplicationDirectory + "\\report\\住院发票_HN.grf";
            PrinterName = HIS_PublicManager.PublicPrintSet.GetPrinterNameByReport("住院发票_HN.grf");
            invoice = InvoiceFactory.CreateInvoice(CostMasterID, "湖南");


            Report.LoadFromFile(ReportPath);
            Report.Printer.PrinterName = PrinterName;
            GWI_DesReport.HisReport.FillRecordToReport(Report, invoice);
            Report.ParameterByName("WorkName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;

            #region 发票项目
            DataTable dt = ((AbstractInvoice)invoice).发票项目费用;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 1; j <= Report.Parameters.Count; j++)
                {
                    if (dt.Rows[i]["itemname"].ToString().Trim() == Report.Parameters[j].Name)
                    {
                        Report.Parameters[j].Value = dt.Rows[i]["Tolal_Fee"].ToString();
                    }
                }
            }
            #endregion
            
            if (Report.Printer.PrinterName == null || Report.Printer.PrinterName == "")
            {
                MessageBox.Show("请先设置好此报表的打印机！", "询问", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                return;
            }
#if DEBUG
            Report.PrintPreview(false);
#else
            //Report.PrintPreview(false);
            Report.Print(false);

#endif
        }        

        //根据住院号检索
        private void tbInpatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                controller.GetInpatNo();
               
            }
        }
        //中途结算
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                controller.CostPat(HIS_ZYManager.Action.CostType.中途结算,controller);
                //MessageBox.Show("结算成功！");
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
            }
        }
        //出院结算
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            try
            {
                controller.CostPat(HIS_ZYManager.Action.CostType.出院结算,controller);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
            }
        }
        //欠费结算
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            try
            {
                controller.CostPat(HIS_ZYManager.Action.CostType.欠费结算,controller);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "提示");
            }
        }
        //关闭
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //记账试算
        private void button1_Click(object sender, EventArgs e)
        {
            controller.GetvillageFee();
        }
        //优惠试算
        private void button2_Click(object sender, EventArgs e)
        {
            controller.GetfaoverFee();
        }
        //录入自费药品金额
        private void button3_Click(object sender, EventArgs e)
        {
            controller.GetselfDrugFee();
        }
        //窗体快捷键
        private void FrmCost_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:

                    break;
                case Keys.F1:	//帮助

                    break;
                case Keys.F2:	//中途结算
                    toolStripButton1_Click(null, null);
                    break;
                case Keys.F3:	//出院结算
                    toolStripButton2_Click(null, null);
                    break;
                case Keys.F4:	//欠费结算
                    toolStripButton3_Click(null, null);
                    break;

                default:
                    break;
            }
        }


        #region IFrmCostView 成员


        public PatFee patFee
        {
            set
            {
                this.tbAllChargeFee.Text = value.chargeFee.ToString("0.00");
                this.tbAllCostFee.Text = value.costFee.ToString("0.00");

                this.tb_faoverFee.Text = value.faoverFee.ToString("0.00");
                this.tb_VillageFee.Text = value.villageFee.ToString("0.00");
                this.tb_SelfFee.Text = value.selfFee.ToString("0.00");
                //补收
                this.textBox6.Text = value.receiveFee.ToString("0.00");
                //退费
                this.textBox7.Text = value.retreatFee.ToString("0.00");
            }
        }

        DataTable HIS_ZYManager.Action.IFrmCostView.dgFee
        {
            set
            {
                this.dgFee.AutoGenerateColumns = false;
                this.dgFee.DataSource = value;
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

        public string selfDrugFee
        {
            get
            {
                return this.tbselfDrugFee.Text;
            }
            set
            {
                this.tbselfDrugFee.Text=value;
            }
        }
        //刷新病人列表
        public void BrushPatList()
        {
            this.llabrush_LinkClicked(null, null);
            
            this.ClearControlText();

            base.zy_PatList = new ZY_PatList();
        }
        //更改病人数据
        public void ChargePatData()
        {
            this.ClearControlText();
            controller.GetPatData();
        }
        //打印发票
        public void CostPrint(int CostMasterID)
        {
            Print(CostMasterID);
        }

        #endregion


        #region IFrmCostView 成员


        public ZY_PatList zyPatList
        {
            get
            {
                return base.zy_PatList;
            }
            set
            {
                base.zy_PatList = value;
                this.tbInpatNo.Text = base.zy_PatList.CureNo;
                this.tbpatName.Text = base.zy_PatList.patientInfo.PatName;
                this.label12.Text = base.zy_PatList.patientInfo.ACCOUNTTYPE;
                this.tbpatDept.Text = base.zy_PatList.CurrDeptCode.Trim() == "" ?
                    BaseNameFactory.GetName(baseNameType.科室名称,base.zy_PatList.CureDeptCode)
                    : BaseNameFactory.GetName(baseNameType.科室名称,base.zy_PatList.CurrDeptCode);//当前科室代码
                this.textBox1.Text = base.zy_PatList.CureDate.ToString("yyyy年MM月dd日");
            }
        }

        #endregion

        private void FrmCost_Load(object sender, EventArgs e)
        {
            controller = new HIS_ZYManager.Action.FrmCostController(this);
        }
    }
}
