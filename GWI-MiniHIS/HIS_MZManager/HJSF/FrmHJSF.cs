using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using HIS.MZ_BLL;
using HIS.SYSTEM.PubicBaseClasses;
using System.Collections;
using HIS.MZ_BLL.Exceptions;
using HIS.Interface;
using HIS.Interface.Structs;
using System.Reflection;

namespace HIS_MZManager.HJSF
{
    public partial class FrmHJSF :  GWI.HIS.Windows.Controls.BaseMainForm 
    {
        private const string subTotalString = "小   计：";
        private GWMHIS.BussinessLogicLayer.Classes.User currentUser;
        private GWMHIS.BussinessLogicLayer.Classes.Deptment currentDept;
        

        /// <summary>
        /// 当前类型
        /// </summary>
        private FormType _formType;
        /// <summary>
        /// 收费项目数据集
        /// </summary>
        private DataTable dtbChargeItems;
        /// <summary>
        /// 医生数据集
        /// </summary>
        private DataTable dtbDoctor;
        /// <summary>
        /// 就诊科室数据集
        /// </summary>
        private DataTable dtbDepartment;
        /// <summary>
        /// 门诊科室
        /// </summary>
        private DataTable dtbMZDepartment;
        /// <summary>
        /// 疾病
        /// </summary>
        private DataTable dtbDiesase;
        /// <summary>
        /// 工作单位
        /// </summary>
        private DataTable dtbWorkUnit;
        /// <summary>
        /// 当前操作的病人
        /// </summary>
        private HIS.MZ_BLL.OutPatient _currentPatient;
        /// <summary>
        /// 补偿打印内容
        /// </summary>
        //private DataTable tbPrintComp;
        /// <summary>
        /// 打印对象
        /// </summary>
        private DataTable tbTemplateDetail;
        /// <summary>
        /// 医生处方修改权限
        /// </summary>
        private Hashtable htDocPresEditItem;

        /// <summary>
        /// 清除信息以便新的录入(录入框和处方网格清空，当前病人对象置null)
        /// <param name="onlyClearText">true：仅清空录入文本框，false：清空录入文本框的同时病人对象也置null</param>
        /// </summary>
        private void ClearUIInfo(bool onlyClearText)
        {
            txtVisitNo.Text = "";
            txtPatientName.Text = "";
            cboSex.SelectedIndex = 1;
            txtAge.Text = "20";
            cboFeeType.SelectedIndex = 0;
            txtDoctor.Text = "";
            txtDoctor.MemberValue = null;
            txtDepartment.Text = "";
            txtDepartment.MemberValue = null;
            txtDiagnosis.Text = "";
            txtDiagnosisMemo.Text = "";
            txtDiagnosis.MemberValue = null;
            txtVisitNo.Focus( );
            txtWorkUnit.Text = "";
            txtWorkUnit.MemberValue = null;
            dgvPresc.Rows.Clear( );
            if ( !onlyClearText)
                _currentPatient = null;
        }
        /// <summary>
        /// 创建新病人
        /// </summary>
        private void CreateNewPatient()
        {
            ClearUIInfo( true  );
          #region 2003-03-25修改就诊号递增问题前的代码
            //if ( _currentPatient != null )
            //{
            //    _currentPatient = new HIS.MZ_BLL.OutPatient( _currentPatient.PatListID );
            //    if ( _currentPatient.PatientName.Trim( ) != "" )
            //    {
            //        //实例化当前病人对象
            //        _currentPatient = new HIS.MZ_BLL.OutPatient( );
            //        //注册新病人
            //        _currentPatient.NewRegister( );
            //    }
            //}
            //else
            //{
            //    //实例化当前病人对象
            //    _currentPatient = new HIS.MZ_BLL.OutPatient( );
            //    //注册新病人
            //    _currentPatient.NewRegister( );
            //}
            //txtPatientName.Enabled = true;
            //cboSex.Enabled = true;
            //cboFeeType.Enabled = true;
            //txtVisitNo.Text = "";  _currentPatient.PatListID.ToString();
            //txtPatientName.Focus( );
            //plLastInfo.Visible = false;
            #endregion

            //2003-03-25开始修改就诊号问题的代码
            //实例化当前病人对象,仅实例化。。不增加就诊记录
            _currentPatient = new HIS.MZ_BLL.OutPatient();                       
            txtPatientName.Enabled = true;
            cboSex.Enabled = true;
            cboFeeType.Enabled = true;
            txtVisitNo.Text = "";
            txtPatientName.Focus();
            plLastInfo.Visible = false;
            //End
        }
        /// <summary>
        /// 保存病人信息
        /// </summary>
        private bool SavePatientInfo()
        {
          #region 2003-03-25修改就诊号递增问题前的代码
            //if ( _currentPatient != null )
            //{
            //    //赋值病人信息
            //    _currentPatient.PatientName = txtPatientName.Text;
            //    _currentPatient.MediType = ( cboFeeType.SelectedIndex + 1 ).ToString( );
            //    _currentPatient.Sex = cboSex.Text;
            //    _currentPatient.CureEmpCode = txtDoctor.SelectedValue == null ? "" : txtDoctor.SelectedValue.ToString( );
            //    _currentPatient.CureDeptCode = txtDepartment.MemberValue == null ? "" : txtDepartment.SelectedValue.ToString( );
            //    _currentPatient.DiseaseCode = txtDepartment.SelectedValue == null ? "" : txtDiagnosis.SelectedValue.ToString( );
            //    _currentPatient.DiseaseName = txtDiagnosis.Text;
            //    if ( _currentPatient.UpdateRegister( ) )
            //    {
            //        return true;
            //    }
            //    else
            //    {
            //        return false;
            //    }
            //}
            //return false;
          #endregion
            if ( txtPatientName.Text.Trim() == "" )
            {
                MessageBox.Show( "病人姓名不能为空", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                txtPatientName.Focus();
                return false;
            }
            if ( txtAge.Text.Trim() == "" )
            {
                MessageBox.Show( "病人年龄不能为空", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                txtAge.Focus();
                return false;
            }
            if ( cboAgeUnit.Text.Trim( ) == "" )
            {
                MessageBox.Show( "病人年龄没有指定单位" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                cboAgeUnit.Focus( );
                return false;
                
            }
            if ( dgvPresc.Rows.Count == 0 )
            {
                if ( MessageBox.Show( "该病人没有可保存的处方，是否保存病人信息？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
                    return false;
            }
            if ( cboFeeType.Text == "" )
            {
                MessageBox.Show( "病人类型不能为空！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                cboFeeType.Focus( );
                return false;
            }

            if (txtAllergic.Text.Trim() == "")
            {
                if (Convert.ToInt16(OPDParamter.Parameters["019"]) == 1)
                {
                    MessageBox.Show("过敏史没有填写！", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            if ( _currentPatient != null )
            {
                #region 2003-03-25修改就诊号递增问题新增加的代码
                if ( _currentPatient.PatListID == 0 )
                {
                    //就诊号是0，说明是新病人，需要登记信息
                    _currentPatient.NewRegister();
                    txtVisitNo.Text = _currentPatient.VisitNo;
                }
                #endregion
                //赋值病人信息
                _currentPatient.PatientName = txtPatientName.Text;
                string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( _currentPatient.PatientName );
                _currentPatient.PYM = pywb[0];
                _currentPatient.WBM = pywb[1];
                _currentPatient.MediType = cboFeeType.SelectedValue.ToString( );
                if ( _currentPatient.Sex.Trim() == "" )
                    _currentPatient.Sex = cboSex.Text;
                _currentPatient.Age = Convert.ToInt32( txtAge.Text );
                if (_currentPatient.CureEmpCode.Trim() == "" )
                    _currentPatient.CureEmpCode = txtDoctor.MemberValue == null ? "" :  txtDoctor.MemberValue.ToString();
                if (_currentPatient.CureDeptCode.Trim() == "" )
                    _currentPatient.CureDeptCode = txtDepartment.MemberValue == null ? "" : txtDepartment.MemberValue.ToString();
                if (_currentPatient.DiseaseCode.Trim() == "")
                    _currentPatient.DiseaseCode = txtDiagnosis.MemberValue == null ? "" : txtDiagnosis.MemberValue.ToString();
                if (_currentPatient.DiseaseName.Trim() == "" )
                    _currentPatient.DiseaseName = txtDiagnosis.Text;
                _currentPatient.DiseaseMemo = txtDiagnosisMemo.Text;
                _currentPatient.CureDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
                _currentPatient.HpGrade = cboAgeUnit.Text;
                _currentPatient.Allergic = txtAllergic.Text;
                if ( txtWorkUnit.Text.Trim( ) != "" )
                {
                    _currentPatient.HpCode = txtWorkUnit.MemberValue == null ? "" : txtWorkUnit.MemberValue.ToString( );
                }
                else
                {
                    _currentPatient.HpCode = "";
                }
                if ( _currentPatient.UpdateRegister() )
                {
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
                _currentPatient = new OutPatient();
                SavePatientInfo();
                #endregion
            }
            return false;
        }
        /// <summary>
        /// 新开处方
        /// </summary>
        private int NewPrescription()
        {
            
            if ( _currentPatient == null )
            {
                if ( txtPatientName.Text.Trim() == "" )
                {
                    MessageBox.Show( "没有指定需要新开处方的病人", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
                    return -1;
                }
                else
                {
                    _currentPatient = new OutPatient();
                }
            }
            if ( txtDoctor.MemberValue == null || txtDoctor.Text.Trim()=="" )
            {
                MessageBox.Show( "新开处方前请先选择医生" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                txtDoctor.Focus( );
                return -1;
            }
            if ( txtDepartment.MemberValue == null )
            {
                MessageBox.Show( "新开处方前请先选择科室" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                txtDepartment.Focus( );
                return -1;
            }
            //if ( txtDiagnosis.MemberValue == null )
            //{
            //    MessageBox.Show( "新开处方前请选择诊断" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
            //    txtDiagnosis.Focus( );
            //    return -1;
            //}
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
                //MessageBox.Show( "没有可操作的处方" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                return false;
            }
            //--new-start-//
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
                    if ( row>=dgvPresc.Rows.Count )
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
        private void WriteSubTotalRow(int subTotalRow)
        {
            decimal presTotal = CalcutePrescriptionCost( subTotalRow );

            for ( int i = 0 ; i < dgvPresc.Columns.Count ; i++ )
            {
                if ( dgvPresc.Columns[i].Visible )
                {
                    if ( ( dgvPresc.Columns[i].GetType() == typeof( DataGridViewTextBoxColumn ) )
                        || dgvPresc.Columns[i].GetType().IsSubclassOf( typeof( DataGridViewTextBoxColumn ) ) )
                    {
                        dgvPresc[i, subTotalRow].Value = "";
                    }
                }
            }
            dgvPresc["Exec_dept", dgvPresc.Rows.Count - 1].Value = subTotalString;
            dgvPresc["TotalCost" , dgvPresc.Rows.Count - 1].Value = presTotal;
            dgvPresc["NO2" , dgvPresc.Rows.Count - 1].Tag = 1; /*注意在小计行的NO2列打标记为小计行*/
            dgvPresc.Rows[dgvPresc.Rows.Count - 1].Tag = 1;

            for ( int i = 0 ; i < dgvPresc.Columns.Count ; i++ )
            {
                dgvPresc[i , subTotalRow].Style.BackColor = Color.LightYellow;
                dgvPresc[i , subTotalRow].Style.Font = new Font( "宋体" , (float)11 , FontStyle.Bold );
                dgvPresc[i, subTotalRow].Style.ForeColor = Color.Red;
                if ( dgvPresc[i, subTotalRow].IsInEditMode )
                    dgvPresc.CancelEdit();
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
            int start, end, subRow;
            GetPrescriptionStartRowAndEndRow( RowIndex, out start, out end, out subRow );
            

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
        private void GetPrescriptionStartRowAndEndRow(int CurrentRowInex,out int startRowInex,out int endRowIndex,out int subTotalRowIndex)
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
                if ( i == dgvPresc.Rows.Count - 1 )
                {
                    if ( dgvPresc["NO2" , i].Tag == null )
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
            int start , end, subRow;
            GetPrescriptionStartRowAndEndRow( currentRowIndex , out start , out end ,out subRow );
            if ( dgvPresc["NO1" , end].Tag!=null && dgvPresc["NO1" , end].Tag.ToString( ) == "1" )
            {
                end = end - 1;
            }
            decimal subTotal = 0;
            
            //====begin 修改单张处方金额 wangzhi ====
            List<IPresDetail> lstDetail = new List<IPresDetail>();
            for ( int i = start ; i <= end ; i++ )
            {
                if ( dgvPresc["TotalCost" , i].Value != null )
                {
                    string bigitemCode = dgvPresc["STATITEM_CODE" , i].Value.ToString().Trim();
                    decimal total_fee = Convert.ToDecimal( dgvPresc["TotalCost" , i].Value );
                    PrescriptionDetail detail = new PrescriptionDetail();
                    detail.Tolal_Fee = total_fee;
                    detail.BigitemCode = bigitemCode;
                    lstDetail.Add( detail );
                }
            }

            subTotal = ( new PrescMoneyCalculate() ).GetPrescriptionTotalMoney( lstDetail );
            return subTotal;
            //====end 修改单张处方金额 wangzhi ====
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
            return Decimal.Round(sumTotal,1);
        }
        /// <summary>
        /// 根据文本获取指定的索引
        /// </summary>
        /// <param name="comboBoxText"></param>
        /// <param name="comboBox"></param>
        /// <returns></returns>
        private int GetComboxIndexByText( string comboBoxText , ComboBox comboBox )
        {
            for ( int i = 0 ; i < comboBox.Items.Count ; i++ )
            {
                if ( comboBox.Items[i].ToString( ) == comboBoxText )
                {
                    return i;
                }
            }
            return -1;
        }
        /// <summary>
        /// 根据ID获取科室名称
        /// </summary>
        /// <param name="DeptId"></param>
        /// <returns></returns>
        private string GetDeptNamebyID(string DeptId)
        {
            if ( DeptId.Trim( ) == "" )
                return "";

            DataRow[] drs = dtbDepartment.Select( "Dept_ID=" + DeptId.Trim() );
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
            DataRow[] drs = dtbChargeItems.Select( "item_id="+ItemID+" and complex_id=" + ComplexID + " and statitem_code='" + BigItemCode + "'" );
            if ( drs.Length > 0 )
                return drs[0]["Code"].ToString( ).Trim( );
            else
                return "";
        }
        /// <summary>
        /// 显示处方
        /// </summary>
        /// <param name="Prescriptions"></param>
        private void ShowPrescriptions(Prescription[] Prescriptions  )
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
                        dgvPresc["NO2",row].Value =  Convert.ToString(i+1);
                    dgvPresc["CODE" , row].Value = GetItemCodeByID( Prescriptions[i].PresDetails[j].ItemId , Prescriptions[i].PresDetails[j].ComplexId , Prescriptions[i].PresDetails[j].BigitemCode );
                    dgvPresc["Item_Name",row].Value = Prescriptions[i].PresDetails[j].Itemname;
                    dgvPresc["Standard",row].Value = Prescriptions[i].PresDetails[j].Standard;
                    dgvPresc[ "Price",row].Value = Prescriptions[i].PresDetails[j].Sell_price;
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
                    
                    dgvPresc[ "PresAmount",row].Value = Prescriptions[i].PresDetails[j].PresAmount;
                    dgvPresc["EXEC_DEPT" , row].Value = GetDeptNamebyID ( Prescriptions[i].ExecDeptCode );
                    dgvPresc["EXEC_DEPT" , row].Tag = Prescriptions[i].ExecDeptCode;
                    dgvPresc["TotalCost",row].Value = Prescriptions[i].PresDetails[j].Tolal_Fee;
                    dgvPresc["Item_ID",row].Value = Prescriptions[i].PresDetails[j].ItemId;
                    dgvPresc[ "STATITEM_CODE",row].Value = Prescriptions[i].PresDetails[j].BigitemCode;
                    dgvPresc[ "Complex_Id",row].Value = Prescriptions[i].PresDetails[j].ComplexId;
                    dgvPresc[ "HJXS",row].Value = Prescriptions[i].PresDetails[j].RelationNum;
                    dgvPresc["PrescDoctor" , row].Value = Prescriptions[i].PresDocCode;
                    dgvPresc["PrescDept" , row].Value = Prescriptions[i].PresDeptCode;
                    dgvPresc["Selected" , row].Value =  (short)1;
                    dgvPresc["Modified" , row].Value = Prescriptions[i].DocPresId>0 ? 1 : 0 ;
                    //dgvPresc[PrescDoctorName.Name, row].Value = PublicDataReader.GetEmployeeNameById( Convert.ToInt32( Prescriptions[i].PresDocCode) );
                    dgvPresc[PrescDoctorName.Name, row].Value = BaseDataController.GetName( BaseDataCatalog.人员列表, Convert.ToInt32( Prescriptions[i].PresDocCode ) );
                    dgvPresc[DocPresId.Name, row].Value = Prescriptions[i].DocPresId;
                    dgvPresc[DocPresDetailId.Name, row].Value = Prescriptions[i].PresDetails[j].DocPrescDetailId;
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
            if ( _currentPatient == null )
            {
                MessageBox.Show( "没有可操作的病人" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return false;
            }
            if ( txtPatientName.Text.Trim( ) == "" )
            {
                MessageBox.Show( "病人姓名不能为空" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                txtPatientName.Focus( );
                return false;
            }

            //if ( txtDoctor.MemberValue == null || txtDoctor.MemberValue.ToString() == "" )
            //{
            //    MessageBox.Show( "就诊医生选择不正确！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            //    txtDoctor.Focus( );
            //    return false;
            //}

            //if ( txtDepartment.MemberValue == null || txtDepartment.MemberValue.ToString() == "" )
            //{
            //    MessageBox.Show( "就诊科室选择不正确！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            //    txtDepartment.Focus( );
            //    return false;
            //}
            #endregion
            for ( int i = 0 ; i < dgvPresc.Rows.Count ; i++ )
            {
                int start, end, subRow;
                GetPrescriptionStartRowAndEndRow( i, out start, out end, out subRow );
                if ( i==subRow )
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
                    if ( dgvPresc["ITEM_ID", i].Value == null || dgvPresc["ITEM_ID", i].Value.ToString() == "" )
                    {
                        MessageBox.Show( "第" + row.ToString() + "行没有药品或项目内容", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        dgvPresc.CurrentCell = dgvPresc["CODE", i];
                        return false;
                    }
                    if ( dgvPresc["EXEC_DEPT", i].Tag == null || dgvPresc["EXEC_DEPT", i].Value.ToString() == "" || dgvPresc["EXEC_DEPT", i].Value == null )
                    {
                        MessageBox.Show( "第" + row.ToString() + "行执行科室填写不正确", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        return false;
                    }
                    if ( dgvPresc[PrescDoctor.Name , i].Value == null || dgvPresc[PrescDoctor.Name , i].Value.ToString( ) == "" ||
                        dgvPresc[PrescDoctorName.Name , i].Value == null || dgvPresc[PrescDoctorName.Name , i].Value.ToString( ) == "" )
                    {
                        MessageBox.Show( "第" + row.ToString( ) + "行开方医生填写不正确" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                        return false;
                    }
                    try
                    {
                        int packNum = dgvPresc["PACK_NUM", i].Value == null ? 0 : Convert.ToInt32( dgvPresc["PACK_NUM", i].Value );
                        int baseNum = dgvPresc["BASE_NUM", i].Value == null ? 0 : Convert.ToInt32( dgvPresc["BASE_NUM", i].Value );
                        if ( packNum == 0 && baseNum == 0 )
                        {
                            MessageBox.Show( "第" + row.ToString() + "行数量为0", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                            dgvPresc.CurrentCell = dgvPresc["BASE_NUM", i];
                            return false;
                        }

                        if ( packNum < 0 || baseNum < 0 )
                        {
                            MessageBox.Show( "第" + row.ToString() + "行数量必须大于0", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                            dgvPresc.CurrentCell = dgvPresc["BASE_NUM", i];
                            return false;
                        }
                    }
                    catch
                    {
                        MessageBox.Show( "第" + row.ToString() + "行输入不正确，该处只允许输入整数", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        dgvPresc.CurrentCell = dgvPresc["BASE_NUM", i];
                        return false;
                    }

                    decimal PresAmount = dgvPresc["PresAmount", i].Value == null ? 0 : Convert.ToDecimal( dgvPresc["PresAmount", i].Value );
                    if ( PresAmount <= 0 )
                    {
                        MessageBox.Show( "第" + row.ToString() + "行付数填写不正确(必须为大于0的整数)", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        dgvPresc.CurrentCell = dgvPresc["PresAmount", i];
                        return false;
                    }
                    if ( !HIS.SYSTEM.PubicBaseClasses.XcConvert.IsInteger( PresAmount.ToString() ) )
                    {
                        MessageBox.Show( "第" + row.ToString() + "行付数必须为整数", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        dgvPresc.CurrentCell = dgvPresc["PresAmount", i];
                        return false;
                    }
                    decimal totalCost = dgvPresc["TotalCost", i].Value == null ? 0 : Convert.ToDecimal( dgvPresc["TotalCost", i].Value );
                    if ( totalCost == 0 )
                    {
                        MessageBox.Show( "第" + row.ToString() + "行金额为0", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        dgvPresc.CurrentCell = dgvPresc["BASE_NUM", i];
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

            int start, end, subRow;
            int currentRowIndex = dgvPresc.CurrentRow.Index;

            GetPrescriptionStartRowAndEndRow( currentRowIndex, out start, out end, out subRow );

            if ( currentRowIndex == subRow )
            {
                for ( int i = 0; i < dgvPresc.Columns.Count; i++ )
                {
                    dgvPresc.Columns[i].ReadOnly = true;
                }
                return;
            }
            else
            {
                dgvPresc.Columns["CODE"].ReadOnly = false;
                dgvPresc.Columns["PACK_NUM"].ReadOnly = false;
                dgvPresc.Columns["BASE_NUM"].ReadOnly = false;
                dgvPresc.Columns["PresAmount"].ReadOnly = false;
                dgvPresc.Columns["EXEC_DEPT"].ReadOnly = true;
            }

            int docPresId = Convert.IsDBNull( dgvPresc[DocPresId.Name, currentRowIndex].Value ) ? -1 : Convert.ToInt32( dgvPresc[DocPresId.Name, currentRowIndex].Value );
            if ( docPresId > 0 )
            {
                dgvPresc.Columns["CODE"].ReadOnly = true;
                dgvPresc.Columns["PACK_NUM"].ReadOnly = true;
                dgvPresc.Columns["BASE_NUM"].ReadOnly = true;
                dgvPresc.Columns["PresAmount"].ReadOnly = true;
                dgvPresc.Columns["EXEC_DEPT"].ReadOnly = true;
                txtDoctor.Enabled = false;
                txtDepartment.Enabled = false;
                txtDiagnosis.Enabled = false;
                txtDiagnosisMemo.Enabled = false;
                btnEditName.Enabled = false;
                
                if ( dgvPresc["STATITEM_CODE" , currentRowIndex].Value == null )
                    return;
                if ( Convert.ToInt32( HIS.MZ_BLL.OPDParamter.Parameters["018"] ) == 1 )
                {
                    string code = dgvPresc["STATITEM_CODE" , currentRowIndex].Value.ToString().Trim();
                    if ( htDocPresEditItem.ContainsKey( code ) )
                    {
                        if ( Convert.ToInt32( htDocPresEditItem[code] ) == 1 )
                        {
                            dgvPresc.Columns["PACK_NUM"].ReadOnly = false;
                            dgvPresc.Columns["BASE_NUM"].ReadOnly = false;
                        }
                    }
                    else
                    {
                        return;
                    }
                }


                return;
            }
            else
            {
                dgvPresc.Columns["CODE"].ReadOnly = false;
                dgvPresc.Columns["PACK_NUM"].ReadOnly = false;
                dgvPresc.Columns["BASE_NUM"].ReadOnly = false;
                dgvPresc.Columns["PresAmount"].ReadOnly = false;
                dgvPresc.Columns["EXEC_DEPT"].ReadOnly = true;

                txtDoctor.Enabled = true;
                txtDepartment.Enabled = true;
                txtDiagnosis.Enabled = true;
                txtDiagnosisMemo.Enabled = true;
                btnEditName.Enabled = true;
            }
            
            if ( dgvPresc["STATITEM_CODE" , currentRowIndex].Value == null )
                return;
            string stat_item_code = dgvPresc["STATITEM_CODE" , currentRowIndex].Value.ToString().Trim();
            if ( stat_item_code == "01" || stat_item_code == "02" )
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
            if ( Convert.ToInt16( OPDParamter.Parameters["013"] ) == 1 )
            {
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
        }
        /// <summary>
        /// 得到选中的处方(如果未选中的处方明细为null)
        /// </summary>
        /// <returns></returns>
        private Prescription[] GetPrescriptionFromGrid(bool allPrescription)
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
                prescriptions[presIndex].PatientID = _currentPatient.PatID;
                prescriptions[presIndex].RegisterID = _currentPatient.PatListID;
                prescriptions[presIndex].PresCostCode = currentUser.EmployeeID.ToString( );
                prescriptions[presIndex].PresDeptCode = _currentPatient.CureDeptCode;
                prescriptions[presIndex].PresDocCode = _currentPatient.CureEmpCode;
                prescriptions[presIndex].Record_Flag = 0;
                prescriptions[presIndex].Charge_Flag = 0;
                prescriptions[presIndex].Drug_Flag = 0;
                prescriptions[presIndex].Total_Fee = 0;
                prescriptions[presIndex].PresDate = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;

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
                    prescriptions[presIndex].PresDetails[detailIndex] = new PrescriptionDetail();
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
                        case "00":
                            prescriptions[presIndex].PrescType = "0";
                            break;
                        default:
                            prescriptions[presIndex].PrescType = "-1";
                            break;
                    }
                    #endregion
                    prescriptions[presIndex].DocPresId = Convert.IsDBNull( dgvPresc[DocPresId.Name, i].Value ) ? 0 : Convert.ToInt32( dgvPresc[DocPresId.Name, i].Value );
                    prescriptions[presIndex].PresDocCode = (dgvPresc[PrescDoctor.Name, i].Value == null ? txtDoctor.MemberValue.ToString() : dgvPresc[PrescDoctor.Name, i].Value.ToString());
                    prescriptions[presIndex].PresDeptCode = ( dgvPresc[PrescDept.Name , i].Value == null ? txtDepartment.MemberValue.ToString( ) : dgvPresc[PrescDept.Name , i].Value.ToString( ) );
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
                    prescriptions[presIndex].PresDetails[detailIndex].DocPrescDetailId = Convert.IsDBNull(dgvPresc[DocPresDetailId.Name, i].Value) ? 0 : Convert.ToInt32(dgvPresc[DocPresDetailId.Name, i].Value);
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
                List<PrescriptionDetail> details = new List<PrescriptionDetail>();
                if ( prescriptions[presIndex].PresDetails != null )
                    details = prescriptions[presIndex].PresDetails.ToList( );
                for ( int i = 0 ; i < details.Count ; i++ )
                {
                    if ( details[i].ItemId == 0 )
                        details.Remove( details[i] );
                }
                if ( details.Count != 0 )
                    prescriptions[presIndex].PresDetails = details.ToArray( );
                else
                    prescriptions[presIndex].PresDetails = null;
                currentRow = subRow + 1;
            }
            #endregion

            return prescriptions;
        }
        /// <summary>
        /// 保存处方处理过程
        /// </summary>
        private void SavePrescriptionEvent()
        {
            if ( PrescriptionValidate() )
            {
                if ( SavePatientInfo() )
                {
                    dgvPresc.EndEdit();
                    if ( EndPrescription() )
                    {
                        if ( PrescriptionValidate() )
                        {
                            Prescription[] prescriptions;
                            //保存处方
                            if ( SavePrescription( out prescriptions ) == false )
                            {
                                return;
                            }
                            //重新显示处方
                            prescriptions = _currentPatient.GetPrescriptions( HIS.MZ_BLL.PresStatus.未收费, _formType == FormType.门诊划价 ? false : true );
                            ShowPrescriptions( prescriptions );
                        }
                    }
                }
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
            #region 药品处方库存判断 
            for ( int i = 0 ; i < prescriptions.Length ; i++ )
            {
                if ( prescriptions[i].PresDetails != null )
                {
                    for ( int j = 0 ; j < prescriptions[i].PresDetails.Length  ; j++ )
                    {
                        if ( prescriptions[i].PresDetails[j].Tolal_Fee == 0 )
                        {
                            MessageBox.Show( "有0金额的项目，不能保存！" );
                            return false;
                        }
                        if ( prescriptions[i].PresDetails[j].BigitemCode.Trim( ) == "01" || prescriptions[i].PresDetails[j].BigitemCode.Trim( ) == "02" ||
                            prescriptions[i].PresDetails[j].BigitemCode.Trim( ) == "03" )
                        {
                            decimal sellprice , buyprice , storevalue;
                            decimal inputValue = prescriptions[i].PresDetails[j].Amount * prescriptions[i].PresDetails[j].PresAmount;
                            if ( !PublicDataReader.StoreExists( prescriptions[i].PresDetails[j].ItemId , prescriptions[i].ExecDeptCode , inputValue ,
                                out sellprice , out buyprice , out storevalue ) )
                            {
                                storevalue = storevalue / prescriptions[i].PresDetails[j].RelationNum;
                                inputValue = prescriptions[i].PresDetails[j].Amount * prescriptions[i].PresDetails[j].PresAmount / prescriptions[i].PresDetails[j].RelationNum;
                                string base_unit = prescriptions[i].PresDetails[j].Unit;
                                DialogResult dlg = MessageBox.Show( "【" + prescriptions[i].PresDetails[j].Itemname + "】所需数量大于当前库存，是否继续？\r\n当前库存：" + storevalue.ToString( "0.00" ) + base_unit + ",输入的数量：" + inputValue.ToString( "0.00" ) + base_unit , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question );
                                if ( dlg == DialogResult.No )
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }
            }
            #endregion
            HIS.MZ_BLL.ChargeControl chargeControl = new HIS.MZ_BLL.ChargeControl( _currentPatient, Convert.ToInt32( currentUser.EmployeeID ) );

            try
            {
                //保存处方
                chargeControl.SavePrescription( prescriptions );

                savedPrescriptions = prescriptions;
                return true;
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return false;
            }

        }
        
        /// <summary>
        /// 处方收银事件
        /// </summary>
        private void PrescriptionChargeEvent()
        {
            if ( PrescriptionValidate() )
            {
                if ( SavePatientInfo() == false )
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
                //加入验证,如果有医生站处方，并且追加了录入的处方,要求先保存
                #region .....
                bool hasDocPresc = false;
                bool selectedAll = true;
                //int start , end , subtotalrow;
                for ( int i = 0 ; i < dgvPresc.Rows.Count ; i++ )
                {
                    if ( dgvPresc.Rows[i].Tag != null )
                        continue;
                    if ( Convert.ToInt32( dgvPresc[DocPresId.Name , i].Value ) != 0 )
                    {
                        hasDocPresc = true;
                        break;
                    }
                }
                for ( int i = 0 ; i < dgvPresc.Rows.Count ; i++ )
                {
                    if ( dgvPresc.Rows[i].Tag != null )
                        continue;
                    if ( Convert.ToInt32( dgvPresc["Selected" , i].Value ) == 0 &&
                        Convert.ToInt32( dgvPresc[DocPresId.Name , i].Value ) == 0 
                        && Convert.ToInt32( dgvPresc[DetailID.Name,i].Value )==0 )
                    {
                        selectedAll = false;
                        break;
                    }
                }
                if ( hasDocPresc && !selectedAll )
                {
                    MessageBox.Show( "在有医生站处方并且部分收费的情况下，请先保存新增的划价处方" ,"",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return;
                }
                #endregion

                Prescription[] prescriptions;
                //保存处方
                if ( SavePrescription( out prescriptions ) )
                {
                    //取出选中的处方
                    Prescription[] selectedPrescriptions = GetPrescriptionFromGrid( false );
                    for ( int i = 0; i < prescriptions.Length; i++ )
                    {
                        if ( selectedPrescriptions[i].PresDetails != null )
                        {
                            selectedPrescriptions[i].PrescriptionID = prescriptions[i].PrescriptionID;
                            for ( int j = 0; j < selectedPrescriptions[i].PresDetails.Length; j++ )
                            {
                                selectedPrescriptions[i].PresDetails[j].PresctionId = prescriptions[i].PresDetails[j].PresctionId;
                                selectedPrescriptions[i].PresDetails[j].DetailId = prescriptions[i].PresDetails[j].DetailId;
                            }
                        }
                    }
                    //过滤掉没有选择的处方
                    List<Prescription> presTmp = new List<Prescription>();
                    for ( int i = 0; i < selectedPrescriptions.Length; i++ )
                    {
                        if ( selectedPrescriptions[i].PresDetails != null )
                        {
                            presTmp.Add( selectedPrescriptions[i] );
                        }
                    }
                    selectedPrescriptions = new Prescription[presTmp.Count];
                    for ( int i = 0; i < presTmp.Count; i++ )
                        selectedPrescriptions[i] = presTmp[i];
                    if ( selectedPrescriptions.Length == 0 )
                    {
                        MessageBox.Show( "没有选择要收费的处方！", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
                        return;
                    }
                    //判断处方数是否大于可用发票数
                    int usableBallot = HIS.MZ_BLL.InvoiceManager.GetInvoiceNumberOfCanUse( OPDBillKind.门诊收费发票 , Convert.ToInt32( currentUser.EmployeeID ) );

                    ChargeType chargeType = ChargeType.多张处方一次结算;
                    if ( usableBallot < selectedPrescriptions.Length && chargeType == ChargeType.一张处方一次结算 )
                    {
                        MessageBox.Show( "当前需要收费的处方有" + selectedPrescriptions.Length + "张，可用发票只有" + usableBallot + "张，请先分配发票！", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        return;
                    }
                    //进行收费处理过程
                    ChargeProcess( selectedPrescriptions );

                    //重新读取未收费的处方
                    Prescription[] notChargePres = _currentPatient.GetPrescriptions( HIS.MZ_BLL.PresStatus.未收费, true );
                    if ( notChargePres.Length > 0 )
                        ShowPrescriptions( notChargePres );
                    else
                    {
                        ClearUIInfo( false );
                        plLastInfo.Visible = true;
                    }
                    string perfCode = "";
                    string invoiceNo = HIS.MZ_BLL.InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票 , Convert.ToInt32( currentUser.EmployeeID ) , true , out perfCode );
                    txtCurrentInvoiceNo.Text = HIS.MZ_BLL.InvoiceManager.FormatInvoiceNo( invoiceNo );
                }
            }
        }
        /// <summary>
        /// 收费处理的完整过程（预算->反馈预算信息->正式结算->打印发票）
        /// </summary>
        /// <param name="prescriptions"></param>
        private bool ChargeProcess( Prescription[] prescriptions )
        {

            //实例化收费对象
            HIS.MZ_BLL.ChargeControl chargeControl = new HIS.MZ_BLL.ChargeControl( _currentPatient, Convert.ToInt32( currentUser.EmployeeID ) );
            //结算信息
            HIS.MZ_BLL.ChargeInfo[] chargeInfos = new HIS.MZ_BLL.ChargeInfo[prescriptions.Length];

            #region 预算
            try
            {
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                chargeInfos = chargeControl.Budget( prescriptions );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return false;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
            #endregion

            #region 合计结算信息并显示给用户
            //累计结算信息
            HIS.MZ_BLL.ChargeInfo totalChargeInfo = new HIS.MZ_BLL.ChargeInfo();
            Hashtable htTotalItems = new Hashtable( );
            for ( int i = 0; i < chargeInfos.Length; i++ )
            {
                totalChargeInfo.TotalFee += chargeInfos[i].TotalFee;
                totalChargeInfo.FavorFee += chargeInfos[i].FavorFee;
                totalChargeInfo.SelfFee += chargeInfos[i].SelfFee;
                totalChargeInfo.VillageFee += chargeInfos[i].VillageFee;
                totalChargeInfo.SelfTally += totalChargeInfo.SelfTally;
            }
            
            //向用户展示结算信息
            FrmChargeInfo frmChargeInfo = new FrmChargeInfo( totalChargeInfo );
            if ( frmChargeInfo.ShowDialog() == DialogResult.Cancel )
            {
                chargeControl.CancelCharge();
                return false;
            }
            #endregion

            //医保或农合记账
            decimal insurPay =  frmChargeInfo.ReturnChargeInfo.VillageFee ;
            //个人记账
            decimal selfTally = frmChargeInfo.ReturnChargeInfo.SelfTally ;
            //POS
            decimal posPay = frmChargeInfo.ReturnChargeInfo.PosFee;
            //现金
            decimal cashPay = frmChargeInfo.ReturnChargeInfo.TotalFee - insurPay - selfTally - posPay - frmChargeInfo.ReturnChargeInfo.FavorFee;
            //处方数
            int presCount = chargeInfos.Length;

            if ( presCount > 1 )
            {
                bool mulitPay = false;
                if ( insurPay > 0 && ( selfTally > 0 || posPay > 0 || cashPay > 0 ) )
                    mulitPay = true;
                else if ( selfTally > 0 && ( insurPay > 0 || posPay > 0 || cashPay > 0 ) )
                    mulitPay = true;
                else if ( posPay > 0 && ( selfTally > 0 || insurPay > 0 || cashPay > 0 ) )
                    mulitPay = true;
                else if ( cashPay > 0 && ( selfTally > 0 || posPay > 0 || insurPay > 0 ) )
                    mulitPay = true;

                if ( mulitPay )
                {
                    MessageBox.Show( "多张处方一次收费只能有一种支付方式！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    return false;
                }
            }

            

            //Console.Write( "" );

            ////防止在允许收手工录入医保支付或农合补偿金额情况下结算多张处方,
            //if ( frmChargeInfo.ReturnChargeInfo.VillageFee > 0 && chargeInfos.Length > 1 && Convert.ToInt16( HIS.MZ_BLL.OPDParamter.Parameters["002"] ) == 0 )
            //{
            //    MessageBox.Show( "如果是手工录入的农合补偿金额，每次只能结算一张处方！", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
            //    return false;
            //}

            chargeControl.SetChargeInfoPay( ref chargeInfos , frmChargeInfo.ReturnChargeInfo.VillageFee ,
                                                                   frmChargeInfo.ReturnChargeInfo.PosFee ,
                                                                   frmChargeInfo.ReturnChargeInfo.CashFee,
                                                                   frmChargeInfo.ReturnChargeInfo.SelfTally );
            try
            {
                Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor();
                //正式结算
                Invoice[] invoicies;
                chargeControl.Charge( chargeInfos , prescriptions , out invoicies );

                //打印发票
                try
                {
                    for ( int i = 0 ; i < invoicies.Length ; i++ )
                        invoicies[i].InvoiceNo = HIS.MZ_BLL.InvoiceManager.FormatInvoiceNo( invoicies[i].InvoiceNo );
                    PrintController.PrintChargeInvoice( invoicies  );
                }
                catch ( Exception printErr )
                {
                    MessageBox.Show( printErr.Message, "打印发票错误", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
                ShowLastChargeInfo( _currentPatient.PatientName, chargeInfos.Length, totalChargeInfo.TotalFee,
                    frmChargeInfo.ActPay, frmChargeInfo.ReturnMoney, frmChargeInfo.ReturnChargeInfo.VillageFee,
                    frmChargeInfo.ReturnChargeInfo.FavorFee, frmChargeInfo.ReturnChargeInfo.SelfFee, frmChargeInfo.ReturnChargeInfo.PosFee ,frmChargeInfo.ReturnChargeInfo.SelfTally);
                return true;
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
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
        private void ShowLastChargeInfo(string PatName,int InvoiceCount,decimal TotalCost,decimal ActPay,decimal ReturnMoney,decimal TallyPay,decimal PerMoney,decimal SelfPay,decimal PosPay,decimal SelfTallyPay)
        {
            lblPatName.Text = PatName;
            lblInvoiceCount.Text = InvoiceCount.ToString( );
            lblPresTotalCost.Text = TotalCost.ToString( "#0.#0");
            lblActPay.Text = ActPay.ToString( "#0.#0" );
            lblReturnMoney.Text = ReturnMoney.ToString( "#0.#0" );
            lblTally.Text = TallyPay.ToString( "#0.#0" );
            lblPerMoney.Text = PerMoney.ToString( "#0.#0" );
            lblSelfPay.Text = SelfPay.ToString( "#0.#0" );
            lblPOS.Text = PosPay.ToString( "#0.#0" );
            lblSelfTally.Text = SelfTallyPay.ToString( "#0.#0" );
        }
        /// <summary>
        /// 检查病人就诊时间是否有效
        /// </summary>
        /// <returns></returns>
        private bool CheckExistsVisitDate()
        {
            int existsDay = 7;
            if ( HIS.MZ_BLL.OPDParamter.Parameters["011"] != null )
                existsDay = Convert.ToInt32( HIS.MZ_BLL.OPDParamter.Parameters["011"] );
            int day = ( HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime - _currentPatient.CureDate ).Days;
            if ( day > existsDay )
            {
                MessageBox.Show( "该病人是" + day + "天前就诊，已超出有效天数(" + existsDay + "天)", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return false ;
            }
            else
                return true;
        }
        /// <summary>
        /// 显示病人信息
        /// </summary>
        private void ShowPatientInfo()
        {
            try
            {
                txtVisitNo.Text = _currentPatient.VisitNo;
                txtPatientName.Text = _currentPatient.PatientName;
                cboSex.SelectedIndex = GetComboxIndexByText( _currentPatient.Sex , cboSex );
                txtAge.Text = _currentPatient.Age.ToString( );
                cboFeeType.SelectedIndex = _currentPatient.MediType == "" ? -1 : Convert.ToInt32( _currentPatient.MediType ) - 1;
                txtDoctor.MemberValue = _currentPatient.CureEmpCode;
                txtDepartment.MemberValue = _currentPatient.CureDeptCode;
                txtDiagnosis.Text = _currentPatient.DiseaseName;
                txtDiagnosis.MemberValue = _currentPatient.DiseaseCode;
                txtDiagnosisMemo.Text = _currentPatient.DiseaseMemo;
                txtWorkUnit.MemberValue = _currentPatient.HpCode;
                cboAgeUnit.Text = _currentPatient.HpGrade;
                txtPatientName.Enabled = false;
                txtAllergic.Text = _currentPatient.Allergic;
            }
            catch
            {
            }
            Prescription[] prescriptions = _currentPatient.GetPrescriptions( HIS.MZ_BLL.PresStatus.未收费 , _formType == FormType.门诊划价 ? false : true , _formType == FormType.门诊划价 ? Convert.ToInt32( currentDept.DeptID ) : 0 );

            ShowPrescriptions( prescriptions );

            if ( prescriptions.Length == 0 )
            {
                if ( txtDoctor.MemberValue != null && txtDoctor.MemberValue.ToString() !="" )
                {
                    if ( txtDepartment.MemberValue != null && txtDepartment.MemberValue.ToString() != "" )
                    {
                        if ( txtDiagnosis.MemberValue != null && txtDiagnosis.MemberValue.ToString() != "" )
                        {
                            txtDiagnosisMemo.Focus( );
                        }
                        else
                        {
                            txtDiagnosis.Focus( );
                        }
                    }
                    else
                    {
                        txtDepartment.Focus( );
                    }
                }
                else
                {
                    txtDoctor.Focus( );
                }
            }
        }
        /// <summary>
        /// 获取选项卡样式
        /// </summary>
        /// <returns></returns>
        protected GWI.HIS.Windows.Controls.SelectionCardTypes GetSelectionCardType()
        {
            GWI.HIS.Windows.Controls.SelectionCardTypes selectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
            string typeName = UserCustomSetting.GetPrescriptionShowCardType( currentUser.LoginCode.ToString( ) );
            if ( typeName.Trim( ) == "" )
            {
                return selectionCardType;
            }
            else
            {
                foreach ( object obj in Enum.GetValues( typeof( GWI.HIS.Windows.Controls.SelectionCardTypes ) ) )
                {
                    if ( obj.ToString( ) == typeName )
                    {
                        return (GWI.HIS.Windows.Controls.SelectionCardTypes)obj;
                    }
                }
            }
            return selectionCardType;
        }
        
        /// <summary>
        /// 是否包含医生站处方
        /// </summary>
        /// <returns></returns>
        private bool IncludeDoctorStationPrescription()
        {
            for ( int i = 0 ; i < dgvPresc.Rows.Count ; i++ )
            {
                int docPrescId = dgvPresc[DocPresId.Name , i].Value == null ? 0 : Convert.ToInt32( dgvPresc[DocPresId.Name , i].Value );
                if ( docPrescId > 0 )
                {
                    return true;
                }
            }

            return false;
        }

        public FrmHJSF( string FormText , FormType formType , GWMHIS.BussinessLogicLayer.Classes.User CurrentUser , GWMHIS.BussinessLogicLayer.Classes.Deptment CurrentDept )
        {
            currentUser = CurrentUser;

            currentDept = CurrentDept;

            InitializeComponent( );

            this.Text = FormText;

            _formType = formType;

            this.FormTitle = this.Text;

            if ( formType == FormType.门诊划价 || formType == FormType.门诊医生 )
            {
                btnBalance.Visible = false;
                btnCancelBlance.Visible = false;
                button1.Enabled = false;
                label1.Visible = false;
            }
 
        }

        private void FrmHJSF_Load( object sender , EventArgs e )
        {
            GetSelectionCardType( );
            //第一次加载数据，根据功能决定是否加载药品
            dtbChargeItems = HIS.MZ_BLL.PublicDataReader.GetItemSelectedCardDataSource( _formType == FormType.门诊划价 ? 0 : 1 );
            //如果是药房划价，过滤执行科室（当前的执行科室是药房）
            if ( _formType == FormType.门诊划价 )
            {
                DataRow[] drs = dtbChargeItems.Copy().Select("EXEC_DEPT_CODE='" + currentDept.DeptID.ToString() + "'");
                dtbChargeItems.Rows.Clear();
                for ( int row = 0; row < drs.Length; row++ )
                    dtbChargeItems.Rows.Add( drs[row].ItemArray );
            }
            dgvPresc.SetSelectionCardDataSource( dtbChargeItems, "CODE" );

            dtbDepartment = BaseDataController.BaseDataSet[BaseDataCatalog.科室列表];
            dtbMZDepartment = BaseDataController.BaseDataSet[BaseDataCatalog.科室列表];
            dtbDiesase = BaseDataController.BaseDataSet[BaseDataCatalog.疾病诊断列表];
            dtbDoctor = BaseDataController.BaseDataSet[BaseDataCatalog.医生列表];
            tbTemplateDetail = BaseDataController.BaseDataSet[BaseDataCatalog.划价模板明细列表];


            txtDoctor.SetSelectionCardDataSource( dtbDoctor );
            txtDepartment.SetSelectionCardDataSource( dtbMZDepartment.Copy() );
            txtDiagnosis.SetSelectionCardDataSource( dtbDiesase );
            //限制就诊号录入长度
            txtVisitNo.MaxLength  = Convert.ToInt32( HIS.MZ_BLL.OPDParamter.Parameters["005"] );
            //限制姓名录入长度
            txtPatientName.MaxLength = Convert.ToInt32( HIS.MZ_BLL.OPDParamter.Parameters["006"] );            
            //检测发票打印配置
            if ( PrintController.ChargeInvocieTemplateExists( )==false && _formType == FormType.门诊收费 )
            {
                MessageBox.Show( "门诊发票模板不存在！请先从门诊参数设置界面设置好发票模板再试！","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                toolStrip1.Enabled = false;
                this.KeyDown-=new KeyEventHandler(FrmHJSF_KeyDown);
            }
            //获取对医生处方的项目编辑权限
            DataTable tbDocPresEditItem = PublicDataReader.Get_PresDoc_EditItem();
            htDocPresEditItem = new Hashtable();
            for ( int i = 0 ; i < tbDocPresEditItem.Rows.Count ; i++ )
                htDocPresEditItem.Add( tbDocPresEditItem.Rows[i]["CODE"].ToString().Trim() , Convert.ToInt32( tbDocPresEditItem.Rows[i]["ALLOW_EDIT"] ) );

            cboFeeType.DisplayMember = "NAME";
            cboFeeType.ValueMember = "PATTYPECODE";
            //cboFeeType.DataSource = PublicDataReader.PatientTypeList;
            cboFeeType.DataSource = BaseDataController.BaseDataSet[BaseDataCatalog.病人类型列表];
            if ( cboFeeType.Items.Count > 0 )
                cboFeeType.SelectedIndex = 0;
            cboSex.SelectedIndex = 1;

            //dtbWorkUnit = PublicDataReader.Get_WorkUnitList( );
            dtbWorkUnit = BaseDataController.BaseDataSet[BaseDataCatalog.工作单位列表];
            txtWorkUnit.SetSelectionCardDataSource( dtbWorkUnit );
            cboAgeUnit.Text = "岁";

            #region user custom property
            //设置用户自定义的网格字体大小
            string grdFontSize = HIS.MZ_BLL.UserCustomSetting.GetPrescriptionGridFontSize( currentUser.LoginCode );
            if ( grdFontSize.Trim() == "" )
            {
                dgvPresc.Font = new Font( "宋体", (float)10 );
            }
            else
            {
                if ( HIS.SYSTEM.PubicBaseClasses.XcConvert.IsNumeric( grdFontSize ) )
                {
                    dgvPresc.Font = new Font( "宋体", (float)(Convert.ToInt32(grdFontSize)) );
                }
                else
                {
                    dgvPresc.Font = new Font( "宋体", (float)12 );
                }
            }
            //设置用户自定义的网格行高
            string rowHeight = HIS.MZ_BLL.UserCustomSetting.GetPrescriptionGridRowHeight( currentUser.LoginCode );
            if ( rowHeight.Trim() == "" )
            {
                dgvPresc.RowTemplate.Height = 23;
            }
            else
            {
                if ( HIS.SYSTEM.PubicBaseClasses.XcConvert.IsInteger( rowHeight ) )
                {
                    dgvPresc.RowTemplate.Height = Convert.ToInt32( rowHeight );
                }
                else
                {
                    dgvPresc.RowTemplate.Height = 23;
                }
            }
            //网格背景色
            dgvPresc.BackgroundColor = HIS.MZ_BLL.UserCustomSetting.GetPrescriptionGridBackgroundColor( currentUser.LoginCode );
            //过滤方式
            string filterType = HIS.MZ_BLL.UserCustomSetting.GetFilterType( currentUser.LoginCode );
            if ( filterType == "" )
                filterType = "0";

            dgvPresc.SelectionCards[0].SelectCardFilterType = (GWI.HIS.Windows.Controls.MatchModes)Convert.ToInt32( filterType );
            #endregion
            
            if (_formType == FormType.门诊划价 &&  dtbChargeItems.Rows.Count == 0 )
            {
                MessageBox.Show( "没有药品信息！\r\n1、请确认药房是否有药品\r\n2、请确认当前登陆科室是否是药房", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation );
                button1.Enabled = false;
            }
            if ( _formType == FormType.门诊收费 )
            {
                try
                {
                    string perfCode = "";
                    string invoiceNo = HIS.MZ_BLL.InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票 , Convert.ToInt32( currentUser.EmployeeID ) , true ,out perfCode);
                    txtCurrentInvoiceNo.Text = HIS.MZ_BLL.InvoiceManager.FormatInvoiceNo( invoiceNo );
                    txtPerfCode.Text = perfCode;
                    MessageBox.Show( "当前可用发票号：" + HIS.MZ_BLL.InvoiceManager.FormatInvoiceNo( invoiceNo ) + " ，请确认！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                }
                catch ( Exception err )
                {
                    MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    this.toolStrip1.Enabled = false;
                }
            }
            
            foreach ( object obj in Enum.GetValues( typeof( HIS.MZ_BLL.SearchPatientType ) ) )
                cboSearchType.Items.Add( obj.ToString( ) );
            cboSearchType.SelectedIndex = 0;

            txtVisitNo.Focus( );

            
        }

        private void FrmHJSF_KeyDown( object sender , KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.F11 )
            {
                //CreateNewPatient( );
                btnGetNewPatient_Click(null, null);
            }
            if ( e.KeyCode == Keys.F3 && toolStrip1.Enabled==true )
            {
                NewPrescription( );
            }

            if ( e.KeyCode == Keys.F2 )
            {
                SavePrescriptionEvent( );
            }
            if ( e.KeyCode == Keys.F8 && _formType == FormType.门诊收费 && toolStrip1.Enabled == true  )
            {
                PrescriptionChargeEvent( );
            }

            if ( e.KeyCode == Keys.F9 && _formType == FormType.门诊收费 && toolStrip1.Enabled == true )
            {
                btnCancelBlance_Click( null, null );
            }

            if ( e.KeyCode == Keys.F5 )
            {
                if ( txtVisitNo.Text.Trim( ) != "" )
                {
                    PatientInfoTextBoxs_EnterKeyPress( this.txtVisitNo , new KeyPressEventArgs( (char)13 ) );
                }
            }
        }

        private void PatientInfoTextBoxs_EnterKeyPress( object sender , KeyPressEventArgs e )
        {

            Control ctrl = (Control)sender;
            
            if ( ctrl.Name == txtVisitNo.Name || ctrl.Name == txtAge.Name )
            {
                if ( ( (int)e.KeyChar >= 48 && (int)e.KeyChar <= 57 ) || (int)e.KeyChar == 13 || (int)e.KeyChar == 8 )
                    e.Handled = false;
                else
                    e.Handled = true;
               
            }

            if ( (int)e.KeyChar == 13 )
            {
                if ( ctrl.Name == txtVisitNo.Name )
                {
                    if ( txtVisitNo.Text.Trim( ) != "" )
                    {
                        try
                        {
                            //检索病人信息
                            string visitNo = txtVisitNo.Text;
                            ClearUIInfo( false );
                            if ( cboSearchType.SelectedIndex == 0 )
                            {
                                //门诊号
                                if ( visitNo.Length <= 4 && visitNo.Length>0 )
                                {
                                    while ( visitNo.Length < 4 )
                                    {
                                        visitNo = "0" + visitNo;
                                    }
                                    visitNo = DateTime.Now.ToString( "yyyyMMdd" ) + visitNo;
                                }
                                
                                _currentPatient = new HIS.MZ_BLL.OutPatient( visitNo  );
                                if ( OutPatient.IsCancelRegister( _currentPatient ) )
                                {
                                    ClearUIInfo( false );
                                    MessageBox.Show( "该病人已经退号，请重新挂号!" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                                    return;
                                }
                            }
                            else
                            {
                                DataTable tbList = PublicDataReader.GetRegistedPatientListByCardNo( visitNo );
                                if ( tbList.Rows.Count > 1 )
                                {
                                    HIS_MZManager.Query.FrmPatientSelect fSelect = new HIS_MZManager.Query.FrmPatientSelect( tbList );
                                    if ( fSelect.ShowDialog( ) == DialogResult.Cancel )
                                        return;
                                    _currentPatient = fSelect.SelectedPatient;
                                }
                                else if ( tbList.Rows.Count == 1 )
                                {
                                    _currentPatient = new OutPatient( Convert.ToInt32( tbList.Rows[0]["PATLISTID"] ) );
                                }
                                else
                                {
                                    MessageBox.Show( "该卡号未找到病人信息，请确认卡号是否正确！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                                    return;
                                }
                            }
                            if (! CheckExistsVisitDate() )
                            {
                                ClearUIInfo( false );
                                return;
                            }
                            ShowPatientInfo( );
                        }
                        catch ( Exception err )
                        {
                            MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                            return;
                        }

                        plLastInfo.Visible = false;
                    }
                    else
                    {
                        txtPatientName.Focus();
                    }
                }
                if ( ctrl.Name == txtPatientName.Name )
                {
                    if ( txtPatientName.Text.Trim() != "" )
                    {
                        plLastInfo.Visible = false;
                    }
                    cboSex.Focus( );
                }
                if ( ctrl.Name == cboSex.Name )
                {
                    txtAge.Focus();
                }
                if ( ctrl.Name == txtAge.Name )
                {
                    cboAgeUnit.Focus( );
                }
                if ( ctrl.Name == cboAgeUnit.Name )
                {
                    cboFeeType.Focus( );
                }

                if ( ctrl.Name == cboFeeType.Name )
                {
                    txtWorkUnit.Focus( );
                }
                if ( ctrl.Name == txtDoctor.Name )
                {
                    if ( txtDepartment.MemberValue != null && txtDepartment.Text != "" )
                    {
                        txtDiagnosis.Focus( );   
                    }
                    else
                        txtDepartment.Focus( );
                }
                if ( ctrl.Name == txtDepartment.Name )
                {
                    txtDiagnosis.Focus( );
                }
                if ( ctrl.Name == txtDiagnosis.Name )
                {
                    if ( txtDiagnosis.MemberValue != null )
                    {
                        txtDiagnosisMemo.Focus();
                    }
                    
                }

                if (ctrl.Name == txtDiagnosisMemo.Name)
                {
                    txtAllergic.Focus();
                }

                if (ctrl.Name == txtAllergic.Name)
                {
                    if (_currentPatient == null)
                        _currentPatient = new OutPatient();
                    NewPrescription();
                }

                
            }
        }

        private void dgvPresc_SelectCardRowSelected( object SelectedValue, ref bool stop, ref int customNextColumnIndex )
        {
            int currentRowIndex = dgvPresc.CurrentCell.RowIndex;
            if ( txtDoctor.MemberValue == null && txtDoctor.Text.Trim()=="" )
            {
                MessageBox.Show( "开方医生填写不正确","",MessageBoxButtons.OK,MessageBoxIcon.Error );
                txtDoctor.Focus();
                stop = true;
                return;
            }
            if ( txtDepartment.MemberValue == null && txtDepartment.Text.Trim() == "" )
            {
                MessageBox.Show( "开方科室填写不正确", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                stop = true;
                txtDepartment.Focus();
                return;
            }

            if ( dgvPresc.CurrentCell.ColumnIndex == dgvPresc.Columns["CODE"].Index )
            {
                //取得选择卡的数据
                string code = ((DataRow)SelectedValue)["CODE"].ToString();
                //string item_name = ( (DataRow)SelectedValue )["ITEM_NAME"].ToString();
                string item_name = ( (DataRow)SelectedValue )["CHEM_NAME"].ToString( );
                string standard = ( (DataRow)SelectedValue )["Standard"].ToString();
                string price = ( (DataRow)SelectedValue )["PRICE"].ToString();
                string item_unit = ( (DataRow)SelectedValue )["ITEM_UNIT"].ToString(); //大单位
                string base_unit = ( (DataRow)SelectedValue )["BASE_UNIT"].ToString();
                string exec_dept_name = ( (DataRow)SelectedValue )["EXEC_DEPT_NAME"] == null ? "" : ( (DataRow)SelectedValue )["EXEC_DEPT_NAME"].ToString();
                string exec_dept_code = ( (DataRow)SelectedValue )["EXEC_DEPT_CODE"] == null ? "" : ( (DataRow)SelectedValue )["EXEC_DEPT_CODE"].ToString();
                string item_id = ( (DataRow)SelectedValue )["ITEM_ID"].ToString();
                string statitem_code = ( (DataRow)SelectedValue )["STATITEM_CODE"].ToString();
                string complex_id = ( (DataRow)SelectedValue )["Complex_ID"].ToString();
                string hjxs = ( (DataRow)SelectedValue )["HJXS"] == null ? "" : ( (DataRow)SelectedValue )["HJXS"].ToString();
                string isDrug = ( (DataRow)SelectedValue )["IsDrug"].ToString().Trim();
                string isTemplate = ( (DataRow)SelectedValue )["IsTemplate"].ToString( ).Trim( );
                //判断库存
                if ( statitem_code == "01" || statitem_code == "02" || statitem_code == "03" )
                {
                    if ( IncludeDoctorStationPrescription() )
                    {
                        MessageBox.Show( "当前内容包含医生站开出的处方，不允许增加药品项目" ,"",MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;
                    }

                    decimal sellprice , buyprice , storevalue;
                    if ( !PublicDataReader.StoreExists( Convert.ToInt32( item_id ) , exec_dept_code , 0,out sellprice,out buyprice,out storevalue ) )
                    {
                        MessageBox.Show( "【" + item_name + "】库存为零。请通知【" + exec_dept_name + "】药房及时入库" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                        dgvPresc.CurrentCell = dgvPresc["CODE" , currentRowIndex];
                        stop = true;
                        return;
                    }
                }
 
                #region 自动分方控制
                if ( Convert.ToInt16( HIS.MZ_BLL.OPDParamter.Parameters["009"] ) == 1 ) 
                {
                    if ( ! IsPrescriptionFirstRow( currentRowIndex ) )
                    {
                        string previous_row_dept_code = dgvPresc["EXEC_DEPT", currentRowIndex - 1].Tag.ToString();
                        string previous_row_stat_item_code = dgvPresc["STATITEM_CODE", currentRowIndex - 1].Value.ToString();
                        string previous_row_isDrug = "0";
                        if ( previous_row_stat_item_code == "01" || previous_row_stat_item_code == "02" || previous_row_stat_item_code == "03" )
                        {
                            previous_row_isDrug = "1";
                        }
                        if ( exec_dept_code.Trim() == "" )
                            exec_dept_code = "0";

                        if ( previous_row_dept_code.Trim() != exec_dept_code.Trim() && exec_dept_code.Trim() != "" )
                        {
                            if ( Convert.ToInt32( exec_dept_code ) > 0 )
                            {
                                if ( MessageBox.Show( "执行科室不同，是否自动分方？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
                                {
                                    dgvPresc.CurrentCell = dgvPresc["CODE", currentRowIndex];
                                    stop = true;
                                    return;
                                }
                                else
                                {
                                    EndPrescription();
                                    currentRowIndex = NewPrescription();
                                }
                            }
                            else
                            {
                                //判断上一行是否药品，是药品的话，不允许在该处方内录入项目
                                if ( previous_row_isDrug != isDrug )
                                {
                                    if ( MessageBox.Show( "药品和治疗项目不能开在同一处方，是否自动分方？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
                                    {
                                        dgvPresc.CurrentCell = dgvPresc["CODE", currentRowIndex];
                                        stop = true;
                                        return;
                                    }
                                    else
                                    {
                                        EndPrescription();
                                        currentRowIndex = NewPrescription();
                                    }
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
                                    dgvPresc["EXEC_DEPT" , currentRowIndex].Value = txtDepartment.Text;
                                    dgvPresc["EXEC_DEPT" , currentRowIndex].Tag = txtDepartment.MemberValue.ToString( );
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
                            dgvPresc["TotalCost" , currentRowIndex].Value = amount * Convert.ToDecimal( price) / Convert.ToDecimal(hjxs) ;
                            dgvPresc["Item_ID" , currentRowIndex].Value = item_id;
                            dgvPresc["STATITEM_CODE" , currentRowIndex].Value = statitem_code;
                            dgvPresc["Complex_Id" , currentRowIndex].Value = complex_id;
                            dgvPresc["HJXS" , currentRowIndex].Value = hjxs;
                            dgvPresc["Selected" , currentRowIndex].Value = (short)1;
                            //加入处方医生
                            dgvPresc[PrescDoctor.Name, currentRowIndex].Value = txtDoctor.MemberValue.ToString();
                            dgvPresc[PrescDoctorName.Name, currentRowIndex].Value = txtDoctor.Text;
                            #endregion

                            int start;
                            int end;
                            int subRow;
                            GetPrescriptionStartRowAndEndRow( currentRowIndex , out start , out end , out subRow );
                            if ( subRow == -1 )
                            {
                                if ( i < drsTemplate.Length - 1 )
                                {
                                    if ( dgvPresc["ITEM_ID",dgvPresc.Rows.Count-1].Value != null )
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
                            MessageBox.Show( _t_name+_t_standard + "没有检索到！您可以：\r\n1、刷新选项卡后再试\r\n2、确认是否有库存或者该药品状态是否停用" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                            //dgvPresc.Rows.RemoveAt( currentRowIndex );
                        }
                        
                    }
                    
                    #endregion
                    int start1 , end1 , subrow1;
                    GetPrescriptionStartRowAndEndRow( currentRowIndex ,out start1 ,out end1 ,out subrow1 );
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
                            dgvPresc["EXEC_DEPT" , currentRowIndex].Value = txtDepartment.Text;
                            dgvPresc["EXEC_DEPT" , currentRowIndex].Tag = txtDepartment.MemberValue.ToString( );
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

                    //加入处方医生
                    dgvPresc[PrescDoctor.Name, currentRowIndex].Value = txtDoctor.MemberValue.ToString();
                    dgvPresc[PrescDoctorName.Name, currentRowIndex].Value = txtDoctor.Text;

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
            if ( txtDoctor.MemberValue != null && txtDepartment.MemberValue != null )
            {
                dgvPresc["PrescDoctor" , e.RowIndex].Value = txtDoctor.MemberValue.ToString( );
                dgvPresc["PrescDept" , e.RowIndex].Value = txtDepartment.MemberValue.ToString( );
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
                menuInsertRow.Enabled = true ;
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

                    if ( dgvPresc.CurrentCell.RowIndex == subRow  ) //小计行
                        return;

                    if ( start == end && subRow == -1 )
                    {
                        //新处方第一行
                        dgvPresc.SelectionCards[0].SpeciFilterString = "";
                        return;
                    }
                    if ( Convert.ToInt16( HIS.MZ_BLL.OPDParamter.Parameters["009"] ) == 0 ) //如果不自动分方，过滤显示
                    {
                        if ( start != end )
                        {
                            string stat_code = dgvPresc["STATITEM_CODE" , start ].Value.ToString( );//当前处方第一行类型
                            if ( stat_code == "01" || stat_code == "02" || stat_code == "03" )
                            {
                                dgvPresc.SelectionCards[0].SpeciFilterString = "ISDRUG=1 AND STATITEM_CODE = '" + stat_code + "'";
                            }
                            else
                            {
                                dgvPresc.SelectionCards[0].SpeciFilterString = "ISDRUG=0 AND STATITEM_CODE NOT IN( '00','01','02','03')";
                            }
                        }
                    }
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
                
                GetPrescriptionStartRowAndEndRow( e.RowIndex , out start , out end ,out subRow );
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

        private void menuInsertRow_Click( object sender , EventArgs e )
        {
            if ( dgvPresc.Rows.Count == 0 )
                return;

            int start , end , subRow;
            int currentRow = dgvPresc.CurrentCell.RowIndex;
            
            GetPrescriptionStartRowAndEndRow( currentRow , out start , out end , out subRow );
            //判断是否为医生处方
            int docPrescId = dgvPresc[DocPresId.Name , currentRow].Value == null ? 0 : Convert.ToInt32( dgvPresc[DocPresId.Name , currentRow].Value );
            if ( docPrescId > 0 )
            {
                MessageBox.Show( "医生站开出的处方不能进行插入操作！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

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
            
            int presId = dgvPresc["PrescID" , currentRow].Value ==null ? 0 : Convert.ToInt32( dgvPresc["PrescID" , currentRow].Value );
            int detailId = dgvPresc["DetailID" , currentRow].Value == null ? 0 : Convert.ToInt32( dgvPresc["DetailID" , currentRow].Value );
            int docPrescId = dgvPresc[DocPresId.Name, currentRow].Value == null ? 0 : Convert.ToInt32( dgvPresc[DocPresId.Name, currentRow].Value );
            if ( docPrescId > 0 )
            {
                MessageBox.Show( "医生站开出的处方不能进行单条删除！", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                return;
            }

            if ( presId > 0 && detailId > 0 )
            {
                if ( MessageBox.Show( "该行明细已经保存，确定要删除？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.No )
                    return;

                HIS.MZ_BLL.ChargeControl chargeControl = new HIS.MZ_BLL.ChargeControl( this._currentPatient, Convert.ToInt32( currentUser.EmployeeID ) );
                try
                {
                    chargeControl.DeletePrescriptionDetail( detailId );
                    if ( start == end )
                    {
                        chargeControl.DeletePrescription( presId );
                    }
                }
                catch ( OperatorException oe )
                {
                    MessageBox.Show( oe.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }
                catch 
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
                GetPrescriptionStartRowAndEndRow( end-1 , out start , out end , out subRow );
                if ( subRow>0)
                    dgvPresc["TotalCost" , subRow].Value = CalcutePrescriptionCost( start );
                
            }
            lblTotal.Text = CalcuteAllPrescriptionCost( ).ToString( "#0.#0");
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
            int docPrescId = dgvPresc[DocPresId.Name, currentRow].Value == null ? 0 : Convert.ToInt32( dgvPresc[DocPresId.Name, currentRow].Value );
            if ( docPrescId > 0 )
            {
                MessageBox.Show( "医生站处方不能删除！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                return;
            }

            if ( presId > 0 && detailId > 0 )
            {
                HIS.MZ_BLL.ChargeControl chargeControl = new HIS.MZ_BLL.ChargeControl( this._currentPatient, Convert.ToInt32( currentUser.EmployeeID ) );

                try
                {
                    chargeControl.DeletePrescription( presId );

                }
                catch ( OperatorException oe )
                {
                    MessageBox.Show( oe.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
                    return;
                }
                catch 
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

        private void InputControlEnter( object sender , EventArgs e )
        {
            Control ctrl = (Control)sender;
            bool ilIsOn = false;
            
            if ( ctrl.Name == txtVisitNo.Name )
            {
                ilIsOn = false;
            }
            if ( ctrl.Name == txtPatientName.Name )
            {
                ilIsOn = true;
            }
            if ( ctrl.Name == cboSex.Name )
            {
                ilIsOn = false;
            }
            if ( ctrl.Name == txtAge.Name )
            {
                ilIsOn = false;
            }
            if ( ctrl.Name == cboFeeType.Name )
            {
                ilIsOn = false;
            }
            if ( ctrl.Name == txtDoctor.Name )
            {
                ilIsOn = false;
            }
            if ( ctrl.Name == txtDepartment.Name )
            {
                ilIsOn = false;
            }
            if ( ctrl.Name == txtDiagnosis.Name )
            {
                ilIsOn = false;
            }
            if ( ctrl.Name == dgvPresc.Name )
            {
                ilIsOn = false;
            }
            HIS.MZ_BLL.ILControl.ILControl.SetILStatus( currentUser.LoginCode , ilIsOn );
        }

        private void txtDoctor_AfterItemSelected( object sender , object SelectedValue )
        {
            if ( txtDoctor.MemberValue != null )
            {
                int docDeptId =  Convert.IsDBNull(( (DataRow)SelectedValue )["DEPT_ID"]) ? 0 : Convert.ToInt32( ( (DataRow)SelectedValue )["DEPT_ID"] );
                string docDeptName = Convert.IsDBNull( ( (DataRow)SelectedValue )["DEPT_NAME"] ) ? "" : ( (DataRow)SelectedValue )["DEPT_NAME"].ToString().Trim();
                if ( docDeptId == 0 )
                {
                    txtDepartment.Focus();
                }
                else
                {
                    txtDepartment.MemberValue = docDeptId;
                    txtDepartment.Text = docDeptName;
                    txtDiagnosis.Focus();
                }

                //GWMHIS.BussinessLogicLayer.Classes.Employee employee = new GWMHIS.BussinessLogicLayer.Classes.Employee( Convert.ToInt64( txtDoctor.MemberValue ) );
                //GWMHIS.BussinessLogicLayer.Classes.Deptment[] departments = employee.GetDepartment();
                //if ( departments == null )
                //{
                //    MessageBox.Show( "【"+employee.Name + "】没有设置科室！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                //    return;
                //}

                //bool currentDeptIsDocDept = true;
                //if ( txtDepartment.MemberValue != null && txtDepartment.Text.Trim( ) != "" )
                //{
                //    for ( int i = 0 ; i < departments.Length ; i++ )
                //    {
                //        if ( departments[i].DeptID != Convert.ToInt32( txtDepartment.MemberValue ) )
                //        {
                //            currentDeptIsDocDept = false;
                //            break;
                //        }
                //    }
                //    if ( !currentDeptIsDocDept )
                //    {
                //        txtDepartment.MemberValue = departments[0].DeptID;
                //        txtDepartment.Text = departments[0].Name;
                //    }
                //}
                //else
                //{
                //    bool find = false;
                //    for ( int i = 0 ; i < departments.Length ; i++ )
                //    {
                //        if ( departments[i].MZ_Flag == true )
                //        {
                //            txtDepartment.MemberValue = departments[i].DeptID;
                //            txtDepartment.Text = departments[i].Name;
                //            find = true;
                //            break;
                //        }
                //    }
                //    if ( !find )
                //    {
                //        txtDepartment.MemberValue = departments[0].DeptID;
                //        txtDepartment.Text = departments[0].Name;
                //    }
                //}
            }
        }

        private void btnPatlist_Click( object sender , EventArgs e )
        {
            HIS_MZManager.Query.FrmPatientSelect fSelect = new HIS_MZManager.Query.FrmPatientSelect( true );
            if ( fSelect.ShowDialog( ) == DialogResult.OK )
            {
                _currentPatient = fSelect.SelectedPatient;

                if ( !CheckExistsVisitDate() )
                {
                    ClearUIInfo( false );
                    return;
                }
                if ( OutPatient.IsCancelRegister( _currentPatient ) )
                {
                    ClearUIInfo( false );
                    MessageBox.Show( "该病人已经退号，请重新挂号!" , "" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                    return;
                }
                ShowPatientInfo( );

                //显示未收费处方
                Prescription[] prescriptions = _currentPatient.GetPrescriptions( HIS.MZ_BLL.PresStatus.未收费 , _formType == FormType.门诊划价 ? false : true );
                ShowPrescriptions( prescriptions );

                if ( txtDoctor.MemberValue == null ||  txtDoctor.MemberValue.ToString().Trim() == "" )
                {
                    txtDoctor.Focus( );
                    return;
                }

                if ( txtDepartment.MemberValue == null || txtDepartment.MemberValue.ToString( ).Trim( ) == "" )
                {
                    txtDepartment.Focus( );
                    return;
                }
                txtDiagnosisMemo.Focus( );
            }
            
        }

        private void btnCloseForm_Click( object sender, EventArgs e )
        {
            this.Close();
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            SavePrescriptionEvent();
        }

        private void btnNewPrescription_Click( object sender, EventArgs e )
        {
            txtDoctor.Enabled = true;
            txtDepartment.Enabled = true;
            //新开处方
            NewPrescription();
            
        }

        private void btnRefresh_Click( object sender, EventArgs e )
        {
            if ( txtVisitNo.Text.Trim() != "" )
            {
                PatientInfoTextBoxs_EnterKeyPress( this.txtVisitNo, new KeyPressEventArgs( (char)13 ) );
            }
        }

        private void btnBalance_Click( object sender, EventArgs e )
        {
            

            PrescriptionChargeEvent();
        }

        private void btnCancelBlance_Click( object sender, EventArgs e )
        {
            FrmUnCharge frmUncharge = new FrmUnCharge( Convert.ToInt32( currentUser.EmployeeID ) );
            if ( frmUncharge.ShowDialog() == DialogResult.OK )
            {
                //更新发票显示
                string perfChar = "";
                string invoiceNo = HIS.MZ_BLL.InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票, Convert.ToInt32( currentUser.EmployeeID ), true, out perfChar );
                txtCurrentInvoiceNo.Text = HIS.MZ_BLL.InvoiceManager.FormatInvoiceNo( invoiceNo );
                if ( frmUncharge.HasPresNeedBalance )
                {
                    _currentPatient = frmUncharge.ReturnPatient;
                    ShowPatientInfo();
                }
            }

            
        }

        private void btnGetNewPatient_Click( object sender, EventArgs e )
        {
            //新病人
            //CreateNewPatient();
            //bool cancharge = true;
            

            GH.FrmMzgh frmGh = new HIS_MZManager.GH.FrmMzgh( "门诊挂号" , currentUser , true , _formType );
            
            frmGh.Width = Screen.PrimaryScreen.WorkingArea.Width;
            frmGh.StartPosition = FormStartPosition.CenterScreen;
            frmGh.ShowInTaskbar = false;
            frmGh.MaximizeBox = false;
            frmGh.MinimizeBox = false;
            
            if ( frmGh.ShowDialog( ) == DialogResult.OK )
            {
                this._currentPatient = new OutPatient( frmGh.Patient.PatListID );
                _currentPatient.Age = frmGh.Patient.Age;
                _currentPatient.CureEmpCode = frmGh.Patient.RegDoctorCode;
                _currentPatient.CureDeptCode = frmGh.Patient.RegDeptCode;
                if ( frmGh.Patient.PatType != null )
                {
                    if ( frmGh.Patient.PatType.Code.Trim( ) != "" )
                    {
                        _currentPatient.MediType = frmGh.Patient.PatType.Code;
                    }
                    
                }
                
                
                ShowPatientInfo( );
            }
        }

        private void btnUserSetting_Click( object sender, EventArgs e )
        {
            FrmSetting fSetting = new FrmSetting( _formType, currentUser );
            fSetting.ShowDialog();
        }

        private void button1_Click( object sender , EventArgs e )
        {
            HJSF.FrmAdjustInvoiceNo frmAdj = new FrmAdjustInvoiceNo( Convert.ToInt32( currentUser.EmployeeID ) , OPDBillKind.门诊收费发票 );
            if ( frmAdj.ShowDialog( ) == DialogResult.OK )
            {
                string perfCode = "";
                txtCurrentInvoiceNo.Text = HIS.MZ_BLL.InvoiceManager.GetBillNumber( OPDBillKind.门诊收费发票 , Convert.ToInt32( currentUser.EmployeeID ) , true ,out perfCode);
            }
        }

        private void btnRefreshShowCArd_Click( object sender , EventArgs e )
        {
            Cursor = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.WaitCursor( );
            //加载数据
            dtbChargeItems = HIS.MZ_BLL.PublicDataReader.GetItemSelectedCardDataSource( _formType == FormType.门诊划价 ? 0 : 1 );
            //如果是药房划价，过滤执行科室（当前的执行科室是药房）
            if ( _formType == FormType.门诊划价 )
            {
                DataRow[] drs = dtbChargeItems.Copy( ).Select( "EXEC_DEPT_CODE='" + currentDept.DeptID.ToString( ) + "'" );
                dtbChargeItems.Rows.Clear( );
                for ( int row = 0 ; row < drs.Length ; row++ )
                    dtbChargeItems.Rows.Add( drs[row].ItemArray );

            }
            dgvPresc.SetSelectionCardDataSource( dtbChargeItems , "CODE" );

            //tbTemplateDetail = HIS.MZ_BLL.PublicDataReader.Get_TemplateDetailList( );
            tbTemplateDetail = BaseDataController.BaseDataSet[BaseDataCatalog.划价模板明细列表];

            Cursor = Cursors.Default;
        }

        

        private void btnClear_Click( object sender , EventArgs e )
        {
            ClearUIInfo( false );
            txtPatientName.Enabled = true;
        }

        private void txtWorkUnit_AfterSelectedRow( object sender , object SelectedValue )
        {
            if ( SelectedValue == null && txtWorkUnit.Text.Trim() != "" )
            {
                if ( MessageBox.Show( "单位名称更不存在，是否添加？" , "" , MessageBoxButtons.YesNo , MessageBoxIcon.Question ) == DialogResult.Yes )
                {
                    string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode( txtWorkUnit.Text );
                    string name = txtWorkUnit.Text.Trim();
                    try
                    {
                        Assembly assembly = Assembly.LoadFile( Application.StartupPath + "\\HIS.Base_BLL.dll" );
                        object obj = assembly.CreateInstance( "HIS.Base_BLL.WorkUnitController" );
                        object objRet = obj.GetType().InvokeMember( "AddWorkUnit", BindingFlags.InvokeMethod, null, null, new object[] { name, pywb[0], pywb[1] } );
                        BaseDataController.Reload( BaseDataCatalog.工作单位列表 );
                        dtbWorkUnit = BaseDataController.BaseDataSet[BaseDataCatalog.工作单位列表];
                        txtWorkUnit.SetSelectionCardDataSource( dtbWorkUnit );
                        txtWorkUnit.MemberValue = objRet.ToString();
                    }
                    catch ( Exception err )
                    {
                        MessageBox.Show( "添加单位不成功，请从基础数据维护处添加" );
                    }
                    
                    
                }
            }
        }

        private void txtAge_KeyUp( object sender , KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Up )
            {
                if ( cboAgeUnit.SelectedIndex == 0 )
                    return;
                else
                    cboAgeUnit.SelectedIndex--;
            }
            if ( e.KeyCode == Keys.Down )
            {
                if ( cboAgeUnit.SelectedIndex == cboAgeUnit.Items.Count - 1 )
                    return;
                else
                    cboAgeUnit.SelectedIndex++;
            }
        }

        private void btnEditName_Click( object sender , EventArgs e )
        {
            GWMHIS.BussinessLogicLayer.Forms.DlgInputBox dlg = new GWMHIS.BussinessLogicLayer.Forms.DlgInputBox( txtPatientName.Text , "请输入新的病人姓名" , "修改病人姓名" );
            dlg.ShowDialog( );
            if ( GWMHIS.BussinessLogicLayer.Forms.DlgInputBox.DlgResult == true )
            {
                if ( GWMHIS.BussinessLogicLayer.Forms.DlgInputBox.DlgValue.Trim( ) != "" )
                {
                    int length = Convert.ToInt32( HIS.MZ_BLL.OPDParamter.Parameters["006"] );
                    if ( GWMHIS.BussinessLogicLayer.Forms.DlgInputBox.DlgValue.Length > length )
                    {
                        MessageBox.Show( "输入的姓名超过系统设定的长度！" , "输入错误" , MessageBoxButtons.OK , MessageBoxIcon.Warning );
                        return;
                    }
                    txtPatientName.Text = GWMHIS.BussinessLogicLayer.Forms.DlgInputBox.DlgValue;
                }
                else
                {
                    MessageBox.Show( "无效的病人姓名！" , "" , MessageBoxButtons.OK , MessageBoxIcon.Information );
                    return;
                }
            }
        }
        
    }
}
