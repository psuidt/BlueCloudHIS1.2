using System;
namespace HIS.ZY_BLL.DataModel
{
    public interface IZY_PatList
    {
        string BedCode { get; set; }
        BindPatListType bindPatListType { get; set; }
        BindPatListVal bindPatListVal { get; set; }
        DateTime CureDate { get; set; }
        string CureDeptCode { get; set; }
        string CureDocCode { get; set; }
        string CureNo { get; set; }
        string CureState { get; set; }
        string CurrDeptCode { get; set; }
        string DiseaseCode { get; set; }
        string DiseaseName { get; set; }
        DateTime MarkDate { get; set; }
        string MarkEmpCode { get; set; }
        string Nccm_NO { get; set; }
        string OriginDeptCode { get; set; }
        string OriginDocCode { get; set; }
        int Out_Flag { get; set; }
        DateTime OutDate { get; set; }
        string OutDiagnCode { get; set; }
        string OutDiagnName { get; set; }
        int PatID { get; set; }
        string PatientCode { get; set; }
        IPatientInfo patientInfo { get; set; }
        int PatListID { get; set; }
        string PatType { get; set; }
        int ReaLiveNum { get; set; }
    }
}
