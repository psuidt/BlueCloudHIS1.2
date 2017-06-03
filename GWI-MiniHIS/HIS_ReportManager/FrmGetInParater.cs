using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.Report_BLL;
using HIS_ReportManager.Controller;
using GWMHIS.BussinessLogicLayer.Classes;


namespace HIS_ReportManager
{
    public partial class FrmGetInParater:BaseForm
    {
        FrmGetInParaterController controller;
        
        #region 属性
        private List<Paramater> _paralist;
        public List<Paramater> paralist
        {
            get { return _paralist; }
            set { _paralist = value; }
        }
        GWMHIS.BussinessLogicLayer.Classes.User _user;
        private Deptment _dept;
        #endregion
        public FrmGetInParater(List<Paramater> pp,User user,Deptment dept)
        {
            InitializeComponent();            
              _paralist = pp;
              _user = user;
              _dept = dept;
        }
        

        private void FrmGetInParater_Load(object sender, EventArgs e)
        {
            controller = new FrmGetInParaterController(_paralist,-1,_user,_dept);
            controller.propertyPanel = this.plEditControl;
            controller.CreateControls();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           paralist= controller.GetParaValue();
           this.DialogResult = DialogResult.OK;
           
           this.Close();
        }
    }
}
