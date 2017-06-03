using System;
namespace HIS.ZY_BLL.DataModel
{
    public interface IPatientInfo
    {
        string ACCOUNTTYPE { get; set; }
        void Add();
        string ALLERGIC { get; set; }
        string CureNo { get; set; }
        int CureNum { get; set; }
        void Delete();
        string FamilyCode { get; set; }
        string GetCureNo(string PatCode);
        System.Data.DataTable GetNccmPat_LH(HIS.ZY_BLL.ObjectModel.NccmManager.SearchNccmPatType snpt, string values);
        string LinkAddress { get; set; }
        string LinkMan { get; set; }
        string LinkTel { get; set; }
        string MediCard { get; set; }
        HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb { get; set; }
        string PatAddress { get; set; }
        DateTime PatBriDate { get; set; }
        string PatCaseNo { get; set; }
        string PatCode { get; set; }
        string PatGroup { get; set; }
        int PatID { get; set; }
        string PATJOB { get; set; }
        string PatName { get; set; }
        string PatNumber { get; set; }
        string PatSex { get; set; }
        string PatTEL { get; set; }
        string PYM { get; set; }
        void Update();
        string WBM { get; set; }
    }
}
