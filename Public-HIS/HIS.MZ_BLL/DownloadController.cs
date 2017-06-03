using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;

namespace HIS.MZ_BLL
{
    public delegate void AfterTableDownLoadOverHandler(string message);

    public class DownloadController : BaseBLL
    {
        public event AfterTableDownLoadOverHandler AfterTableDownLoadOver;

        private System.Data.OleDb.OleDbConnection accessConnection;

        private int workid = Convert.ToInt32( HIS.SYSTEM.Core.EntityConfig.WorkID );

        public DownloadController()
        {
            ConnectToAccessFile( );
        }

        public void DownLoadBaseData()
        {
            System.Data.OleDb.OleDbCommand cmd = accessConnection.CreateCommand( );
            cmd.CommandType = CommandType.Text;

            DownLoad_Doctor( cmd );
            DownLoad_MZFP_ITEM( cmd );
            DownLoad_StatItem( cmd );
            DownLoad_Base_PatientType( cmd );
            DownLoad_BASE_PATIENTTYPE_COST(cmd);
            DownLoad_BASE_ITEM_FAVORABLE(cmd);
            DownLoad_BASE_ITEMMX_FAVORABLE( cmd );
            DownLoad_User( cmd );
            DownLoad_Base_Dept_Property( cmd );
            DownLoad_Base_Employee_Property( cmd );
            DownLoad_ShowCard( cmd );
            DownLoad_TemplateDetail( cmd );
            DownLoad_MZ_Invoice( cmd );
            DownLoad_Base_Work_Unit( cmd );

            cmd.Dispose( );

        }

        private void DownLoad_Doctor( System.Data.OleDb.OleDbCommand cmd )
        {
            string sql = "";
            //下载医生
            sql = @"select b.employee_id,b.name as emp_name,b.py_code,b.wb_code,c.dept_id,c.name as dept_name from  
                    (select employee_id,dept_id from base_emp_dept_role where workid=" + workid + @") a,
                    ( select a.employee_id,b.name ,b.py_code,b.wb_code
                        from base_role_doctor a 
                        left join base_employee_property b 
                        on a.employee_id = b.employee_id and a.workid=" + workid + " and b.workid=" + workid + @"
                    ) b ,
                    (select dept_id,name from base_dept_property where type_code='001' and mz_flag=1 and workid=" + workid + @") c
                    where a.employee_id=b.employee_id and a.dept_id=c.dept_id";
            DataTable tbDoctor = oleDb.GetDataTable( sql );
            cmd.CommandText = "delete * from base_doctor";
            cmd.ExecuteNonQuery( );
            for ( int i = 0 ; i < tbDoctor.Rows.Count ; i++ )
            {
                string employee_id = getValue( tbDoctor.Rows[i]["employee_id"] , true );
                string emp_name = getValue( tbDoctor.Rows[i]["emp_name"] , false );
                string py_code = getValue( tbDoctor.Rows[i]["py_code"] , false );
                string wb_code = getValue( tbDoctor.Rows[i]["wb_code"] , false );
                string dept_id = getValue( tbDoctor.Rows[i]["dept_id"] , true );
                string dept_name = getValue( tbDoctor.Rows[i]["dept_name"] , false );
                sql = "insert into base_doctor(employee_id,emp_name,py_code,wb_code,dept_id,dept_name)";
                sql += "values(" + employee_id + ",'" + emp_name + "','" + py_code + "','" + wb_code + "'," + dept_id + ",'" + dept_name + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery( );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载医生信息完成！" );
        }

        private void DownLoad_MZFP_ITEM( System.Data.OleDb.OleDbCommand cmd )
        {
            string sql = "";
            DataTable tbMzfpItem = oleDb.GetDataTable( "select code,item_name from base_stat_mzfp" );
            cmd.CommandText = "delete * from base_mzfp_item";
            cmd.ExecuteNonQuery( );
            for ( int i = 0 ; i < tbMzfpItem.Rows.Count ; i++ )
            {
                string code = getValue( tbMzfpItem.Rows[i]["code"] ,false);
                string itemname = getValue( tbMzfpItem.Rows[i]["item_name"] ,false);
                sql = "insert into base_mzfp_item(code,name) values ('" + code + "','" + itemname + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载发票项目完成！" );
        }

        private void DownLoad_StatItem( System.Data.OleDb.OleDbCommand cmd )
        {
            DataTable tbStatItem = oleDb.GetDataTable( "select a.code,a.item_name,a.mzfp_code,b.item_name as mzfp_name from base_stat_item a left join base_stat_mzfp b on a.mzfp_code = b.code" );
            string sql = "";
            cmd.CommandText = "delete * from base_stat_item";
            cmd.ExecuteNonQuery( );
            for ( int i = 0 ; i < tbStatItem.Rows.Count ; i++ )
            {
                string code = getValue( tbStatItem.Rows[i]["code"] , false );
                string itemname = getValue( tbStatItem.Rows[i]["item_name"] , false );
                string mzfpcode = getValue( tbStatItem.Rows[i]["mzfp_code"] , false );
                string mzfpname = getValue( tbStatItem.Rows[i]["mzfp_name"] , false );
                sql = "insert into base_stat_item(code,item_name,mzfp_code,mzfp_name) values ('" + code + "','" + itemname + "','" + mzfpcode + "','" + mzfpname + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载统计大类完成！" );
        }

        private void DownLoad_Base_PatientType( System.Data.OleDb.OleDbCommand cmd )
        {
            DataTable tbPatType = oleDb.GetDataTable( "select code,name from base_patienttype" );
            cmd.CommandText = "delete * from Base_PatientType";
            cmd.ExecuteNonQuery( );

            for ( int i = 0 ; i < tbPatType.Rows.Count ; i++ )
            {
                string code = getValue( tbPatType.Rows[i]["code"] , false );
                string name = getValue( tbPatType.Rows[i]["name"] , false );
                string sql = "insert into Base_PatientType(code,name) values ('" + code + "','" + name + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载病人类型完成！" );
        }

        private void DownLoad_User( System.Data.OleDb.OleDbCommand cmd )
        {
            string sql = "select a.employee_id,b.name ,a.code,a.password from base_user a,base_employee_property b where a.employee_id=b.employee_id and a.workid=" + workid + " and b.workid=" + workid;
            DataTable tbUser = oleDb.GetDataTable( sql );
            cmd.CommandText = "delete * from base_user";
            cmd.ExecuteNonQuery( );
            for ( int i = 0 ; i < tbUser.Rows.Count ; i++ )
            {
                string employee_id = getValue( tbUser.Rows[i]["employee_id"] , true );
                string name = getValue( tbUser.Rows[i]["name"] , false );
                string code = getValue( tbUser.Rows[i]["code"] , false );
                string password = getValue( tbUser.Rows[i]["password"] , false );
                sql = "insert into base_user(employee_id,usercode,name,[password]) values (" + employee_id + ",'" + code + "','" + name + "','" + password + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery(  );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载用户信息完成！" );
        }

        private void DownLoad_Base_Dept_Property( System.Data.OleDb.OleDbCommand cmd )
        {
            string sql = "select dept_id,name,py_code,wb_code from base_dept_property where workid=" + workid;
            DataTable tb = oleDb.GetDataTable( sql );
            cmd.CommandText = "delete * from base_dept_property";
            cmd.ExecuteNonQuery( );
            for ( int i = 0 ; i < tb.Rows.Count ; i++ )
            {
                string dept_id = getValue( tb.Rows[i]["dept_id"] , true );
                string name = getValue( tb.Rows[i]["name"] , false );
                string py_code = getValue( tb.Rows[i]["py_code"] , false );
                string wb_code = getValue( tb.Rows[i]["wb_code"] , false );

                sql = "insert into base_dept_property(dept_id,name,py_code,wb_code) values (" + dept_id + ",'" + name + "','" + py_code + "','" + wb_code + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery( );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载科室信息完成！" );
        }

        private void DownLoad_Base_Employee_Property( System.Data.OleDb.OleDbCommand cmd )
        {
            string sql = "select employee_id,name,py_code,wb_code from base_employee_property where workid=" + workid;
            DataTable tb = oleDb.GetDataTable( sql );
            cmd.CommandText = "delete * from base_employee_property";
            cmd.ExecuteNonQuery( );
            for ( int i = 0 ; i < tb.Rows.Count ; i++ )
            {
                string employee_id = getValue( tb.Rows[i]["employee_id"] , true );
                string name = getValue( tb.Rows[i]["name"] , false );
                string py_code = getValue( tb.Rows[i]["py_code"] , false );
                string wb_code = getValue( tb.Rows[i]["wb_code"] , false );

                sql = "insert into base_employee_property(employee_id,name,py_code,wb_code) values (" + employee_id + ",'" + name + "','" + py_code + "','" + wb_code + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery( );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载人员信息完成！" );
        }

        private void DownLoad_ShowCard( System.Data.OleDb.OleDbCommand cmd )
        {
            DataTable tbChargeItems = oleDb.GetDataTable( "select * from vi_mz_showcard where workid=" + workid );
            cmd.CommandText = "delete * from vi_mz_showcard";
            cmd.ExecuteNonQuery( );
            for ( int i = 0 ; i < tbChargeItems.Rows.Count ; i++ )
            {
                int item_id = Convert.ToInt32( getValue( tbChargeItems.Rows[i]["item_id"] , true ) );
                string code = getValue( tbChargeItems.Rows[i]["code"] , false );
                string item_name = getValue( tbChargeItems.Rows[i]["item_name"] , false );
                string chem_name = getValue( tbChargeItems.Rows[i]["chem_name"] , false );
                string py_code = getValue( tbChargeItems.Rows[i]["py_code"] , false );
                string wb_code = getValue( tbChargeItems.Rows[i]["wb_code"] , false );
                string standard = getValue( tbChargeItems.Rows[i]["standard"] , false );
                string item_unit = getValue( tbChargeItems.Rows[i]["item_unit"] , false );
                string base_unit = getValue( tbChargeItems.Rows[i]["base_unit"] , false );
                string price = getValue( tbChargeItems.Rows[i]["price"] , false );
                int complex_id = Convert.ToInt32( getValue( tbChargeItems.Rows[i]["complex_id"] , true ) ); 
                string address = getValue( tbChargeItems.Rows[i]["address"] , false );
                int isdrug = Convert.ToInt32( getValue( tbChargeItems.Rows[i]["isdrug"] , true ) );
                string statitem_code = getValue( tbChargeItems.Rows[i]["statitem_code"] , false );
                int hjxs = Convert.ToInt32( getValue( tbChargeItems.Rows[i]["hjxs"] , true ) );
                string exec_dept_name = getValue( tbChargeItems.Rows[i]["exec_dept_name"] , false );
                string exec_dept_code = getValue( tbChargeItems.Rows[i]["exec_dept_code"] , false );
                string amount = getValue( tbChargeItems.Rows[i]["amount"] , false );
                string ncms_comp_rate = getValue( tbChargeItems.Rows[i]["ncms_comp_rate"] , false );
                string insur_type = getValue( tbChargeItems.Rows[i]["insur_type"] , false );
                int istemplate = Convert.ToInt32( getValue( tbChargeItems.Rows[i]["istemplate"] , true ) );
                string sql = @"insert into vi_mz_showcard(item_id,code,item_name,chem_name,py_code,wb_code,standard,item_unit,
                                                           base_unit, price,complex_id,address,isdrug,statitem_code,hjxs,exec_dept_name, exec_dept_code,amount,ncms_comp_rate,insur_type,  istemplate)
                                values (" + item_id + ",'" + code + "','" + item_name + "','" + chem_name + "','" + py_code + "','" + wb_code + "','" + standard + "','" + item_unit + "','" + base_unit + "'," + price + "," + complex_id + ",'" + address + "'," + isdrug + ",'" + statitem_code + "'," + hjxs + ",'" + exec_dept_name + "', " + exec_dept_code + "," + amount + "," + ncms_comp_rate + ",'" + insur_type + "'," + istemplate + ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery( );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载服务项目、药品项目完成！" );
        }

        private void DownLoad_TemplateDetail( System.Data.OleDb.OleDbCommand cmd )
        {
            DataTable tbTempDetail = oleDb.GetDataTable( "select * from base_template_detail where workid=" + workid );
            cmd.CommandText = "delete * from base_template_detail";
            for ( int i = 0 ; i < tbTempDetail.Rows.Count ; i++ )
            {
                int template_id = Convert.ToInt32(getValue(tbTempDetail.Rows[i]["template_id"],true));
                int item_id = Convert.ToInt32(getValue( tbTempDetail.Rows[i]["item_id"] , true ));
                int complex_id = Convert.ToInt32(getValue( tbTempDetail.Rows[i]["complex_id"] , true ));
                string item_name = getValue( tbTempDetail.Rows[i]["item_name"] , false );
                string standard = getValue( tbTempDetail.Rows[i]["standard"] , false );
                string unit = getValue( tbTempDetail.Rows[i]["unit"] , false );
                string bigitemcode = getValue( tbTempDetail.Rows[i]["bigitemcode"] , false );
                int amount = Convert.ToInt32(getValue( tbTempDetail.Rows[i]["amount"] , true ));

                string sql = @"insert into base_template_detail(template_id,item_id,complex_id,item_name,standard,unit,bigitemcode,amount)
                                values (" + template_id + "," + item_id + "," + complex_id + ",'" + item_name + "','" + standard + "','" + unit + "','" + bigitemcode + "'," + amount + ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery( );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载模板明细完成！" );
        }

        private void DownLoad_Base_Work_Unit( System.Data.OleDb.OleDbCommand cmd )
        {
            string sql = "select * from base_work_unit";
            DataTable tb = oleDb.GetDataTable( sql );
            cmd.CommandText = "delete * from base_work_unit";
            cmd.ExecuteNonQuery( );
            for ( int i = 0 ; i < tb.Rows.Count ; i++ )
            {
                string code = getValue( tb.Rows[i]["code"] , false );
                string name = getValue( tb.Rows[i]["name"] , false );
                string py_code = getValue( tb.Rows[i]["py_code"] , false );
                string wb_code = getValue( tb.Rows[i]["wb_code"] , false );

                sql = "insert into base_work_unit(code,name,py_code,wb_code) values ('" + code + "','" + name + "','" + py_code + "','" + wb_code + "')";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery( );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载病人单位列表完成！" );
        }

        private void DownLoad_MZ_Invoice( System.Data.OleDb.OleDbCommand cmd )
        {
            DataTable tb = oleDb.GetDataTable( "Select * From MZ_INVOICE Where workid=" + workid );
            cmd.CommandText = "delete * from mz_invoice";
            cmd.ExecuteNonQuery( );
            for ( int i = 0 ; i < tb.Rows.Count ; i++ )
            {
                int id = Convert.ToInt32( getValue( tb.Rows[i]["id"] , true ) );
                int employee_id = Convert.ToInt32( getValue( tb.Rows[i]["employee_id"] , true ) );
                int invoice_type = Convert.ToInt32( getValue( tb.Rows[i]["invoice_type"] , true ) );
                int start_no = Convert.ToInt32( getValue( tb.Rows[i]["start_no"] , true ) );
                int end_no = Convert.ToInt32( getValue( tb.Rows[i]["end_no"] , true ) );
                int current_no = Convert.ToInt32( getValue( tb.Rows[i]["current_no"] , true ) );
                int status = Convert.ToInt32( getValue( tb.Rows[i]["status"] , true ) );
                string perfChar = getValue( tb.Rows[i]["perfChar"] , false );

                string sql = @"insert into MZ_INVOICE(id,perfchar,employee_id,invoice_type,start_no,end_no,current_no,status)
                                values (" + id + ",'" + perfChar + "'," + employee_id + "," + invoice_type + "," + start_no + "," + end_no + "," + current_no + "," + status + ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery( );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载发票信息完成！" );

        }

        private void DownLoad_BASE_PATIENTTYPE_COST( System.Data.OleDb.OleDbCommand cmd )
        {
            DataTable tbPatType = oleDb.GetDataTable( "select * from BASE_PATIENTTYPE_COST where workid=" + workid );
            cmd.CommandText = "delete * from BASE_PATIENTTYPE_COST";
            cmd.ExecuteNonQuery( );
            for ( int i = 0 ; i < tbPatType.Rows.Count ; i++ )
            {
                string PATTYPECODE = getValue( tbPatType.Rows[i]["PATTYPECODE"] , false );
                string NAME = getValue( tbPatType.Rows[i]["NAME"] , false );
                string FAVORABLE_SCALE = getValue( tbPatType.Rows[i]["FAVORABLE_SCALE"] , true  );
                string FAVORABLE_TYPE = getValue( tbPatType.Rows[i]["FAVORABLE_TYPE"] , true );
                string MZ_FLAG = getValue( tbPatType.Rows[i]["MZ_FLAG"] , true );
                string ZY_FLAG = getValue( tbPatType.Rows[i]["ZY_FLAG"] , true );
                string MEDSAFECODE = getValue( tbPatType.Rows[i]["MEDSAFECODE"] , false );
                string DEL_FLAG = getValue( tbPatType.Rows[i]["DEL_FLAG"] , true );
                string sql = @"insert into BASE_PATIENTTYPE_COST(PATTYPECODE,NAME,FAVORABLE_SCALE,FAVORABLE_TYPE,MZ_FLAG,ZY_FLAG,MEDSAFECODE,DEL_FLAG) 
                                values ('" + PATTYPECODE + "','" + NAME + "'," + FAVORABLE_SCALE + "," + FAVORABLE_TYPE + "," + MZ_FLAG + "," + ZY_FLAG + ",'" + MEDSAFECODE + "'," + DEL_FLAG + ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery( );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载类型打折设置完成！" );
        }

        private void DownLoad_BASE_ITEM_FAVORABLE( System.Data.OleDb.OleDbCommand cmd )
        {
            DataTable tbPatType = oleDb.GetDataTable( "select * from BASE_ITEM_FAVORABLE where workid=" + workid );
            cmd.CommandText = "delete * from BASE_ITEM_FAVORABLE";
            cmd.ExecuteNonQuery( );

            for ( int i = 0 ; i < tbPatType.Rows.Count ; i++ )
            {
                string PATTYPECODE = getValue( tbPatType.Rows[i]["PATTYPECODE"] , false );
                string ITEMCODE = getValue( tbPatType.Rows[i]["ITEMCODE"] , false );
                string ITEMTYPE_FLAG = getValue( tbPatType.Rows[i]["ITEMTYPE_FLAG"] , true );
                string FAVORABLE_SCALE = getValue( tbPatType.Rows[i]["FAVORABLE_SCALE"] , true  );

                string sql = @"insert into BASE_ITEM_FAVORABLE(PATTYPECODE,ITEMCODE,ITEMTYPE_FLAG,FAVORABLE_SCALE) 
                                values ('" + PATTYPECODE + "','" + ITEMCODE + "'," + ITEMTYPE_FLAG + "," + FAVORABLE_SCALE + ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery( );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载基本项目优惠设置完成！" );
        }

        private void DownLoad_BASE_ITEMMX_FAVORABLE( System.Data.OleDb.OleDbCommand cmd )
        {
            DataTable tbPatType = oleDb.GetDataTable( "select * from BASE_ITEMMX_FAVORABLE where workid=" + workid );
            cmd.CommandText = "delete * from BASE_ITEMMX_FAVORABLE";
            cmd.ExecuteNonQuery( );

            for ( int i = 0 ; i < tbPatType.Rows.Count ; i++ )
            {
                string PATTYPECODE = getValue( tbPatType.Rows[i]["PATTYPECODE"] , false );
                string ITEMID = getValue( tbPatType.Rows[i]["ITEMID"] , false );
                string ITEMTYPE = getValue( tbPatType.Rows[i]["ITEMTYPE"] , true );
                string FAVORABLE_SCALE = getValue( tbPatType.Rows[i]["FAVORABLE_SCALE"] , true );

                string sql = @"insert into BASE_ITEMMX_FAVORABLE(PATTYPECODE,ITEMID,ITEMTYPE,FAVORABLE_SCALE) 
                                values ('" + PATTYPECODE + "','" + ITEMID + "'," + ITEMTYPE + "," + FAVORABLE_SCALE + ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery( );
            }
            if ( AfterTableDownLoadOver != null )
                AfterTableDownLoadOver( "下载项目明细优惠设置完成！" );
        }
        
        private void ConnectToAccessFile()
        {
            string dbPath = System.Windows.Forms.Application.StartupPath + "\\HIS.mdb";
            accessConnection = new System.Data.OleDb.OleDbConnection( );
            accessConnection.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbPath + ";User Id=;Password=;";
            try
            {
                accessConnection.Open( );
            }
            catch(Exception err)
            {
                throw err;
            }
        }

        private string getValue( object obj , bool numeric )
        {
            if ( obj == null )
            {
                if ( numeric )
                    return "0";
                else
                    return "";
            }
            else
            {
                return obj.ToString( ).Trim( );
            }
        }

       
    }
}
