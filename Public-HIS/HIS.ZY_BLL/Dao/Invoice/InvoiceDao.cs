using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.ZY_BLL.Dao.Invoice
{
    public class InvoiceDao : Iinvoice
    {
        #region Iinvoice 成员

        public System.Data.DataTable GetInvoiceInfo(int CostMasterID)
        {
            string strsql = @"  select itemname, SUM(tolal_fee) tolal_fee 
                            from  
                            (select  
                            (select itemname from  (select a.code,b.item_name as itemname from {base_stat_item as a},{base_stat_zyfp as b} where   a.zyfp_code =b.code ) aa  where   aa.code = bigitemcode ) itemname , 
                            sum(total_fee)   as tolal_fee 
                            from {zy_costorder} where   costid =" + CostMasterID + @" group by bigitemcode ) a 
                            group by itemname  ";
            return oleDb.GetDataTable(strsql);
        }

        #endregion

        #region IbaseDao 成员

        private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb;
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb
        {
            get
            {
                return _oleDb;
            }
            set
            {
                _oleDb = value;
            }
        }
        #endregion



        public System.Data.DataTable GetInvoiceRecord()
        {
            string strsql = @"select 
                                    ID,
                                    (case   WHEN INVOICE_TYPE= 0 then '收费'   ELSE '公共'  end) as INVOICE_TYPE,
                                    B.NAME as USERNAME,
                                    PERFCHAR,
                                    START_NO,
                                    END_NO,
                                    CURRENT_NO,
                                    (case   WHEN A.STATUS =0 then '正常'   WHEN A.STATUS =1 then '用完'   WHEN A.STATUS =2 then '待用'   ELSE '停用' end) as  STATUS,
                                    A.STATUS as STATUS_FLAG,
                                    ALLOT_DATE,
                                    C.NAME as ALLOT_USER 
                                    from {zy_invoice as A} 
                                    Left Join {base_employee_property as B} on A.EMPLOYEE_ID = B.EMPLOYEE_ID 
                                    Left Join {base_employee_property as C} on A.ALLOT_USER = C.EMPLOYEE_ID  ";

            return oleDb.GetDataTable(strsql);
        }

    }
}
