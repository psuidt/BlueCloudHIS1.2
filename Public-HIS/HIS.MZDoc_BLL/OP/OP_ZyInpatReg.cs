using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 住院证操作类
    /// </summary>
    public class OP_ZyInpatReg : BaseBLL
    {
        ///// <summary>
        ///// 获取住院证信息
        ///// </summary>
        ///// <param name="regId">登记ID</param>
        ///// <param name="patListId">病人就诊ID</param>
        ///// <returns>住院证信息</returns>
        //public static string GetInpatReg(ref int regId, int patListId)
        //{
        //    string strsql = Tables.mz_doc_zy_inpat_reg.PATLISTID + oleDb.EuqalTo() + patListId;
        //    HIS.Model.Mz_Doc_Zy_Inpat_Reg reg = BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(oleDb).GetModel(strsql);
        //    if (reg == null)
        //    {
        //        regId = -1;
        //        return "";
        //    }
        //    else
        //    {
        //        regId = reg.RegId;
        //        return reg.Reg_Content;
        //    }
        //}

        ///// <summary>
        ///// 保存住院证
        ///// </summary>
        ///// <param name="patId">病人ID</param>
        ///// <param name="patListId">病人就诊ID</param>
        ///// <param name="employeeId">登记人</param>
        ///// <param name="xmlText">登记内容</param>
        ///// <returns>住院证ID</returns>
        //public static int SaveInpatReg(int patId, int patListId, int employeeId, string xmlText)
        //{
        //    try
        //    {
        //        HIS.Model.Mz_Doc_Zy_Inpat_Reg reg = new HIS.Model.Mz_Doc_Zy_Inpat_Reg();
        //        reg.PatId = patId;
        //        reg.PatListId = patListId;
        //        reg.Reg_Content = xmlText;
        //        reg.Reg_Emp = employeeId;
        //        reg.Reg_Date = XcDate.ServerDateTime;
        //        return BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(oleDb).Add(reg);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        ///// <summary>
        ///// 保存住院证
        ///// </summary>
        ///// <param name="regId">登记ID</param>
        ///// <param name="xmlText">登记内容</param>
        //public static void SaveInpatReg(int regId, string xmlText)
        //{
        //    try
        //    {
        //        HIS.Model.Mz_Doc_Zy_Inpat_Reg reg = BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(oleDb).GetModel(regId);
        //        reg.Reg_Content = xmlText;
        //        reg.Reg_Date = XcDate.ServerDateTime;
        //        BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(oleDb).Update(reg);
        //    }
        //    catch (Exception e)
        //    {
        //        throw e;
        //    }
        //}

        ///// <summary>
        ///// 查询病区床位情况
        ///// </summary>
        ///// <returns>病区床位情况数据表</returns>
        //public static DataTable QueryZyDeptBed()
        //{
        //    DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(oleDb);
        //    return mzdoc_dal.Query_ZyDeptBed();
        //}

        /// <summary>
        /// 获取住院证信息
        /// </summary>
        /// <param name="regId">住院证ID</param>
        /// <returns>住院证信息数据表</returns>
        public static DataTable GetInpatRegInfo(int regId)
        {
            DataTable resultTable = new DataTable();
            resultTable.Columns.Add("Name", Type.GetType("System.String"));
            resultTable.Columns.Add("Value", Type.GetType("System.String"));
            HIS.Model.Mz_Doc_Zy_Inpat_Reg reg = BindEntity<HIS.Model.Mz_Doc_Zy_Inpat_Reg>.CreateInstanceDAL(oleDb).GetModel(regId);
            if (reg == null)
            {
                return resultTable;
            }
            else
            {
                return Public.XmlFunction.DeComposeXmlText(reg.Reg_Content, "ZyInpatRegContent", resultTable);
            }
        }

        ///// <summary>
        ///// 获得与病人姓名一致的其他入院信息
        ///// </summary>
        ///// <param name="patName">病人姓名</param>
        ///// <returns>数据表</returns>
        //public static DataTable GetFormerlyInpatInfo(string patName)
        //{
        //    string strsql = Tables.patientinfo.PATNAME + oleDb.Like() + "'%" + patName + "%'" + oleDb.And() + Tables.patientinfo.CURENUM + oleDb.GreaterThan() + "0";
        //    return BindEntity<Model.PatientInfo>.CreateInstanceDAL(oleDb).GetList(strsql);
        //}
    }
}
