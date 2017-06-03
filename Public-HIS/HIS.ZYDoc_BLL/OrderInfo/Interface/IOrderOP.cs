using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZYDoc_BLL.OrderInfo
{ 
    
    public interface IOrderOP
    {
        List<HIS.Model.zy_doc_orderrecord_son> recordsSon { get; set; }
        List<HIS.Model.ZY_DOC_ORDERRECORD> records { get; set; }

        /// <summary>
        /// 新开
        /// </summary>
        /// <param name="orderkind"></param>
        /// <param name="sign"></param>
        /// <param name="order_type"></param>
        /// <returns></returns>
        DataSet AddRows(int orderkind, int sign, int order_type); //新开

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="deptid"></param>
        /// <param name="ordertype"></param>
        /// <param name="patlist"></param>
        /// <param name="SaveDiscription"></param>
        /// <returns></returns>
        WrongDecline Save(int deptid, int ordertype, HIS.Model.ZY_PatList patlist,out string SaveDiscription);//保存　

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="zy_Patlist"></param>
        /// <param name="rowindex"></param>
        /// <param name="sign"></param>
        /// <param name="deptid"></param>
        /// <param name="employid"></param>
        /// <param name="IsOut"></param>
        /// <returns></returns>
        bool Delete( HIS.Model.ZY_PatList zy_Patlist, int rowindex, int sign, int deptid, int employid, out bool IsOut);//删除

        /// <summary>
        /// 修改
        /// </summary>
        /// <returns></returns>
        bool UpDate();//修改        

        /// <summary>
        /// 发送
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        string Send(out int index); //发送

        /// <summary>
        /// 交病人
        /// </summary>
        /// <param name="nrow"></param>
        /// <returns></returns>
        bool GivePatient( int nrow); //交病人

        /// <summary>
        /// 出院带药
        /// </summary>
        /// <param name="nrow"></param>
        /// <returns></returns>
        bool TakeOut(int nrow);      //出院带药　

        /// <summary>
        /// 自备
        /// </summary>
        /// <returns></returns>
        bool SelfMed();              //自备
    

        /// <summary>
        /// 停嘱
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="teminaltimes"></param>
        /// <param name="eorderdoc"></param>
        /// <param name="dtime"></param>
        /// <param name="employid"></param>
        /// <returns></returns>
        bool Stop(int groupid, int teminaltimes, int eorderdoc, DateTime? dtime, int employid);//停嘱

        /// <summary>
        /// 取消停
        /// </summary>
        /// <param name="groupid"></param>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        bool CancelStop(int groupid, int patlistid);                  //取消停

        /// <summary>
        /// 出院医嘱
        /// </summary>
        /// <param name="record"></param>
        /// <param name="patlist"></param>
        /// <returns></returns>
        bool Leave(HIS.Model.ZY_DOC_ORDERRECORD record, HIS.Model.ZY_PatList patlist); //出院医嘱

        /// <summary>
        /// 转科医嘱
        /// </summary>
        /// <param name="record"></param>
        /// <param name="transdept"></param>
        /// <returns></returns>
        bool TurnDept(HIS.Model.ZY_DOC_ORDERRECORD record, HIS.Model.ZY_DOC_TRANSDEPT transdept); //转科医嘱

        /// <summary>
        /// 死亡医嘱
        /// </summary>
        /// <param name="record"></param>
        /// <param name="patlist"></param>
        /// <returns></returns>
        bool Death(HIS.Model.ZY_DOC_ORDERRECORD record, HIS.Model.ZY_PatList patlist);  //死亡医嘱　

        /// <summary>
        /// 获得医嘱信息
        /// </summary>
        /// <param name="orderkind"></param>
        /// <param name="zy_Patlist"></param>
        /// <param name="deptid"></param>
        /// <returns></returns>
        DataTable GetOrders(OrderType ordertype, Status status, HIS.Model.ZY_PatList zy_Patlist, int deptid); // 获得医嘱信息

        /// <summary>
        /// 作废医嘱
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        bool Abolish(HIS.Model.ZY_DOC_ORDERRECORD record); //作废医嘱

        /// <summary>
        /// 术后、产后医嘱
        /// </summary>
        /// <param name="order_content"></param>
        /// <param name="patdeptid"></param>
        /// <param name="presdeptid"></param>
        /// <param name="borderdoc"></param>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        bool AfterOperation(string order_content,int patdeptid,int presdeptid,int borderdoc,int patlistid); //术后、产后医嘱

        /// <summary>
        /// 模板应用
        /// </summary>
        /// <param name="record"></param>
        /// <param name="model"></param>
        /// <param name="ordertype"></param>
        /// <param name="deptid"></param>
        /// <param name="order_doc"></param>
        void ApplyModel(HIS.Model.zy_doc_orderrecord_son record, HIS.Model.ZY_DOC_ORDERMODELLIST model, int ordertype, int deptid, int order_doc); //模板应用   

        /// <summary>
        /// 产后术后停所有的医嘱
        /// </summary>
        /// <returns></returns>
        bool StopAll();

        /// <summary>
        /// 使医嘱按格式显示
        /// </summary>
        /// <returns></returns>
        DataTable TableFormat();
    }
}
