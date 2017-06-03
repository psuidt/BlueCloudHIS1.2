using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWI.HIS.Windows.Controls;
using HIS.MZ_BLL;

namespace HIS_MZManager.HJSF
{
    public struct SearchCondiction
    {
        public string PatientNameKeyWord;
        public string OutPatientNo;
        public DateTime BeginDate;
        public DateTime EndDate;
    }
    public class FrmOutPatientController
    {
        private IFrmOutPatient formView;

        private DataTable tbDoctorList;

        private DataTable tbDepartment;

        private DataTable tbPatType;

        private DataTable tbWorkUnit;

        private DataTable tbDisease;

        private SearchCondiction condiction;

        /// <summary>
        /// 医生
        /// </summary>
        public DataTable Doctors
        {
            get
            {
                return tbDoctorList;
            }

        }
        /// <summary>
        /// 科室
        /// </summary>
        public DataTable Departments
        {
            get
            {
                return tbDepartment;
            }
        }

        public DataTable PatientType
        {
            get
            {
                return tbPatType;
            }
        }

        public DataTable WorkUnits
        {
            get
            {
                return tbWorkUnit;
            }
        }

        public DataTable Diseases
        {
            get
            {
                return tbDisease;
            }
        }

        public SearchCondiction Condiction
        {
            get
            {
                return condiction;
            }
            set
            {
                condiction = value;
            }
        }

        public FrmOutPatientController( IFrmOutPatient FormView )
        {
            formView = FormView;

            Initialize( );
        }

        public event OnBeforeSaveEventHandle BeforeSaveEvent;

        public bool SavePatient()
        {
            if ( formView.FormAction == 0 )
            {
                if ( BeforeSaveEvent != null )
                {
                    BeforeSaveEventArgs e = new BeforeSaveEventArgs( );
                    BeforeSaveEvent( this , e );
                    if ( e.Cancel )
                        return false;
                }
                //新增病人
                OutPatient outpatient = new OutPatient( );
                outpatient.NewRegister( );
                int patlistId = outpatient.PatListID;
                string visitno = outpatient.VisitNo;
                outpatient = PatientConvert.ConvertPatient( (UIOutPatient)formView.Patient );
                outpatient.PatListID = patlistId;
                outpatient.VisitNo = visitno;
                outpatient.UpdateRegister( );
                formView.Patient = PatientConvert.ConvertPatient( outpatient );


            }
            return true;
        }
        /// <summary>
        /// 查找病人
        /// </summary>
        public void SearchingPatient()
        {
            StringBuilder strWhere = new StringBuilder( );
            strWhere.Append( "CUREDATE between " );
            strWhere.Append( "'"+ condiction.BeginDate.ToString("yyyy-MM-dd") + " 00:00:00'" );
            strWhere.Append( " AND " );
            strWhere.Append( "'" + condiction.EndDate.ToString("yyyy-MM-dd") +  " 23:59:59'" );
            if ( condiction.PatientNameKeyWord.Trim( ) != "" )
                strWhere.Append( " AND PATNAME LIKE '%" + GWI.HIS.Windows.Controls.CommonFun.FormatKeyword(condiction.PatientNameKeyWord) + "%' " );

            if ( condiction.OutPatientNo.Trim( ) != "" )
                strWhere.Append( " AND VISITNO = '" + condiction.OutPatientNo + "'" );

            DataTable tbPatient = OutPatient.GetPatientList( strWhere.ToString() );
            formView.SearchResultList = tbPatient;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()
        {
            if ( formView.FormAction == 2 )
                return;
            
            tbDoctorList = BaseDataController.BaseDataSet[BaseDataCatalog.医生列表];
            
            tbDepartment = BaseDataController.BaseDataSet[BaseDataCatalog.科室列表];
            
            tbPatType = BaseDataController.BaseDataSet[BaseDataCatalog.病人类型列表];
            
            tbWorkUnit = BaseDataController.BaseDataSet[BaseDataCatalog.工作单位列表];
            
            tbDisease = BaseDataController.BaseDataSet[BaseDataCatalog.疾病诊断列表];
            
        }

        public void SetPatient( IOutPatient Patient )
        {
            formView.Patient = Patient;
        }

        public bool SelectedPateint()
        {
            if ( formView.SelectedPatientId != 0 )
            {
                OutPatient patient1 = new OutPatient( formView.SelectedPatientId );
                UIOutPatient patient2 = PatientConvert.ConvertPatient( patient1 );
                SetPatient( patient2 );
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
