using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.SYSTEM.PubicBaseClasses;
using HIS_BaseManager.基本数据维护.Controller;
using HIS.Base_BLL.Enums;
using HIS.Base_BLL;

namespace HIS_BaseManager.基本数据维护
{
    public partial class FrmVindicatorConfig : BaseForm, IFrmVindicatorConfig
    {
        #region IFrmVindicatorConfig 成员

        public string TABLE_DB_NAME
        {
            get
            {
                return tableInfo.BASE_TABLE_DB_NAME.ToString().Trim();
            }
            set
            {
                tableInfo.BASE_TABLE_DB_NAME = value;
            }
        }

        public string TABLE_CN_NAME
        {
            get
            {
                return tableInfo.BASE_TABLE_CN_NAME.Trim();
            }
            set
            {
                tableInfo.BASE_TABLE_CN_NAME = value.Trim();
            }
        }

        public string FIELD_DB_NAME
        {
            get
            {
                return txtField_DB_Name.Text.Trim();
            }
            set
            {
                txtField_DB_Name.Text = value.Trim();
            }
        }

        public string FIELD_CN_NAME
        {
            get
            {
                return txtField_CN_Name.Text;
            }
            set
            {
                txtField_CN_Name.Text = value.Trim();
            }
        }

        public int FIELD_DB_TYPE
        {
            get
            {
                HIS.Base_BLL.Enums.FIELD_DB_TYPE dbType = HIS.Base_BLL.Enums.FIELD_DB_TYPE.字符;
                foreach ( object obj in Enum.GetValues( typeof( HIS.Base_BLL.Enums.FIELD_DB_TYPE ) ) )
                {
                    if ( obj.ToString() == cboFieldType.Text )
                    {
                        dbType =  (HIS.Base_BLL.Enums.FIELD_DB_TYPE)obj ;
                        break;
                    }
                }
                return (int)dbType;
            }
            set
            {
                cboFieldType.Text = ( (HIS.Base_BLL.Enums.FIELD_DB_TYPE)value ).ToString();
            }
        }

        public int IS_PRIMARY_KEY
        {
            get
            {
                return chkPrimaryKey.Checked ? 1 : 0;
            }
            set
            {
                chkPrimaryKey.Checked = ( value == 1 ? true : false );
            }
        }

        public int AUTO_INCREASE
        {
            get
            {
                return chkAutoIncrease.Checked ? 1 : 0;
            }
            set
            {
                chkAutoIncrease.Checked = ( value == 1 ? true : false );
            }
        }

        public int ALLOW_EMPTY
        {
            get
            {
                return chkAllowEmpty.Checked ? 1 : 0;
            }
            set
            {
                chkAllowEmpty.Checked = ( value == 1 ? true : false );
            }
        }

        public int MAXLENGTH
        {
            get
            {
                if ( txtMaxLength.Text.Trim() == "" )
                    return 1;
                else
                    return Convert.ToInt32(txtMaxLength.Text);
            }
            set
            {
                txtMaxLength.Text = value.ToString();
            }
        }

        public int IS_FOREIGNER_KEY
        {
            get
            {
                return chkForignerKey.Checked ? 1 : 0;
            }
            set
            {
                chkForignerKey.Checked = ( value == 1 ? true : false );
            }
        }

        public string FOREIGNER_TABLE
        {
            get
            {
                if ( chkForignerKey.Checked )
                    return cboForignerTable.Text;
                else
                    return "";
            }
            set
            {
                cboForignerTable.Text = value;
            }
        }

        public string FOREIGNER_FIELD_DB_NAME
        {
            get
            {
                if ( chkForignerKey.Checked )
                    return cboForignerID_Field.Text;
                else
                    return "";
            }
            set
            {
                cboForignerID_Field.Text = value;
            }
        }

        public string FOREIGNER_FIELD_CN_NAME
        {
            get
            {
                if ( chkForignerKey.Checked )
                    return cboForignerName_Field.Text;
                else
                    return "";
            }
            set
            {
                cboForignerName_Field.Text = value;
            }
        }

        public string FOREIGNER_FILTER_SQL
        {
            get
            {
                if ( chkForignerKey.Checked )
                    return txtFilterSql.Text.Trim();
                else
                    return "";
            }
            set
            {
                txtFilterSql.Text = value.Trim();
            }
        }

        public int UIC_TYPE
        {
            get
            {
                ControlType ct = ControlType.TextBox;
                foreach ( object obj in Enum.GetValues( typeof( ControlType ) ) )
                {
                    if ( obj.ToString() == cboUC.Text )
                    {
                        ct = (ControlType)obj;
                        break;
                    }
                }
                return (int)ct;
            }
            set
            {
                cboUC.Text = ( (ControlType)value ).ToString();
            }
        }

        public int LOCATION_X
        {
            get
            {
                if ( txtLocationX.Text.Trim() == "" )
                    return 0;
                else
                    return Convert.ToInt32( txtLocationX.Text );
            }
            set
            {
                txtLocationX.Text = value.ToString();
            }
        }

        public int LOCATION_Y
        {
            get
            {
                if ( txtLocationY.Text.Trim() == "" )
                    return 0;
                else
                    return Convert.ToInt32( txtLocationY.Text );
            }
            set
            {
                txtLocationY.Text = value.ToString();
            }
        }

        public int WIDTH
        {
            get
            {
                if ( txtWidth.Text.Trim() == "" )
                    return 0;
                else
                    return Convert.ToInt32( txtWidth.Text );
            }
            set
            {
                txtWidth.Text = value.ToString();
            }
        }

        public int HEIGHT
        {
            get
            {
                if ( txtHeight.Text.Trim() == "" )
                    return 0;
                else
                    return Convert.ToInt32( txtHeight.Text );
            }
            set
            {
                txtHeight.Text = value.ToString();
            }
        }

        public int GRID_COL_WIDTH
        {
            get
            {
                if ( txtColWidth.Text.Trim() == "" )
                    return 0;
                else
                    return Convert.ToInt32( txtColWidth.Text );
            }
            set
            {
                txtColWidth.Text = value.ToString();
            }
        }

        public int TABINDEX
        {
            get
            {
                if ( txtTabIndex.Text.Trim() == "" )
                    return 0;
                else
                    return Convert.ToInt32(txtTabIndex.Text);
            }
            set
            {
                txtTabIndex.Text = value.ToString();
            }
        }

        public int ALLOW_EDIT
        {
            get
            {
                return chkAllowEdit.Checked ? 1 : 0;
            }
            set
            {
                chkAllowEdit.Checked = ( value == 1 ? true : false );
            }
        }

        public int FIELD_MARK_TYPE
        {
            get
            {
                HIS.Base_BLL.Enums.FIELD_MARK_TYPE t = HIS.Base_BLL.Enums.FIELD_MARK_TYPE.无;
                foreach ( object obj in Enum.GetValues( typeof( HIS.Base_BLL.Enums.FIELD_MARK_TYPE ) ) )
                {
                    if ( obj.ToString() == cboMarkType.Text )
                    {
                        t = (HIS.Base_BLL.Enums.FIELD_MARK_TYPE)obj;
                        break;
                    }
                }
                return (int)t;
            }
            set
            {
                cboMarkType.Text = ( (HIS.Base_BLL.Enums.FIELD_MARK_TYPE)value ).ToString();
            }
        }
        public string SelectedField
        {
            get
            {
                if ( tvwField.SelectedNode == null )
                    return "";

                if ( tvwField.SelectedNode.Tag == null )
                    return "";
                else
                    return tvwField.SelectedNode.Tag.ToString().Trim();
            }
        }
        #endregion

        /// <summary>
        /// 创建字段的树形
        /// </summary>
        private void CreateFieldTree()
        {

            tvwField.Nodes.Clear();
            TreeNode topNode = new TreeNode();
            topNode.Text = tableInfo.BASE_TABLE_DB_NAME.ToString() + "(" + tableInfo.BASE_TABLE_CN_NAME + ")";
            topNode.ImageIndex = 0;
            for ( int i = 0; i < controller.TableFields.Count; i++ )
            {
                TreeNode fdNode = new TreeNode();
                fdNode.Text = controller.TableFields[i].Value.ToString() + "(" + controller.TableFields[i].Text + ")";
                fdNode.Tag = controller.TableFields[i].Value.ToString();
                fdNode.ImageIndex = 1;
                topNode.Nodes.Add( fdNode );
            }
            tvwField.Nodes.Add( topNode );
            tvwField.ExpandAll();
        }
        /// <summary>
        /// 重置输入内容
        /// </summary>
        private void ResetInputContent()
        {
            txtColWidth.Text = "75";
            txtField_CN_Name.Text = "";
            txtField_DB_Name.Text = "";
            txtFilterSql.Text = "";
            txtHeight.Text = "30";
            txtLocationX.Text = "0";
            txtLocationY.Text = "0";
            txtTabIndex.Text = "0";
            txtWidth.Text = "75";
            txtMaxLength.Text = "2";
            chkAllowEdit.Checked = false;
            chkAllowEmpty.Checked = false;
            chkAutoIncrease.Checked = false;
            chkForignerKey.Checked = false;
            grpForignerInfo.Enabled = false;
            chkPrimaryKey.Checked = false;
            cboFieldType.SelectedIndex = 0;
            cboForignerID_Field.SelectedIndex = -1;
            cboForignerName_Field.SelectedIndex = -1;
            cboForignerTable.SelectedIndex = 0;
            cboUC.SelectedIndex = 0;
        }
        /// <summary>
        /// 控件绑定事件
        /// </summary>
        private void BindControlEvents()
        {
            tvwField.AfterSelect += new TreeViewEventHandler( tvwField_AfterSelect );

            txtField_CN_Name.TextChanged += new EventHandler( TextBox_TextChanges );
            txtFilterSql.TextChanged += new EventHandler( TextBox_TextChanges );
            txtHeight.TextChanged += new EventHandler( TextBox_TextChanges );
            txtWidth.TextChanged += new EventHandler( TextBox_TextChanges );
            txtLocationX.TextChanged += new EventHandler( TextBox_TextChanges );
            txtLocationY.TextChanged += new EventHandler( TextBox_TextChanges );
            txtTabIndex.TextChanged += new EventHandler( TextBox_TextChanges );
            txtColWidth.TextChanged += new EventHandler( TextBox_TextChanges );
            txtMaxLength.TextChanged += new EventHandler( TextBox_TextChanges );

            cboForignerTable.SelectedIndexChanged += new EventHandler( CombBox_SelectedIndexChanged );
            cboFieldType.SelectedIndexChanged += new EventHandler( CombBox_SelectedIndexChanged );
            cboForignerID_Field.SelectedIndexChanged += new EventHandler( CombBox_SelectedIndexChanged );
            cboForignerName_Field.SelectedIndexChanged += new EventHandler( CombBox_SelectedIndexChanged );
            cboUC.SelectedIndexChanged += new EventHandler( CombBox_SelectedIndexChanged );
            cboMarkType.SelectedIndexChanged += new EventHandler( CombBox_SelectedIndexChanged );

            chkAllowEdit.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chkAllowEmpty.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chkAutoIncrease.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chkForignerKey.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chkPrimaryKey.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
        }
        /// <summary>
        /// 取消控件绑定事件
        /// </summary>
        private void RemoveControlEvents()
        {
            tvwField.AfterSelect -= new TreeViewEventHandler( tvwField_AfterSelect );

            txtField_CN_Name.TextChanged -= new EventHandler( TextBox_TextChanges );
            txtFilterSql.TextChanged -= new EventHandler( TextBox_TextChanges );
            txtHeight.TextChanged -= new EventHandler( TextBox_TextChanges );
            txtWidth.TextChanged -= new EventHandler( TextBox_TextChanges );
            txtLocationX.TextChanged -= new EventHandler( TextBox_TextChanges );
            txtLocationY.TextChanged -= new EventHandler( TextBox_TextChanges );
            txtTabIndex.TextChanged -= new EventHandler( TextBox_TextChanges );
            txtColWidth.TextChanged -= new EventHandler( TextBox_TextChanges );
            txtMaxLength.TextChanged -= new EventHandler( TextBox_TextChanges );

            cboForignerTable.SelectedIndexChanged -= new EventHandler( CombBox_SelectedIndexChanged );
            cboFieldType.SelectedIndexChanged -= new EventHandler( CombBox_SelectedIndexChanged );
            cboForignerID_Field.SelectedIndexChanged -= new EventHandler( CombBox_SelectedIndexChanged );
            cboForignerName_Field.SelectedIndexChanged -= new EventHandler( CombBox_SelectedIndexChanged );
            cboUC.SelectedIndexChanged -= new EventHandler( CombBox_SelectedIndexChanged );
            cboMarkType.SelectedIndexChanged -= new EventHandler( CombBox_SelectedIndexChanged );

            chkAllowEdit.CheckedChanged -= new EventHandler( CheckBox_CheckedChanged );
            chkAllowEmpty.CheckedChanged -= new EventHandler( CheckBox_CheckedChanged );
            chkAutoIncrease.CheckedChanged -= new EventHandler( CheckBox_CheckedChanged );
            chkForignerKey.CheckedChanged -= new EventHandler( CheckBox_CheckedChanged );
            chkPrimaryKey.CheckedChanged -= new EventHandler( CheckBox_CheckedChanged );
        }
        /// <summary>
        /// 刷新信息
        /// </summary>
        private void RefrshFieldInfo()
        {
            RemoveControlEvents();

            controller.Initalize();

            CreateFieldTree();

            ResetInputContent();

            BindControlEvents();
        }

        private FrmVindicatorConfigController controller;

        public FrmVindicatorConfig(TableConfig TableInfo)
        {
            InitializeComponent();

            tableInfo = TableInfo;
        }

        private TableConfig tableInfo;

        
        private void FrmVindicatorConfig_Load( object sender, EventArgs e )
        {

            foreach ( object obj in Enum.GetValues( typeof( HIS.Base_BLL.Enums.FIELD_DB_TYPE ) ) )
                cboFieldType.Items.Add( obj.ToString() );
            cboFieldType.SelectedIndex = 0;

            foreach ( object obj in Enum.GetValues( typeof( HIS.Base_BLL.Enums.ControlType ) ) )
                cboUC.Items.Add( obj.ToString() );
            cboUC.SelectedIndex = 0;

            foreach ( object obj in Enum.GetValues( typeof( HIS.Base_BLL.Enums.FIELD_MARK_TYPE ) ) )
                cboMarkType.Items.Add( obj.ToString() );
            cboMarkType.Text = HIS.Base_BLL.Enums.FIELD_MARK_TYPE.无.ToString();

            controller = new FrmVindicatorConfigController( this );
            controller.TableInfo = tableInfo;
            controller.Initalize();
            
            CreateFieldTree();

            cboForignerTable.DisplayMember = "NAME";
            cboForignerTable.ValueMember = "NAME";
            cboForignerTable.DataSource = controller.SystemTable;


            BindControlEvents();

            SelectedDefaultNode();
            
        }

        private void SelectedDefaultNode()
        {
            if ( tvwField.SelectedNode == null )
            {
                if ( tvwField.Nodes.Count > 0 )
                {
                    if ( tvwField.Nodes[0].Nodes.Count > 0 )
                    {
                        tvwField.SelectedNode = tvwField.Nodes[0].Nodes[0];
                    }
                }

            }
        }
       

        void tvwField_AfterSelect( object sender, TreeViewEventArgs e )
        {
            if ( e.Node.Tag == null )
            {
                if ( e.Node.Parent == null )
                {
                    if ( e.Node.Nodes.Count > 0 )
                    {
                        tvwField.SelectedNode = e.Node.Nodes[0];
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }

            controller.ShowFieldConfig();
                
        }
        
        private void btnClose_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            RefrshFieldInfo();
            SelectedDefaultNode();
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            try
            {
                if ( controller.CheckUpDataBeforeUpdate() )
                {
                    try
                    {
                        controller.UpdateConfig();

                        MessageBox.Show( "设置已保存！", "", MessageBoxButtons.OK, MessageBoxIcon.Information );

                        RefrshFieldInfo();
                        SelectedDefaultNode();
                    }
                    catch ( Exception err )
                    {
                        MessageBox.Show( err.Message + "！\r\n  保存设置发生错误！", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    }
                }
            }
            catch(Exception checkErr)
            {
                MessageBox.Show( "数据验证错误！\r\n" + checkErr.Message,"",MessageBoxButtons.OK,MessageBoxIcon.Error );
            }
        }

        private void TextBox_TextChanges( object sender, EventArgs e )
        {
            controller.ConfigValueChanged();
        }

        private void CombBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            ComboBox cbo = (ComboBox)sender;

            if ( cbo.Name == cboForignerTable.Name )
            {
                #region ..........
                List<string> lstField = controller.GetSystemFieldList( cboForignerTable.Text );

                cboForignerID_Field.Items.Clear();
                cboForignerName_Field.Items.Clear();
                for ( int i = 0; i < lstField.Count; i++ )
                {
                    cboForignerID_Field.Items.Add( lstField[i] );
                    cboForignerName_Field.Items.Add( lstField[i] );
                }
                if ( cboForignerID_Field.Items.Count > 0 )
                    cboForignerID_Field.SelectedIndex = 0;
                if ( cboForignerName_Field.Items.Count > 0 )
                    cboForignerName_Field.SelectedIndex = 0;
                #endregion
            }

            if ( cbo.Name == cboFieldType.Name )
            {
                #region ..........
                if ( cboFieldType.SelectedIndex == -1 )
                    return;

                HIS.Base_BLL.Enums.FIELD_DB_TYPE dbType = HIS.Base_BLL.Enums.FIELD_DB_TYPE.字符;

                foreach ( object obj in Enum.GetValues( typeof( HIS.Base_BLL.Enums.FIELD_DB_TYPE ) ) )
                {
                    if ( obj.ToString() == cboFieldType.Text )
                    {
                        dbType = (HIS.Base_BLL.Enums.FIELD_DB_TYPE)obj;
                        break;
                    }
                }

                switch ( dbType )
                {
                    case HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字:
                        txtMaxLength.Enabled = false;
                        break;
                    case HIS.Base_BLL.Enums.FIELD_DB_TYPE.字符:
                        chkAutoIncrease.Checked = false;
                        txtMaxLength.Enabled = true;
                        if ( cboUC.Text == HIS.Base_BLL.Enums.ControlType.CheckBox.ToString() )
                            cboUC.Text = HIS.Base_BLL.Enums.ControlType.TextBox.ToString();
                        break;
                    case HIS.Base_BLL.Enums.FIELD_DB_TYPE.日期:
                        chkAutoIncrease.Checked = false;
                        txtMaxLength.Enabled = false;
                        break;
                    default:
                        chkAutoIncrease.Checked = false;
                        chkPrimaryKey.Checked = false;
                        chkForignerKey.Checked = false;
                        txtMaxLength.Enabled = false;
                        break;
                }
                #endregion
            }
            if ( cbo.Name == cboUC.Name )
            {
                if ( cboUC.Text == HIS.Base_BLL.Enums.ControlType.CheckBox.ToString() )
                {
                    if ( cboFieldType.Text != HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字.ToString() )
                    {
                        cboFieldType.Text = HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字.ToString();
                    }
                }
            }
            controller.ConfigValueChanged();
        }

        private void CheckBox_CheckedChanged( object sender, EventArgs e )
        {
            CheckBox checkBox = (CheckBox)sender;

            if ( checkBox.Name == chkPrimaryKey.Name )
            {
                #region ..........
                if ( chkPrimaryKey.Checked )
                {
                    chkAllowEmpty.Checked = false;
                    chkForignerKey.Checked = false;
                    if ( chkAutoIncrease.Checked )
                        chkAllowEdit.Checked = false;
                }
                #endregion
            }

            if ( checkBox.Name == chkAllowEmpty.Name )
            {
                #region ..........
                if ( chkAllowEmpty.Checked )
                {
                    chkPrimaryKey.Checked = false;
                    chkAutoIncrease.Checked = false;
                }
                #endregion
            }

            if ( checkBox.Name == chkForignerKey.Name )
            {
                #region ..........
                if ( chkForignerKey.Checked )
                {
                    chkPrimaryKey.Checked = false;
                    chkAutoIncrease.Checked = false;

                    grpForignerInfo.Enabled = true;
                }
                else
                {
                    grpForignerInfo.Enabled = false;
                    cboForignerTable.SelectedIndex = -1;
                }
                #endregion
            }

            if ( checkBox.Name == chkAutoIncrease.Name )
            {
                #region ..........
                if ( chkAutoIncrease.Checked )
                {
                    chkAllowEmpty.Checked = false;
                    chkForignerKey.Checked = false;
                    chkAllowEdit.Checked = false;
                    if ( cboFieldType.Text != HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字.ToString() )
                    {
                        cboFieldType.Text = HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字.ToString();
                    }
                }
                #endregion
            }
            if ( checkBox.Name == chkAllowEdit.Name )
            {
                if ( chkAllowEdit.Checked && chkPrimaryKey.Checked && chkAutoIncrease.Checked )
                {
                    chkAutoIncrease.Checked = false;
                }
            }

            controller.ConfigValueChanged();
        }

        private void btnSetting_Click( object sender, EventArgs e )
        {
            FrmSetLocation frmSetLocation = new FrmSetLocation( controller.GetFieldConfigs()  );

            if ( frmSetLocation.ShowDialog() == DialogResult.OK )
            {
                controller.AccecptLoactionSetting( frmSetLocation.LocationSettings );
                SelectedDefaultNode();
            }
        }

        private void btnFixedField_Click( object sender, EventArgs e )
        {
            try
            {
                if ( controller.ReviseConfigFields() )
                {
                    MessageBox.Show( "字段修正完成!", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error ); 
            }
        }

        private void btnConfirmField_Click( object sender, EventArgs e )
        {
            try
            {
                if ( controller.ConfirmFieldExists() )
                {
                    MessageBox.Show( "字段验证通过！", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message ,"",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
        }

        private void btnTestSQL_Click( object sender, EventArgs e )
        {
            try
            {
                if ( controller.TestSQL() )
                {
                    MessageBox.Show( "SQL语句正确！", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }
    }
}
