using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Base_BLL;
using System.Data;
using HIS.BLL;

namespace HIS_BaseManager.基本数据维护.Controller
{
    public class FrmTableConfigController
    {
        public FrmTableConfigController(IFrmTableConfig FormView)
        {
            formView = FormView;
        }
        private IFrmTableConfig formView;
        private DataTable systemTables;
        private List<TableConfig> vindicateTableList;
        /// <summary>
        /// 当前需要维护的表的列表
        /// </summary>
        public List<TableConfig> VindicateTableList
        {
            get
            {
                return vindicateTableList;
            }
        }
        /// <summary>
        /// IBMSYS.SYSTABLES系统表中的HIS系统的所有表
        /// </summary>
        public DataTable SystemTables
        {
            get
            {
                return systemTables;
            }
        }
        /// <summary>
        /// 从界面获取配置
        /// </summary>
        /// <returns></returns>
        private TableConfig GetEditedTableConfig()
        {
            TableConfig config = new TableConfig();
            config.ALLOW_USER_EDIT = formView.ALLOW_USER_EDIT == 1 ? true : false;
            config.ALLOW_PHYSIC_DELETE = formView.ALLOW_PHYSIC_DELETE == 1 ? true : false;
            config.BASE_TABLE_CN_NAME = formView.TABLE_CN_NAME;
            config.BASE_TABLE_DB_NAME = formView.TABLE_DB_NAME;
            return config;
        }
        /// <summary>
        /// 保存配置
        /// </summary>
        public void SaveTableConfig()
        {
            try
            {
                TableConfig config = GetEditedTableConfig();
                TableAndFieldConfig.AddTableConfig( config );
            }
            catch ( Exception err )
            {
                throw err;
            }

        }
        /// <summary>
        /// 更新配置
        /// </summary>
        public void UpdateTableConfig()
        {
            try
            {
                TableConfig config = GetEditedTableConfig();
                TableAndFieldConfig.UpdateTableConfig( config );
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 删除配置
        /// </summary>
        public void DeleteTableConfig()
        {
            try
            {
                TableConfig config = GetEditedTableConfig();
                TableAndFieldConfig.DeleteTableConfig( config );
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 保存前的验证
        /// </summary>
        /// <returns></returns>
        public bool CheckDataBeforeSave()
        {
            if ( formView.TABLE_CN_NAME.Trim() == "" )
                throw new Exception( "表概念名不能为空！" );

            return true;
        }
        /// <summary>
        /// 初始化控制器
        /// </summary>
        public void Initiazle()
        {
            systemTables = BaseDataController.GetSystemTableList();
            DataTable tbbaseTable = BaseDataReader.GetVindicateTableList();
            vindicateTableList = new List<TableConfig>();
            for ( int i = 0; i < tbbaseTable.Rows.Count; i++ )
            {
                TableConfig tableConfig = new TableConfig();
                tableConfig.BASE_TABLE_CN_NAME = tbbaseTable.Rows[i][Tables.base_vindicate_table.BASE_TABLE_CN_NAME].ToString().Trim();
                tableConfig.BASE_TABLE_DB_NAME = tbbaseTable.Rows[i][Tables.base_vindicate_table.BASE_TABLE_DB_NAME].ToString().Trim();
                tableConfig.ALLOW_USER_EDIT = Convert.ToInt32( tbbaseTable.Rows[i][Tables.base_vindicate_table.ALLOW_USER_EDIT] ) == 1 ? true : false;
                tableConfig.ALLOW_PHYSIC_DELETE = Convert.ToInt32( tbbaseTable.Rows[i][Tables.base_vindicate_table.ALLOW_PHYSIC_DELETE] ) == 1 ? true : false;
                vindicateTableList.Add( tableConfig );
            }
        }
        /// <summary>
        /// 显示表配置信息
        /// </summary>
        public void ShowTableConfig()
        {
            if ( formView.TABLE_DB_NAME.Trim() != "" )
            {
                TableConfig config = vindicateTableList.Find( delegate( TableConfig x )
                {
                    return x.BASE_TABLE_DB_NAME == formView.TABLE_DB_NAME;
                } );
                if ( config != null )
                {
                    formView.TABLE_CN_NAME = config.BASE_TABLE_CN_NAME;
                    formView.ALLOW_USER_EDIT = config.ALLOW_USER_EDIT ? 1 : 0;
                    formView.ALLOW_PHYSIC_DELETE = config.ALLOW_PHYSIC_DELETE ? 1 : 0;
                }
                else
                {
                    formView.TABLE_CN_NAME = "";
                    formView.ALLOW_USER_EDIT = 0;
                    formView.ALLOW_PHYSIC_DELETE = 0;
                }
            }
        }
    }
}
