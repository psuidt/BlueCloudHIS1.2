using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_BaseManager
{
    public partial class FrmNccmAutoMatch : Form
    {
        private DataTable dtMatch;
        private HIS.Base_BLL.Enums.MatchClass _matchClass;

        public System.Collections.Hashtable ReturnedMatchRelation;

        public FrmNccmAutoMatch(HIS.Base_BLL.Enums.MatchClass matchClass, DataTable tb)
        {
            InitializeComponent();
            dtMatch = tb;
            _matchClass = matchClass;
        }

        /// <summary>
        /// 创建农合、医保药品目录网格列式样
        /// </summary>
        private void CreateGridOfDrug()
        {
            GWMHIS.PublicControls.GridColumn[] columns = new GWMHIS.PublicControls.GridColumn[18];

            columns[0].HeaderText = "选";
            columns[0].Width = 35;
            columns[0].ColumnType = GWMHIS.PublicControls.ColumnType.CheckBox;
            columns[0].CanEdit = true;
            columns[0].DataField = "selected";

            columns[1].HeaderText = "类型";
            columns[1].Width = 35;
            columns[1].DataField = "nccm_drug_type";

            columns[2].HeaderText = "编码";
            columns[2].Width = 100;
            columns[2].DataField = "nccm_drug_code";

            columns[3].HeaderText = "药品名称";
            columns[3].Width = 150;
            columns[3].DataField = "nccm_drug_name";

            columns[4].HeaderText = "药品别名";
            columns[4].Width = 150;
            columns[4].DataField = "nccm_drug_alias";

            columns[5].HeaderText = "规格";
            columns[5].Width = 80;
            columns[5].DataField = "nccm_specs";

            columns[6].HeaderText = "单位";
            columns[6].Width = 50;
            columns[6].DataField = "nccm_unit";

            columns[7].HeaderText = "价格";
            columns[7].Width = 70;
            columns[7].DataField = "nccm_price";

            columns[8].HeaderText = "剂型";
            columns[8].Width = 40;
            columns[8].DataField = "nccm_drug_form";

            

            columns[9].HeaderText = "类型";
            columns[9].Width = 35;
            columns[9].DataField = "his_type";

            columns[10].HeaderText = "编码";
            columns[10].Width = 60;
            columns[10].DataField = "his_code";

            columns[11].HeaderText = "药品名称";
            columns[11].Width = 120;
            columns[11].DataField = "his_name";

            columns[12].HeaderText = "化学名";
            columns[12].Width = 120;
            columns[12].DataField = "his_chemname";

            columns[13].HeaderText = "规格";
            columns[13].Width = 90;
            columns[13].DataField = "his_spec";

            columns[14].HeaderText = "单位";
            columns[14].Width = 65;
            columns[14].DataField = "his_unit";

            columns[15].HeaderText = "单价";
            columns[15].Width = 65;
            columns[15].DataField = "his_price";

            columns[16].HeaderText = "剂型";
            columns[16].Width = 65;
            columns[16].DataField = "his_model";

            columns[17].HeaderText = "生产厂家";
            columns[17].Width = 150;
            columns[17].DataField = "his_factory";


            dgvList.SetColumnsStyle( columns );
        }
        /// <summary>
        /// 创建农合、医保药品目录网格列式样
        /// </summary>
        private void CreateGridOfItem()
        {
            GWMHIS.PublicControls.GridColumn[] columns = new GWMHIS.PublicControls.GridColumn[12];

            columns[0].HeaderText = "选";
            columns[0].Width = 35;
            columns[0].ColumnType = GWMHIS.PublicControls.ColumnType.CheckBox;
            columns[0].CanEdit = true;
            columns[0].DataField = "selected";

            columns[1].HeaderText = "项目编码";
            columns[1].Width = 90;
            columns[1].DataField = "nccm_item_code";

            columns[2].HeaderText = "项目名称";
            columns[2].Width = 180;
            columns[2].DataField = "nccm_item_name";

            columns[3].HeaderText = "单位";
            columns[3].Width = 70;
            columns[3].DataField = "nccm_unit";

            columns[4].HeaderText = "一类价格";
            columns[4].Width = 70;
            columns[4].DataField = "nccm_price1";

            columns[5].HeaderText = "二类价格";
            columns[5].Width = 70;
            columns[5].DataField = "nccm_price2";

            columns[6].HeaderText = "三类价格";
            columns[6].Width = 70;
            columns[6].DataField = "nccm_price3";



            columns[7].HeaderText = "医院编号";
            columns[7].Width = 75;
            columns[7].DataField = "his_item_id";

            columns[8].HeaderText = "医疗编码";
            columns[8].Width = 120;
            columns[8].DataField = "his_std_code";

            columns[9].HeaderText = "项目名称";
            columns[9].Width = 120;
            columns[9].DataField = "his_item_name";
          
            columns[10].HeaderText = "单位";
            columns[10].Width = 120;
            columns[10].DataField = "his_item_unit";

            columns[11].HeaderText = "单价";
            columns[11].Width = 120;
            columns[11].DataField = "his_price";

            dgvList.SetColumnsStyle( columns );
        }

        private void FrmNccmAutoMatch_Load( object sender, EventArgs e )
        {
            if ( _matchClass == HIS.Base_BLL.Enums.MatchClass.药品匹配 )
            {
                CreateGridOfDrug();
            }
            else
            {
                CreateGridOfItem();   
            }
            DataTable dtTmp = dtMatch.Clone();

            foreach ( DataColumn col in dtTmp.Columns )
            {
                if ( dgvList.Columns.Contains( col.ColumnName ) && dgvList.Columns[col.ColumnName].Visible )
                {
                    continue;
                }
                else
                {
                    dtMatch.Columns.Remove( col.ColumnName );
                }
            }

            dgvList.DataSource = dtMatch;
            int colIndex = 0;
            if ( _matchClass == HIS.Base_BLL.Enums.MatchClass.药品匹配 )
            {
                colIndex = 8;
            }
            else
            {
                colIndex = 7;
            }

            for ( int i = 1; i <= colIndex ; i++ )
            {
                dgvList.Columns[i].DefaultCellStyle.BackColor = Color.LightCyan;
            }
        }

        private void btnOK_Click( object sender, EventArgs e )
        {
            System.Collections.Hashtable htItems = new System.Collections.Hashtable();

            for ( int i = 0; i < dgvList.Rows.Count; i++ )
            {
                short selected = 0;
                if ( dgvList["selected", i].Value != null )
                {
                    selected = Convert.ToInt16( dgvList["selected", i].Value );
                }
                if ( selected == 1 )
                {
                    string his_code = "";
                    string nccm_code = "";
                    string strName = "";
                    if ( _matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配 )
                    {
                        his_code = dgvList["his_item_id", i].Value.ToString();
                        nccm_code = dgvList["nccm_item_code", i].Value.ToString();
                        strName = dgvList["his_item_name", i].Value.ToString();
                    }
                    else
                    {
                        his_code = dgvList["his_code", i].Value.ToString();
                        nccm_code = dgvList["nccm_drug_code", i].Value.ToString();
                        strName = dgvList["his_chemname", i].Value.ToString();
                    }
                    if ( !htItems.Contains( his_code ) )
                    {
                        htItems.Add( his_code, nccm_code );
                    }
                    else
                    {
                        MessageBox.Show( strName + "  只允许匹配到一个农合目录下！", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        return;
                    }

                }
            }
            ReturnedMatchRelation = htItems;
            this.Close();
        }

        private void btnCancel_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void chkAll_CheckedChanged( object sender, EventArgs e )
        {
            if ( chkAll.Checked )
            {
                for ( int i = 0; i < dgvList.Rows.Count; i++ )
                {
                    dgvList["selected", i].Value = (short)1;
                }
            }
            else
            {
                for ( int i = 0; i < dgvList.Rows.Count; i++ )
                {
                    dgvList["selected", i].Value = (short)0;
                }
            }
        }
    }
}
