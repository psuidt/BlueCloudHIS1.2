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

namespace HIS.ZYDoc_BLL.MediApply 
{
    public class ApplyOP : BaseBLL, IMediApply
    {     

        #region 获得科室
        /// <summary>
        /// 获得科室
        /// </summary>
        /// <param name="meditype"></param>
        /// <returns></returns>
        public DataTable GetDept(MediType meditype)
        {
            return ApplyFactory.GetApply(meditype).GetDept();           
        }
        #endregion

        #region 获得科室相应的项目类型
        /// <summary>
        /// 获得科室相应的项目类型
        /// </summary>
        /// <param name="meditype"></param>
        /// <returns></returns>
        public DataTable GetMediType(MediType meditype)
        {
            return ApplyFactory.GetApply(meditype).GetMediType();          
        }
        #endregion

        #region 获得项目名称
        /// <summary>
        /// 获得项目名称
        /// </summary>
        /// <param name="meditype"></param>
        /// <param name="deptId"></param>
        /// <param name="medicalClass"></param>
        /// <returns></returns>
        public DataTable GetItems(MediType meditype, int deptId, int medicalClass)
        {
            return ApplyFactory.GetApply(meditype).GetItems(deptId, medicalClass);           
        }
        #endregion

        #region 获得一段时间内的申请报告
        /// <summary>
        /// 获得一段时间内的申请报告
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="meditype"></param>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        /// <returns></returns>
        public DataTable GetOrders(int patlistid, MediType meditype, DateTime? Bdate, DateTime? Edate)
        {
            return ApplyFactory.GetApply(meditype).GetOrders(patlistid, Bdate, Edate);          
        }
        #endregion

        #region 提交检查申请
        /// <summary>
        /// 提交检查申请
        /// </summary>
        /// <param name="records"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <returns></returns>
        public bool SaveCheck(List<HIS.Model.ZY_DOC_ORDERRECORD> records, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_CHECKAPPLY> applys)
        {
            return ApplyFactory.GetApply(MediType.检查).Save(records, patlist, applys);           
        }
        #endregion

        #region 提交检验申请
        /// <summary>
        /// 提交检验申请
        /// </summary>
        /// <param name="records"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <returns></returns>
        public bool SaveTest(List<HIS.Model.ZY_DOC_ORDERRECORD> records, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_TESTAPPLY> applys)
        {
            return ApplyFactory.GetApply(MediType.检验).Save(records, patlist, applys);           
        }
        #endregion

        #region 提交治疗申请
        /// <summary>
        /// 提交治疗申请
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="patlist"></param>
        /// <returns></returns>
        public bool SaveCure(List<HIS.Model.ZY_DOC_ORDERRECORD> orders, HIS.Model.ZY_PatList patlist)
        {           
            return ApplyFactory.GetApply(MediType.治疗).Save(orders, patlist);
        }
        #endregion

        #region 检查打印
        /// <summary>
        /// 检查打印
        /// </summary>
        /// <param name="path"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <param name="dtime"></param>
        /// <param name="name"></param>
        /// <param name="state"></param>
        /// <param name="palce"></param>
        /// <param name="deptname"></param>
        /// <param name="tjjg"></param>
        /// <param name="Xjg"></param>
        /// <param name="hyjg"></param>
        /// <param name="othercheck"></param>
        public void CheckPrint(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string state, string palce, string deptname, string tjjg, string Xjg, string hyjg, string othercheck)
        {
            ApplyFactory.GetApply(MediType.检查).Print(path, patlist, applys, dtime, name, state, palce, deptname, tjjg, Xjg, hyjg, othercheck);
        }
        #endregion

        #region 检验打印
        /// <summary>
        /// 检验打印
        /// </summary>
        /// <param name="path"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <param name="dtime"></param>
        /// <param name="name"></param>
        /// <param name="sample"></param>
        /// <param name="deptname"></param>
        /// <param name="diagname"></param>
        public void TestPrint(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string sample, string deptname, string diagname)
        {
            ApplyFactory.GetApply(MediType.检验).Print(path, patlist, applys, dtime, name, sample, deptname, diagname);
        }
        #endregion

        #region 治疗打印
        /// <summary>
        /// 治疗打印
        /// </summary>
        /// <param name="path"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <param name="dtime"></param>
        /// <param name="name"></param>
        /// <param name="state"></param>
        public void CurePrint(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string state)
        {
            ApplyFactory.GetApply(MediType.治疗).Print(path, patlist, applys, dtime, name, state);
        }
        #endregion

        #region 删除申请
        /// <summary>
        /// 删除申请
        /// </summary>
        /// <param name="meditype"></param>
        /// <returns></returns>
        public bool DelApply(MediType meditype, HIS.Model.ZY_DOC_ORDERRECORD record)
        {
            return ApplyFactory.GetApply(meditype).DelApply(record );
        }
        #endregion
    }
}
