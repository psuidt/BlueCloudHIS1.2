using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;

namespace HIS_ZYNurseManager
{
    public partial class FrmAssignBed : GWI.HIS.Windows.Controls.BaseMainForm
    {
        public FrmAssignBed(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();           
        }       
     }
}
