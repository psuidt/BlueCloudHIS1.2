using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;


namespace HIS.ZYDoc_BLL.OrderInfo
{
    public class OrderOperation : BaseBLL, IOrderOP
    {

        PubOperation puborder = new PubOperation();
        LongOperation longop = new LongOperation();
        TempOperation tempop = new TempOperation();
        HIS.ZYDoc_BLL.BaseInfo.ShowCardBase showcardbase = new HIS.ZYDoc_BLL.BaseInfo.ShowCardBase();

        #region 属性
        private List<HIS.Model.zy_doc_orderrecord_son> _recordsSon;
        private List<HIS.Model.ZY_DOC_ORDERRECORD> _records;

        public List<HIS.Model.zy_doc_orderrecord_son> recordsSon
        {
            get
            {
                return _recordsSon;
            }
            set
            {
                _recordsSon = value;
                puborder.recordsSon = value;
            }
        }
        public List<HIS.Model.ZY_DOC_ORDERRECORD> records
        {
            get
            {
                return _records;
            }
            set
            {
                _records = value;
                puborder.records = value;
                longop.orders = value;
            }
        }
        #endregion

        #region 新增
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="orderkind"></param>
        /// <param name="sign"></param>
        /// <param name="order_type"></param>
        /// <returns></returns>
        public DataSet AddRows(int orderkind, int sign, int order_type)
        {
          return  showcardbase.AddRows(orderkind, sign, order_type);
        }
        #endregion

        #region 保存医嘱
        /// <summary>
        /// 保存医嘱
        /// </summary>
        /// <param name="records"></param>
        /// <param name="deptid"></param>
        /// <param name="ordertype"></param>
        /// <param name="patlist"></param>
        /// <param name="SaveDiscription"></param>
        /// <returns></returns>
        public WrongDecline Save(int deptid, int ordertype, HIS.Model.ZY_PatList patlist, out string SaveDiscription)
        {            
            return puborder.SaveRecords(deptid, ordertype, patlist, out SaveDiscription);
        }
        #endregion

        #region 删除医嘱
        /// <summary>
        /// 删除医嘱
        /// </summary>
        /// <param name="records"></param>
        /// <param name="zy_Patlist"></param>
        /// <param name="rowindex"></param>
        /// <param name="sign"></param>
        /// <param name="deptid"></param>
        /// <param name="employid"></param>
        /// <param name="IsOut"></param>
        /// <returns></returns>
        public bool Delete(HIS.Model.ZY_PatList zy_Patlist, int rowindex, int sign, int deptid, int employid, out bool IsOut)
        {
            return puborder.DeleteOrder(zy_Patlist, rowindex, sign, deptid, employid, out IsOut);
        }
        #endregion

        #region 修改
        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        public bool UpDate()
        {
            return puborder.UpdateOrder();
        }
        #endregion

        #region 发送医嘱
        /// <summary>
        /// 发送医嘱
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public string Send(out int index)
        {
            return puborder.SendOrders(out index);
        }
        #endregion

        #region 交病人
        /// <summary>
        /// 交病人
        /// </summary>
        /// <param name="records"></param>
        /// <param name="nrow"></param>
        /// <returns></returns>
        public bool GivePatient(int nrow)
        {
            return  tempop.OrderChangeDeal(records, nrow, "交病人", "5");
        }
        #endregion

        #region 出院带药
        /// <summary>
        /// 出院带药
        /// </summary>
        /// <param name="records"></param>
        /// <param name="nrow"></param>
        /// <returns></returns>
        public bool TakeOut(int nrow)
        {
            return tempop.OrderChangeDeal(records, nrow, "出院带药", "7");
        }
        #endregion

        #region 自备
        /// <summary>
        /// 自备
        /// </summary>
        /// <returns></returns>
        public bool SelfMed()
        {
            return true;
        }
        #endregion


        #region 停嘱
        /// <summary>
        /// 停嘱
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="groupid"></param>
        /// <param name="teminaltimes"></param>
        /// <param name="eorderdoc"></param>
        /// <param name="dtime"></param>
        /// <returns></returns>
        public bool Stop(int groupid,int teminaltimes,int eorderdoc,DateTime? dtime,int employid)
        {
            return longop.StopOrders(groupid, teminaltimes, eorderdoc, dtime);
        }
        #endregion

        public bool StopAll()
        {
            return longop.StopOrders();
        }

        #region 取消停
        /// <summary>
        /// 取消停
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="groupid"></param>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public bool CancelStop(int groupid, int patlistid)
        {
            return longop.CancelStopOrders(groupid, patlistid);
        }
        #endregion

        #region 出院医嘱
        /// <summary>
        /// 出院医嘱
        /// </summary>
        /// <param name="record"></param>
        /// <param name="patlist"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public bool Leave(HIS.Model.ZY_DOC_ORDERRECORD record, HIS.Model.ZY_PatList patlist)
        {      
           return tempop.Leave().Leave(record, patlist, records);
        }
        #endregion

        #region 转科申请
        /// <summary>
        /// 转科申请
        /// </summary>
        /// <param name="record"></param>
        /// <param name="transdept"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public bool TurnDept(HIS.Model.ZY_DOC_ORDERRECORD record, HIS.Model.ZY_DOC_TRANSDEPT transdept)
        {        
            return tempop.Turndept().Turn(record, transdept, records);
        }
        #endregion

        #region 死亡医嘱
        /// <summary>
        /// 死亡医嘱
        /// </summary>
        /// <param name="record"></param>
        /// <param name="patlist"></param>
        /// <param name="records"></param>
        /// <returns></returns>
        public bool Death(HIS.Model.ZY_DOC_ORDERRECORD record, HIS.Model.ZY_PatList patlist)
        {
            return tempop.Leave().Leave(record, patlist, records);
        }
        #endregion

        #region 得到医嘱信息
        /// <summary>
        /// 得到医嘱信息
        /// </summary>
        /// <param name="orderkind"></param>
        /// <param name="zy_Patlist"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public DataTable GetOrders(OrderType ordertype,Status status, HIS.Model.ZY_PatList zy_Patlist, int deptid)
        {
          return  puborder.GetOrder(ordertype,status ,zy_Patlist, deptid);
        }
        #endregion

        #region 作废医嘱
        /// <summary>
        /// 作废医嘱
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public bool Abolish(HIS.Model.ZY_DOC_ORDERRECORD record)
        {
            return tempop.Abolish(record);
        }
        #endregion

        #region 术后、产后医嘱
        /// <summary>
        /// 术后、产后医嘱
        /// </summary>
        /// <param name="order_content"></param>
        /// <param name="patdeptid"></param>
        /// <param name="presdeptid"></param>
        /// <param name="borderdoc"></param>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public bool AfterOperation(string order_content, int patdeptid, int presdeptid, int borderdoc, int patlistid)
        {      
            return longop.Afteroperation().AfterPeration(order_content, patdeptid, presdeptid, borderdoc, patlistid);
        }
        #endregion

        #region 模板应用
        /// <summary>
        /// 模板应用
        /// </summary>
        /// <param name="record"></param>
        /// <param name="model"></param>
        /// <param name="ordertype"></param>
        /// <param name="deptid"></param>
        /// <param name="order_doc"></param>
        public void ApplyModel(HIS.Model.zy_doc_orderrecord_son record, HIS.Model.ZY_DOC_ORDERMODELLIST model, int ordertype, int deptid, int order_doc)
        {
            ModelApply.ModelDataApply(record, model, ordertype, deptid, order_doc);
        }
        #endregion

        public DataTable TableFormat()
        {
           return  puborder.TableFormat();
        }
    }
}
