using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Base_BLL;
using HIS.SYSTEM.PubicBaseClasses;
using System.Reflection;
using HIS.BLL;
using System.Collections;

namespace HIS_BaseManager.基本数据维护.Controller
{
    /// <summary>
    /// 字段维护界面控制器
    /// </summary>
    public class FrmVindicatorConfigController
    {
        private IFrmVindicatorConfig formView;
        /// <summary>
        /// 控制器
        /// </summary>
        /// <param name="FormView">界面试图</param>
        public FrmVindicatorConfigController( IFrmVindicatorConfig FormView )
        {
            formView = FormView;
        }

        private DataTable tbFieldConfig;//字段配置表
        private List<Item> lstField; //当前表的字段列表
        private TableConfig tableInfo;
        private DataTable tbSystemTable;
        private bool isShowing; //标记是否为正在显示数据，防止因显示数据而引发ConfigValueChange事件

        private DataTable GetVindicateTableFieldList( )
        {
            DataTable tbTemp = BaseDataReader.GetVindicateTableFieldList( Tables.base_table_config.TABLE_DB_NAME + " = '" + tableInfo.BASE_TABLE_DB_NAME.ToString().Trim() + "'" );
            tbFieldConfig = tbTemp.Clone();
            DataRow[] drs = tbTemp.Select( "", Tables.base_table_config.TABINDEX + " ASC" );
            for ( int i = 0; i < drs.Length; i++ )
                tbFieldConfig.Rows.Add( drs[i].ItemArray );
            return tbFieldConfig ;
        }

        /// <summary>
        /// 系统数据表名列表
        /// </summary>
        public DataTable SystemTable
        {
            get
            {
                return tbSystemTable;
            }
        }
        /// <summary>
        /// 当前表信息
        /// </summary>
        public TableConfig TableInfo
        {
            get
            {
                return tableInfo;
            }
            set
            {
                tableInfo = value;
            }
        }
        /// <summary>
        /// 当前表的字段列表
        /// </summary>
        public List<Item> TableFields
        {
            get
            {
                return lstField;
            }
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        public void Initalize()
        {

            tbSystemTable = BaseDataController.GetSystemTableList();
            //加载字段配置表
            tbFieldConfig = GetVindicateTableFieldList();
            ////根据表名从DLL加载字段列表
            //string dllName = System.Windows.Forms.Application.StartupPath + "\\HIS.Entity.dll";
            //Assembly assembly = Assembly.LoadFile( dllName );
            //string typeName = "HIS.Model." + tableInfo.BASE_TABLE_DB_NAME.ToString().Trim();
            //object obj = assembly.CreateInstance( typeName, true );
            //if ( obj == null )
            //    throw new Exception( "未能从实体文件加载表对象【"+typeName + "】");
            //PropertyInfo[] properies = obj.GetType().GetProperties();
            //获取当前数据库表
            DataTable tb = BaseDataReader.GetBaseTableData( tableInfo.BASE_TABLE_DB_NAME.ToString(), "1>2" );
            lstField = new List<Item>();
            bool reloadConfig = false;
            for ( int i = 0; i < tb.Columns.Count; i++ )
            {
                string strWhere = Tables.base_table_config.TABLE_DB_NAME + " = '" + tableInfo.BASE_TABLE_DB_NAME.ToString().Trim() + "' and "
                                + Tables.base_table_config.FIELD_DB_NAME + " = '" + tb.Columns[i].ColumnName + "'";
                DataRow[] drsFields = tbFieldConfig.Select( strWhere );
                if ( drsFields.Length == 0 )
                {
                    TableAndFieldConfig.AddDefaultConfig( tableInfo, tb.Columns[i].ColumnName );
                    reloadConfig = true;
                }
            }
            if ( reloadConfig )
                tbFieldConfig = GetVindicateTableFieldList();
            for ( int i = 0; i < tbFieldConfig.Rows.Count; i++ )
            {
                Item item = new Item();
                item.Text =  tbFieldConfig.Rows[i][Tables.base_table_config.FIELD_CN_NAME].ToString().Trim();
                item.Value = tbFieldConfig.Rows[i][Tables.base_table_config.FIELD_DB_NAME].ToString().Trim();
                lstField.Add( item );
            }
        }
        /// <summary>
        /// 显示配置明细内容
        /// </summary>
        public void ShowFieldConfig()
        {
            string strWhere = Tables.base_table_config.TABLE_DB_NAME + " = '" + tableInfo.BASE_TABLE_DB_NAME.ToString().Trim() + "' and "
                                + Tables.base_table_config.FIELD_DB_NAME + " = '" + formView.SelectedField + "'";

            DataRow[] drsFields = tbFieldConfig.Select( strWhere );
            if ( drsFields.Length == 0 )
            {
                throw new Exception( "配置列表中没有找到字段【" + formView.TABLE_DB_NAME + "." + formView.FIELD_DB_NAME + "】的配置记录!" );
            }
            else if ( drsFields.Length > 1 )
            {
                throw new Exception( "配置列表中字段【" + formView.TABLE_DB_NAME + "." + formView.FIELD_DB_NAME + "】的配置记录有多条，请检查!" );
            }
            else
            {
                isShowing = true;
                formView.ALLOW_EDIT = Convert.ToInt32( drsFields[0][Tables.base_table_config.ALLOW_EDIT] );
                formView.ALLOW_EMPTY = Convert.ToInt32( drsFields[0][Tables.base_table_config.ALLOW_EMPTY] );
                formView.AUTO_INCREASE = Convert.ToInt32( drsFields[0][Tables.base_table_config.AUTO_INCREASE] );
                formView.FIELD_CN_NAME = drsFields[0][Tables.base_table_config.FIELD_CN_NAME].ToString().Trim();
                formView.FIELD_DB_NAME = drsFields[0][Tables.base_table_config.FIELD_DB_NAME].ToString().Trim();
                formView.FIELD_DB_TYPE = Convert.ToInt32( drsFields[0][Tables.base_table_config.FIELD_DB_TYPE]);
                formView.FOREIGNER_TABLE = drsFields[0][Tables.base_table_config.FOREIGNER_TABLE].ToString().Trim();
                formView.FOREIGNER_FIELD_CN_NAME = drsFields[0][Tables.base_table_config.FOREIGNER_FIELD_CN_NAME].ToString().Trim();
                formView.FOREIGNER_FIELD_DB_NAME = drsFields[0][Tables.base_table_config.FOREIGNER_FIELD_DB_NAME].ToString().Trim();
                formView.FOREIGNER_FILTER_SQL = drsFields[0][Tables.base_table_config.FOREIGNER_FILTER_SQL].ToString().Trim();
                formView.GRID_COL_WIDTH = Convert.ToInt32( drsFields[0][Tables.base_table_config.GRID_COL_WIDTH] );
                formView.HEIGHT = Convert.ToInt32( drsFields[0][Tables.base_table_config.HEIGHT] );
                formView.IS_FOREIGNER_KEY = Convert.ToInt32( drsFields[0][Tables.base_table_config.IS_FOREIGNER_KEY] );
                formView.IS_PRIMARY_KEY = Convert.ToInt32( drsFields[0][Tables.base_table_config.IS_PRIMARY_KEY] );
                formView.LOCATION_X = Convert.ToInt32( drsFields[0][Tables.base_table_config.LOCATION_X] );
                formView.LOCATION_Y = Convert.ToInt32( drsFields[0][Tables.base_table_config.LOCATION_Y] );
                formView.MAXLENGTH = Convert.ToInt32( drsFields[0][Tables.base_table_config.MAXLENGTH] );
                formView.TABINDEX = Convert.ToInt32( drsFields[0][Tables.base_table_config.TABINDEX] );
                formView.TABLE_CN_NAME = drsFields[0][Tables.base_table_config.TABLE_CN_NAME].ToString().Trim();
                formView.TABLE_DB_NAME = drsFields[0][Tables.base_table_config.TABLE_DB_NAME].ToString().Trim();
                formView.UIC_TYPE = Convert.ToInt32( drsFields[0][Tables.base_table_config.UIC_TYPE] );
                formView.WIDTH = Convert.ToInt32( drsFields[0][Tables.base_table_config.WIDTH] );
                formView.FIELD_MARK_TYPE = Convert.ToInt32( drsFields[0][Tables.base_table_config.FIELD_MARK_TYPE] );
                isShowing = false;
            }
        }
        /// <summary>
        /// 获取指定的表字段
        /// </summary>
        /// <param name="TableName"></param>
        /// <returns></returns>
        public List<string> GetSystemFieldList( string TableName )
        {
            //string dllName = System.Windows.Forms.Application.StartupPath + "\\HIS.Entity.dll";
            //Assembly assembly = Assembly.LoadFile( dllName );
            //string typeName = "HIS.Model." + TableName;
            //object obj = assembly.CreateInstance( typeName, true );
            //List<string> lstField = new List<string>();
            //if ( obj != null )
            //{
            //    PropertyInfo[] properies = obj.GetType().GetProperties();
            //    for ( int i = 0; i < properies.Length; i++ )
            //    {
            //        lstField.Add( properies[i].Name );
            //    }
            //}
            //return lstField;
            DataRow[] drsFields = BaseDataController.GetTableColumn().Select("TBNAME='" + TableName + "'");
            List<string> lstField = new List<string>();
            foreach (DataRow dr in drsFields) 
            {
                lstField.Add(dr["NAME"].ToString().Trim());
            }
            return lstField;
        }
        /// <summary>
        /// 更新前的数据验证
        /// </summary>
        /// <returns></returns>
        public bool CheckUpDataBeforeUpdate()
        {
            if ( formView.SelectedField == "" )
                throw new Exception("没有指定要修改的字段！");
            DataRow[] drs = tbFieldConfig.Select( Tables.base_table_config.FIELD_MARK_TYPE + "=" + (int)HIS.Base_BLL.Enums.FIELD_MARK_TYPE.名称 );
            if ( drs.Length > 1 )
                throw new Exception( "表内的名称标识字段只能设置一个！" );
            drs = tbFieldConfig.Select( Tables.base_table_config.FIELD_MARK_TYPE + "=" + (int)HIS.Base_BLL.Enums.FIELD_MARK_TYPE.拼音码 );
            if ( drs.Length > 1 )
                throw new Exception( "表内的拼音码标识字段只能设置一个！" );
            drs = tbFieldConfig.Select( Tables.base_table_config.FIELD_MARK_TYPE + "=" + (int)HIS.Base_BLL.Enums.FIELD_MARK_TYPE.五笔码 );
            if ( drs.Length > 1 )
                throw new Exception( "表内的五笔码标识字段只能设置一个！" );


            return true;
        }
        /// <summary>
        /// 更新配置
        /// </summary>
        public void UpdateConfig()
        {
            List<FieldConfig> configs = GetFieldConfigs();
            TableAndFieldConfig.UpdateFieldConfig( configs );
        }
        /// <summary>
        /// 数据发生改变
        /// </summary>
        public void ConfigValueChanged()
        {
            if ( formView.SelectedField == "" )
                return;
            if ( !isShowing )
            {
                string strWhere = Tables.base_table_config.TABLE_DB_NAME + " = '" + tableInfo.BASE_TABLE_DB_NAME.ToString().Trim() + "' and "
                                    + Tables.base_table_config.FIELD_DB_NAME + " = '" + formView.SelectedField + "'";
                DataRow[] drsFields = tbFieldConfig.Select( strWhere );
                if ( drsFields.Length == 0 )
                {
                    throw new Exception( "配置列表中没有找到字段【" + formView.TABLE_DB_NAME + "." + formView.FIELD_DB_NAME + "】的配置记录!" );
                }
                else if ( drsFields.Length > 1 )
                {
                    throw new Exception( "配置列表中字段【" + formView.TABLE_DB_NAME + "." + formView.FIELD_DB_NAME + "】的配置记录有多条，请检查!" );
                }
                else
                {
                    drsFields[0][Tables.base_table_config.ALLOW_EDIT] = formView.ALLOW_EDIT;
                    drsFields[0][Tables.base_table_config.ALLOW_EMPTY] = formView.ALLOW_EMPTY;
                    drsFields[0][Tables.base_table_config.AUTO_INCREASE] = formView.AUTO_INCREASE;
                    drsFields[0][Tables.base_table_config.FIELD_CN_NAME] = formView.FIELD_CN_NAME;
                    drsFields[0][Tables.base_table_config.FIELD_DB_NAME] = formView.FIELD_DB_NAME;
                    drsFields[0][Tables.base_table_config.FIELD_DB_TYPE] = formView.FIELD_DB_TYPE;
                    drsFields[0][Tables.base_table_config.MAXLENGTH] = formView.MAXLENGTH;
                    drsFields[0][Tables.base_table_config.FOREIGNER_TABLE] = formView.FOREIGNER_TABLE;
                    drsFields[0][Tables.base_table_config.FOREIGNER_FIELD_CN_NAME] = formView.FOREIGNER_FIELD_CN_NAME;
                    drsFields[0][Tables.base_table_config.FOREIGNER_FIELD_DB_NAME] = formView.FOREIGNER_FIELD_DB_NAME;
                    drsFields[0][Tables.base_table_config.FOREIGNER_FILTER_SQL] = formView.FOREIGNER_FILTER_SQL;
                    drsFields[0][Tables.base_table_config.GRID_COL_WIDTH] = formView.GRID_COL_WIDTH;
                    drsFields[0][Tables.base_table_config.HEIGHT] = formView.HEIGHT;
                    drsFields[0][Tables.base_table_config.IS_FOREIGNER_KEY] = formView.IS_FOREIGNER_KEY;
                    drsFields[0][Tables.base_table_config.IS_PRIMARY_KEY] = formView.IS_PRIMARY_KEY;
                    drsFields[0][Tables.base_table_config.LOCATION_X] = formView.LOCATION_X;
                    drsFields[0][Tables.base_table_config.LOCATION_Y] = formView.LOCATION_Y;
                    drsFields[0][Tables.base_table_config.TABINDEX] = formView.TABINDEX;
                    drsFields[0][Tables.base_table_config.TABLE_CN_NAME] = formView.TABLE_CN_NAME;
                    drsFields[0][Tables.base_table_config.TABLE_DB_NAME] = formView.TABLE_DB_NAME;
                    drsFields[0][Tables.base_table_config.UIC_TYPE] = formView.UIC_TYPE;
                    drsFields[0][Tables.base_table_config.WIDTH] = formView.WIDTH;
                    drsFields[0][Tables.base_table_config.FIELD_MARK_TYPE] = formView.FIELD_MARK_TYPE;
                }
            }
        }
        /// <summary>
        /// 返回配置列表
        /// </summary>
        public List<FieldConfig> GetFieldConfigs()
        {
            List<FieldConfig> configs = new List<FieldConfig>();
            for ( int i = 0; i < tbFieldConfig.Rows.Count; i++ )
            {
                FieldConfig config = new FieldConfig();
                config.ALLOW_EDIT = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.ALLOW_EDIT] ) == 1 ? true : false;
                config.ALLOW_EMPTY = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.ALLOW_EMPTY] ) == 1 ? true : false;
                config.AUTO_INCREASE = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.AUTO_INCREASE] ) == 1 ? true : false;
                config.FIELD_CN_NAME = tbFieldConfig.Rows[i][Tables.base_table_config.FIELD_CN_NAME].ToString().Trim();
                config.FIELD_DB_NAME = tbFieldConfig.Rows[i][Tables.base_table_config.FIELD_DB_NAME].ToString().Trim();
                config.FIELD_DB_TYPE = (HIS.Base_BLL.Enums.FIELD_DB_TYPE)Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.FIELD_DB_TYPE] );
                config.FOREIGNER_TABLE = tbFieldConfig.Rows[i][Tables.base_table_config.FOREIGNER_TABLE].ToString().Trim();
                config.FOREIGNER_FIELD_CN_NAME = tbFieldConfig.Rows[i][Tables.base_table_config.FOREIGNER_FIELD_CN_NAME].ToString().Trim();
                config.FOREIGNER_FIELD_DB_NAME = tbFieldConfig.Rows[i][Tables.base_table_config.FOREIGNER_FIELD_DB_NAME].ToString().Trim();
                config.FOREIGNER_FILTER_SQL = tbFieldConfig.Rows[i][Tables.base_table_config.FOREIGNER_FILTER_SQL].ToString().Trim();
                config.GRID_COL_WIDTH = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.GRID_COL_WIDTH] );
                config.HEIGHT = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.HEIGHT] );
                config.IS_FOREIGNER_KEY = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.IS_FOREIGNER_KEY] ) == 1 ? true : false;
                config.IS_PRIMARY_KEY = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.IS_PRIMARY_KEY] ) == 1 ? true : false;
                config.LOCATION_X = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.LOCATION_X] );
                config.LOCATION_Y = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.LOCATION_Y] );
                config.MAXLENGTH = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.MAXLENGTH] );
                config.TABINDEX = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.TABINDEX] );
                config.TABLE_CN_NAME = tbFieldConfig.Rows[i][Tables.base_table_config.TABLE_CN_NAME].ToString().Trim();
                config.TABLE_DB_NAME = tbFieldConfig.Rows[i][Tables.base_table_config.TABLE_DB_NAME].ToString().Trim();
                config.UIC_TYPE = (HIS.Base_BLL.Enums.ControlType)Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.UIC_TYPE] );
                config.WIDTH = Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.WIDTH] );
                config.FIELD_MARK_TYPE = (HIS.Base_BLL.Enums.FIELD_MARK_TYPE)( Convert.ToInt32( tbFieldConfig.Rows[i][Tables.base_table_config.FIELD_MARK_TYPE] ) );

                configs.Add( config );
            }
            return configs;
        }
        /// <summary>
        /// 提交Loacition配置
        /// </summary>
        /// <param name="LocationConfig"></param>
        public void AccecptLoactionSetting(List<FieldConfig> LocationConfigs )
        {
            for ( int i = 0; i < LocationConfigs.Count; i++ )
            {
                string strWhere = Tables.base_table_config.TABLE_DB_NAME + " = '" + LocationConfigs[i].TABLE_DB_NAME + "'" + " And " + Tables.base_table_config.FIELD_DB_NAME + " = '" + LocationConfigs[i].FIELD_DB_NAME + "'";
                DataRow[] drsFields = tbFieldConfig.Select( strWhere );
                if ( drsFields.Length == 0 )
                {
                    throw new Exception( "配置列表中没有找到字段【" + LocationConfigs[i].TABLE_DB_NAME + "." + LocationConfigs[i].FIELD_DB_NAME + "】的配置记录!" );
                }
                else if ( drsFields.Length > 1 )
                {
                    throw new Exception( "配置列表中字段【" + LocationConfigs[i].TABLE_DB_NAME + "." + LocationConfigs[i].FIELD_DB_NAME + "】的配置记录有多条，请检查!" );
                }
                else
                {
                    drsFields[0][Tables.base_table_config.LOCATION_X] = LocationConfigs[i].LOCATION_X;
                    drsFields[0][Tables.base_table_config.LOCATION_Y] = LocationConfigs[i].LOCATION_Y;
                    drsFields[0][Tables.base_table_config.WIDTH] = LocationConfigs[i].WIDTH;
                    drsFields[0][Tables.base_table_config.TABINDEX] = LocationConfigs[i].TABINDEX;
                    drsFields[0][Tables.base_table_config.GRID_COL_WIDTH] = LocationConfigs[i].GRID_COL_WIDTH;
                }
            }
        }
        /// <summary>
        /// 验证数据库字段与实体表字段是否对应
        /// </summary>
        public bool ConfirmFieldExists()
        {
            ////Hashtable entityFields = new Hashtable();
            Hashtable tableFields = new Hashtable();
            Hashtable configFields = new Hashtable();

            string fieldName = "";
            string message = "";
            #region 获取各个部分的字段
            //当前数据库HIS表
            DataTable tb = BaseDataReader.GetBaseTableData( tableInfo.BASE_TABLE_DB_NAME.ToString(), "1>2" );
            for ( int i = 0; i < tb.Columns.Count; i++ )
            {
                fieldName = tb.Columns[i].ColumnName.Trim().ToUpper();
                tableFields.Add( fieldName, fieldName );
            }
            
            //获取配置表中保存的字段
            for ( int i = 0; i < tbFieldConfig.Rows.Count; i++ )
            {
                fieldName = tbFieldConfig.Rows[i][Tables.base_table_config.FIELD_DB_NAME].ToString().Trim().ToUpper();
                configFields.Add(fieldName,fieldName);
            }
            #endregion

            List<string> exceptionfields = new List<string>();
            //异常抛出方式，
            //如果是配置表和数据表异常，抛出CustomException异常
            #region 以数据表为参照，对比配置表字段是否有差异
            foreach ( object obj in tableFields )
            {
                string key = ( (DictionaryEntry)obj ).Key.ToString();
                if ( configFields.Contains( key ) )
                {
                    //有对应的表字段
                    continue;
                }
                else
                {
                    //无对应的表字段
                    exceptionfields.Add( key );//加到异常字段中
                }
            }
            if ( exceptionfields.Count > 0 )
            {
                for ( int i = 0; i < exceptionfields.Count; i++ )
                {
                    message += exceptionfields[i] + ",";
                }
                throw new CustomException( "字段【" + message + "】不存在于配置中，请点击修复将字段添加到配置列表中以便维护" );
            }
            #endregion

            exceptionfields.Clear();
            #region 以配置表为参照，对比数据表字段是否有差异
            foreach ( object obj in configFields )
            {
                string key = ( (DictionaryEntry)obj ).Key.ToString();
                if ( tableFields.Contains( key ) )
                {
                    //有对应的表字段
                    continue;
                }
                else
                {
                    //无对应的表字段
                    exceptionfields.Add( key );//加到异常字段中
                }
            }
            if ( exceptionfields.Count > 0 )
            {
                for ( int i = 0; i < exceptionfields.Count; i++ )
                {
                    message += exceptionfields[i] + ",";
                }
                throw new CustomException( "配置列表中的字段【" + message + "】不存在于现在的数据库环境中，可能已经过期！请点击修复以便同步配置！" );
            }
            #endregion

            return true;
        }
        /// <summary>
        /// 修正配置表字段，使之与数据库、实体同步
        /// </summary>
        /// <returns></returns>
        public bool ReviseConfigFields()
        {
            bool needRevise = false;
            try
            {
                if ( ConfirmFieldExists() )
                {
                    needRevise = false;
                }
            }
            catch ( CustomException ce )
            {
                needRevise = true;
            }
            catch ( Exception err )
            {
                throw err;
            }
            //如果需要修正
            if ( needRevise )
            {
                Hashtable tableFields = new Hashtable();
                Hashtable configFields = new Hashtable();

                string fieldName = "";

                #region 获取各个部分的字段
                //当前数据库HIS表
                DataTable tb = BaseDataReader.GetBaseTableData( tableInfo.BASE_TABLE_DB_NAME.ToString(), "1>2" );
                for ( int i = 0; i < tb.Columns.Count; i++ )
                {
                    fieldName = tb.Columns[i].ColumnName.Trim().ToUpper();
                    tableFields.Add( fieldName, fieldName );
                }

                //获取配置表中保存的字段
                for ( int i = 0; i < tbFieldConfig.Rows.Count; i++ )
                {
                    fieldName = tbFieldConfig.Rows[i][Tables.base_table_config.FIELD_DB_NAME].ToString().Trim().ToUpper();
                    configFields.Add( fieldName, fieldName );
                }
                #endregion

                //以当前表字段为参照。遍历配置，没有则添加,多余则删除

                List<string> fieldNotInConfig = new List<string>(); //在配置中不存在的字段 ,需添加
                List<string> fieldNotInTable = new List<string>(); //配置表中多余的字段，引起多余的原因可能是修改了表结构，取消了一些字段,需删除

                #region 以 数据表为参照，对比配置表字段是否有差异
                foreach ( object obj in tableFields )
                {
                    string key = ( (DictionaryEntry)obj ).Key.ToString();
                    if ( configFields.Contains( key ) )
                        continue;//有对应的表字段
                    else
                        fieldNotInConfig.Add( key );////无对应的表字段,加到需要添加的列表中
                }
                foreach ( object obj in configFields )
                {
                    string key = ( (DictionaryEntry)obj ).Key.ToString();
                    if ( tableFields.Contains( key ) )
                        continue;//有对应的表字段
                    else
                        fieldNotInTable.Add( key );//多余的字段，添加到待删除列表中
                }
                #endregion
                try
                {
                    //加入没有的配置字段
                    foreach ( string FieldName in fieldNotInConfig )
                        TableAndFieldConfig.AddDefaultConfig( tableInfo, FieldName );

                    TableAndFieldConfig.DeleteFieldConfig( tableInfo, fieldNotInTable );
                    return true;
                }
                catch ( Exception err )
                {
                    ( new ErrorController() ).LogEvent( err.Message + "\r\n" + err.Source );
                    throw new Exception( "修正配置表信息发生错误！" );
                }
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 测试SQL是否正确
        /// </summary>
        /// <returns></returns>
        public bool TestSQL()
        {
            try
            {
                BaseDataController.GetDataTable( formView.FOREIGNER_TABLE,
                    new string[] { formView.FOREIGNER_FIELD_DB_NAME, formView.FOREIGNER_FIELD_CN_NAME },
                    formView.FOREIGNER_FILTER_SQL );
                return true;
            }
            catch(Exception err)
            {
                throw err;
            }
        }
    }
}
