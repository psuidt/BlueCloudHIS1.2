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

namespace HIS_ZYManager
{
    public partial class FrmCostTotal : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private User _currentUser;
        private Deptment _currentDept;
        private FilterType _filterType;			//选项卡条件过滤类别
        private SearchType _searchType;
        public FrmCostTotal(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            _filterType = Constant.CustomFilterType;
            _searchType = Constant.CustomSearchType;
            this.Text = chineseName;
        }
    }
}
