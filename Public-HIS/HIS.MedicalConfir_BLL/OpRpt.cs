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

namespace HIS.MedicalConfir_BLL
{
    public class OpRpt : BaseBLL
    {
        #region 得到所有医技科室
        /// <summary>
        /// 得到所有医技科室
        /// </summary>
        /// <returns></returns>
        public static DataTable GetMediDept()
        {
            string strWhere = Tables.base_dept_property.TYPE_CODE + oleDb.EuqalTo() + "'004'" + oleDb.And() + Tables.base_dept_property.DELETED + oleDb.EuqalTo() + 0;
            return BindEntity<HIS.Model.BASE_DEPT_PROPERTY>.CreateInstanceDAL(oleDb).GetList(strWhere);
        }
        #endregion

        #region 通过科室ID获得此科室医技项目汇总信息
        /// <summary> 
        /// 通过科室ID获得此科室医技项目汇总信息
        /// </summary>
        /// <param name="deptid"></param>
        /// <returns></returns>
        public static DataTable GetDeptItem(int deptid,DateTime ? Bdate,DateTime ? Edate)
        {           
            string strMz = "select  itemname,sum(tolal_fee) as money ,0 as flag from mz_presorder where presorderid in (select presorderid from medical_confir where "
            + " Confirdept =" + deptid + " and cancel_flag=0 and mark_flag=0 and confirdate>='"+Bdate.Value.Date+"' and confirdate <= '"+Edate.Value.Date.AddDays(1)+"' and workid="+HIS.SYSTEM.Core.EntityConfig.WorkID+") group by itemname";
            string strZy = "select  itemname,sum(tolal_fee) as money,0 as flag from zy_presorder where presorderid in (select presorderid from medical_confir where "
            + " Confirdept =" + deptid + " and cancel_flag=0 and mark_flag=1 and confirdate>='" + Bdate.Value.Date + "' and confirdate <= '" + Edate.Value.Date.AddDays(1) + "' and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + ") group by itemname";
            DataTable dtMz = oleDb.GetDataTable(strMz);
            DataTable dtZy = oleDb.GetDataTable(strZy);
            int mzcount = dtMz.Rows.Count;
            int zycount = dtZy.Rows.Count;
            DataTable items = dtMz.Clone();          
            items.Clear();
            for (int i = 0; i < mzcount; i++)
            {
                items.Rows.Add(dtMz.Rows[i].ItemArray);
            }
            for (int i = 0; i < zycount; i++)
            {
                items.Rows.Add(dtZy.Rows[i].ItemArray);
            }
            for (int i = 0; i < mzcount + zycount; i++)
            {
                for (int j = i + 1; j < mzcount + zycount; j++)
                {
                    if (items.Rows[i][0].ToString() == items.Rows[j][0].ToString())
                    {
                        items.Rows[i][1]=(Convert.ToDecimal(items.Rows[i][1].ToString())+Convert.ToDecimal(items.Rows[j][1].ToString())).ToString();
                        items.Rows[j][2]=1;
                        break;
                    }                   
                }
            }
            DataRow [] rows=items.Select("flag=0");
            DataTable table = items.Clone();
            table.Clear();
            decimal sum = 0;
            for(int i=0;i<rows.Length;i++)
            {
                table.Rows.Add(rows[i].ItemArray);
                sum = sum +Convert.ToDecimal( rows[i][1].ToString());
            }
            DataRow row = table.NewRow();
            row[0] = "费用合计";
            row[1] = sum;
            table.Rows.Add(row);
            return table;
        }

        #endregion

        #region 通过项目名称得到门诊病人和住院病人做这些项目的明细
        /// <summary>
        /// 通过项目名称得到门诊病人和住院病人做这些项目的明细
        /// </summary>
        /// <param name="itemname"></param>
        /// <param name="dtMz"></param>
        /// <param name="dtZy"></param>
        public static void GetDetailFee(string itemname, out DataTable dtMz, out DataTable dtZy)
        {
            dtMz = MzGetFee.GetMzFees(itemname);
            dtZy = ZyGetFee.GetZyFees(itemname);
        }
        #endregion
    }
}
