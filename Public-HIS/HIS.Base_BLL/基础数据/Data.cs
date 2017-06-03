using System;
using System.Data;

namespace HIS.Base_BLL
{
    public class Data 
    {
        public Data( DataTable dataTable )
        {
            table = dataTable;
        }
        private DataTable table;
        /// <summary>
        /// 对应的数据表
        /// </summary>
        public DataTable Table
        {
            get
            {
                return table;
            }
        }
        /// <summary>
        /// 判断指定的条件是否有有效记录
        /// </summary>
        /// <param name="filterString"></param>
        /// <returns></returns>
        public bool Exists( string filterString )
        {
            try
            {
                if ( table != null )
                {
                    if ( table.Select( filterString ).Length == 0 )
                        return false;
                    else
                        return true;
                }
                else
                    throw new Exception( "数据未读取" );
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 得到指定的记录的某一字段的值，可能返回null
        /// </summary>
        /// <param name="idValue"></param>
        /// <param name="idFieldName"></param>
        /// <param name="valueFieldName"></param>
        /// <returns></returns>
        public object GetValue( object idValue , string idFieldName , string valueFieldName )
        {
            return GetValue( idValue , idFieldName , valueFieldName , null );
        }
        /// <summary>
        /// 得到指定的记录的某一字段的值，可能返回null，由nullValue而定
        /// </summary>
        /// <param name="idValue">标识符值</param>
        /// <param name="idFieldName">标识符字段名</param>
        /// <param name="valueFieldName">要取值的字段名</param>
        /// <param name="nullValue">空值的默认值</param>
        /// <returns></returns>
        public object GetValue( object idValue , string idFieldName , string valueFieldName ,object nullValue)
        {
            string selectString = "";
            string quotChar = "";
            if ( idValue is string )
                quotChar = "'";
            selectString = idFieldName + " = " + quotChar + idValue.ToString() + quotChar;
            try
            {
                DataRow[] drs = table.Select( selectString );
                if ( drs.Length == 0 )
                    return "";
                else
                {
                    if ( Convert.IsDBNull( drs[0][valueFieldName] ) )
                    {
                        return nullValue;
                    }
                    else
                    {
                        return drs[0][valueFieldName];
                    }
                }
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 得到指定条件的行
        /// </summary>
        /// <param name="filterString">查询条件</param>
        /// <returns></returns>
        public DataRow GetRow( string filterString )
        {
            try
            {
                if ( table != null )
                {
                    DataRow[] drs = table.Select( filterString );
                    if ( drs.Length > 0 )
                        return drs[0];
                    else
                        return null;
                }
                else
                    return null;
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 得到符合指定条件的所有行
        /// </summary>
        /// <param name="filterString">查询条件</param>
        /// <returns></returns>
        public DataRow[] GetRows( string filterString )
        {
            try
            {
                if ( table != null )
                {
                    DataRow[] drs = table.Select( filterString );
                    return drs;
                }
                else
                    return null;
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 得到指定条件的记录表
        /// </summary>
        /// <param name="filterString"></param>
        /// <returns></returns>
        public DataTable GetFilterTable( string filterString )
        {
            try
            {
                if ( table != null )
                {
                    DataRow[] drs = table.Select( filterString );
                    if ( drs.Length > 0 )
                        return drs.CopyToDataTable();
                    else
                        return table.Clone();
                }
                else
                    return null;
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 得到数据集名
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            if ( table != null )
                return table.TableName;
            else
                return "";
        }
        
    }
}
