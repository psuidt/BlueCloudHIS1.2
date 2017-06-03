using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS_DJSFManager.类;
using System.Collections;

namespace HIS_DJSFManager.窗口
{
    public partial class FrmCharge : BaseMainForm
    {
        public FrmCharge()
        {
            InitializeComponent( );
        }

        private const string subTotalString = "小   计：";

        public int currentUserEmployeeId;
        
        /// <summary>
        /// 收费项目
        /// </summary>
        private DataTable dtbChargeItems;
        /// <summary>
        /// 医生表
        /// </summary>
        private DataTable tbDoctor;
        /// <summary>
        /// 科室表
        /// </summary>
        private DataTable dtbDepartment;

        private DataTable tbTemplateDetail;

        private DataTable dtbWorkUnit;

        private OutPatient _currentPatient;

        private int NewPrescription()
        {
            if ( txtDoctor.MemberValue == null || txtDoctor.Text.Trim( ) == "" )
            {
                MessageBox.Show( "新开处方前请先选择医生" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                txtDoctor.Focus( );
                return -1;
            }
            
            int lastRowIndex = dgvPresc.Rows.Count - 1;
            int prescNo = 1;
            int start , end , subRow;
            GetPrescriptionStartRowAndEndRow( lastRowIndex , out start , out end , out subRow );
            if ( subRow == -1 )
            {
                if ( lastRowIndex == start && lastRowIndex == end && start == end )
                {
                    return lastRowIndex;
                }
                EndPrescription( );
            }

            dgvPresc.Rows.Add( );
            //添加行做新处方的开始行
            lastRowIndex = dgvPresc.Rows.Count - 1;
            prescNo = GetNewPrescriptionNo( );
            dgvPresc["NO1" , lastRowIndex].Value = prescNo;
            dgvPresc["NO2" , lastRowIndex].Value = prescNo;
            dgvPresc["PrescID" , lastRowIndex].Value = 0;
            dgvPresc["DetailID" , lastRowIndex].Value = 0;
            dgvPresc.CurrentCell = dgvPresc["CODE" , lastRowIndex];
            dgvPresc.Focus( );
            return lastRowIndex;
        }
        /// <summary>
        /// 结束处方
        /// </summary>
        private bool EndPrescription()
        {
            if ( dgvPresc.Rows.Count == 0 )
            {
                return false;
            }

            int prescStartRow;
            int prescEndRow;
            int subRow;
            int curentrowIndex = dgvPresc.CurrentCell.RowIndex;

            GetPrescriptionStartRowAndEndRow( curentrowIndex , out prescStartRow , out  prescEndRow , out subRow );
            if ( subRow != -1 )
            {
                //remove insert row
                int row = prescStartRow;
                while ( true )
                {
                    if ( dgvPresc["ITEM_ID" , row].Value == null ) //空行
                    {
                        dgvPresc.Rows.RemoveAt( row );
                    }
                    row++;
                    if ( dgvPresc.Rows[row].Tag != null )
                    {
                        break;
                    }
                }
            }
            else
            {
                int row = prescStartRow;
                while ( true )
                {
                    if ( dgvPresc["ITEM_ID" , row].Value == null ) //空行
                    {
                        dgvPresc.Rows.RemoveAt( row );
                        if ( prescStartRow == prescEndRow )
                        {
                            return true;
                        }
                    }
                    row++;
                    if ( row >= dgvPresc.Rows.Count )
                    {
                        dgvPresc.Rows.Add( );
                        WriteSubTotalRow( dgvPresc.Rows.Count - 1 );
                        break;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 写小计行内容
        /// </summary>
        /// <param name="subTotalRow"></param>
        private void WriteSubTotalRow( int subTotalRow )
        {
            decimal presTotal = CalcutePrescriptionCost( subTotalRow );

            for ( int i = 0 ; i < dgvPresc.Columns.Count ; i++ )
            {
                if ( dgvPresc.Columns[i].Visible )
                {
                    if ( ( dgvPresc.Columns[i].GetType( ) == typeof( DataGridViewTextBoxColumn ) )
                        || dgvPresc.Columns[i].GetType( ).IsSubclassOf( typeof( DataGridViewTextBoxColumn ) ) )
                    {
                        dgvPresc[i , subTotalRow].Value = "";
                    }
                }
            }
            dgvPresc["Exec_dept" , dgvPresc.Rows.Count - 1].Value = subTotalString;
            dgvPresc["TotalCost" , dgvPresc.Rows.Count - 1].Value = presTotal;
            dgvPresc["NO2" , dgvPresc.Rows.Count - 1].Tag = 1; /*注意在小计行的NO2列打标记为小计行*/
            dgvPresc.Rows[dgvPresc.Rows.Count - 1].Tag = 1;

            for ( int i = 0 ; i < dgvPresc.Columns.Count ; i++ )
            {
                dgvPresc[i , subTotalRow].Style.BackColor = Color.LightYellow;
                dgvPresc[i , subTotalRow].Style.Font = new Font( "宋体" , (float)11 , FontStyle.Bold );
                dgvPresc[i , subTotalRow].Style.ForeColor = Color.Red;
                if ( dgvPresc[i , subTotalRow].IsInEditMode )
                    dgvPresc.CancelEdit( );
                dgvPresc[i , subTotalRow].ReadOnly = true;
            }


        }
        /// <summary>
        /// 判断当前行是否处方第一行
        /// </summary>
        /// <param name="RowIndex"></param>
        /// <returns></returns>
        private bool IsPrescriptionFirstRow( int RowIndex )
        {
            int start , end , subRow;
            GetPrescriptionStartRowAndEndRow( RowIndex , out start , out end , out subRow );


            if ( RowIndex == start )
                return true;
            else
                return false;

            //if ( dgvPresc.Rows.Count == 1 )
            //    return true;

            //if ( dgvPresc["NO2" , RowIndex].Value != null )
            //    return true;
            //else
            //{
            //    //判断是否是小计行
            //    return false;
            //}

        }
        /// <summary>
        /// 根据当前行获取处方的开始行和结束行,小计行
        /// </summary>
        /// <param name="CurrentRowInex">当前行</param>
        /// <param name="startRowInex">开始行的Index</param>
        /// <param name="endRowIndex">结束行的Index</param>
        /// <param name="subTotalRowIndex">小计行的Index，如果为-1,则表示当前处方没有小计行</param>
        private void GetPrescriptionStartRowAndEndRow( int CurrentRowInex , out int startRowInex , out int endRowIndex , out int subTotalRowIndex )
        {
            int currentRowIndex = CurrentRowInex;
            subTotalRowIndex = -1;
            if ( CurrentRowInex == -1 )
            {
                startRowInex = 0;
                endRowIndex = 0;
                return;
            }
            //如果是小计行
            if ( dgvPresc["NO2" , currentRowIndex].Tag != null
                && Convert.ToInt32( dgvPresc["NO2" , currentRowIndex].Tag ) == 1 )
            {
                subTotalRowIndex = currentRowIndex;
                CurrentRowInex = CurrentRowInex - 1;
            }

            currentRowIndex = CurrentRowInex;
            //查找开始行
            while ( true )
            {
                currentRowIndex--;
                if ( currentRowIndex <= 0 )
                {
                    startRowInex = 0;
                    break;
                }
                else
                {
                    if ( dgvPresc["NO2" , currentRowIndex].Tag != null
                        && Convert.ToInt32( dgvPresc["NO2" , currentRowIndex].Tag ) == 1 )
                    {
                        startRowInex = currentRowIndex + 1;
                        break;
                    }
                }
            }
            //查找结束
            currentRowIndex = CurrentRowInex;
            while ( true )
            {
                currentRowIndex++;
                if ( currentRowIndex == dgvPresc.Rows.Count )
                {
                    endRowIndex = currentRowIndex - 1;
                    break;
                }
                else
                {
                    if ( dgvPresc["NO2" , currentRowIndex].Tag != null
                        && Convert.ToInt32( dgvPresc["No2" , currentRowIndex].Tag ) == 1 )
                    {
                        endRowIndex = currentRowIndex - 1;
                        subTotalRowIndex = currentRowIndex;
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// 获取新增处方的顺序号
        /// </summary>
        private int GetNewPrescriptionNo()
        {
            if ( dgvPresc.Rows.Count == 1 )
                return 1;
            else
            {
                object obj = dgvPresc["NO1" , dgvPresc.Rows.Count - 2].Value;
                return ( Convert.ToInt32( obj ) + 1 );
            }
        }
        /// <summary>
        /// 获取处方张数
        /// </summary>
        /// <returns></returns>
        private int GetPrescriptionNumber()
        {
            int number = 0;
            for ( int i = 0 ; i < dgvPresc.Rows.Count ; i++ )
            {
                if ( dgvPresc["NO2" , i].Tag != null && Convert.ToInt32( dgvPresc["NO2" , i].Tag ) == 1 )
                {
                    number = number + 1;
                }
            }
            return number;
        }
        /// <summary>
        /// 计算处方金额
        /// </summary>
        /// <returns></returns>
        private decimal CalcutePrescriptionCost( int currentRowIndex )
        {
            int start , end , subRow;
            GetPrescriptionStartRowAndEndRow( currentRowIndex , out start , out end , out subRow );
            if ( dgvPresc["NO1" , end].Tag != null && dgvPresc["NO1" , end].Tag.ToString( ) == "1" )
            {
                end = end - 1;
            }
            decimal subTotal = 0;
            Hashtable htStatItem = new Hashtable( );
            try
            {
                for ( int i = start ; i <= end ; i++ )
                {
                    if ( dgvPresc["TotalCost" , i].Value != null )
                    {
                        string bigitemCode = dgvPresc["STATITEM_CODE" , i].Value.ToString( ).Trim( );
                        if ( htStatItem.ContainsKey( bigitemCode ) )
                        {
                            object obj = Convert.ToDecimal( htStatItem[bigitemCode] );
                            obj = Convert.ToDecimal( obj ) + Convert.ToDecimal( dgvPresc["TotalCost" , i].Value );
                            htStatItem.Remove( bigitemCode );
                            htStatItem.Add( bigitemCode , obj );
                        }
                        else
                        {
                            htStatItem.Add( bigitemCode , Convert.ToDecimal( dgvPresc["TotalCost" , i].Value ) );
                        }
                    }
                }
                foreach ( object obj in htStatItem )
                {
                    subTotal += Decimal.Round( Convert.ToDecimal( ( (DictionaryEntry)obj ).Value ) , 1 );
                }
                return subTotal;
            }
            catch
            {
                return 0;
            }
        }
        /// <summary>
        /// 计算总金额
        /// </summary>
        /// <returns></returns>
        private decimal CalcuteAllPrescriptionCost()
        {
            decimal sumTotal = 0;

            for ( int row = 0 ; row < dgvPresc.Rows.Count ; row++ )
            {
                int start;
                int end;
                int subrow;
                GetPrescriptionStartRowAndEndRow( row , out start , out end , out subrow );
                if ( subrow != -1 )
                {
                    sumTotal = sumTotal + Convert.ToDecimal( dgvPresc["TotalCost" , subrow].Value );
                    row = subrow + 1;
                }
                else
                {
                    for ( int i = start ; i < dgvPresc.Rows.Count ; i++ )
                    {
                        sumTotal = sumTotal + Convert.ToDecimal( dgvPresc["TotalCost" , i].Value );
                    }
                    row = end + 1;
                }
            }
            return Decimal.Round( sumTotal , 1 );
        }

        private string GetDeptNamebyID( string DeptId )
        {
            if ( DeptId.Trim( ) == "" )
                return "";

            DataRow[] drs = dtbDepartment.Select( "Dept_ID=" + DeptId.Trim( ) );
            if ( drs.Length > 0 )
                return drs[0]["Name"].ToString( ).Trim( );
            else
                return "";
        }
        /// <summary>
        /// 获取项目CODE
        /// </summary>
        /// <param name="ItemID"></param>
        /// <param name="ComplexID"></param>
        /// <param name="BigItemCode"></param>
        /// <returns></returns>
        private string GetItemCodeByID( int ItemID , int ComplexID , string BigItemCode )
        {
            DataRow[] drs = dtbChargeItems.Select( "item_id=" + ItemID + " and complex_id=" + ComplexID + " and statitem_code='" + BigItemCode + "'" );
            if ( drs.Length > 0 )
                return drs[0]["Code"].ToString( ).Trim( );
            else
                return "";
        }
        /// <summary>
        /// 显示处方
        /// </summary>
        /// <param name="Prescriptions"></param>
        private void ShowPrescriptions( Prescription[] Prescriptions )
        {
            dgvPresc.Rows.Clear( );
            plLastInfo.Visible = false;
            for ( int i = 0 ; i < Prescriptions.Length ; i++ )
            {
                for ( int j = 0 ; j < Prescriptions[i].PresDetails.Length ; j++ )
                {
                    dgvPresc.Rows.Add( );
                    int row = dgvPresc.Rows.Count - 1;

                    dgvPresc["PrescID" , row].Value = Prescriptions[i].PrescriptionID;
                    dgvPresc["DetailID" , row].Value = Prescriptions[i].PresDetails[j].DetailId;
                    dgvPresc["NO1" , row].Value = Convert.ToString( i + 1 );
                    if ( j == 0 )
                        dgvPresc["NO2" , row].Value = Convert.ToString( i + 1 );
                    dgvPresc["CODE" , row].Value = GetItemCodeByID( Prescriptions[i].PresDetails[j].ItemId , Prescriptions[i].PresDetails[j].ComplexId , Prescriptions[i].PresDetails[j].BigitemCode );
                    dgvPresc["Item_Name" , row].Value = Prescriptions[i].PresDetails[j].Itemname;
                    dgvPresc["Standard" , row].Value = Prescriptions[i].PresDetails[j].Standard;
                    dgvPresc["Price" , row].Value = Prescriptions[i].PresDetails[j].Sell_price;
                    dgvPresc["Item_Unit" , row].Value = Prescriptions[i].PresDetails[j].Unit;//大单位
                    dgvPresc["PACK_Unit" , row].Value = Prescriptions[i].PresDetails[j].Unit;//大单位
                    string base_unit = "";
                    DataRow[] drBaseItem = dtbChargeItems.Select( "isdrug = 1 and item_id=" + Prescriptions[i].PresDetails[j].ItemId.ToString( ) );
                    if ( drBaseItem.Length > 0 )
                        base_unit = drBaseItem[0]["base_unit"].ToString( ).Trim( );
                    else
                        base_unit = Prescriptions[i].PresDetails[j].Unit;

                    dgvPresc["Base_Unit" , row].Value = base_unit;//小单位
                    if ( Prescriptions[i].PresDetails[j].BigitemCode == "01" ||
                        Prescriptions[i].PresDetails[j].BigitemCode == "02" ||
                        Prescriptions[i].PresDetails[j].BigitemCode == "03" )
                    {
                        decimal baseNum = Prescriptions[i].PresDetails[j].Amount % Prescriptions[i].PresDetails[j].RelationNum;
                        decimal packNum = ( Prescriptions[i].PresDetails[j].Amount - baseNum ) / Prescriptions[i].PresDetails[j].RelationNum;

                        dgvPresc["PACK_NUM" , row].Value = packNum;
                        dgvPresc["BASE_NUM" , row].Value = baseNum;
                    }
                    else
                    {
                        dgvPresc["PACK_NUM" , row].Value = 0;
                        dgvPresc["BASE_NUM" , row].Value = Prescriptions[i].PresDetails[j].Amount;
                    }

                    dgvPresc["PresAmount" , row].Value = Prescriptions[i].PresDetails[j].PresAmount;
                    dgvPresc["EXEC_DEPT" , row].Value = GetDeptNamebyID( Prescriptions[i].ExecDeptCode );
                    dgvPresc["EXEC_DEPT" , row].Tag = Prescriptions[i].ExecDeptCode;
                    dgvPresc["TotalCost" , row].Value = Prescriptions[i].PresDetails[j].Tolal_Fee;
                    dgvPresc["Item_ID" , row].Value = Prescriptions[i].PresDetails[j].ItemId;
                    dgvPresc["STATITEM_CODE" , row].Value = Prescriptions[i].PresDetails[j].BigitemCode;
                    dgvPresc["Complex_Id" , row].Value = Prescriptions[i].PresDetails[j].ComplexId;
                    dgvPresc["HJXS" , row].Value = Prescriptions[i].PresDetails[j].RelationNum;
                    dgvPresc["PrescDoctor" , row].Value = Prescriptions[i].PresDocCode;
                    dgvPresc["PrescDept" , row].Value = Prescriptions[i].PresDeptCode;
                    dgvPresc["Selected" , row].Value = (short)1;
                    dgvPresc["Modified" , row].Value = 0;
                    //颜色
                    for ( int r = 0 ; r < dgvPresc.Columns.Count ; r++ )
                    {
                        dgvPresc.Rows[row].Cells[r].Style.ForeColor = Color.Blue;
                    }
                }
                dgvPresc.Rows.Add( );
                WriteSubTotalRow( dgvPresc.Rows.Count - 1 );
            }
            if ( dgvPresc.Rows.Count > 0 )
                dgvPresc.CurrentCell = dgvPresc["CODE" , dgvPresc.Rows.Count - 1];
            //计算所有总金额
            lblTotal.Text = CalcuteAllPrescriptionCost( ).ToString( "#0.00" );
        }
        /// <summary>
        /// 验证处方正确性
        /// </summary>
        /// <returns></returns>
        private bool PrescriptionValidate()
        {
            #region 病人基本信息验证
            
            if ( txtPatName.Text.Trim( ) == "" )
            {
                MessageBox.Show( "病人姓名不能为空" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtPatName.Focus( );
                return false;
            }

            if ( txtDoctor.MemberValue == null || txtDoctor.MemberValue.ToString( ) == "" )
            {
                MessageBox.Show( "就诊医生选择不正确！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtDoctor.Focus( );
                return false;
            }
            #endregion
            for ( int i = 0 ; i < dgvPresc.Rows.Count ; i++ )
            {
                int start , end , subRow;
                GetPrescriptionStartRowAndEndRow( i , out start , out end , out subRow );
                if ( i == subRow )
                {
                    //小计行跳过
                    continue;
                }
                if ( subRow == -1 && end == dgvPresc.Rows.Count - 1 )
                {
                    //如果是最后一行并且没有结束处方，跳过
                    continue;
                }
                else
                {
                    //判断是否是
                    int row = i + 1;
                    if ( dgvPresc["ITEM_ID" , i].Value == null || dgvPresc["ITEM_ID" , i].Value.ToString( ) == "" )
                    {
                        MessageBox.Show( "第" + row.ToString( ) + "行没有药品或项目内容" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        dgvPresc.CurrentCell = dgvPresc["CODE" , i];
                        return false;
                    }
                    if ( dgvPresc["EXEC_DEPT" , i].Tag == null || dgvPresc["EXEC_DEPT" , i].Value.ToString( ) == "" || dgvPresc["EXEC_DEPT" , i].Value == null )
                    {
                        MessageBox.Show( "第" + row.ToString( ) + "行执行科室填写不正确" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return false;
                    }
                    try
                    {
                        int packNum = dgvPresc["PACK_NUM" , i].Value == null ? 0 : Convert.ToInt32( dgvPresc["PACK_NUM" , i].Value );
                        int baseNum = dgvPresc["BASE_NUM" , i].Value == null ? 0 : Convert.ToInt32( dgvPresc["BASE_NUM" , i].Value );
                        if ( packNum == 0 && baseNum == 0 )
                        {
                            MessageBox.Show( "第" + row.ToString( ) + "行数量为0" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                            dgvPresc.CurrentCell = dgvPresc["BASE_NUM" , i];
                            return false;
                        }

                        if ( packNum < 0 || baseNum < 0 )
                        {
                            MessageBox.Show( "第" + row.ToString( ) + "行数量必须大于0" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                            dgvPresc.CurrentCell = dgvPresc["BASE_NUM" , i];
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show( "第" + row.ToString( ) + "行输入不正确，该处只允许输入整数" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        dgvPresc.CurrentCell = dgvPresc["BASE_NUM" , i];
                        return false;
                    }

                    decimal PresAmount = dgvPresc["PresAmount" , i].Value == null ? 0 : Convert.ToDecimal( dgvPresc["PresAmount" , i].Value );
                    if ( PresAmount <= 0 )
                    {
                        MessageBox.Show( "第" + row.ToString( ) + "行付数填写不正确(必须为大于0的整数)" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        dgvPresc.CurrentCell = dgvPresc["PresAmount" , i];
                        return false;
                    }
                    
                    decimal totalCost = dgvPresc["TotalCost" , i].Value == null ? 0 : Convert.ToDecimal( dgvPresc["TotalCost" , i].Value );
                    if ( totalCost == 0 )
                    {
                        MessageBox.Show( "第" + row.ToString( ) + "行金额为0" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        dgvPresc.CurrentCell = dgvPresc["BASE_NUM" , i];
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// 设置列的只读属性
        /// </summary>
        private void SetColumnReadOnly()
        {
            if ( dgvPresc.Rows.Count == 0 )
                return;
            if ( dgvPresc.CurrentCell == null )
                return;

            int start , end , subRow;
            GetPrescriptionStartRowAndEndRow( dgvPresc.CurrentCell.RowIndex , out start , out end , out subRow );
            if ( dgvPresc.CurrentCell.RowIndex == subRow )
            {
                for ( int i = 0 ; i < dgvPresc.Columns.Count ; i++ )
                {
                    dgvPresc.Columns[i].ReadOnly = true;
                }
            }
            else
            {
                dgvPresc.Columns["CODE"].ReadOnly = false;
                dgvPresc.Columns["PACK_NUM"].ReadOnly = false;
                dgvPresc.Columns["BASE_NUM"].ReadOnly = false;
                dgvPresc.Columns["PresAmount"].ReadOnly = false;
                dgvPresc.Columns["EXEC_DEPT"].ReadOnly = true;
            }

            int currentRowIndex = dgvPresc.CurrentRow.Index;
            if ( dgvPresc["STATITEM_CODE" , currentRowIndex].Value == null )
                return;
            string stat_item_code = dgvPresc["STATITEM_CODE" , currentRowIndex].Value.ToString( ).Trim( );
            if ( stat_item_code == "01" || stat_item_code == "02" /*|| stat_item_code == "03"*/ )
            {
                dgvPresc.Columns["PACK_NUM"].ReadOnly = false;
                dgvPresc.Columns["PresAmount"].ReadOnly = true;
                dgvPresc.Columns["EXEC_DEPT"].ReadOnly = true;
            }
            else if ( stat_item_code == "03" )
            {
                dgvPresc.Columns["PresAmount"].ReadOnly = false;
                dgvPresc.Columns["EXEC_DEPT"].ReadOnly = true;
            }
            else
            {
                dgvPresc.Columns["PACK_NUM"].ReadOnly = true;
                dgvPresc.Columns["PresAmount"].ReadOnly = true;
                dgvPresc.Columns["EXEC_DEPT"].ReadOnly = true;
            }
            //单价为0可编辑
            if ( dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["Price"].Index )
            {
                if ( dgvPresc["ITEM_ID" , currentRowIndex].Value != null && dgvPresc["ITEM_ID" , currentRowIndex].Value.ToString( ).Trim( ) != "" )
                {
                    DataRow[] drs = dtbChargeItems.Select( "ITEM_ID=" + dgvPresc["ITEM_ID" , currentRowIndex].Value.ToString( ) );
                    if ( drs.Length > 0 )
                    {
                        if ( Convert.ToDecimal( drs[0]["Price"] ) == 0 )
                        {
                            dgvPresc.Columns["Price"].ReadOnly = false;
                        }
                        else
                        {
                            dgvPresc.Columns["Price"].ReadOnly = true;
                        }
                    }
                }
            }
            
        }
        /// <summary>
        /// 得到选中的处方(如果未选中的处方明细为null)
        /// </summary>
        /// <returns></returns>
        private Prescription[] GetPrescriptionFromGrid( bool allPrescription )
        {
            int prescCount = 0;

            prescCount = GetPrescriptionNumber( );

            int currentRow = 0;

            Prescription[] prescriptions = new Prescription[prescCount];

            #region 得到处方，如果是没有选择的处方
            int start , end , subRow;//定义处方的开始行，结束行和小计行
            int presIndex = 0;
            for ( presIndex = 0 ; presIndex < prescCount ; presIndex++ )
            {
                prescriptions[presIndex] = new Prescription( );
                //处方头
                prescriptions[presIndex].PatientID = 0;
                prescriptions[presIndex].RegisterID = Convert.ToInt32( txtPatName.Tag ); 
                prescriptions[presIndex].PresCostCode = currentUserEmployeeId.ToString( );
                prescriptions[presIndex].PresDeptCode = lblDept.Tag.ToString();
                prescriptions[presIndex].PresDocCode = txtDoctor.MemberValue.ToString();
                prescriptions[presIndex].Record_Flag = 0;
                prescriptions[presIndex].Charge_Flag = 0;
                prescriptions[presIndex].Drug_Flag = 0;
                prescriptions[presIndex].Total_Fee = 0;
                prescriptions[presIndex].PresDate = DateTime.Now;

                GetPrescriptionStartRowAndEndRow( currentRow , out start , out end , out subRow );
                if ( !allPrescription )
                {
                    if ( Convert.ToInt32( dgvPresc["Selected" , start].Value ) == 0 )
                    {
                        prescriptions[presIndex].PresDetails = null;
                        currentRow = subRow + 1;
                        continue;
                    }
                }
                prescriptions[presIndex].PresDetails = new PrescriptionDetail[end - start + 1];
                int detailIndex = 0;
                for ( int i = start ; i <= end ; i++ )
                {
                    if ( dgvPresc["Selected" , start].Value == null || Convert.ToBoolean( dgvPresc["Selected" , start].Value ) == false )
                    {
                        prescriptions[presIndex].PresDetails = null;
                        break;
                    }
                    if ( dgvPresc["ITEM_ID" , i].Value == null )
                        continue;
                    prescriptions[presIndex].PrescriptionID = Convert.ToInt32( dgvPresc["PrescID" , i].Value );
                    prescriptions[presIndex].ExecDeptCode = dgvPresc["EXEC_DEPT" , i].Tag.ToString( );//处方头记录执行科室
                    #region prescription.PrescType
                    switch ( dgvPresc["STATITEM_CODE" , i].Value.ToString( ).Trim( ) )
                    {
                        case "01":
                            prescriptions[presIndex].PrescType = "1";
                            break;
                        case "02":
                            prescriptions[presIndex].PrescType = "2";
                            break;
                        case "03":
                            prescriptions[presIndex].PrescType = "3";
                            break;
                        default:
                            prescriptions[presIndex].PrescType = "-1";
                            break;
                    }
                    #endregion
                    prescriptions[presIndex].PresDetails[detailIndex].PresctionId = prescriptions[presIndex].PrescriptionID;
                    int packNum = Convert.ToInt32( dgvPresc["PACK_NUM" , i].Value );
                    int baseNum = Convert.ToInt32( dgvPresc["BASE_NUM" , i].Value );
                    decimal relationNum = Convert.ToDecimal( dgvPresc["HJXS" , i].Value );
                    int amountNum = Convert.ToInt32( dgvPresc["PresAmount" , i].Value );
                    decimal sumNum = Convert.ToDecimal( packNum * relationNum + baseNum );
                    prescriptions[presIndex].PresDetails[detailIndex].Amount = sumNum;
                    prescriptions[presIndex].PresDetails[detailIndex].BigitemCode = dgvPresc["STATITEM_CODE" , i].Value.ToString( );
                    prescriptions[presIndex].PresDetails[detailIndex].Buy_price = Convert.ToDecimal( dgvPresc["Price" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].ComplexId = Convert.ToInt32( dgvPresc["Complex_Id" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].DetailId = Convert.ToInt32( dgvPresc["DetailID" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].ItemId = Convert.ToInt32( dgvPresc["Item_ID" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].Itemname = dgvPresc["Item_Name" , i].Value.ToString( );
                    #region prescription.PresDetails[detailIndex].ItemType
                    switch ( dgvPresc["STATITEM_CODE" , i].Value.ToString( ).Trim( ) )
                    {
                        case "01":
                            prescriptions[presIndex].PresDetails[detailIndex].ItemType = "01";
                            break;
                        case "02":
                            prescriptions[presIndex].PresDetails[detailIndex].ItemType = "02";
                            break;
                        case "03":
                            prescriptions[presIndex].PresDetails[detailIndex].ItemType = "03";
                            break;
                        default:
                            prescriptions[presIndex].PresDetails[detailIndex].ItemType = "00";
                            break;
                    }
                    #endregion
                    prescriptions[presIndex].PresDetails[detailIndex].Order_Flag = detailIndex + 1;
                    prescriptions[presIndex].PresDetails[detailIndex].PresAmount = Convert.ToInt32( dgvPresc["PresAmount" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].RelationNum = Convert.ToDecimal( dgvPresc["HJXS" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].Sell_price = Convert.ToDecimal( dgvPresc["Price" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].Standard = dgvPresc["Standard" , i].Value.ToString( );
                    prescriptions[presIndex].PresDetails[detailIndex].Tolal_Fee = Convert.ToDecimal( dgvPresc["TotalCost" , i].Value );
                    prescriptions[presIndex].PresDetails[detailIndex].Unit = dgvPresc["Pack_Unit" , i].Value.ToString( );
                    if ( Convert.ToInt16( dgvPresc["Modified" , i].Value ) == 1 )
                    {
                        prescriptions[presIndex].PresDetails[detailIndex].Modified = true;
                        prescriptions[presIndex].Modified = true;
                    }
                    else
                    {
                        prescriptions[presIndex].PresDetails[detailIndex].Modified = false;
                    }
                    prescriptions[presIndex].Total_Fee += prescriptions[presIndex].PresDetails[detailIndex].Tolal_Fee;
                    detailIndex++;
                }

                currentRow = subRow + 1;
            }
            #endregion

            return prescriptions;
        }
        /// <summary>
        /// 清除信息以便新的录入(录入框和处方网格清空，当前病人对象置null)
        /// <param name="onlyClearText">true：仅清空录入文本框，false：清空录入文本框的同时病人对象也置null</param>
        /// </summary>
        private void ClearUIInfo( bool onlyClearText )
        {
            
            txtPatName.Text = "";
            cboSex.SelectedIndex = 1;
            txtAge.Text = "20";
            cboPatType.SelectedIndex = 0;
            txtDoctor.Text = "";
            txtDoctor.MemberValue = null;
            lblDept.Text = "";
            lblDept.Tag = "0";
            txtPatName.Focus( );
            dgvPresc.Rows.Clear( );
            if ( !onlyClearText )
                _currentPatient = null;
        }
        /// <summary>
        /// 保存病人信息
        /// </summary>
        private bool SavePatientInfo()
        {
            #region 2003-03-25修改就诊号递增问题前的代码
            
            #endregion
            if ( txtPatName.Text.Trim( ) == "" )
            {
                MessageBox.Show( "病人姓名不能为空" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtPatName.Focus( );
                return false;
            }
            if ( txtAge.Text.Trim( ) == "" )
            {
                MessageBox.Show( "病人年龄不能为空" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtAge.Focus( );
                return false;
            }
            if ( dgvPresc.Rows.Count == 0 )
            {
                if ( MessageBox.Show( "该病人没有可保存的处方，是否保存病人信息？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                    return false;
            }
            if ( cboPatType.Text == "" )
            {
                MessageBox.Show( "病人类型不能为空！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                cboPatType.Focus( );
                return false;
            }
            if ( _currentPatient != null )
            {
                #region 2003-03-25修改就诊号递增问题新增加的代码
                if ( _currentPatient.PatListID == 0 )
                {
                    //就诊号是0，说明是新病人，需要登记信息
                    _currentPatient.NewRegister( );
                    //txtVisitNo.Text = _currentPatient.VisitNo;
                }
                #endregion
                //赋值病人信息
                _currentPatient.PatientName = txtPatName.Text;
                _currentPatient.PYM = "";
                _currentPatient.WBM = "";
                _currentPatient.MediType = cboPatType.SelectedValue.ToString( );
                _currentPatient.Sex = cboSex.Text;
                _currentPatient.Age = Convert.ToInt32( txtAge.Text );
                _currentPatient.CureEmpCode = txtDoctor.MemberValue == null ? "" : txtDoctor.MemberValue.ToString( );
                _currentPatient.CureDeptCode = lblDept.Tag == null ? "" : lblDept.Tag.ToString( );
                _currentPatient.DiseaseCode = "";
                _currentPatient.DiseaseName = "";
                _currentPatient.DiseaseMemo = "";
                _currentPatient.CureDate = DateTime.Now;
                if ( _currentPatient.UpdateRegister( ) )
                {
                    txtPatName.Tag = _currentPatient.PatListID;
                    return true;
                    
                }
                else
                {
                    return false;
                }
            }
            else
            {
                #region 2003-03-25修改就诊号递增问题新增加的代码
                //没有开新号直接录入病人信息的情况
                _currentPatient = new OutPatient( );
                _currentPatient.PatientName = txtPatName.Text;
                _currentPatient.PYM = "";
                _currentPatient.WBM = "";
                _currentPatient.MediType = cboPatType.SelectedValue.ToString( );
                _currentPatient.Sex = cboSex.Text;
                _currentPatient.Age = Convert.ToInt32( txtAge.Text );
                _currentPatient.CureEmpCode = txtDoctor.MemberValue == null ? "" : txtDoctor.MemberValue.ToString( );
                _currentPatient.CureDeptCode = lblDept.Tag == null ? "" : lblDept.Tag.ToString( );
                _currentPatient.DiseaseCode = "";
                _currentPatient.DiseaseName = "";
                _currentPatient.DiseaseMemo = "";
                _currentPatient.CureDate = DateTime.Now;

                SavePatientInfo( );
                #endregion
                return true;
            }
           
        }
        /// <summary>
        /// 
        /// </summary>
        private void SavePrescriptionEvent()
        {
            try
            {
                if ( PrescriptionValidate( ) )
                {
                    if ( SavePatientInfo( ) )
                    {
                        dgvPresc.EndEdit( );
                        if ( EndPrescription( ) )
                        {
                            if ( PrescriptionValidate( ) )
                            {
                                //保存处方
                                SavePrescription( );
                                //重新显示处方
                                Prescription[] prescriptions = _currentPatient.GetPrescriptions( PresStatus.未收费 , true );
                                ShowPrescriptions( prescriptions );
                                
                            }
                        }
                    }
                }
            }
            catch(Exception err)
            {
                MessageBox.Show( err.Message );
            }
        }
        /// <summary>
        /// 保存处方
        /// </summary>
        /// <param name="savedPrescriptions">返回保存后的处方</param>
        /// <returns></returns>
        private bool SavePrescription( out Prescription[] savedPrescriptions )
        {
            savedPrescriptions = null;

            //获取处方
            Prescription[] prescriptions = GetPrescriptionFromGrid( true );

            for ( int i = 0 ; i < prescriptions.Length ; i++ )
            {
                if ( prescriptions[i].PresDetails != null )
                {
                    for ( int j = 0 ; j < prescriptions[i].PresDetails.Length - 1 ; j++ )
                    {
                        if ( prescriptions[i].PresDetails[j].Tolal_Fee == 0 )
                        {
                            MessageBox.Show( "有0金额的项目，不能保存！" );
                            return false;
                        }
                    }
                }
            }

            ChargeControl chargeControl = new ChargeControl( _currentPatient , Convert.ToInt32( currentUserEmployeeId ) );

            try
            {
                //保存处方
                chargeControl.SavePrescription( prescriptions );

                savedPrescriptions = prescriptions;
                return true;
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return false;
            }

            //return true;
        }
        /// <summary>
        /// 保存处方
        /// </summary>
        private bool SavePrescription()
        {
            Prescription[] prescriptions;
            return SavePrescription( out prescriptions );
        }

        private void PrescriptionChargeEvent()
        {
            try
            {
                if ( PrescriptionValidate( ) )
                {
                    if ( SavePatientInfo( ) == false )
                        return;
                }
                else
                {
                    return;
                }

                dgvPresc.EndEdit( );
                //结束处方
                if ( EndPrescription( ) )
                {
                    Prescription[] prescriptions;
                    //保存处方
                    if ( SavePrescription( out prescriptions ) )
                    {
                        //取出选中的处方
                        Prescription[] selectedPrescriptions = GetPrescriptionFromGrid( false );
                        for ( int i = 0 ; i < prescriptions.Length ; i++ )
                        {
                            if ( selectedPrescriptions[i].PresDetails != null )
                            {
                                selectedPrescriptions[i].PrescriptionID = prescriptions[i].PrescriptionID;
                                for ( int j = 0 ; j < selectedPrescriptions[i].PresDetails.Length ; j++ )
                                {
                                    selectedPrescriptions[i].PresDetails[j].PresctionId = prescriptions[i].PresDetails[j].PresctionId;
                                    selectedPrescriptions[i].PresDetails[j].DetailId = prescriptions[i].PresDetails[j].DetailId;
                                }
                            }
                        }
                        //过滤掉没有选择的处方
                        List<Prescription> presTmp = new List<Prescription>( );
                        for ( int i = 0 ; i < selectedPrescriptions.Length ; i++ )
                        {
                            if ( selectedPrescriptions[i].PresDetails != null )
                            {
                                presTmp.Add( selectedPrescriptions[i] );
                            }
                        }
                        selectedPrescriptions = new Prescription[presTmp.Count];
                        for ( int i = 0 ; i < presTmp.Count ; i++ )
                            selectedPrescriptions[i] = presTmp[i];
                        if ( selectedPrescriptions.Length == 0 )
                        {
                            MessageBox.Show( "没有选择要收费的处方！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                            return;
                        }
                        //判断处方数是否大于可用发票数
                        int usableBallot = InvoiceManager.GetInvoiceNumberOfCanUse( OPDBillKind.门诊收费发票 , Convert.ToInt32( currentUserEmployeeId ) );
                        if ( usableBallot == 0 )
                        {
                            MessageBox.Show( "当前可用发票只有" + usableBallot + "张，请先分配发票！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                            return;
                        }
                        ChargeType chargeType = ChargeType.多张处方一次结算;
                        if ( usableBallot < selectedPrescriptions.Length && chargeType == ChargeType.一张处方一次结算 )
                        {
                            MessageBox.Show( "当前需要收费的处方有" + selectedPrescriptions.Length + "张，可用发票只有" + usableBallot + "张，请先分配发票！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                            return;
                        }
                        //进行收费处理过程
                        ChargeProcess( selectedPrescriptions );

                        //重新读取未收费的处方
                        Prescription[] notChargePres = _currentPatient.GetPrescriptions( PresStatus.未收费 , true );
                        if ( notChargePres.Length > 0 )
                            ShowPrescriptions( notChargePres );
                        else
                        {
                            ClearUIInfo( false );
                            plLastInfo.Visible = true;

                            txtPatName.Enabled = true;
                            txtAge.Enabled = true;
                            cboPatType.Enabled = true;
                            cboSex.Enabled = true;
                            txtPatName.Focus( );
                        }
                        string perfCode = "";
                        lblInvoice.Text = InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票 , Convert.ToInt32( currentUserEmployeeId ) , true , out perfCode );
                    }
                }
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message );
            }
        }
        /// <summary>
        /// 收费处理的完整过程（预算->反馈预算信息->正式结算->打印发票）
        /// </summary>
        /// <param name="prescriptions"></param>
        private bool ChargeProcess( Prescription[] prescriptions )
        {

            //实例化收费对象
            ChargeControl chargeControl = new ChargeControl( _currentPatient , Convert.ToInt32( currentUserEmployeeId ) );
            //结算信息
            ChargeInfo[] chargeInfos = new ChargeInfo[prescriptions.Length];

            #region 预算
            try
            {
                Cursor = Cursors.WaitCursor;
                chargeInfos = chargeControl.Budget( prescriptions );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            #endregion

            #region 合计结算信息并显示给用户
            //累计结算信息
            ChargeInfo totalChargeInfo = new ChargeInfo( );
            Hashtable htTotalItems = new Hashtable( );
            for ( int i = 0 ; i < chargeInfos.Length ; i++ )
            {
                totalChargeInfo.TotalFee += chargeInfos[i].TotalFee;
                totalChargeInfo.FavorFee += chargeInfos[i].FavorFee;
                totalChargeInfo.SelfFee += chargeInfos[i].SelfFee;
                totalChargeInfo.VillageFee += chargeInfos[i].VillageFee;

            }

            //向用户展示结算信息
            FrmChargeInfo frmChargeInfo = new FrmChargeInfo( totalChargeInfo );
            if ( frmChargeInfo.ShowDialog( ) == DialogResult.Cancel )
            {
                chargeControl.CancelCharge( );
                return false;
            }
            #endregion

            //防止在允许收手工录入医保支付或农合补偿金额情况下结算多张处方,
            if ( frmChargeInfo.ReturnChargeInfo.VillageFee > 0 && chargeInfos.Length > 1 )
            {
                MessageBox.Show( "如果是手工录入的农合补偿金额，每次只能结算一张处方！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Exclamation );
                return false;
            }

            chargeControl.SetChargeInfoPay( ref chargeInfos , frmChargeInfo.ReturnChargeInfo.VillageFee ,
                                                                   frmChargeInfo.ReturnChargeInfo.PosFee ,
                                                                   frmChargeInfo.ReturnChargeInfo.CashFee ,
                                                                   frmChargeInfo.ReturnChargeInfo.SelfTally );
            try
            {
                Cursor = Cursors.WaitCursor;
                //正式结算
                Invoice[] invoicies;
                chargeControl.Charge( chargeInfos , prescriptions , out invoicies );
                //打印发票
                try
                {
                    PrintController.PrintChargeInvoice( invoicies );
                }
                catch ( Exception printErr )
                {
                    MessageBox.Show( printErr.Message , "打印发票错误" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                }
                ShowLastChargeInfo( _currentPatient.PatientName , chargeInfos.Length , totalChargeInfo.TotalFee ,
                    frmChargeInfo.ActPay , frmChargeInfo.ReturnMoney , frmChargeInfo.ReturnChargeInfo.VillageFee ,
                    frmChargeInfo.ReturnChargeInfo.FavorFee , frmChargeInfo.ReturnChargeInfo.SelfFee , frmChargeInfo.ReturnChargeInfo.PosFee , frmChargeInfo.ReturnChargeInfo.SelfTally );
                return true;
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }

        }

        /// <summary>
        /// 显示上一个病人的收费信息
        /// </summary>
        /// <param name="PatName"></param>
        /// <param name="InvoiceCount"></param>
        /// <param name="TotalCost"></param>
        /// <param name="ActPay"></param>
        /// <param name="ReturnMoney"></param>
        /// <param name="TallyPay"></param>
        /// <param name="PerMoney"></param>
        /// <param name="SelfPay"></param>
        /// <param name="PosPay"></param>
        private void ShowLastChargeInfo( string PatName , int InvoiceCount , decimal TotalCost , decimal ActPay , decimal ReturnMoney , decimal TallyPay , decimal PerMoney , decimal SelfPay , decimal PosPay , decimal SelfTallyPay )
        {
            lblPatName.Text = PatName;
            lblInvoiceCount.Text = InvoiceCount.ToString( );
            lblPresTotalCost.Text = TotalCost.ToString( "#0.#0" );
            lblActPay.Text = ActPay.ToString( "#0.#0" );
            lblReturnMoney.Text = ReturnMoney.ToString( "#0.#0" );
            lblTally.Text = TallyPay.ToString( "#0.#0" );
            lblPerMoney.Text = PerMoney.ToString( "#0.#0" );
            lblSelfPay.Text = SelfPay.ToString( "#0.#0" );
            lblPOS.Text = PosPay.ToString( "#0.#0" );
            lblSelfTally.Text = SelfTallyPay.ToString( "#0.#0" );
        }

        private void FrmCharge_Load( object sender , EventArgs e )
        {
            dtbChargeItems = DataReader.GetShowCardItems( );
            dgvPresc.SetSelectionCardDataSource( dtbChargeItems ,"CODE" );

            tbDoctor = DataReader.GetDoctorList( );
            txtDoctor.SetSelectionCardDataSource( tbDoctor );

            tbTemplateDetail = DataReader.GetTemplateDetail( );

            cboPatType.ValueMember = "CODE";
            cboPatType.DisplayMember = "NAME";
            cboPatType.DataSource = DataReader.PatientType;
            if ( cboPatType.Items.Count > 0 )
                cboPatType.SelectedIndex = 0;

            cboSex.SelectedIndex = 0;

            dtbDepartment = DataReader.Department.Copy( );

            dtbWorkUnit = DataReader.Get_WorkUnitList( );
            txtWorkUnit.SetSelectionCardDataSource( dtbWorkUnit );

            try
            {
                string perfCode = "";
                string invoiceNo = InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票 , Convert.ToInt32( currentUserEmployeeId ) , true , out perfCode );
                lblInvoice.Text = invoiceNo;
                MessageBox.Show( "当前可用发票号：" + invoiceNo + " ，请确认！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                this.toolBarMain.Enabled = false;
            }
        }

        private void txtDoctor_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                NewPrescription( );
            }
        }

        private void txtDoctor_AfterSelectedRow( object sender , object SelectedValue )
        {
            if ( SelectedValue != null )
            {
                lblDept.Text = ( (DataRow)SelectedValue )["DEPT_NAME"].ToString( ).Trim( );
                lblDept.Tag = Convert.ToInt32(( (DataRow)SelectedValue )["DEPT_ID"]);
            }
        }

        private void dgvPresc_SelectCardRowSelected( object SelectedValue , ref bool stop , ref int customNextColumnIndex )
        {
            int currentRowIndex = dgvPresc.CurrentCell.RowIndex;
            if ( txtDoctor.MemberValue == null )
            {
                MessageBox.Show( "开方医生填写不正确" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtDoctor.Focus( );
                stop = true;
                return;
            }
            

            if ( dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["CODE"].Index )
            {
                //取得选择卡的数据
                string code = ( (DataRow)SelectedValue )["CODE"].ToString( );
                //string item_name = ( (DataRow)SelectedValue )["ITEM_NAME"].ToString();
                string item_name = ( (DataRow)SelectedValue )["CHEM_NAME"].ToString( );
                string standard = ( (DataRow)SelectedValue )["Standard"].ToString( );
                string price = ( (DataRow)SelectedValue )["PRICE"].ToString( );
                string item_unit = ( (DataRow)SelectedValue )["ITEM_UNIT"].ToString( ); //大单位
                string base_unit = ( (DataRow)SelectedValue )["BASE_UNIT"].ToString( );
                string exec_dept_name = ( (DataRow)SelectedValue )["EXEC_DEPT_NAME"] == null ? "" : ( (DataRow)SelectedValue )["EXEC_DEPT_NAME"].ToString( );
                string exec_dept_code = ( (DataRow)SelectedValue )["EXEC_DEPT_CODE"] == null ? "" : ( (DataRow)SelectedValue )["EXEC_DEPT_CODE"].ToString( );
                string item_id = ( (DataRow)SelectedValue )["ITEM_ID"].ToString( );
                string statitem_code = ( (DataRow)SelectedValue )["STATITEM_CODE"].ToString( );
                string complex_id = ( (DataRow)SelectedValue )["Complex_ID"].ToString( );
                string hjxs = ( (DataRow)SelectedValue )["HJXS"] == null ? "" : ( (DataRow)SelectedValue )["HJXS"].ToString( );
                string isDrug = ( (DataRow)SelectedValue )["IsDrug"].ToString( ).Trim( );
                string isTemplate = ( (DataRow)SelectedValue )["IsTemplate"].ToString( ).Trim( );
                //

                #region 自动分方控制
                if ( !IsPrescriptionFirstRow( currentRowIndex ) )
                {
                    string previous_row_dept_code = dgvPresc["EXEC_DEPT" , currentRowIndex - 1].Tag.ToString( );
                    string previous_row_stat_item_code = dgvPresc["STATITEM_CODE" , currentRowIndex - 1].Value.ToString( );
                    string previous_row_isDrug = "0";
                    if ( previous_row_stat_item_code == "01" || previous_row_stat_item_code == "02" || previous_row_stat_item_code == "03" )
                    {
                        previous_row_isDrug = "1";
                    }
                    if ( exec_dept_code.Trim( ) == "" )
                        exec_dept_code = "0";

                    if ( previous_row_dept_code.Trim( ) != exec_dept_code.Trim( ) && exec_dept_code.Trim( ) != "" )
                    {
                        if ( Convert.ToInt32( exec_dept_code ) > 0 )
                        {
                            if ( MessageBox.Show( "执行科室不同，是否自动分方？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                            {
                                dgvPresc.CurrentCell = dgvPresc["CODE" , currentRowIndex];
                                stop = true;
                                return;
                            }
                            else
                            {
                                EndPrescription( );
                                currentRowIndex = NewPrescription( );
                            }
                        }
                        else
                        {
                            //判断上一行是否药品，是药品的话，不允许在该处方内录入项目
                            if ( previous_row_isDrug != isDrug )
                            {
                                if ( MessageBox.Show( "药品和治疗项目不能开在同一处方，是否自动分方？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                                {
                                    dgvPresc.CurrentCell = dgvPresc["CODE" , currentRowIndex];
                                    stop = true;
                                    return;
                                }
                                else
                                {
                                    EndPrescription( );
                                    currentRowIndex = NewPrescription( );
                                }
                            }

                        }
                    }
                }
                
                #endregion

                if ( isTemplate == "1" )
                {
                    
                    #region 加入模板明细
                    DataRow[] drsTemplate = tbTemplateDetail.Select( "TEMPLATE_ID=" + item_id );
                    for ( int i = 0 ; i < drsTemplate.Length ; i++ )
                    {
                        string _t_item_id = drsTemplate[i]["item_id"].ToString( ).Trim( );
                        string _t_complex_id = drsTemplate[i]["complex_id"].ToString( ).Trim( );
                        string _t_name = drsTemplate[i]["item_name"].ToString( ).Trim( );
                        string _t_standard = drsTemplate[i]["standard"].ToString( ).Trim( );
                        DataRow[] drsItem = dtbChargeItems.Select( "ITEM_ID=" + _t_item_id + " and complex_id=" + _t_complex_id + " and isdrug=" + isDrug );
                        if ( drsItem.Length > 0 )
                        {
                            code = drsItem[0]["CODE"].ToString( );
                            item_name = drsItem[0]["ITEM_NAME"].ToString( );
                            standard = drsItem[0]["Standard"].ToString( );
                            price = drsItem[0]["PRICE"].ToString( );
                            item_unit = drsItem[0]["ITEM_UNIT"].ToString( ); //大单位
                            base_unit = drsItem[0]["BASE_UNIT"].ToString( );
                            exec_dept_name = drsItem[0]["EXEC_DEPT_NAME"] == null ? "" : drsItem[0]["EXEC_DEPT_NAME"].ToString( );
                            exec_dept_code = drsItem[0]["EXEC_DEPT_CODE"] == null ? "" : drsItem[0]["EXEC_DEPT_CODE"].ToString( );
                            item_id = drsItem[0]["ITEM_ID"].ToString( );
                            statitem_code = drsItem[0]["STATITEM_CODE"].ToString( ).Trim( );
                            complex_id = drsItem[0]["Complex_ID"].ToString( );
                            hjxs = drsItem[0]["HJXS"] == null ? "1" : drsItem[0]["HJXS"].ToString( );
                            int amount = Convert.ToInt32( drsTemplate[i]["AMOUNT"] );
                            string _isDrug = drsItem[0]["IsDrug"].ToString( ).Trim( );

                            decimal baseNum = amount % Convert.ToInt32( hjxs );
                            decimal packNum = ( amount - baseNum ) / Convert.ToInt32( hjxs );

                            #region 加入模板明细
                            dgvPresc["CODE" , currentRowIndex].Value = code.Trim( );
                            dgvPresc["Item_Name" , currentRowIndex].Value = item_name;
                            dgvPresc["Standard" , currentRowIndex].Value = standard;
                            dgvPresc["Price" , currentRowIndex].Value = price;

                            dgvPresc["Item_Unit" , currentRowIndex].Value = item_unit;
                            dgvPresc["PACK_Unit" , currentRowIndex].Value = item_unit;

                            if ( statitem_code == "01" || statitem_code == "02" || statitem_code == "03" )
                            {
                                dgvPresc["PACK_NUM" , currentRowIndex].Value = packNum;
                                dgvPresc["BASE_NUM" , currentRowIndex].Value = baseNum;
                            }
                            else
                            {
                                dgvPresc["PACK_NUM" , currentRowIndex].Value = 0;
                                dgvPresc["BASE_NUM" , currentRowIndex].Value = amount;
                            }

                            dgvPresc["Base_Unit" , currentRowIndex].Value = base_unit;

                            if ( IsPrescriptionFirstRow( currentRowIndex ) )
                            {
                                dgvPresc["PresAmount" , currentRowIndex].Value = 1;
                                //如果是处方第一行并且选择的项目没有执行科室，则默认为开方科室
                                if ( exec_dept_code.Trim( ) == "" || exec_dept_code.Trim( ) == "0" )
                                {
                                    dgvPresc["EXEC_DEPT" , currentRowIndex].Value = lblDept.Text;
                                    dgvPresc["EXEC_DEPT" , currentRowIndex].Tag = lblDept.Tag.ToString( );
                                }
                                else
                                {
                                    dgvPresc["EXEC_DEPT" , currentRowIndex].Value = exec_dept_name;
                                    dgvPresc["EXEC_DEPT" , currentRowIndex].Tag = exec_dept_code;
                                }
                            }
                            else
                            {
                                dgvPresc["PresAmount" , currentRowIndex].Value = dgvPresc["PresAmount" , currentRowIndex - 1].Value;
                                dgvPresc["EXEC_DEPT" , currentRowIndex].Value = dgvPresc["EXEC_DEPT" , currentRowIndex - 1].Value;
                                dgvPresc["EXEC_DEPT" , currentRowIndex].Tag = dgvPresc["EXEC_DEPT" , currentRowIndex - 1].Tag;
                            }
                            dgvPresc["TotalCost" , currentRowIndex].Value = amount * Convert.ToDecimal( price ) / Convert.ToDecimal( hjxs );
                            dgvPresc["Item_ID" , currentRowIndex].Value = item_id;
                            dgvPresc["STATITEM_CODE" , currentRowIndex].Value = statitem_code;
                            dgvPresc["Complex_Id" , currentRowIndex].Value = complex_id;
                            dgvPresc["HJXS" , currentRowIndex].Value = hjxs;
                            dgvPresc["Selected" , currentRowIndex].Value = (short)1;
                            #endregion

                            int start;
                            int end;
                            int subRow;
                            GetPrescriptionStartRowAndEndRow( currentRowIndex , out start , out end , out subRow );
                            if ( subRow == -1 )
                            {
                                if ( i < drsTemplate.Length - 1 )
                                {
                                    if ( dgvPresc["ITEM_ID" , dgvPresc.Rows.Count - 1].Value != null )
                                        dgvPresc.Rows.Add( );
                                    currentRowIndex = dgvPresc.Rows.Count - 1;
                                }
                            }
                            else
                            {
                                if ( i < drsTemplate.Length - 1 )
                                {
                                    dgvPresc.Rows.Insert( currentRowIndex + 1 , 1 );
                                    currentRowIndex = currentRowIndex + 1;
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show( _t_name + _t_standard + "没有检索到！您可以：\r\n1、刷新选项卡后再试\r\n2、确认是否有库存或者该药品状态是否停用" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                            //dgvPresc.Rows.RemoveAt( currentRowIndex );
                        }

                    }

                    #endregion
                    int start1 , end1 , subrow1;
                    GetPrescriptionStartRowAndEndRow( currentRowIndex , out start1 , out end1 , out subrow1 );
                    if ( subrow1 == -1 )
                    {
                        if ( currentRowIndex == dgvPresc.Rows.Count - 1 )
                        {
                            if ( dgvPresc["ITEM_ID" , dgvPresc.Rows.Count - 1].Value != null )
                            {
                                dgvPresc.Rows.Add( );
                            }
                        }
                    }
                    dgvPresc.CurrentCell = dgvPresc["CODE" , dgvPresc.Rows.Count - 1];
                    
                }
                else
                {
                    #region 加入单行
                    dgvPresc["CODE" , currentRowIndex].Value = code;
                    dgvPresc["Item_Name" , currentRowIndex].Value = item_name;
                    dgvPresc["Standard" , currentRowIndex].Value = standard;
                    dgvPresc["Price" , currentRowIndex].Value = price;

                    dgvPresc["Item_Unit" , currentRowIndex].Value = item_unit;
                    dgvPresc["PACK_Unit" , currentRowIndex].Value = item_unit;
                    dgvPresc["PACK_NUM" , currentRowIndex].Value = 0;
                    dgvPresc["BASE_NUM" , currentRowIndex].Value = 0;
                    dgvPresc["Base_Unit" , currentRowIndex].Value = base_unit;

                    if ( IsPrescriptionFirstRow( currentRowIndex ) )
                    {
                        dgvPresc["PresAmount" , currentRowIndex].Value = 1;
                        //如果是处方第一行并且选择的项目没有执行科室，则默认为开方科室
                        if ( exec_dept_code.Trim( ) == "" || exec_dept_code.Trim( ) == "0" )
                        {
                            dgvPresc["EXEC_DEPT" , currentRowIndex].Value = lblDept.Text;
                            dgvPresc["EXEC_DEPT" , currentRowIndex].Tag = lblDept.Tag.ToString();
                        }
                        else
                        {
                            dgvPresc["EXEC_DEPT" , currentRowIndex].Value = exec_dept_name;
                            dgvPresc["EXEC_DEPT" , currentRowIndex].Tag = exec_dept_code;
                        }
                    }
                    else
                    {
                        dgvPresc["PresAmount" , currentRowIndex].Value = dgvPresc["PresAmount" , currentRowIndex - 1].Value;
                        dgvPresc["EXEC_DEPT" , currentRowIndex].Value = dgvPresc["EXEC_DEPT" , currentRowIndex - 1].Value;
                        dgvPresc["EXEC_DEPT" , currentRowIndex].Tag = dgvPresc["EXEC_DEPT" , currentRowIndex - 1].Tag;
                    }
                    dgvPresc["TotalCost" , currentRowIndex].Value = 0.00;
                    dgvPresc["Item_ID" , currentRowIndex].Value = item_id;
                    dgvPresc["STATITEM_CODE" , currentRowIndex].Value = statitem_code;
                    dgvPresc["Complex_Id" , currentRowIndex].Value = complex_id;
                    dgvPresc["HJXS" , currentRowIndex].Value = hjxs;
                    dgvPresc["Selected" , currentRowIndex].Value = (short)1;

                    SetColumnReadOnly( );
                    if ( statitem_code == "01" || statitem_code == "02" )
                    {
                        customNextColumnIndex = dgvPresc.Columns["PACK_NUM"].Index;
                        return;
                    }
                    else
                    {
                        customNextColumnIndex = dgvPresc.Columns["BASE_NUM"].Index;
                    }
                    #endregion
                }
            }
        }

        private void dgvPresc_RowsAdded( object sender , DataGridViewRowsAddedEventArgs e )
        {
            dgvPresc["PrescDoctor" , e.RowIndex].Value = txtDoctor.MemberValue.ToString( );
            dgvPresc["PrescDept" , e.RowIndex].Value = lblDept.Text;
            dgvPresc["PrescDept" , e.RowIndex].Tag = lblDept.Tag.ToString();
            dgvPresc["Modified" , e.RowIndex].Value = 1;
            if ( dgvPresc.Rows.Count == 1 )
            {
                return;
            }
            else
            {
                //复制处方号
                if ( !IsPrescriptionFirstRow( e.RowIndex ) )
                {
                    dgvPresc["NO1" , e.RowIndex].Value = dgvPresc["NO1" , e.RowIndex - 1].Value;
                }
            }

        }

        private void dgvPresc_CellEndEdit( object sender , DataGridViewCellEventArgs e )
        {
            int rowIndex = dgvPresc.CurrentCell.RowIndex;
            int start , end , subRow;
            GetPrescriptionStartRowAndEndRow( e.RowIndex , out  start , out end , out subRow );
            try
            {
                if ( dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["PACK_NUM"].Index || dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["BASE_NUM"].Index
                    || dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["PresAmount"].Index || dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["Price"].Index )
                {
                    if ( dgvPresc["PACK_NUM" , rowIndex].Value == null || dgvPresc["PACK_NUM" , rowIndex].Value.ToString( ).Trim( ) == "" )
                        dgvPresc["PACK_NUM" , rowIndex].Value = 0;
                    if ( dgvPresc["BASE_NUM" , rowIndex].Value == null || dgvPresc["BASE_NUM" , rowIndex].Value.ToString( ).Trim( ) == "" )
                        dgvPresc["BASE_NUM" , rowIndex].Value = 0;
                    if ( dgvPresc["PresAmount" , rowIndex].Value == null || dgvPresc["PresAmount" , rowIndex].Value.ToString( ).Trim( ) == "" )
                        dgvPresc["PresAmount" , rowIndex].Value = 0;
                    if ( dgvPresc["Price" , rowIndex].Value == null || dgvPresc["Price" , rowIndex].Value.ToString( ).Trim( ) == "" )
                        dgvPresc["Price" , rowIndex].Value = 0;


                    decimal packnum = dgvPresc["PACK_NUM" , rowIndex].Value == null ? 0 : Convert.ToDecimal( dgvPresc["PACK_NUM" , rowIndex].Value );
                    decimal basenum = dgvPresc["BASE_NUM" , rowIndex].Value == null ? 0 : Convert.ToDecimal( dgvPresc["BASE_NUM" , rowIndex].Value );
                    decimal presAmount = dgvPresc["PresAmount" , rowIndex].Value == null ? 1 : Convert.ToDecimal( dgvPresc["PresAmount" , rowIndex].Value );
                    //计算本张处方金额
                    decimal presTotal = 0;
                    for ( int index = start ; index <= end ; index++ )
                    {
                        dgvPresc["PresAmount" , index].Value = presAmount;
                        packnum = dgvPresc["PACK_NUM" , index].Value == null ? 0 : Convert.ToDecimal( dgvPresc["PACK_NUM" , index].Value );
                        basenum = dgvPresc["BASE_NUM" , index].Value == null ? 0 : Convert.ToDecimal( dgvPresc["BASE_NUM" , index].Value );
                        decimal relationNum = dgvPresc["HJXS" , index].Value == null ? 0 : Convert.ToDecimal( dgvPresc["HJXS" , index].Value );
                        decimal price = dgvPresc["PRICE" , index].Value == null ? 0 : Convert.ToDecimal( dgvPresc["PRICE" , index].Value );
                        decimal total = 0;
                        if ( relationNum != 0 )
                            total = Math.Round( ( packnum * price + ( basenum * price / relationNum ) ) * presAmount , 4 );

                        dgvPresc["TotalCost" , index].Value = total;
                        presTotal += Convert.ToDecimal( dgvPresc["TotalCost" , index].Value );

                    }
                    //更新小计行数
                    if ( subRow > 0 )
                        dgvPresc["TotalCost" , subRow].Value = CalcutePrescriptionCost( e.RowIndex ); //presTotal;
                    //将本行修改标识置为1
                    dgvPresc["Modified" , rowIndex].Value = 1;
                }
                //计算所有总金额
                lblTotal.Text = CalcuteAllPrescriptionCost( ).ToString( "#0.00" );
            }
            catch
            {
            }
        }

        private void dgvPresc_CurrentCellChanged( object sender , EventArgs e )
        {
            SetColumnReadOnly( );
            //可根据需要设置SpeciFilterString属性来过滤对应选择卡中的记录
            if ( dgvPresc.CurrentCell == null )
                return;
            //控制右键菜单Enable
            if ( dgvPresc["NO2" , dgvPresc.CurrentRow.Index].Tag != null &&
                Convert.ToInt32( dgvPresc["NO2" , dgvPresc.CurrentRow.Index].Tag ) == 1 )
            {
                menuDelRow.Enabled = false;
                menuInsertRow.Enabled = false;
                menuDelPres.Enabled = false;
            }
            else
            {
                menuDelRow.Enabled = true;
                menuInsertRow.Enabled = true;
                menuDelPres.Enabled = true;
            }

            if ( dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["CODE"].Index )
            {
                if ( dgvPresc.Rows.Count == 1 )
                {
                    dgvPresc.SelectionCards[0].SpeciFilterString = "";
                    return;
                }
                else
                {
                    int start , end , subRow;
                    GetPrescriptionStartRowAndEndRow( dgvPresc.CurrentCell.RowIndex , out start , out end , out subRow );

                    if ( dgvPresc.CurrentCell.RowIndex == 0 )
                        return;

                    if ( dgvPresc.CurrentCell.RowIndex == subRow ) //小计行
                        return;

                    if ( start == end && subRow == -1 )
                    {
                        //新处方第一行
                        dgvPresc.SelectionCards[0].SpeciFilterString = "";
                        return;
                    }
                    //if ( Convert.ToInt16( OPDParamter.Parameters["009"] ) == 0 ) //如果不自动分方，过滤显示
                    //{
                    //    if ( start != end )
                    //    {
                    //        string stat_code = dgvPresc["STATITEM_CODE" , start].Value.ToString( );//当前处方第一行类型
                    //        if ( stat_code == "01" || stat_code == "02" || stat_code == "03" )
                    //        {
                    //            dgvPresc.SelectionCards[0].SpeciFilterString = "ISDRUG=1 AND STATITEM_CODE = '" + stat_code + "'";
                    //        }
                    //        else
                    //        {
                    //            dgvPresc.SelectionCards[0].SpeciFilterString = "ISDRUG=0 AND STATITEM_CODE NOT IN( '01','02','03')";
                    //        }
                    //    }
                    //}
                }
            }


        }

        private void dgvPresc_CellContentClick( object sender , DataGridViewCellEventArgs e )
        {
            if ( dgvPresc.Rows.Count == 0 )
                return;
            if ( e.RowIndex < 0 )
                return;

            if ( e.ColumnIndex == dgvPresc.Columns["Selected"].Index )
            {
                int start , end , subRow;
                bool isSelected = false;
                if ( Convert.ToBoolean( dgvPresc["Selected" , e.RowIndex].Value ) == true )
                    isSelected = false;
                else
                    isSelected = true;

                GetPrescriptionStartRowAndEndRow( e.RowIndex , out start , out end , out subRow );
                for ( int i = start ; i <= end ; i++ )
                {
                    dgvPresc["Selected" , i].Value = isSelected;
                }
            }
        }

        private void dgvPresc_DataGridViewCellPressEnterKey( object sender , int colIndex , int rowIndex , ref bool jumpStop )
        {
            if ( colIndex == dgvPresc.Columns["PresAmount"].Index )
            {
                if ( dgvPresc["Item_ID" , rowIndex].Value == null )
                {
                    jumpStop = true;
                }
            }
        }

        private void btnNewPres_Click( object sender , EventArgs e )
        {
            NewPrescription( );
        }

        private void toolStripButton1_Click( object sender , EventArgs e )
        {
            SavePrescriptionEvent( );
        }

        private void cboSex_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                cboPatType.Focus( );
        }

        private void cboPatType_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
                txtWorkUnit.Focus( );
        }

        private void toolStripButton2_Click( object sender , EventArgs e )
        {
            PrescriptionChargeEvent( );
        }

        private void btnClearInfo_Click( object sender , EventArgs e )
        {
            ClearUIInfo( false );
            txtPatName.Enabled = true;
            txtAge.Enabled = true;
            cboPatType.Enabled = true;
            cboSex.Enabled = true;
        }

        private void menuInsertRow_Click( object sender , EventArgs e )
        {
            if ( dgvPresc.Rows.Count == 0 )
                return;

            int start , end , subRow;
            int currentRow = dgvPresc.CurrentCell.RowIndex;

            GetPrescriptionStartRowAndEndRow( currentRow , out start , out end , out subRow );
            //当前行是空行的话不操作
            if ( dgvPresc["ITEM_ID" , currentRow].Value != null
                && dgvPresc["ITEM_ID" , currentRow].Value.ToString( ) != "" )
            {
                dgvPresc.Rows.Insert( currentRow + 1 , 1 );
                dgvPresc["PrescID" , currentRow + 1].Value = dgvPresc["PrescID" , currentRow].Value;
                dgvPresc.CurrentCell = dgvPresc["CODE" , currentRow + 1];
                dgvPresc.BeginEdit( true );
            }


        }

        private void menuDelRow_Click( object sender , EventArgs e )
        {
            if ( dgvPresc.Rows.Count == 0 )
                return;

            int start , end , subRow;
            int currentRow = dgvPresc.CurrentCell.RowIndex;
            GetPrescriptionStartRowAndEndRow( currentRow , out start , out end , out subRow );

            int presId = dgvPresc["PrescID" , currentRow].Value == null ? 0 : Convert.ToInt32( dgvPresc["PrescID" , currentRow].Value );
            int detailId = dgvPresc["DetailID" , currentRow].Value == null ? 0 : Convert.ToInt32( dgvPresc["DetailID" , currentRow].Value );
            if ( presId > 0 && detailId > 0 )
            {
                if ( MessageBox.Show( "该行明细已经保存，确定要删除？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                    return;

                ChargeControl chargeControl = new ChargeControl( this._currentPatient , Convert.ToInt32( currentUserEmployeeId ) );
                try
                {
                    chargeControl.DeletePrescriptionDetail( detailId );
                    if ( start == end )
                    {
                        chargeControl.DeletePrescription( presId );
                    }
                }
                catch ( Exception err )
                {
                    MessageBox.Show( "删除行不成功！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }
            }

            if ( start == end )
            {
                if ( subRow != -1 )
                {
                    dgvPresc.Rows.RemoveAt( subRow );
                }
                dgvPresc.Rows.RemoveAt( end );
            }
            else
            {
                dgvPresc.Rows.RemoveAt( currentRow );
                GetPrescriptionStartRowAndEndRow( end - 1 , out start , out end , out subRow );
                if ( subRow > 0 )
                    dgvPresc["TotalCost" , subRow].Value = CalcutePrescriptionCost( start );

            }
            lblTotal.Text = CalcuteAllPrescriptionCost( ).ToString( "#0.#0" );
        }

        private void menuDelPres_Click( object sender , EventArgs e )
        {
            if ( dgvPresc.Rows.Count == 0 )
                return;
            if ( MessageBox.Show( "确定要删除当前处方吗?" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                return;

            int start , end , subRow;
            int currentRow = dgvPresc.CurrentCell.RowIndex;

            int presId = dgvPresc["PrescID" , currentRow].Value == null ? 0 : Convert.ToInt32( dgvPresc["PrescID" , currentRow].Value );
            int detailId = dgvPresc["DetailID" , currentRow].Value == null ? 0 : Convert.ToInt32( dgvPresc["DetailID" , currentRow].Value );
            if ( presId > 0 && detailId > 0 )
            {
                ChargeControl chargeControl = new ChargeControl( this._currentPatient , Convert.ToInt32( currentUserEmployeeId ) );

                try
                {
                    chargeControl.DeletePrescription( presId );

                }
                catch ( Exception err )
                {
                    MessageBox.Show( "删除处方不成功！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }
            }

            GetPrescriptionStartRowAndEndRow( currentRow , out start , out end , out subRow );

            if ( subRow > 0 )
            {
                end = subRow;
            }
            for ( int i = end ; i >= start ; i-- )
            {
                dgvPresc.Rows.RemoveAt( i );
            }
        }

        private void btnPatient_Click( object sender , EventArgs e )
        {
            FrmPatientList fPatient = new FrmPatientList( );
            if ( fPatient.ShowDialog( ) == DialogResult.OK )
            {
                try
                {
                    _currentPatient = new OutPatient( fPatient.SelectedPatientListId );

                    txtPatName.Text = _currentPatient.PatientName;
                    cboSex.Text = _currentPatient.Sex;
                    cboPatType.SelectedValue = _currentPatient.MediType;
                    txtDoctor.MemberValue = _currentPatient.CureEmpCode;
                    lblDept.Tag = _currentPatient.CureDeptCode;
                    lblDept.Text = DataReader.GetDeptNameById( Convert.ToInt32( ( _currentPatient.CureDeptCode.Trim( ) == "" ? "0" : _currentPatient.CureDeptCode ) ) );
                    txtAge.Text = _currentPatient.Age.ToString( );
                    //显示未收费处方
                    Prescription[] prescriptions = _currentPatient.GetPrescriptions( PresStatus.未收费 , true );
                    ShowPrescriptions( prescriptions );

                    txtPatName.Enabled = false;
                    txtAge.Enabled = false;
                    cboPatType.Enabled = false;
                    cboSex.Enabled = false;
                    txtDoctor.Focus( );
                }
                catch
                {
                    MessageBox.Show( "发生错误" ,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }
                
            }
        }

        private void FrmCharge_KeyDown( object sender , KeyEventArgs e )
        {
            switch ( e.KeyCode )
            {
                case Keys.F2:
                    toolStripButton1_Click( null , null );
                    break;
                case Keys.F3:
                    btnNewPres_Click( null , null );
                    break;
                case Keys.F12:
                    btnClearInfo_Click( null , null );
                    break;
                case Keys.F8:
                    toolStripButton2_Click( null , null );
                    break;
            }
        }

        private void txtWorkUnit_AfterSelectedRow( object sender , object SelectedValue )
        {
            //if ( SelectedValue == null && txtWorkUnit.Text.Trim( ) != "" )
            //{
            //    if ( MessageBox.Show( "单位名称更不存在，是否添加？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes )
            //    {
                    
            //        string code = ( new BaseDataController( ) ).AddNewWorkUnit( txtWorkUnit.Text.Trim( ) , "" , "" );
            //        txtWorkUnit.MemberValue = code;
            //        dtbWorkUnit = DataReader.Get_WorkUnitList( );
            //        txtWorkUnit.SetSelectionCardDataSource( dtbWorkUnit );
            //    }
            //}
        }
    }
}
