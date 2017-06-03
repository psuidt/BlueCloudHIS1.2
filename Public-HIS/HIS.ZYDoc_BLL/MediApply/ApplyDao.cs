using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZYDoc_BLL.MediApply
{
    partial class ApplyDao:HIS.SYSTEM.Core.BaseBLL
    {
        #region 属性
        private   int _class_type;  //检查，化验类型  
        private   MediType _meditype; //医技类型（检查、化验、治疗）        

        public   int class_type
        {
            get
            {
                return _class_type;
            }
            set
            {
                _class_type = value;
            }
        }     

        public  MediType meditype
        {
            get
            {
                return _meditype;
            }
            set
            {
                _meditype = value;
            }
        }
     
        #endregion
        private  DataTable items = new DataTable();
        public ApplyDao()
        {
           // items = BaseInfo.GetProcedure.GetOrderItem();
            items = HIS.SYSTEM.Core.BindEntity<object>.CreateInstanceDAL(oleDb, "VI_CLINICAL_ORDER").GetList("");
        }
        public  DataTable GetDept()
        {
            DataRow[] rows;
            if (_meditype == MediType.治疗)
            {
                rows= items.Select("dept_id>0 and order_type =4", "dept_id");
            }
            else
            {
                 rows = items.Select("class_type="+class_type+" and dept_id>0 and order_type =5", "dept_id");
            }
            DataTable dept = items.Clone();
            dept.Clear();
            if (rows == null || rows.Length == 0)
            {
                return dept;
            }
            dept.Rows.Add(rows[0].ItemArray);
            for (int i = 1; i < rows.Length; i++)
            {
                if (rows[i]["dept_id"].ToString() != rows[i - 1]["dept_id"].ToString())
                {
                    dept.Rows.Add(rows[i].ItemArray);
                }
            }
            return dept;            
        }

        public  DataTable GetMediType()
        {
            DataRow[] rows;
            if ( _meditype == MediType.治疗)           
            {
                rows = items.Select(" dept_id>0 and order_type =4", "dept_id");
            }
            else
            {
                rows = items.Select("class_type="+class_type+" and dept_id>0 and order_type =5", "dept_id");
            }
            DataTable meditype = items.Clone();
            meditype.Clear();
            if (rows == null || rows.Length == 0)
            {
                return meditype;
            }
            meditype.Rows.Add(rows[0].ItemArray);
            for (int i = 1; i < rows.Length; i++)
            {
                if (rows[i]["dept_id"].ToString() != rows[i - 1]["dept_id"].ToString())
                {
                    meditype.Rows.Add(rows[i].ItemArray);
                }
            }
            return meditype;
        }

        /// <summary>
        /// 获得相应类型的项目名称
        /// </summary>
        /// <param name="meditype"></param>
        /// <param name="deptId"></param>
        /// <param name="medicalClass"></param>
        /// <returns></returns>
        public  DataTable GetItems(int deptId, int medicalClass)
        {           
            DataTable item = new DataTable();
            item = items.Clone();
            item.Clear();
            DataRow[] rows;
            if (_meditype == MediType.治疗)
            {
                rows = items.Select("order_type=4  and dept_id=" + deptId + " ", "order_name");
            }
            else
            {
                rows = items.Select("order_type=5 and class_type="+class_type+" and dept_id=" + deptId + " and medical_class=" + medicalClass + "", "order_name");
            }
            if (rows == null || rows.Length == 0)
            {
                return item;
            }
            for (int i = 0; i < rows.Length; i++)
            {
                item.Rows.Add(rows[i].ItemArray);
            }
            return item;
        }

        /// <summary>
        /// 查询一段时间的申请报告
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="meditype"></param>
        /// <param name="Bdate"></param>
        /// <param name="Edate"></param>
        /// <returns></returns>
        public  DataTable GetOrders(int patlistid, DateTime? Bdate, DateTime? Edate)
        {
            string strsql = @"SELECT DISTINCT ID,  申请时间 ,  医嘱号 ,  检查项目 ,  执行科室 ,jsnum*order_price AS  检查费 , 医嘱状态 ,  下嘱医生, orditem_id
                        FROM (SELECT order_id AS ID,  order_bdate AS  申请时间 ,GROUP_ID AS  医嘱号 , order_content AS  检查项目 ,orditem_id as orditem_id ,(select name from  "
                             + "{ BASE_DEPT_PROPERTY } where exec_dept=dept_id) AS  执行科室 ,(case when status_falg = 0 then '未发送' when status_falg = 1 "
                             + "then '已发送' when status_falg = 2 then '已审核' when (status_falg = 5 and eorder_venurse=0) then '已记账' when (status_falg = 5 and eorder_venurse=1) then '已生成报告' end) AS  医嘱状态 ,"
                             + "(SELECT name FROM {BASE_EMPLOYEE_PROPERTY }  WHERE  employee_id  =order_doc) AS  下嘱医生 ,amount AS jsnum,order_price "
                         + "FROM { ZY_DOC_ORDERRECORD } WHERE patid =" + patlistid + " AND item_type = 5 AND delete_flag=0 and (order_bdate >= '" + Bdate + "' and order_bdate <='" + Edate + "' )  and orditem_id ";
            if (_meditype == MediType.治疗)
            {

                strsql += " in(select order_id from {base_order_items}  where order_type=4 )) AS A ORDER BY  申请时间 ";
            }
            else
            {
                strsql += " in(select order_id from {base_order_items}  where order_type=5 and medical_class in (select id from {BASE_MEDICAL_CLASS} where class_type="+class_type+"))) AS A ORDER BY  申请时间 ";
            }
            return oleDb.GetDataTable(strsql);
        }

    }
}
