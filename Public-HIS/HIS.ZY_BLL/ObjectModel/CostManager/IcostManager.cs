using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.ZY_BLL.DataModel;

namespace HIS.ZY_BLL.ObjectModel.CostManager
{
    public interface IcostManager
    {
        int AccountID { get; set; }
        string ChargeCode { get; set; }
        DateTime CostDate { get; set; }
        int CostMasterID { get; set; }
        string CostType { get; set; }
        string CureNo { get; set; }
        int Delete_Flag { get; set; }
        string DeptName { get; set; }
        decimal Deptosit_Fee { get; set; }
        DateTime Discharge_bdate { get; set; }
        DateTime Discharge_date { get; set; }
        DateTime Discharge_edate { get; set; }
        decimal Favor_Fee { get; set; }
        decimal Money_Fee { get; set; }
        decimal MoreRation_Fee { get; set; }
        string Nccm_NO { get; set; }
        decimal NotWorkUnit_Fee { get; set; }
        int Ntype { get; set; }
        int OldID { get; set; }
        HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb { get; set; }
        int PatID { get; set; }
        int PatListID { get; set; }
        string PatName { get; set; }
        string PatType { get; set; }
        decimal Pos_Fee { get; set; }
        decimal Ration_Fee { get; set; }
        decimal Reality_Fee { get; set; }
        int Record_Flag { get; set; }
        decimal Self_Fee { get; set; }
        decimal SelfDrug_Fee { get; set; }
        int Ticket_Flag { get; set; }
        string TicketCode { get; set; }
        string TicketNum { get; set; }
        decimal Total_Fee { get; set; }
        string UserName { get; set; }
        decimal Village_Fee { get; set; }
        int Village_Type { get; set; }
        string WorkUnit { get; set; }
        decimal WorkUnit_Fee { get; set; }

        PatFee GetPatFee();
        PatFee GetPatFee(DateTime costdate);
        bool ClearPatData(int PatListID);

        ZY_CostMaster GetCostMaster(int patlistid);
    }
}
