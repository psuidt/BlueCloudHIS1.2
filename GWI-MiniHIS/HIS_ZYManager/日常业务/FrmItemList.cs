using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using GWMHIS.BussinessLogicLayer.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZY_BLL.ObjectModel.BaseData;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.CostManager;
using HIS.ZY_BLL.ObjectModel;
using HIS.ZY_BLL;
using HIS.ZY_BLL.ObjectModel.FeeBillManager;

namespace HIS_ZYManager
{
    public partial class FrmItemList : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;
        private Deptment _currentDept;
        private FilterType _filterType;			//选项卡条件过滤类别
        private SearchType _searchType;
        public ZY_PatList zy_PatList = null;
        //本次优惠金额
        decimal AllDec = 0;

        decimal firstFee=0;
        decimal secondFee=0;
        decimal otherFee=0;
        //明细项目数据
        DataTable ItemDt=null;
        ZY_PatList zy_pat = null;
        grproLib.GridppReport Report = null;
        private FeeBillManager feeBillManager = null;

        public FrmItemList(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            _filterType = Constant.CustomFilterType;
            _searchType = Constant.CustomSearchType;
            this.Text = chineseName;


            DataTable dt = BaseDataFactory.GetData(baseDataType.住院临床科室); 
            this.cbDept.DataSource = dt;
            this.cbDept.DisplayMember = "name";
            this.cbDept.ValueMember = "code";


            this.chbDept.Checked = true;
            this.cbDept.SelectedValue = currentDeptId.ToString();
            zy_PatList = new ZY_PatList();
            feeBillManager = new FeeBillManager();

            this.dtpB.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 00:00:00");
            this.dtpE.Value = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd") + " 23:59:59");

            this.cb_pattype.SelectedIndex = 0;

            this.dtpB.Enabled = false;
            this.dtpE.Enabled = false;
        }
        //绑定病人列表
        private void BindLvPatList()
        {

            string DeptCode = null;
            string CureNo = null;
            string PatName = null;

            DateTime? Bdate = null;
            DateTime? Edate = null;

            bool IsIn = true;

            if (this.chbDept.Checked)
            {
                DeptCode = this.cbDept.SelectedValue.ToString().Trim();
            }

            if (this.checkBox3.Checked)
            {
                CureNo = this.tbInpatNo.Text;
            }

            if (this.checkBox4.Checked)
            {
                PatName = this.textBox1.Text.Trim();
            }

            if (this.checkBox2.Checked)
            {
                Bdate = this.dtpBdate.Value;
                Edate = this.dtpEdate.Value;
            }

            IsIn = this.cb_pattype.SelectedIndex == 0 ? true : false;

            this.lvPatList.Items.Clear();

            List<ZY_PatList> zypatlist = null;

            //ZY_PatList zy_Patlist = new ZY_PatList();
            BindPatListVal bplv = new BindPatListVal();
            bplv.IsIn = IsIn;
            bplv.DeptCode = DeptCode;
            bplv.Bdate = Bdate;
            bplv.Edate = Edate;
            bplv.CureNo = CureNo;
            bplv.PatName = PatName;
            bplv.IsCost = this.cb_pattype.SelectedIndex == 1 ? true : false;
            zy_PatList.bindPatListVal = bplv;
            zy_PatList.bindPatListType = BindPatListType.费用清单病人列表;
            zypatlist = zy_PatList.BindPatList();
            if (zypatlist.Count == 0)
            {
                MessageBox.Show("未找到任何病人！");
                return;
            }
            IcostManager icM = ObjectFactory.GetObject<IcostManager>(typeof(ZY_CostMaster));
            for (int i = 0; i < zypatlist.Count; i++)
            {
                bool b = true;//false 欠费病人

                ListViewItem lstViewItem = new ListViewItem();
                lstViewItem.SubItems.Clear();
                lstViewItem.Tag = zypatlist[i];
                lstViewItem.SubItems[0].Text = zypatlist[i].CureNo;
                lstViewItem.SubItems.Add(zypatlist[i].BedCode);
                lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatName);
                lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatSex);
               
                if (zypatlist[i].PatType == "4" || zypatlist[i].PatType == "5")
                {
                    icM = icM.GetCostMaster(zypatlist[i].PatListID);
                    lstViewItem.SubItems.Add(icM.Deptosit_Fee.ToString());
                    lstViewItem.SubItems.Add(icM.Total_Fee.ToString());//HIS.ZY_BLL.OP_CostManage.GetSumVillage_Fee(zypatlist[i].PatListID).ToString("0.00"));
                    lstViewItem.SubItems.Add(Convert.ToString(icM.Deptosit_Fee-icM.Total_Fee));
                }
                else
                {
                    icM.PatListID = zypatlist[i].PatListID;
                    PatFee patFee = icM.GetPatFee();

                    lstViewItem.SubItems.Add(patFee.chargeFee.ToString());
                    lstViewItem.SubItems.Add(patFee.costFee.ToString());
                    lstViewItem.SubItems.Add(patFee.surplusFee.ToString());
                    if (patFee.surplusFee < 0)
                    {
                        b = false;//欠费病人
                    }
                }
                lstViewItem.SubItems.Add(zypatlist[i].patientInfo.PatBriDate.ToString("yyyy-MM-dd"));
                lstViewItem.SubItems.Add(BaseNameFactory.GetName(baseNameType.科室名称, zypatlist[i].CurrDeptCode));
                lstViewItem.SubItems.Add(zypatlist[i].patientInfo.ACCOUNTTYPE);
                lstViewItem.SubItems.Add(zypatlist[i].CureDate.Date.ToString("yyyy-MM-dd"));
                string strOutDate= zypatlist[i].OutDate.Date.ToString("yyyy-MM-dd");
                strOutDate = strOutDate == "0001-01-01" ? "至今" : strOutDate;
                lstViewItem.SubItems.Add(strOutDate);
                if (zypatlist[i].OutDate.ToString("yyyy-MM-dd") == "0001-01-01")
                {
                    
                    //this.tbNum.Text = ts.Days.ToString();
                    lstViewItem.SubItems.Add("0");
                }
                else
                {
                    TimeSpan ts = zypatlist[i].OutDate - zypatlist[i].CureDate;
                    lstViewItem.SubItems.Add(ts.Days.ToString());
                }

                //[20100624.1.10]
                if (this.cbQF.Checked == true)//欠费病人显示
                {
                    if (b == false)
                        this.lvPatList.Items.Add(lstViewItem);
                }
                else
                {
                    this.lvPatList.Items.Add(lstViewItem);
                }
            }
        }

        private void lvPatList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvPatList.SelectedItems.Count == 0)

            { return; }

            zy_PatList = (ZY_PatList)this.lvPatList.SelectedItems[0].Tag;

        }
        //刷新
        private void btbrush_Click(object sender, EventArgs e)
        {
            BindLvPatList();
        }

        //全选
        private void button2_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < this.lvPatList.Items.Count; i++)
            {
                this.lvPatList.Items[i].Checked = true;
            }



        }
        //反选
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvPatList.Items.Count; i++)
            {
                if (this.lvPatList.Items[i].Checked == false)
                    this.lvPatList.Items[i].Checked = true;
                else
                    this.lvPatList.Items[i].Checked = false;
            }



        }

        

        //打印清单,是否预览
        private void Print(bool IsPreview)
        {
            /*为了解决转科后病人的费用清单打印
             * 以前的清单都是在最后一个科室完全打印，现在是转了几个科室就打几张清单，完全分开
             */
            //取出该病人ID所存在的所有开方科室

            //循环打印各个科室的费用清单
            //打在一起
            if (HIS.ZY_BLL.OP_ZYConfigSetting.GetConfigValue("010") == 0)
            {
                ShowItemData();
                PrintMain(IsPreview,null);
            }
            else
            {
                DataTable dt = feeBillManager.GetPresDeptCode(zy_pat.PatListID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    ShowItemData(dt.Rows[i][0].ToString());
                    PrintMain(IsPreview, dt.Rows[i][0].ToString());
                }
            }
        }

        //打印主功能
        private void PrintMain(bool IsPreview,string presdeptcode)
        {
            Report = new grproLib.GridppReport();

             IcostManager icM = ObjectFactory.GetObject<IcostManager>(typeof(ZY_CostMaster));
             icM.PatListID = zy_pat.PatListID;
             PatFee patFee = icM.GetPatFee(this.dtpE.Value.Date);
             

            if (this.radioButton1.Checked)
            {
                Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院费用清单_汇总.grf");
            }
            else if (this.radioButton2.Checked)
            {
                Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院费用清单_核算.grf");
            }
            else if (this.radioButton3.Checked)
            {
                Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院费用清单.grf");
            }
            else if (this.radioButton4.Checked)
            {
                Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院费用清单_汇总分组.grf");
            }
            else if (this.radioButton5.Checked)
            {
                Report.LoadFromFile(Constant.ApplicationDirectory + "\\report\\住院费用一日清单.grf");
            }
            if (checkBox1.Checked == true)
            {
                Report.ParameterByName("费用时间").AsString = this.dtpB.Value.ToString("yyyy-MM-dd HH:mm:ss") + "至" + this.dtpE.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }
            else
            {
                string date1, date2;
                if (zy_pat.OutDate.Date.ToString("yyyy-MM-dd") == "0001-01-01")
                {
                    date2 = "至今";
                }
                else
                {
                    date2 = zy_pat.OutDate.Date.ToString("yyyy-MM-dd")+" 23:59:59";
                }
                date1 = zy_pat.CureDate.ToString("yyyy-MM-dd HH:mm:ss");

                Report.ParameterByName("费用时间").AsString = date1 + "至" + date2;
            }
            if (this.radioButton5.Checked)
            {
                Report.ParameterByName("费用时间").AsString = this.dtpB.Value.ToString("yyyy-MM-dd HH:mm:ss");
            }

            Report.ParameterByName("CureNo").AsString = zy_pat.CureNo;
            Report.ParameterByName("PatCaseNo").AsString = zy_pat.patientInfo.PatCaseNo;
            Report.ParameterByName("PatName").AsString = zy_pat.patientInfo.PatName;

            string DateStr = zy_pat.OutDate.Date.ToString("yyyy-MM-dd");
            if (DateStr == "0001-01-01")
            {
                DateStr = zy_pat.CureDate.Date.ToString("yyyy-MM-dd");
            }
            else
            {
                DateStr = zy_pat.CureDate.Date.ToString("yyyy-MM-dd") + "至" + DateStr;
            }
            Report.ParameterByName("MarkDate").AsString = DateStr;
            Report.ParameterByName("BedCode").AsString = zy_pat.BedCode;
            if (presdeptcode == null)
            {
                Report.ParameterByName("住院科室").AsString = BaseNameFactory.GetName(baseNameType.科室名称,zy_pat.CurrDeptCode);
            }
            else
            {
                Report.ParameterByName("住院科室").AsString = BaseNameFactory.GetName(baseNameType.科室名称,presdeptcode);
            }
            Report.ParameterByName("WorkName").AsString = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.WorkName;

            if (zy_pat.PatType == "4" || zy_pat.PatType == "5")
            {
                
                //Report.ParameterByName("累计交费").AsString = "0";
                //try
                //{
                //    ZY_CostMaster zyCM = new ZY_CostMaster();
                //    Report.ParameterByName("农合医保记账").AsString = zyCM.GetSumVillage_Fee(zy_pat.PatListID).ToString("0.00");
                //}
                //catch { }
                //Report.ParameterByName("余额").AsString = "0";
                icM = icM.GetCostMaster(zy_pat.PatListID);
                Report.ParameterByName("累计交费").AsString = icM.Deptosit_Fee.ToString();
                Report.ParameterByName("累计记账").AsString = icM.Total_Fee.ToString();
                Report.ParameterByName("余额").AsString = Convert.ToString(icM.Deptosit_Fee - icM.Total_Fee);
            }
            else
            {


                Report.ParameterByName("累计交费").AsString = patFee.chargeFee.ToString();
                Report.ParameterByName("累计记账").AsString = patFee.costFee.ToString();
                Report.ParameterByName("余额").AsString = patFee.surplusFee.ToString();
            }
            //ShowItemData(); 移动在Print()中
            try
            {
                Report.ParameterByName("甲类总金额").AsString = firstFee.ToString();
                Report.ParameterByName("乙类总金额").AsString = secondFee.ToString();
                Report.ParameterByName("本次优惠").AsString = AllDec.ToString();

                Report.ParameterByName("担保金额").AsString = zy_pat.DbFee.ToString("0.00");
                //Report.ParameterByName("自付金额").AsString = Convert.ToString(patFee.costFee - firstFee - secondFee);
            }
            catch { }
            if (this.radioButton5.Checked)
            {
                for (int i = 0; i < ItemDt.Rows.Count; i++)
                {
                    for (int j = 1; j <= Report.Parameters.Count; j++)
                    {
                        if (ItemDt.Rows[i]["itemname"].ToString().Trim() == Report.Parameters[j].Name)
                        {
                            Report.Parameters[j].Value = ItemDt.Rows[i]["Tolal_Fee"].ToString();
                        }
                    }
                }
            }
            else
            {
                Report.FetchRecord += new grproLib._IGridppReportEvents_FetchRecordEventHandler(Report_FetchRecord);
            }
            if (IsPreview)
                Report.PrintPreview(false);
            else
                Report.Print(false);
        }

        private DateTime? Bdate = null;
        private DateTime? Edate = null;

        private void GetFeeDate()
        {
            if (this.checkBox1.Checked == true)
            {
                Bdate = this.dtpB.Value;
                Edate = this.dtpE.Value;
            }
            else
            {
                Bdate = null;
                Edate = null;
            }
        }

        //获取数据
        private void ShowItemData()
        {
            GetFeeDate();

            //按项目组合
            if (this.radioButton1.Checked)
            {
                DataTable dt = null;

                dt = feeBillManager.GetPresTotalData(zy_pat.PatListID, Bdate, Edate);

                dt = feeBillManager.GetFeeType(dt, "1", out AllDec, out firstFee, out secondFee, out otherFee);
                ItemDt = dt;
            }
            //按发票项目
            else if (this.radioButton2.Checked)
            {
                DataTable dt = null;

                dt = feeBillManager.GetCostCalData(zy_pat.PatListID, Bdate, Edate);
                
                ItemDt = dt;
            }
            //按明细项目
            else if (this.radioButton3.Checked)
            {
                DataTable dt = null;

                dt = feeBillManager.GetPresDataTable(zy_pat.PatListID, Bdate, Edate);
                
                dt = feeBillManager.GetFeeType(dt, "2", out AllDec, out firstFee, out secondFee, out otherFee);

                ItemDt = dt;
            }
            //按项目分组汇总
            else if (this.radioButton4.Checked)
            {
                DataTable dt = null;

                dt = feeBillManager.GetPresTotalGroupData(zy_pat.PatListID, Bdate, Edate);
                
                dt = feeBillManager.GetFeeType(dt, "3", out AllDec, out firstFee, out secondFee, out otherFee);

                //dt = feeBillManager.SpliterDataTable(dt);

                ItemDt = dt;
            }
            //住院费用一日清单
            else if (this.radioButton5.Checked)
            {
                DataTable dt = null;

                dt = feeBillManager.GetCostDayData(zy_pat.PatListID, Bdate, Edate);
                
                DataRow dr = dt.NewRow();
                dr["ITEMNAME"] = "合计";

                decimal tolal_fee = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tolal_fee += Convert.ToDecimal(dt.Rows[i]["tolal_fee"]);
                }
                dr["tolal_fee"] = tolal_fee;
                dt.Rows.Add(dr);
                ItemDt = dt;
            }
        }

        //获取数据
        private void ShowItemData(string presdeptcode)
        {
            GetFeeDate();

            //按项目组合
            if (this.radioButton1.Checked)
            {
                DataTable dt = feeBillManager.GetPresTotalData(zy_pat.PatListID, presdeptcode, Bdate, Edate);
                dt = feeBillManager.GetFeeType(dt, "1", out AllDec, out firstFee, out secondFee, out otherFee);
                ItemDt = dt;
            }
            //按发票项目
            else if (this.radioButton2.Checked)
            {
                DataTable dt = feeBillManager.GetCostCalData(zy_pat.PatListID, presdeptcode, Bdate, Edate);
                ItemDt = dt;
            }
            //按明细项目
            else if (this.radioButton3.Checked)
            {
                DataTable dt = feeBillManager.GetPresDataTable(zy_pat.PatListID, presdeptcode, Bdate, Edate);
                dt = feeBillManager.GetFeeType(dt, "2", out AllDec, out firstFee, out secondFee, out otherFee);

                ItemDt = dt;
            }
            //按项目分组汇总
            else if (this.radioButton4.Checked)
            {
                DataTable dt = feeBillManager.GetPresTotalGroupData(zy_pat.PatListID, presdeptcode, Bdate, Edate);

                dt = feeBillManager.GetFeeType(dt, "3", out AllDec, out firstFee, out secondFee, out otherFee);
                ItemDt = dt;
            }
            //住院费用一日清单
            else if (this.radioButton5.Checked)
            {
                DataTable dt = feeBillManager.GetCostDayData(zy_pat.PatListID, presdeptcode, Bdate, Edate);
                DataRow dr = dt.NewRow();
                dr["ITEMNAME"] = "合计";

                decimal tolal_fee = 0;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    tolal_fee += Convert.ToDecimal(dt.Rows[i]["tolal_fee"]);
                }
                dr["tolal_fee"] = tolal_fee;
                dt.Rows.Add(dr);
                ItemDt = dt;
            }
        }

        private void Report_FetchRecord(ref bool Eof)
        {
            GWI_DesReport.HisReport.FillRecordToReport(Report, ItemDt);

        }
        //单人打印
        private void button4_Click(object sender, EventArgs e)
        {
            zy_pat = zy_PatList;
            if (zy_pat != null)
            {
                Print(true);
            }
        }
        //选择打印
        private void button5_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvPatList.Items.Count; i++)
            {
                if (this.lvPatList.Items[i].Checked)
                {
                    zy_pat = (ZY_PatList)this.lvPatList.Items[i].Tag;
                    Print(false);
                }
            }
        }
        //全部打印
        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.lvPatList.Items.Count; i++)
            {
                zy_pat = (ZY_PatList)this.lvPatList.Items[i].Tag;
                Print(false);
            }
        }
        //修改床位号
        private void button1_Click(object sender, EventArgs e)
        {
            string value = GWMHIS.BussinessLogicLayer.Forms.DlgInputBoxStatic.InputBox("输入病人  [" + zy_PatList.patientInfo.PatName + "]  的床位号", "修改床位号",zy_PatList.BedCode,false);
            if (value != null)
            {
                feeBillManager.AlterPatBedNo(zy_PatList.PatListID, value);
                zy_PatList.BedCode = value;
                MessageBox.Show("修改成功！请重新刷新病人列表", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //显示科室
        private void chbDept_CheckedChanged_1(object sender, EventArgs e)
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
        //显示时间
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
            {
                this.dtpBdate.Enabled = true;
                this.dtpEdate.Enabled = true;
            }
            else
            {
                this.dtpBdate.Enabled = false;
                this.dtpEdate.Enabled = false;
            }
        }
        //显示住院号
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox3.Checked)
            {
                this.tbInpatNo.Enabled = true;
                this.tbInpatNo.Focus();
            }
            else
            {
                this.tbInpatNo.Enabled = false;
            }
        }
        //显示病人姓名
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox4.Checked)
            {
                this.textBox1.Enabled = true;
                this.textBox1.Focus();
            }
            else
            {
                this.textBox1.Enabled = false;
            }
        }

        private void lvPatList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            e.Item.Selected = true;
        }
        //关闭
        private void btClose_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }
        //病人回车查询
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btbrush_Click(null, null);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                this.dtpB.Enabled = true;
                this.dtpE.Enabled = true;
            }
            else
            {
                this.dtpB.Enabled = false;
                this.dtpE.Enabled = false;
            }
        }
    }
}
