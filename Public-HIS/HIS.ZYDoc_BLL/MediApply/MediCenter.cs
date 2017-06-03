using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYDoc_BLL.MediApply
{
    abstract class MediCenter:BaseBLL
    {
        /// <summary>
        /// 获得相应类型的科室
        /// </summary>
        /// <returns></returns>
        public abstract DataTable GetDept();

        /// <summary>
        /// 获得所有医技类型
        /// </summary>
        /// <returns></returns>
        public abstract DataTable GetMediType();

        /// <summary>
        /// 获得相应类型的项目名称
        /// </summary>
        /// <param name="meditype"></param>
        /// <param name="deptId"></param>
        /// <param name="medicalClass"></param>
        /// <returns></returns>
        public abstract DataTable GetItems( int deptId, int medicalClass);

        /// <summary>
        /// 查询一段时间的申请报告
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="meditype"></param>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        /// <returns></returns>
        public abstract DataTable GetOrders(int patlistid,  DateTime? Bdate, DateTime? Edate);

     
        /// <summary>
        ///  提交检查申请
        /// </summary>
        /// <param name="records"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <returns></returns>
        public abstract bool Save(List<HIS.Model.ZY_DOC_ORDERRECORD> records, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_CHECKAPPLY> applys);

        /// <summary>
        /// 提交检验申请
        /// </summary>
        /// <param name="records"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <returns></returns>
        public abstract bool Save(List<HIS.Model.ZY_DOC_ORDERRECORD> records, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_TESTAPPLY> applys);

        /// <summary>
        /// 提交治疗申请
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="patlist"></param>
        /// <returns></returns>
        public abstract bool Save(List<HIS.Model.ZY_DOC_ORDERRECORD> orders, HIS.Model.ZY_PatList patlist);

        /// <summary>
        /// 检查申请打印
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
        public abstract void Print(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, 
            string state, string palce, string deptname, string tjjg, string Xjg, string hyjg, string othercheck);
        /// <summary>
        /// 检验申请打印
        /// </summary>
        /// <param name="path"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <param name="dtime"></param>
        /// <param name="name"></param>
        /// <param name="sample"></param>
        /// <param name="deptname"></param>
        /// <param name="diagname"></param>
        public abstract void Print(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, 
            string sample, string deptname, string diagname);

        /// <summary>
        /// 治疗申请打印
        /// </summary>
        /// <param name="path"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <param name="dtime"></param>
        /// <param name="name"></param>
        /// <param name="state"></param>
        public abstract void Print(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string state);

        /// <summary>
        /// 删除申请
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        public abstract bool DelApply(HIS.Model.ZY_DOC_ORDERRECORD record);
    }
}
