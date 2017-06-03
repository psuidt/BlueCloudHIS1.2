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
    public partial class UC_ZYYS : UserControl, IParameter
    {
        public UC_ZYYS()
        {
            InitializeComponent();
        }

        private Parameters parameters;


        #region IParameter 成员

        public HIS.Base_BLL.Enums.ParameterCatalog Catalog
        {
            get
            {
                return HIS.Base_BLL.Enums.ParameterCatalog.住院医生站;
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

        private void UC_ZYYS_Load( object sender, EventArgs e )
        {
            LoadDataSource();

            ShowParameters();

            chk001.CheckedChanged +=new EventHandler( CheckBox_CheckChanged );
            chk002.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk003.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk005.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk006.CheckedChanged += new EventHandler( CheckBox_CheckChanged );
            chk007.CheckedChanged += new EventHandler(CheckBox_CheckChanged);
            dgv004.CellValueChanged += new DataGridViewCellEventHandler(dgv004_CellValueChanged);          
        }

        private void LoadDataSource()
        {       
            // * 20100517.2.01 住院医生站参数设置修改（科室和药房对应关系）
            DataRow[] drDeptOfZY = BaseDataReader.Base_Dept_Property.Select("ZY_FLAG=1 AND TYPE_CODE='001'");
            for (int i = 0; i < drDeptOfZY.Length; i++)
            {
                DataRow dr = baseDataSet.Tables["dtDeptOfZY"].NewRow();
                dr["DEPT_ID"] = drDeptOfZY[i]["DEPT_ID"];
                dr["NAME"] = drDeptOfZY[i]["NAME"];
                baseDataSet.Tables["dtDeptOfZY"].Rows.Add(dr);
            }

            DataRow[] drDeptOfYP = BaseDataReader.GetDrugRoomList().Select("DEPTTYPE1='药房'");
            for (int i = 0; i < drDeptOfYP.Length; i++)
            {
                DataRow dr = baseDataSet.Tables["dtDeptOfYP"].NewRow();
                dr["DEPTDICID"] = drDeptOfYP[i]["DEPTID"];
                dr["DEPTNAME"] = drDeptOfYP[i]["DEPTNAME"];
                baseDataSet.Tables["dtDeptOfYP"].Rows.Add(dr);
            }         
        }

        private void ShowParameters()
        {
            chk001.Checked = Convert.ToInt32( parameters["001"].Value ) == 1 ? true : false;
            chk002.Checked = Convert.ToInt32( parameters["002"].Value ) == 1 ? true : false;
            chk003.Checked = Convert.ToInt32( parameters["003"].Value ) == 1 ? true : false;
            chk005.Checked = Convert.ToInt32( parameters["005"].Value ) == 1 ? true : false;
            chk006.Checked = Convert.ToInt32(parameters["006"].Value) == 1 ? true : false;
            chk007.Checked = Convert.ToInt32(parameters["007"].Value) == 1 ? true : false;
            string strCfg = parameters["004"].Value.ToString().Trim();
            if (strCfg.Trim() != "")
            {
                string[] relation = strCfg.Split(",".ToCharArray());
                for (int i = 0; i < relation.Length; i++)
                {
                    string[] values = relation[i].Split("-".ToCharArray());
                    int row = dgv004.Rows.Add();
                    dgv004[DEPT_ID.Name, row].Value = values[0];
                    dgv004[DEPTDICID.Name, row].Value = values[1];
                }
            }

        }

        private void CheckBox_CheckChanged( object sender, EventArgs e )
        {
            string ctrlName = ( (Control)sender ).Name;
            if ( ctrlName == chk001.Name )
                parameters["001"].Value = chk001.Checked ? 1 : 0;
            else if ( ctrlName == chk002.Name )
                parameters["002"].Value = chk002.Checked ? 1 : 0;
            else if ( ctrlName == chk003.Name )
                parameters["003"].Value = chk003.Checked ? 1 : 0;
            else if ( ctrlName == chk005.Name )
                parameters["005"].Value = chk005.Checked ? 1 : 0;
            else if (ctrlName == chk006.Name)
                parameters["006"].Value = chk006.Checked ? 1 : 0;
            else if (ctrlName == chk007.Name)
                parameters["007"].Value = chk007.Checked ? 1 : 0;
        }
     

        private void dgv004_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }

        void dgv004_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetParameter_004_Value();
        }

        private void SetParameter_004_Value()
        {
            string strValue = "";
            for (int i = 0; i < dgv004.Rows.Count; i++)
            {
                if ((dgv004[DEPT_ID.Name, i].Value != null && dgv004[DEPT_ID.Name, i].Value.ToString() != "") &&
                    (dgv004[DEPTDICID.Name, i].Value != null && dgv004[DEPTDICID.Name, i].Value.ToString() != ""))
                    strValue = strValue + dgv004[DEPT_ID.Name, i].Value.ToString().Trim() + "-" + dgv004[DEPTDICID.Name, i].Value.ToString().Trim() + ",";
            }
            if (strValue.Trim() != "")
                strValue = strValue.Remove(strValue.Length - 1, 1);
            parameters["004"].Value = strValue;
        }

        private void btnAddMapping_Click(object sender, EventArgs e)
        {
            dgv004.Rows.Add();
        }

        private void btnRemoveMapping_Click(object sender, EventArgs e)
        {
            if (dgv004.Rows.Count != 0)
                dgv004.Rows.RemoveAt(dgv004.CurrentRow.Index);

            SetParameter_004_Value();
        }
    }
}
