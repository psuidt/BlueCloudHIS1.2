using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_MZDocManager
{
    public partial class UCMedicalApply : UserControl
    {
        private HIS.MZDoc_BLL.Public.MedicalApplyType _currentType = HIS.MZDoc_BLL.Public.MedicalApplyType.医技检查申请;
        DataSet _dataSet = new DataSet();

        public UCMedicalApply()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 加载科室数据
        /// </summary>
        public void LoadMedicalDept()
        {
            HIS.MZDoc_BLL.BaseMedical medical = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(_currentType);
            DataTable table = medical.LoadMedicalDept(_dataSet);
            this.cbBMedicalDept.DisplayMember = "dept_name";
            this.cbBMedicalDept.ValueMember = "dept_id";
            this.cbBMedicalDept.DataSource = table;
            if (table != null && table.Rows.Count > 0)
            {
                this.cbBMedicalDept.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 加载项目类型
        /// </summary>
        public void LoadMedicalClass()
        {
            HIS.MZDoc_BLL.BaseMedical medical = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(_currentType);
            DataTable table = medical.LoadMedicalClass(_dataSet, (int)this.cbBMedicalDept.SelectedValue);
            this.cbBMedicalClass.DisplayMember = "medical_class_name";
            this.cbBMedicalClass.ValueMember = "medical_class";
            this.cbBMedicalClass.DataSource = table;
            if (table != null && table.Rows.Count > 0)
            {
                this.cbBMedicalClass.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// 加载医技项目列表
        /// </summary>
        public void LoadMedicalItem()
        {
            HIS.MZDoc_BLL.BaseMedical medical = HIS.MZDoc_BLL.MedicalApplyFactory.CreateMedicalApplyObject(_currentType);
            List<HIS.MZDoc_BLL.Medical_Order_Item> itemlist = (List<HIS.MZDoc_BLL.Medical_Order_Item>)HIS.MZDoc_BLL.Public.Function.DataTableToList<HIS.MZDoc_BLL.Medical_Order_Item>(medical.LoadMedicalItem(_dataSet, (int)this.cbBMedicalDept.SelectedValue, (int)this.cbBMedicalClass.SelectedValue));
            this.chkLBMedicalItem.Items.Clear();
            for (int i = 0; i < itemlist.Count; i++)
            {
                this.chkLBMedicalItem.Items.Add(itemlist[i]);
            }
            this.qTxtMecicalItemQuery.SetSelectionCardDataSource(HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(itemlist));
        }

        private void UCMedicalApply_Load(object sender, EventArgs e)
        {
            //LoadMedicalDept();
        }

        private void cbBMedicalDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMedicalClass();
        }

        private void cbBMedicalClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMedicalItem();
            this.tabPage2.Controls.Clear();
            Control control = new FormSite.FormatPanel(HIS.MZDoc_BLL.OP_MedicalApply.GetMedicalApplyXmlDocument((int)this.cbBMedicalClass.SelectedValue));
            control.Dock = DockStyle.Fill;
            this.tabPage2.Controls.Add(control);
        }

        private void chkLBMedicalItem_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
