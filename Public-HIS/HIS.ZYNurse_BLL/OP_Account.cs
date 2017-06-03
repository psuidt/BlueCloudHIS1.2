using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using HIS.BLL;
using HIS.Model;
using HIS.SYSTEM.BussinessLogicLayer.Classes;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;

namespace HIS.ZYNurse_BLL
{
    public class OP_Account : BaseBLL
    {
        /// <summary>
        /// 获取病人列表
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public DataTable getPatList(int dept_id)
        {
            try
            {
                string strWhere = @"select a.bed_no,a.patlist_id,c.patname"
                                  + " from zy_nurse_bed a"
                                  + " join zy_patlist b on a.patlist_id=b.patlistid"
                                  + " join patientinfo c on b.patid=c.patid"
                                  + " where a.dept_id=" + dept_id+" order by cast( replace(bed_no,'加','100') as integer)";
                DataTable patdt = oleDb.GetDataTable(strWhere);
                return patdt;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 获取病人
        /// </summary>
        /// <param name="dept_id"></param>
        /// <returns></returns>
        public DataTable getPat(int dept_id,int patlistid)
        {
            try
            {
                string strWhere = @"select a.bed_no,a.patlist_id,c.patname"
                                  + " from zy_nurse_bed a"
                                  + " join zy_patlist b on a.patlist_id=b.patlistid"
                                  + " join patientinfo c on b.patid=c.patid"
                                  + " where a.dept_id=" + dept_id + " and  a.patlist_id="+patlistid+" order by cast( replace(bed_no,'加','100') as integer)";
                DataTable patdt = oleDb.GetDataTable(strWhere);
                return patdt;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 根据病人获取主管医生
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public int getOrderDoc(int patlist_id)
        {
            int orderdoc = 0;
            int patlistid = patlist_id;
            string strWhere = "patlist_id=" + patlistid;
            object obj = BindEntity<ZY_NURSE_BED>.CreateInstanceDAL(oleDb).GetFieldValue("zy_doc", strWhere);
            if (obj != null && obj != DBNull.Value)
            {
                orderdoc = int.Parse(obj.ToString());
            }
            return orderdoc;
        }
        /// <summary>
        /// 项目表
        /// </summary>
        /// <returns></returns>
        public DataTable getItems()
        {   
            try
            {           //加物资后修改 heyan   
                string strWhere="(order_type=0 or order_type=8 or order_type=9)";
                string[] str=new string[14];
                str[0] = "case order_type when 8 then '护理' when  9 then'其它' when 0 then '物资' end as order_type";
                str[1]="py_code";
                str[2]="wb_code";
                str[3]="itemname as order_name";
                str[4] = "SELL_PRICE as price";
                str[5] = "PACKUNIT as order_unit ";
                str[6]= " '' as  default_usage";
                str[7] = "SERVER_ITEM_ID as item_id";
                str[8] = "tc_flag";
                str[9] = "EXECDEPTCODE as execdept_code";
                str[10] = "execdeptname";
                str[11] = "order_type as item_type";
                str[12] = " statitem_code";
                str[13] = "storenum";
                DataTable itemlist = BindEntity<Object>.CreateInstanceDAL(oleDb,Views.VI_CLINICAL_ALL_ITEMS).GetList(strWhere, str);
                return itemlist;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            } 
        }
        /// <summary>
        /// 频率表
        /// </summary>
        /// <returns></returns>
        public DataTable getFrequency()
        {
            try
            {
                string strwhere = @"select py_code,name,execnum from BASE_FREQUENCY";
                DataTable frequencylist = oleDb.GetDataTable(strwhere);
                return frequencylist;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }
        /// <summary>
        /// 账单保存
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public bool BindData(List<ZY_DOC_ORDERRECORD> list)
        {
            try
            {         
                oleDb.BeginTransaction();
                for(int i=0;i<list.Count;i++)
                BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Add(list[i]);
                oleDb.CommitTransaction();          
                return true;
            }
            catch(Exception e)
            {
                return false;
                throw new Exception(e.Message);
            }
        }
        /// <summary>
        /// 账单删除
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public void DelData(List<int> orderidlist)
        {
            try
            {
                for (int i = 0; i < orderidlist.Count; i++)
                {
                    string strWhere = "order_id=" + orderidlist[i];
                    object obj = BindEntity<HIS.Model.ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).GetFieldValue("noexe_flag", strWhere);
                    int noexe_flag=Convert.ToInt32(obj);
                    if(noexe_flag!=1)
                    {
                        BindEntity<ZY_DOC_ORDERRECORD>.CreateInstanceDAL(oleDb).Delete(strWhere); 
                    }                    
                }
                return;
            }
            catch (Exception e)
            {         
                throw new Exception(e.Message);
            }
        }
    }        
}
