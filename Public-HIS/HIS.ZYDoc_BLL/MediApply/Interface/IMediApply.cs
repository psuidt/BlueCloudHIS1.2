using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZYDoc_BLL.MediApply
{
    public enum MediType
    {
        检查=1,
        检验,
        治疗
    }

    public interface IMediApply
    {
        /// <summary>
        /// 获得科室
        /// </summary>
        /// <param name="meditype"></param>
        /// <returns></returns>
        DataTable GetDept(MediType meditype);

        /// <summary>
        /// 获得类型
        /// </summary>
        /// <param name="meditype"></param>
        /// <returns></returns>
        DataTable GetMediType(MediType meditype);

        /// <summary>
        /// 获得相应类型的项目名称
        /// </summary>
        /// <param name="meditype"></param>
        /// <param name="deptId"></param>
        /// <param name="medicalClass"></param>
        /// <returns></returns>
        DataTable GetItems(MediType meditype, int deptId, int medicalClass);
        DataTable GetOrders(int patlistid, MediType meditype, DateTime? Bdate, DateTime? Edate);
        /// <summary>
        ///  提交检查申请
        /// </summary>
        /// <param name="records"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <returns></returns>
        bool SaveCheck(List<HIS.Model.ZY_DOC_ORDERRECORD> records, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_CHECKAPPLY> applys);

        /// <summary>
        /// 提交检验申请
        /// </summary>
        /// <param name="records"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <returns></returns>
        bool SaveTest(List<HIS.Model.ZY_DOC_ORDERRECORD> records, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_TESTAPPLY> applys);

        /// <summary>
        /// 提交治疗申请
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="patlist"></param>
        /// <returns></returns>
        bool SaveCure(List<HIS.Model.ZY_DOC_ORDERRECORD> orders, HIS.Model.ZY_PatList patlist);
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
        void CheckPrint(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name,
            string state, string palce, string deptname, string tjjg, string Xjg, string hyjg, string othercheck);
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
        void TestPrint(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name,
            string sample, string deptname, string diagname);

        /// <summary>
        ///  治疗打印
        /// </summary>
        /// <param name="path"></param>
        /// <param name="patlist"></param>
        /// <param name="applys"></param>
        /// <param name="dtime"></param>
        /// <param name="name"></param>
        /// <param name="state"></param>
        void CurePrint(string path, HIS.Model.ZY_PatList patlist, List<HIS.Model.ZY_DOC_ORDERRECORD> applys, DateTime dtime, string name, string state);

        /// <summary>
        /// 申请删除
        /// </summary>
        /// <param name="meditype"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        bool DelApply(MediType meditype, HIS.Model.ZY_DOC_ORDERRECORD record);

    }
}
