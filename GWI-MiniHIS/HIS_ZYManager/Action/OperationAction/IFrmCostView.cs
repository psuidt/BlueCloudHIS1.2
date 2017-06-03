using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GWMHIS.BussinessLogicLayer.Classes;
using System.Data;
using HIS.ZY_BLL;
using HIS.ZY_BLL.DataModel;

namespace HIS_ZYManager.Action
{
    public enum PrintTicketType
    {
        全额打印 = 1, 只打自费 = 2, 不打发票 = 3
    }

    public enum CostType
    {
        中途结算 = 1, 出院结算 = 2, 欠费结算 = 3
    }

    public interface IFrmCostView
    {
        User currentUser { get; }
        Deptment currentDept { get; }

        PatFee patFee { set; }
        DataTable dgFee { set; }

        string InpatNo { get; set; }
        string selfDrugFee { get; set; }

        ZY_PatList zyPatList { get; set; }
        /// <summary>
        /// 清空界面数据
        /// </summary>
        void BrushPatList();
        /// <summary>
        /// 更改病人数据
        /// </summary>
        void ChargePatData();
        /// <summary>
        /// 打印发票
        /// </summary>
        /// <param name="CostMasterID">结算ID</param>
        void CostPrint(int CostMasterID);
    }

    public interface IFrmCostDiagView
    {
        void Initialize(DataSet _dataSet);

        bool GroupBoxEnabled { set; }
        bool tbFeeEnabled { set; }
        bool tbPosEnabled { set; }
        bool tbExtraEnabled { set; }

        string LabTitle { set; }

        ZY_PatList zyPatList { get; set; }
        PatFee patFee { set; }

        decimal tbFee { get; set; }
        decimal tbPos { get; set; }
        decimal tbExtra { get; set; }

        PrintTicketType Ptt { get; }

        string tbTicketNO { get; }

    }
}
