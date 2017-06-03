using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Forms;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using _HIS = HIS.SYSTEM.PubicBaseClasses;

using HIS.SYSTEM.DatabaseAccessLayer;
namespace HIS_BaseManager
{
    public partial class FrmInforSerch : GWI.HIS.Windows.Controls.BaseMainForm
    {

        

        public FrmInforSerch(string FormText)
        {
            InitializeComponent();
           
            this.FormTitle = FormText;
            this.Text = FormText;
        }

        private void FrmInforSerch_Load( object sender, EventArgs e )
        {
            dgvDrugItem.AutoGenerateColumns = false;
            dgvServiceItem.AutoGenerateColumns = false;
            LoadData();
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            dgvServiceItem.DataSource = HIS.Base_BLL.BaseDataReader.Get_HIS_ItemList().DefaultView;
            dgvDrugItem.DataSource = HIS.Base_BLL.BaseDataReader.Get_DrugDiciton().DefaultView;
        }

        private void toolStripButton1_Click( object sender, EventArgs e )
        {
            LoadData();
        }

        private void toolStripButton2_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void btnSearch_Click( object sender, EventArgs e )
        {
            string strKey = lblKeyWord.Text;
            strKey = strKey.Replace( "'", "''" );
            strKey = strKey.Replace( "[", "" );
            strKey = strKey.Replace( "%", "[%]" );
            strKey = strKey.Replace( "*", "[*]" );
            strKey = strKey.Replace( "(", "[(]" );
            try
            {
                string s1 = "PY_CODE LIKE '%" + strKey + "%' OR WB_CODE LIKE '%" + strKey + "%' OR BYNAME LIKE '%" + strKey + "%' OR NAME LIKE '%" + strKey + "%'";
                ( (DataView)dgvDrugItem.DataSource ).RowFilter = s1;
                string s2 = "PY_CODE LIKE '%" + strKey + "%' OR WB_CODE LIKE '%" + strKey + "%' OR ITEM_NAME LIKE '%" + strKey + "%'";
                ( (DataView)dgvServiceItem.DataSource ).RowFilter = s2;
            }
            catch
            {
            }
        }

        private void lblKeyWord_KeyPress( object sender, KeyPressEventArgs e )
        {
            if( (int)e.KeyChar == 13 )
                btnSearch_Click( null, null );
        }
    }
}
