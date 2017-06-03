using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GWMHIS.BussinessLogicLayer.Classes;
using System.Data;

namespace HIS_ZYDocManager.Action
{
   
        public interface IView
        {
            User currentUser { get; }
            Deptment currentDept { get; }
            void Initialize(DataSet _dataSet);

            //HIS.Model.ZY_PatList zy_patlist_get { get; }
            //SearchPatList searchPatList { get; }
            //DataTable cbDept_set { set; }
            //List<HIS.Model.ZY_PatList> lvPatList_set { set; }
        }
  
}
