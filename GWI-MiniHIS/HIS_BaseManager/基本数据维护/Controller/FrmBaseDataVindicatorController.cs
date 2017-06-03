using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.Base_BLL;
using HIS.BLL;
using GWI.HIS.Windows.Controls;
using HIS.Base_BLL.Enums;
using System.Windows.Forms;


namespace HIS_BaseManager.基本数据维护.Controller
{
    /// <summary>
    /// 通用数据维护界面控制
    /// </summary>
    public class FrmBaseDataVindicatorController
    {
        public FrmBaseDataVindicatorController(IFrmBaseDataVindicatorView FormView)
        {
            formView = FormView;
        }

        private IFrmBaseDataVindicatorView formView;
        private DataGridViewEx dataGridViewEx;
        private Panel propertyPanel;
        private DataTable tbFieldConfig;
        private List<TableConfig> baseTableList;
        private List<FieldConfig> baseFieldConfigList;

        /// <summary>
        /// 需要维护的基础表的名称的列表
        /// </summary>
        public List<TableConfig> BastTableList
        {
            get
            {
                return baseTableList;
            }
        }
        /// <summary>
        /// 网格列表
        /// </summary>
        public DataGridViewEx DataGrid
        {
            get
            {
                return dataGridViewEx;
            }
            set
            {
                dataGridViewEx = value;
            }
        }
        /// <summary>
        /// 属性面板
        /// </summary>
        public Panel PropertyPanel
        {
            get
            {
                return propertyPanel;
            }
            set
            {
                propertyPanel = value;
            }
        }

        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            //加载需要维护的基础表的列表
            baseTableList = new List<TableConfig>();
            DataTable tbbaseTable = BaseDataReader.GetVindicateTableList();
            for ( int i = 0; i < tbbaseTable.Rows.Count; i++ )
            {
                TableConfig tableConfig = new TableConfig();
                tableConfig.BASE_TABLE_CN_NAME = tbbaseTable.Rows[i][Tables.base_vindicate_table.BASE_TABLE_CN_NAME].ToString().Trim();
                tableConfig.BASE_TABLE_DB_NAME = tbbaseTable.Rows[i][Tables.base_vindicate_table.BASE_TABLE_DB_NAME].ToString().Trim();
                tableConfig.ALLOW_USER_EDIT = Convert.ToInt32( tbbaseTable.Rows[i][Tables.base_vindicate_table.ALLOW_USER_EDIT] ) == 1 ? true : false;
                baseTableList.Add( tableConfig );
            }

            tbFieldConfig = BaseDataReader.GetVindicateTableFieldList("");

            
        }
        /// <summary>
        /// 初始化控件
        /// </summary>
        public void CreateControls()
        {
            DataRow[] drsConfig = tbFieldConfig.Select( Tables.base_table_config.TABLE_DB_NAME + "='" + formView.SelectedTable.BASE_TABLE_DB_NAME.ToString().Trim() + "'",
                                                        Tables.base_table_config.TABINDEX + " ASC" );
            dataGridViewEx.Columns.Clear();
            propertyPanel.Controls.Clear();
            baseFieldConfigList = new List<FieldConfig>();
            for ( int i = 0; i < drsConfig.Length; i++ )
            {
                FieldConfig config = new FieldConfig();
                #region get config
                config.ALLOW_EDIT = Convert.ToInt32( drsConfig[i][Tables.base_table_config.ALLOW_EDIT] ) == 1 ? true : false;
                config.ALLOW_EMPTY = Convert.ToInt32( drsConfig[i][Tables.base_table_config.ALLOW_EMPTY] ) == 1 ? true : false;
                config.AUTO_INCREASE = Convert.ToInt32( drsConfig[i][Tables.base_table_config.AUTO_INCREASE] ) == 1 ? true : false;
                config.FIELD_CN_NAME = drsConfig[i][Tables.base_table_config.FIELD_CN_NAME].ToString().Trim();
                config.FIELD_DB_NAME = drsConfig[i][Tables.base_table_config.FIELD_DB_NAME].ToString().Trim();
                config.FIELD_DB_TYPE = (HIS.Base_BLL.Enums.FIELD_DB_TYPE)Convert.ToInt32( drsConfig[i][Tables.base_table_config.FIELD_DB_TYPE] );
                config.FOREIGNER_TABLE = drsConfig[i][Tables.base_table_config.FOREIGNER_TABLE].ToString().Trim();
                config.MAXLENGTH = Convert.ToInt32( drsConfig[i][Tables.base_table_config.MAXLENGTH] );
                config.FOREIGNER_FIELD_CN_NAME = drsConfig[i][Tables.base_table_config.FOREIGNER_FIELD_CN_NAME].ToString().Trim();
                config.FOREIGNER_FIELD_DB_NAME = drsConfig[i][Tables.base_table_config.FOREIGNER_FIELD_DB_NAME].ToString().Trim();
                config.FOREIGNER_FILTER_SQL = drsConfig[i][Tables.base_table_config.FOREIGNER_FILTER_SQL].ToString().Trim();
                config.GRID_COL_WIDTH = Convert.ToInt32( drsConfig[i][Tables.base_table_config.GRID_COL_WIDTH] );
                config.HEIGHT = Convert.ToInt32( drsConfig[i][Tables.base_table_config.HEIGHT] );
                config.IS_FOREIGNER_KEY = Convert.ToInt32( drsConfig[i][Tables.base_table_config.IS_FOREIGNER_KEY] ) == 1 ? true : false;
                config.IS_PRIMARY_KEY = Convert.ToInt32( drsConfig[i][Tables.base_table_config.IS_PRIMARY_KEY] ) == 1 ? true : false;
                config.LOCATION_X = Convert.ToInt32( drsConfig[i][Tables.base_table_config.LOCATION_X] );
                config.LOCATION_Y = Convert.ToInt32( drsConfig[i][Tables.base_table_config.LOCATION_Y] );
                config.TABINDEX = Convert.ToInt32( drsConfig[i][Tables.base_table_config.TABINDEX] );
                config.TABLE_CN_NAME = drsConfig[i][Tables.base_table_config.TABLE_CN_NAME].ToString().Trim();
                config.TABLE_DB_NAME = drsConfig[i][Tables.base_table_config.TABLE_DB_NAME].ToString().Trim();
                config.UIC_TYPE = (HIS.Base_BLL.Enums.ControlType)Convert.ToInt32( drsConfig[i][Tables.base_table_config.UIC_TYPE] );
                config.WIDTH = Convert.ToInt32( drsConfig[i][Tables.base_table_config.WIDTH] );
                config.FIELD_MARK_TYPE = (HIS.Base_BLL.Enums.FIELD_MARK_TYPE)( Convert.ToInt32( drsConfig[i][Tables.base_table_config.FIELD_MARK_TYPE] ) );
                baseFieldConfigList.Add( config );
                #endregion
                DataGridViewColumn grdCol;
                Control ctrl = new Control();

                #region 设置控件和列样式
                if ( config.UIC_TYPE == ControlType.CheckBox )
                {
                    grdCol = new DataGridViewCheckBoxColumn();
                    ctrl = new CheckBox();
                    ( (CheckBox)ctrl ).Text = config.FIELD_CN_NAME;
                    ( (CheckBox)ctrl ).AutoSize = true;
                    if ( config.GRID_COL_WIDTH == 0 )
                        ( (DataGridViewCheckBoxColumn)grdCol ).Visible = false;
                    else
                        ( (DataGridViewCheckBoxColumn)grdCol ).Visible = true;
                    ( (DataGridViewCheckBoxColumn)grdCol ).Width = config.GRID_COL_WIDTH;
                    
                }
                else if ( config.UIC_TYPE == ControlType.ComboBox )
                {
                    grdCol = new DataGridViewComboBoxColumn();
                    if ( config.GRID_COL_WIDTH == 0 )
                        ( (DataGridViewComboBoxColumn)grdCol ).Visible = false;
                    else
                        ( (DataGridViewComboBoxColumn)grdCol ).Visible = true;
                    ( (DataGridViewComboBoxColumn)grdCol ).Width = config.GRID_COL_WIDTH;

                    ctrl = new ComboBox();
                    if ( config.IS_FOREIGNER_KEY )
                    {
                        //如果是外键，设置外键的数据来源和显示字段，值字段
                        DataTable tb = BaseDataReader.GetBaseTableData( config.FOREIGNER_TABLE, new string[] { "rtrim(cast("+config.FOREIGNER_FIELD_DB_NAME + " as char(30))) as " + config.FOREIGNER_FIELD_DB_NAME, config.FOREIGNER_FIELD_CN_NAME }, config.FOREIGNER_FILTER_SQL );
                        ( (DataGridViewComboBoxColumn)grdCol ).DataSource = tb;
                        ( (DataGridViewComboBoxColumn)grdCol ).DisplayMember = config.FOREIGNER_FIELD_CN_NAME;
                        ( (DataGridViewComboBoxColumn)grdCol ).ValueMember = config.FOREIGNER_FIELD_DB_NAME;
                        ( (DataGridViewComboBoxColumn)grdCol ).DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

                        ( (ComboBox)ctrl ).DataSource = tb;
                        ( (ComboBox)ctrl ).DisplayMember = config.FOREIGNER_FIELD_CN_NAME;
                        ( (ComboBox)ctrl ).ValueMember = config.FOREIGNER_FIELD_DB_NAME;
                        ( (ComboBox)ctrl ).DropDownStyle = ComboBoxStyle.DropDown;
                        ( (ComboBox)ctrl ).MaxDropDownItems = 25;
                    }
                }
                else
                {
                    grdCol = new DataGridViewTextBoxColumn();
                    if ( config.GRID_COL_WIDTH == 0 )
                        ( (DataGridViewTextBoxColumn)grdCol ).Visible = false;
                    else
                        ( (DataGridViewTextBoxColumn)grdCol ).Visible = true;
                    ( (DataGridViewTextBoxColumn)grdCol ).Width = config.GRID_COL_WIDTH;

                    ctrl = new TextBox();
                    ( (TextBox)ctrl ).MaxLength = config.MAXLENGTH;
                }
                #endregion

                #region 创建控件和列
                //定义标签
                Label lbl = new Label();
                lbl.Text = config.FIELD_CN_NAME;
                lbl.AutoSize = true;
                int lblWidth = 0;
                int lblHeight = 0;
                using ( System.Drawing.Graphics g = propertyPanel.CreateGraphics() )
                {
                    System.Drawing.SizeF size = g.MeasureString( lbl.Text, propertyPanel.Font );
                    lblWidth = Convert.ToInt32( size.Width );
                    lblHeight = Convert.ToInt32( size.Height );
                }

                //定义控件
                ctrl.Name = config.UIC_TYPE.ToString() + "_" + config.FIELD_DB_NAME;
                ctrl.Size = new System.Drawing.Size( config.WIDTH, config.HEIGHT );
                ctrl.Location = new System.Drawing.Point( config.LOCATION_X, config.LOCATION_Y );
                if ( !config.ALLOW_EDIT )
                    ctrl.Enabled = false;
                ctrl.TabIndex = config.TABINDEX;
                ctrl.KeyPress += new KeyPressEventHandler( ctrl_KeyPress );
                ctrl.Tag = config;

                if ( config.UIC_TYPE != ControlType.CheckBox )
                {
                    lbl.Left = ctrl.Left - lblWidth - 4;
                    lbl.Top = ctrl.Top + ( ctrl.Height - lblHeight );
                    if ( !config.ALLOW_EMPTY )
                        lbl.ForeColor = System.Drawing.Color.Red;
                    propertyPanel.Controls.Add( lbl );
                }
                
                
                propertyPanel.Controls.Add( ctrl );

                grdCol.Name = "COLUMN_"+config.FIELD_DB_NAME;
                grdCol.HeaderText = config.FIELD_CN_NAME;
                grdCol.DataPropertyName = config.FIELD_DB_NAME;
                
                dataGridViewEx.Columns.Add( grdCol );

                #endregion
            }

        }
        /// <summary>
        /// 控件回车键事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ctrl_KeyPress( object sender, KeyPressEventArgs e )
        {
            FieldConfig config = (FieldConfig)( (Control)sender ).Tag;
            
            if ( (int)e.KeyChar == 13 )
            {
                if ( config.FIELD_MARK_TYPE == FIELD_MARK_TYPE.名称 )
                {
                    CreateSpellCode(  ((Control)sender).Text );
                }

                FindNextControl( (Control)sender );
            }
        }
        /// <summary>
        /// 生成拼音五笔字段
        /// </summary>
        private void CreateSpellCode(string text)
        {
            string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( text );
            foreach ( Control ctrl in this.propertyPanel.Controls )
            {
                if ( ctrl.Tag == null )
                    continue;
       
                if ( ( (FieldConfig)ctrl.Tag ).FIELD_MARK_TYPE == FIELD_MARK_TYPE.拼音码 )
                {
                    if ( ( (FieldConfig)ctrl.Tag ).UIC_TYPE == ControlType.TextBox )
                    {
                        ( (TextBox)ctrl ).Text = pywb[0];
                    }
                }
                if ( ( (FieldConfig)ctrl.Tag ).FIELD_MARK_TYPE == FIELD_MARK_TYPE.五笔码 )
                {
                    if ( ( (FieldConfig)ctrl.Tag ).UIC_TYPE == ControlType.TextBox )
                    {
                        ( (TextBox)ctrl ).Text = pywb[1];
                    }
                }
                
            }
        }
        /// <summary>
        /// 按TableIndex查找下一个控件
        /// </summary>
        /// <param name="CurrentControl">当前的控件TabIndex</param>
        private void FindNextControl( Control CurrentControl )
        {
            string strWhere = Tables.base_table_config.TABLE_DB_NAME + "='" + formView.SelectedTable.BASE_TABLE_DB_NAME.ToString().Trim() + "' and " + 
                                Tables.base_table_config.TABINDEX + " > " + CurrentControl.TabIndex + " and " + Tables.base_table_config.ALLOW_EDIT + "=1";
            DataRow[] drsConfig = tbFieldConfig.Select( strWhere, Tables.base_table_config.TABINDEX + " ASC" );
            int nextTabIndex = 0;
            string nextCtrlName = "";
            if ( drsConfig.Length > 0 )
            {
                //返回下一个控件
                nextTabIndex = Convert.ToInt32( drsConfig[0][Tables.base_table_config.TABINDEX] );
                HIS.Base_BLL.Enums.ControlType ct = (HIS.Base_BLL.Enums.ControlType)( Convert.ToInt32( drsConfig[0][Tables.base_table_config.UIC_TYPE] ) );
                nextCtrlName = ct.ToString() + "_" + drsConfig[0][Tables.base_table_config.FIELD_DB_NAME].ToString().Trim();
            }
            else
                return;
            foreach ( Control ctrl in this.propertyPanel.Controls )
            {
                if ( ctrl.TabIndex == nextTabIndex && ctrl.Name == nextCtrlName )
                {
                    ctrl.Focus();
                    return;
                }
            }
        }
        /// <summary>
        /// 在网格内显示表数据
        /// </summary>
        public void ShowDataInGrid()
        {
            DataRow[] drsConfig = tbFieldConfig.Select( Tables.base_table_config.TABLE_DB_NAME + "='" + formView.SelectedTable.BASE_TABLE_DB_NAME.ToString().Trim() + "'",
                                                         Tables.base_table_config.TABINDEX + " ASC" );
            string[] fields = new string[drsConfig.Length];
            for( int i=0;i<drsConfig.Length;i++)
                fields[i] = "rtrim(cast(" + drsConfig[i][Tables.base_table_config.FIELD_DB_NAME].ToString( ) + " as char(30))) as " + drsConfig[i][Tables.base_table_config.FIELD_DB_NAME].ToString( );
            if ( fields.Length == 0 )
            {
                fields = null;
            }

            DataTable tbData = BaseDataReader.GetBaseTableData( formView.SelectedTable.BASE_TABLE_DB_NAME.Trim().ToString() ,fields,"");

            dataGridViewEx.DataSource = tbData.DefaultView;
        }
        /// <summary>
        /// 查找数据
        /// </summary>
        public void FilterGridData()
        {
            string keyWord = CommonFun.FormatKeyword( formView.FilterKeyWord );
            string filterString = "";
            
            bool setFilterField = false;

            foreach ( Control ctrl in this.propertyPanel.Controls )
            {
                if ( ctrl.Tag == null )
                    continue;
                FieldConfig config = (FieldConfig)ctrl.Tag;
                if ( config.FIELD_MARK_TYPE == FIELD_MARK_TYPE.拼音码
                    || config.FIELD_MARK_TYPE == FIELD_MARK_TYPE.五笔码
                    || config.FIELD_MARK_TYPE == FIELD_MARK_TYPE.名称 )
                {
                    filterString = " " + filterString + config.FIELD_DB_NAME + " LIKE '%" + keyWord + "%' OR ";
                    setFilterField = true;
                }
                
            }
            if ( setFilterField == false )
                throw new Exception("没有正确配置名称、拼音码、五笔码字段！");
            filterString = filterString.Trim().Remove( filterString.Trim().Length - 2, 2 );

            ( (DataView)( dataGridViewEx.DataSource ) ).RowFilter = filterString;
        }
        /// <summary>
        /// 显示记录数据的详细信息
        /// </summary>
        public void ShowRecordContent()
        {
            if ( dataGridViewEx.Rows.Count == 0 )
                return;
            if ( dataGridViewEx.CurrentCell == null )
                return;

            foreach ( Control ctrl in this.propertyPanel.Controls )
            {
                if ( ctrl is Label )
                    continue;
                FieldConfig config = (FieldConfig)ctrl.Tag;
                string columnName = "COLUMN_" + config.FIELD_DB_NAME;
                if ( dataGridViewEx.Columns.Contains( columnName ) )
                {
                    object data = dataGridViewEx[columnName, dataGridViewEx.CurrentCell.RowIndex].Value;
                    if ( data == null )
                        continue;
                    if ( config.UIC_TYPE == ControlType.CheckBox )
                    {
                        ( (CheckBox)ctrl ).Checked = Convert.ToInt32( data ) == 1 ? true : false;
                    }
                    if ( config.UIC_TYPE == ControlType.TextBox )
                    {
                        ( (TextBox)ctrl ).Text = ( Convert.IsDBNull( data ) ? "" : data.ToString() );
                    }
                    if ( config.UIC_TYPE == ControlType.ComboBox )
                    {
                        if ( !Convert.IsDBNull( data ) )
                        {
                            ( (ComboBox)ctrl ).SelectedValue = data;
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 置为新增记录状态
        /// </summary>
        public void SetAddNewStatus()
        {
            Control startCtrl = null;
            int minTabIndex = -1;
            bool firstFlag = true ;
            foreach ( Control ctrl in this.propertyPanel.Controls )
            {
                if ( ctrl is Label )
                    continue;
                                
                FieldConfig config = (FieldConfig)ctrl.Tag;
                
                if ( ctrl is CheckBox )
                {
                    ( (CheckBox)ctrl ).Checked = false;
                }

                else if ( ctrl is TextBox )
                {
                    if ( config.IS_PRIMARY_KEY && config.AUTO_INCREASE )
                    {
                        ctrl.Enabled = false;
                    }
                    else
                        ctrl.Enabled = true;
                    ( (TextBox)ctrl ).Text = "";
                }
                else
                {
                }
                if ( firstFlag )
                {
                    if ( ctrl.Enabled )
                    {
                        minTabIndex = config.TABINDEX;
                        startCtrl = ctrl;
                        firstFlag = false;
                    }
                }
                else
                {
                    if ( ctrl.Enabled && minTabIndex > config.TABINDEX )
                    {
                        minTabIndex = config.TABINDEX;
                        startCtrl = ctrl;
                    }
                }
                

            }
            if (startCtrl != null )
                startCtrl.Focus();
        }
        /// <summary>
        /// 新增记录
        /// </summary>
        public void AddNewBaseDataRecord()
        {
            BaseDataRecord objRecord = CreateRecordInstance();
            if ( objRecord != null )
            {
                string tableName = formView.SelectedTable.BASE_TABLE_DB_NAME.ToString().Trim();
                BaseDataController.AddNewBaseDataRecord( objRecord,tableName );
            }
        }
        /// <summary>
        /// 更新记录
        /// </summary>
        public void UpdateBaseDataRecord()
        {
            BaseDataRecord objRecord = CreateRecordInstance();
            if ( objRecord != null )
            {
                string tableName = formView.SelectedTable.BASE_TABLE_DB_NAME.ToString().Trim();
                BaseDataController.UpdateBaseDataRecord( objRecord, tableName );
            }

        }
        /// <summary>
        /// 删除一条记录
        /// </summary>
        public void DeleteBaseDataRecord()
        {
            BaseDataRecord objRecord = CreateRecordInstance();
            if (objRecord != null)
            {
                string tableName = formView.SelectedTable.BASE_TABLE_DB_NAME.ToString().Trim();
                BaseDataController.DeleteBaseDataRecord(objRecord, formView.SelectedTable);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private BaseDataRecord CreateRecordInstance()
        {
            if (formView.SelectedTable == null)
            {
                throw new Exception("没有选择数据表");
            }
            string TableName = formView.SelectedTable.BASE_TABLE_DB_NAME.ToString().Trim();
            
            DataTable tb = BaseDataReader.GetBaseTableData( TableName, "1 > 2" );
            
            BaseDataRecord dataRecord = new BaseDataRecord();//定义一条新记录

            foreach ( Control ctrl in this.propertyPanel.Controls )
            {
                if ( ctrl is Label )
                    continue;
                if ( ctrl.Tag == null )
                    continue;
                FieldConfig config = (FieldConfig)ctrl.Tag;
                
                for ( int i = 0; i < tb.Columns.Count ; i++ )
                {
                    string fieldName = tb.Columns[i].ColumnName;
                    if ( fieldName.ToUpper() == config.FIELD_DB_NAME.ToUpper() )
                    {
                        object objValue = null;
                        if ( config.UIC_TYPE == ControlType.CheckBox )
                        {
                            objValue = ( (CheckBox)ctrl ).Checked ? 1 : 0;
                        }
                        if ( config.UIC_TYPE == ControlType.ComboBox )
                        {
                            objValue = ( (ComboBox)ctrl ).SelectedValue;
                        }
                        if ( config.UIC_TYPE == ControlType.TextBox )
                        {
                            objValue = ( (TextBox)ctrl ).Text;
                        }
                        //如果是自增长的主键，跳过
                        if ( config.IS_PRIMARY_KEY && config.AUTO_INCREASE && objValue.ToString().Trim() == "" )
                            continue;
                        if ( (config.IS_PRIMARY_KEY  || !config.ALLOW_EMPTY  ))
                        {
                            if ( objValue == null || objValue.ToString() == "" )
                            {
                                throw new Exception( config.FIELD_CN_NAME + "不能为空！" );
                            }
                        }
                        
                        objValue = Convert.ChangeType( objValue, tb.Columns[i].DataType );
                        

                        BaseDataRecordField field_value = new BaseDataRecordField();
                        field_value.FieldConfig = config;
                        field_value.DataValue = objValue;
                        dataRecord.RecordFields.Add( field_value );
                    }
                }
            }
            return dataRecord;
        }
    }
}
