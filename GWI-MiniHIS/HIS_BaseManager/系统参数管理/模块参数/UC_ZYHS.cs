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
    public partial class UC_ZYHS : UserControl, IParameter
    {
        public UC_ZYHS()
        {
            InitializeComponent();
        }

        private Parameters parameters;
        

        #region IParameter 成员

        public HIS.Base_BLL.Enums.ParameterCatalog Catalog
        {
            get
            {
                return HIS.Base_BLL.Enums.ParameterCatalog.住院护士站;
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

        private void UC_ZYHS_Load( object sender, EventArgs e )
        {
            ShowParameters();
            LoadDataSource();
            chk001.CheckedChanged += new EventHandler( CheckBoxCheckChanged );
            chk002.CheckedChanged += new EventHandler( CheckBoxCheckChanged );
            chk007.CheckedChanged += new EventHandler( CheckBoxCheckChanged );
            rd008_0.CheckedChanged += new EventHandler( CheckBoxCheckChanged );
            txt003.Validating += new CancelEventHandler( txtBox_Validating );
            txt004.Validating += new CancelEventHandler( txtBox_Validating );
            txt005.Validating += new CancelEventHandler( txtBox_Validating );
            txt006.Validating += new CancelEventHandler( txtBox_Validating );
            dgv009.CellValueChanged += new DataGridViewCellEventHandler(dgv009_CellValueChanged);       
        }
        private void LoadDataSource()
        {
            // * 20100925.2.01 护士站账单录入参数设置修改（科室和药房对应关系）
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
        void dgv009_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            SetParameter_009_Value();
        }

        private void SetParameter_009_Value()
        {
            string strValue = "";
            for (int i = 0; i < dgv009.Rows.Count; i++)
            {
                if ((dgv009[DEPT_ID.Name, i].Value != null && dgv009[DEPT_ID.Name, i].Value.ToString() != "") &&
                    (dgv009[DEPTDICID.Name, i].Value != null && dgv009[DEPTDICID.Name, i].Value.ToString() != ""))
                    strValue = strValue + dgv009[DEPT_ID.Name, i].Value.ToString().Trim() + "-" + dgv009[DEPTDICID.Name, i].Value.ToString().Trim() + ",";
            }
            if (strValue.Trim() != "")
                strValue = strValue.Remove(strValue.Length - 1, 1);
            parameters["009"].Value = strValue;
        }


        void txtBox_Validating( object sender, CancelEventArgs e )
        {
            string message;
            if ( !ValidTextBox( (TextBox)sender, out message ) )
            {
                MessageBox.Show( message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }
            string ctrlName = ( (Control)sender ).Name;
            if ( ctrlName == txt003.Name )
            {
                parameters["003"].Value = Convert.ToInt32( txt003.Text );
            }
            else if ( ctrlName == txt004.Name )
            {
                parameters["004"].Value = Convert.ToInt32( txt004.Text );
            }
            else if ( ctrlName == txt005.Name )
            {
                parameters["005"].Value = Convert.ToInt32( txt005.Text );
            }
            else if ( ctrlName == txt006.Name )
            {
                parameters["006"].Value = Convert.ToInt32( txt006.Text );
            }
        }

        bool ValidTextBox( TextBox textBox ,out string message)
        {
            message = "";
            try
            {
                Convert.ToInt32( textBox.Text );
                return true;
            }
            catch
            {
                message = "格式不正确";
                return false;
            }
        }

        private void ShowParameters()
        {
            chk001.Checked = Convert.ToInt32(parameters["001"].Value) == 1 ? true : false;
            chk002.Checked = Convert.ToInt32( parameters["002"].Value ) == 1 ? true : false;
            chk007.Checked = Convert.ToInt32( parameters["007"].Value ) == 1 ? true : false;
            txt003.Text = parameters["003"].Value.ToString();
            txt004.Text = parameters["004"].Value.ToString();
            txt005.Text = parameters["005"].Value.ToString();
            txt006.Text = parameters["006"].Value.ToString();
            if ( Convert.ToInt32( parameters["008"].Value ) == 1 )
            {
                rd008_0.Checked = false;
                rd008_1.Checked = true;
            }
            else
            {
                rd008_0.Checked = true;
                rd008_1.Checked = false;
            }
            string strCfg = parameters["009"].Value.ToString().Trim();
            if (strCfg.Trim() != "")
            {
                string[] relation = strCfg.Split(",".ToCharArray());
                for (int i = 0; i < relation.Length; i++)
                {
                    string[] values = relation[i].Split("-".ToCharArray());
                    int row = dgv009.Rows.Add();
                    dgv009[DEPT_ID.Name, row].Value = values[0];
                    dgv009[DEPTDICID.Name, row].Value = values[1];
                }
            }
        }

        private void CheckBoxCheckChanged( object sender, EventArgs e )
        {
            string ctrlName = ( (Control)sender ).Name;
            if ( ctrlName == chk001.Name )
            {
                parameters["001"].Value = chk001.Checked ? 1 : 0;

            }
            else if ( ctrlName == chk002.Name )
            {
                parameters["002"].Value = chk002.Checked ? 1 : 0;
            }
            else if ( ctrlName == chk007.Name )
            {
                parameters["007"].Value = chk007.Checked ? 1 : 0;
            }
            else if ( ctrlName == rd008_0.Name )
            {
                parameters["008"].Value = rd008_1.Checked ? 1 : 0;
                    
            }
        }

        private void btnAddMapping_Click(object sender, EventArgs e)
        {
            dgv009.Rows.Add();
        }

        private void btnRemoveMapping_Click(object sender, EventArgs e)
        {
            if (dgv009.Rows.Count != 0)
                dgv009.Rows.RemoveAt(dgv009.CurrentRow.Index);

            SetParameter_009_Value();
        }

        
    }
}
