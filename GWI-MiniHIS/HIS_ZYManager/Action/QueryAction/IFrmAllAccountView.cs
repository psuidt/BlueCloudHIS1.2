using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using GWMHIS.BussinessLogicLayer.Classes;
using HIS.ZY_BLL.ObjectModel.AccountManager;
using System.Windows.Forms;

namespace HIS_ZYManager.Action
{

    //zenghao [20100506.1.01]
    public interface IFrmAllAccountView
    {
        User currentUser { get; }
        Deptment currentDept { get; }

        DateTime BeginDate { get; }
        DateTime EndDate { get; }

        AbstractAllAccount Data { set; }

        TreeNode treenode { set; }

        DataTable Workers { set; }

        long Worker { get; }
    }
}
