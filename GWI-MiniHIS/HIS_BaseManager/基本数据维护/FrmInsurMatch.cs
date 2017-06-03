using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.MediInsInterface_BLL.MediInsInterface.NccmSystem.Core;

namespace HIS_BaseManager
{
    public partial class FrmInsurMatch : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private HIS.Base_BLL.Enums.MatchClass _matchClass;
        private GWMHIS.BussinessLogicLayer.Classes.User _user;
        private HospitalInfo _hospitalInfo;

        /// <summary>
        /// 药品项目匹配窗口
        /// </summary>
        /// <param name="matchClass"></param>
        public FrmInsurMatch( string FormText, HIS.Base_BLL.Enums.MatchClass matchClass, GWMHIS.BussinessLogicLayer.Classes.User user )
        {
            InitializeComponent( );

            _matchClass = matchClass;

            this.Text = FormText;
            this.FormTitle = FormText;
            if ( matchClass == HIS.Base_BLL.Enums.MatchClass.药品匹配 )
            {
                btnDownLoad.Text = "下载农合药品目录";
            }
            else if ( matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配 )
            {
                btnDownLoad.Text = "下载农合医疗项目目录";
            }
            _user = user;
        }
        /// <summary>
        /// 创建农合、医保药品目录网格列式样
        /// </summary>
        private void CreateGridOfInsurDrug()
        {
            DataGridViewTextBoxColumn col;
            dgvInsur.Columns.Clear();

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "类型";
            col.Width = 35;
            col.DataPropertyName = "DRUG_TYPE";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "编码";
            col.Width = 100;
            col.DataPropertyName = "DRUG_CODE";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "药品名称";
            col.Width = 150;
            col.DataPropertyName = "DRUG_NAME";
            col.Name = col.DataPropertyName;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "药品别名";
            col.Width = 150;
            col.DataPropertyName = "DRUG_ALIAS";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "剂型";
            col.Width = 40;
            col.DataPropertyName = "DRUG_FORM";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "";
            col.Visible = false;
            col.DataPropertyName = "LIMIT_PRICE";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "";
            col.Visible = false;
            col.DataPropertyName = "LIMIT_DESC";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "";
            col.Visible = false;
            col.DataPropertyName = "USE_LEVEL";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );
            
           
        }
        /// <summary>
        /// 创建农合、医保药品目录网格列式样
        /// </summary>
        private void CreateGridOfInsurItem()
        {
            DataGridViewTextBoxColumn col;
            dgvInsur.Columns.Clear();

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "项目编码";
            col.Width = 90;
            col.DataPropertyName = "item_code";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "项目名称";
            col.Width = 180;
            col.DataPropertyName = "item_name";
            col.Name = col.DataPropertyName;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "单位";
            col.Width = 70;
            col.DataPropertyName = "unit";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "一类价格";
            col.Width = 70;
            col.DataPropertyName = "price1";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "二类价格";
            col.Width = 70;
            col.DataPropertyName = "price2";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "三类价格";
            col.Width = 70;
            col.DataPropertyName = "price3";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );


            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "";
            col.Visible = false;
            col.DataPropertyName = "SPECS";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

  
            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "";
            col.Visible = false;
            col.DataPropertyName = "ITEM_CONTENT";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

 
            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "";
            col.Visible = false;
            col.DataPropertyName = "EXCLUDE_CONTENT";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

        }
        /// <summary>
        /// 创建医院药品目录网格列式样
        /// </summary>
        private void CreateGridOfHisDrug()
        {
            DataGridViewTextBoxColumn col;
            dgvHIS.Columns.Clear();

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "类型";
            col.Width = 35;
            col.DataPropertyName = "type";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "编码";
            col.Width = 60;
            col.DataPropertyName = "code";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );
      
            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "药品名称";
            col.Width = 120;
            col.DataPropertyName = "name";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "化学名";
            col.Width = 120;
            col.DataPropertyName = "chemname";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );             

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "规格";
            col.Width = 90;
            col.DataPropertyName = "spec";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "单位";
            col.Width = 65;
            col.DataPropertyName = "unit";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "单价";
            col.Width = 65;
            col.DataPropertyName = "price";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "剂型";
            col.Width = 65;
            col.DataPropertyName = "model";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "生产厂家";
            col.Width = 150;
            col.DataPropertyName = "factory";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );
        }
        /// <summary>
        /// 创建医院药品项目网格列式样
        /// </summary>
        private void CreateGridOfHisItem()
        {
            DataGridViewTextBoxColumn col;
            dgvHIS.Columns.Clear();

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "医院编号";
            col.Visible = false;
            col.DataPropertyName = "item_id";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "医疗编码";
            col.Width = 120;
            col.DataPropertyName = "std_code";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "项目名称";
            col.Width = 120;
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col.DataPropertyName = "item_name";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "单位";
            col.Width = 120;
            col.DataPropertyName = "item_unit";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "单价";
            col.Width = 120;
            col.DataPropertyName = "price";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "PY";
            col.Visible = false;
            col.DataPropertyName = "py_code";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "wb";
            col.Visible = false;
            col.DataPropertyName = "wb_code";
            col.Name = col.DataPropertyName;
            dgvHIS.Columns.Add( col );

        }
        /// <summary>
        /// 创建对应关系网格
        /// </summary>
        private void CreateGridOfRelation()
        {
            DataGridViewTextBoxColumn col;
            dgvRelation.Columns.Clear();

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "";
            col.Visible = false;
            col.DataPropertyName = "NCMS_CODE";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            dgvRelation.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "";
            col.Visible = false;
            col.DataPropertyName = "HOSPITAL_CODE";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            dgvRelation.Columns.Add( col ); 

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "状态";
            col.Visible = false;
            col.DataPropertyName = "STATUS";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            dgvRelation.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "";
            col.Visible = false;
            col.DataPropertyName = "TYPE";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            dgvRelation.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "审核状态";
            col.Visible = false;
            col.DataPropertyName = "APPROVE_STATUS";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            dgvRelation.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "上传时间";
            col.Visible = false;
            col.DataPropertyName = "UPLOAD_TIME";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            dgvRelation.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "上传人";
            col.Visible = false;
            col.DataPropertyName = "UPLOADER";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            dgvRelation.Columns.Add( col );

            if ( _matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配 )
            {
                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "新农合编码";
                col.Width = 120;
                col.DataPropertyName = "ITEM_CODE";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "新农合项目名称";
                col.Width = 250;
                col.DataPropertyName = "ITEM_NAME";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "单位";
                col.Width = 70;
                col.DataPropertyName = "UNIT";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "";
                col.Visible = false;
                col.DataPropertyName = "ITEMID";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "医院名称";
                col.Width = 120;
                col.DataPropertyName = "ITEMNAME";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "单位";
                col.Width = 70;
                col.DataPropertyName = "ITEM_UNIT";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "价格";
                col.Width = 60;
                col.DataPropertyName = "PRICE";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );
            }
            else
            {
                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "新农合药品编码";
                col.Width = 100;
                col.DataPropertyName = "DRUG_CODE";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "新农合药品别名";
                col.Width = 150;
                col.DataPropertyName = "DRUG_ALIAS";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "新农合药品名称";
                col.Width = 150;
                col.DataPropertyName = "DRUG_NAME";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "剂型";
                col.Width = 50;
                col.DataPropertyName = "DRUG_FORM";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "";
                col.Visible = false;
                col.DataPropertyName = "ITEMID";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "医院药品名称";
                col.Width = 120;
                col.DataPropertyName = "ITEMNAME";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "规格";
                col.Width = 90;
                col.DataPropertyName = "STANDARD";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "单位";
                col.Width = 50;
                col.DataPropertyName = "ITEM_UNIT";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "单价";
                col.Width = 70;
                col.DataPropertyName = "PRICE";
                col.ReadOnly = true;
                col.Name = col.DataPropertyName;
                dgvRelation.Columns.Add( col );

                col = new DataGridViewTextBoxColumn();
                col.HeaderText = "生产厂家";
                col.Width = 100;
                col.DataPropertyName = "ADDRESS";
                col.Name = col.DataPropertyName;
                col.ReadOnly = true;
                dgvRelation.Columns.Add( col );
            }
            col = new DataGridViewTextBoxColumnEx();
            col.HeaderText = "补偿比例(%)";
            col.Width = 100;
            col.DataPropertyName = "COMP_RATE";
            col.ReadOnly = false;
            col.MaxInputLength = 6;
            col.Name = col.DataPropertyName;
            col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            col.DefaultCellStyle.Format = "##0.#0";
            col.DefaultCellStyle.BackColor = Color.LightCyan;
            ( (DataGridViewTextBoxColumnEx)col ).TextFormatStyle = TextFormatStyle.UNumberic;
            dgvRelation.Columns.Add( col );

            DataGridViewButtonColumn btnCol = new DataGridViewButtonColumn();
            btnCol.HeaderText = "删除";
            btnCol.Width = 60;
            btnCol.DataPropertyName = "DELETED";
            btnCol.Name = btnCol.DataPropertyName;
            dgvRelation.Columns.Add( btnCol );
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="strValue"></param>
        /// <returns></returns>
        private string FormatKeyWord( string strValue )
        {
            strValue = strValue.Replace( "[", "[[]" );
            strValue = strValue.Replace( "%", "[%]" );
            strValue = strValue.Replace( "*", "[*]" );
            strValue = strValue.Replace( "'", "''" );
            return strValue;
        }
        /// <summary>
        /// 加载数据
        /// </summary>
        private void LoadData()
        {
            try
            {
                bool isNew = true;
               
                switch ( _matchClass )
                {
                    case HIS.Base_BLL.Enums.MatchClass.药品匹配:
                        CreateGridOfInsurDrug();
                        dgvInsur.DataSource = HIS.Base_BLL.BaseDataReader.Get_Ncms_DrugList().DefaultView;

                        CreateGridOfHisDrug();
                        dgvHIS.DataSource = HIS.Base_BLL.BaseDataReader.Get_HIS_DrugList().DefaultView;

                        CreateGridOfRelation();
                        dgvRelation.DataSource = HIS.Base_BLL.BaseDataReader.Get_Ncms_MatchInfo( isNew, "2" ).DefaultView;
                        break;
                    case HIS.Base_BLL.Enums.MatchClass.项目匹配:
                        CreateGridOfInsurItem();
                        dgvInsur.DataSource = HIS.Base_BLL.BaseDataReader.Get_Ncms_TherapyList().DefaultView;

                        CreateGridOfHisItem();
                        dgvHIS.DataSource = HIS.Base_BLL.BaseDataReader.Get_HIS_ItemList().DefaultView;

                        CreateGridOfRelation();
                        dgvRelation.DataSource = HIS.Base_BLL.BaseDataReader.Get_Ncms_MatchInfo( isNew, "3" ).DefaultView;
                        break;
                }
                

            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
        }

        private void ShowData(bool filterNcms,bool filterHIS,bool filterRelation)
        {
            string keyWord = FormatKeyWord( txtKeyWord.Text );

            if ( filterNcms )
            {
                if ( chkInsur.Checked )
                {
                    if ( _matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配 )
                        ( (DataView)dgvInsur.DataSource ).RowFilter  = "item_name like '%" + keyWord + "%'";
                        
                    else
                        ( (DataView)dgvInsur.DataSource ).RowFilter = "drug_name like '%" + keyWord + "%'";
                        
                }
            }

            if ( filterHIS )
            {
                if ( chkHIS.Checked )
                {
                    if ( _matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配 )
                        ( (DataView)dgvHIS.DataSource ).RowFilter = "item_name like '%" + keyWord + "%' or py_code like '" + keyWord + "' or wb_code = '%" + keyWord + "%'";
                    else
                        ( (DataView)dgvHIS.DataSource ).RowFilter = "name like '%" + keyWord + "%' or chemname like '%" + keyWord + "%' ";
                }
            }

            if ( filterRelation )
            {
                string filter = "";
                
              
                if ( _matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配 )
                {
                    filter += " item_name like '%" + keyWord + "%' or itemname like '%" + keyWord + "%'";
                }
                else
                {
                    filter += " drug_name like '%" + keyWord + "%' or itemname like '%" + keyWord + "%'";
                }
                                
                ( (DataView)dgvRelation.DataSource ).RowFilter = filter;
            }
        }

        private void FrmInsurMatch_Load( object sender , EventArgs e )
        {
            try
            {
                _hospitalInfo = HIS.Base_BLL.BaseDataReader.Get_Ncms_HisInfo();
            }
            catch
            {
                MessageBox.Show( "连接新农合服务器失败，未能读取到最新的医院信息。", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            LoadData();
            
            ShowData( true, true, true );

            plPageIndex.Visible = false;
        }  

        private void btnClose_Click( object sender , EventArgs e )
        {
            this.Close();
        }

        private void btnMatch_Click( object sender , EventArgs e )
        {
            if ( dgvHIS.Rows.Count == 0 )
                return;
            if ( dgvInsur.Rows.Count == 0 )
                return;
            if ( dgvHIS.CurrentCell == null )
                return;
            if ( dgvInsur.CurrentCell == null )
                return;
            if ( dgvInsur.SelectedRows.Count == 0 )
                return;
            if ( dgvHIS.SelectedRows.Count == 0 )
                return;

            for ( int row = 0; row < dgvHIS.SelectedRows.Count; row++ )
            {
                string ncms_code = "";
                string hospital_code = "";
                string item_type = "";
                if ( _matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配 )
                {
                    ncms_code = dgvInsur["item_code", dgvInsur.CurrentRow.Index].Value.ToString();
                    hospital_code = dgvHIS.SelectedRows[row].Cells["item_id"].Value.ToString();  // dgvHIS["item_id", dgvHIS.CurrentRow.Index].Value.ToString();
                    item_type = "2";
                }
                else
                {
                    ncms_code = dgvInsur["DRUG_CODE", dgvInsur.CurrentRow.Index].Value.ToString();
                    hospital_code = dgvHIS.SelectedRows[row].Cells["code"].Value.ToString(); //dgvHIS["code", dgvHIS.CurrentRow.Index].Value.ToString();
                    item_type = "1";
                }

                try
                {
                    HIS.Base_BLL.MatchManager.AddMatchInfo( ncms_code, hospital_code, item_type );
                }
                catch(Exception err)
                {
                    MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }
                
            }
            MessageBox.Show( "匹配成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
            LoadData();
            ShowData( true, true, true );
        }
        
        private void btnRefresh_Click( object sender , EventArgs e )
        {
            //Cursor = GWMHIS.PubicBaseCla
            try
            {
                LoadData();
                ShowData( true, true, true );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message , "" , MessageBoxButtons.OK , MessageBoxIcon.Error );
            }
        }

        private void btnSearch_Click( object sender , EventArgs e )
        {
            ShowData( true, true, true );
        }

        private void txtKeyWord_KeyPress( object sender , KeyPressEventArgs e )
        {
            if ( (int)e.KeyChar == 13 )
            {
                btnSearch_Click( null , null );
            }
        }

       

        private void btnDownLoad_Click( object sender, EventArgs e )
        {
            if ( MessageBox.Show( "确定要下载目录吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
                return;
            try
            {
                btnDownLoad.Enabled = false;
                Cursor = Cursors.WaitCursor;
                if( _matchClass == HIS.Base_BLL.Enums.MatchClass.药品匹配 )
                    HIS.Base_BLL.MatchManager.DownLoadAndSaveNcmsDrug();
                else if ( _matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配 )
                    HIS.Base_BLL.MatchManager.DownLoadAndSavNcmsTherapy();

                MessageBox.Show( "下载完毕！", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
            }
            catch ( Exception err )
            {
                MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            }
            finally
            {
                btnDownLoad.Enabled = true;
                Cursor = Cursors.Default;
            }
        }

        private void btnSave_Click( object sender, EventArgs e )
        {
            //保存比例设置
            for ( int i = 0; i < dgvRelation.Rows.Count; i++ )
            {
                string his_code = dgvRelation["HOSPITAL_CODE",i].Value.ToString();
                string ncms_code = dgvRelation["NCMS_CODE", i].Value.ToString();
                string type = dgvRelation["TYPE", i].Value.ToString();
                if ( dgvRelation["COMP_RATE", i].Value == null || dgvRelation["COMP_RATE", i].Value.ToString() == "" )
                {
                    MessageBox.Show( ( i + 1 ).ToString() + "行补偿比例填写不正确", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }
                else
                {
                    try
                    {
                        decimal tmp = Convert.ToDecimal( dgvRelation["COMP_RATE", i].Value );
                    }
                    catch
                    {
                        MessageBox.Show( ( i + 1 ).ToString() + "行补偿比例填写不正确", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                        return;
                    }
                }

                decimal rate = Convert.ToDecimal( dgvRelation["COMP_RATE", i].Value.ToString() );

                HIS.Base_BLL.MatchManager.SaveCompRate( his_code, ncms_code, type, rate );
            }

            MessageBox.Show("补偿比例已保存！","",MessageBoxButtons.OK,MessageBoxIcon.Information );
        }

        private void dgvRelation_CellContentClick( object sender, DataGridViewCellEventArgs e )
        {
            if ( dgvRelation.Rows.Count == 0 )
                return;
            if ( dgvRelation.CurrentCell == null )
                return;

            if ( e.ColumnIndex == dgvRelation.Columns["DELETED"].Index )
            {
                if ( MessageBox.Show( "确定要删除选中的匹配关系吗？", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.No )
                    return;
                
                int row = e.RowIndex;

                string ncms_code = dgvRelation["NCMS_CODE", row].Value.ToString();
                string his_code = dgvRelation["HOSPITAL_CODE", row].Value.ToString();
                string item_type = "";
                if ( _matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配 )
                {
                    item_type = "2";
                }
                else
                {
                    item_type = "1";
                }

                try
                {
                    HIS.Base_BLL.MatchManager.DeletematchInfo( ncms_code, his_code, item_type );
                }
                catch ( Exception err )
                {
                    MessageBox.Show( err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error );
                    return;
                }
                LoadData();
                if ( txtKeyWord.Text.Trim() != "" )
                    btnSearch_Click( null, null );
            }
        }

        private void dgvRelation_DataError( object sender, DataGridViewDataErrorEventArgs e )
        {
            e.Cancel = true;
        }

    }
}
