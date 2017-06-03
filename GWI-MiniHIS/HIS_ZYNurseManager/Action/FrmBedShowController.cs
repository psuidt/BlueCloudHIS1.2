using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_ZYNurseManager.Action
{
    public class FrmBedShowController
    {
        private IFrmBedShowView view;
        private User user;
        private Deptment dept;
        private DataSet ds;
        private DataTable dt;
        

        public FrmBedShowController(IFrmBedShowView _view)
        {
            view = _view;
            ds= new DataSet();
            user = view.currentUser;
            dept = view.currentDept;
            LoadBedInfo();            
          
        }

        private void LoadBedInfo()
        {   
           
        }
    }
}
