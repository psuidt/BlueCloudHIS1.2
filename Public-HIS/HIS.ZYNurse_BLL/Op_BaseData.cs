using System;
using System.Data;
using System.Collections.Generic;
using System.Text;

using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.BLL;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.ZYNurse_BLL
{
    public class Op_BaseData:BaseBLL
    {         
        /// <summary>
        /// 根据科室获取科室的病人信息
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public List<HIS.Model.ZY_PatList> getPatInfo(int dept_id)
        {
            try
            {
                List<HIS.Model.ZY_PatList> zy_patlist = new List<ZY_PatList>();
                int deptid = dept_id;
                string strWhere = Tables.zy_nurse_bed.DEPT_ID + oleDb.EuqalTo() + deptid + oleDb.OrderBy(oleDb.DBConvert("replace(" + Tables.zy_nurse_bed.BED_NO + ",'加','100')", "INTEGER"));//cast( replace("bed_no",'加','100') as integer)
                List<HIS.Model.ZY_NURSE_BED> beds= BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                for (int i = 0; i < beds.Count; i++)
                {
                    HIS.Model.ZY_PatList plist = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(beds[i].PATLIST_ID);
                    zy_patlist.Add(plist);
                }
                return zy_patlist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }           
        }
        /// <summary>
        /// 根据科室获取科室的床位信息
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public List<HIS.Model.ZY_NURSE_BED> getBedInfo(int dept_id)
        {
            try
            {
                List<HIS.Model.ZY_NURSE_BED> zy_patlist = new List<ZY_NURSE_BED>();
                int deptid = dept_id;
                string strWhere = Tables.zy_nurse_bed.DEPT_ID + oleDb.EuqalTo() + deptid +oleDb.OrderBy(oleDb.DBConvert("replace(" + Tables.zy_nurse_bed.BED_NO + ",'加','100')", "INTEGER"));
                List<HIS.Model.ZY_NURSE_BED> beds = BindEntity<HIS.Model.ZY_NURSE_BED>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                return beds;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }        
        }
        /// <summary>
        /// 根据科室和床位号获取床位ID
        /// </summary>
        /// <returns></returns>
        public int getBedId(int dept_id, string  bed_no)
        {
            string strWhere = "dept_id=" + dept_id + " and bed_no='" + bed_no + "'";
            object bedid = BindEntity<ZY_NURSE_BED>.CreateInstanceDAL(oleDb).GetFieldValue("bed_id",strWhere);
            return int.Parse(bedid.ToString());
        }

        #region 获得所有药房名称
        /// <summary>
        /// 获得所有药房名称
        /// </summary>
        /// <returns></returns>
        public DataTable GetYfName()
        {
            string strWhere = Tables.yp_deptdic.DEPTTYPE1 + oleDb.EuqalTo() + "'药房'";
            return BindEntity<HIS.Model.YP_DeptDic>.CreateInstanceDAL(oleDb).GetList(strWhere);
        }
        #endregion

        #region 获得科室开药的药房名称
        /// <summary>
        /// 获得科室开药的药房名称
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public DataTable Get_dept_yfName(int deptid)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", Type.GetType("System.String"));
            dt.Columns.Add("Value", Type.GetType("System.String"));
            object obj = BindEntity<HIS.Model.ZY_NURSE_CONFIG>.CreateInstanceDAL(oleDb).GetFieldValue("value", "code='009'");
            string deptname = obj  ==null ? "":obj.ToString().Trim();
            try
            {
                string drugDeptIds = "";
                string[] drugDepts = deptname.Split(',');
                foreach (string drugDept in drugDepts)
                {
                    string[] values = drugDept.Split('-');
                    drugDeptIds += (Convert.ToInt32(values[0]) == deptid ? (values[1] + ",") : "");
                }
                if (drugDeptIds.Trim() != "")
                {
                    drugDeptIds = drugDeptIds.Substring(0, drugDeptIds.Length - 1);
                    dt.Rows.Add("默认药房", drugDeptIds);
                }
            }
            catch
            {
            }

            dt.Rows.Add("全部药房", -1);
            DataTable yf = BindEntity<Model.YP_DeptDic>.CreateInstanceDAL(oleDb).GetList("DEPTTYPE1='药房'");
            if (yf != null)
            {
                foreach (DataRow row in yf.Rows)
                {
                    dt.Rows.Add(row["DeptName"].ToString().Trim(), row["DeptId"]);
                }
            }
            return dt;
        }
        #endregion
    }
}
