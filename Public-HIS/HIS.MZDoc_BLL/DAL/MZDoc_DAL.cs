using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;

namespace HIS.DAL
{
    /// <summary>
    /// 门诊医生数据访问层
    /// </summary>
    public class MZDoc_DAL
    {
        private RelationalDatabase _oleDb = null;
        private long workid = 0;

        /// <summary>
        /// 门诊医生数据访问层构造函数
        /// </summary>
        /// <param name="oleDb"></param>
        public MZDoc_DAL(RelationalDatabase oleDb)
        {
            _oleDb = oleDb;
            workid = HIS.SYSTEM.Core.EntityConfig.WorkID;
        }

        #region 医技申请数据相关
        /// <summary>
        /// 获得医技化验科室
        /// </summary>
        /// <returns></returns>
        public DataTable Load_MedicalAssayDept()
        {
            string strsql = "select distinct dept_id,dept_name from VI_CLINICAL_ORDER where order_type=5 and class_type=1 and dept_id>0 and workid=" + workid;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获得医技检查科室
        /// </summary>
        /// <returns></returns>
        public DataTable Load_MedicalExamineDept()
        {
            string strsql = "select distinct dept_id,dept_name from VI_CLINICAL_ORDER where order_type=5 and class_type=0 and dept_id>0 and workid=" + workid;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获得医技治疗科室
        /// </summary>
        /// <returns></returns>
        public DataTable Load_MedicalTreatDept()
        {
            string strsql = "select distinct dept_id,dept_name from VI_CLINICAL_ORDER where order_type=4 and dept_id>0 and medical_class>0 and workid=" + workid;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获得医技项目类型列表
        /// </summary>
        /// <param name="sqlstr"></param>
        /// <returns></returns>
        public List<Model.Base_Medical_Class> Load_MedicalClass(string sqlstr)
        {
            return (List<Model.Base_Medical_Class>)BindEntity<Model.Base_Medical_Class>.CreateInstanceDAL(_oleDb).GetListArray(sqlstr);
        }

        /// <summary>
        /// 修改医技项目类型信息
        /// </summary>
        /// <param name="model"></param>
        public void SaveMedicalClass(Model.Base_Medical_Class model)
        {
            BindEntity<Model.Base_Medical_Class>.CreateInstanceDAL(BaseBLL.oleDb).Update(model);
        }

        /// <summary>
        /// 修改医技项目类型的打印格式信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="printType"></param>
        public void SaveMedicalClass(int id, string printType)
        {
            string strwhere = Tables.base_medical_class.ID + BaseBLL.oleDb.EuqalTo() + id;
            string[] strvalue = { Tables.base_medical_class.PRINTTYPE + BaseBLL.oleDb.EuqalTo() + "'" + printType + "'" };
            BindEntity<Model.Base_Medical_Class>.CreateInstanceDAL(BaseBLL.oleDb).Update(strwhere, strvalue);
        }

        /// <summary>
        /// 获得医技化验项目类型
        /// </summary>
        /// <returns></returns>
        public DataTable Load_MedicalAssayClass()
        {
            string strsql = "select distinct dept_id,dept_name,medical_class,medical_class_name from VI_CLINICAL_ORDER where order_type=5 and class_type=1 and dept_id>0 and workid=" + workid;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获得医技检查项目类型
        /// </summary>
        /// <returns></returns>
        public DataTable Load_MedicalExamineClass()
        {
            string strsql = "select distinct dept_id,dept_name,medical_class,medical_class_name from VI_CLINICAL_ORDER where order_type=5 and class_type=0 and dept_id>0 and workid=" + workid;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获得医技治疗项目类型
        /// </summary>
        /// <returns></returns>
        public DataTable Load_MedicalTreatClass()
        {
            string strsql = @"select distinct dept_id,dept_name,medical_class,medical_class_name 
                                 from VI_CLINICAL_ORDER 
                                  where order_type=4 and dept_id>0 and medical_class>0 and workid=" + workid;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 获取医技项目基础数据
        /// </summary>
        /// <returns></returns>
        public DataTable Load_MedicalItem()
        {
            DataTable table = BindEntity<object>.CreateInstanceDAL(_oleDb, HIS.BLL.Views.VI_CLINICAL_ORDER).GetList("");
            table.TableName = "MedicalItem";
            return table;
        }

        /// <summary>
        /// 获得已产生报告的医技申请列表
        /// </summary>
        /// <param name="patid">病人ID</param>
        /// <param name="bDate">开始时间</param>
        /// <param name="eDate">结束时间</param>
        /// <returns></returns>
        public DataTable Load_MedicalApplyList(long patid, DateTime bDate, DateTime eDate)
        {
            string strsql = @"select distinct a.preslistid,g.name as applydocname, f.name as applydeptname,e.name as dept_name,
			                     b.PRES_DATE as apply_date,i.name as medical_class,a.item_id,a.item_name,a.ITEM_PRICE as price,
                                  case when i.CLASS_TYPE=0 then 1 else case when i.CLASS_TYPE=1 then 0 else 2 end end as Apply_Type,h.TicketNum
			                     from MZ_DOC_PRESLIST a 		
		  	                     left join mz_doc_preshead b on a.presheadid=b.presheadid		  
		 	                      left join base_order_items c on a.item_id=c.order_id
         	                      left join base_dept_property e on b.PRES_EXEDEPT=e.dept_id
		 	                      left join base_dept_property f on b.PRES_DEPT=f.dept_id
		 	                      left join base_employee_property g on b.PRES_DOC=g.employee_id
		 	                      inner join MZ_PRESMASTER h on h.docpresid=b.presheadid 
			                       left join base_medical_class i on c.medical_class=i.id
			                       where a.selfdrug_flag=1 and b.patid=" + patid + " and b.PRES_DATE between '" + bDate + "' and '" + eDate + "' and i.CLASS_TYPE<2 and a.workid=" + workid;
            return _oleDb.GetDataTable(strsql);
        }
        #endregion

        /// <summary>
        /// 获得医生列表
        /// </summary>
        /// <returns></returns>
        public DataTable Load_DoctorData()
        {
            string strWhere_1 = "A." + Tables.base_role_doctor.EMPLOYEE_ID + _oleDb.EuqalTo() + "B." + Tables.base_employee_property.EMPLOYEE_ID;
            string strsql = _oleDb.Table(_oleDb.TableName(_oleDb.TableNameBM(Tables.BASE_ROLE_DOCTOR, "A"), _oleDb.TableNameBM(Tables.BASE_EMPLOYEE_PROPERTY, "B")), "", strWhere_1,
                                "B." + Tables.base_employee_property.EMPLOYEE_ID,
                                "B." + Tables.base_employee_property.NAME,
                               "B." + Tables.base_employee_property.PY_CODE,
                                "B." + Tables.base_employee_property.WB_CODE);
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 加载常用药品数据
        /// </summary>
        /// <param name="employeeid">所属医生Id</param>
        /// <returns></returns>
        public DataTable Load_CommonDrug(long employeeid)
        {
            string strsql = @"select distinct a.*,
                                     b.byname as itemname,b.STANDARD,b.packunit as unit,b.ADDRESS,b.PY_CODE,b.WB_CODE,b.D_CODE 
                                from MZ_DOC_COMMONITEM a left join VI_CLINICAL_DRUG b on a.item_id=b.itemid where DELETE_BIT=0 and TYPE=1 and a.workid=" + workid + " and a.RECORD_DOC=" + employeeid + " order by Frequency desc";
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 加载常用项目数据
        /// </summary>
        /// <param name="employeeid">所属医生Id</param>
        /// <returns></returns>
        public DataTable Load_CommonItem(long employeeid)
        {
            string strsql = @"select distinct a.*,
                                     b.Order_Id,b.Order_Name,b.Order_Unit,b.Order_Type,b.Medical_Class,b.Default_Usage,b.Py_Code,b.Wb_Code,b.D_Code,b.Tc_Flag,b.Bz
                                 from MZ_DOC_COMMONITEM a left join BASE_ORDER_ITEMS b on a.item_id=b.ORDER_ID 
                                 where a.DELETE_BIT=0 and b.delete_bit=0 and TYPE=0 and a.workid=" + workid + " and a.RECORD_DOC=" + employeeid + " order by Frequency desc";
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// j加载药品词典
        /// </summary>
        /// <returns>药品词典数据表</returns>
        public DataTable Load_DrugDic()
        {
            string strsql = "select * from VI_CLINICAL_DRUG where workid=" + workid;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 根据条件查询病人列表
        /// </summary>
        /// <param name="patientSearchInfo">病人查询信息</param>
        /// <returns></returns>
        public DataTable Search_PatList(HIS.MZDoc_BLL.Public.PatientSearchInfo patientSearchInfo)// string cardNo, string visitNo, string patName, int deptId, int docId, DateTime beginTime, DateTime endTime)
        {
            string strsql = @"select distinct a.* ,b.name as DeptName, c.name as DocName ,d.PRES_DEPT,d.PRES_DOC
                                from ( select * from mz_patlist where " + Tables.mz_patlist.MEDICARD + _oleDb.Like() + "'%" + patientSearchInfo.CardNo + "%'"
                                                 + _oleDb.And() + Tables.mz_patlist.VISITNO + _oleDb.Like() + "'%" + patientSearchInfo.VisitNo + "%'"
                                                 + _oleDb.And() + Tables.mz_patlist.PATNAME + _oleDb.Like() + "'%" + patientSearchInfo.PatName + "%'"
                                                 + _oleDb.And() + Tables.mz_patlist.DISEASENAME + _oleDb.Like() + "'%" + patientSearchInfo.Diagnosis + "%'"
                                                 + _oleDb.And() + HIS.BLL.Tables.mz_patlist.VISITNO + _oleDb.NotEqualTo() + "''"
                                                 + _oleDb.And() + Tables.mz_patlist.CUREDATE + _oleDb.Between() + "'" + patientSearchInfo.BeginTime.Date + "'" + _oleDb.And() + "'" + patientSearchInfo.EndTime.Date.AddDays(1) + "'"
                                                 + _oleDb.And() + " workid=" + workid + ")a "
                              + " inner join (select * from mz_doc_preshead where ("
                                                    + Tables.mz_doc_preshead.PRES_DEPT + _oleDb.EuqalTo() + patientSearchInfo.DeptId + _oleDb.Or() + patientSearchInfo.DeptId + _oleDb.EuqalTo() + "-1)"
                                                    + _oleDb.And() + "(" + Tables.mz_doc_preshead.PRES_DOC + _oleDb.EuqalTo() + patientSearchInfo.DocId + _oleDb.Or() + patientSearchInfo.DocId + _oleDb.EuqalTo() + "-1)"
                                                    + _oleDb.And() + Tables.mz_doc_preshead.PRES_FLAG + _oleDb.LessThan() + "2" + _oleDb.And() + " workid=" + workid + " ) d on a.patlistid=d.patlistid "
                              + "left join base_dept_property b on d.PRES_DEPT=b.dept_id "
                              + "left join base_employee_property c on d.PRES_DOC=c.employee_id "
                              + "inner join mz_doc_preslist e on d.presheadid=e.presheadid and e.DELETE_BIT=0 where a.workid=" + workid;

//            string strsql = @"select distinct a.* ,b.name as DeptName, c.name as DocName ,d.PRES_DEPT,d.PRES_DOC
//                              from 
//                             ( select * from mz_patlist where ";
//            if (patientSearchInfo.CardNo.Trim() != "")
//            {
//                strsql += Tables.mz_patlist.MEDICARD + _oleDb.Like() + "'%" + patientSearchInfo.CardNo + "%'" + _oleDb.And();
//            }
//            if (patientSearchInfo.VisitNo.Trim() != "")
//            {
//                strsql += Tables.mz_patlist.VISITNO + _oleDb.Like() + "'%" + patientSearchInfo.VisitNo + "%'" + _oleDb.And();
//            }
//            if (patientSearchInfo.PatName.Trim() != "")
//            {
//                strsql += Tables.mz_patlist.PATNAME + _oleDb.Like() + "'%" + patientSearchInfo.PatName + "%'" + _oleDb.And();
//            }
//            if (patientSearchInfo.Diagnosis.Trim() != "")
//            {
//                strsql += Tables.mz_patlist.DISEASENAME + _oleDb.Like() + "'%" + patientSearchInfo.Diagnosis + "%'" + _oleDb.And();
//            }
//            strsql += HIS.BLL.Tables.mz_patlist.VISITNO + _oleDb.NotEqualTo() + "''"
//                                 + _oleDb.And() + Tables.mz_patlist.CUREDATE + _oleDb.Between() + "'" + patientSearchInfo.BeginTime.Date + "'" + _oleDb.And() + "'" + patientSearchInfo.EndTime.Date.AddDays(1) + "'"
//                                 + _oleDb.And() + " workid=" + workid + ")a "
//                              + " inner join (select * from mz_doc_preshead where ("
//                              + Tables.mz_doc_preshead.PRES_DEPT + _oleDb.EuqalTo() + patientSearchInfo.DeptId + _oleDb.Or() + patientSearchInfo.DeptId + _oleDb.EuqalTo() + "-1)"
//                              + _oleDb.And() + "(" + Tables.mz_doc_preshead.PRES_DOC + _oleDb.EuqalTo() + patientSearchInfo.DocId + _oleDb.Or() + patientSearchInfo.DocId + _oleDb.EuqalTo() + "-1)"
//                              + _oleDb.And() + Tables.mz_doc_preshead.PRES_FLAG + _oleDb.LessThan() + "2" + _oleDb.And() + " workid=" + workid + " ) d on a.patlistid=d.patlistid "
//                              + "left join base_dept_property b on d.PRES_DEPT=b.dept_id "
//                              + "left join base_employee_property c on d.PRES_DOC=c.employee_id "
//                              + "inner join mz_doc_preslist e on d.presheadid=e.presheadid and e.DELETE_BIT=0 where a.workid=" + workid;
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 根据条件查询病人列表
        /// </summary>
        /// <param name="beginTime">就诊时间段查询的开始时间</param>
        /// <param name="endTime">就诊时间段查询的结束时间</param>
        /// <returns></returns>
        public List<HIS.Model.MZ_PatList> Search_PatList(DateTime beginTime, DateTime endTime)
        {
            //string strsql = Tables.mz_patlist.CUREDATE + _oleDb.Between() + "'" + beginTime.Date + "'"
            //    + _oleDb.And() + "'" + endTime.Date.AddDays(1) + "'"
            //    + _oleDb.And() + HIS.BLL.Tables.mz_patlist.VISITNO + _oleDb.NotEqualTo() + "''";
            return BindEntity<HIS.Model.MZ_PatList>.CreateInstanceDAL(_oleDb).GetListArray(
                "CUREDATE between '" + beginTime.Date + "' and '" + endTime.Date.AddDays(1) + "' and VISITNO<>''");
        }

        #region 数据统计
        /// <summary>
        /// 统计医生工作量
        /// </summary>
        /// <param name="employeeId">员工ID</param>
        /// <param name="beginDate">统计开始时间</param>
        /// <param name="endDate">统计结束时间</param>
        /// <returns>查询结果</returns>
        public DataTable Query_DocWork(int employeeId, DateTime beginDate, DateTime endDate)
        {
            string strsql = "select (select count(patlistid) as patnum from mz_patlist "
                            + "where cureempcode='" + employeeId + "' and curedate between '" + beginDate.Date + "' and '" + endDate.AddDays(1).Date + "' and workid=" + workid + "), "
                            + "c.code ,rtrim(c.item_name) as item_name,sum(b.total_fee) as money from MZ_COSTMASTER a "
                            + "inner join MZ_COSTORDER b on a.COSTMASTERID=b.costid "
                            + "left join base_stat_item c on b.itemtype=c.code "
                            + "where a.COSTMASTERID in (select COSTMASTERID from MZ_PRESMASTER "
                            + "where presdoccode='" + employeeId + "' and record_flag<3 and charge_flag=1 and presdate between '" + beginDate.Date + "' and '" + endDate.AddDays(1).Date + "' and workid=" + workid + ") "
                            + "and a.RECORD_FLAG<3 group by c.code ,c.item_name";
            return _oleDb.GetDataTable(strsql);
        }

        /// <summary>
        /// 统计病区床位情况
        /// </summary>
        public DataTable Query_ZyDeptBed()
        {
            string strsql = "select a.dept_id,b.name,count(*) as num, sum(isuse) isuse,sum(notuse) notuse from " +
                           "(select dept_id,case when patlist_id>0 then 1 else 0 end as isuse, case when patlist_id>0 then 0 else 1 end as notuse from ZY_NURSE_BED where workid=" + workid +
                           ") as a left join base_dept_property b on a.dept_id=b.dept_id where b.workid=" + workid + " group by a.dept_id,b.name";
            return _oleDb.GetDataTable(strsql);
        }
        #endregion
    }
}
