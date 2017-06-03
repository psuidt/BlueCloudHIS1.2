using System;
namespace HIS.ZY_BLL.DataModel
{
    public interface IZY_PresOrder
    {
        decimal Amount { get; set; }
        void BackPres(System.Collections.Generic.List<IZY_PresOrder> zyPresOrderList);
        void BackPres(int zypresorderid, IZY_PresOrder zyPresOrder);
        int BigNum { get; set; }
        decimal Buy_Price { get; set; }
        decimal CalculateAllFee(decimal binnum, decimal smallnum, decimal RelationNum, decimal price);
        decimal CalculateAllFee(decimal Allnum, decimal RelationNum, decimal price);
        void ChangePresDoc(int PresOrderID, string PresDocCode);
        int Charge_Flag { get; set; }
        string ChargeCode { get; set; }
        void ChargePres(System.Collections.Generic.List<int> zyPresOrderList, System.Collections.Generic.List<string> prestype, System.Collections.Generic.List<string> ChargeCodeL, System.Collections.Generic.List<DateTime> CoatdateL);
        bool CheckBackPres(out decimal resultfee, out decimal arithmetical_compliment);
        void ClearPatPresData(int patListID);
        object Clone();
        decimal Comp_Money { get; set; }
        int Cost_Flag { get; set; }
        DateTime CostDate { get; set; }
        int CostMasterID { get; set; }
        string CostName { get; set; }
        void DelComp(int[] PRESORDERID);
        int Delete_Flag { get; set; }
        void DelPres();
        string DeptName { get; set; }
        string DocName { get; set; }
        int Drug_Flag { get; set; }
        string ExecDept { get; set; }
        string ExecDeptCode { get; set; }
        string GetFPXM_Code(string itemType);
        System.Data.DataTable GetNotSendDurgPresDataTable();
        decimal GetPresAllFee(DateTime PresDate, int PresType);
        System.Data.DataTable GetPresDataTable();
        System.Data.DataTable GetPresDataTable(DateTime? Bdate, DateTime? Edate, string presType, string DrugName);
        System.Data.DataTable GetPresDataTable(DateTime? Bdate, DateTime? Edate, string DrugName);
        System.Data.DataTable GetPresDataTable(DateTime date, int prestype);
        System.Data.DataTable GetPresDataTable(DateTime date);
        System.Data.DataTable GetPresDataTableOld();
        System.Data.DataTable GetPresTemplateData(int Template_ID);
        System.Data.DataTable GetSendGrugPres(int patlistid, string deptcode);
        System.Data.DataTable GetSendGrugPres(string CureNo, string deptcode);
        decimal GetSendGrugPresTotalFee(int patlistid, string deptcode);
        int group_id { get; set; }
        int ItemID { get; set; }
        string ItemName { get; set; }
        string ItemType { get; set; }
        System.Data.DataTable LoadAllData();
        void LoadData();
        System.Data.DataTable LoadDrugData(string deptcode);
        System.Data.DataTable LoadDrugData();
        System.Data.DataTable LoadItemData();
        DateTime MarkDate { get; set; }
        string NCMS_CODE { get; set; }
        int OldID { get; set; }
        HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb { get; set; }
        int Order_Flag { get; set; }
        int order_id { get; set; }
        int order_type { get; set; }
        string PackUnit { get; set; }
        int PassID { get; set; }
        int PatID { get; set; }
        int PatListID { get; set; }
        int PresAmount { get; set; }
        long PRESCDETAILNO { get; set; }
        long PRESCNO { get; set; }
        DateTime PresDate { get; set; }
        string PresDeptCode { get; set; }
        string PresDocCode { get; set; }
        int PresMasterID { get; set; }
        int PresOrderID { get; set; }
        string PresType { get; set; }
        int Record_Flag { get; set; }
        decimal RelationNum { get; set; }
        int rowno { get; set; }
        void SavePres(System.Collections.Generic.List<IZY_PresOrder> zyPresOrderList);
        decimal Sell_Price { get; set; }
        decimal SmallNum { get; set; }
        string Standard { get; set; }
        decimal Tolal_Fee { get; set; }
        string Unit { get; set; }
        void UpdateComp(int[] PRESORDERID);
        bool XD { get; set; }
    }
}
