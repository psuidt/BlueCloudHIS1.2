using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MZ_BLL;
using GWI.HIS.Windows.Controls;
using System.Data;
using System.Collections;
using HIS.Interface.Structs;


namespace HIS_MZManager.HJSF
{
    /// <summary>
    /// 预算结算界面控制器
    /// </summary>
    public partial class FrmBudgetBalanceController
    {
        public event OnAfterReadPatientPrescriptionHandler AfterReadPatientPrescription;
        /// <summary>
        /// 删除消息引发的事件
        /// </summary>
        public event OnBeforeDeleteEventHandle BeforeDeleteEvent;
        /// <summary>
        /// 删除后的事件
        /// </summary>
        public event OnAfterDeleteEventHandle AfterDeleteEvent;
        /// <summary>
        /// 在保存后引发的事件
        /// </summary>
        public event OnAfterSavedEventHandle AfterSavedEvent;
        /// <summary>
        /// 在插入行前的事件
        /// </summary>
        public event OnBeforeInsertRowEventHandle BeforeInsertRow;
        /// <summary>
        /// 控制器初始化完成后的事件
        /// </summary>
        public event OnControllerInitalizeEndEnvenHandle ControllerInitalizeEnd;
        /// <summary>
        /// 预算完成事件
        /// </summary>
        public event OnAfterBudgetEndEventHandle AfterBudgetEndEvent;
        /// <summary>
        /// 结算完成事件
        /// </summary>
        public event OnAfterBalanceEndEventHandle AfterBalanceEndEvent;
        /// <summary>
        /// 保存处方前的事件
        /// </summary>
        public event OnBeforeSaveEventHandle BeforeSavePrescriptionEvent;
        /// <summary>
        /// 控制器构造函数
        /// </summary>
        /// <param name="FormView">实现了界面视图接口的对象</param>
        public FrmBudgetBalanceController( IFrmBudgeBalance FormView )
        {
            formView = FormView;

            formView.Prescriptions = formView.GetPrescDataStruct( );
        }
        /// <summary>
        /// 选项卡数据
        /// </summary>
        public DataTable ShowCardData
        {
            get
            {
                return tbShowCardData;
            }
        }
        /// <summary>
        /// 医生列表
        /// </summary>
        public DataTable Doctors
        {
            get
            {
                if ( tbDoctor == null )
                {
                    tbDoctor = new DataTable( );
                    tbDoctor.Columns.Add( "EMPLOYEE_ID" );
                    tbDoctor.Columns.Add( "NAME" );
                    tbDoctor.Columns.Add( "PY_CODE" );
                    tbDoctor.Columns.Add( "WB_CODE" );
                }
                return tbDoctor;
            }
        }
        /// <summary>
        /// 科室列表
        /// </summary>
        public DataTable Departments
        {
            get
            {
                if ( tbDepartment == null )
                {
                    tbDepartment = new DataTable( );
                    tbDepartment.Columns.Add( "DEPT_ID" );
                    tbDepartment.Columns.Add( "NAME" );
                    tbDepartment.Columns.Add( "PY_CODE" );
                    tbDepartment.Columns.Add( "WB_CODE" );
                }
                return tbDepartment;
            }
        }


        /// <summary>
        /// 初始化数据
        /// </summary>
        public void Initailze()
        {
            ControllerInitalizeEndArgs e = new ControllerInitalizeEndArgs( );
            //加载数据
            LoadBaseData( );
            //加载收费员发票
            LoadInvoiceInfo( );
            
            prescController = new PrescriptionController( );

            if ( ControllerInitalizeEnd != null )
            {
                ControllerInitalizeEnd( this , e );
            }
        }
        /// <summary>
        /// 加载收费员发票
        /// </summary>
        public void LoadInvoiceInfo()
        {
            if ( formView.FormAction == 0 )
            {
                try
                {
                    string perfChar = "";
                    string currentInvoiceNo = HIS.MZ_BLL.InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票 , formView.CurrentEmployeeId , true , out perfChar );
                    formView.InvoicePerfChar = perfChar;
                    formView.CurrentInvoiceNo = currentInvoiceNo;
                }
                catch ( Exception err )
                {
                    throw err;
                }
            }
        }
        /// <summary>
        /// 重新加载数据
        /// </summary>
        public void ReloadData()
        {
            LoadBaseData( );
        }
        /// <summary>
        /// 查找病人
        /// </summary>
        /// <param name="searchMode">查找模式</param>
        /// <param name="keyWord">检索关键字</param>
        public void SearchPatient( SearchPatientMode searchMode , string keyWord )
        {
            //在此调用业务逻辑层的方法查找到业务病人对象
            OutPatient patient = new OutPatient( );
            //TODO:
            switch ( searchMode )
            {
                case SearchPatientMode.门诊就诊号:
                    patient = new OutPatient( keyWord );
                    break;
                //case SearchPatientMode.挂号收据号:
                //    patient = new OutPatient( keyWord , OPDBillKind.门诊挂号发票 );
                //    break;
                //case SearchPatientMode.收费发票号:
                //    patient = new OutPatient( keyWord , OPDBillKind.门诊收费发票 );
                //    break;
                default:
                    patient = new OutPatient( );
                    break;
            }
            formView.Patient = PatientConvert.ConvertPatient( patient );
            if ( patient.CureEmpCode.Trim( ) != "" )
                formView.PrescDoctorId = Convert.ToInt32( patient.CureEmpCode );
            if ( patient.CureDeptCode.Trim( ) != "" )
                formView.DoctorDeptId = Convert.ToInt32( patient.CureDeptCode );
        }
        /// <summary>
        /// 读取病人未收费的处方
        /// </summary>
        public void ReadPatientNotBalancePrescription(bool afterBalance)
        {
            OutPatient patient = PatientConvert.ConvertPatient( (UIOutPatient)formView.Patient );

            Prescription[] prescriptions = patient.GetPrescriptions( PresStatus.未收费 , true );
            for ( int i = 0 ; i < prescriptions.Length ; i++ )
                prescriptions[i].Selected = true;

            DataTable tbPresc = formView.Prescriptions;

            tbPresc.Rows.Clear( );

            FillPrescData( prescriptions , tbPresc );

            CalculateAllPrescriptionFee( );

            AfterReadPatientPrescriptionArgs e = new AfterReadPatientPrescriptionArgs();
            e.PrescCount = GetPrescriptionAmbitList( ).Rows.Count;
            if ( tbPresc.Select( COL_DOC_PRESDETAIL_ID + " <> 0" ).Length > 0 )
                e.HasDoctorPresc = true;
            else
                e.HasDoctorPresc = false;

            e.AfterBalance = afterBalance;

            if ( AfterReadPatientPrescription != null )
                AfterReadPatientPrescription( this , e );
        }
        /// <summary>
        /// 删除一条处方明细
        /// </summary>
        /// <param name="rowIndex">要删除的明细所在的行索引</param>
        public void DeletePrescriptionDetail( int rowIndex )
        {
            DataTable tbPresc =  (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return;
            int start , end , subtotal;
            GetPrescriptionSectionStartRow( rowIndex , out start , out end , out subtotal );

            if ( start == end )
            {
                //如果处方的开始行等于处方的结束行，说明当前处方只有一条记录，直接调用删除整张处方功能
                DeletePrescription( rowIndex );
            }
            else
            {
                if ( BeforeDeleteEvent != null )
                {
                    //触发删除事件
                    BeforeDeleteEventArgs e1 = new BeforeDeleteEventArgs( );
                    e1.Message = "确认要删除第" + rowIndex + "行的处方明细吗？";
                    BeforeDeleteEvent( this , e1 );
                    if ( e1.Cancel )
                        return;
                }
                int detailId = Convert.ToInt32( tbPresc.Rows[rowIndex][COL_PRESDETAIL_ID] );
                AfterDeleteEventArgs e = new AfterDeleteEventArgs( );
                try
                {
                    if ( detailId > 0 )
                        prescController.DeletePrescriptionDetail( detailId );
                    e.Message = "删除成功！";
                }
                catch(Exception err)
                {
                    e.Cancel = true;
                    e.Message = err.Message;
                }
                if ( AfterDeleteEvent != null )
                    AfterDeleteEvent( this , e );

                tbPresc.Rows.RemoveAt( rowIndex );
            }

        }
        /// <summary>
        /// 删除一张处方
        /// </summary>
        /// <param name="rowIndex">选中的处方所包含的行索引</param>
        public void DeletePrescription( int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return;
            int start , end , subtotal;
            GetPrescriptionSectionStartRow( rowIndex , out start , out end , out subtotal );

            if ( BeforeDeleteEvent != null )
            {
                //触发删除事件
                BeforeDeleteEventArgs e = new BeforeDeleteEventArgs( );
                e.Message = "确认要删除第" + rowIndex + "行的处方吗？";
                BeforeDeleteEvent( this , e );
                if ( e.Cancel )
                    return;
            }
            AfterDeleteEventArgs e2 = new AfterDeleteEventArgs( );
            try
            {
                int presId = Convert.ToInt32( tbPresc.Rows[rowIndex][COL_PRESMASTER_ID] );
                if ( presId > 0 )
                    prescController.DeletePrescription( presId );
                e2.Message = "删除成功！";
            }
            catch(Exception err)
            {
                e2.Cancel = true;
                e2.Message = err.Message;
            }
            if ( AfterDeleteEvent != null )
                AfterDeleteEvent( this , e2 );

            //获得处方张数标志
            int presAmbit = GetAppointedPrescriptionAmbit( rowIndex );
            //得到指定的处方的所有明细
            DataRow[] drsNeedRemove = tbPresc.Select( COL_PRESC_AMBIT + "=" + presAmbit );

            for ( int i = 0 ; i < drsNeedRemove.Length ; i++ )
            {
                tbPresc.Rows.Remove( drsNeedRemove[i] );
            }
        }
        /// <summary>
        /// 填充选择卡选中行的数据到指定的行
        /// </summary>
        /// <param name="SelectedRow">从选项卡选择的行记录</param>
        /// <param name="rowIndex">当前要填充的行</param>
        public void FillSelectedRowData( DataRow SelectedRow , int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            bool isTemplate = Convert.ToInt32( SelectedRow["ISTEMPLATE"] )==1?true:false ;
            if ( !isTemplate )
            {
                _fillSelectedRowData( SelectedRow , rowIndex );
            }
            else
            {
                int _rowIndex = rowIndex;
                DataRow[] drsTemplateDetails = tbTemplateDetail.Select("TEMPLATE_ID=" + Convert.ToInt32(SelectedRow["ITEM_ID"]));
                for ( int i = 0 ; i < drsTemplateDetails.Length ; i++ )
                {
                    int itemId = Convert.ToInt32( drsTemplateDetails[i]["ITEM_ID"] );
                    int complexId = Convert.ToInt32( drsTemplateDetails[i]["COMPLEX_ID"] );
                    string bigitemcode = drsTemplateDetails[i]["BIGITEMCODE"].ToString( ).Trim( );
                    decimal amount = Convert.ToDecimal( drsTemplateDetails[i]["AMOUNT"] );
                    string filter = "ITEM_ID = " + itemId + " AND COMPLEX_ID = " + complexId + " AND STATITEM_CODE = '" + bigitemcode + "'";
                    DataRow[] drItem = tbShowCardData.Select( filter );
                    if ( drItem.Length > 0 )
                    {
                        FillSelectedRowData( drItem[0] , _rowIndex );
                        //填入设置的数量
                        if ( bigitemcode == "01" || bigitemcode == "02" || bigitemcode == "03" )
                        {
                            decimal relationNum = Convert.ToDecimal( tbPresc.Rows[_rowIndex][COL_RELATION_NUM] );
                            decimal packNum,baseNum;
                            string  packUnit,baseUnit;
                            ConvertDrugAmountToPackNumAndBaseNum( itemId , amount , relationNum ,
                                out packNum , out packUnit , out baseNum , out baseUnit );
                            tbPresc.Rows[_rowIndex][COL_PACK_NUM] = packNum;
                            tbPresc.Rows[_rowIndex][COL_PACK_UNIT] = packUnit;
                            tbPresc.Rows[_rowIndex][COL_BASE_NUM] = baseNum;
                            tbPresc.Rows[_rowIndex][COL_BASE_UNIT] = baseUnit;
                        }
                        else
                        {
                            tbPresc.Rows[_rowIndex][COL_BASE_NUM] = amount;
                        }
                        CalculateRowTotalFee( _rowIndex );
                        //插入新的行
                        _rowIndex = _rowIndex + 1;
                        AddEmptyPrescriptionDetail( _rowIndex );

                    }
                }
            }

        }
        /// <summary>
        /// 结束处方
        /// </summary>
        public void EndPrescription()
        {
            //查找未结束的处方
            DataTable tbPresc = (DataTable)formView.Prescriptions;

            DataTable tbAmbit = GetPrescriptionAmbitList( );
            int notEndPrescAmbit = 0;//保存未结束的处方的处方张数标志
            for ( int i = 0 ; i < tbAmbit.Rows.Count ; i++ )
            {
                int ambit = Convert.ToInt32( tbAmbit.Rows[i][COL_PRESC_AMBIT] );
                DataRow[] drs = tbPresc.Select( COL_PRESC_AMBIT + "=" + ambit );
                bool prescEnd = false;
                for ( int j = 0 ; j < drs.Length ; j++ )
                {
                    int subtotal_flag = Convert.ToInt32( drs[j][COL_SUB_TOTAL_FLAG] );
                    if ( subtotal_flag == 1 )
                    {
                        prescEnd = true;
                        break;
                    }
                }
                if ( prescEnd == false )
                {
                    notEndPrescAmbit = ambit;
                    break;
                }
            }
            //处理未结束的处方
            if ( notEndPrescAmbit != 0 )
            {
                DataRow[] drNotEndPresc = tbPresc.Select( COL_PRESC_AMBIT + "=" + notEndPrescAmbit );
                for ( int i = 0 ; i < drNotEndPresc.Length ; i++ )
                {
                    //移除掉无效的行
                    if ( Convert.ToInt32( drNotEndPresc[i][COL_ITEM_ID] ) == 0 )
                        tbPresc.Rows.Remove( drNotEndPresc[i] );
                }
                drNotEndPresc = tbPresc.Select( COL_PRESC_AMBIT + "=" + notEndPrescAmbit );
                if ( drNotEndPresc.Length > 0 )
                {
                    int lastIndex = tbPresc.Rows.IndexOf( drNotEndPresc[drNotEndPresc.Length - 1] );
                    DataRow drSubTotal = tbPresc.NewRow( );
                    drSubTotal[COL_EXEC_DEPT_NAME] = "小  计";
                    drSubTotal[COL_SELL_PRICE] = DBNull.Value;
                    drSubTotal[COL_PACK_NUM] = DBNull.Value;
                    drSubTotal[COL_BASE_NUM] = DBNull.Value;
                    drSubTotal[COL_SUB_TOTAL_FLAG] = (short)1;
                    drSubTotal[COL_PRESC_AMBIT] = notEndPrescAmbit;
                    tbPresc.Rows.InsertAt( drSubTotal , lastIndex + 1 );

                    CalculatePrescriptionFee( lastIndex );
                }
            }
        }
        /// <summary>
        /// 在指定位置增加空的明细行
        /// </summary>
        /// <param name="destRowIndex">目的行索引</param>
        public void AddEmptyPrescriptionDetail( int destRowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            DataRow dr = tbPresc.NewRow( );

            dr[COL_PRESNO] = DBNull.Value;
            dr[COL_KEYWORD] = "";
            dr[COL_ITEM_NAME] = "";
            dr[COL_ITEM_UNIT] = "";
            dr[COL_STANDARD] = "";
            dr[COL_SELL_PRICE] = "0.00";
            dr[COL_PACK_NUM] = 0;
            dr[COL_PACK_UNIT] = "";
            dr[COL_BASE_NUM] = 0;
            dr[COL_BASE_UNIT] = "";
            dr[COL_PRES_DOSAGE] = 1;
            dr[COL_PRES_DOC_NAME] = "";
            dr[COL_EXEC_DEPT_NAME] = "";
            dr[COL_TOTAL_FEE] = 0;
            dr[COL_SELECTED_FLAG] = true;

            dr[COL_PRESMASTER_ID] = 0;
            dr[COL_PRESDETAIL_ID] = 0;
            dr[COL_PRESC_TYPE] = "";
            dr[COL_ITEM_ID] = 0;
            dr[COL_COMPLEX_ID] = 0;
            dr[COL_BUY_PRICE] = 0;
            dr[COL_RELATION_NUM] = 0;
            dr[COL_PRES_DOC_ID] = 0;
            dr[COL_PRES_DEPT_ID] = 0;
            dr[COL_EXEC_DEPT_ID] = 0;
            dr[COL_DOC_PRESMASTER_ID] = 0;
            dr[COL_BIGITEMCODE] = "";
            dr[COL_MODIFY_FLAG] = 1;
            dr[COL_SUB_TOTAL_FLAG] = 0;
            //tbPresc.Rows.Add( dr );
            tbPresc.Rows.InsertAt( dr , destRowIndex );
            dr[COL_PRESC_AMBIT] = GetPrescriptionAmbitAfterInsertEmptyRow( tbPresc.Rows.IndexOf( dr ) );
            int start , end , subTotalRow;
            GetPrescriptionSectionStartRow( destRowIndex , out start , out end , out subTotalRow );
            if ( start == end )
            {
                dr[COL_PRESNO] = GetMaxAmbit();
            }
        }
        /// <summary>
        /// 计算指定行的金额
        /// </summary>
        /// <param name="rowIndex"></param>
        public void CalculateRowTotalFee( int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return;
            //得到行合计
            tbPresc.Rows[rowIndex][COL_TOTAL_FEE] = _calculateRowTotalFee( rowIndex );
            //重新计算当前处方合计
            CalculatePrescriptionFee( rowIndex );
            //重新计算所有处方总金额
            CalculateAllPrescriptionFee( );
        }
        /// <summary>
        /// 计算指定行处的处方的总金额
        /// </summary>
        /// <param name="rowIndex"></param>
        public void CalculatePrescriptionFee( int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return;

            int start , end , subRowTotal;

            GetPrescriptionSectionStartRow( rowIndex , out start , out end , out  subRowTotal );

            if ( subRowTotal != -1 )
            {
                tbPresc.Rows[subRowTotal][COL_TOTAL_FEE] = _calculatePrescriptionFee(rowIndex);
            }
        }
        /// <summary>
        /// 计算所有处方的总金额
        /// </summary>
        /// <returns></returns>
        public void CalculateAllPrescriptionFee()
        { 
            formView.AllPrescriptionTotalFee = _calculateAllPrescriptionFee();
        }
        /// <summary>
        /// 保存处方
        /// </summary>
        public bool SavePrescription()
        {
            DataTable tbPresc = formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return false;

            if ( BeforeSavePrescriptionEvent != null )
            {
                BeforeSaveEventArgs be = new BeforeSaveEventArgs( );
                BeforeSavePrescriptionEvent( this , be );

                if ( be.Cancel == true )
                    return false;
            }

            OutPatient patient = PatientConvert.ConvertPatient( (UIOutPatient)formView.Patient );
            DataTable tbAmbit = GetPrescriptionAmbitList( );
            Prescription[] prescriptions = GetPrescriptionsFromDataTable();
            AfterSavedEventArgs e = new AfterSavedEventArgs( );
            try
            {
                bool success = prescController.SavePrescription( patient , prescriptions );
                if ( success )
                {
                    FillPrescData( prescriptions , tbPresc );
                }
            }
            catch(Exception err)
            {
                e.Cancel = true ;
                e.Message = err.Message;
                return false;
            }


            if ( AfterSavedEvent != null )
                AfterSavedEvent( this , e );

            return true;
        }
        /// <summary>
        /// 预算
        /// </summary>
        public void Budget()
        {
            OutPatient patient = PatientConvert.ConvertPatient( (UIOutPatient)formView.Patient );

            Prescription[] prescriptions = GetPrescriptionsFromDataTable();

            List<Prescription> lstPrescription = new List<Prescription>( );
            for ( int i = 0 ; i < prescriptions.Length ; i++ )
            {
                if ( prescriptions[i].Selected )
                    lstPrescription.Add( prescriptions[i] );
            }
            prescriptions = lstPrescription.ToArray( );
            
            HIS.MZ_BLL.ChargeControl chargeController = new ChargeControl( patient , formView.CurrentEmployeeId );

            AfterBudgetEndArgs e = new AfterBudgetEndArgs( );
            e.ChargeController = chargeController;
            try
            {
                ChargeInfo[] chargeInfos = chargeController.Budget( prescriptions );
                e.BudgetInfos = chargeInfos;
                ChargeInfo chargeInfo = new ChargeInfo( );
                for ( int i = 0 ; i < chargeInfos.Length ; i++ )
                {
                    chargeInfo.TotalFee += chargeInfos[i].TotalFee;
                    chargeInfo.FavorFee += chargeInfos[i].FavorFee;
                    chargeInfo.SelfFee += chargeInfos[i].SelfFee;
                    chargeInfo.VillageFee += chargeInfos[i].VillageFee;
                }
                e.TotalBugetInfo = chargeInfo;
                e.Prescriptions = prescriptions;
                e.Success = true;
            }
            catch ( Exception err )
            {
                e.Success = false;
                e.Message = err.Message;
            }

            if ( AfterBudgetEndEvent != null )
                AfterBudgetEndEvent( this , e );
        }
        /// <summary>
        /// 结算
        /// </summary>
        /// <param name="e">预算的消息参数</param>
        public void Balance( AfterBudgetEndArgs e )
        {
            Invoice[] invoicies;
            ChargeInfo[] chargeInfos = e.BudgetInfos;
            AfterBalanceEndArgs even = new AfterBalanceEndArgs( );
            try
            {
                bool ret = e.ChargeController.Charge( chargeInfos , e.Prescriptions , out invoicies );
                even.Success = ret;
                even.Invoices = invoicies;
                even.BalanceInfo = e.TotalBugetInfo;
            }
            catch ( Exception err )
            {
                even.Success = false;
                even.Cancel = true;
                even.Message = err.Message;
            }
            

            if ( AfterBalanceEndEvent != null )
                AfterBalanceEndEvent( this , even );

            try
            {
                string perfChar = "";
                string currentInvoiceNo = HIS.MZ_BLL.InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票 , formView.CurrentEmployeeId , true , out perfChar );
                formView.InvoicePerfChar = perfChar;
                formView.CurrentInvoiceNo = currentInvoiceNo;
            }
            catch ( Exception err )
            {
                throw err;
            }
        }
        /// <summary>
        /// 清除当前所有处方信息
        /// </summary>
        public void ClearPrescriptions()
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;

            tbPresc.Rows.Clear( );
        }
        /// <summary>
        /// 设置处方医生和处方科室使之为当前行所在的处方的处方医生
        /// </summary>
        /// <param name="rowIndex"></param>
        public void SetPrescriptionDoctorInfo( int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return;

            int start , end , subTotalRow;

            GetPrescriptionSectionStartRow( rowIndex , out start , out end , out subTotalRow );
            if ( subTotalRow == -1 )
            {
                if ( start == end )
                {
                    return;
                }
                else
                {
                    for ( int i = start ; i <= end ; i++ )
                    {
                        if ( Convert.ToInt32( tbPresc.Rows[start][COL_ITEM_ID] ) != 0 )
                        {
                            formView.PrescDoctorId = Convert.ToInt32( tbPresc.Rows[i][COL_PRES_DOC_ID] );
                            formView.DoctorDeptId = Convert.ToInt32( tbPresc.Rows[i][COL_PRES_DEPT_ID] );
                            return;
                        }
                    }
                }
            }

            int itemId = Convert.ToInt32( tbPresc.Rows[start][COL_ITEM_ID] );
            if ( itemId == 0 )
                return;
            formView.PrescDoctorId = Convert.ToInt32( tbPresc.Rows[start][COL_PRES_DOC_ID] );
            formView.DoctorDeptId = Convert.ToInt32( tbPresc.Rows[start][COL_PRES_DEPT_ID] );
        }
        /// <summary>
        /// 设置当前行所在的处方的选中状态
        /// </summary>
        /// <param name="rowIndex"></param>
        public void SetPrescriptionSelectedStatus( int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return;

            int start , end , subTotalRow;
            
            GetPrescriptionSectionStartRow( rowIndex , out start , out end , out subTotalRow );

            int presAmbit = Convert.ToInt32( tbPresc.Rows[rowIndex][COL_PRESC_AMBIT] );
            bool currentSelectedStatus = Convert.ToBoolean( tbPresc.Rows[rowIndex][COL_SELECTED_FLAG] );
            if ( currentSelectedStatus == true )
            {
                currentSelectedStatus = false;
            }
            else
            {
                currentSelectedStatus = true;
            }
            DataRow[] drsPresc = tbPresc.Select( COL_PRESC_AMBIT + "=" + presAmbit );
            for ( int i = 0 ; i < drsPresc.Length ; i++ )
                drsPresc[i][COL_SELECTED_FLAG] = currentSelectedStatus;
        }
        /// <summary>
        /// 设置处方付数
        /// </summary>
        /// <param name="rowIndex"></param>
        public void SetPrescriptionDosage( int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return;
            int start , end , subTotalRow;
            GetPrescriptionSectionStartRow( rowIndex , out start , out end , out subTotalRow );

            if ( rowIndex == subTotalRow )
                return;

            string bigitemcode = tbPresc.Rows[rowIndex][COL_BIGITEMCODE].ToString( );
            if ( bigitemcode == "03" )
            {
                decimal dosage = Convert.ToDecimal( tbPresc.Rows[rowIndex][COL_PRES_DOSAGE] );
                for ( int i = start ; i <= end ; i++ )
                {
                    tbPresc.Rows[i][COL_PRES_DOSAGE] = dosage;
                    tbPresc.Rows[i][COL_MODIFY_FLAG] = (short)1;
                    CalculateRowTotalFee( i );
                }
            }
        }
        /// <summary>
        /// 设置修改状态
        /// </summary>
        /// <param name="rowIndex"></param>
        public void SetPrescriptionModifyStatus( int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return;

            tbPresc.Rows[rowIndex][COL_MODIFY_FLAG] = (short)1;
        }
        /// <summary>
        /// 是否允许增加空的明细行
        /// </summary>
        /// <param name="crossRowIndex">参照行，一般为当前所在行</param>
        /// <param name="message">返回不能插入行的原因提示</param>
        /// <returns></returns>
        public bool AllowAddEmptyPrescriptionDetail( int crossRowIndex , out string message )
        {
            message = "";
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return true;

            bool bRet = true;
            BeforeInsertRowArgs e = new BeforeInsertRowArgs( );
            bool isLastRow = ( crossRowIndex == ( tbPresc.Rows.Count - 1 ) ? true : false );
            int subTotalRowFlag = Convert.ToInt32( tbPresc.Rows[crossRowIndex][COL_SUB_TOTAL_FLAG] );
            if ( subTotalRowFlag == 1 )
            {
                message = "小计行不能进行任何操作";
                e.Message = message;
                bRet = false;
            }
            else
            {
                int doctor_presc_id = Convert.ToInt32( tbPresc.Rows[crossRowIndex][COL_DOC_PRESMASTER_ID] );
                if ( doctor_presc_id != 0 )
                {
                    message = "医生处方不允许进行追加，删除行操作！";
                    e.Message = message;
                    e.Cancel = true;
                    bRet= false;
                }

                int itemId = Convert.ToInt32( tbPresc.Rows[crossRowIndex][COL_ITEM_ID] );
                if ( isLastRow && itemId == 0 )
                {
                    message = "最后一行已经是空行";
                    e.Message = message;
                    bRet = false;
                }

                if ( formView.PrescDoctorId == 0 || formView.DoctorDeptId == 0 )
                {
                    message = "新增处方或处方明细前请先指定处方医生";
                    e.Cancel = true;
                    e.Message = message;
                    bRet = false;
                }
                else
                {
                    int start , end , subtotalRow;
                    GetPrescriptionSectionStartRow( crossRowIndex , out start , out end , out  subtotalRow );
                    Hashtable doctorIds = new Hashtable( );
                    int presambit = Convert.ToInt32( tbPresc.Rows[crossRowIndex][COL_PRESC_AMBIT] );
                    DataRow[] drs = tbPresc.Select( COL_PRESC_AMBIT + "=" + presambit + " AND " + COL_SUB_TOTAL_FLAG + "= 0");
                    for ( int i = 0 ; i < drs.Length ; i++ )
                    {
                        int docId = Convert.ToInt32( drs[i][COL_PRES_DOC_ID] );
                        if ( !doctorIds.ContainsKey( docId ) )
                            doctorIds.Add( docId , drs[i][COL_PRES_DOC_NAME].ToString( ).Trim( ) );
                    }
                    if ( doctorIds.Count > 0 )
                    {
                        if ( !doctorIds.ContainsKey( formView.PrescDoctorId ) )
                        {
                            message = "相同处方内处方医生必须一致";
                            e.Cancel = true;
                            e.Message = message;
                            bRet = false;
                        }
                    }
                    
                }
            }
            if ( BeforeInsertRow != null )
            {
                BeforeInsertRow( this , e );
            }
            return bRet;
        }
        /// <summary>
        /// 是否允许增加空的明细行
        /// </summary>
        /// <param name="crossRowIndex">参照行，一般为当前所在行</param>
        /// <param name="message">返回不能插入行的原因提示</param>
        /// <returns></returns>
        public bool AllowAddEmptyPrescriptionDetail( int crossRowIndex )
        {
            string message = "";
            return AllowAddEmptyPrescriptionDetail( crossRowIndex , out message );
        }
        /// <summary>
        /// 是否允许开始对处方进行操作
        /// </summary>
        /// <param name="message">返回不能操作的原因消息</param>
        /// <returns></returns>
        public bool AllowBeginPrescriptionHandle( out string message )
        {
            message = "";
            if ( formView.Patient == null )
            {
                message = "操作处方前请先选择病人。\r\n1、你可以选择需要的查询方式后输入检索码后按Enter进行检索\r\n2、点击查找病人按钮，找到目标病人后确定";
                return false;
            }

            return true;
        }
        /// <summary>
        /// 判断当前行列是否允许编辑
        /// </summary>
        /// <param name="RowIndex">当前行</param>
        /// <param name="ColumnIndex">当前列</param>
        /// <returns></returns>
        public bool AllowCurrentCellEdit( int RowIndex , int ColumnIndex )
        {
            DataTable tbPresc = formView.Prescriptions;
            if ( RowIndex >= tbPresc.Rows.Count )
                return false;

            if ( Convert.ToInt32( tbPresc.Rows[RowIndex][COL_SUB_TOTAL_FLAG] ) == 1 )
            {
                //小计行不能编辑
                return false;
            }
            if ( Convert.ToInt32( tbPresc.Rows[RowIndex][COL_DOC_PRESMASTER_ID] ) != 0 )
            {
                //医生处方不能修改
                return false;
            }
            if ( tbPresc.Columns[ColumnIndex].ColumnName == COL_KEYWORD )
            {
                //检索列可编辑
                return true;
            }

            string columnName = tbPresc.Columns[ColumnIndex].ColumnName;
            if ( columnName == COL_PACK_NUM || columnName == COL_BASE_NUM || columnName == COL_PRES_DOSAGE )
            {
                string bigitemcode = tbPresc.Rows[RowIndex][COL_BIGITEMCODE].ToString( ).Trim( );
                if ( bigitemcode == "03" && columnName == COL_PRES_DOSAGE )
                {
                    //中药处方的付数列可编辑
                    return true;
                }
                else
                {
                    if ( bigitemcode == "01" || bigitemcode == "02" )
                    {
                        if ( columnName == COL_PACK_NUM || columnName == COL_BASE_NUM )
                        {
                            //西药和成药的包装数列和基本数列可编辑
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        //项目类只能修改基本数
                        if ( columnName == COL_BASE_NUM )
                            return true;
                        else
                            return false;
                    }
                }
                
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 是否允许删除处方明细
        /// </summary>
        /// <param name="rowIndex">要删除的明细所在的行索引</param>
        /// <param name="message">不能删除明细行的原因</param>
        /// <returns></returns>
        public bool AllowDeletePrescriptionDetail( int rowIndex , out string message )
        {
            message = "";
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return false;

            int subTotalRowFlag = Convert.ToInt32( tbPresc.Rows[rowIndex][COL_SUB_TOTAL_FLAG] );
            if ( subTotalRowFlag == 1 )
            {
                //小计行不能删除
                message = "小计行不能进行任何操作";
                return false;
            }

            int isDoctorPresc = Convert.ToInt32( tbPresc.Rows[rowIndex][COL_DOC_PRESMASTER_ID] );
            if ( isDoctorPresc != 0 )
            {
                //医生开出的处方不能删除
                message = "医生站开出的处方不能由划价收费操作员删除";
                return false;
            }

            return true;
        }
        /// <summary>
        /// 判断是否为药品明细行
        /// </summary>
        /// <param name="RowIndex">当前行</param>
        /// <param name="IsHerbalMedical">是否中草药(返回值)</param>
        /// <returns>bool</returns>
        public bool IsDurgDetail( int RowIndex , out bool IsHerbalMedical )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            IsHerbalMedical = false;
            if ( RowIndex >= tbPresc.Rows.Count )
                return false;

            if ( Convert.ToInt32( tbPresc.Rows[RowIndex][COL_SUB_TOTAL_FLAG] ) == 0 )
            {
                string bigitemcode = tbPresc.Rows[RowIndex][COL_BIGITEMCODE].ToString( ).Trim( );
                if ( bigitemcode == "01" || bigitemcode == "02" || bigitemcode == "03" )
                {
                    if ( bigitemcode == "03" )
                    {
                        IsHerbalMedical = true;
                    }
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
        /// <summary>
        /// 在填充空行前的约束检查
        /// 原则:
        /// 1、项目和药品不能在同一处方中
        /// 2、如果是项目，执行科室不同不能在同一处方中
        /// 3、西成药与中草药不能在同一处方中
        /// 4、在填充前检查选择的处方医生是否一致
        /// 5、处方医生是否填写
        /// 6、药品要进行0库存判断
        /// </summary>
        /// <param name="SelectedRow">将要填充的选择的行记录</param>
        /// <param name="rowIndex">要填充的行</param>
        /// <param name="message">返回的信息</param>
        /// <returns></returns>
        public bool ValidateRestrictBeforeFillSelectedRowData( DataRow SelectedRow , int rowIndex , out string message )
        {
            message = "";

            DataTable tbPresc = formView.Prescriptions;
            //处方明细空，允许
            if ( tbPresc.Rows.Count == 0 )
                return true;

            string bigitemcode = SelectedRow["STATITEM_CODE"].ToString( ).Trim( );
            string exec_dept_code = SelectedRow["EXEC_DEPT_CODE"].ToString( ).Trim( );

            //约束6:判断0库存
            if ( bigitemcode == "01" || bigitemcode == "02" || bigitemcode == "03" )
            {
                decimal sellprice , buyprice , storevalue;
                if ( !PublicDataReader.StoreExists( Convert.ToInt32( SelectedRow["ITEM_ID"] ) , exec_dept_code , 0 , out sellprice , out buyprice , out storevalue ) )
                {
                    message = "【" + SelectedRow["ITEM_NAME"].ToString().Trim() + "】库存为零。请通知药房及时入库" ;
                    return false;
                }
            }

            int start , end , subtotalrow;
            GetPrescriptionSectionStartRow( rowIndex , out start , out end , out subtotalrow );

            if ( rowIndex == start && start == end )
            {
                //是处方的第一行并且只有处方只有一个空行（新开的处方）
                if ( formView.PrescDoctorId == 0 )
                {
                    message = "没有选择处方医生！";
                    return false;
                }
                return true;
            }
            Hashtable doctorIds = new Hashtable( );
            for ( int i = start ; i <= end ; i++ )
            {
                if ( i == rowIndex )
                    continue;
                int docId = Convert.ToInt32( tbPresc.Rows[i][COL_PRES_DOC_ID] );
                if ( docId != 0 )
                {
                    if ( !doctorIds.ContainsKey( docId ) )
                        doctorIds.Add( docId , tbPresc.Rows[i][COL_PRES_DOC_NAME] );
                }
                
                if ( Convert.ToInt32( tbPresc.Rows[i][COL_ITEM_ID] ) != 0 )
                {
                    string bigitemcode2 = tbPresc.Rows[i][COL_BIGITEMCODE].ToString( ).Trim( );
                    string exec_dept_code2 = tbPresc.Rows[i][COL_EXEC_DEPT_ID].ToString( ).Trim( );

                    bool selectedIsdrug = bigitemcode == "01" || bigitemcode == "02" || bigitemcode == "03";
                    bool detailIsdrug = bigitemcode2 == "01" || bigitemcode2 == "02" || bigitemcode2 == "03";

                    #region 原则1、3判断
                    if ( detailIsdrug && selectedIsdrug )
                    {
                        if ( bigitemcode == "03" && ( bigitemcode2 == "01" || bigitemcode2 == "02" ) )
                        {
                            message = "中草药与西药成药不能开在同一处方！";
                            return false;
                        }
                        else
                        {
                            if ( bigitemcode2 == "03" && ( bigitemcode == "01" || bigitemcode == "02" ) )
                            {
                                message = "中草药与西药成药不能开在同一处方！";
                                return false;
                            }
                        }
                    }
                    else
                    {
                        if ( ( detailIsdrug && !selectedIsdrug ) || ( !detailIsdrug && selectedIsdrug ) )
                        {
                            message = "药品和项目不能开在同一处方！";
                            return false;
                        }
                    }
                    #endregion

                    #region 原则2判断
                    if ( !selectedIsdrug && !detailIsdrug )
                    {
                        if ( exec_dept_code2 != exec_dept_code )
                        {
                            message = "项目的执行科室不同不能开在同一处方！";
                            return false;
                        }
                    }
                    #endregion
                }
            }
            //验证4约束
            if (doctorIds.Count> 0 && !doctorIds.ContainsKey( formView.PrescDoctorId ) )
            {
                message = "当前的处方医生不是指定的医生，同一处方只允许一个医生";
                return false;
            }
            return true;

        }
        /// <summary>
        /// 检查数据正确性
        /// </summary>
        /// <returns></returns>
        public bool CheckDataValidity(out string message)
        {
            message = "";
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
            {
                message = "没有需要保存的处方！";
                return false;
            }

            //1、检查数量是否合法
            DataRow[] drs = tbPresc.Select( COL_SUB_TOTAL_FLAG + "= 0" );
            for ( int i = 0 ; i < drs.Length ; i++ )
            {
                int itemId = Convert.ToInt32( drs[i][COL_ITEM_ID] );
                if ( itemId == 0 )
                    tbPresc.Rows.Remove( drs[i] );
            }
            drs = tbPresc.Select( COL_SUB_TOTAL_FLAG + "= 0" );
            for ( int i = 0 ; i < drs.Length ; i++ )
            {
                string item_name = drs[i][COL_ITEM_NAME].ToString( ).Trim( );
                decimal baseNum = Convert.ToDecimal( drs[i][COL_BASE_NUM] );
                decimal packNum = Convert.ToDecimal( drs[i][COL_PACK_NUM] );
                decimal total_fee = Convert.ToDecimal( drs[i][COL_TOTAL_FEE] );
                decimal price = Convert.ToDecimal( drs[i][COL_SELL_PRICE] );
                int presDoctorId = Convert.ToInt32( drs[i][COL_PRES_DOC_ID] );
                int docDeptId = Convert.ToInt32( drs[i][COL_PRES_DEPT_ID] );
                
                if ( presDoctorId == 0 )
                {
                    message = "【" + item_name + "】处方医生填写不正确！";
                    return false;
                }
                if ( docDeptId == 0 )
                {
                    message = "【" + item_name + "】医生科室填写不正确";
                    return false;
                }
                if ( price <= 0 )
                {
                    message = "【" + item_name + "】价格设置不正确!,请联系管理员";
                    return false;
                }
                if ( baseNum <= 0 && packNum <= 0 )
                {
                    message = "【" + item_name + "】数量填写不正确！";
                    return false;
                }
                if ( total_fee <= 0 )
                {
                    message = "【" + item_name + "】合计金额不正确，请检查数量是否填写正确";
                    return false;
                }
            }
            drs = tbPresc.Select( COL_SUB_TOTAL_FLAG + "= 1" );
            for ( int i = 0 ; i < drs.Length ; i++ )
            {
                if ( Convert.ToDecimal( drs[i][COL_TOTAL_FEE] ) <= 0 )
                {
                    message = "有处方小计为0的处方！";
                    return false;
                }
            }
            return true;
        }
    }
}
