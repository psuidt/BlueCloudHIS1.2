using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_ZYDocManager.Action
{
    public interface IFrmMediApplyView : IView
    {
        HIS.Model.ZY_PatList BindPatControlData { set; }
        HIS.ZY_BLL.PatFee BindPatFeeControlData { set; }
        HIS.Model.ZY_PatList zy_patlist_get { get; }
        void getDept(DataSet _dataSet);
    }
}
