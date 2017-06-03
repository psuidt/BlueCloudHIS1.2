using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.DataModel;
using System.Data;

namespace HIS_MediInsInterface.Action
{
    //zenghao [20100510.2.01]
    public interface ICostUpdate
    {
        ZY_PatList zyPatList { get; }
        ZY_PatList[] zyPatLists { get; }

        DataTable dgvFee { set; }
        DataTable dgvHisFee { set; }
        DataTable dgvNccmFee { set; }

        string rtbMessage { set; }
        void ClearMessage();
        void brushpatlist();
    }


    public enum UpdateType
    {
        正在单人上传,
        正在多人上传,
        待上传,
        无效
    }
}
