using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Model;
using HIS.YP_BLL;


namespace HIS_YPManager
{
    public partial class FrmCheckType : GWI.HIS.Windows.Controls.BaseForm
    {
        public FrmCheckType()
        {
            InitializeComponent();
        }
        public int drugTypeId = 0;
        public int drugDoseId = -1;
        public bool isOnlyNoStore = false;
        private List<YP_TypeDic> typeList = new List<YP_TypeDic>();
        private List<YP_DoseDic> doseList = new List<YP_DoseDic>();
        private void FrmCheckType_Load(object sender, EventArgs e)
        {
            typeList = DrugBaseDataBll.GetAllType();
            foreach (YP_TypeDic type in typeList)
            {
                cobDrugType.Items.Add(type.TypeName);
                cobDrugType.Tag = type;
            }            
            cobDrugType.SelectedIndex = 0;
            YP_DoseDic newDose = new YP_DoseDic();
            newDose.DoseName = "无剂型药品";
            doseList = DrugBaseDataBll.GetDoseType(cobDrugType.SelectedIndex + 1);
            doseList.Insert(0, newDose);
            foreach (YP_DoseDic dose in doseList)
            {
                cobDrugDose.Items.Add(dose.DoseName);
                cobDrugDose.Tag = dose;
            }
            cobDrugDose.SelectedIndex = 0;
        }

        private void chkDrugType_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDrugType.Checked == true)
            {
                cobDrugType.Enabled = true;
                drugTypeId = typeList[cobDrugType.SelectedIndex].TypeDicID; 
            }
            else 
            {
                cobDrugType.Enabled = false;
                drugTypeId = 0;
            }
        }

        private void chkDrugDose_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDrugDose.Checked == true)
            {
                cobDrugDose.Enabled = true;
                drugDoseId = doseList[cobDrugDose.SelectedIndex].DoseDicID;
            }
            else
            {
                cobDrugDose.Enabled = false;
                drugDoseId = -1;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void cobDrugType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobDrugType.Enabled == true)
            {
                int index = cobDrugType.SelectedIndex;
                drugTypeId = typeList[index].TypeDicID;
                if (index != -1)
                {
                    doseList = DrugBaseDataBll.GetDoseType(index + 1);
                    cobDrugDose.Items.Clear();
                    YP_DoseDic newDose = new YP_DoseDic();
                    newDose.DoseName = "无剂型药品";
                    doseList.Insert(0, newDose);
                    foreach (YP_DoseDic dose in doseList)
                    {
                        cobDrugDose.Items.Add(dose.DoseName);
                        cobDrugDose.Tag = dose;
                    }
                    cobDrugDose.SelectedIndex = 0;
                    if (chkDrugDose.Checked)
                    {
                        drugDoseId = 0;
                    }
                    else
                    {
                        drugDoseId = -1;
                    }
                }
            }
        }

        private void cobDrugDose_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cobDrugDose.Enabled == true)
            {
                if (cobDrugDose.SelectedIndex != 0)
                {
                    int index = cobDrugDose.SelectedIndex;
                    drugDoseId = doseList[index].DoseDicID;
                }
                else
                {
                    drugDoseId = 0;
                }
            }
        }

        private void chkIsHaveStore_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsHaveStore.Checked)
            {
                this.isOnlyNoStore = true;
            }
            else
            {
                this.isOnlyNoStore = false;
            }
        }
    }
}
