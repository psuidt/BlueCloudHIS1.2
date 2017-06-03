using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.PubicBaseClasses;
using System.Windows.Forms;
using HIS.SYSTEM.BussinessLogicLayer.Classes;

namespace HIS_ZYDocManager.Action
{
    public class ControllerMethod
    {
       
        DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());
        #region 皮试赋值
        /// <summary>
        /// 皮试赋值
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="itemtype"></param>
        /// <param name="usage"></param>
        /// <param name="frequency"></param>
        /// <param name="amount"></param>
        /// <param name="psid"></param>
        /// <param name="itemname"></param>
        /// <param name="itemid"></param>
        /// <param name="execdept"></param>
        /// <param name="ps_flag"></param>
        /// <param name="order_spec"></param>
        /// <param name="unit"></param>
        public void GivePsRowData(DataRow dr, int itemtype, string usage, string frequency, decimal amount,
                               decimal psid, string itemname, int itemid, int execdept, int ps_flag, string order_spec, string unit)
        {
            dr["BeginTime"] = XcDate.ServerDateTime;
            dr["item_type"] = itemtype;
            dr["order_content"] = itemname;
            dr["makedicid"] = itemid;
            dr["usage"] = usage;
            dr["order_usage"] = usage;
            dr["frequency"] = frequency;
            dr["Frency"] = "";
            dr["order_type"] = 1;
            dr["status_falg"] = -1;
            dr["pres_amount"] = 1;
            dr["PresNum"] = 1;
            dr["amount"] = amount;
            dr["firset_times"] = DBNull.Value;
            dr["First"] = DBNull.Value;
            dr["unit"] = unit;
            dr["exec_dept"] = execdept;
            dr["ps_flag"] = ps_flag;
            dr["order_spec"] = order_spec;
            dr["ps_orderid"] = psid;
            dr["orditem_id"] = 0;
        }
        #endregion

        #region 置空值
        /// <summary>
        /// 置空值
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="sign"></param>
        public void SetNull(DataRow dr, int sign)
        {
            dr["last"] = DBNull.Value;
            dr["ExeNurse"] = DBNull.Value;
            dr["trans_date"] = DBNull.Value;
            dr["eorder_date"] = DBNull.Value;
            dr["teminal_times"] = DBNull.Value;
            dr["EOrderDocName"] = DBNull.Value;
            dr["eorder_doc"] = DBNull.Value;
            if (sign == 1)
            {
                dr["usage"] = DBNull.Value;
                dr["Frency"] = DBNull.Value;
                dr["First"] = DBNull.Value;
                dr["PresNum"] = DBNull.Value;
            }
        }
        #endregion

        #region 网格赋值
        /// <summary>
        /// 网格赋值
        /// </summary>
        /// <param name="record"></param>
        /// <param name="dr"></param>
        /// <param name="dt"></param>
        /// <param name="rowid"></param>
        /// <param name="OrderType"></param>
        public void CardData(HIS.Model.zy_doc_orderrecord_son record, DataRow dr, DataTable dt, int rowid, int OrderType)
        {
            record.ORDER_CONTENT = XcConvert.IsNull(dr["ITEMNAME"], "");
            record.ORDER_TYPE = OrderType;
            record.EXEC_DEPT = Convert.ToInt32(XcConvert.IsNull(dr["EXECDEPTCODE"], "0"));
            record.ITEM_TYPE = Convert.ToInt32(XcConvert.IsNull(dr["order_type"], ""));
            record.UNIT = XcConvert.IsNull(dr["doseunit"], "");
            record.UNITTYPE = 0;
            record.ORDER_PRICE = Convert.ToDecimal(XcConvert.IsNull(dr["sell_price"], "0"));
            //record.PRES_DEPTID = deptid;
            //record.ORDER_DOC = employid;
            record.OrderDocName = HIS.ZYDoc_BLL.GetName.GetEmployname(record.ORDER_DOC.ToString());// BaseData.GetUserName(record.ORDER_DOC);
            record.PRES_AMOUNT = 1;
            record.AMOUNT = Convert.ToDecimal(dr["dosenum"]);
            record.PresNum = 1;
            record.STATUS_FALG = -1;
            record.ITEM_CODE = XcConvert.IsNull(dr["statitem_code"], "");
            record.ORDER_SPEC = XcConvert.IsNull(dr["standard"], "");

            if (Convert.ToInt32(dr["tc_flag"]) == 1)
            {
                record.TC_ID = Convert.ToInt32(dr["server_item_id"]);
            }
            else
            {
                record.TC_ID = 0;
            }
            if (record.ORECORD_A2 != 2)
            {
                record.GROUP_ID = -1;
                record.ORECORD_A2 = 0;
                record.PRES_AMOUNT = 1;
                record.PresNum = 1;
            }
            if (Convert.ToInt16(dr["order_type"]) > 3)
            {
                record.SEVERS_ID = Convert.ToInt32(XcConvert.IsNull(dr["server_item_id"], "0"));
                record.ORDITEM_ID = Convert.ToInt32(XcConvert.IsNull(dr["itemid"], "0"));
                record.MAKEDICID = 0;
                record.FIRSET_TIMES = 1;
                record.First = 1;
            }
            if (!IsGroupFirstRow(dt, rowid))//如果不是一组的第一行
            {
                record.FREQUENCY = XcConvert.IsNull(dt.Rows[rowid - 1]["FREQUENCY"].ToString(), "");
                record.ORDER_USAGE = XcConvert.IsNull(dt.Rows[rowid - 1]["order_usage"].ToString(), "");
                record.FIRSET_TIMES = Convert.ToInt32(XcConvert.IsNull(dt.Rows[rowid - 1]["firset_times"].ToString(), "1"));
                record.PRES_AMOUNT = Convert.ToDecimal(XcConvert.IsNull(dt.Rows[rowid - 1]["pres_amount"].ToString(), "1"));
            }
        }
        #endregion

        #region 判断是否是一组的第一行
        /// <summary>
        /// 判断是否是一组的第一行
        /// </summary>
        /// <param name="myTb"></param>
        /// <param name="nrow"></param>
        /// <returns></returns>
        private bool IsGroupFirstRow(DataTable myTb, int nrow)
        {
            if (nrow == 0) return true;
            if (myTb.Rows[nrow]["BeginTime"].ToString().Trim() != timeformat.ToString() ||
                myTb.Rows[nrow]["order_content"].ToString().Trim() == "术后医嘱" || myTb.Rows[nrow]["order_content"].ToString().Trim() == "产后医嘱"
                || myTb.Rows[nrow]["item_type"].ToString() == "7")
            {
                return true;//上一列无内容
            }
            return false;
        }
        #endregion      

        #region 交病人和出院带药的判断
        /// <summary>
        /// 交病人和出院带药的判断
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="nrow"></param>
        /// <param name="struc"></param>
        /// <param name="order_type"></param>
        /// <returns></returns>
        public bool ChangeOrderKind(HIS.Model.ZY_DOC_ORDERRECORD record, string struc, string order_type)
        {
            if (record.ORDER_CONTENT == null || record.ORDER_CONTENT == "")
            {
                MessageBox.Show("请选择医嘱内容");
                return false;
            }
            if (record.ITEM_TYPE > 3)
            {
                MessageBox.Show("" + struc + "的只能是药品！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (record.EXEC_DEPT == -1) //标为自备的药品不能再置交病人和出院带药　2010.3.19
            {
                MessageBox.Show("该药品已为自备药，不能再" + struc + "", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            if (record.STATUS_FALG == -1 || record.STATUS_FALG > 1)
            {
                MessageBox.Show("该医嘱还未保存，已转抄或执行，不能交病人");
                return false;
            }
            else if (record.ORDER_TYPE == 5 || record.ORDER_TYPE == 7)
            {
                MessageBox.Show("该药品已经被指定，不能重新指定。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (record.STATUS_FALG > 3)
            {
                MessageBox.Show("医嘱选择错误！只能是药品医嘱。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (MessageBox.Show("你确定要将" + record.ORDER_CONTENT + struc + "？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        #endregion
    }
}
