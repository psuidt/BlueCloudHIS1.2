using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.MZ_BLL;
using System.Data;
using GWI.HIS.Windows.Controls;
using System.Collections;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.Interface;
using HIS.Interface.Structs;

namespace HIS_MZManager.HJSF
{
    public partial class FrmBudgetBalanceController
    {
        #region 列名称常量定义
        private const string COL_BASE_NUM = "COL_BASE_NUM";
        private const string COL_BASE_UNIT = "COL_BASE_UNIT";
        private const string COL_BIGITEMCODE = "COL_BIGITEMCODE";
        private const string COL_BUY_PRICE = "COL_BUY_PRICE";
        private const string COL_COMPLEX_ID = "COL_COMPLEX_ID";
        private const string COL_DOC_PRESMASTER_ID = "COL_DOC_PRESMASTER_ID";
        private const string COL_DOC_PRESDETAIL_ID = "COL_DOC_PRESDETAIL_ID";
        private const string COL_EXEC_DEPT_ID = "COL_EXEC_DEPT_ID";
        private const string COL_EXEC_DEPT_NAME = "COL_EXEC_DEPT_NAME";
        private const string COL_ITEM_ID = "COL_ITEM_ID";
        private const string COL_ITEM_NAME = "COL_ITEM_NAME";
        private const string COL_ITEM_UNIT = "COL_ITEM_UNIT";
        private const string COL_KEYWORD = "COL_KEYWORD";
        private const string COL_MODIFY_FLAG = "COL_MODIFY_FLAG";
        private const string COL_PACK_NUM = "COL_PACK_NUM";
        private const string COL_PACK_UNIT = "COL_PACK_UNIT";
        private const string COL_PRES_DEPT_ID = "COL_PRES_DEPT_ID";
        private const string COL_PRES_DOC_ID = "COL_PRES_DOC_ID";
        private const string COL_PRES_DOC_NAME = "COL_PRES_DOC_NAME";
        private const string COL_PRES_DOSAGE = "COL_PRES_DOSAGE";
        private const string COL_PRESC_TYPE = "COL_PRESC_TYPE";
        private const string COL_PRESDETAIL_ID = "COL_PRESDETAIL_ID";
        private const string COL_PRESMASTER_ID = "COL_PRESMASTER_ID";
        private const string COL_PRESNO = "COL_PRESNO";
        private const string COL_RELATION_NUM = "COL_RELATION_NUM";
        private const string COL_SELECTED_FLAG = "COL_SELECTED_FLAG";
        private const string COL_SELL_PRICE = "COL_SELL_PRICE";
        private const string COL_STANDARD = "COL_STANDARD";
        private const string COL_SUB_TOTAL_FLAG = "COL_SUB_TOTAL_FLAG";
        private const string COL_TOTAL_FEE = "COL_TOTAL_FEE";
        private const string COL_PRESC_AMBIT = "COL_PRESC_AMBIT";
        #endregion

        private IFrmBudgeBalance formView;

        private DataTable tbShowCardData;

        private DataTable tbDoctor;

        private DataTable tbDepartment;

        private DataTable tbTemplateDetail;

        private HIS.MZ_BLL.PrescriptionController prescController;

        /// <summary>
        /// 获取处方起始行信息
        /// </summary>
        /// <param name="currentRowIndex">当前行</param>
        /// <param name="StartRowIndex">当前处方的开始行</param>
        /// <param name="EndRowIndex">当前处方的结束行</param>
        /// <param name="SubTotalRow">当前处方的小计行，如果处方未结束，则小计行为-1</param>
        private void GetPrescriptionSectionStartRow( int currentRowIndex , out int StartRowIndex , out int EndRowIndex , out int SubTotalRow )
        {
            StartRowIndex = -1;
            EndRowIndex = -1;
            SubTotalRow = -1;
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return;
            if ( currentRowIndex >= tbPresc.Rows.Count )
                return;

            //获得当前行所在的处方的处方界限标志
            int presc_ambit = Convert.ToInt16( tbPresc.Rows[currentRowIndex][COL_PRESC_AMBIT] );
            DataRow[] drsSubTotal = tbPresc.Select( COL_PRESC_AMBIT + "=" + presc_ambit + " AND " + COL_SUB_TOTAL_FLAG + "= 1" );
            if ( drsSubTotal.Length > 0 )
                SubTotalRow = tbPresc.Rows.IndexOf( drsSubTotal[0] );

            DataRow[] drsDetail = tbPresc.Select( COL_PRESC_AMBIT + "=" + presc_ambit + " AND " + COL_SUB_TOTAL_FLAG + "= 0" );
            if ( drsDetail.Length > 0 )
            {
                StartRowIndex = tbPresc.Rows.IndexOf( drsDetail[0] );
                EndRowIndex = tbPresc.Rows.IndexOf( drsDetail[drsDetail.Length - 1] );
            }
        }
        /// <summary>
        /// 填充处方数据
        /// </summary>
        /// <param name="prescriptions">要填充的处方,Prescription[]类型的数组</param>
        /// <param name="descTable">填充的目标数据表</param>
        private void FillPrescData( Prescription[] prescriptions , DataTable descTable )
        {
            descTable.Rows.Clear( );

            for ( int presIndex = 0 ; presIndex < prescriptions.Length ; presIndex++ )
            {
                PrescriptionDetail[] details = prescriptions[presIndex].PresDetails;

                for ( int detailIndex = 0 ; detailIndex < details.Length ; detailIndex++ )
                {
                    DataRow dr = descTable.NewRow( );
                    #region 增加明细行
                    if ( detailIndex == 0 )
                    {
                        dr[COL_PRESNO] = presIndex + 1;
                    }
                    decimal pack_num = 0;
                    string pack_unit = "";
                    decimal base_num = details[detailIndex].Amount;
                    string base_unit = details[detailIndex].Unit.Trim();
                    if ( details[detailIndex].BigitemCode == "01" || details[detailIndex].BigitemCode == "02" || details[detailIndex].BigitemCode == "03" )
                    {
                        pack_num = 0;
                        pack_unit = "";
                        base_num = 0;
                        base_unit = "";
                        ConvertDrugAmountToPackNumAndBaseNum( Convert.ToInt32( details[detailIndex].ItemId ) , details[detailIndex].Amount , details[detailIndex].RelationNum ,
                            out pack_num , out pack_unit , out base_num , out base_unit );
                    }
                    dr[COL_KEYWORD] = "";
                    dr[COL_ITEM_NAME] = details[detailIndex].Itemname.Trim();
                    dr[COL_ITEM_UNIT] = details[detailIndex].Unit.Trim();
                    dr[COL_STANDARD] = details[detailIndex].Standard.Trim();
                    dr[COL_SELL_PRICE] = details[detailIndex].Sell_price;
                    dr[COL_PACK_NUM] = pack_num;
                    dr[COL_PACK_UNIT] = pack_unit;
                    dr[COL_BASE_NUM] = base_num;
                    dr[COL_BASE_UNIT] = base_unit;
                    dr[COL_PRES_DOSAGE] = details[detailIndex].PresAmount;
                    dr[COL_PRES_DOC_NAME] =BaseDataController.GetName(BaseDataCatalog.人员列表, Convert.ToInt32( prescriptions[presIndex].PresDocCode ) );
                    dr[COL_EXEC_DEPT_NAME] = BaseDataController.GetName(BaseDataCatalog.科室列表 , Convert.ToInt32( prescriptions[presIndex].ExecDeptCode ) );
                    dr[COL_TOTAL_FEE] = details[detailIndex].Tolal_Fee;
                    dr[COL_SELECTED_FLAG] = prescriptions[presIndex].Selected;
                    dr[COL_PRESMASTER_ID] = prescriptions[presIndex].PrescriptionID;
                    dr[COL_PRESDETAIL_ID] = details[detailIndex].DetailId;
                    dr[COL_PRESC_TYPE] = prescriptions[presIndex].PrescType;
                    dr[COL_ITEM_ID] = details[detailIndex].ItemId;
                    dr[COL_COMPLEX_ID] = details[detailIndex].ComplexId;
                    dr[COL_BUY_PRICE] = details[detailIndex].Buy_price;
                    dr[COL_RELATION_NUM] = details[detailIndex].RelationNum;
                    dr[COL_PRES_DOC_ID] = prescriptions[presIndex].PresDocCode;
                    dr[COL_PRES_DEPT_ID] = prescriptions[presIndex].PresDeptCode;
                    dr[COL_EXEC_DEPT_ID] = prescriptions[presIndex].ExecDeptCode;
                    dr[COL_DOC_PRESMASTER_ID] = prescriptions[presIndex].DocPresId;
                    dr[COL_DOC_PRESDETAIL_ID] = details[detailIndex].DocPrescDetailId;
                    dr[COL_BIGITEMCODE] = details[detailIndex].BigitemCode;
                    dr[COL_MODIFY_FLAG] = (short)0;
                    dr[COL_SUB_TOTAL_FLAG] = (short)0;
                    dr[COL_PRESC_AMBIT] = presIndex + 1;
                    #endregion
                    descTable.Rows.Add( dr );
                }
                #region 增加小计行
                DataRow drSubTotal = descTable.NewRow( );
                drSubTotal[COL_EXEC_DEPT_NAME] = "小  计";
                drSubTotal[COL_SELL_PRICE] = DBNull.Value;
                drSubTotal[COL_PACK_NUM] = DBNull.Value;
                drSubTotal[COL_BASE_NUM] = DBNull.Value;
                drSubTotal[COL_SELECTED_FLAG] = prescriptions[presIndex].Selected;
                drSubTotal[COL_SUB_TOTAL_FLAG] = (short)1;
                drSubTotal[COL_PRESC_AMBIT] = presIndex + 1;
                drSubTotal[COL_TOTAL_FEE] = prescriptions[presIndex].Total_Fee;
                descTable.Rows.Add( drSubTotal );
                drSubTotal[COL_TOTAL_FEE] = _calculatePrescriptionFee( descTable.Rows.IndexOf(drSubTotal));
                #endregion
            }
        }
        /*
            dr[COL_PRESNO] = presIndex+1;
            dr[COL_KEYWORD] = "COL_KEYWORD";
            dr[COL_ITEM_NAME] = "COL_ITEM_NAME";
            dr[COL_ITEM_UNIT] = "COL_ITEM_UNIT";
            dr[COL_STANDARD] = "COL_STANDARD";
            dr[COL_SELL_PRICE] = "COL_SELL_PRICE";
            dr[COL_PACK_NUM] = "COL_PACK_NUM";
            dr[COL_PACK_UNIT] = "COL_PACK_UNIT";
            dr[COL_BASE_NUM ] = "COL_BASE_NUM";
            dr[COL_BASE_UNIT] = "COL_BASE_UNIT";
            dr[COL_PRES_DOSAGE] = "COL_PRES_DOSAGE";
            dr[COL_PRES_DOC_NAME] = "COL_PRES_DOC_NAME";
            dr[COL_EXEC_DEPT_NAME] = "COL_EXEC_DEPT_NAME";
            dr[COL_TOTAL_FEE] = "COL_TOTAL_FEE";
            dr[COL_SELECTED_FLAG] = "COL_SELECTED_FLAG";

            dr[COL_PRESMASTER_ID] = "COL_PRESMASTER_ID";
            dr[COL_PRESDETAIL_ID] = "COL_PRESDETAIL_ID";
            dr[COL_PRESC_TYPE] = "COL_PRESC_TYPE";
            dr[COL_ITEM_ID] = "COL_ITEM_ID";
            dr[COL_COMPLEX_ID] = "COL_COMPLEX_ID";
            dr[COL_BUY_PRICE] = "COL_BUY_PRICE";
            dr[COL_RELATION_NUM] = "COL_RELATION_NUM";
            dr[COL_PRES_DOC_ID] = "COL_PRES_DOC_ID";
            dr[COL_PRES_DEPT_ID] = "COL_PRES_DEPT_ID";
            dr[COL_EXEC_DEPT_ID] = "COL_EXEC_DEPT_ID";
            dr[COL_DOC_PRESMASTER_ID] = "COL_DOC_PRESMASTER_ID";
            dr[COL_BIGITEMCODE] = "COL_BIGITEMCODE";
            dr[COL_MODIFY_FLAG] = "COL_MODIFY_FLAG";
            dr[COL_SUB_TOTAL_FLAG] = "COL_SUB_TOTAL_FLAG";
         */
        /// <summary>
        /// 将药品的基本数量转换为包装数和基本数的描述
        /// </summary>
        /// <param name="DrugId">药品ID</param>
        /// <param name="Amount">最小单位（基本单位）值的药品数量</param>
        /// <param name="RelationNum">包装数与基本数的比例系数</param>
        /// <param name="PackNum">包装数(返回)</param>
        /// <param name="PackUnit">包装单位(返回)</param>
        /// <param name="BaseNum">基本数(返回)</param>
        /// <param name="BaseUnit">基本单位(返回)</param>
        private void ConvertDrugAmountToPackNumAndBaseNum( int DrugId , decimal Amount , decimal RelationNum , out decimal PackNum , out string PackUnit ,
                                                                        out decimal BaseNum , out string BaseUnit )
        {
            BaseUnit = "";
            BaseNum = 0;
            PackUnit = "";
            PackNum = 0;
            DataRow[] drBaseItem = tbShowCardData.Select( "isdrug = 1 and item_id=" + DrugId );
            if ( drBaseItem.Length > 0 )
            {
                PackUnit = drBaseItem[0]["item_unit"].ToString( ).Trim( );
                BaseUnit = drBaseItem[0]["base_unit"].ToString( ).Trim( );

                BaseNum = Amount % RelationNum;
                PackNum = ( Amount - BaseNum ) / RelationNum;
            }
        }
        /// <summary>
        /// 将包装数和基本数的描述转换成基本数的描述
        /// </summary>
        /// <returns></returns>
        private decimal ConvertDrugPackNumAndBaseNumToAmount( int DrugId , decimal RelationNum , decimal PackNum , 
                                                                string PackUnit ,decimal BaseNum ,  string BaseUnit )
        {
            //DataRow[] drBaseItem = tbShowCardData.Select( "isdrug = 1 and item_id=" + DrugId );
            //if ( drBaseItem.Length > 0 )
            //{
            return PackNum * RelationNum + BaseNum;
            //}
        }
        /// <summary>
        /// 得到处方张数标志(不判断结束标志位)
        /// </summary>
        /// <returns></returns>
        private DataTable GetPrescriptionAmbitList()
        {
            DataTable tbAmbit = new DataTable( );
            tbAmbit.Columns.Add( COL_PRESC_AMBIT , Type.GetType( "System.Int32" ) );
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            for ( int i = 0 ; i < tbPresc.Rows.Count ; i++ )
            {
                if ( Convert.IsDBNull( tbPresc.Rows[i][COL_PRESC_AMBIT] ) )
                    continue;
                int ambit = Convert.ToInt32( tbPresc.Rows[i][COL_PRESC_AMBIT] );
                if ( tbAmbit.Select( COL_PRESC_AMBIT + "=" + ambit ).Length == 0 )
                {
                    DataRow dr = tbAmbit.NewRow( );
                    dr[COL_PRESC_AMBIT] = ambit;
                    tbAmbit.Rows.Add( dr );
                }
            }
            return tbAmbit;
        }
        /// <summary>
        /// 获取张数标志的最大值
        /// </summary>
        /// <returns></returns>
        private int GetMaxAmbit()
        {
            DataTable tbAmbit = GetPrescriptionAmbitList( );
            object obj = tbAmbit.Compute( "MAX(" + COL_PRESC_AMBIT + ")" , "" );
            if ( obj == null )
                return 0;
            else
                return Convert.ToInt32( obj );

        }
        /// <summary>
        /// 在执行插入空行操作后得到改行的处方张数标志
        /// </summary>
        /// <param name="rowIndex">插入行的行索引</param>
        /// <returns></returns>
        private int GetPrescriptionAmbitAfterInsertEmptyRow( int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( rowIndex >= tbPresc.Rows.Count )
                return 0;
            if ( rowIndex == 0 )
            {
                //如果是第一行，返回1
                return 1;
            }
            else
            {
                if ( Convert.ToInt32( tbPresc.Rows[rowIndex - 1][COL_SUB_TOTAL_FLAG] ) == 1 )
                {
                    //如果上一行是小计行，返回新的标志值
                    int ret = GetMaxAmbit( ) + 1;
                    return ret;
                }
                else
                {
                    //直接返回上一行的标识值
                    return Convert.ToInt32( tbPresc.Rows[rowIndex - 1][COL_PRESC_AMBIT] );
                }
            }
        }
        /// <summary>
        /// 获得指定处方的处方张数标志
        /// </summary>
        /// <param name="AppointedRowIndex">指定的行索引,该索引包含在处方所有的行的索引中</param>
        /// <returns></returns>
        private int GetAppointedPrescriptionAmbit( int AppointedRowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return 0;
            else
                return Convert.ToInt32( tbPresc.Rows[AppointedRowIndex][COL_PRESC_AMBIT] );

        }
        /// <summary>
        /// 计算指定行的金额
        /// </summary>
        /// <param name="rowIndex"></param>
        private decimal _calculateRowTotalFee( int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return 0;
            int start , end , subRowTotal;

            GetPrescriptionSectionStartRow( rowIndex , out start , out end , out  subRowTotal );

            if ( rowIndex == subRowTotal )
                return 0;
            int item_id = Convert.ToInt32( tbPresc.Rows[rowIndex][COL_ITEM_ID] );
            if ( item_id == 0 )
                return 0;

            if ( Convert.IsDBNull( tbPresc.Rows[rowIndex][COL_BASE_NUM] ) )
                tbPresc.Rows[rowIndex][COL_BASE_NUM] = 0;
            if ( Convert.IsDBNull( tbPresc.Rows[rowIndex][COL_PACK_NUM] ) )
                tbPresc.Rows[rowIndex][COL_PACK_NUM] = 0;
            if ( Convert.IsDBNull( tbPresc.Rows[rowIndex][COL_PRES_DOSAGE] ) )
                tbPresc.Rows[rowIndex][COL_PRES_DOSAGE] = 0;

            decimal base_num = Convert.ToDecimal( tbPresc.Rows[rowIndex][COL_BASE_NUM] );
            decimal pack_num = Convert.ToDecimal( tbPresc.Rows[rowIndex][COL_PACK_NUM] );
            decimal relation_num = Convert.ToDecimal( tbPresc.Rows[rowIndex][COL_RELATION_NUM] );
            decimal sell_price = Convert.ToDecimal( tbPresc.Rows[rowIndex][COL_SELL_PRICE] );
            decimal dosage = Convert.ToDecimal( tbPresc.Rows[rowIndex][COL_PRES_DOSAGE] );
            //计算行合计金额
            decimal rowTotal = ( sell_price / relation_num ) * ( ( relation_num * pack_num ) + base_num ) * dosage;
            
            return Decimal.Round( rowTotal , 4 );
            
        }
        /// <summary>
        /// 计算指定行处的处方的总金额
        /// </summary>
        /// <param name="rowIndex"></param>
        private decimal _calculatePrescriptionFee( int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return 0;
            int start , end , subRowTotal;

            GetPrescriptionSectionStartRow( rowIndex , out start , out end , out  subRowTotal );

            //计算当前处方金额
            List<PrescriptionDetail> details = new List<PrescriptionDetail>( );
            for ( int i = start ; i <= end ; i++ )
            {
                if ( Convert.ToInt32( tbPresc.Rows[i][COL_ITEM_ID] ) == 0 )
                    continue;
                PrescriptionDetail detail = new PrescriptionDetail( );
                detail.BigitemCode = tbPresc.Rows[i][COL_BIGITEMCODE].ToString( ).Trim( );
                detail.Tolal_Fee = Convert.ToDecimal( tbPresc.Rows[i][COL_TOTAL_FEE] );
                details.Add( detail );
            }
            Prescription pres = new Prescription( );
            pres.PresDetails = details.ToArray( );
            decimal roundingMoney;
            Hashtable htBigitemItem;
            //decimal prescTotal = BaseDataController.CalculatePrescriptionTotalFee( pres , out htBigitemItem , out roundingMoney );
            List<IPresDetail> lstDetail = new List<IPresDetail>();
            for(int i=0;i<pres.PresDetails.Length;i++)
                lstDetail.Add( pres.PresDetails[i]);


            decimal prescTotal = ( new PrescMoneyCalculate() ).GetPrescriptionTotalMoney( lstDetail, out htBigitemItem, out roundingMoney );
            
            return prescTotal;
        }
        /// <summary>
        /// 计算所有处方的总金额
        /// </summary>
        /// <returns></returns>
        private decimal _calculateAllPrescriptionFee()
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;

            DataTable tbAmbit = GetPrescriptionAmbitList( );

            decimal allPrescFee = 0;

            for ( int i = 0 ; i < tbAmbit.Rows.Count ; i++ )
            {
                DataRow[] drs = tbPresc.Select( COL_PRESC_AMBIT + "=" + tbAmbit.Rows[i][0].ToString( )  );
                if ( Convert.ToBoolean( drs[0][COL_SELECTED_FLAG] ) == false )
                    continue;
                int rowIndex = tbPresc.Rows.IndexOf( drs[0] );

                decimal prescTotalFee = _calculatePrescriptionFee( rowIndex );
                allPrescFee = allPrescFee + prescTotalFee;
            }

            return allPrescFee;
        }
        /// <summary>
        /// 加载基本数据
        /// </summary>
        private void LoadBaseData()
        {
            #region 加载选项卡数据
            int type = 0;
            if ( formView.FormAction == 0 )
                type = 1;
            else
                type = 0;

            tbShowCardData = PublicDataReader.GetItemSelectedCardDataSource( type );
            //窗体行为：0 - 门诊收费 1 - 门诊划价 2 - 药房划价
            if ( formView.FormAction == 2 )
            {
                //移除掉非药品的项目
                DataRow[] drs = tbShowCardData.Select( "ISDRUG=0" );
                for ( int i = 0 ; i < drs.Length ; i++ )
                    tbShowCardData.Rows.Remove( drs[i] );
            }
            #endregion
            //加载医生
            tbDoctor = BaseDataController.BaseDataSet[BaseDataCatalog.医生列表];
            //加载科室
            tbDepartment = BaseDataController.BaseDataSet[BaseDataCatalog.科室列表];
            //加载模板明细
            tbTemplateDetail = BaseDataController.BaseDataSet[BaseDataCatalog.划价模板明细列表];
        }
        /// <summary>
        /// 从数据表返回处方结构
        /// </summary>
        /// <param name="onlySelected">仅返回选中的</param>
        /// <returns></returns>
        private Prescription[] GetPrescriptionsFromDataTable()
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            if ( tbPresc.Rows.Count == 0 )
                return null;

            DataTable tbAmbit = GetPrescriptionAmbitList( );

            List<Prescription> lstPrescriptions = new List<Prescription>( );

            for ( int i = 0 ; i < tbAmbit.Rows.Count ; i++ )
            {
                int ambit = Convert.ToInt32( tbAmbit.Rows[i][0] );
                DataRow[] drsDetail = tbPresc.Select( COL_PRESC_AMBIT + "=" + ambit );
                bool selected = Convert.ToBoolean( drsDetail[0][COL_SELECTED_FLAG] );
                
                Prescription prescription = new Prescription( );
                #region ................
                prescription.Charge_Flag = 0;
                prescription.ChargeCode = "";
                prescription.ChargeID = 0;
                prescription.DocPresId = Convert.ToInt32( drsDetail[0][COL_DOC_PRESMASTER_ID] );
                prescription.Drug_Flag = 0;
                prescription.ExecDeptCode = drsDetail[0][COL_EXEC_DEPT_ID].ToString( );
                prescription.ExecDocCode = "";
                prescription.Modified = false;
                prescription.OldPresID = 0;
                prescription.PatientID = 0;
                prescription.PatientName = formView.Patient.PatientName;
                prescription.PresCostCode = formView.CurrentEmployeeId.ToString( );
                prescription.PrescriptionID = Convert.ToInt32( drsDetail[0][COL_PRESMASTER_ID] );
                prescription.PrescType = drsDetail[0][COL_PRESC_TYPE].ToString( );
                prescription.PresDate = XcDate.ServerDateTime;
                prescription.PresDeptCode = drsDetail[0][COL_PRES_DEPT_ID].ToString( );
                prescription.PresDocCode = drsDetail[0][COL_PRES_DOC_ID].ToString( );
                prescription.Record_Flag = 0;
                prescription.RedeemCost = 0;
                prescription.RegisterID = formView.Patient.PatListId;
                prescription.RoundingMoney = 0;
                prescription.TicketCode = "";
                prescription.TicketNum = "";
                prescription.Total_Fee = _calculatePrescriptionFee( tbPresc.Rows.IndexOf( drsDetail[0]));
                prescription.VisitNo = formView.Patient.OutPatientNo;
                prescription.Selected = selected;
                #endregion
                List<PrescriptionDetail> lstPrescDetail = new List<PrescriptionDetail>( );
                for ( int detailIndex = 0 ; detailIndex < drsDetail.Length ; detailIndex++ )
                {
                    if ( Convert.ToInt32( drsDetail[detailIndex][COL_SUB_TOTAL_FLAG] ) == 1 )
                    {
                        continue;
                    }
                    PrescriptionDetail detail = new PrescriptionDetail( );
                    #region ...................
                    int itemId = Convert.ToInt32( drsDetail[detailIndex][COL_ITEM_ID] );
                    decimal packNum = Convert.ToDecimal(drsDetail[detailIndex][COL_PACK_NUM]);
                    string packUnit = drsDetail[detailIndex][COL_PACK_UNIT].ToString().Trim();
                    decimal baseNum = Convert.ToDecimal( drsDetail[detailIndex][COL_BASE_NUM] );
                    string baseUnit = drsDetail[detailIndex][COL_BASE_UNIT].ToString().Trim();
                    decimal relationNum = Convert.ToDecimal( drsDetail[detailIndex][COL_RELATION_NUM] );
                    string bigitemCode = drsDetail[detailIndex][COL_BIGITEMCODE].ToString( ).Trim( );

                    detail.Amount = ConvertDrugPackNumAndBaseNumToAmount( itemId , relationNum , packNum , packUnit , baseNum , baseUnit );
                    detail.BigitemCode = drsDetail[detailIndex][COL_BIGITEMCODE].ToString( ).Trim( );
                    detail.Buy_price = Convert.ToDecimal( drsDetail[detailIndex][COL_BUY_PRICE] );
                    detail.Comp_Money = 0;
                    detail.ComplexId = Convert.ToInt32( drsDetail[detailIndex][COL_COMPLEX_ID] );
                    detail.DetailId = Convert.ToInt32( drsDetail[detailIndex][COL_PRESDETAIL_ID] );
                    detail.Drug_Flag = 0;
                    detail.ItemId = itemId;
                    detail.Itemname = drsDetail[detailIndex][COL_ITEM_NAME].ToString( ).Trim( );
                    if ( bigitemCode == "01" || bigitemCode == "02" || bigitemCode == "03" )
                        detail.ItemType = bigitemCode;
                    else
                        detail.ItemType = "00";
                    detail.Modified = ( Convert.ToInt32( drsDetail[detailIndex][COL_MODIFY_FLAG] ) == 1 ? true : false );
                    if ( detail.Modified )
                        prescription.Modified = true;
                    detail.Order_Flag = detailIndex + 1;
                    detail.PassId = 0;
                    detail.PresAmount = Convert.ToInt32( drsDetail[detailIndex][COL_PRES_DOSAGE] );
                    detail.PresctionId = Convert.ToInt32( drsDetail[detailIndex][COL_PRESMASTER_ID] );
                    detail.RelationNum = Convert.ToDecimal( drsDetail[detailIndex][COL_RELATION_NUM] );
                    detail.Sell_price = Convert.ToDecimal( drsDetail[detailIndex][COL_SELL_PRICE] );
                    detail.Standard = drsDetail[detailIndex][COL_STANDARD].ToString( ).Trim( );
                    detail.Tolal_Fee = Convert.ToDecimal( drsDetail[detailIndex][COL_TOTAL_FEE] );
                    detail.Unit = drsDetail[detailIndex][COL_ITEM_UNIT].ToString( ).Trim( );
                    detail.DocPrescDetailId = Convert.ToInt32(drsDetail[detailIndex][COL_DOC_PRESDETAIL_ID]);
                    #endregion
                    lstPrescDetail.Add( detail );
                }
                prescription.PresDetails = lstPrescDetail.ToArray( );

                lstPrescriptions.Add( prescription );
                
            }

            return lstPrescriptions.ToArray( );
        }
        /// <summary>
        /// 填充选择卡选中行的数据到指定的行
        /// </summary>
        /// <param name="SelectedRow">从选项卡选择的行记录</param>
        /// <param name="rowIndex">当前要填充的行</param>
        private void _fillSelectedRowData( DataRow SelectedRow , int rowIndex )
        {
            DataTable tbPresc = (DataTable)formView.Prescriptions;
            DataRow dr = tbPresc.Rows[rowIndex];
            dr[COL_KEYWORD] = SelectedRow["CODE"].ToString( ).Trim( );
            dr[COL_ITEM_NAME] = SelectedRow["CHEM_NAME"].ToString( ).Trim( );
            dr[COL_ITEM_UNIT] = SelectedRow["ITEM_UNIT"].ToString( ).Trim( );
            dr[COL_STANDARD] = SelectedRow["STANDARD"].ToString( ).Trim( );
            dr[COL_SELL_PRICE] = Convert.ToDecimal( SelectedRow["PRICE"] );
            dr[COL_PACK_NUM] = 0;
            dr[COL_PACK_UNIT] = SelectedRow["ITEM_UNIT"].ToString( ).Trim( );
            dr[COL_BASE_NUM] = 0;
            dr[COL_BASE_UNIT] = SelectedRow["BASE_UNIT"].ToString( ).Trim( );
            dr[COL_PRES_DOSAGE] = 1;
            dr[COL_PRES_DOC_NAME] = BaseDataController.GetName( BaseDataCatalog.人员列表, formView.PrescDoctorId );
            dr[COL_PRESDETAIL_ID] = 0;
            
            dr[COL_TOTAL_FEE] = 0;
            dr[COL_SELECTED_FLAG] = true;
            dr[COL_PRESC_TYPE] = "";
            dr[COL_ITEM_ID] = Convert.ToInt32( SelectedRow["ITEM_ID"] );
            dr[COL_COMPLEX_ID] = Convert.ToInt32( SelectedRow["COMPLEX_ID"] );
            dr[COL_BUY_PRICE] = dr[COL_SELL_PRICE];
            dr[COL_RELATION_NUM] = Convert.ToDecimal( SelectedRow["HJXS"] );
            //查找当前行所在的处方的医生、处方ID，
            #region .................
            int start , end , subTotalRow;
            GetPrescriptionSectionStartRow( rowIndex , out start , out end , out subTotalRow );
            if ( subTotalRow == -1 )
            {
                if ( start == end )
                {
                    //如果是新开处方的第一行,处方医生和科室取当前选择的医生和科室
                    dr[COL_PRES_DOC_ID] = formView.PrescDoctorId;
                    dr[COL_PRES_DEPT_ID] = formView.DoctorDeptId;
                    dr[COL_PRESMASTER_ID] = 0;
                }
                else
                {
                    //取其他行的医生和科室
                    for ( int i = start ; i <= end ; i++ )
                    {
                        if ( !Convert.IsDBNull( tbPresc.Rows[i][COL_PRES_DOC_ID] )
                            && tbPresc.Rows[i][COL_PRES_DOC_ID].ToString( ).Trim( ) != "" )
                        {
                            dr[COL_PRES_DOC_ID] = tbPresc.Rows[i][COL_PRES_DOC_ID];
                            dr[COL_PRES_DEPT_ID] = tbPresc.Rows[i][COL_PRES_DEPT_ID];
                            dr[COL_PRESMASTER_ID] = tbPresc.Rows[i][COL_PRESMASTER_ID];

                            break;
                        }
                    }
                }
            }
            else
            {
                //取其他行的医生和科室
                for ( int i = start ; i <= end ; i++ )
                {
                    if ( !Convert.IsDBNull( tbPresc.Rows[i][COL_PRES_DOC_ID] )
                        && tbPresc.Rows[i][COL_PRES_DOC_ID].ToString( ).Trim( ) != "" )
                    {
                        dr[COL_PRES_DOC_ID] = tbPresc.Rows[i][COL_PRES_DOC_ID];
                        dr[COL_PRES_DEPT_ID] = tbPresc.Rows[i][COL_PRES_DEPT_ID];
                        dr[COL_PRESMASTER_ID] = tbPresc.Rows[i][COL_PRESMASTER_ID];
                        break;
                    }
                }
            }
            #endregion
            if (SelectedRow["EXEC_DEPT_CODE"].ToString() == "0")
            {
                //dr[COL_EXEC_DEPT_NAME] = PublicDataReader.GetDeptNameById(formView.DoctorDeptId);
                dr[COL_EXEC_DEPT_NAME] = BaseDataController.GetName(BaseDataCatalog.科室列表 , formView.DoctorDeptId );
                dr[COL_EXEC_DEPT_ID] = formView.DoctorDeptId;
            }
            else
            {
                dr[COL_EXEC_DEPT_NAME] = SelectedRow["EXEC_DEPT_NAME"].ToString().Trim();
                dr[COL_EXEC_DEPT_ID] = SelectedRow["EXEC_DEPT_CODE"].ToString().Trim();
            }
            dr[COL_DOC_PRESMASTER_ID] = 0;
            dr[COL_DOC_PRESDETAIL_ID] = 0;
            dr[COL_BIGITEMCODE] = SelectedRow["STATITEM_CODE"].ToString( ).Trim( );
            dr[COL_MODIFY_FLAG] = 1;
            dr[COL_SUB_TOTAL_FLAG] = 0;
            

        }
    }
}
