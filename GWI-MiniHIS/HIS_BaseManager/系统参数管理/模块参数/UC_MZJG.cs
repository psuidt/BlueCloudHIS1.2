using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Base_BLL;
using HIS.Base_BLL.Enums;
using System.Collections;

namespace HIS_BaseManager
{
    public partial class UC_MZJG : UserControl ,IParameter
    {
        public UC_MZJG()
        {
            InitializeComponent();
            
        }

        private Parameters parameters;

        private DataTable dtAllowEditDocPresRange;

        public DataTable AllowEditDocPresRange
        {
            get
            {
                return dtAllowEditDocPresRange;
            }
            set
            {
                dtAllowEditDocPresRange = value;
            }
        }
        #region IParameter 成员

        public HIS.Base_BLL.Enums.ParameterCatalog Catalog
        {
            get
            {
                return HIS.Base_BLL.Enums.ParameterCatalog.门诊经管;
            }
        }

        public HIS.Base_BLL.Parameters Parameters
        {
            get
            {
                return parameters;
            }
            set
            {
                parameters = value;
            }
        }

        #endregion

        /// <summary>
        /// 加载参数
        /// </summary>
        private void LoadParameterConfig()
        {
            //加载参数
            try
            {
                chk001.Checked = Convert.ToInt32( parameters["001"].Value ) == 1 ? true : false;
                chk002.Checked = Convert.ToInt32( parameters["002"].Value ) == 1 ? true : false;
                chk003.Checked = Convert.ToInt32( parameters["003"].Value ) == 1 ? true : false;
                chk004.Checked = Convert.ToInt32( parameters["004"].Value ) == 1 ? true : false;
                txt005.Text = parameters["005"].Value.ToString();
                txt006.Text = parameters["006"].Value.ToString();
                txt007.Text = parameters["007"].Value.ToString();
                chk008.Checked = Convert.ToInt32( parameters["008"].Value ) == 1 ? true : false;
                chk009.Checked = Convert.ToInt32( parameters["009"].Value ) == 1 ? true : false;
                txt010.Text = parameters["010"].Value.ToString();
                txt011.Text = parameters["011"].Value.ToString();
                chk012.Checked = Convert.ToInt32( parameters["012"].Value ) == 1 ? true : false;
                chk013.Checked = Convert.ToInt32( parameters["013"].Value ) == 1 ? true : false;
                cbo014.Text = ( (ChargeType)Convert.ToInt32( parameters["014"].Value ) ).ToString();
                cbo015.Text = parameters["015"].Value.ToString();
                chk016.Checked = Convert.ToInt32( parameters["016"].Value ) == 1 ? true : false;
                chk017.Checked = Convert.ToInt32( parameters["017"].Value ) == 1 ? true : false;
                chk018.Checked = Convert.ToInt32( parameters["018"].Value ) == 1 ? true : false;
                chk019.Checked = Convert.ToInt32( parameters["019"].Value ) == 1 ? true : false;
                cbo020.Text = ( (RoundType)Convert.ToInt32( parameters["020"].Value ) ).ToString();
                cbo021.Text = ( (InvoiceStyle)Convert.ToInt32( parameters["021"].Value ) ).ToString();
            }
            catch
            {
                MessageBox.Show( "读取参数错误！请初始化后再试", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                
            }
        }

        private void UC_MZJG_Load( object sender, EventArgs e )
        {
            foreach ( object obj in Enum.GetValues( typeof( ChargeType ) ) )
                cbo014.Items.Add( obj.ToString() );

            foreach ( object obj in Enum.GetValues( typeof( RoundType ) ) )
                cbo020.Items.Add( obj.ToString() );

            foreach ( object obj in Enum.GetValues( typeof( InvoiceStyle ) ) )
                cbo021.Items.Add( obj.ToString() );

            LoadParameterConfig();

            BindValueChangeEvents();

            BindKeyPressEvents();

            dgvEditItem.AutoGenerateColumns = false;
            dgvEditItem.DataSource = dtAllowEditDocPresRange;
            if ( !chk018.Checked )
                dgvEditItem.Enabled = false;
        }

        private void TextBox_TextChanged( object sender, EventArgs e )
        {
           
            string name = ( (Control)sender ).Name;
            if ( name == txt005.Name )
                parameters["005"].Value = Convert.ToInt32( txt005.Text.Trim() == "" ? "0" : FormatText(txt005.Text) );
            else if ( name == txt006.Name )
                parameters["006"].Value = Convert.ToInt32( txt006.Text.Trim() == "" ? "0" : FormatText(txt006.Text) );
            else if ( name == txt007.Name )
                parameters["007"].Value = Convert.ToInt32( txt007.Text.Trim() == "" ? "0" : FormatText(txt007.Text) );
            else if ( name == txt010.Name )
                parameters["010"].Value = Convert.ToInt32( txt010.Text.Trim() == "" ? "0" : FormatText(txt010.Text) );
            else if ( name == txt011.Name )
                parameters["011"].Value = Convert.ToInt32( txt011.Text.Trim() == "" ? "0" : FormatText(txt011.Text) );
        }

        private void TextBox_KeyPress( object sender, KeyPressEventArgs e )
        {
            int keyAsc = (int)e.KeyChar;
            if ( ( keyAsc >= 48 && keyAsc <= 57 ) || keyAsc == 8 || keyAsc == 13 )
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
            }
        }

        private void CheckBox_CheckedChanged( object sender, EventArgs e )
        {
            string name = ((Control)sender).Name;
            if ( name == chk001.Name )
                parameters["001"].Value = chk001.Checked ? 1 : 0;
            else if ( name == chk002.Name )
                parameters["002"].Value = chk002.Checked ? 1 : 0;
            else if ( name == chk003.Name )
                parameters["003"].Value = chk003.Checked ? 1 : 0;
            else if ( name == chk004.Name )
                parameters["004"].Value = chk004.Checked ? 1 : 0;
            else if ( name == chk008.Name )
                parameters["008"].Value = chk008.Checked ? 1 : 0;
            else if ( name == chk009.Name )
                parameters["009"].Value = chk009.Checked ? 1 : 0 ;
            else if ( name == chk012.Name )
                parameters["012"].Value = 0;
            else if ( name == chk013.Name )
                parameters["013"].Value = chk013.Checked ? 1 : 0;
            else if ( name == chk016.Name )
                parameters["016"].Value = chk016.Checked ? 1 : 0;
            else if ( name == chk017.Name )
                parameters["017"].Value = chk017.Checked ? 1 : 0 ;
            else if ( name == chk018.Name )
            {
                parameters["018"].Value = chk018.Checked ? 1 : 0;
                if ( chk018.Checked )
                    dgvEditItem.Enabled = true;
                else
                    dgvEditItem.Enabled = false;
            }
            else if ( name == chk019.Name )
                parameters["019"].Value = chk019.Checked ? 1 : 0;
            
            
        }

        private void CombBox_SelectedIndexChanged( object sender, EventArgs e )
        {
            string name = ( (Control)sender ).Name;
            if ( name == cbo014.Name )
                parameters["014"].Value = cbo014.SelectedIndex;
            else if ( name == cbo015.Name )
                parameters["015"].Value = Convert.ToInt32( cbo015.Text );
            else if ( name == cbo020.Name )
                parameters["020"].Value = cbo020.SelectedIndex;
            else if ( name == cbo021.Name )
            {
                foreach ( object obj in Enum.GetValues( typeof( InvoiceStyle ) ) )
                {
                    if ( obj.ToString() == cbo021.Text )
                    {
                        parameters["021"].Value = (int)((InvoiceStyle)obj);
                    }
                }
            }
        }

        private void BindValueChangeEvents()
        {
            chk001.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk002.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk003.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk004.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk008.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk009.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk012.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk013.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk016.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk017.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk018.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );
            chk019.CheckedChanged += new EventHandler( CheckBox_CheckedChanged );

            cbo014.SelectedIndexChanged += new EventHandler( CombBox_SelectedIndexChanged );
            cbo015.SelectedIndexChanged += new EventHandler( CombBox_SelectedIndexChanged );
            cbo020.SelectedIndexChanged += new EventHandler( CombBox_SelectedIndexChanged );
            cbo021.SelectedIndexChanged += new EventHandler( CombBox_SelectedIndexChanged );

            txt005.TextChanged += new EventHandler( TextBox_TextChanged );
            txt006.TextChanged += new EventHandler( TextBox_TextChanged );
            txt007.TextChanged += new EventHandler( TextBox_TextChanged );
            txt010.TextChanged += new EventHandler( TextBox_TextChanged );
            txt011.TextChanged += new EventHandler( TextBox_TextChanged );            
        }

        private void BindKeyPressEvents()
        {
            txt005.KeyPress += new KeyPressEventHandler( TextBox_KeyPress );
            txt006.KeyPress += new KeyPressEventHandler( TextBox_KeyPress );
            txt007.KeyPress += new KeyPressEventHandler( TextBox_KeyPress );
            txt010.KeyPress += new KeyPressEventHandler( TextBox_KeyPress );
            txt011.KeyPress += new KeyPressEventHandler( TextBox_KeyPress );
        }

        private string FormatText(string strNum )
        {
            try
            {
                return Convert.ToInt32( strNum ).ToString();
            }
            catch
            {
                return "0";
            }
        }

        

        
    }
}
