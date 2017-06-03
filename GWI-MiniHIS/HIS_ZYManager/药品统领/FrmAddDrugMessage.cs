using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.BaseData;

/*
 *如果药品消息表需要添加或修改一字段，需要修改地方有： 
 * 1.EntityConfig.xml 文件修改
 * 2.实体修改
 * 3.Table&View.cs
 * ------
 * 4.DsMessageData的dtDrugMessage
 * 5.FrmAddDrugMessage的“向下”方法
 * ------上面两步可以放到第6步，但保存的时候会影响速度
 * 6.OP_DurgMessage的"保存统领单数据"方法
 * ------
 * 
 * 
 * 
 * 
 * 
 */

namespace HIS_ZYManager
{
    public partial class FrmAddDrugMessage : GWI.HIS.Windows.Controls.BaseMainForm
    {
        User currentUser = null;
        Deptment currentDept = null;

        private GWI.HIS.Windows.Controls.DataGridViewEx _Dgvx;
        private GWI.HIS.Windows.Controls.DataGridViewEx _Dgvx1;
        private int order_type;
        private int Masterid;
        private string[] data = new string[8];

        private DataTable yfData = null;
        private DataTable usageData = null;

        private bool IsNew = true;
        private bool IsOper = false;
        //[20100514.1.04]
        public FrmAddDrugMessage(int _masterid, User _currentUser, Deptment _currentDept,bool _IsOper)
        {
            InitializeComponent();
            IsNew = true;
            DataTable tb = BaseDataFactory.GetData(baseDataType.住院临床科室);
            tb.TableName = "Dept";

            this.cbDept.DataSource = tb;
            this.cbDept.DisplayMember = "name";
            this.cbDept.ValueMember = "code";
            this.cbDept.SelectedValue = _currentDept.DeptID;
            //[20100525.1.06]
            //禁用修改科室
            this.cbDept.Enabled = false;

            DataTable tb1 = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetYfDept();
            this.comboBox1.DataSource = tb1;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "code";
            try
            {
                this.comboBox1.SelectedValue = "1417";
            }
            catch { }
            //填充dtDrugMessage
            //BindMessageData(HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetMessageOrder());

            data[5] = _currentUser.EmployeeID.ToString();
            data[6] = _currentUser.Name;

            yfData = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetYfData();
            usageData = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetUsageName();

            this.cbStatType.SelectedIndex = 0;

            currentUser = _currentUser;
            currentDept = _currentDept;
            //[20100514.1.04]
            IsOper = _IsOper;

            if (IsOper == true)
            {
                this.cbStatType.SelectedIndex = 2;
                this.tscbType.SelectedIndex = 5;
            }
            else
            {
                this.tscbType.SelectedIndex = 0;
            }
        }
        //[20100514.1.04]
        public FrmAddDrugMessage(int _masterid, User _currentUser, Deptment _currentDept, string _deptCode, string _yfCode, bool _IsDrug, int _StatType, DataTable _dt, bool _IsOper)
        {
            InitializeComponent();
            IsNew = false;
            DataTable tb = BaseDataFactory.GetData(baseDataType.住院临床科室);
            tb.TableName = "Dept";

            this.cbDept.DataSource = tb;
            this.cbDept.DisplayMember = "name";
            this.cbDept.ValueMember = "code";

            DataTable tb1 = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetYfDept();
            this.comboBox1.DataSource = tb1;
            this.comboBox1.DisplayMember = "name";
            this.comboBox1.ValueMember = "code";

            //修改统领单

            Masterid = _masterid;

            //
            //填充dtDrugMessage
            BindMessageData(_dt);
            //绑定数据PresOrder
            this.radioButton1.Checked = _IsDrug;
            this.cbStatType.SelectedIndex = _StatType;
            this.cbDept.SelectedValue = _deptCode;
            this.comboBox1.SelectedValue = _yfCode;
            this.panel9.Enabled = false;
            data[1] = _deptCode;
            BindData(_deptCode, _IsDrug, _StatType);
            //显示

            ShowData();
            ShowStatData();



            data[5] = _currentUser.EmployeeID.ToString();
            data[6] = _currentUser.Name;

            yfData = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetYfData();
            usageData = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetUsageName();

            currentUser = _currentUser;
            currentDept = _currentDept;
            //[20100514.1.04]
            IsOper = _IsOper;

            if (IsOper == true)
            {
                this.cbStatType.SelectedIndex = 2;
                this.tscbType.SelectedIndex = 5;
            }
            else
            {
                this.tscbType.SelectedIndex = 0;
            }
        }

        //关闭
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //科室
        private void chbDept_CheckedChanged(object sender, EventArgs e)
        {
            //if (chbDept.Checked)
            //{
            //    this.cbDept.Enabled = true;
            //}
            //else
            //{
            //    this.cbDept.Enabled = false;
            //}
        }

        //刷新
        private void llabrush_LinkClicked(object sender, EventArgs e)
        {
            BindMessageData(HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetMessageOrder());
            if (dsMessageData.dtDrugMessage.Rows.Count > 0)
            {
                DataRow[] drs = dsMessageData.dtDrugMessage.Select("MASTERID=" + Masterid);
                if (drs.Length > 0)
                {
                    if (MessageBox.Show("统领单还有药品数据，刷新将清空所以数据，是否继续？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    {
                        return;
                    }
                    for (int i = 0; i < drs.Length; i++)
                    {
                        dsMessageData.dtDrugMessage.Rows.Remove(drs[i]);
                    }
                }
            }
            //[20100514.1.04]
            if (IsOper == true && this.cbStatType.SelectedIndex!=2)
            {
                MessageBox.Show("手术室不能统领其他类型的药品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string deptcode = null;
            //if (chbDept.Checked)
            deptcode = this.cbDept.SelectedValue.ToString().Trim();
            data[1] = deptcode;
            BindData(deptcode, this.radioButton1.Checked, this.cbStatType.SelectedIndex);

            ShowData();
            ShowStatData();
        }

        //绑定消息明细
        private void BindMessageData(DataTable _dt)
        {
            dsMessageData.dtDrugMessage.Rows.Clear();
            DataRow[] drs = _dt.Select();
            for (int i = 0; i < drs.Length; i++)
            {
                DataRow dr = dsMessageData.dtDrugMessage.NewRow();
                dr["XD"] = false;
                for (int m = 0; m < _dt.Columns.Count; m++)
                {
                    for (int n = 0; n < dsMessageData.dtDrugMessage.Columns.Count; n++)
                    {
                        if (_dt.Columns[m].ColumnName.ToUpper() == dsMessageData.dtDrugMessage.Columns[n].ColumnName.ToUpper())
                        {
                            dr[dsMessageData.dtDrugMessage.Columns[n].ColumnName] = drs[i][m];
                            break;
                        }
                    }
                }
                dr["DT_State"] = "";
                dsMessageData.dtDrugMessage.Rows.Add(dr);
            }
        }

        //绑定数据PresOrder所有数据(StatType:0.大输液 1.药品 2. 手术)
        //update 20091124 StatType:0.非口服 1.口服 2. 手术
        private void BindData(string deptcode, bool IsDrug, int StatType)
        {
            //加载病人信息
            dsMessageData.dtPatInfo.Rows.Clear();
            ZY_PatList zy_Patlist = new ZY_PatList();
            BindPatListVal bplv = new BindPatListVal();
            bplv.IsIn = true;
            bplv.DeptCode = deptcode;
            //[20100514.1.04]
            bplv.IsOperation = IsOper;
            zy_Patlist.bindPatListVal = bplv;
            zy_Patlist.bindPatListType = BindPatListType.费用清单病人列表;
            List<ZY_PatList> zyPatList = zy_Patlist.BindPatList();
            //zyPatList = zyPatList.FindAll(delegate(ZY_PatList y) { return (y.BedCode.Trim() != ""); });
            //zyPatList.Sort();
            for (int i = 0; i < zyPatList.Count; i++)
            {
                DataRow dr = dsMessageData.dtPatInfo.NewRow();
                dr["XD"] = false;
                dr["CureNo"] = zyPatList[i].CureNo;
                dr["PatName"] = zyPatList[i].patientInfo.PatName;
                dr["Sex"] = zyPatList[i].patientInfo.PatSex;
                dr["BedCode"] = zyPatList[i].BedCode;
                dr["CureDate"] = zyPatList[i].CureDate;
                dr["patlistid"] = zyPatList[i].PatListID;
                dsMessageData.dtPatInfo.Rows.Add(dr);
            }
            //dsMessageData.dtPatInfo.OrderBy(x =>Convert.ToInt32(x.BedCode));
            string yfcode = this.comboBox1.SelectedValue.ToString().Trim();
            data[2] = yfcode;
            data[3] = IsDrug ? "1" : "0";
            data[4] = StatType.ToString();
            data[7] = StatType.ToString();
            //加载账单信息
            string strWhere = "prestype in ('0', '1','2','3') and charge_flag=1 and cost_flag=0 and execdeptcode='" + yfcode + "' ";
            //加载未发药的信息drug_flag=0,发药后为1
            //冲账的药品未退药的drug_flag=1，退药后改为0
            //未发药的费用冲账drug_flag=0 ,oldid 关联
            if (IsDrug)//发药
            {
                strWhere += " and RECORD_FLAG in (0,1) and DRUG_FLAG=0 ";
                if (StatType == 2)//手术用药
                {
                    strWhere += " and ORDER_ID=0 ";
                }
                if (StatType == 0)//非口服
                {
                    strWhere += " and ORDER_ID!=0 and (select count(*) from zy_doc_orderrecord b where b.order_id=zy_presorder.order_id and b.order_usage in (select name from BASE_USAGEDICTION where id not in( select distinct USAGE_ID  from DB2INST2.BASE_USAGE_USETYPE_ROLE where type_name = '服药单')))>0";
                }
                if (StatType == 1)//口服（包括交病人）
                {
                    strWhere += " and ORDER_ID!=0 and (select count(*) from zy_doc_orderrecord b where b.order_id=zy_presorder.order_id and b.order_usage in (select name from BASE_USAGEDICTION where id in( select distinct USAGE_ID  from DB2INST2.BASE_USAGE_USETYPE_ROLE where type_name = '服药单')))>0";
                }
            }
            else//退药
            {
                strWhere += " and RECORD_FLAG=1 and DRUG_FLAG=1 ";
                //if (IsOper)
                //{
                //    strWhere += " and ORDER_ID=0 ";
                //}
                //else
                //{
                //    strWhere += " and ORDER_ID!=0";
                //}
            }

            List<ZY_PresOrder> zyPOList = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetPresOrder(strWhere, IsDrug);
            dsMessageData.dtPresOrder.Rows.Clear();
            for (int i = 0; i < zyPOList.Count; i++)
            {
                ZY_PatList zyP = zyPatList.Find(delegate(ZY_PatList y) { return (y.PatListID == zyPOList[i].PatListID); });
                if (zyP != null && (zyP.PatType == "1" || zyP.PatType == "2" || zyP.PatType == "7"))//过滤掉不在院的记录
                {
                    DataRow dr = dsMessageData.dtPresOrder.NewRow();
                    dr["XD"] = true;
                    dr["PRESORDERID"] = zyPOList[i].PresOrderID;
                    dr["patlistid"] = zyPOList[i].PatListID;
                    dr["CureNo"] = dsMessageData.dtPatInfo.Select("patlistid='" + zyPOList[i].PatListID+"'")[0]["CureNO"];
                    dr["PatName"] = dsMessageData.dtPatInfo.Select("patlistid='" + zyPOList[i].PatListID+"'")[0]["PatName"];
                    dr["itemid"] = zyPOList[i].ItemID;
                    dr["itemname"] = zyPOList[i].ItemName;
                    dr["standard"] = zyPOList[i].Standard;
                    dr["unit"] = zyPOList[i].Unit;
                    dr["relationnum"] = zyPOList[i].RelationNum;
                    dr["buy_price"] = zyPOList[i].Buy_Price;
                    dr["sell_price"] = zyPOList[i].Sell_Price;
                    dr["amount"] = zyPOList[i].Amount;
                    dr["presamount"] = zyPOList[i].PresAmount;
                    dr["tolal_fee"] = zyPOList[i].Tolal_Fee;
                    dr["presdoccode"] = zyPOList[i].PresDocCode;
                    dr["presdeptcode"] = zyPOList[i].PresDeptCode;
                    dr["costdate"] = zyPOList[i].CostDate;
                    dr["oldid"] = zyPOList[i].OldID;
                    dr["record_flag"] = zyPOList[i].Record_Flag;
                    dr["order_id"] = zyPOList[i].order_id;
                    dr["group_id"] = zyPOList[i].group_id;

                    dr["order_type"] = zyPOList[i].order_type;
                    dr["BEDNO"] = dsMessageData.dtPatInfo.Select("patlistid='" + zyPOList[i].PatListID+"'")[0]["BedCode"];
                    dr["CHARGECODE"] = zyPOList[i].ChargeCode;
                    dr["DT_State"] = "";
                    dsMessageData.dtPresOrder.Rows.Add(dr);
                }
            }

            //加载统领信息

        }

        private string GetPatlistIDStr()
        {
            //取得勾选的病人
            string str = null;
            for (int i = 0; i < dsMessageData.dtPatInfo.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dsMessageData.dtPatInfo.Rows[i]["XD"]))
                    str += dsMessageData.dtPatInfo.Rows[i]["patlistid"].ToString() + ",";
            }
            if (str == null)
                str = "0";
            else
                str = str.Substring(0, str.Length - 1);
            return str;
        }
        //显示药品信息
        private void ShowData()
        {
            //统领单有的药品至上删除标示
            for (int i = 0; i < dsMessageData.dtPresOrder.Rows.Count; i++)
            {
#if DEBUG
                if (Convert.ToInt32(dsMessageData.dtPresOrder.Rows[i]["PRESORDERID"]) == 69501)
                {
                    //return;
                }
#endif
                DataRow[] drs = dsMessageData.dtDrugMessage.Select(" DT_State <>'Delete' and ORDERRECIPEID=" + Convert.ToInt32(dsMessageData.dtPresOrder.Rows[i]["PRESORDERID"]));
                if (drs.Length > 0)
                    dsMessageData.dtPresOrder.Rows[i]["DT_State"] = "Delete";
            }

            string str = GetPatlistIDStr();

            //长期汇总
            //dtDrugInfoBindingSource.Filter = "order_type=0 and patlistid in (" + str + ")";
            //临时汇总
            //dtDrugInfoBindingSource1.Filter = "order_type=1 and patlistid in (" + str + ")";

            //长期明细
            dtPresOrderBindingSource.Filter = "order_type=0 and DT_State<>'Delete' and patlistid in (" + str + ")";
            //临时明细
            dtPresOrderBindingSource1.Filter = "order_type <>0 and DT_State<>'Delete' and patlistid in (" + str + ")";

            dsMessageData.dtDrugInfo.Rows.Clear();
            DataRow[] dr = dsMessageData.dtPresOrder.Select(" DT_State<>'Delete' and patlistid in (" + str + ")");

            for (int i = 0; i < dr.Length; i++)
            {
                bool b = false;
                if (dsMessageData.dtDrugInfo.Rows.Count == 0)
                {
                    b = true;
                }

                for (int j = 0; j < dsMessageData.dtDrugInfo.Rows.Count; j++)
                {
                    if (Convert.ToInt32(dr[i]["itemid"]) == Convert.ToInt32(dsMessageData.dtDrugInfo.Rows[j]["itemid"])
                        && Convert.ToInt32(dr[i]["order_type"]) == Convert.ToInt32(dsMessageData.dtDrugInfo.Rows[j]["order_type"]))
                    {
                        dsMessageData.dtDrugInfo.Rows[j]["Amount"] = Convert.ToDecimal(dsMessageData.dtDrugInfo.Rows[j]["Amount"]) + Convert.ToDecimal(dr[i]["amount"]);
                        dsMessageData.dtDrugInfo.Rows[j]["presamount"] = Convert.ToInt32(dsMessageData.dtDrugInfo.Rows[j]["presamount"]) + Convert.ToInt32(dr[i]["presamount"]);
                        dsMessageData.dtDrugInfo.Rows[j]["Total_Fee"] = Convert.ToDecimal(dsMessageData.dtDrugInfo.Rows[j]["Total_Fee"]) + Convert.ToDecimal(dr[i]["tolal_fee"]);
                        break;
                    }
                    if (j == dsMessageData.dtDrugInfo.Rows.Count - 1)
                    {
                        b = true;
                    }
                }

                if (b)
                {
                    DataRow _dr = dsMessageData.dtDrugInfo.NewRow();
                    _dr["XD"] = true;
                    _dr["itemid"] = dr[i]["itemid"];
                    _dr["DrugName"] = dr[i]["itemname"];
                    _dr["Spec"] = dr[i]["standard"];
                    _dr["Price"] = dr[i]["sell_price"];
                    _dr["Amount"] = dr[i]["amount"];
                    _dr["presamount"] = dr[i]["presamount"];
                    _dr["Unit"] = dr[i]["unit"];
                    _dr["Total_Fee"] = dr[i]["tolal_fee"];
                    _dr["order_type"] = dr[i]["order_type"];
                    dsMessageData.dtDrugInfo.Rows.Add(_dr);
                }

            }
        }
        //显示统领信息
        private void ShowStatData()
        {
            //显示明细
            dtDrugMessageBindingSource.Filter = " DT_State<>'Delete' and MASTERID=" + Masterid;

            //显示汇总
            dsMessageData.dtMessageInfo.Rows.Clear();

            DataRow[] drs = dsMessageData.dtDrugMessage.Select("DT_State<>'Delete' and MASTERID=" + Masterid);

            for (int i = 0; i < drs.Length; i++)
            {
                bool b = false;
                if (dsMessageData.dtMessageInfo.Rows.Count == 0)
                {
                    b = true;
                }

                for (int j = 0; j < dsMessageData.dtMessageInfo.Rows.Count; j++)
                {
                    if (Convert.ToInt32(drs[i]["MakerdicID"]) == Convert.ToInt32(dsMessageData.dtMessageInfo.Rows[j]["itemid"]))
                    {
                        dsMessageData.dtMessageInfo.Rows[j]["Amount"] = Convert.ToDecimal(dsMessageData.dtMessageInfo.Rows[j]["Amount"]) + Convert.ToDecimal(drs[i]["DRUGNUM"]);
                        dsMessageData.dtMessageInfo.Rows[j]["presamount"] = Convert.ToInt32(dsMessageData.dtMessageInfo.Rows[j]["presamount"]) + Convert.ToInt32(drs[i]["RECIPENUM"]);
                        dsMessageData.dtMessageInfo.Rows[j]["Total_Fee"] = Convert.ToDecimal(dsMessageData.dtMessageInfo.Rows[j]["Total_Fee"]) + Convert.ToDecimal(drs[i]["RETAILFEE"]);
                        break;
                    }
                    if (j == dsMessageData.dtMessageInfo.Rows.Count - 1)
                    {
                        b = true;
                    }
                }

                if (b)
                {
                    DataRow _dr = dsMessageData.dtMessageInfo.NewRow();
                    _dr["XD"] = false;
                    _dr["itemid"] = drs[i]["MakerdicID"];
                    _dr["DrugName"] = drs[i]["CHEMNAME"];
                    _dr["Spec"] = drs[i]["SPEC"];
                    _dr["Price"] = drs[i]["RETAILPRICE"];
                    _dr["Amount"] = drs[i]["DRUGNUM"];
                    _dr["presamount"] = drs[i]["RECIPENUM"];
                    _dr["Unit"] = drs[i]["UNITNAME"];
                    _dr["Total_Fee"] = drs[i]["RETAILFEE"];
                    dsMessageData.dtMessageInfo.Rows.Add(_dr);
                }
            }
        }
        //勾选病人
        private void dataGridViewEx4_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex > -1)
            {
                if (Convert.ToBoolean(dsMessageData.dtPatInfo.Rows[e.RowIndex]["XD"]))
                {
                    dsMessageData.dtPatInfo.Rows[e.RowIndex]["XD"] = false;
                }
                else
                {
                    dsMessageData.dtPatInfo.Rows[e.RowIndex]["XD"] = true;
                }
                ShowData();
            }

        }
        //反选
        private void dataGridViewEx4_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                for (int i = 0; i < dsMessageData.dtPatInfo.Rows.Count; i++)
                {
                    if (Convert.ToBoolean(dsMessageData.dtPatInfo.Rows[i]["XD"]))
                    {
                        dsMessageData.dtPatInfo.Rows[i]["XD"] = false;
                    }
                    else
                    {
                        dsMessageData.dtPatInfo.Rows[i]["XD"] = true;
                    }
                }
                ShowData();
            }
        }

        private void 全选ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dsMessageData.dtPatInfo.Rows.Count; i++)
            {

                dsMessageData.dtPatInfo.Rows[i]["XD"] = true;

            }
            ShowData();
        }

        private void 反选ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dsMessageData.dtPatInfo.Rows.Count; i++)
            {
                if (Convert.ToBoolean(dsMessageData.dtPatInfo.Rows[i]["XD"]))
                {
                    dsMessageData.dtPatInfo.Rows[i]["XD"] = false;
                }
                else
                {
                    dsMessageData.dtPatInfo.Rows[i]["XD"] = true;
                }
            }
            ShowData();
        }
        //勾选药品
        private void dataGridViewEx1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectDgvx();
            if (e.RowIndex > -1)
            {
                if (Convert.ToBoolean(_Dgvx[0, e.RowIndex].Value))
                    _Dgvx[0, e.RowIndex].Value = false;
                else
                    _Dgvx[0, e.RowIndex].Value = true;
            }
        }
        //药品反选
        private void dataGridViewEx1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SelectDgvx();
                for (int i = 0; i < _Dgvx.RowCount; i++)
                {
                    if (Convert.ToBoolean(_Dgvx[0, i].Value))
                        _Dgvx[0, i].Value = false;
                    else
                        _Dgvx[0, i].Value = true;
                }
            }
        }
        //选中的DataGrid控件
        private bool SelectDgvx()
        {
            order_type = this.tabControl1.SelectedIndex;
            //data[4] = data[4] == "0" ? order_type.ToString() : "2";
            if (this.tabControl1.SelectedIndex == 0)
            {
                if (this.tabControl2.SelectedIndex == 0)
                {
                    _Dgvx = this.dataGridViewEx1;
                }
                else
                {
                    _Dgvx = this.dataGridViewEx5;
                }
                //_tabPage = this.tabPage2;

            }
            else
            {
                if (this.tabControl3.SelectedIndex == 0)
                {
                    _Dgvx = this.dataGridViewEx6;
                }
                else
                {
                    _Dgvx = this.dataGridViewEx7;
                }
                //_tabPage = this.tabPage1;
            }
            DataRow[] drs = dsMessageData.dtDrugMessage.Select("DT_State<>'Delete' and masterid=" + Masterid);
            if (drs.Length > 0)
            {
                if (Convert.ToInt32(drs[0]["docordertype"]) != this.tabControl1.SelectedIndex)
                {
                    return false;
                }
            }
            return true;
        }
        private void SelectDavx1()
        {
            if (this.tabControl4.SelectedIndex == 0)
            {
                _Dgvx1 = this.dataGridViewEx3;
            }
            else
            {
                _Dgvx1 = this.dataGridViewEx2;
            }
        }
        //向下
        private void button1_Click(object sender, EventArgs e)
        {
            if (SelectDgvx() == false)
            {
                MessageBox.Show("不能添加该选项卡【长期】或【临时】的药品!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //汇总赋值给明细
            if (_Dgvx.Name == "dataGridViewEx1" || _Dgvx.Name == "dataGridViewEx6")
            {

                DataRow[] _Alldrs = dsMessageData.dtPresOrder.Select("DT_State<>'Delete' and patlistid in (" + GetPatlistIDStr() + ") and order_type=" + order_type);
                for (int j = 0; j < _Alldrs.Length; j++)
                {
                    _Alldrs[j]["XD"] = false;

                    //取得汇总勾选
                    DataRow[] Alldrs = dsMessageData.dtDrugInfo.Select("(XD=True or XD=true) and order_type=" + order_type);
                    for (int i = 0; i < Alldrs.Length; i++)
                    {
                        if (Convert.ToInt32(_Alldrs[j]["itemid"]) == Convert.ToInt32(Alldrs[i]["itemid"]))
                        {
                            _Alldrs[j]["XD"] = true;
                        }
                    }
                }
            }

            DataRow[] drs = dsMessageData.dtPresOrder.Select("DT_State<>'Delete' and (XD=True or XD=true) and patlistid in (" + GetPatlistIDStr() + ") and order_type=" + order_type);

            for (int i = 0; i < drs.Length; i++)
            {
                DataRow[] _drs = dsMessageData.dtDrugMessage.Select("ORDERRECIPEID=" + Convert.ToInt32(drs[i]["PRESORDERID"]) + " and  MASTERID=" + Masterid);
                if (_drs.Length > 0)//以前向上操作打上删除标示的药品复原（）
                    _drs[0]["DT_State"] = "";//?
                else
                {
                    //循环赋值
                    DataRow dr = dsMessageData.dtDrugMessage.NewRow();

                    int makerdicID = Convert.ToInt32(drs[i]["itemid"]);
                    DataRow[] _cdrs = yfData.Select("MakerDicID=" + makerdicID);
                    if (_cdrs.Length > 0)
                    {
                        dr["UNIT"] = _cdrs[0]["Unit"];//
                        dr["DOSENAME"] = _cdrs[0]["DOSENAME"];
                        dr["SPECDICID"] = _cdrs[0]["SPECDICID"];
                        dr["PRODUCTNAME"] = _cdrs[0]["ProductName"];
                    }
                    else
                    {
                        dr["UNIT"] = 0;//
                        dr["DOSENAME"] = "";
                        dr["SPECDICID"] = 0;
                        dr["PRODUCTNAME"] = "";
                    }

                    dr["XD"] = false;
                    dr["DRUGMESSAGEID"] = 0;
                    dr["masterid"] = Masterid;
                    dr["MakerdicID"] = makerdicID;
                    dr["CHEMNAME"] = drs[i]["itemname"];
                    dr["SPEC"] = drs[i]["standard"];
                    dr["BEDNO"] = drs[i]["BEDNO"];
                    dr["CURENO"] = drs[i]["CureNo"];
                    dr["PATNAME"] = drs[i]["patName"];
                    dr["CUREDEPT"] = drs[i]["presdeptcode"];
                    dr["CUREDOC"] = drs[i]["presdoccode"];
                    dr["patlistid"] = drs[i]["patlistid"];
                    dr["RECIPENUM"] = drs[i]["presamount"];
                    dr["DRUGNUM"] = drs[i]["amount"];

                    dr["UNITNAME"] = drs[i]["unit"];

                    dr["UNITNUM"] = drs[i]["relationnum"];

                    //dr["DOSENUM"] = 0;//

                    dr["RETAILPRICE"] = drs[i]["sell_price"];
                    dr["TRADEPRICE"] = drs[i]["buy_price"];
                    dr["RETAILFEE"] = drs[i]["tolal_fee"];
                    dr["TRADEFEE"] = 0;//
                    dr["RECIPEMASTERID"] = 0;//drs[i]["patlistid"].ToString() + drs[i]["order_type"].ToString() + drs[i]["group_id"].ToString();//
                    dr["ORDERRECIPEID"] = drs[i]["PRESORDERID"];
                    dr["CHARGEMAN"] = drs[i]["CHARGECODE"];
                    dr["CHARGEDATE"] = drs[i]["costdate"];
                    //REFUNDFLAG     SMALLINT,
                    //UNIFORM_FLAG   SMALLINT,
                    dr["CHARGECODE"] = HIS.ZY_BLL.DurgMessage.OP_DurgMessage.GetDrugType(Convert.ToInt32(drs[i]["order_id"]), usageData);
                    //WORKID         BIGINT,
                    dr["ORDERGROUP_ID"] = drs[i]["group_id"];
                    dr["DOCORDERTYPE"] = drs[i]["order_type"];
                    dr["DOCORDERID"] = drs[i]["order_id"];
                    //DISP_FLAG      SMALLINT,

                    dr["DT_State"] = "Add";
                    dsMessageData.dtDrugMessage.Rows.Add(dr);
                }
                //向下药品打上删除标示
                drs[i]["XD"] = false;
                drs[i]["DT_State"] = "Delete";
            }

            ShowData();
            ShowStatData();

        }
        //向上
        private void button2_Click(object sender, EventArgs e)
        {
            //SelectDgvx();
            //以前存在的数据置删除标示
            //向下得到的数据直接移除

            //汇总赋值给明细
            SelectDavx1();
            if (_Dgvx1.Name == "dataGridViewEx3")
            {

                DataRow[] _Alldrs = dsMessageData.dtDrugMessage.Select("masterid=" + Masterid);
                for (int j = 0; j < _Alldrs.Length; j++)
                {
                    _Alldrs[j]["XD"] = false;
                    DataRow[] Alldrs = dsMessageData.dtMessageInfo.Select("XD=True");
                    for (int i = 0; i < Alldrs.Length; i++)
                    {
                        if (Convert.ToInt32(_Alldrs[j]["MakerdicID"]) == Convert.ToInt32(Alldrs[i]["itemid"]))
                        {
                            _Alldrs[j]["XD"] = true;
                        }
                    }
                }
            }

            DataRow[] drs = dsMessageData.dtDrugMessage.Select("XD=True and masterid=" + Masterid);

            for (int i = 0; i < drs.Length; i++)
            {

                DataRow[] _drs = dsMessageData.dtPresOrder.Select("PRESORDERID=" + Convert.ToInt32(drs[i]["ORDERRECIPEID"]));
                if (_drs.Length > 0)//以前向上操作打上删除标示的药品复原（）
                    _drs[0]["DT_State"] = "";//?
                if (drs[i]["DT_State"].ToString() == "Add")
                {
                    dsMessageData.dtDrugMessage.Rows.Remove(drs[i]);
                }
                else
                {
                    drs[i]["XD"] = false;
                    drs[i]["DT_State"] = "Delete";
                }
            }

            ShowData();
            ShowStatData();

        }
        //清空
        private void button3_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < dsMessageData.dtDrugMessage.Rows.Count; i++)
            {
                dsMessageData.dtDrugMessage.Rows[i]["XD"] = true;
            }

            DataRow[] drs = dsMessageData.dtDrugMessage.Select("XD=True and MASTERID=" + Masterid);

            for (int i = 0; i < drs.Length; i++)
            {

                DataRow[] _drs = dsMessageData.dtPresOrder.Select("PRESORDERID=" + Convert.ToInt32(drs[i]["ORDERRECIPEID"]));
                if (_drs.Length > 0)//以前向上操作打上删除标示的药品复原（）
                    _drs[0]["DT_State"] = "";//?

                if (drs[i]["DT_State"].ToString() == "Add")
                {
                    dsMessageData.dtDrugMessage.Rows.Remove(drs[i]);
                }
                else
                {
                    drs[i]["DT_State"] = "Delete";
                }
            }

            ShowData();
            ShowStatData();

        }
        //勾选统领单药品
        private void dataGridViewEx3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectDavx1();
            if (e.RowIndex > -1)
            {
                if (Convert.ToBoolean(_Dgvx1[0, e.RowIndex].Value))
                    _Dgvx1[0, e.RowIndex].Value = false;
                else
                    _Dgvx1[0, e.RowIndex].Value = true;
            }
        }
        //反选统领单药品
        private void dataGridViewEx3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                SelectDavx1();
                for (int i = 0; i < _Dgvx1.RowCount; i++)
                {
                    if (Convert.ToBoolean(_Dgvx1[0, i].Value))
                        _Dgvx1[0, i].Value = false;
                    else
                        _Dgvx1[0, i].Value = true;
                }
            }
        }
        //保存
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            DataRow[] drs = dsMessageData.dtDrugMessage.Select("(DT_State='Delete' or DT_State='Add') and MASTERID=" + Masterid);
            if (drs.Length > 0)
            {
                if (data[4] != "2")
                {
                    data[4] = Convert.ToInt32(drs[0]["docordertype"]) == 0 ? "0" : "1";
                }
                data[0] = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString();
                string message = null;
                HIS.ZY_BLL.DurgMessage.OP_DurgMessage.SaveMessage(Masterid, drs, data,out message);
                MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //MessagePromptManager.Messenger senders = new MessagePromptManager.Messenger(currentUser.UserID, currentDept.DeptID, "");
                //MessagePromptManager.Messenger receiver = new MessagePromptManager.Messenger();
                //MessagePromptManager.Messages message = new MessagePromptManager.Messages("002", "【" + currentDept.Name + "】统领消息", "【" + currentDept.Name + "】已经发来了药品统领消息，请及时查看！");
                //senders.SendMessage(receiver, message);

                if (IsNew)
                {
                    llabrush_LinkClicked(null, null);
                }
                else
                {
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("没有需要保存的数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        //生成长期统领单
        private void 生成长期统领单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 0;
            this.tabControl2.SelectedIndex = 0;
            SelectDgvx();
            for (int i = 0; i < _Dgvx.RowCount; i++)
            {
                _Dgvx[0, i].Value = true;
            }
            button1_Click(null, null);
        }
        //生成临时统领单
        private void 生成临时统领单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex = 1;
            this.tabControl3.SelectedIndex = 1;
            SelectDgvx();
            for (int i = 0; i < _Dgvx.RowCount; i++)
            {
                _Dgvx[0, i].Value = true;
            }
            button1_Click(null, null);
        }
        //发退药
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                this.cbStatType.Enabled = true;
            }
            else
            {
                this.cbStatType.Enabled = false;
            }
        }
        //窗体快捷键
        private void FrmAddDrugMessage_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Escape:

                    break;
                case Keys.F1:	//

                    break;
                case Keys.F2:	//
                    toolStripButton1_Click(null, null);
                    break;

                default:
                    break;
            }
        }
        //一键发送
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            //[20100514.1.04]
            if (IsOper == false && this.tscbType.SelectedIndex == 5)
            {
                MessageBox.Show("手术药品不能在此发送！");
                return;
            }
            //[20100514.1.04]
            if (IsOper == true && this.tscbType.SelectedIndex != 5)
            {
                MessageBox.Show("除了手术药品，其他类型药品不能在此发送！");
                return;
            }

            if (MessageBox.Show("是否执行一键发送[" + this.tscbType.Text + "]到药房?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                HIS.ZY_BLL.DurgMessage.OP_DurgMessage.OneKeySendDrug(this.tscbType.SelectedIndex, currentDept.DeptID.ToString(), currentUser.EmployeeID.ToString(), currentUser.Name, dsMessageData.dtDrugMessage, IsOper);
                MessageBox.Show("发送成功，请重新刷新列表！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                MessagePromptManager.Messenger senders = new MessagePromptManager.Messenger(currentUser.UserID, currentDept.DeptID, "");
                MessagePromptManager.Messenger receiver = new MessagePromptManager.Messenger();
                MessagePromptManager.Messages message = new MessagePromptManager.Messages("002", "【" + currentDept.Name + "】统领消息", "【" + currentDept.Name + "】已经发来了药品统领消息，请及时查看！");
                senders.SendMessage(receiver, message);
            }
        }
        //保存
        private void button4_Click(object sender, EventArgs e)
        {
            toolStripButton1_Click(null, null);
        }
    }
}
