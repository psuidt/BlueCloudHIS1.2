using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZDocManager
{
    public partial class FrmApplyFormat : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public FrmApplyFormat(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            this.Text = chineseName;
            this.FormTitle = chineseName;
            Initialize();
        }

        private void Initialize()
        {
            FormSite.NavigationBand[] band = new FormSite.NavigationBand[3];
            List<HIS.Model.Base_Medical_Class> list = new List<HIS.Model.Base_Medical_Class>();

            band[0].Text = "化验申请";
            HIS.MZDoc_BLL.BaseMedical medicalAssay = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(HIS.MZDoc_BLL.Public.MedicalApplyType.医技化验申请);
            list = medicalAssay.LoadMedicalClass();
            if (list != null)
            {
                band[0].Items = new FormSite.NavigationItem[list.Count];
                for (int index = 0; index < list.Count; index++)
                {
                    band[0].Items[index].Text = list[index].Name;
                    band[0].Items[index].Value = list[index].Id;
                    band[0].Items[index].FormatXmlDocument = list[index].PrintType;
                }
            }

            band[1].Text = "检查申请";
            medicalAssay = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(HIS.MZDoc_BLL.Public.MedicalApplyType.医技检查申请);
            list = medicalAssay.LoadMedicalClass();
            if (list != null)
            {
                band[1].Items = new FormSite.NavigationItem[list.Count];
                for (int index = 0; index < list.Count; index++)
                {
                    band[1].Items[index].Text = list[index].Name;
                    band[1].Items[index].Value = list[index].Id;
                    band[1].Items[index].FormatXmlDocument = list[index].PrintType;
                }
            }

            band[2].Text = "治疗申请";
            medicalAssay = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(HIS.MZDoc_BLL.Public.MedicalApplyType.医技治疗申请);
            list = medicalAssay.LoadMedicalClass();
            if (list != null)
            {
                band[2].Items = new FormSite.NavigationItem[list.Count];
                for (int index = 0; index < list.Count; index++)
                {
                    band[2].Items[index].Text = list[index].Name;
                    band[2].Items[index].Value = list[index].Id;
                    band[2].Items[index].FormatXmlDocument = list[index].PrintType;
                }
            }
            FormSite.FormatSiteControl control = new FormSite.FormatSiteControl(band);
            control.Dock = DockStyle.Fill;
            control.SaveButtonClick += new EventHandler(Control_SaveButtonClick);
            control.CloseButtonClick += new EventHandler(Control_CloseButtonClick);
            control.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.plBaseWorkArea.Controls.Add(control);
        }

        void Control_CloseButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        void Control_SaveButtonClick(object sender, EventArgs e)
        {
            FormSite.NavigationItem item = (FormSite.NavigationItem)sender;
            HIS.DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(null);
            mzdoc_dal.SaveMedicalClass(item.Value,item.FormatXmlDocument);
            MessageBox.Show("保存成功！", "提示");
        }
    }
}
