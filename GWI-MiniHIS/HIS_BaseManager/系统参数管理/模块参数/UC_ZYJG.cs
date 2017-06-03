using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Base_BLL;

namespace HIS_BaseManager
{
    public partial class UC_ZYJG : UserControl, IParameter
    {
        public UC_ZYJG()
        {
            InitializeComponent();
        }

        private Parameters parameters;


        #region IParameter 成员

        public HIS.Base_BLL.Enums.ParameterCatalog Catalog
        {
            get
            {
                return HIS.Base_BLL.Enums.ParameterCatalog.住院经管;
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

        private void UC_ZYJG_Load( object sender, EventArgs e )
        {
            ShowParameters();

            chk001.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk002.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk003_1.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk004.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk005.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk006.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk008.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk009.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk010.CheckedChanged += new EventHandler( CheckBox_CheckChanged );

            txt007.TextChanged += new EventHandler( txt007_TextChanged );
        }

        void txt007_TextChanged( object sender, EventArgs e )
        {
            parameters["007"].Notes = txt007.Text;
        }

     
        private void ShowParameters()
        {
            chk001.Checked = Convert.ToInt32( parameters["001"].Value ) == 1 ? true : false;
            chk002.Checked = Convert.ToInt32( parameters["002"].Value ) == 1 ? true : false;
            if ( Convert.ToInt32( parameters["003"].Value ) == 1 )
            {
                chk003_0.Checked = false;
                chk003_1.Checked = true;
            }
            else
            {
                chk003_0.Checked = false;
                chk003_1.Checked = true;
            }
            chk004.Checked = Convert.ToInt32( parameters["004"].Value ) == 1 ? true : false;
            chk005.Checked = Convert.ToInt32( parameters["005"].Value ) == 1 ? true : false;
            chk006.Checked = Convert.ToInt32( parameters["006"].Value ) == 1 ? true : false;
            
            chk008.Checked = Convert.ToInt32( parameters["008"].Value ) == 1 ? true : false;
            chk009.Checked = Convert.ToInt32( parameters["009"].Value ) == 1 ? true : false;
            chk010.Checked = Convert.ToInt32( parameters["010"].Value ) == 1 ? true : false;

            txt007.Text = parameters["007"].Value.ToString();
        }

        void CheckBox_CheckChanged( object sender, EventArgs e )
        {
            string ctrlName = ( (Control)sender ).Name;
            if ( ctrlName == chk001.Name )
                parameters["001"].Value = chk001.Checked ? 1 : 0;
            else if ( ctrlName == chk002.Name )
            {
                parameters["002"].Value = chk002.Checked ? 1 : 0;
            }
            else if ( ctrlName == chk003_1.Name )
            {
                parameters["003"].Value = chk003_1.Checked ? 1 : 0;
            }
            else if ( ctrlName == chk004.Name )
            {
                parameters["004"].Value = chk004.Checked ? 1 : 0;
            }
            else if ( ctrlName == chk005.Name )
            {
                parameters["005"].Value = chk005.Checked ? 1 : 0;
            }
            else if ( ctrlName == chk006.Name )
            {
                parameters["006"].Value = chk006.Checked ? 1 : 0;
            }
            else if ( ctrlName == chk008.Name )
            {
                parameters["008"].Value = chk008.Checked ? 1 : 0;
            }
            else if ( ctrlName == chk009.Name )
            {
                parameters["009"].Value = chk009.Checked ? 1 : 0;
            }
            else if ( ctrlName == chk010.Name )
            {
                parameters["010"].Value = chk010.Checked ? 1 : 0;
            }
        }
    }
}
