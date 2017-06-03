using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.Model;

namespace HIS.Base_BLL 
{
    public class BaseDataController : HIS.SYSTEM.Core.BaseBLL
    {
       /// <summary>
        /// 从数据库系统表（SYSIBM.SYSTABLES和SYSIBM.SYSCOLUMNS）中获取HIS系统的表列名称的列表
       /// </summary>
       /// <returns></returns>
        public static DataTable GetTableColumn()
        {
            string sql = @"select b.tbname,b.name from
                            (select name from sysibm.systables where type='T' and creator = 'DB2INST2') a,
                            (select tbname,name from sysibm.syscolumns ) b 
                            where a.name = b.tbname";
            return oleDb.GetDataTable( sql );
        }
        /// <summary>
        /// 从数据库系统表（SYSIBM.SYSTABLES）中获取HIS系统表名称的列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetSystemTableList()
        {
            string sql = "select name from sysibm.systables where type='T' and creator = 'DB2INST2'";
                            
                            
            return oleDb.GetDataTable( sql );
        }
        /// <summary>
        /// 生成拼音五笔编码
        /// </summary>
        /// <param name="tableName"></param>
        /// <param name="nameColumn"></param>
        /// <param name="keyColumn"></param>
        /// <param name="pyColumn"></param>
        /// <param name="wbColumn"></param>
        public static void UpdatePYWBField(string tableName, ColumnInfo nameColumn,ColumnInfo keyColumn,
            ColumnInfo pyColumn, ColumnInfo wbColumn )
        {
            if ( pyColumn == null && wbColumn == null )
                return;
            if ( ( pyColumn != null && pyColumn.DataValue == null ) && ( wbColumn != null && wbColumn.DataValue == null ) )
            {
                return;
            }

            StringBuilder sb = new StringBuilder( );
            sb.Append( "update " + tableName + " set " );
            if ( pyColumn != null && pyColumn.DataValue != null )
                sb.Append( pyColumn.ColumnName + "='"+ pyColumn.DataValue.ToString() +"'," );
            if ( wbColumn != null && wbColumn.DataValue != null )
                sb.Append( wbColumn.ColumnName + "='" + wbColumn.DataValue.ToString() + "'," );
            sb.Remove( sb.Length - 1 , 1 );
            sb.Append( "where " + nameColumn.ColumnName + "='" + nameColumn.DataValue.ToString( ) + "'" );
            if ( keyColumn.IsNumeric )
                sb.Append( " and " + keyColumn.ColumnName + "=" + keyColumn.DataValue.ToString( ) );
            else
                sb.Append( " and " + keyColumn.ColumnName + "='" + keyColumn.DataValue.ToString( ) + "'");

            oleDb.DoCommand( sb.ToString() );
        }
        /// <summary>
        /// 新增基础数据到数据库
        /// </summary>
        public static void AddNewBaseDataRecord( BaseDataRecord objValue, string TableName )
        {
            List<string> fields = new List<string>();
            List<string> values = new List<string>();
            foreach ( BaseDataRecordField field in objValue.RecordFields )
            {
                if ( field.FieldConfig.IS_PRIMARY_KEY && field.FieldConfig.AUTO_INCREASE )
                {
                    continue;
                }
                else
                {
                    fields.Add( field.FieldConfig.FIELD_DB_NAME );
                    if ( field.FieldConfig.FIELD_DB_TYPE == HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字 )
                    {
                        values.Add( field.DataValue.ToString() );
                    }
                    else
                        values.Add( "'" + field.DataValue.ToString() + "'" );
                }
            }
            if (!TableAndFieldConfig.IsCommonTable(TableName))
            {
                fields.Add("workid");
                values.Add(HIS.SYSTEM.Core.EntityConfig.WorkID.ToString());
            }
            else
            {
                fields.Add("workid");
                values.Add("1");
            }

            StringBuilder sb = new StringBuilder();
            sb.Append( "INSERT INTO " + TableName + "(" );
            for ( int i = 0; i < fields.Count - 1; i++ )
                sb.Append( fields[i] + "," );
            sb.Append( fields[fields.Count - 1] + ") VALUES (" );
            for ( int i = 0; i < values.Count - 1; i++ )
                sb.Append( values[i] + "," );
            sb.Append( values[values.Count - 1] + ")" );
            try
            {
                oleDb.DoCommand( sb.ToString() );
            }
            catch ( Exception err )
            {
                ( new ErrorController() ).LogEvent( err.Message + "\r\n" + err.StackTrace );
                throw new Exception( "新增数据发生错误！" );
            }
            
        }
        /// <summary>
        /// 更新基础数据到数据库
        /// </summary>
        public static void UpdateBaseDataRecord( BaseDataRecord objValue, string TableName )
        {
            List<string> field_and_value = new List<string>();
            List<string> update_condiction_pk = new List<string>();//where 条件
            //List<string> update_condiction_field = new List<string>();//where 条件
            foreach ( BaseDataRecordField field in objValue.RecordFields )
            {
                if ( field.FieldConfig.IS_PRIMARY_KEY  )
                {
                    //自增长的主键列不能更新
                    string f_pk = field.FieldConfig.FIELD_DB_NAME;
                    if ( field.FieldConfig.FIELD_DB_TYPE == HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字 )
                        f_pk = f_pk + " = " + ( field.DataValue == null ? "0" : field.DataValue.ToString() );
                    else
                        f_pk = f_pk + " = '" + ( field.DataValue == null ? "" : field.DataValue.ToString() ) + "'";
                    update_condiction_pk.Add( f_pk );
                }
                else
                {
                    if ( field.FieldConfig.ALLOW_EDIT )//不允许编辑的列不更新
                    {
                        string f_v = field.FieldConfig.FIELD_DB_NAME;
                        if ( field.FieldConfig.FIELD_DB_TYPE == HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字 )
                            f_v = f_v + " = " + ( field.DataValue == null ? "0" : field.DataValue.ToString() );
                        else
                            f_v = f_v + " = '" + ( field.DataValue == null ? "" : field.DataValue.ToString() ) + "'";
                        field_and_value.Add( f_v );
                    }

                }
            }

            if ( update_condiction_pk.Count == 0 )
                throw new Exception("没有指定主键的表无法更新,请确认数据表设置了主键或者配置字段设置了主键");

            if (!TableAndFieldConfig.IsCommonTable(TableName))
                update_condiction_pk.Add("workid = " + HIS.SYSTEM.Core.EntityConfig.WorkID);

            StringBuilder sb = new StringBuilder();
            sb.Append( "UPDATE " );
            sb.Append( TableName );
            sb.Append( " SET " );
            for ( int i = 0; i < field_and_value.Count - 1; i++ )
                sb.Append( field_and_value[i] + "," );
            sb.Append( field_and_value[field_and_value.Count-1] );
            sb.Append( " WHERE " );
            for ( int i = 0; i < update_condiction_pk.Count-1; i++ )
                sb.Append( update_condiction_pk[i] + " AND " );
            sb.Append( update_condiction_pk[update_condiction_pk.Count - 1] );

            try
            {
                oleDb.DoCommand( sb.ToString() );
            }
            catch(Exception err)
            {
                ( new ErrorController() ).LogEvent( err.Message + "\r\n" + err.StackTrace );
                throw new Exception("更新数据发生错误！");
            }
          
        }
        /// <summary>
        /// 删除指定的基础数据记录
        /// </summary>
        /// <param name="objValue"></param>
        /// <param name="TableName"></param>
        public static void DeleteBaseDataRecord(BaseDataRecord objValue, TableConfig TableInfo)
        {
            if (!TableInfo.ALLOW_PHYSIC_DELETE)
                throw new Exception("当前表的记录不允许删除操作，请通过修改记录的删除标志来标记记录是否可用！");

            List<string> delete_condiction_pk = new List<string>();//where 条件

            foreach (BaseDataRecordField field in objValue.RecordFields)
            {
                if (field.FieldConfig.IS_PRIMARY_KEY)
                {
                    string f_pk = field.FieldConfig.FIELD_DB_NAME;
                    if (field.FieldConfig.FIELD_DB_TYPE == HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字)
                        f_pk = f_pk + " = " + (field.DataValue == null ? "0" : field.DataValue.ToString());
                    else
                        f_pk = f_pk + " = '" + (field.DataValue == null ? "" : field.DataValue.ToString()) + "'";
                    delete_condiction_pk.Add(f_pk);
                }
            }

            if (delete_condiction_pk.Count == 0)
                throw new Exception("没有指定主键的表无法删除,请确认数据表设置了主键或者配置字段设置了主键");
            if (!TableAndFieldConfig.IsCommonTable(TableInfo.BASE_TABLE_DB_NAME))
                delete_condiction_pk.Add("workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID.ToString());
            
            StringBuilder sb = new StringBuilder();
            sb.Append("DELETE FROM  ");
            sb.Append(TableInfo.BASE_TABLE_DB_NAME);
            sb.Append(" WHERE ");
            for (int i = 0; i < delete_condiction_pk.Count - 1; i++)
                sb.Append(delete_condiction_pk[i] + " AND ");
            sb.Append(delete_condiction_pk[delete_condiction_pk.Count - 1]);

            try
            {
                oleDb.DoCommand(sb.ToString());
            }
            catch (Exception err)
            {
                (new ErrorController()).LogEvent(err.Message + "\r\n" + err.StackTrace);
                throw new Exception("删除数据发生错误！");
            }
        }
        /// <summary>
        /// 获取指定表的数据
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="Fields"></param>
        /// <param name="strWhere"></param>
        public static DataTable GetDataTable( string TableName, string[] Fields, string strWhere )
        {
            return BindEntity<object>.CreateInstanceDAL( oleDb, TableName ).GetList( strWhere, Fields );
        }

        /// <summary>
        /// 返回需要维护的基础表的列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVindicateTableList()
        {
            return BindEntity<BASE_VINDICATE_TABLE>.CreateInstanceDAL( oleDb ).GetList( "" );
        }
        /// <summary>
        /// 返回基础表字段维护列表
        /// </summary>
        /// <returns></returns>
        public static DataTable GetVindicateTableFieldList( string strWhere )
        {
            return BindEntity<BASE_TABLE_CONFIG>.CreateInstanceDAL( oleDb ).GetList( strWhere );
        }
        /// <summary>
        /// 返回指定表的数据
        /// </summary>
        /// <param name="TableName">指定的表名称</param>
        /// <param name="strWhere">where 条件</param>
        /// <returns></returns>
        public static DataTable GetBaseTableData( string TableName , string strWhere )
        {
            return BindEntity<object>.CreateInstanceDAL( oleDb , TableName ).GetList( strWhere );

        }
        /// <summary>
        /// 返回指定表数据表，列为指定列
        /// </summary>
        /// <param name="TableName">表名</param>
        /// <param name="Fields">要返回的列名</param>
        /// <param name="strWhere">where条件</param>
        /// <returns></returns>
        public static DataTable GetBaseTableData( string TableName , string[] Fields , string strWhere )
        {


            string sql = "";
            if ( Fields != null )
            {
                sql = oleDb.Table( TableName , "" , strWhere , Fields );
                return oleDb.GetDataTable( sql );
            }
            else
                return BindEntity<object>.CreateInstanceDAL( oleDb , TableName ).GetList( strWhere );
        }
    }

    public class ColumnInfo
    {
        public string ColumnName;
        public bool IsNumeric;
        public object DataValue;
    }
}
