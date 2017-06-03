using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MZ_BLL;
using GWI.HIS.Windows.Controls;
using System.Data;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS_MZManager.HJSF
{
    public class PatientConvert
    {
        private static DataTable tbWorkUnit;

        /// <summary>
        /// 将界面实现接口的病人对象转换为业务病人对象
        /// </summary>
        /// <param name="patient"></param>
        /// <returns></returns>
        public static  OutPatient ConvertPatient( UIOutPatient p )
        {
            OutPatient pat = new OutPatient( );
            HIS.SYSTEM.PubicBaseClasses.Age age = HIS.SYSTEM.PubicBaseClasses.XcDate.DateToAge( p.BordDay );
            pat.Age = age.AgeNum;
            pat.AgeUnit = age.Unit.ToString( );
            pat.BornDate = p.BordDay;
            pat.CureDate = p.RegDate == null ? DateTime.Now : p.RegDate.Value;
            pat.CureDeptCode = p.CureDepartment.Value.Code.ToString( );
            pat.CureEmpCode = p.CureDoctor.Value.Code.ToString( );
            pat.DiseaseCode = p.Disease == null ? "" : p.Disease.Value.Code.ToString( );
            pat.DiseaseMemo = "";
            pat.DiseaseName = p.Disease == null ? "" : p.Disease.Value.Text;
            pat.HisCardNo = p.CardNo;
            pat.HpCode = p.WorkUnit.Value.Code == null ? "" : p.WorkUnit.Value.Code.ToString( );
            pat.HpGrade = pat.AgeUnit;
            pat.MediCard = p.CardNo;
            pat.MediType = p.PatientType.Value.Code.ToString( );
            pat.PatID = p.PatId;
            pat.PatListID = p.PatListId;
            pat.PatientName = p.PatientName;
            string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( p.PatientName );
            pat.PYM = pywb[0];
            pat.Sex = p.Sex;
            pat.WBM = pywb[1];

            return pat;
        }
        public static UIOutPatient ConvertPatient( OutPatient p )
        {
            string name = "";
            UIOutPatient pat = new UIOutPatient( );
            Age age = new Age( );
            age.AgeNum = p.Age;
            foreach ( object obj in Enum.GetValues( typeof( AgeUnit ) ) )
            {
                if ( obj.ToString( ) == p.HpGrade )
                {
                    age.Unit = (AgeUnit)obj;
                    break;
                }
            }
            pat.BordDay = XcDate.AgeToDate( age );
            pat.CardNo = p.HisCardNo;
            //name = PublicDataReader.GetDeptNameById( Convert.ToInt32( p.CureDeptCode == "" ? "0" : p.CureDeptCode ) );
            name = BaseDataController.GetName(BaseDataCatalog.科室列表 , Convert.ToInt32( p.CureDeptCode == "" ? "0" : p.CureDeptCode ) );
            pat.CureDepartment = new BindValue( p.CureDeptCode , name );

            //name = PublicDataReader.GetEmployeeNameById( Convert.ToInt32( p.CureEmpCode == "" ? "0" : p.CureEmpCode ) );
            name = BaseDataController.GetName( BaseDataCatalog.人员列表, Convert.ToInt32( p.CureEmpCode == "" ? "0" : p.CureEmpCode ) );
            pat.CureDoctor = new BindValue( p.CureEmpCode , name );

            pat.Disease = new BindValue( p.DiseaseCode , p.DiseaseName );
            pat.OutPatientNo = p.VisitNo;
            pat.PatId = Convert.ToInt32( p.PatID );
            pat.PatientName = p.PatientName;
            //pat.PatientType = new BindValue( p.MediType , PublicDataReader.GetPatientTypeNameByCode( p.MediType ) );
            pat.PatientType = new BindValue( p.MediType, BaseDataController.GetName( BaseDataCatalog.病人类型列表, p.MediType ) );
            pat.PatListId = p.PatListID;
            pat.RegDate = p.CureDate;
            pat.RegDepartment = pat.CureDepartment;
            pat.Sex = p.Sex;

            pat.WorkUnit = new BindValue( p.HpCode , GetWorkUnitNameByCode( p.HpCode ) );



            return pat;
        }

        private static string GetWorkUnitNameByCode( string Code )
        {
            if ( tbWorkUnit == null )
            {
                //tbWorkUnit = PublicDataReader.Get_WorkUnitList( );
                tbWorkUnit = BaseDataController.BaseDataSet[BaseDataCatalog.工作单位列表];
            }

            DataRow[] drs = tbWorkUnit.Select( "CODE='" + Code + "'" );
            if ( drs.Length == 0 )
                return "";
            else
                return drs[0]["NAME"].ToString( ).Trim( );
        }
    }
}
