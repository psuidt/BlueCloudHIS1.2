using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using HIS.Model;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.Base_BLL.Enums;
using HIS.BLL;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 基础表维护配置管理类
    /// </summary>
    public class TableAndFieldConfig : BaseBLL
    {
        /// <summary>
        /// 增加字段配置的默认值
        /// </summary>
        /// <param name="TableName"></param>
        /// <param name="FieldName"></param>
        public static void AddDefaultConfig( TableConfig TableInfo, string FieldName )
        {
            BASE_TABLE_CONFIG config = new BASE_TABLE_CONFIG();
            config.TABLE_CN_NAME = TableInfo.BASE_TABLE_CN_NAME;
            config.TABLE_DB_NAME = TableInfo.BASE_TABLE_DB_NAME;
            config.FIELD_CN_NAME = FieldName;
            config.FIELD_DB_NAME = FieldName;
            config.FIELD_DB_TYPE = (int)FIELD_DB_TYPE.字符;
            config.ALLOW_EDIT = 1;
            config.ALLOW_EMPTY = 1;
            config.MAXLENGTH = 0;
            config.AUTO_INCREASE = 0;
            config.FOREIGNER_FIELD_CN_NAME = "";
            config.FOREIGNER_FIELD_DB_NAME = "";
            config.FOREIGNER_FILTER_SQL = "";
            config.FOREIGNER_TABLE = "";
            config.GRID_COL_WIDTH = 75;
            config.UIC_TYPE = (int)ControlType.TextBox;
            config.WIDTH = 75;
            config.HEIGHT = 30;
            config.FIELD_MARK_TYPE = 0;
            string strWhere = Tables.base_table_config.TABLE_DB_NAME + oleDb.EuqalTo() + "'" + config.TABLE_DB_NAME + "'" + oleDb.And() + Tables.base_table_config.FIELD_DB_NAME + oleDb.EuqalTo() + "'" + config.FIELD_DB_NAME + "'";
            if ( BindEntity<BASE_TABLE_CONFIG>.CreateInstanceDAL( oleDb ).Exists( strWhere ) )
            {
                return;
            }
            else
            {
                BindEntity<BASE_TABLE_CONFIG>.CreateInstanceDAL( oleDb ).Add( config );
            }
        }
        /// <summary>
        /// 更新配置
        /// </summary>
        /// <param name="Configs"></param>
        public static void UpdateFieldConfig(List<FieldConfig> Configs)
        {
            oleDb.BeginTransaction();
            try
            {
                for ( int i = 0; i < Configs.Count; i++ )
                {
                    FieldConfig Config = Configs[i];
                    string strWhere = Tables.base_table_config.TABLE_DB_NAME + oleDb.EuqalTo() + "'" + Config.TABLE_DB_NAME + "'" + oleDb.And() + Tables.base_table_config.FIELD_DB_NAME + oleDb.EuqalTo() + "'" + Config.FIELD_DB_NAME + "'";
                    BASE_TABLE_CONFIG config = BindEntity<BASE_TABLE_CONFIG>.CreateInstanceDAL( oleDb ).GetModel( strWhere );
                    if ( config != null )
                    {
                        BindEntity<BASE_TABLE_CONFIG>.CreateInstanceDAL( oleDb ).Update( strWhere,
                                            Tables.base_table_config.ALLOW_EDIT + oleDb.EuqalTo() + ( Config.ALLOW_EDIT ? "1" : "0" ),
                                            Tables.base_table_config.ALLOW_EMPTY + oleDb.EuqalTo() + ( Config.ALLOW_EMPTY ? "1" : "0" ),
                                            Tables.base_table_config.AUTO_INCREASE + oleDb.EuqalTo() + ( Config.AUTO_INCREASE ? "1" : "0" ),
                                            Tables.base_table_config.FIELD_CN_NAME + oleDb.EuqalTo() + "'" + Config.FIELD_CN_NAME + "'",
                                            Tables.base_table_config.FIELD_DB_NAME + oleDb.EuqalTo() + "'" + Config.FIELD_DB_NAME + "'",
                                            Tables.base_table_config.FIELD_DB_TYPE + oleDb.EuqalTo() + (int)Config.FIELD_DB_TYPE,
                                            Tables.base_table_config.FOREIGNER_FIELD_CN_NAME + oleDb.EuqalTo() + "'" + Config.FOREIGNER_FIELD_CN_NAME + "'",
                                            Tables.base_table_config.FOREIGNER_FIELD_DB_NAME + oleDb.EuqalTo() + "'" + Config.FOREIGNER_FIELD_DB_NAME + "'",
                                            Tables.base_table_config.FOREIGNER_FILTER_SQL + oleDb.EuqalTo() + "'" + Config.FOREIGNER_FILTER_SQL + "'",
                                            Tables.base_table_config.FOREIGNER_TABLE + oleDb.EuqalTo() + "'" + Config.FOREIGNER_TABLE + "'",
                                            Tables.base_table_config.GRID_COL_WIDTH + oleDb.EuqalTo() + Config.GRID_COL_WIDTH,
                                            Tables.base_table_config.HEIGHT + oleDb.EuqalTo() + Config.HEIGHT,
                                            Tables.base_table_config.IS_FOREIGNER_KEY + oleDb.EuqalTo() + ( Config.IS_FOREIGNER_KEY ? "1" : "0" ),
                                            Tables.base_table_config.IS_PRIMARY_KEY + oleDb.EuqalTo() + ( Config.IS_PRIMARY_KEY ? "1" : "0" ),
                                            Tables.base_table_config.LOCATION_X + oleDb.EuqalTo() + Config.LOCATION_X,
                                            Tables.base_table_config.LOCATION_Y + oleDb.EuqalTo() + Config.LOCATION_Y,
                                            Tables.base_table_config.TABINDEX + oleDb.EuqalTo() + Config.TABINDEX,
                                            Tables.base_table_config.MAXLENGTH + oleDb.EuqalTo() + Config.MAXLENGTH,
                                            Tables.base_table_config.TABLE_CN_NAME + oleDb.EuqalTo() + "'" + Config.TABLE_CN_NAME + "'",
                                            Tables.base_table_config.TABLE_DB_NAME + oleDb.EuqalTo() + "'" + Config.TABLE_DB_NAME + "'",
                                            Tables.base_table_config.UIC_TYPE + oleDb.EuqalTo() + (int)Config.UIC_TYPE,
                                            Tables.base_table_config.WIDTH + oleDb.EuqalTo() + Config.WIDTH,
                                            Tables.base_table_config.FIELD_MARK_TYPE + oleDb.EuqalTo() + (int)Config.FIELD_MARK_TYPE );
                    }
                }
                oleDb.CommitTransaction();
            }
            catch 
            {
                oleDb.RollbackTransaction();
            }
        }
        /// <summary>
        /// 删除字段配置
        /// </summary>
        /// <param name="TableInfo"></param>
        /// <param name="FieldName"></param>
        public static void DeleteFieldConfig( TableConfig TableInfo, List<string> FieldList )
        {
            oleDb.BeginTransaction();
            try
            {
                foreach ( string FieldName in FieldList )
                {
                    string strWhere = Tables.base_table_config.TABLE_DB_NAME + oleDb.EuqalTo() + "'" + TableInfo.BASE_TABLE_DB_NAME.ToString() + "' And " +
                        Tables.base_table_config.FIELD_DB_NAME + oleDb.EuqalTo() + "'" + FieldName + "'";

                    BindEntity<BASE_TABLE_CONFIG>.CreateInstanceDAL( oleDb ).Delete( strWhere );
                }
                oleDb.CommitTransaction();
            }
            catch 
            {
                oleDb.RollbackTransaction();
            }
        }
        /// <summary>
        /// 增加表配置
        /// </summary>
        /// <param name="Config"></param>
        public static void AddTableConfig( TableConfig Config )
        {
            string strWhere = Tables.base_vindicate_table.BASE_TABLE_DB_NAME + oleDb.EuqalTo() + "'" + Config.BASE_TABLE_DB_NAME + "'";
            BASE_VINDICATE_TABLE table = BindEntity<BASE_VINDICATE_TABLE>.CreateInstanceDAL( oleDb ).GetModel( strWhere );
            if ( table != null )
                throw new Exception( "表名已经存在！" );
            try
            {
                BindEntity<BASE_VINDICATE_TABLE>.CreateInstanceDAL( oleDb ).Add( new string[] { Tables.base_vindicate_table.BASE_TABLE_DB_NAME, 
                                                                                           Tables.base_vindicate_table.BASE_TABLE_CN_NAME,
                                                                                           Tables.base_vindicate_table.ALLOW_USER_EDIT},
                                                                              new string[] { "'" + Config.BASE_TABLE_DB_NAME + "'", 
                                                                                            "'" + Config.BASE_TABLE_CN_NAME + "'",
                                                                                            (Config.ALLOW_USER_EDIT ? "1":"0")},
                                                                              new bool[]{false,false,false} );
            }
            catch ( Exception err )
            {
                (new ErrorController()).LogEvent(err.Message + "\r\n" + err.StackTrace );
                throw new Exception("新增表配置发生错误！");
            }
        }
        /// <summary>
        /// 更新表配置
        /// </summary>
        /// <param name="Config"></param>
        public static void UpdateTableConfig( TableConfig Config )
        {
            string strWhere = Tables.base_vindicate_table.BASE_TABLE_DB_NAME + oleDb.EuqalTo() + "'" + Config.BASE_TABLE_DB_NAME + "'";
            BASE_VINDICATE_TABLE table = BindEntity<BASE_VINDICATE_TABLE>.CreateInstanceDAL( oleDb ).GetModel( strWhere );
            if ( table == null )
                throw new Exception( "表名不存在！" );
            try
            {
                BindEntity<BASE_VINDICATE_TABLE>.CreateInstanceDAL( oleDb ).Update( strWhere,
                                                          Tables.base_vindicate_table.BASE_TABLE_CN_NAME + oleDb.EuqalTo() + "'" + Config.BASE_TABLE_CN_NAME + "'",
                                                          Tables.base_vindicate_table.ALLOW_USER_EDIT + oleDb.EuqalTo() + ( Config.ALLOW_USER_EDIT ? "1" : "0" ) );
            }
            catch ( Exception err )
            {
                ( new ErrorController() ).LogEvent( err.Message + "\r\n" + err.StackTrace );
                throw new Exception( "保存表配置发生错误！" );
            }
        }
        /// <summary>
        /// 删除表配置
        /// </summary>
        /// <param name="Config"></param>
        public static void DeleteTableConfig( TableConfig Config )
        {
            string strWhere1 = Tables.base_vindicate_table.BASE_TABLE_DB_NAME + oleDb.EuqalTo() + "'" + Config.BASE_TABLE_DB_NAME + "'";
            string strWhere2 = Tables.base_table_config.TABLE_DB_NAME + oleDb.EuqalTo() + "'" + Config.BASE_TABLE_DB_NAME + "'";
            oleDb.BeginTransaction();
            try
            {
                BindEntity<BASE_TABLE_CONFIG>.CreateInstanceDAL( oleDb ).Delete( strWhere2 );
                BindEntity<BASE_VINDICATE_TABLE>.CreateInstanceDAL( oleDb ).Delete( strWhere1 );
                oleDb.CommitTransaction();
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction();
                ( new ErrorController() ).LogEvent( err.Message + "\r\n" + err.StackTrace );
                throw new Exception("删除表配置发生错误！");
            }

        }
        /// <summary>
        /// 根据表明判断是否为共享表
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public static bool IsCommonTable(string TableName)
        {
            DAL_Model table = HIS.SYSTEM.Core.EntityConfig.dal_m.Find(delegate(DAL_Model m)
            {
                if (m.TableName.ToUpper() == TableName.ToUpper())
                    return true;
                else
                    return false;
            });
            if (table != null)
                return table.IsBG;
            else
                throw new Exception("没有读取到表配置！");
        }
    }
}
