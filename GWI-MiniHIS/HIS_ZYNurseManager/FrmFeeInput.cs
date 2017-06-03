using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;
using GWI.HIS.Windows.Controls;

namespace HIS_ZYNurseManager
{
    public partial class FrmFeeInput : GWI.HIS.Windows.Controls.BaseMainForm
    {
        int orderid;
        int ordertype;
        int groupid;
        private string patlistid;
        private DataTable itemdt;
        DataTable dtAllItems;
        OP_Account op_account = new OP_Account();
        OP_Order op_order = new OP_Order();

        private User _currentUser;
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }
        private Deptment _currentDept;
        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <param name="currentDeptId"></param>
        /// <param name="chineseName"></param>
        public FrmFeeInput(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            LoadItemInfo();
            dataGridViewEx1.DataSource = op_account.getPatList(Convert.ToInt32(_currentDept.DeptID));
            dataGridViewEx2.SetSelectionCardDataSource(itemdt, "column5");
            dataGridViewEx3.SetSelectionCardDataSource(itemdt, "column15");
            if (dataGridViewEx1.Rows.Count != 0)
            {
                patlistid = dataGridViewEx1["column12", 0].Value.ToString();
            }
            else
            {
                if (MessageBox.Show("该科室无任何病人信息列表，请重新登录选择科室", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    return;
                else
                    return;
            }
            refreshaccount();
        }
        /// <summary>
        /// 构造函数(账单补录)
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <param name="currentDeptId"></param>
        /// <param name="chineseName"></param>
        public FrmFeeInput(long currentUserId, long currentDeptId, string chineseName, int patlist_id, int order_id, int order_type, int group_id)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            //tabPageControl1.TabPages.RemoveAt(0);
            //tabPageControl1.TabPages.RemoveAt(1);
            patlistid = patlist_id.ToString();
            orderid = order_id;
            ordertype = order_type;
            groupid = group_id;
            dataGridViewEx1.DataSource = op_account.getPat(Convert.ToInt32(_currentDept.DeptID), Convert.ToInt32(patlistid));
            LoadItemInfo();
            //LoadFrequency();
            dataGridViewEx2.SetSelectionCardDataSource(itemdt, "column5");
            //dataGridViewEx2.SetSelectionCardDataSource(frequencydt,"column10");
            dataGridViewEx3.SetSelectionCardDataSource(itemdt, "column15");
            if (dataGridViewEx1.Rows.Count != 0)
            {
                patlistid = dataGridViewEx1["column12", 0].Value.ToString();

            }
            else
            {
                if (MessageBox.Show("该科室无任何病人信息列表，请重新登录选择科室", "提示", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    return;
                else
                    return;
            }
            btnSend.Enabled = true;
            refreshaccount();
        }
        /// <summary>
        /// 病人刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnrefresh_Click(object sender, EventArgs e)
        {
            dataGridViewEx1.DataSource = op_account.getPatList(Convert.ToInt32(_currentDept.DeptID));
        }
        /// <summary>
        /// 账单刷新
        /// </summary>
        private void refreshaccount()
        {
            dtgrdVaildLongAccount.AutoGenerateColumns = false;
            dtgrdVaildLongAccount.DataSource = op_order.getOrder(Convert.ToInt32(patlistid), 2);
            dtgrdValidTempAccount.AutoGenerateColumns = false;
            dtgrdValidTempAccount.DataSource = op_order.getOrder(Convert.ToInt32(patlistid), 3);
        }
        /// <summary>
        /// 数据源
        /// </summary>
        private void LoadItemInfo()
        {
            itemdt = op_account.getItems();
            itemdt.TableName = "Itemslist";
        }
        /// <summary>
        /// 获取病人列表ID
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dataGridViewEx1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            patlistid = dataGridViewEx1["column12", dataGridViewEx1.CurrentCell.RowIndex].Value.ToString();
            inPatientPanel1.InPatientExtDB = new ApplyIInPatient(Convert.ToInt32(patlistid));
            dataGridViewEx2.Rows.Clear();
            dataGridViewEx3.Rows.Clear();
            DataTable patdt = (DataTable)dataGridViewEx1.DataSource;
            if (patdt.Rows.Count > 0)
            {
                if (tabPageControl1.SelectedIndex == 2)
                {
                    dtgrdVaildLongAccount.DataSource = op_order.getOrder(Convert.ToInt32(patlistid), 2);
                }
                else if (tabPageControl1.SelectedIndex == 3)
                {
                    dtgrdValidTempAccount.DataSource = op_order.getOrder(Convert.ToInt32(patlistid), 3);
                }
            }
        }
        /// <summary>
        /// 长期账单录入行选中后对应的操作
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <param name="stop"></param>
        /// <param name="customNextColumnIndex"></param>
        private void dataGridViewEx2_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            int i = dataGridViewEx2.CurrentCell.RowIndex;
            if (dataGridViewEx2.CurrentCell.ColumnIndex == dataGridViewEx2.Columns["column5"].Index)
            {
                
                int orderid = Convert.ToInt32(((DataRow)SelectedValue)["item_id"].ToString());
                 string item_name = ((DataRow)SelectedValue)["order_name"].ToString();
                string name = ((DataRow)SelectedValue)["order_type"].ToString();
                if (name == "物资") //add by heyan 2010.12.15 护士录账单是物资时要判断库存
                {
                    if (Convert.ToDecimal(((DataRow)SelectedValue)["STORENUM"]) <= 0)
                    {
                        MessageBox.Show("" + item_name + "的库存不足，请重开");
                        return;
                    }
                }

               
                string price = ((DataRow)SelectedValue)["price"].ToString();
                string item_unit = ((DataRow)SelectedValue)["order_unit"].ToString();
                string default_usage = ((DataRow)SelectedValue)["DEFAULT_USAGE"].ToString();
                string tc_flag = ((DataRow)SelectedValue)["TC_FLAG"].ToString();
                int execdept = Convert.ToInt32(XcConvert.IsNull(((DataRow)SelectedValue)["execdept_code"], _currentDept.DeptID.ToString()));
                //int execdept = ((DataRow)SelectedValue)["execdept_code"] == "" || ((DataRow)SelectedValue)["execdept_code"] ==null? Convert.ToInt32(_currentDept.DeptID) : Convert.ToInt32(((DataRow)SelectedValue)["execdept_code"].ToString());
                dataGridViewEx2.EndEdit();
                dataGridViewEx2["column3", i].Value = orderid;
                dataGridViewEx2["column4", i].Value = name;
                dataGridViewEx2["column5", i].Value = item_name;
                dataGridViewEx2["column6", i].Value = 1;
                dataGridViewEx2["column7", i].Value = price;
                dataGridViewEx2["column8", i].Value = item_unit;
                dataGridViewEx2["column9", i].Value = default_usage;
                dataGridViewEx2["column20", i].Value = tc_flag;
                dataGridViewEx2["execdept_code", i].Value = execdept;
            }
            else
            {
            }
        }
        /// <summary>
        /// 临时账单录入行选中后对应的操作
        /// </summary>
        /// <param name="SelectedValue"></param>
        /// <param name="stop"></param>
        /// <param name="customNextColumnIndex"></param>
        private void dataGridViewEx3_SelectCardRowSelected(object SelectedValue, ref bool stop, ref int customNextColumnIndex)
        {
            int i = dataGridViewEx3.CurrentCell.RowIndex;
            int orderid = Convert.ToInt32(((DataRow)SelectedValue)["item_id"].ToString());
            string name = ((DataRow)SelectedValue)["order_type"].ToString();
            string item_name = ((DataRow)SelectedValue)["order_name"].ToString();
            if (name == "物资") //add by heyan 2010.12.15 护士录账单是物资时要判断库存
            {
                if (Convert.ToDecimal(((DataRow)SelectedValue)["STORENUM"]) <= 0)
                {
                    MessageBox.Show("" + item_name + "的库存不足，请重开");
                    return;
                }
            }
            string price = ((DataRow)SelectedValue)["price"].ToString();
            string item_unit = ((DataRow)SelectedValue)["order_unit"].ToString();
            string default_usage = ((DataRow)SelectedValue)["DEFAULT_USAGE"].ToString();
            int execdept = Convert.ToInt32(XcConvert.IsNull(((DataRow)SelectedValue)["execdept_code"], _currentDept.DeptID.ToString()));
            dataGridViewEx3.EndEdit();
            dataGridViewEx3["column13", i].Value = orderid;
            dataGridViewEx3["column14", i].Value = name;
            dataGridViewEx3["column15", i].Value = item_name;
            dataGridViewEx3["column16", i].Value = 1;
            dataGridViewEx3["column17", i].Value = price;
            dataGridViewEx3["column18", i].Value = item_unit;
            dataGridViewEx3["column19", i].Value = default_usage;
            dataGridViewEx3["execdept_code1", i].Value = execdept;
        }
        /// <summary>
        /// 新开新增行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tabPageControl1.SelectedTab.Text == "长期账单")
            {
                int rownum = dataGridViewEx2.Rows.Count;
                if (rownum == 0 || dataGridViewEx2[Column5.Name, rownum - 1].Value != null)
                {
                    dataGridViewEx2.Rows.Add();
                    dataGridViewEx2.CurrentCell = dataGridViewEx2[2, rownum];
                    dataGridViewEx2.Focus();
                }
                else
                {
                    dataGridViewEx2.CurrentCell = dataGridViewEx2[2, rownum - 1];
                    dataGridViewEx2.Focus();
                    return;
                }
            }
            else
            {
                int rownum = dataGridViewEx3.Rows.Count;
                if (rownum == 0 || dataGridViewEx3[Column15.Name, rownum - 1].Value != null)
                {
                    dataGridViewEx3.Rows.Add();
                    dataGridViewEx3.CurrentCell = dataGridViewEx3[2, rownum];
                    dataGridViewEx3.Focus();
                }
                else
                {
                    dataGridViewEx3.CurrentCell = dataGridViewEx3[2, rownum - 1];
                    dataGridViewEx3.Focus();
                    return;
                }
            }
        }
        /// <summary>
        /// 账单保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            HIS.Model.ZY_DOC_ORDERRECORD zyorderrecord;
            List<HIS.Model.ZY_DOC_ORDERRECORD> list = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            if (patlistid == null)
                return;
            int orderdoc = op_account.getOrderDoc(Convert.ToInt32(patlistid));

            if (tabPageControl1.SelectedIndex == 0)
            {
                if (dataGridViewEx2.Rows.Count == 0)
                {
                    MessageBox.Show("您没有新开任何医嘱", "提示", MessageBoxButtons.OK);
                    return;
                }
                for (int rownum = 0; rownum < dataGridViewEx2.Rows.Count; rownum++)
                {
                    zyorderrecord = new HIS.Model.ZY_DOC_ORDERRECORD();
                    if (dataGridViewEx2.Rows.Count != 1 && rownum == dataGridViewEx2.Rows.Count - 1 && dataGridViewEx2[1, rownum].Value == null)//只有一行或者是最后一行
                    {
                        break;
                    }
                    else
                    {
                        if (dataGridViewEx2[1, rownum].Value != null)
                        {
                            try
                            {
                                if (dataGridViewEx2[1, rownum].Value.ToString() == "护理")
                                {
                                    zyorderrecord.ITEM_TYPE = 8;
                                }
                                else if (dataGridViewEx2[1, rownum].Value.ToString() == "物资")
                                {
                                    zyorderrecord.ITEM_TYPE = 0;
                                }
                                else
                                {
                                    zyorderrecord.ITEM_TYPE = 9;
                                }
                                string strValue = dataGridViewEx2[3, rownum].Value.ToString().Trim();
                                if (CommonFun.IsNumeric(strValue, false))
                                {
                                    if (Convert.ToDecimal(strValue) > 0)
                                    {
                                        zyorderrecord.AMOUNT = Convert.ToDecimal(strValue);
                                    }
                                    else
                                    {
                                        dataGridViewEx2.CurrentCell = dataGridViewEx2[Column6.Name, rownum];
                                        dataGridViewEx2.Focus();
                                        MessageBox.Show("您输入的数量为负数，请重新输入正数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else
                                {
                                    dataGridViewEx2.CurrentCell = dataGridViewEx2[Column6.Name, rownum];
                                    dataGridViewEx2.Focus();
                                    MessageBox.Show("您输入的数量不是数值，请重输入数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                zyorderrecord.ORDER_TYPE = 2;
                                zyorderrecord.EXEC_DEPT = Convert.ToInt32(dataGridViewEx2["execdept_code", rownum].Value.ToString());// Convert.ToInt32(_currentDept.DeptID);
                                zyorderrecord.PATID = Convert.ToInt32(patlistid);
                                zyorderrecord.ORDER_DOC = orderdoc;
                                zyorderrecord.PRES_DEPTID = Convert.ToInt32(_currentDept.DeptID);
                                zyorderrecord.ORDER_BDATE = XcDate.ServerDateTime;
                                zyorderrecord.ORDITEM_ID = Convert.ToInt32(dataGridViewEx2[0, rownum].Value.ToString());
                                zyorderrecord.ORDER_CONTENT = dataGridViewEx2[2, rownum].Value.ToString();
                                zyorderrecord.STATUS_FALG = 2;
                                zyorderrecord.UNIT = dataGridViewEx2[Column8.Name, rownum].Value.ToString();
                                zyorderrecord.UNITTYPE = 2;
                                zyorderrecord.PAT_DEPTID = Convert.ToInt32(_currentDept.DeptID);
                                zyorderrecord.TC_ID = Convert.ToInt32(dataGridViewEx2[7, rownum].Value.ToString());

                                list.Add(zyorderrecord);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("您还未完整输入账单内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dataGridViewEx2.Focus();
                            return;
                        }
                    }
                }
                bool feeinputresult = op_account.BindData(list);
                if (feeinputresult == true)
                {
                    MessageBox.Show("您的长期账单已经成功保存！", "提示", MessageBoxButtons.OK);
                    refreshaccount();
                }
                else
                {
                    MessageBox.Show("您的长期账单保存失败，请稍候重试！", "提示", MessageBoxButtons.OK);
                }
                dataGridViewEx2.Rows.Clear();
            }
            else
            {
                if (dataGridViewEx3.Rows.Count == 0)
                {
                    MessageBox.Show("您没有新开任何医嘱", "提示", MessageBoxButtons.OK);
                    return;
                }
                for (int rownum = 0; rownum < dataGridViewEx3.Rows.Count; rownum++)
                {
                    zyorderrecord = new HIS.Model.ZY_DOC_ORDERRECORD();
                    if (dataGridViewEx3.Rows.Count != 1 && rownum == dataGridViewEx3.Rows.Count - 1 && dataGridViewEx3[1, rownum].Value == null)//只有一行或者是最后一行
                    {
                        break;
                    }
                    else
                    {
                        if (dataGridViewEx3[1, rownum].Value != null)
                        {
                            try
                            {
                                if (dataGridViewEx3[1, rownum].Value.ToString() == "护理")
                                {
                                    zyorderrecord.ITEM_TYPE = 8;
                                }
                                else if (dataGridViewEx3[1, rownum].Value.ToString() == "物资")
                                {
                                    zyorderrecord.ITEM_TYPE = 0;
                                }
                                else
                                {
                                    zyorderrecord.ITEM_TYPE = 9;
                                }
                                string strValue = dataGridViewEx3[3, rownum].Value.ToString().Trim();
                                if (CommonFun.IsNumeric(strValue, false))
                                {
                                    if (Convert.ToDecimal(strValue) > 0)
                                    {
                                        zyorderrecord.AMOUNT = Convert.ToDecimal(strValue);
                                    }
                                    else
                                    {
                                        dataGridViewEx3.CurrentCell = dataGridViewEx3[Column16.Name, rownum];
                                        dataGridViewEx3.Focus();
                                        MessageBox.Show("您输入的数量为负数，请重新输入正数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        return;
                                    }
                                }
                                else
                                {
                                    dataGridViewEx3.CurrentCell = dataGridViewEx3[Column16.Name, rownum];
                                    dataGridViewEx3.Focus();
                                    MessageBox.Show("您输入的数量不是数值，请重输入数！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return;
                                }
                                zyorderrecord.ORDER_TYPE = 3;
                                zyorderrecord.EXEC_DEPT = Convert.ToInt32(dataGridViewEx3["execdept_code1", rownum].Value.ToString());// Convert.ToInt32(_currentDept.DeptID);
                                zyorderrecord.PATID = Convert.ToInt32(patlistid);
                                zyorderrecord.ORDER_DOC = orderdoc;
                                zyorderrecord.PRES_DEPTID = Convert.ToInt32(_currentDept.DeptID);
                                zyorderrecord.ORDER_BDATE = XcDate.ServerDateTime;
                                zyorderrecord.ORDITEM_ID = Convert.ToInt32(dataGridViewEx3[0, rownum].Value.ToString());
                                zyorderrecord.ORDER_CONTENT = dataGridViewEx3[2, rownum].Value.ToString();
                                zyorderrecord.STATUS_FALG = 2;
                                zyorderrecord.UNIT = dataGridViewEx3[Column18.Name, rownum].Value.ToString();
                                zyorderrecord.UNITTYPE = 2;
                                zyorderrecord.PAT_DEPTID = Convert.ToInt32(_currentDept.DeptID);
                                list.Add(zyorderrecord);
                            }
                            catch (Exception ex)
                            {
                                throw new Exception(ex.Message);
                            }
                        }
                        else
                        {
                            MessageBox.Show("您还未完整输入账单内容", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dataGridViewEx3.Focus();
                            return;
                        }
                    }
                }
                bool feeinputresult = op_account.BindData(list);
                if (feeinputresult == true)
                {
                    MessageBox.Show("您的临时账单已经成功保存！", "提示", MessageBoxButtons.OK);
                    refreshaccount();
                }
                else
                {
                    MessageBox.Show("您的临时账单保存失败，请稍候重试！", "提示", MessageBoxButtons.OK);
                }
            }
            dataGridViewEx3.Rows.Clear();
        }
        /// <summary>
        /// 账单发送
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            int row;
            if (tabPageControl1.SelectedIndex == 3)///临时账单
            {
                row = dtgrdValidTempAccount.Rows.Count;
                List<int> list = new List<int>();
                int neworderid;
                bool result;
                for (int i = 0; i < row; i++)
                {
                    if (Convert.ToBoolean(dtgrdValidTempAccount[0, i].Value) == true)
                    {
                        neworderid = Convert.ToInt32(dtgrdValidTempAccount[dataGridViewTextBoxColumn7.Name, i].Value.ToString());
                        list.Add(neworderid);
                    }
                }
                if (list.Count == 0)
                {
                    MessageBox.Show("您未选中要发送的临时账单项！", "提示", MessageBoxButtons.OK);
                    return;
                }
                else
                {
                    result = op_order.tempvalidaccountinsert(list, _currentUser.EmployeeID, Convert.ToInt32(patlistid), orderid, ordertype, groupid);
                }
                if (result == true)
                {
                    MessageBox.Show("您的临时账单已成功发送！", "提示", MessageBoxButtons.OK);
                }
                else
                {
                    MessageBox.Show("您的临时账单发送失败，请稍候重新发送！", "提示", MessageBoxButtons.OK);
                }
                dtgrdValidTempAccount.DataSource = op_order.getOrder(Convert.ToInt32(patlistid), 3);
            }
            else
            {
                MessageBox.Show("对不起，只有补录的临时账单才可以发送！", "提示", MessageBoxButtons.OK);
                return;
            }
        }
        /// <summary>
        /// 账单删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDel_Click(object sender, EventArgs e)
        {
            try
            {
                if (tabPageControl1.SelectedIndex == 0 || tabPageControl1.SelectedIndex == 1)
                {
                    if (tabPageControl1.SelectedIndex == 0)
                    {
                        DialogResult dr = MessageBox.Show("您真的要删除该行录入吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            dataGridViewEx2.Rows.RemoveAt(dataGridViewEx2.CurrentCell.RowIndex);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        DialogResult dr = MessageBox.Show("您真的要删除该行录入吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            dataGridViewEx3.Rows.RemoveAt(dataGridViewEx3.CurrentCell.RowIndex);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
                else
                {
                    if (tabPageControl1.SelectedIndex == 2)
                    {
                        List<int> orderlist = new List<int>();
                        for (int i = 0; i < dtgrdVaildLongAccount.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dtgrdVaildLongAccount[0, i].Value) == true)
                            {
                                orderid = Convert.ToInt32(dtgrdVaildLongAccount[1, i].Value.ToString());
                                orderlist.Add(orderid);
                            }
                        }
                        DialogResult dr = MessageBox.Show("您真的要删除这些账单记录吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            op_account.DelData(orderlist);
                            dtgrdVaildLongAccount.AutoGenerateColumns = false;
                            dtgrdVaildLongAccount.DataSource = op_order.getOrder(Convert.ToInt32(patlistid), 2);
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        List<int> orderlist = new List<int>();
                        for (int i = 0; i < dtgrdValidTempAccount.Rows.Count; i++)
                        {
                            if (Convert.ToBoolean(dtgrdValidTempAccount[0, i].Value) == true)
                            {
                                orderid = Convert.ToInt32(dtgrdValidTempAccount[1, i].Value.ToString());
                                orderlist.Add(orderid);
                            }
                        }
                        DialogResult dr = MessageBox.Show("您真的要删除这些账单记录吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (dr == DialogResult.Yes)
                        {
                            op_account.DelData(orderlist);
                            dtgrdValidTempAccount.AutoGenerateColumns = false;
                            dtgrdValidTempAccount.DataSource = op_order.getOrder(Convert.ToInt32(patlistid), 3);
                        }
                        else
                        {
                            return;
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("系统遇到异常信息，请重试!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// 全选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            if (tabPageControl1.SelectedIndex == 2)
            {
                for (int rownum = 0; rownum < dtgrdVaildLongAccount.Rows.Count; rownum++)
                {
                    dtgrdVaildLongAccount[0, rownum].Value = true;
                    for (int k = 0; k < dtgrdVaildLongAccount.Columns.Count; k++)
                    {
                        dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
            else if (tabPageControl1.SelectedIndex == 3)
            {
                for (int rownum = 0; rownum < dtgrdValidTempAccount.Rows.Count; rownum++)
                {
                    dtgrdValidTempAccount[0, rownum].Value = true;
                    for (int k = 0; k < dtgrdValidTempAccount.Columns.Count; k++)
                    {
                        dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
            }
        }
        /// <summary>
        /// 反选
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnReverSelect_Click(object sender, EventArgs e)
        {
            if (tabPageControl1.SelectedIndex == 2)
            {
                for (int rownum = 0; rownum < dtgrdVaildLongAccount.Rows.Count; rownum++)
                {
                    dtgrdVaildLongAccount[0, rownum].Value = !(Convert.ToBoolean(dtgrdVaildLongAccount[0, rownum].Value));
                    if (Convert.ToBoolean(dtgrdVaildLongAccount[0, rownum].Value) == true)
                    {
                        for (int k = 0; k < dtgrdVaildLongAccount.Columns.Count; k++)
                        {
                            dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dtgrdVaildLongAccount.Columns.Count; k++)
                        {
                            dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dtgrdVaildLongAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }
                }
            }
            else if (tabPageControl1.SelectedIndex == 3)
            {
                for (int rownum = 0; rownum < dtgrdValidTempAccount.Rows.Count; rownum++)
                {
                    dtgrdValidTempAccount[0, rownum].Value = !(Convert.ToBoolean(dtgrdValidTempAccount[0, rownum].Value));
                    if (Convert.ToBoolean(dtgrdValidTempAccount[0, rownum].Value) == true)
                    {
                        for (int k = 0; k < dtgrdValidTempAccount.Columns.Count; k++)
                        {
                            dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                            dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                        }
                    }
                    else
                    {
                        for (int k = 0; k < dtgrdValidTempAccount.Columns.Count; k++)
                        {
                            dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                            dtgrdValidTempAccount.Rows[rownum].Cells[k].Style.BackColor = System.Drawing.Color.White;
                        }
                    }

                }
            }

        }
        /// <summary>
        /// 选中有效长期账单行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdVaildLongAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                if (Convert.ToBoolean(dtgrdVaildLongAccount[0, i].Value) == false)
                {
                    dtgrdVaildLongAccount[0, i].Value = true;
                    for (int k = 0; k < dtgrdVaildLongAccount.Columns.Count; k++)
                    {
                        dtgrdVaildLongAccount.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdVaildLongAccount.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
                else
                {
                    dtgrdVaildLongAccount[0, i].Value = false;
                    for (int k = 0; k < dtgrdVaildLongAccount.Columns.Count; k++)
                    {
                        dtgrdVaildLongAccount.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                        dtgrdVaildLongAccount.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }
        /// <summary>
        /// 选中有效临时账单行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dtgrdValidTempAccount_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }
            if (e.ColumnIndex == 0)
            {
                int i = e.RowIndex;
                if (Convert.ToBoolean(dtgrdValidTempAccount[0, i].Value) == false)
                {
                    dtgrdValidTempAccount[0, i].Value = true;
                    for (int k = 0; k < dtgrdValidTempAccount.Columns.Count; k++)
                    {
                        dtgrdValidTempAccount.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.GreenYellow;
                        dtgrdValidTempAccount.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.GreenYellow;
                    }
                }
                else
                {
                    dtgrdValidTempAccount[0, i].Value = false;
                    for (int k = 0; k < dtgrdValidTempAccount.Columns.Count; k++)
                    {
                        dtgrdValidTempAccount.Rows[i].Cells[k].Style.SelectionBackColor = System.Drawing.Color.Blue;
                        dtgrdValidTempAccount.Rows[i].Cells[k].Style.BackColor = System.Drawing.Color.White;
                    }
                }
            }
        }
        /// <summary>
        /// 账单页选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tabPageControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabPageControl1.SelectedIndex == 2)
            {
                btnNew.Enabled = false;
                btnModelApply.Enabled = false;
                dtgrdVaildLongAccount.AutoGenerateColumns = false;
                dtgrdVaildLongAccount.DataSource = op_order.getOrder(Convert.ToInt32(patlistid), 2);
            }
            else if (tabPageControl1.SelectedIndex == 3)
            {
                btnNew.Enabled = false;
                btnModelApply.Enabled = false;
                dtgrdValidTempAccount.AutoGenerateColumns = false;
                dtgrdValidTempAccount.DataSource = op_order.getOrder(Convert.ToInt32(patlistid), 3);
            }
            else
            {
                btnNew.Enabled = true;
                btnModelApply.Enabled = true;
            }
        }
        /// <summary>
        /// 退出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModelApply_Click(object sender, EventArgs e)
        {
            FrmModelApply modelapply = new FrmModelApply(Convert.ToInt32(_currentDept.DeptID), Convert.ToInt32(_currentUser.EmployeeID));
            modelapply.ShowDialog();
            List<int> applyModels = modelapply.checkedmodels;
            string notValidItmes = "";       
            for (int i = 0; i < applyModels.Count; i++)
            {
                DataTable dt = PublicFeeModel.GetFeeModelList(applyModels[i]);
                for (int j = 0; j < dt.Rows.Count; j++)
                {       
                    DataRow [] rows=itemdt.Select(" item_id="+Convert.ToInt32(dt.Rows[j]["item_id"])+" and item_type="+Convert.ToInt32(dt.Rows[j]["item_type"])+"");
                    if (rows == null || rows.Length == 0)
                    {
                        notValidItmes = notValidItmes + "," + dt.Rows[j]["item_name"].ToString();
                        continue;
                    }
                    if (tabPageControl1.SelectedIndex == 0)
                    {
                        int rowIndexLong = dataGridViewEx2.Rows.Count;
                        if (rowIndexLong == 0 || dataGridViewEx2[Column5.Name, rowIndexLong - 1].Value != null)
                        {
                            dataGridViewEx2.Rows.Add();
                            dataGridViewEx2.CurrentCell = dataGridViewEx2[2, rowIndexLong];
                            dataGridViewEx2.Focus();
                        }
                        else
                        {
                            dataGridViewEx2.CurrentCell = dataGridViewEx2[2, rowIndexLong - 1];
                            dataGridViewEx2.Focus();
                            rowIndexLong -= 1;
                        }
                        dataGridViewEx2["column3", rowIndexLong].Value = dt.Rows[j]["item_id"];
                        // dataGridViewEx2["column4", rowIndexLong].Value = dt.Rows[j]["item_type"];
                        dataGridViewEx2["column6", rowIndexLong].Value = dt.Rows[j]["amount"];
                        if (dt.Rows[j]["item_type"].ToString().Trim() == "8")
                        {
                            dataGridViewEx2["column4", rowIndexLong].Value = "护理";
                        }
                        else if (dt.Rows[j]["item_type"].ToString().Trim() == "9")
                        {
                            dataGridViewEx2["column4", rowIndexLong].Value = "其它";
                        }
                        else if (dt.Rows[j]["item_type"].ToString().Trim() == "0")
                        {
                            dataGridViewEx2["column4", rowIndexLong].Value = "物资";
                        }
                        dataGridViewEx2["column5", rowIndexLong].Value = rows[0]["order_name"].ToString().Trim();
                        dataGridViewEx2["column7", rowIndexLong].Value = rows[0]["price"];
                        dataGridViewEx2["column8", rowIndexLong].Value = rows[0]["order_unit"];
                        dataGridViewEx2["column9", rowIndexLong].Value = rows[0]["DEFAULT_USAGE"];
                        dataGridViewEx2["column20", rowIndexLong].Value = rows[0]["TC_FLAG"];
                        dataGridViewEx2["execdept_code", rowIndexLong].Value = Convert.ToInt32(XcConvert.IsNull(rows[0]["execdept_code"], _currentDept.DeptID.ToString()));
                    }
                    else if (tabPageControl1.SelectedIndex == 1)
                    {
                        int rowIndexTemp = dataGridViewEx3.Rows.Count;
                        if (rowIndexTemp == 0 || dataGridViewEx3[Column15.Name, rowIndexTemp - 1].Value != null)
                        {
                            dataGridViewEx3.Rows.Add();
                            dataGridViewEx3.CurrentCell = dataGridViewEx3[2, rowIndexTemp];
                            dataGridViewEx3.Focus();
                        }
                        else
                        {
                            dataGridViewEx3.CurrentCell = dataGridViewEx3[2, rowIndexTemp - 1];
                            dataGridViewEx3.Focus();
                            rowIndexTemp -= 1;
                        }
                        dataGridViewEx3["column13", rowIndexTemp].Value = dt.Rows[j]["item_id"];
                        // dataGridViewEx3["column14", rowIndexTemp].Value = dt.Rows[j]["item_type"];
                        dataGridViewEx3["column16", rowIndexTemp].Value = dt.Rows[j]["amount"];
                        if (dt.Rows[j]["item_type"].ToString().Trim() == "8")
                        {
                            dataGridViewEx3["column14", rowIndexTemp].Value = "护理";
                        }
                        else if (dt.Rows[j]["item_type"].ToString().Trim() == "9")
                        {
                            dataGridViewEx3["column14", rowIndexTemp].Value = "其它";
                        }
                        else if (dt.Rows[j]["item_type"].ToString().Trim() == "0")
                        {
                            dataGridViewEx3["column14", rowIndexTemp].Value = "物资";
                        }
                        dataGridViewEx3["column15", rowIndexTemp].Value = rows[0]["order_name"].ToString().Trim();
                        dataGridViewEx3["column17", rowIndexTemp].Value = rows[0]["price"];
                        dataGridViewEx3["column18", rowIndexTemp].Value = rows[0]["order_unit"];
                        dataGridViewEx3["column19", rowIndexTemp].Value = rows[0]["DEFAULT_USAGE"];
                        dataGridViewEx3["execdept_code1", rowIndexTemp].Value = Convert.ToInt32(XcConvert.IsNull(rows[0]["execdept_code"], _currentDept.DeptID.ToString()));
                    }
                }
            }
            if (notValidItmes.Trim() != "")
            {
                MessageBox.Show(""+notValidItmes+"现已不存在，应用时已过滤 ,请及时更新模板!");
            }
        }

        private void FrmFeeInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                btnNew_Click(null, null); 
            }
            else if (e.KeyCode == Keys.F3)
            {
                btnSave_Click(null, null);
            }
            else if (e.KeyCode == Keys.F4)
            {
                btnDel_Click(null, null);
            }
            else if (e.KeyCode == Keys.F5)
            {
                btnSend_Click(null, null);
            }
            else if (e.KeyCode == Keys.F6)
            {
                btnExit_Click(null, null);
            }
            else if (e.KeyCode == Keys.F7)
            {
                btnModelApply_Click(null, null);
            }
        }

        private void FrmFeeInput_Load(object sender, EventArgs e)
        {
            dtAllItems = itemdt.Clone();
            for (int i = 0; i < itemdt.Rows.Count; i++)
            {
                dtAllItems.Rows.Add(itemdt.Rows[i].ItemArray);
            }

            Op_BaseData basedata = new Op_BaseData();

            DataTable yf = basedata.GetYfName();
            if (yf == null || yf.Rows.Count == 1)
            {
                this.cbYf.Text = "全部药房";
                this.cbYf.Visible = false;
                this.lbyf.Visible = false;
            }
            else
            {
                this.cbYf.Visible = true;
                this.lbyf.Visible = true;
                this.cbYf.DisplayMember = "Name";
                this.cbYf.ValueMember = "Value";
                cbYf.DataSource = basedata.Get_dept_yfName(Convert.ToInt32(_currentDept.DeptID));
                this.cbYf.SelectedIndex = 0;
            }
        }

        private void cbYf_SelectedIndexChanged(object sender, EventArgs e)
        {
            string yfIds = (this.cbYf.SelectedValue == null ? -1 : this.cbYf.SelectedValue).ToString().Trim();
            itemdt.Clear();
            //新增判断药房科室
            if (yfIds != "-1")
            {
                DataRow[] dr = dtAllItems.Select("item_type >3 or execdept_code in ( " + yfIds + ")");
                for (int i = 0; i < dr.Length; i++)
                {
                    itemdt.Rows.Add(dr[i].ItemArray);
                }
            }
            else
            {
                for (int i = 0; i < dtAllItems.Rows.Count; i++)
                {
                    itemdt.Rows.Add(dtAllItems.Rows[i].ItemArray);
                }
            }
        }
    }
}
