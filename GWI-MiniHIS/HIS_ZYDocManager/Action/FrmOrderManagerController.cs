using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYDoc_BLL;
using GWI.HIS.Windows.Controls;

namespace HIS_ZYDocManager.Action
{
    public class FrmOrderManagerController : PublicController
    {
        private IFrmOrderManagerView view;
        private DataSet _dataSet;     
        private HIS.Model.ZY_PatList zy_Patlist;
        public DateTime timeformat = Convert.ToDateTime(Convert.ToDateTime("0001-1-1 0:00:00").ToShortDateString() + " " + Convert.ToDateTime("0001-1-1 0:00:00").ToLongTimeString());
        MessagePromptManager.Messenger senders;　
        MessagePromptManager.Messenger receiver;
        private int deptid=0;
        private int employid = 0;
        private ControllerMethod controlmethod;
        private HIS.ZYDoc_BLL.OrderInfo.IOrderOP OpOrder;
        private HIS.ZYDoc_BLL.BaseInfo.ShowCardBase showcardbase;        
        public FrmOrderManagerController(IFrmOrderManagerView _view)
        {
            view = _view;
            _dataSet = new DataSet();
            deptid = Convert.ToInt32(view.currentDept.DeptID);
            employid = Convert.ToInt32(view.currentUser.EmployeeID);
            zy_Patlist = view.zy_patlist_get;
            OpOrder = new HIS.ZYDoc_BLL.OrderInfo.OrderOperation();
            showcardbase = new HIS.ZYDoc_BLL.BaseInfo.ShowCardBase();         
            LoadINFO();
            senders = new MessagePromptManager.Messenger(view.currentUser.UserID, view.currentDept.DeptID, "");
            receiver = new MessagePromptManager.Messenger(-1, view.currentDept.DeptID, "");
            controlmethod = new ControllerMethod();

            //this.GetCourseCount();
           // this.GetEmr(0);

        }
        //重新获得病人信息实体
        public void SetPatlist()
        {
            zy_Patlist = view.zy_patlist_get;
        }
        #region 初始化数据
        public void LoadINFO()
        {  
            _dataSet = showcardbase.LoadBaseINFO();         
            view.Initialize(_dataSet);
        }
        //刷新基础数据选项卡
        public void ReloadINFO()
        {
            _dataSet = showcardbase.ReloadInfo();
            view.Initialize(_dataSet);
        }
        #region 根据ID获得药品单位信息
        /// <summary>
        /// 根据ID获得药品单位信息
        /// </summary>
        /// <param name="itemid"></param>
        /// <param name="itemtype"></param>
        public void GetDwType(int itemid, int itemtype)
        {
            _dataSet = showcardbase.GetDwType(itemid, itemtype);
        }
        #endregion      
     
        public void YfSelect(int orderkind)
        {
            _dataSet = showcardbase.YfSelect(orderkind, view.GetYfIds);
        }
        public void RowsInsert(int orderkind,int sign,int item_type)
        {
            _dataSet = showcardbase.AddRows(orderkind,sign, item_type); 
        }
        #endregion

        #region 对医嘱的操作
        #region   新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="orderkind"></param>
        /// <param name="sign">0=按新开按钮。1=按回车新开</param>
        /// <returns></returns>
        public int AddRow(int orderkind, int sign)
        {             
            DataTable dt= this.GetOrderTable(orderkind);
            if (sign != 0)
            {
                _dataSet = OpOrder.AddRows(orderkind, sign, Convert.ToInt16(dt.Rows[dt.Rows.Count - 1]["item_type"]));
            }
            else
            {
                _dataSet = OpOrder.AddRows(orderkind, sign, 0);
            }
            int rowid;
            if (dt != null && dt.Rows.Count > 0)
            {
                rowid = dt.Rows.Count - 1;
                if (dt.Rows[rowid]["order_content"].ToString().Trim() == "")	//最后一行不为空才允许新增一行
                {
                    if (sign == 0)
                    {
                        dt.Rows[rowid]["BeginTime"] = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;                       
                        controlmethod.SetNull(dt.Rows[rowid], 1);
                        dt.Rows[rowid]["amount"] = DBNull.Value;
                    }
                    return rowid;
                }
                else
                {
                    List<HIS.Model.zy_doc_orderrecord_son> _zyorderrecordSon = new List<HIS.Model.zy_doc_orderrecord_son>();
                    HIS.Model.zy_doc_orderrecord_son son = new HIS.Model.zy_doc_orderrecord_son();
                    if (sign == 0)     //如果是按新开按钮，录入时间显示。如果是按回车，录入时间显示为空
                    {
                        son.BeginTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                    }
                    if (sign == 1)
                    {
                        son.BeginTime = timeformat;
                    }
                    _zyorderrecordSon.Add(son);
                    DataTable ddt = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_zyorderrecordSon);
                    controlmethod.SetNull(ddt.Rows[0], 1);
                    ddt.Rows[0]["amount"] = DBNull.Value;
                    dt.Rows.Add(ddt.Rows[0].ItemArray);
                    rowid = dt.Rows.Count - 1;
                    return rowid;
                }
            }
            else
            {
                List<HIS.Model.zy_doc_orderrecord_son> _zyorderrecordSon = new List<HIS.Model.zy_doc_orderrecord_son>();
                HIS.Model.zy_doc_orderrecord_son son = new HIS.Model.zy_doc_orderrecord_son();
                son.BeginTime = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                _zyorderrecordSon.Add(son);
               DataTable ddt = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(_zyorderrecordSon);
               controlmethod.SetNull(ddt.Rows[0], 1);
                if (orderkind == 0)
                {
                    view.BindLongOrderData = null;
                    view.BindLongOrderData = ddt;
                    dt = view.BindLongOrderData;
                }
                if (orderkind == 1)
                {
                    view.BindTempOrderData = null;
                    view.BindTempOrderData = ddt;
                    dt = view.BindTempOrderData;
                }
                controlmethod.SetNull(ddt.Rows[0], 1);
            }
            rowid = dt.Rows.Count - 1;          
            return rowid;
        }
        #endregion

        #region 保存医嘱
        /// <summary>
        /// 保存医嘱
        /// </summary>
        /// <param name="ordertype"></param>
        public bool SaveOrder(int ordertype,out int colid,out int rowid)
        {         
            List<HIS.Model.zy_doc_orderrecord_son> records = TableToSon(ordertype);
            colid = 0;
            rowid = 0;
            if (records == null || records.Count == 0)
            {
                return true ;
            }
            string SaveDiscription = "";
            WrongDecline wrong= OpOrder.Save(deptid, ordertype, zy_Patlist, out SaveDiscription);
            if (wrong.err != "0")
            {
                MessageBox.Show(wrong.err);
                colid = wrong.colid;
                rowid = wrong.rowid;
                return false;
            }
            else
            {
                if (SaveDiscription != "")
                {
                    MessageBox.Show(SaveDiscription);
                }
                colid = 0;
                rowid = 0;
                ModelToTable(records, ordertype); 
                return true;
            }
        }
        #endregion

        #region 发送医嘱
        /// <summary>
        /// 医嘱发送
        /// </summary>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        public bool SendOrder(int ordertype)
        {           
            int index = -1;
            if (MessageBox.Show("您确认检查完毕吗?", "审核", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }
            List<HIS.Model.zy_doc_orderrecord_son> records = TableToSon(ordertype);           
            string content = OpOrder.Send(out index);
            if (index != -1)
            {
                MessageBox.Show("还有未保存的医嘱+'" +records[index].ORDER_CONTENT + "'，请先保存");
                return false;
            }
            if (content != "")
            {
                MessageBox.Show("" + content + "发送成功！");
                ModelToTable(records, ordertype);       
                this.MessageTell("有新医嘱需要处理，请注意查收");
                return true;
            }
            return false;
        }
        #endregion     
       
        #region 医嘱取消删除
        /// <summary>
        ///  删除取消医嘱
        /// </summary>
        /// <param name="rowindex"></param>
        /// <param name="orderkind"></param>
        /// <param name="sign">0=删除一条 1=删除一组</param>
        public bool DelOrder(DataTable dt, int rowindex, int orderkind, int sign)
        {
            List<HIS.Model.zy_doc_orderrecord_son> records = TableToSon(orderkind);
            if (records[rowindex].STATUS_FALG > 1)
            {
                MessageBox.Show("该医嘱已执行，不能删除");
                return true;
            }
            if (records[rowindex].ORDER_CONTENT==null || records[rowindex].ORDER_CONTENT=="")
            {
                records[rowindex].DELETE_FLAG = 1;  
                AfterDelete(records, orderkind);
                return true;
            }           
          
            if (MessageBox.Show("确实要删除"+"["+records[rowindex].ORDER_CONTENT+"]"+"吗", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                if (records[rowindex].ORDER_DOC!=0 && records[rowindex].ORDER_DOC != employid) // * 20100919.1.09 医生删除时，限制只能删除本医生开的医嘱
                {
                    string docname = HIS.SYSTEM.BussinessLogicLayer.Classes.BaseData.GetUserName(records[rowindex].ORDER_DOC.ToString());
                    MessageBox.Show("" + records[rowindex].ORDER_CONTENT + "是由" + docname + "开的医嘱，只能由" + docname + "删除！");
                    return false;
                }
                bool isout=false;
                if (OpOrder.Delete (zy_Patlist, rowindex, sign, deptid, employid,out isout))
                {
                    if (isout)
                    {
                        view.zy_patlist_get = HIS.ZYDoc_BLL.PatInfo.PatOperation.GetNewPatModel(zy_Patlist.PatListID);  //病人状态改变后，重新获得病人信息实体
                            this.SetPatlist();                        
                        view.BindLongOrderData = null;
                    }  
                    AfterDelete(records, orderkind);
                    return true;
                }
            }
            return false;           
        }
        #endregion

        #region 医嘱复制
        /// <summary>
        /// 医嘱复制
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowindex"></param>
        public void Copy(DataTable dt, int rowindex)
        {
            int beginNum = 0;
            int endNum = 0;
            DateTime begintime = XcDate.ServerDateTime;
           FindBeginEnd(rowindex, dt, ref beginNum, ref endNum);
            DataRow dr = dt.NewRow();
            dr.ItemArray = dt.Rows[beginNum].ItemArray;

            if (Convert.ToInt32(dr["MAKEDICID"].ToString()) != 0) //add by heyan 2010.12.2医嘱复制时判断药品库存
            {
                if (!drugbase.CanPresZero())
                {
                    if (drugbase.GetStoreNum(Convert.ToInt32(dr["MAKEDICID"].ToString()), Convert.ToInt32(dr["item_type"].ToString()), Convert.ToInt32(dr["EXEC_DEPT"])) <= 0)
                    {
                        MessageBox.Show("不允许开药品库存为0的药品，请选择其他药品!");
                        return;
                    }
                }          
            }
            dr["begintime"] = begintime;
            dr["orecord_a2"] = 0;
            dr["status_falg"] = -1;
            dr["last"] = DBNull.Value;
            dr["ExeNurse"] = DBNull.Value;
            dr["trans_date"] = DBNull.Value;
            dr["eorder_date"] = DBNull.Value;
            dr["teminal_times"] = DBNull.Value;
            dr["EOrderDocName"] = DBNull.Value;
            dr["eorder_doc"] = DBNull.Value;
            dr["order_doc"] = Convert.ToInt32(employid);          
            dr["pres_deptid"] = deptid;
            dr["TRANS_NURSE"] = 0;
            dr["ps_orderid"] = 0;
            dr["ps_flag"] = 0;
            dr["noexe_flag"] = 0;
            dt.Rows.Add(dr);
            for (int i = beginNum + 1; i <= endNum; i++)
            {
                dr = dt.NewRow();
                dr.ItemArray = dt.Rows[i].ItemArray;
                if (Convert.ToInt32(dr["MAKEDICID"].ToString()) != 0)
                {
                    if (!drugbase.CanPresZero())
                    {
                        if (drugbase.GetStoreNum(Convert.ToInt32(dr["MAKEDICID"].ToString()), Convert.ToInt32(dr["item_type"].ToString()), Convert.ToInt32(dr["EXEC_DEPT"])) <= 0)
                        {
                            MessageBox.Show("不允许开药品库存为0的药品，请选择其他药品!");
                            return;
                        }
                    }
                }
                dr["begintime"] = Convert.ToDateTime(dr["begintime"].ToString());
                dr["orecord_a2"] = 0;
                dr["status_falg"] = -1;
                dr["last"] = DBNull.Value;
                dr["ExeNurse"] = DBNull.Value;
                dr["trans_date"] = DBNull.Value;
                dr["eorder_date"] = DBNull.Value;
                dr["teminal_times"] = DBNull.Value;
                dr["EOrderDocName"] = DBNull.Value;
                dr["eorder_doc"] = DBNull.Value;
                dr["order_doc"] = Convert.ToInt32(employid);               
                dr["pres_deptid"] = deptid;
                dr["TRANS_NURSE"] = 0;
                dr["ps_orderid"] = 0;
                dr["ps_flag"] = 0;
                dr["noexe_flag"] = 0;
                dt.Rows.Add(dr);
            }
        }
        #endregion

        #region 出院带药和交病人
        /// <summary>
        /// 出院带药和交病人
        /// </summary>
        /// <param name="nrow"></param>
        /// <param name="ncon"></param>
        /// <param name="orderkind"></param>
        /// <param name="struc"></param>
        /// <param name="ordertype"></param>
        /// <returns></returns>
        public bool OrderToPat(int nrow,int ncon,int orderkind,string struc,string ordertype)
        {          
            List<HIS.Model.ZY_DOC_ORDERRECORD> records = TableToModel(1); 
            if (!controlmethod.ChangeOrderKind(records[nrow], struc , ordertype))
            {
                return false;
            }
            if (ordertype == "5")
            {
                return OpOrder.GivePatient(nrow);
            }
            else
            {
                return OpOrder.TakeOut(nrow);
            }
        }
        #endregion

        #region 停嘱执行
        /// <summary>
        ///  停嘱执行
        /// </summary>
        /// <param name="nrow"></param>
        /// <param name="num"></param>
        /// <param name="dtime"></param>
        /// <param name="userid"></param>
        /// <param name="sign"> 0＝停止1=取消停</param>
        /// <returns></returns>
        public bool StopOrders(int nrow, int num, DateTime dtime, int groupid, int sign)
        {          
            List<HIS.Model.ZY_DOC_ORDERRECORD> records = TableToModel(0);                      
            if (sign == 0)
            {
                if (OpOrder.Stop(groupid,num,employid,dtime,employid))
                {                    
                    MessageTell("有已停医嘱需要处理，请注意查收");
                    return true;
                }
            }
            if (sign == 1)
            {
                if (OpOrder.CancelStop(groupid, zy_Patlist.PatListID))
                {
                    MessageBox.Show("取消停医嘱成功！");
                    return true;
                }
                else
                {
                    MessageBox.Show("该组医嘱是术后、产后或转科自动停止的，不允许取消停！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return false;
        }
        #endregion

        #region 右键插入皮试医嘱
        /// <summary>
        /// 右键插入皮试医嘱
        /// </summary>
        /// <param name="myTb"></param>
        /// <param name="nrow"></param>
        /// <param name="orderkind"></param>
        public void OnInsertPS(DataTable myTb, int nrow, int orderkind)
        {
            #region 判断是否皮试药品
            bool ps = false;
            HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
            record = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(myTb, nrow, record);
            if (record.ITEM_TYPE == 1)
            {
                ps = drugbase.IsPsDrug(record.MAKEDICID, 1);
                if (ps != true)
                {
                    MessageBox.Show("不是皮试药品！", "选择错误！", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;//不是皮试药品就退出
                }
            }
            else
            {
                MessageBox.Show("皮试药品只能是西药");
                return;
            }
            #endregion
            DateTime dTime = XcDate.ServerDateTime;
            decimal strDate = Convert.ToDecimal(dTime.ToString("yyyyMMddHHmmss.ffffff"));
            if (record.ORDER_USAGE != "皮试用")
            {
                myTb.Rows[nrow]["ps_orderid"] = strDate;
                myTb.Rows[nrow]["ps_flag"] = 0;
            }
            string con = record.ORDER_CONTENT.Trim();
            try
            {
                List<HIS.Model.ZY_DOC_ORDERRECORD> records = new List<HIS.Model.ZY_DOC_ORDERRECORD>();                
                record.PS_FLAG = 0;
                record.PS_ORDERID = strDate;
                int Ind = con.IndexOf("(免试)");
                if (Ind >= 0)
                {
                    con = con.Remove(Ind, "(免试)".Length);
                }
                myTb.Rows[nrow]["order_content"] = con;
                record.ORDER_CONTENT = con;
                records.Add(record);
                if (record.STATUS_FALG != -1)
                {
                    OpOrder.records = records;
                    if (!OpOrder.UpDate())
                    {
                        MessageBox.Show("添加皮试失败！", "失败提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        myTb.Rows[nrow]["ps_flag"] = -1;
                        myTb.Rows[nrow]["ps_orderid"] = 0;
                        return;
                    }
                }
            }
            catch
            {
                MessageBox.Show("添加皮试失败！", "失败提示", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                myTb.Rows[nrow]["ps_flag"] = -1;
                myTb.Rows[nrow]["ps_orderid"] = 0;
                return;
            }
            InsertPSYZ(1, con, strDate, orderkind, nrow, record.MAKEDICID);
            MessageBox.Show("添加皮试完成！\n请注意保存、发送自动生成的皮试医嘱！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 作废医嘱
        public bool AbolishOrder(DataTable dt,int nrow)
        {
            HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
            record = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, nrow, record);
            if (OpOrder.Abolish(record))
            {
                MessageBox.Show("医嘱作废成功！\n已记帐的费用请护士冲正。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
        }
        #endregion

        #region 术后、产后医嘱
        public bool AfterOperation(string order_content)
        {
            return OpOrder.AfterOperation(order_content, Convert.ToInt32(zy_Patlist.CurrDeptCode), deptid, employid, zy_Patlist.PatListID);
        }
        #endregion

        #region 增加脚注
        /// <summary>
        /// 增加脚注
        /// </summary>
        /// <param name="tb">表</param>
        /// <param name="nrow">表行号</param>
        /// <param name="note">脚注名称</param>
        public void AddJz(int nrow, string note)
        {
            DataTable tb = view.BindTempOrderData;        
            string str = tb.Rows[nrow]["order_content"].ToString().Trim() + " ";
            if (str.IndexOf("【") > 0)
            {
                str = str.Substring(0, str.IndexOf("【"));
            }
            tb.Rows[nrow]["order_content"] = str + " 【" + note + "】";
            List<HIS.Model.ZY_DOC_ORDERRECORD> order_record = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
            record = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(tb, nrow, record);
            record.ORDER_CONTENT = tb.Rows[nrow]["order_content"].ToString().Trim();
            order_record.Add(record);
            if (record.STATUS_FALG >= 0)
            {
                OpOrder.records = order_record;
                OpOrder.UpDate();
            }
        }
        #endregion

        #endregion

        #region 网格赋值
        /// <summary>
        /// 赋值
        /// </summary>
        /// <param name="OrderType"></param>
        /// <param name="rowid"></param>
        /// <param name="dr"></param>
        /// <returns></returns>
        public int SelectCardBindData(int orderkind, int rowid, DataRow dr, int columnid)
        {
            DataTable dt = null;
            dt = this.GetOrderTable(orderkind);
            int colid;
            bool pscl = false;
            HIS.Model.zy_doc_orderrecord_son record = new HIS.Model.zy_doc_orderrecord_son();
            record = (HIS.Model.zy_doc_orderrecord_son)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, rowid, record);
            switch (columnid)
            {
                case 2:
                    if (Convert.ToInt32(dr["order_type"].ToString()) < 4)
                    {
                        if (!drugbase.CanPresZero())
                        {
                            if (Convert.ToDecimal(dr["storenum"].ToString()) <= 0)
                            {
                                MessageBox.Show("不允许开药品库存为0的药品，请选择其他药品!");
                                colid = 2;
                                break;
                            }
                        }
                        if (Convert.ToInt32(dr["order_type"].ToString()) < 3)
                        {
                            this.GetDwType(Convert.ToInt32(dr["itemid"].ToString()),Convert.ToInt32(dr["order_type"].ToString()));
                        }
                    }
                    record.PRES_DEPTID = deptid;
                    record.ORDER_DOC = employid; 
                    controlmethod.CardData(record, dr,dt,rowid,orderkind);                    
                    if (Convert.ToInt16(dr["order_type"].ToString().Trim()) < 4)
                    {
                        record.MAKEDICID = Convert.ToInt32(dr["itemid"]);
                        record.ORDITEM_ID = 0;
                        record.SEVERS_ID = 0;
                        if (Convert.ToInt16(dr["skintest_flag"]) == 1)
                        {
                            if (MessageBox.Show("该药品是需要皮试的药品，你要开‘皮试’医嘱吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                            {
                                
                                pscl = true;
                                DateTime dTime = XcDate.ServerDateTime;
                                decimal strDate = Convert.ToDecimal(dTime.ToString("yyyyMMddHHmmss.ffffff"));
                                record.PS_FLAG = 0;
                                record.PS_ORDERID = strDate;
                                List<HIS.Model.zy_doc_orderrecord_son> records = new List<HIS.Model.zy_doc_orderrecord_son>();
                                records.Add(record);
                                DataTable table = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(records);
                                dt.Rows[rowid].ItemArray = table.Rows[0].ItemArray;
                                controlmethod.SetNull(dt.Rows[rowid], 0);
                                InsertPSYZ(Convert.ToInt16(dr["order_type"]), dr["ITEMNAME"].ToString(), strDate, orderkind, rowid, Convert.ToInt32(dr["itemid"].ToString()));
                                if (MessageBox.Show("是否开皮试用药？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                {
                                    InsertPSYY(Convert.ToInt32(dr["order_type"].ToString()), XcConvert.IsNull(dr["ITEMNAME"], ""), Convert.ToDecimal(dr["dosenum"].ToString()),
                                        XcConvert.IsNull(dr["doseunit"], ""), XcConvert.IsNull(dr["EXECDEPTCODE"], "0"), XcConvert.IsNull(dr["standard"], ""), XcConvert.IsNull(dr["itemid"], "0"), dTime, orderkind, rowid);
                                }
                            }
                            else
                            {
                                record.ORDER_CONTENT = record.ORDER_CONTENT + "(免试)";
                                record.PS_FLAG = 3;
                            }
                        }
                        else
                        {
                            record.PS_FLAG = 0;
                            record.PS_ORDERID = 0;
                        }
                    }
                    colid = 3;                   
                    break;
                case 10:                 
                    record.ORDER_STRUC = XcConvert.IsNull(dr["NAME"], "");
                    colid = -1;
                    break;
                case 5:                 
                    record.ORDER_USAGE = XcConvert.IsNull(dr["name"], "");
                    record.Usage = XcConvert.IsNull(dr["name"], "");
                    dt.Rows[rowid]["order_usage"] = XcConvert.IsNull(dr["name"], "");
                    if (IsGroupFirstRow(dt, rowid))
                    {
                        this.ChangeValue(dt, rowid, "Usage");//如果是第一组的每一项，则改变值的同时，这一组的同时改变
                    }
                    colid = 6;
                    break;
                case 6:                 
                    record.FREQUENCY = XcConvert.IsNull(dr["name"], "");
                    record.Frency = XcConvert.IsNull(dr["name"], "");
                    dt.Rows[rowid]["FREQUENCY"] = XcConvert.IsNull(dr["name"], "");
                    if (orderkind == 0)
                    {
                        record.FIRSET_TIMES = base.GetExectime(record.FREQUENCY.ToString());
                        record.First = record.FIRSET_TIMES;
                        dt.Rows[rowid]["FIRSET_TIMES"] = record.FIRSET_TIMES;
                    }
                    if (IsGroupFirstRow(dt, rowid)) //如果是第一组的每一项，则改变值的同时，这一组的同时改变
                    {
                        this.ChangeValue(dt, rowid, "Frency");
                    }
                    colid = 7;
                    break;
                default: colid = -1; break;
            }
            if (orderkind == 1 && columnid == 4) //只有临嘱里边可以修改单位
            {             
                record.UNIT = XcConvert.IsNull(dr["name"], "");
                record.UNITTYPE =Convert.ToInt32( XcConvert.IsNull(dr["dwlx"], "0"));
                colid = 5;
            }
            if (!pscl)
            {
                List<HIS.Model.zy_doc_orderrecord_son> records = new List<HIS.Model.zy_doc_orderrecord_son>();
                records.Add(record);
                DataTable table = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(records);
                dt.Rows[rowid].ItemArray = table.Rows[0].ItemArray;
                controlmethod.SetNull(dt.Rows[rowid], 0);
                if (colid != 7)
                {
                    dt.Rows[rowid]["first"] = DBNull.Value;
                }
                
            }
            return colid;
        }
        #endregion

        #region 私有方法
        #region 显示网格颜色
        /// <summary>
        /// 显示网格颜色
        /// </summary>a
        /// <param name="order"></param>
        /// <param name="rowid"></param>
        /// <param name="colid"></param>
        private void ShowRowColor(HIS.Model.ZY_DOC_ORDERRECORD order, int rowid, int colid)
        {
            if (order.ORDER_CONTENT == "产后医嘱" || order.ORDER_CONTENT == "术后医嘱")
            {
                view.OrderColor = new OrderColor(rowid, -1, System.Drawing.Color.Red, System.Drawing.Color.White);
            }
            else
            {
                switch (order.STATUS_FALG)
                {
                    case -1://修改的医嘱（ 新开未保存的医嘱）
                        if (order.ORECORD_A2 == 2)
                        {
                            view.OrderColor = new OrderColor(rowid, -1, System.Drawing.Color.Black, System.Drawing.Color.Orange);
                        }
                        break;
                    case 0:// 已保存的医嘱
                        view.OrderColor = new OrderColor(rowid, -1, System.Drawing.Color.Black, System.Drawing.Color.Honeydew);
                        break;
                    case 1://已发送的医嘱
                        view.OrderColor = new OrderColor(rowid, -1, System.Drawing.Color.SeaGreen, System.Drawing.Color.White);
                        break;
                    case 2://已转抄的医嘱
                        view.OrderColor = new OrderColor(rowid, -1, System.Drawing.Color.Blue, System.Drawing.Color.White);
                        break;
                    case 3://已停止的长嘱
                        view.OrderColor = new OrderColor(rowid, -1, System.Drawing.Color.Gray, System.Drawing.Color.White);
                        break;
                    case 4://转抄停嘱
                        view.OrderColor = new OrderColor(rowid, -1, System.Drawing.Color.Maroon, System.Drawing.Color.WhiteSmoke);
                        break;
                    case 5://已执行的医嘱
                        view.OrderColor = new OrderColor(rowid, -1, System.Drawing.Color.Black, System.Drawing.Color.WhiteSmoke);
                        break;
                }
            }
        }
        #endregion      

        #region 增加皮试医嘱
        /// <summary>
        /// 增加皮试医嘱 
        /// </summary>
        /// <param name="itemtype"></param>
        /// <param name="itemname"></param>
        /// <param name="strDate"></param>
        /// <param name="ordertype"></param>
        /// <param name="rowid"></param>
        private void InsertPSYZ(int itemtype, string itemname, decimal strDate, int ordertype, int rowid, int itemid)
        {
            DataTable tb = view.BindTempOrderData;
            if (tb == null || tb.Rows.Count == 0)
            {
                this.AddRow(1, 0);
            }
            tb = view.BindTempOrderData;
            DataRow dr = tb.NewRow();
            controlmethod.GivePsRowData(dr, itemtype, "皮试", "", 0, strDate, itemname, itemid, deptid, 0, "", "");
            dr["order_doc"] = employid;
            if (ordertype == 1)
            {
                while (rowid >= 0)
                {
                    if (tb.Rows[rowid]["BeginTime"].ToString() != timeformat.ToString())
                    {
                        tb.Rows.InsertAt(dr, rowid); //在临嘱时，插入该医嘱上一行
                        break;
                    }
                    rowid--;
                }
            }
            else
            {
                int n = tb.Rows.Count;
                while (n > 0 && tb.Rows[n - 1]["order_content"].ToString() == "")
                {
                    view.Plus(0);
                    tb.Rows.Remove(tb.Rows[n - 1]);
                    view.Plus(1);
                    n--;
                }
                tb.Rows.Add(dr);
            }
        }
        #endregion

        #region  增加皮试用药
        /// <summary>
        ///  增加皮试用药
        /// </summary>
        /// <param name="myRow"></param>
        /// <param name="dTime"></param>
        /// <param name="page"></param>
        /// <param name="nrow"></param>
        private void InsertPSYY(int itemtype, string itemname, decimal dosenum, string doseunit, string deptid, string standard, string itemid, DateTime dTime, int ordertype, int rowid)
        {
            DataTable tb = view.BindTempOrderData;
            if (tb == null || tb.Rows.Count == 0)
            {
                this.AddRow(1, 0);
            }
            tb = view.BindTempOrderData;
            DataRow dr = tb.NewRow();           
            controlmethod.GivePsRowData( dr, itemtype, "皮试用", "Qd", dosenum, 0, itemname, Convert.ToInt32(itemid), Convert.ToInt32( deptid), -1, standard,doseunit.ToString().Trim());
            dr["order_doc"] = employid;
            if (ordertype == 1) //本来是在临时医嘱界面上开的皮试
            {
                while (rowid >= 0)
                {
                    if (tb.Rows[rowid]["BeginTime"].ToString() != timeformat.ToString())
                    {
                        tb.Rows.InsertAt(dr, rowid); //在临嘱时，插入该医嘱上一行
                        break;
                    }
                    rowid--;
                }
            }
            else
            {
                int n = tb.Rows.Count;
                while (n > 0 && tb.Rows[n - 1]["order_content"].ToString() == "")
                {
                    view.Plus(0);
                    tb.Rows.Remove(tb.Rows[n - 1]);
                    view.Plus(1);
                    n--;
                }
                tb.Rows.Add(dr);
            }
        }
        #endregion     

        #region 模板赋值
        /// <summary>
        /// 模板赋值
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="_rowIndex"></param>
        /// <param name="model"></param>
        /// <param name="ordertype"></param>
        private void ModelData(DataTable dt, int _rowIndex, HIS.Model.ZY_DOC_ORDERMODELLIST model, int ordertype)
        {
            bool pscl = false;
            HIS.Model.zy_doc_orderrecord_son record = new HIS.Model.zy_doc_orderrecord_son();
            record = (HIS.Model.zy_doc_orderrecord_son)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, _rowIndex, record);            
            OpOrder.ApplyModel(record, model, ordertype, deptid, employid);
            if (model.ITEM_TYPE < 4)
            {
                record.MAKEDICID = model.ITEM_ID;
                record.SEVERS_ID = 0;
                record.ORDITEM_ID = 0;
                record.ORDER_SPEC = drugbase.GetSpec(model.ITEM_ID, model.ITEM_TYPE);
                if (drugbase.IsPsDrug(model.ITEM_ID, model.ITEM_TYPE))
                {
                    pscl = true;
                    List<HIS.Model.zy_doc_orderrecord_son> records = new List<HIS.Model.zy_doc_orderrecord_son>();
                    records.Add(record);
                    DataTable table = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(records);
                    dt.Rows[_rowIndex].ItemArray = table.Rows[0].ItemArray; 
                    PSCL(dt, _rowIndex, model, ordertype);
                }

            }
            else
            {
                record.SEVERS_ID = model.SEVERS_ID;
                record.ORDITEM_ID = model.ITEM_ID;
                record.MAKEDICID = 0;
            }
            if (!pscl)
            {
                List<HIS.Model.zy_doc_orderrecord_son> records = new List<HIS.Model.zy_doc_orderrecord_son>();
                records.Add(record);
                DataTable table = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(records);
                dt.Rows[_rowIndex].ItemArray = table.Rows[0].ItemArray;
            }
        }
        #endregion

        #region 模板中皮试医嘱的处理
        private void PSCL(DataTable dt, int rowid, HIS.Model.ZY_DOC_ORDERMODELLIST modellist, int ordertype)
        {
            if (MessageBox.Show("该模板药品" + dt.Rows[rowid]["order_content"].ToString() + "是需要皮试的药品，你要开‘皮试’医嘱吗？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                DateTime dTime = XcDate.ServerDateTime;
                decimal strDate = Convert.ToDecimal(dTime.ToString("yyyyMMddHHmmss.ffffff"));
                dt.Rows[rowid]["ps_flag"] = 0;
                dt.Rows[rowid]["ps_orderid"] = strDate;
                InsertPSYZ(modellist.ITEM_TYPE, modellist.ITEM_NAME, strDate, ordertype, rowid, modellist.ITEM_ID);
                if (MessageBox.Show("是否开皮试用药？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    InsertPSYY(modellist.ITEM_TYPE, modellist.ITEM_NAME, modellist.AMOUNT, modellist.doseunit, modellist.EXEC_DEPT.ToString(), "", modellist.ITEM_ID.ToString(), dTime, ordertype, rowid);
                }
            }
            else
            {
                dt.Rows[rowid]["order_content"] = dt.Rows[rowid]["order_content"].ToString() + " (免试)";
                dt.Rows[rowid]["ps_flag"] = 3;
            }
        }
        #endregion      
       
        #endregion

        #region  公共方法
        #region 获得病人列表信息
        /// <summary>
        ///  病人列表
        /// </summary>
        public void GetPatlist()
        {
            zy_Patlist = view.zy_patlist_get;
            if (zy_Patlist != null)
            {
                view.BindPatControlData = zy_Patlist;
            }
        }
        #endregion

        #region 获得病人医嘱信息
        /// <summary>
        /// 得到医嘱数据
        /// </summary>
        /// <param name="orderkind"></param>
        public void getOrderData(int orderkind)
        {
            DataTable dt = new DataTable();
            DataTable mytable = OpOrder.GetOrders((OrderType)orderkind,Status.所有, zy_Patlist, deptid);  
            if (mytable == null || mytable.Rows.Count == 0)
            {
                if (orderkind == 0)
                {
                    view.BindLongOrderData = null;
                }
                if (orderkind == 1)
                {
                    view.BindTempOrderData = null;
                }
                return;
            }
            if (orderkind == 0)
            {
                view.BindLongOrderData = null;
                view.BindLongOrderData = mytable;
                dt = view.BindLongOrderData;
            }
            if (orderkind == 1)
            {
                view.BindTempOrderData = null;
                view.BindTempOrderData = mytable;
                dt = view.BindTempOrderData;
            }
            ColorPaint(dt);
        }
        #endregion

        #region 绘制颜色
        /// <summary>
        /// 绘制颜色
        /// </summary>
        /// <param name="dtc"></param>
        public void ColorPaint(DataTable dtc)
        {
            if (dtc == null)
            {
                return;
            }
            for (int i = 0; i < dtc.Rows.Count; i++)
            {
                HIS.Model.zy_doc_orderrecord_son order = new HIS.Model.zy_doc_orderrecord_son();
                order = (HIS.Model.zy_doc_orderrecord_son)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dtc, i, order);
                if (order.ITEM_TYPE < 4 && order.ORDER_TYPE == 0 && order.STATUS_FALG == 2)
                {
                    if (drugbase.GetStoreNum(order.MAKEDICID, order.ITEM_TYPE)<1)
                    {
                        view.OrderColor = new OrderColor(i, -1, System.Drawing.Color.Blue, System.Drawing.Color.Turquoise);
                    }
                    else
                    {
                        ShowRowColor(order, i, 1);
                    }
                }
                else
                {
                    ShowRowColor(order, i, 1);
                }
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
        public bool IsGroupFirstRow(DataTable myTb, int nrow)
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

        #region 只读的控制
        /// <summary>
        /// 控制只读
        /// </summary>
        /// <param name="colid"></param>
        /// <param name="rowid"></param>
        public void SettingReadOnly(int colid, int rowid, int orderkind)
        {
            try
            {
                DataTable dt = null;
                dt = this.GetOrderTable(orderkind);
                HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
                record = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, rowid, record);
                if (record.STATUS_FALG > 1 || record.ITEM_TYPE==10) //已经发送的不能修改　
                {
                    view.AmountReadOnly = true;
                    view.DropSperReadOnly = true;
                    view.FirstTimeReadOnly = true;
                    view.FrenQuencyReadOnly = true;
                    view.ItemNameReadOnly = true;
                    view.PresAmountReadOnly = true;
                    view.StrucReadOnly = true;
                    if (record.STATUS_FALG > 2)
                    {
                        view.UsageReadOnly = true;
                    }
                    else
                    {
                        if (IsGroupFirstRow(dt, rowid))
                        {
                            view.UsageReadOnly = false;
                        }
                        else
                        {
                            view.UsageReadOnly = true;
                        }
                    }
                    view.UnitReadOnly = true;
                }
                else
                {
                    if (colid == 5)
                    {
                        if (dt.Rows[rowid][colid].ToString() == "皮试" && record.ITEM_TYPE == 7)
                        {
                            view.UsageReadOnly = true;
                        }
                    }
                    if (!this.IsGroupFirstRow(dt, rowid)) //如果不是一组的第一行
                    {
                        view.FirstTimeReadOnly = true;
                        view.FrenQuencyReadOnly = true;
                        view.PresAmountReadOnly = true;
                        view.UsageReadOnly = true;
                        view.ItemNameReadOnly = false;
                        view.AmountReadOnly = false;
                        view.DropSperReadOnly = false;
                        view.StrucReadOnly = false;
                        if (record.ITEM_TYPE>2|| orderkind == 0) //长期医嘱和中草药单位都是含量单位
                        {
                            view.UnitReadOnly = true;
                        }
                        else
                        {
                            view.UnitReadOnly = false;
                        }
                    }
                    else     //如果是一组的第一行
                    {
                        view.AmountReadOnly = false;
                        view.DropSperReadOnly = false;
                        view.FirstTimeReadOnly = false;
                        view.FrenQuencyReadOnly = false;
                        view.ItemNameReadOnly = false;
                        view.StrucReadOnly = false;
                        view.UsageReadOnly = false;
                        if (record.ITEM_TYPE == 3)
                        {
                            view.PresAmountReadOnly = false;
                        }
                        else
                        {
                            view.PresAmountReadOnly = true;
                        }
                        if (record.ITEM_TYPE>2|| orderkind == 0) //长期医嘱和中草药单位都是含量单位
                        {
                            view.UnitReadOnly = true;
                        }
                        else
                        {
                            view.UnitReadOnly = false;
                        }
                    }
                }
            }
            catch
            {
            }
        }
        #endregion

        #region 停嘱处理前检查
        /// <summary>
        /// 停嘱检查
        /// </summary>
        public bool StopCheck(int nrow, int ncol)
        {
            DataTable tb = view.BindLongOrderData;
            HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
            record = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(tb, nrow, record);
            if (record.STATUS_FALG == -1 || tb.Rows[nrow]["status_falg"].ToString() == "")
            {
                return false;
            }
            int groupID = record.GROUP_ID;// Convert.ToInt32(tb.Rows[nrow]["group_id"].ToString().Trim());
            if (record.STATUS_FALG != 2)
            {
                MessageBox.Show("医嘱选择错误！\n请选择有效长嘱。", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                if (record.ORDER_USAGE == "静滴")
                {
                    MessageBox.Show("该组医嘱用法是“静滴”，停嘱后请选择其他组续滴液体作为“静滴”。", "修改用法提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return true;
                }
            }
            return true;
        }
        #endregion   

        #region 一组医嘱用法，频率自动改变
        /// <summary>
        /// 当改变一组中第一个的频率，用法时这组的医嘱自动改变
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowindex"></param>
        /// <param name="colname"></param>
        public void ChangeValue(DataTable dt, int rowindex, string colname)
        {
            for (int i = rowindex + 1; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["BeginTime"].ToString().Trim() == timeformat.ToString())
                {
                    dt.Rows[i]["order_usage"] = XcConvert.IsNull(dt.Rows[rowindex]["order_usage"].ToString(), "");
                    dt.Rows[i]["frequency"] = XcConvert.IsNull(dt.Rows[rowindex]["frequency"].ToString(), "");
                    dt.Rows[i]["firset_times"] = XcConvert.IsNull(dt.Rows[rowindex]["firset_times"].ToString(), "1");
                    dt.Rows[i]["pres_amount"] = XcConvert.IsNull(dt.Rows[rowindex]["pres_amount"].ToString(), "0");
                    if (dt.Rows[i]["orecord_a2"].ToString().Trim() == "1")
                    {
                        dt.Rows[i]["orecord_a2"] = 2;
                        dt.Rows[i]["status_falg"] = -1;
                        this.ColorPaint(dt);
                    }
                }
                if (dt.Rows[i]["BeginTime"].ToString().Trim() != timeformat.ToString())
                {
                    break;
                }
            }
        }
        #endregion

        #region 插入自备药
        /// <summary>
        /// 插入自备药，把执行科室ＩＤ置为－１
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="rowindex"></param>
        /// <param name="colindex"></param>
        public void InsertSelfMed(DataTable dt, int rowindex, int colindex)
        {
            HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
            record = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, rowindex, record);
            if (record.ORDER_CONTENT == null || record.ORDER_CONTENT=="")
            {
                return;
            }
            if (record.STATUS_FALG > 1)
            {
                MessageBox.Show("该药品已发送或执行，不能更改为自备药", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (record.ORDER_CONTENT.IndexOf("「自备」", 0) >= 0 && record.EXEC_DEPT== -1)
            {
                MessageBox.Show("该药品已为自备药", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (record.ORDER_TYPE == 5)
            {
                MessageBox.Show("该药品已交病人，不能再置为自备", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (record.ORDER_TYPE == 7)
            {
                MessageBox.Show("该药品已置出院带药，不能再置为自备", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            int  typenum = record.ITEM_TYPE;
            if (typenum == 1 || typenum == 2 || typenum == 3)
            {
                if (record.ORDER_CONTENT != null && record.ORDER_CONTENT != "")
                {
                    dt.Rows[rowindex]["order_content"] = dt.Rows[rowindex]["order_content"].ToString().Trim() + "「自备」";
                    dt.Rows[rowindex]["exec_dept"] = -1;
                    if (dt.Rows[rowindex]["orecord_a2"].ToString().Trim() == "1")
                    {
                        dt.Rows[rowindex]["orecord_a2"] = 2;
                        dt.Rows[rowindex]["status_falg"] = -1;
                    }
                }
                this.ColorPaint(dt);
            }
            else
            {
                MessageBox.Show("自备的必须是药品");
            }
        }
        #endregion

        #region 通过类型获得相应的datatable
        /// <summary>
        /// 通过医嘱类型获得相应的datatable
        /// </summary>
        /// <param name="orderkind"></param>
        /// <returns></returns>
        private DataTable GetOrderTable(int orderkind)
        {
            if (orderkind == 0)
            {
                return view.BindLongOrderData;
            }
            else if (orderkind == 1)
            {
                return view.BindTempOrderData;
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region 增加模板数据
        /// <summary>
        /// 增加模板数据
        /// </summary>
        /// <param name="modellist"></param>
        public void AddModelData(List<HIS.Model.ZY_DOC_ORDERMODELLIST> modellist)
        {
            if (modellist == null || modellist.Count == 0)
            {
                return;
            }
            int count = modellist.Count;
            DataTable dt = new DataTable();
            int ordertype = view.GetOrderKind();
            int _rowIndex = view.GetRowIndex();
            if (ordertype == 0)
            {
                string itemYJ = "";
                string itemCY = "";
                string itemWZ = "";
                List<HIS.Model.ZY_DOC_ORDERMODELLIST> modellistt = new List<HIS.Model.ZY_DOC_ORDERMODELLIST>();
                for (int i = 0; i < count; i++)
                {
                    if (modellist[i].ITEM_TYPE == 3) //长期医嘱中除去中草药医嘱和医技项目医嘱，单位都是含量单位
                    {
                        itemCY = itemCY + modellist[i].ITEM_NAME + ",";
                        continue;
                    }
                    if (modellist[i].ITEM_TYPE == 5)
                    {
                        itemYJ = itemYJ + modellist[i].ITEM_NAME + ",";
                        continue;
                    }
                    if (modellist[i].ITEM_TYPE == 0)
                    {
                        itemWZ = itemWZ + modellist[i].ITEM_NAME + ",";
                        continue;
                    }
                    modellistt.Add(modellist[i]);
                }
                if (itemCY != "")
                {
                    MessageBox.Show("'" + itemCY + "'为中草药，不能应用在长期医嘱中");
                }
                if (itemYJ != "")
                {
                    MessageBox.Show("'" + itemYJ + "'为医技项目，不能应用在长期医嘱中");
                }
                if (itemWZ != "")
                {
                    MessageBox.Show("'" + itemWZ + "'为物资，不能应用在长期医嘱中");
                }
                if (modellistt == null || modellistt.Count == 0)
                {
                    return;
                }
                count = modellistt.Count;
                if (modellistt[0].ITEM_TYPE != 3)
                {
                    _rowIndex = this.AddRow(ordertype, 0);
                    dt = view.BindLongOrderData;
                    this.ModelData(dt, _rowIndex, modellistt[0], ordertype);
                    controlmethod.SetNull(dt.Rows[_rowIndex], 0);
                }
                for (int index = 1; index < count && modellistt[index].ITEM_TYPE != 3; index++)
                {
                    if (modellistt[index].GROUP_ID != modellistt[index - 1].GROUP_ID)
                    {
                        _rowIndex = this.AddRow(ordertype, 0);
                        dt = view.BindLongOrderData;
                        this.ModelData(dt, _rowIndex, modellistt[index], ordertype);
                        controlmethod.SetNull(dt.Rows[_rowIndex], 0);
                    }
                    else
                    {
                        _rowIndex = this.AddRow(ordertype, 1);
                        this.ModelData(dt, _rowIndex, modellistt[index], ordertype);
                        controlmethod.SetNull(dt.Rows[_rowIndex], 1);
                    }
                }
            }
            if (ordertype == 1)
            {
                _rowIndex = this.AddRow(ordertype, 0);
                if (ordertype == 1)
                {
                    dt = view.BindTempOrderData;
                }
                this.ModelData(dt, _rowIndex, modellist[0], ordertype);            
                controlmethod.SetNull(dt.Rows[_rowIndex], 0);
                for (int index = 1; index < count; index++)
                {
                    if (modellist[index].GROUP_ID != modellist[index - 1].GROUP_ID)
                    {
                        _rowIndex = this.AddRow(ordertype, 0);
                        this.ModelData(dt, _rowIndex, modellist[index], ordertype);
                        controlmethod.SetNull(dt.Rows[_rowIndex], 0);
                    }
                    else
                    {
                        _rowIndex = this.AddRow(ordertype, 1);
                        this.ModelData(dt, _rowIndex, modellist[index], ordertype);
                        controlmethod.SetNull(dt.Rows[_rowIndex], 1);                      
                    }
                }
            }
        }
        #endregion

        #region 消息提示
        /// <summary>
        /// 消息提示
        /// </summary>
        /// <param name="Tells"></param>
        public void MessageTell(string Tells)
        {
            string messages = "（" + GetName.GetDeptName(view.currentDept.DeptID.ToString()) + zy_Patlist.BedCode.ToString() + zy_Patlist.PatientInfo.PatName + ")" + Tells;
            MessagePromptManager.Messages message = new MessagePromptManager.Messages("001", "消息提示", messages);
            senders.SendMessage(receiver, message);
        }
        #endregion

        #region 是否有未执行的医嘱
        public string NotExeOrders()
        {
            return HIS.ZYDoc_BLL.PatInfo.PatOperation.NotCanOut(zy_Patlist.PatListID);
        }
        #endregion

        #region 是否可以修改医嘱
        public bool NotCanUpdate()
        {
            return HIS.ZYDoc_BLL.PatInfo.PatOperation.NotCanUpdate(view.zy_patlist_get);
        }
        #endregion

       // 20100512.1.03  病人出院时判断病人是否存在未完成的手术
        #region 是否存在已申请未完成的手术
        public bool ExistNotFinishSs()
        {
            return HIS.ZYDoc_BLL.PatInfo.PatOperation.ExistNotFinishSs(view.zy_patlist_get);
        }
        #endregion
        #endregion

        #region 由对象转为datatable
        private void ModelToTable(List<HIS.Model.zy_doc_orderrecord_son> records, int orderkind)
        {           
            OpOrder.recordsSon = records;
             DataTable table= OpOrder.TableFormat();
            if (orderkind == 0)
            {
                view.BindLongOrderData = table;
                ColorPaint(view.BindLongOrderData);
            }
            else
            {
                view.BindTempOrderData = table;
                ColorPaint(view.BindTempOrderData);
            }
        }
        #endregion
   
        #region datatabel转为对象HIS.Model.ZY_DOC_ORDERRECORD
        /// <summary>
        /// datatabel转为对象HIS.Model.ZY_DOC_ORDERRECORD
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="Bindex"></param>
        /// <param name="Eindex"></param>
        /// <returns></returns>
        public List<HIS.Model.ZY_DOC_ORDERRECORD> TableToModel(int orderkind)
        {
            DataTable dt = GetOrderTable(orderkind);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            List<HIS.Model.ZY_DOC_ORDERRECORD> records = new List<HIS.Model.ZY_DOC_ORDERRECORD>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["order_content"].ToString() != "")
                {
                    HIS.Model.ZY_DOC_ORDERRECORD record = new HIS.Model.ZY_DOC_ORDERRECORD();
                    record = (HIS.Model.ZY_DOC_ORDERRECORD)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, record);
                    records.Add(record);
                }
            }
            OpOrder.records = records;
            return records;            
        }
        #endregion

        #region datatable转为对象HIS.Model.zy_doc_orderrecord_son
        /// <summary>
        /// datatable转为对象HIS.Model.zy_doc_orderrecord_son
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        public List<HIS.Model.zy_doc_orderrecord_son> TableToSon(int orderkind)
        {
            DataTable dt = GetOrderTable(orderkind);
            if (dt == null || dt.Rows.Count == 0)
            {
                return null;
            }
            List<HIS.Model.zy_doc_orderrecord_son> records = new List<HIS.Model.zy_doc_orderrecord_son>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                HIS.Model.zy_doc_orderrecord_son recordson = new HIS.Model.zy_doc_orderrecord_son();
                recordson = (HIS.Model.zy_doc_orderrecord_son)HIS.SYSTEM.PubicBaseClasses.ApiFunction.DataTableToObject(dt, i, recordson);
                   // recordson.LoadData();
                    HIS.ZYDoc_BLL.GetName.GiveName(recordson);
                records.Add(recordson);

            }
            OpOrder.recordsSon = records;
            return records;
        }
        #endregion
     
        #region 得到一组的最后行索引
        /// <summary>
        /// 得到一组的最后行索引
        /// </summary>
        /// <param name="myTb"></param>
        /// <param name="nrow"></param>
        /// <returns></returns>
        public int GetGroupEndRow(DataTable myTb, int nrow)
        {
            int i;
            for (i = nrow + 1; i < myTb.Rows.Count; i++)
            {
                if (IsGroupFirstRow(myTb, i))
                {
                    return i;
                }
            }
            if (i == myTb.Rows.Count)
            {
                return i;
            }
            return -1;
        }
        #endregion

        private void AfterDelete(List<HIS.Model.zy_doc_orderrecord_son> records, int orderkind)
        {
            if (records == null)
                return ;
            DataTable table = HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(records.FindAll(x => x.DELETE_FLAG == 0));           
            if (orderkind == 0)
            {
                view.BindLongOrderData = table;
                ColorPaint(view.BindLongOrderData);
            }
            else
            {
                view.BindTempOrderData = table;
                ColorPaint(view.BindTempOrderData);
            }
        }

        #region 电子病历
        //得到病历
        public void GetEmr(int index)
        {
            HIS_EMRManager.Public.EMRRecordInfo emrInfo = this.GetEmrInfo();
            if (index == 0)
            {
                emrInfo.RecordType = HIS_EMRManager.Public.EMRType.入院记录;
                view.EmrControl = HIS_EMRManager.Public.ExternalInterFace.GetEMRRecord(emrInfo);
            }
            else if (index == 1)
            {
                emrInfo.RecordType = HIS_EMRManager.Public.EMRType.病程记录;               
                view.EmrControl = HIS_EMRManager.Public.ExternalInterFace.GetEMRRecord(emrInfo, view.Nodetag);             
            }
            else if (index == 2)
            {
                emrInfo.RecordType = HIS_EMRManager.Public.EMRType.出院记录;
                view.EmrControl = HIS_EMRManager.Public.ExternalInterFace.GetEMRRecord(emrInfo);
            }
            else if (index == 3)
            {
                emrInfo.RecordType = HIS_EMRManager.Public.EMRType.死亡记录;
                view.EmrControl = HIS_EMRManager.Public.ExternalInterFace.GetEMRRecord(emrInfo);
            }  
            else
            {
                emrInfo.RecordType = HIS_EMRManager.Public.EMRType.手术记录;
                view.EmrControl = HIS_EMRManager.Public.ExternalInterFace.GetEMRRecord(emrInfo);
            }   
        }
        //得到所有的病程记录
        public void GetCourseCount()
        {
            HIS_EMRManager.Public.EMRRecordInfo emrInfo = this.GetEmrInfo();
            emrInfo.RecordType = HIS_EMRManager.Public.EMRType.病程记录;
            DataTable DiseaseCourse = HIS_EMRManager.Public.ExternalInterFace.GetDiseaseCourseRecord(emrInfo);
            if (DiseaseCourse != null && DiseaseCourse.Rows.Count!=0)
            {
                for (int i = 0; i < DiseaseCourse.Rows.Count; i++)
                {
                    string name = DiseaseCourse.Rows[i]["name"].ToString();
                    string value = DiseaseCourse.Rows[i]["value"].ToString();
                    view.CouserNodeAdd(name, value);
                }
            }
            else
            {
                AddCourse();
            }
        }

        //添加一个新的病程记录     
        public void AddCourse()
        {
            HIS_EMRManager.Public.EMRRecordInfo emrInfo = this.GetEmrInfo();
            emrInfo.RecordType = HIS_EMRManager.Public.EMRType.病程记录;
            view.EmrControl = HIS_EMRManager.Public.ExternalInterFace.AddEMRRecord(emrInfo);
        }
        //得到病人的信息
        public HIS_EMRManager.Public.EMRRecordInfo GetEmrInfo()
        {
            HIS_EMRManager.Public.EMRRecordInfo emrInfo = new HIS_EMRManager.Public.EMRRecordInfo();
            emrInfo.Patid = Convert.ToInt64(zy_Patlist.PatID);
            emrInfo.PatListid = zy_Patlist.PatListID;
            emrInfo.CreateEmpId = view.currentUser.EmployeeID;
            emrInfo.CreateDeptId = view.currentDept.DeptID;
            emrInfo.RecordType = HIS_EMRManager.Public.EMRType.入院记录;
            emrInfo.MediCard = zy_Patlist.PatientInfo.MediCard;
            emrInfo.PatName = zy_Patlist.PatientInfo.PatName;
            return emrInfo;
        }
        #endregion
    }
}


