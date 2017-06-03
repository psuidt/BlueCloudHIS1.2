using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.CostManager;
using HIS.ZY_BLL.ObjectModel;
using HIS.ZY_BLL;



namespace HIS_ZYManager
{
    public partial class FrmCostList : ZYBaseFrom
    {
        DataSet _dataSet = null;
        private HIS.SYSTEM.PubicBaseClasses.FilterType _filterType;			//选项卡条件过滤类别
        private HIS.SYSTEM.PubicBaseClasses.SearchType _searchType;
        private Control _curActiveControl;		//定位SHOWCARD网格从何处弹出
        private ZY_PresOrder zyPresOrder = null;
 
        public FrmCostList()
        {
            InitializeComponent();
            _filterType = HIS.SYSTEM.PubicBaseClasses.Constant.CustomFilterType;
            _searchType = HIS.SYSTEM.PubicBaseClasses.Constant.CustomSearchType;
            base.HIS_DoubleClick += new lvPatList_DoubleClickEvent(FrmCostList_HIS_DoubleClick);

            zyPresOrder = new ZY_PresOrder();

            this.checkBox1.Checked = true;
            this.checkBox2.Checked = false;
            this.checkBox5.Checked = false;
            this.cbPresType.Enabled = false;
            this.cbPresType.SelectedIndex = 0;
            _dataSet = new DataSet();
            this.InitializeDataSet();

            this.dgFee.AutoGenerateColumns = false;
            this.dgFee.DataSource = null;



        }

        private void ShowCardWidth(GWI.HIS.Windows.Controls.QueryTextBox qtb)
        {
            //if (qtb.Width > 250)
                qtb.SelectionCardWidth = 400;
        }
        //加载数据
        private void InitializeDataSet()
        {
            try
            {
                //处方表结构
                Thread loadPrescTable = new Thread(new ThreadStart(LoadItemDic));
                loadPrescTable.Start();
                loadPrescTable.Join();
                this.tb_drugname.SetSelectionCardDataSource(_dataSet.Tables["ITEM_DICTIONARY"]);
                //此线程执行完毕是InitializeGrid()的先决条件    
                ShowCardWidth(this.tb_drugname);
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void LoadItemDic()
        {
            DataTable tb = null;
            tb = zyPresOrder.LoadAllData();
            tb.TableName = "ITEM_DICTIONARY";
            _dataSet.Tables.Add(tb);
            tb = zyPresOrder.LoadDrugData();
            tb.TableName = "ITEM_DRUG";
            _dataSet.Tables.Add(tb);
        }
        //双击病人列表
        private void FrmCostList_HIS_DoubleClick(object sender, EventArgs e)
        {
            zyPresOrder.PatListID = zy_PatList.PatListID;
            //this.BindCostData(base.zy_PatList.PatListID, null, null);
            this.tbInpatNo.Text = base.zy_PatList.CureNo;
            this.tbpatName.Text = base.zy_PatList.patientInfo.PatName;
            IcostManager icM = ObjectFactory.GetObject<IcostManager>(typeof(ZY_CostMaster));
            icM.PatListID = zy_PatList.PatListID;
            PatFee patFee = icM.GetPatFee();

            this.lbChargeTolFee.Text = patFee.chargeFee.ToString();
            this.lbCoseTolFee.Text = patFee.costFee.ToString();
            this.lbExtFee.Text = patFee.surplusFee.ToString();
            DateTime? bdt = null;
            DateTime? edt = null;
            string prestype = null;
            string drugname = null;
            if (this.checkBox1.Checked)
            {
                bdt = this.dtpBdate.Value;
                edt = this.dtpEdate.Value;
            }
            if (this.checkBox5.Checked)
            {
                prestype = this.cbPresType.SelectedIndex.ToString();
            }
            if (this.checkBox2.Checked)
            {
                drugname = HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNull(this.tb_drugname.MemberValue, "");
            }

            this.dgFee.DataSource = AddAddress(zyPresOrder.GetPresDataTable(bdt, edt, prestype, drugname));


        }
        //药品后面添加生成厂家
        private DataTable AddAddress(DataTable dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string itemid = dt.Rows[i]["ITEMID"].ToString();
                DataRow[] drs = _dataSet.Tables["ITEM_DRUG"].Select("itemid=" + itemid);
                if (drs.Length != 0)
                {
                    if (drs[0] != null)
                    {
                        dt.Rows[i]["itemname"] = dt.Rows[i]["itemname"].ToString() + "  [" + drs[0]["ADDRESS"].ToString() + "]";
                    }
                }
            }
            return dt;
        }
        //关闭
        private void toolclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //刷新
        private void toolbrush_Click(object sender, EventArgs e)
        {
            if (zy_PatList != null)
            {
                FrmCostList_HIS_DoubleClick(null, null);
            }
        }
        //窗体快捷键
        private void FrmCostList_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:

                    break;
                case Keys.F1:	//帮助

                    break;
                case Keys.F2:	//刷新
                    toolbrush_Click(null, null);
                    break;
                case Keys.F3:	//预览
                    break;
                case Keys.F4:	//打印
                    toolStripButton2_Click(null, null);
                    break;

                default:
                    break;
            }
        }
        //冲账和取消冲账
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (base.zy_PatList == null || base.zy_PatList.PatType.Trim() == "3" || base.zy_PatList.PatType.Trim() == "4" || base.zy_PatList.PatType.Trim() == "5")
            {
                MessageBox.Show("已出院病人，不能再冲帐操作！");
                return;
            }
            if (this.dgFee.DataSource != null && ((DataTable)this.dgFee.DataSource).Rows.Count > 0)
            {
                DataTable tb = ((DataTable)this.dgFee.DataSource).DefaultView.ToTable();
                for (int i = 0; i < ((DataTable)this.dgFee.DataSource).Rows.Count; i++)
                {
                    if ((bool)this.dgFee[0, i].Value)
                    {
                        ZY_PresOrder zypresorder = new ZY_PresOrder();
                        zypresorder = (ZY_PresOrder)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(tb, i, zypresorder);
                        //取消冲账记录和已结算的记录都不能操作
                        if (zypresorder.Record_Flag == 2 || zypresorder.Cost_Flag==1)
                        {
                            continue;
                        }
                        //[20100514.1.03]
                        if (currentDept.DeptID.ToString() != zypresorder.PresDeptCode)
                        {
                            MessageBox.Show("不是本科室记的账不允许操作！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            continue;
                        }
                        //取消冲账
                        if (zypresorder.OldID != 0)
                        {
                            if (MessageBox.Show("确定要对[" + this.dgFee[3, i].Value.ToString() + "]取消冲账吗？", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                            {
                                int presorderid = zypresorder.PresOrderID;
                                
                                zypresorder.PresOrderID = 0;
                                zypresorder.Amount = Convert.ToDecimal(0 - zypresorder.Amount);
                                zypresorder.Tolal_Fee = Convert.ToDecimal(0 - zypresorder.Tolal_Fee);

                                int index = zypresorder.ItemName.IndexOf(" [");
                                if (index != -1)
                                    zypresorder.ItemName = zypresorder.ItemName.Substring(0, index);
                                //if (//zypresorder.PresType.Trim() == "3" ||
                                //    Convert.ToInt32(zypresorder.PresType) >= 4)
                                //{
                                //    zypresorder.Drug_Flag = 1;
                                //}
                                //else
                                //{
                                //    zypresorder.Drug_Flag = 0;
                                //}
                                zypresorder.Record_Flag = 2;
                                zypresorder.OldID = presorderid;
                                zypresorder.PassID = 0;
                                zypresorder.CostDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                                zyPresOrder.BackPres(presorderid, zypresorder);
                                MessageBox.Show("取消冲账成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else//对原始费用冲账
                        {
                            string value = GWMHIS.BussinessLogicLayer.Forms.DlgInputBoxStatic.InputBox("输入  [" + this.dgFee[3, i].Value.ToString() + "]  冲账的数量", "费用冲账", Convert.ToDecimal(this.dgFee[6, i].Value).ToString(), true);

                            value = Convert.ToDecimal(value).ToString();
                            //this.dgFee[i, 5] = Convert.ToDecimal(this.dgFee[i, 5]) - Convert.ToDecimal(value);
                            if (value != null && value != "0")
                            {
                                decimal Count = Convert.ToDecimal(value);
                                //decimal RCount = Count % Convert.ToDecimal(tb.Rows[i]["RELATIONNUM"]);
                                
                                List<ZY_PresOrder> zy_PresOrderList = new List<ZY_PresOrder>();
                                zypresorder.OldID = zypresorder.PresOrderID;
                                zypresorder.PresOrderID = 0;
                                zypresorder.Amount = Convert.ToDecimal(0 - Convert.ToDecimal(value));
                                 decimal fee = zyPresOrder.CalculateAllFee(Count, Convert.ToDecimal(tb.Rows[i]["RELATIONNUM"]), Convert.ToDecimal(tb.Rows[i]["Sell_PRICE"]));
                                    zypresorder.Tolal_Fee = Convert.ToDecimal(Convert.ToDecimal(0 - fee).ToString("0.00"));
                                zypresorder.Record_Flag = 1;
                                zypresorder.PassID = 0;
                                zypresorder.CostDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;

                                int index = zypresorder.ItemName.IndexOf(" [");
                                if (index != -1)
                                    zypresorder.ItemName = zypresorder.ItemName.Substring(0, index);

                                decimal resultfee, arithmetical_compliment;
                                if (zypresorder.CheckBackPres(out resultfee, out arithmetical_compliment))
                                {
                                    if (arithmetical_compliment == 0)
                                    {
                                        zypresorder.Tolal_Fee = resultfee;
                                    }
                                    zy_PresOrderList.Add(zypresorder);
                                    zyPresOrder.BackPres(zy_PresOrderList);
                                    MessageBox.Show("冲账成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    MessageBox.Show(tb.Rows[i]["ItemName"].ToString() + "冲帐数量过多！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
                toolbrush_Click(null, null);
                //try
                //{
                //    //农合记账
                //    if (zy_PatList.PatientInfo.ACCOUNTTYPE.Trim() == "农合")
                //    {
                //        if (zy_PatList.PatientInfo.MediCard != null && zy_PatList.PatientInfo.MediCard.Trim() != "")
                //        {
                //            IZY_NccmInterface nccmInterface = NccmFactory.Create();
                //            if (nccmInterface != null)
                //            {
                //                nccmInterface.zy_Patlist = zy_PatList;
                //                DataTable dt = zyPresOrder.GetPresDataTable();
                //                nccmInterface.UploadZYPatFee(nccmInterface.ConvertFeeDetail(dt));
                //            }
                //        }
                //    }
                //}
                //catch (Exception err)
                //{
                //    MessageBox.Show(err.Message);
                //}
            }
        }
        //查询条件
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox1.Checked)
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
        //查询条件
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox2.Checked)
                this.tb_drugname.Enabled = true;
            else
                this.tb_drugname.Enabled = false;
            this.tb_drugname.Text = "";
            this.tb_drugname.Tag = "";
        }
        //查询条件
        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dgFee.DataSource != null && ((DataTable)this.dgFee.DataSource).Rows.Count > 0)
            {
                if (this.checkBox3.Checked)
                {
                    for (int i = 0; i < ((DataTable)this.dgFee.DataSource).Rows.Count; i++)
                    {
                        if (Convert.ToInt32(((DataTable)this.dgFee.DataSource).Rows[i]["RECORD_FLAG"]) != 2 && Convert.ToInt32(((DataTable)this.dgFee.DataSource).Rows[i]["Drug_FLAG"]) != 2 && Convert.ToInt32(((DataTable)this.dgFee.DataSource).Rows[i]["COST_FLAG"]) != 1)
                        {
                            this.dgFee[0,i].Value = true;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < ((DataTable)this.dgFee.DataSource).Rows.Count; i++)
                    {
                        this.dgFee[0, i].Value = false;
                    }
                }
            }
        }
        //查询条件
        private void checkBox4_CheckedChanged(object sender, EventArgs e)
        {
            if (this.dgFee.DataSource != null && ((DataTable)this.dgFee.DataSource).Rows.Count > 0)
            {
                 
                    for (int i = 0; i < ((DataTable)this.dgFee.DataSource).Rows.Count; i++)
                    {

                        if ((bool)this.dgFee[0, i].Value)
                            this.dgFee[0, i].Value = false;
                        else
                        {
                            if (Convert.ToInt32(((DataTable)this.dgFee.DataSource).Rows[i]["RECORD_FLAG"]) != 2 && Convert.ToInt32(((DataTable)this.dgFee.DataSource).Rows[i]["Drug_FLAG"]) != 2 && Convert.ToInt32(((DataTable)this.dgFee.DataSource).Rows[i]["COST_FLAG"]) != 1)
                            {
                                this.dgFee[0, i].Value = true;
                            }
                        }
                    }
               
            }
        }
        //选定行
        private void dgFee_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            for (int i = 0; i < ((DataTable)grid.DataSource).DefaultView.Count; i++)
            {
                grid.UnSelect(i);
            }
            grid.Select(grid.CurrentCell.RowNumber);
        }
        //2009-4-8 zy update 输入住院号回车获取病人信息
        private void tbInpatNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                ZY_PatList zyPatlist = zy_PatList.GetPatInfo(tbInpatNo.Text.Trim());
                if (zyPatlist != null)
                {
                    FrmCostList_HIS_DoubleClick(null, null);
                    base.zy_PatList = zyPatlist;
                }
                else
                    MessageBox.Show("没有此住院号的病人！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //显示未发药的信息
        private void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            if (zy_PatList != null)
            {
                this.dgFee.DataSource = zyPresOrder.GetNotSendDurgPresDataTable();
            }
        }
        //单击勾选
        private void dgFee_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (this.dgFee.DataSource != null && ((DataTable)this.dgFee.DataSource).Rows.Count > 0)
                {
                    if (Convert.ToInt32(((DataTable)this.dgFee.DataSource).DefaultView.ToTable().Rows[e.RowIndex]["RECORD_FLAG"]) == 2 || Convert.ToInt32(((DataTable)this.dgFee.DataSource).DefaultView.ToTable().Rows[e.RowIndex]["Drug_FLAG"]) == 2 || Convert.ToInt32(((DataTable)this.dgFee.DataSource).DefaultView.ToTable().Rows[e.RowIndex]["COST_FLAG"]) == 1)
                    {
                        this.dgFee[0, e.RowIndex].Value = false;
                    }
                    else
                    {
                        if ((bool)this.dgFee[0, e.RowIndex].Value)
                            this.dgFee[0, e.RowIndex].Value = false;
                        else
                            this.dgFee[0, e.RowIndex].Value = true;
                    }
                }
            }
            catch
            {
            }
        }
        //长临时账单
        private void checkBox5_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox5.Checked)
                this.cbPresType.Enabled = true;
            else
                this.cbPresType.Enabled = false;
        }
    }
}
