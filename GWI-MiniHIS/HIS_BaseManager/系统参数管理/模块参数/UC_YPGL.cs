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
    public partial class UC_YPGL : UserControl, IParameter
    {
        public UC_YPGL()
        {
            InitializeComponent();
        }

        private Parameters parameters;


        #region IParameter 成员

        public HIS.Base_BLL.Enums.ParameterCatalog Catalog
        {
            get
            {
                return HIS.Base_BLL.Enums.ParameterCatalog.药品管理;
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

        private void UC_YPGL_Load( object sender, EventArgs e )
        {
            LoadDrugRoomList();
            //显示公共参数
            ShowCommonParameters();
            //绑定事件以便更改
            BindCommonEvent();

            lstDrugRoom.SelectedIndexChanged += new EventHandler( lstDrugRoom_SelectedIndexChanged );
            if ( lstDrugRoom.Items.Count > 0 )
                lstDrugRoom.Items[0].Selected = true;

            
        }

        void cbo008_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( lstDrugRoom.SelectedItems.Count == 0 )
                return;
            int deptId = Convert.ToInt32( lstDrugRoom.SelectedItems[0].Tag );
            GetDrugParameter("008",deptId).Value = Convert.ToInt32( cbo008.Text );
        }

        void TextBox_Validating( object sender, CancelEventArgs e )
        {
            string name = ( (Control)sender ).Name;
            if ( name == txt015.Name )
            {
                parameters["015"].Value = Convert.ToInt32(txt015.Text);
            }
            else if ( name == txt016.Name )
            {
                parameters["016"].Value = Convert.ToInt32(txt016.Text);
            }
            else if ( name == txt017.Name )
            {
                parameters["017"].Value = Convert.ToInt32(txt017.Text);
            }
        }

        void txt013_Validating( object sender, CancelEventArgs e )
        {
            if ( lstDrugRoom.SelectedItems.Count == 0 )
                return;
            int deptId = Convert.ToInt32( lstDrugRoom.SelectedItems[0].Tag );

            GetDrugParameter( "013", deptId ).Value = txt013.Text;
        }

        void lstDrugRoom_SelectedIndexChanged( object sender, EventArgs e )
        {
            RemoveSpeciEvent();

            ShowDrugRoomParameters();

            BindSpeciEvent();
        }

        private void ShowCommonParameters()
        {
            chk009.Checked = Convert.ToInt32( parameters["009"].Value ) == 1 ? true : false;
            if ( Convert.ToInt32( parameters["014"].Value ) == 0 )
            {
                rd014_0.Checked = true;
                rd014_1.Checked = false;
            }
            else
            {
                rd014_0.Checked = false;
                rd014_1.Checked = true;
            }
            txt015.Text = parameters["015"].Value.ToString();
            txt016.Text = parameters["016"].Value.ToString();
            txt017.Text = parameters["017"].Value.ToString();
            chk018.Checked = Convert.ToInt32( parameters["018"].Value ) == 1 ? true : false;
            chk019.Checked = Convert.ToInt32( parameters["019"].Value ) == 1 ? true : false;
            chk020.Checked = Convert.ToInt32( parameters["020"].Value ) == 1 ? true : false;
            chk021.Checked = Convert.ToInt32( parameters["021"].Value ) == 1 ? true : false;
        }

        private void ShowDrugRoomParameters()
        {
            if ( lstDrugRoom.SelectedItems.Count == 0 )
                return;
            int deptId = Convert.ToInt32( lstDrugRoom.SelectedItems[0].Tag );

            chk006.Checked = Convert.ToInt32( GetDrugParameter( "006", deptId ).Value ) == 1 ? true : false;
            cbo008.Text = GetDrugParameter( "008", deptId ).Value.ToString();
            chk010.Checked = Convert.ToInt32( GetDrugParameter( "010", deptId ).Value ) == 1 ? true : false;
            chk011.Checked = Convert.ToInt32( GetDrugParameter( "011", deptId ).Value ) == 1 ? true : false;
            chk012.Checked = Convert.ToInt32( GetDrugParameter( "012", deptId ).Value ) == 1 ? true : false;
            txt013.Text = GetDrugParameter( "013", deptId ).Value.ToString();
            
        }

        private Parameter GetDrugParameter( string Code, int DeptId )
        {
            foreach ( Parameter p in parameters )
            {
                if ( p.Code == Code && p.DeptId == DeptId )
                {
                    return p;
                    
                }
            }

            throw new Exception( "无效的参数代码【"+Code+"】" );
        }
        /// <summary>
        /// 加载药房
        /// </summary>
        private void LoadDrugRoomList()
        {
            DataTable dtDrugRoom = BaseDataReader.GetDrugRoomList();
            foreach ( DataRow dr in dtDrugRoom.Rows )
            {
                int deptId = Convert.ToInt32( dr["DEPTID"] );
                string deptName = dr["DEPTNAME"].ToString().Trim();
                ListViewItem item = new ListViewItem();
                item.Text = deptName;
                item.Tag = deptId;
                lstDrugRoom.Items.Add( item );
            }
        }

        private void CheckBox_Common_CheckedChanged( object sender, EventArgs e )
        {
            Control ctrl = (Control)sender;
            string name = ctrl.Name;
            if ( name == chk009.Name )
            {
                parameters["009"].Value = chk009.Checked ? 1 : 0;
            }
            else if ( name == chk018.Name )
            {
                parameters["018"].Value = chk018.Checked ? 1 : 0;
            }
            else if ( name == chk019.Name )
            {
                parameters["019"].Value = chk019.Checked ? 1 : 0;
            }
            else if ( name == chk020.Name )
            {
                parameters["020"].Value = chk020.Checked ? 1 : 0;
            }
            else if ( name == chk021.Name )
            {
                parameters["021"].Value = chk021.Checked ? 1 : 0;
            }
            else if ( name == rd014_0.Name )
            {
                if ( rd014_0.Checked )
                {
                    parameters["014"].Value = 0;
                }
                else
                {
                    parameters["014"].Value = 1;
                }
            }
        }

        private void CheckBox_Speci_CheckedChanged( object sender, EventArgs e )
        {
            if ( lstDrugRoom.SelectedItems.Count == 0 )
                return;
            int deptId = Convert.ToInt32( lstDrugRoom.SelectedItems[0].Tag );

            string name = ( (Control)sender ).Name;

            if ( name == chk010.Name )
            {
                GetDrugParameter( "010", deptId ).Value = chk010.Checked ? 1 : 0;
            }
            else if ( name == chk011.Name )
            {
                GetDrugParameter( "011", deptId ).Value = chk011.Checked ? 1 : 0;
            }
            else if ( name == chk012.Name )
            {
                GetDrugParameter( "012", deptId ).Value = chk012.Checked ? 1 : 0;
            }

        }

        private void BindCommonEvent()
        {
            chk009.CheckedChanged += new EventHandler( CheckBox_Common_CheckedChanged );
            rd014_0.CheckedChanged += new EventHandler( CheckBox_Common_CheckedChanged );
            rd014_1.CheckedChanged += new EventHandler( CheckBox_Common_CheckedChanged );
            txt015.Validating += new CancelEventHandler( TextBox_Validating );
            txt016.Validating += new CancelEventHandler( TextBox_Validating );
            txt017.Validating += new CancelEventHandler( TextBox_Validating );
            chk018.CheckedChanged += new EventHandler( CheckBox_Common_CheckedChanged );
            chk019.CheckedChanged += new EventHandler( CheckBox_Common_CheckedChanged );
            chk020.CheckedChanged += new EventHandler( CheckBox_Common_CheckedChanged );
            chk021.CheckedChanged += new EventHandler( CheckBox_Common_CheckedChanged );
        }

        private void BindSpeciEvent()
        {
            txt013.Validating += new CancelEventHandler( txt013_Validating );
            cbo008.SelectedIndexChanged += new EventHandler( cbo008_SelectedIndexChanged );
            chk006.CheckedChanged += new EventHandler( CheckBox_Speci_CheckedChanged );
            chk010.CheckedChanged += new EventHandler( CheckBox_Speci_CheckedChanged );
            chk011.CheckedChanged += new EventHandler( CheckBox_Speci_CheckedChanged );
            chk012.CheckedChanged += new EventHandler( CheckBox_Speci_CheckedChanged );
            
        }

        private void RemoveSpeciEvent()
        {
            txt013.Validating -= new CancelEventHandler( txt013_Validating );
            cbo008.SelectedIndexChanged += new EventHandler( cbo008_SelectedIndexChanged );
            chk006.CheckedChanged -= new EventHandler( CheckBox_Speci_CheckedChanged );
            chk010.CheckedChanged -= new EventHandler( CheckBox_Speci_CheckedChanged );
            chk011.CheckedChanged -= new EventHandler( CheckBox_Speci_CheckedChanged );
            chk012.CheckedChanged -= new EventHandler( CheckBox_Speci_CheckedChanged );
        }
    }
}
