using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.MZ_BLL;
using HIS.MZ_BLL.Exceptions;

namespace HIS_MZManager
{

    public interface IFrmMzgh
    {
        HIS.MZ_BLL.RegPatient Patient
        {
            get;
            set;
        }
        DataTable RegisterList
        {
            get;
            set;
        }
        DataTable RegDeptList
        {
            //get;
            set;

        }
        DataTable RegTypeList
        {
            //get;
            set;
        }
        DataTable RegDoctor
        {
            //get;
            set;
        }
        int OperatorId
        {
            get;
        }
        string OperatorName
        {
            get;
        }
        bool ShowRegInfo();
        string ShowForm( out string PerfChar);
        void ShowCurrentRegisterInvoiceNo(string currentInvoiceNo);
    }
    /// <summary>
    /// 门诊挂号界面控制器
    /// </summary>
    public class FrmMzghController
    {
        public DataTable tbRegDept;
        public DataTable tbRegDoc;
        public DataTable tbRegType;
        public DataTable tbFolkList;

        private DataTable patientTypeList;

        public DataTable PatientTypeList
        {
            get
            {
                return patientTypeList;
            }
        }
        private IFrmMzgh view;
        private bool showAllPatient;


        public FrmMzghController(IFrmMzgh View )
        {
            view = View;
            //获取可挂号的科室(条件：临床并且是门诊的有效科室)
            tbRegDept = BaseDataController.BaseDataSet[BaseDataCatalog.科室列表].Select( "TYPE_CODE IN ('001') AND MZ_FLAG = 1 AND DELETED = 0" ).CopyToDataTable();
            //得到医生列表
            DataTable tbDoctorTmp = BaseDataController.BaseDataSet[BaseDataCatalog.医生列表];
            tbRegDoc = new DataTable();
            tbRegDoc.Columns.Add( "EMPLOYEE_ID" );
            tbRegDoc.Columns.Add( "EMP_NAME" );
            tbRegDoc.Columns.Add( "PY_CODE" );
            tbRegDoc.Columns.Add( "WB_CODE" );
            tbRegDoc.Columns.Add( "YS_TYPENAME" );
            for ( int i = 0; i < tbDoctorTmp.Rows.Count; i++ )
            {
                int employee_id = Convert.ToInt32( tbDoctorTmp.Rows[i]["EMPLOYEE_ID"] );
                if ( tbRegDoc.Select( "EMPLOYEE_ID = " + employee_id ).Length == 0 )
                {
                    DataRow dr = tbRegDoc.NewRow();
                    dr["EMPLOYEE_ID"] = tbDoctorTmp.Rows[i]["EMPLOYEE_ID"];
                    dr["EMP_NAME"] = tbDoctorTmp.Rows[i]["EMP_NAME"];
                    dr["PY_CODE"] = tbDoctorTmp.Rows[i]["PY_CODE"];
                    dr["WB_CODE"] = tbDoctorTmp.Rows[i]["WB_CODE"];
                    dr["YS_TYPENAME"] = tbDoctorTmp.Rows[i]["YS_TYPENAME"];
                    tbRegDoc.Rows.Add( dr );
                }
            }

            tbRegType = BaseDataController.BaseDataSet[BaseDataCatalog.挂号类型定义列表].Select( "VALID_FLAG=1" ).CopyToDataTable();
            
            tbFolkList = BaseDataController.BaseDataSet[BaseDataCatalog.名族列表];
            
            patientTypeList = BaseDataController.BaseDataSet[BaseDataCatalog.病人类型列表];
        }

        public void InitViewData()
        {
            view.RegDeptList = tbRegDept;
            view.RegTypeList = tbRegType;
            view.RegDoctor = tbRegDoc;

        }
        /// <summary>
        /// 挂号处理
        /// </summary>
        public bool ProcessRegister()
        {
            HIS.MZ_BLL.RegController regController = new HIS.MZ_BLL.RegController();
            regController.OperatorId = view.OperatorId;
            regController.OperatorName = view.OperatorName;
            try
            {
                ValidData();

                if ( regController.BudgetProcess( view.Patient ) )
                {
                    if ( view.ShowRegInfo() )
                    {
                        if ( regController.RegisterPrecess( view.Patient ) )
                        {
                            HIS.MZ_BLL.RegisterInvoice invoice = new RegisterInvoice();
                            invoice.FindRegDetail(view.Patient);
                            invoice.ChargeUserName = view.OperatorName;
                            invoice.DocType = view.Patient.RegTypeName;
                            invoice.RegNo = view.Patient.VisitNo;
                            invoice.RegDeptName = view.Patient.RegDeptName;
                            invoice.TotalFee = view.Patient.RegFeeInfo.TotalFee;
                            invoice.PatName = view.Patient.PatientName;
                            PrintController.PrintRegisterVoice(invoice);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch(Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 退号处理
        /// </summary>
        public bool CancelRegister()
        {
            string perfChar = "";
            string invoiceNo = view.ShowForm(out perfChar);

            if ( invoiceNo.Trim() == "" )
                return false;

            HIS.MZ_BLL.RegController regController = new HIS.MZ_BLL.RegController();
            regController.OperatorId = view.OperatorId;
            regController.OperatorName = view.OperatorName;
            try
            {
                return regController.CancelRegister( invoiceNo , perfChar );
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 刷新
        /// </summary>
        public void Refresh()
        {
            HIS.MZ_BLL.RegController regController = new HIS.MZ_BLL.RegController();
            try
            {
                DateTime dateBegin = Convert.ToDateTime(HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime.ToString( "yyyy-MM-dd" ) + " 00:00:00");
                DateTime dateEnd = dateBegin.AddHours( 23 ).AddMinutes( 59 ).AddSeconds( 59 );
                if (!showAllPatient )
                    view.RegisterList = regController.GetRegPatientList( dateBegin , dateEnd , view.OperatorId );
                else
                    view.RegisterList = regController.GetRegPatientList( dateBegin , dateEnd , 0 );
            }
            catch ( Exception err )
            {
                throw err;
            }
        }

        public bool FindPatient(string hisCardNo)
        {
            HIS.MZ_BLL.RegController regController = new HIS.MZ_BLL.RegController();
            regController.OperatorId = view.OperatorId;
            
            HIS.MZ_BLL.RegPatient patient  = regController.GetPatientBaseInfoByHisCardNo( hisCardNo );
            if ( patient == null )
            {
                patient = new HIS.MZ_BLL.RegPatient( );
                view.Patient = patient;
                return false;
            }
            else
            {
                view.Patient = patient;
                view.Patient.ValidCardNo = false;
                return true;
            }
                
            
        }

        private void ValidData()
        {
            if ( view.Patient.PatientName == "" )
                throw new Exception( "病人姓名不能为空！" );
            if ( view.Patient.Sex == "" )
                throw new Exception( "病人性别不能为空！" );
            if ( view.Patient.RegDeptCode == "" )
                throw new Exception( "挂号科室不能为空！" );
            if ( view.Patient.RegTypeCode == "" )
                throw new Exception( "挂号类别不能为空！" );

            if (view.Patient.Allergic.Trim() == "")
            {
                //参数控制了要录入过敏史
                if (Convert.ToInt16(OPDParamter.Parameters["019"]) == 1)
                {
                    throw new Exception("过敏史必须要填写");
                }
            }
        }

        public void ShowCurrentRegisterInvoiceNo()
        {
            HIS.MZ_BLL.OPDBillKind kind = HIS.MZ_BLL.OPDBillKind.门诊挂号发票;
            if ( HIS.MZ_BLL.OPDParamter.Parameters["012"].ToString() == "1" )
                kind = HIS.MZ_BLL.OPDBillKind.门诊收费发票;

            string perfChar = "";
            string invoiceNo = HIS.MZ_BLL.InvoiceManager.GetBillNumber( kind , view.OperatorId , true , out perfChar );
            view.ShowCurrentRegisterInvoiceNo( invoiceNo );
        }

        public void LoadPatintInfoByVisitNo(string visitNo)
        {
            try
            {
                HIS.MZ_BLL.RegController regController = new HIS.MZ_BLL.RegController( );
                RegPatient patient = regController.GetPatientInfoByVisitNo( visitNo );
                view.Patient = patient;
            }
            catch ( OperatorException oe )
            {
                throw new Exception( oe.Message );
            }
            catch 
            {
                throw new Exception( "查找病人信息发生错误！" );
            }
        }

        public bool ShowAllPatient
        {
            get
            {
                return showAllPatient;
            }
            set
            {
                showAllPatient = value;
            }
        }
    }
}
