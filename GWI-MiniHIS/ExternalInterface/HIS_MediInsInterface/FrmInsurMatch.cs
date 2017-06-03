using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.MediInsInterface_BLL.MediInsBLL.Domain.DataMatch;

namespace HIS_MediInsInterface
{
    public partial class FrmInsurMatch : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private HIS.Base_BLL.Enums.MatchClass _matchClass;
        private GWMHIS.BussinessLogicLayer.Classes.User _user;

        private AbstractDataMatch datamatch = null;
        //private HospitalInfo _hospitalInfo;

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
                datamatch = new DrugDataMatch();
            }
            else if ( matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配 )
            {
                btnDownLoad.Text = "下载农合医疗项目目录";
                datamatch = new ItemDataMatch();
            }
            datamatch.EmpID = user.EmployeeID.ToString();
            datamatch.Name = user.Name;
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
            col.HeaderText = "药品编码";
            col.Width = 80;
            col.DataPropertyName = "Medi_code";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "药品名称";
            col.Width = 150;
            col.MinimumWidth = 150;
            col.DataPropertyName = "Medi_name";
            col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "剂型名称";
            col.Width = 100;
            col.DataPropertyName = "Model_name";
            col.Name = col.DataPropertyName;

            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "生产厂家";
            col.Width = 100;
            col.DataPropertyName = "Factory";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "规格";
            col.Width = 80;
            col.DataPropertyName = "Standard";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "药品类型名称";
            col.Width = 80;
            col.DataPropertyName = "Medi_item_name";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "国家药品目录标志";
            col.Width = 40;
            col.DataPropertyName = "STAPLE_FLAG";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );
            dgvInsur.AutoGenerateColumns = false;
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

            //col = new DataGridViewTextBoxColumn();
            //col.HeaderText = "单位";
            //col.Width = 70;
            //col.DataPropertyName = "unit";
            //col.Name = col.DataPropertyName;
            //dgvInsur.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "价格";
            col.Width = 70;
            col.DataPropertyName = "price";
            col.Name = col.DataPropertyName;
            dgvInsur.Columns.Add( col );

            dgvInsur.AutoGenerateColumns = false;

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
        /// 创建医院项目项目网格列式样
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
            col.HeaderText = "中心编码";
            col.DataPropertyName = "ITEM_CODE";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 80;
            dgvRelation.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "中心名称";
            col.DataPropertyName = "ITEM_NAME";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 150;
            dgvRelation.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "中心剂型";
            col.DataPropertyName = "MODEL_NAME";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 100;
            dgvRelation.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "本院编码";
            col.DataPropertyName = "HOSP_CODE";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 80;
            dgvRelation.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "本院名称";
            col.DataPropertyName = "HOSP_NAME";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 150;
            dgvRelation.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "本院剂型";
            col.DataPropertyName = "HOSP_MODEL";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 100;
            dgvRelation.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "匹配序号";
            col.DataPropertyName = "SERIAL_MATCH";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 70;
            dgvRelation.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "是否上传";
            col.DataPropertyName = "VALID_FLAG";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 70;
            dgvRelation.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "审核标识";
            col.DataPropertyName = "AUDIT_FLAG";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 70;
            dgvRelation.Columns.Add(col);

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "匹配类型";
            col.DataPropertyName = "MATCH_TYPE";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 70;
            dgvRelation.Columns.Add(col); 


            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "上传时间";
            col.DataPropertyName = "UPLOAD_TIME";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 100;
            dgvRelation.Columns.Add( col );

            col = new DataGridViewTextBoxColumn();
            col.HeaderText = "上传人";
            col.DataPropertyName = "UPLOADER";
            col.Name = col.DataPropertyName;
            col.ReadOnly = true;
            col.Width = 70;
            dgvRelation.Columns.Add( col );            
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

                switch (_matchClass)
                {
                    case HIS.Base_BLL.Enums.MatchClass.药品匹配:
                        CreateGridOfInsurDrug();
                        CreateGridOfHisDrug();
                        CreateGridOfRelation();
                        break;
                    case HIS.Base_BLL.Enums.MatchClass.项目匹配:
                        CreateGridOfInsurItem();
                        CreateGridOfHisItem();
                        CreateGridOfRelation();
                        break;
                }

                dgvInsur.DataSource = datamatch.OuterData(this.checkBox3.Checked);
                dgvHIS.DataSource = datamatch.HisData(this.checkBox2.Checked);
                dgvRelation.DataSource = datamatch.RelationData(true, "2").DefaultView;
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowData(bool filterNcms,bool filterHIS,bool filterRelation)
        {
            string keyWord = FormatKeyWord( txtKeyWord.Text );

            if ( filterNcms )
            {
                
                if (chkInsur.Checked)
                {
                    if (dgvInsur.DataSource != null)
                    {
                        if (_matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配)
                            ((DataTable)dgvInsur.DataSource).DefaultView.RowFilter = "(item_name like '%" + keyWord + "%' or code_py like '%"+keyWord+"%' )";

                        else
                            ((DataTable)dgvInsur.DataSource).DefaultView.RowFilter = "(MEDI_NAME like '%" + keyWord + "%' or code_py like '%" + keyWord + "%')";
                    }
                }
            }

            if ( filterHIS )
            {
                if ( chkHIS.Checked )
                {
                    if (dgvHIS.DataSource != null)
                    {
                        if (_matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配)
                            ((DataTable)dgvHIS.DataSource).DefaultView.RowFilter = "(item_name like '%" + keyWord + "%' or py_code like '%" + keyWord + "%')";
                        else
                            ((DataTable)dgvHIS.DataSource).DefaultView.RowFilter = "(name like '%" + keyWord + "%' or chemname like '%" + keyWord + "%' or py_code like '%" + keyWord + "%' )";
                    }
                }
            }

            if ( filterRelation )
            {
                string filter = "";

                if (dgvRelation.DataSource != null)
                {


                    filter += " HOSP_NAME like '%" + keyWord + "%' or ITEM_NAME like '%" + keyWord + "%'";
                   
                    ((DataView)dgvRelation.DataSource).RowFilter = filter;
                }
            }
        }

        private void FrmInsurMatch_Load( object sender , EventArgs e )
        {
            LoadData();           
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
                    ncms_code = dgvInsur["ITEM_CODE", dgvInsur.CurrentRow.Index].Value.ToString();
                    hospital_code = dgvHIS.SelectedRows[row].Cells["item_id"].Value.ToString();  // dgvHIS["item_id", dgvHIS.CurrentRow.Index].Value.ToString();
                    item_type = "2";
                }
                else//药品匹配
                {
                    ncms_code = dgvInsur["MEDI_CODE", dgvInsur.CurrentRow.Index].Value.ToString();
                    hospital_code = dgvHIS.SelectedRows[row].Cells["code"].Value.ToString(); //dgvHIS["code", dgvHIS.CurrentRow.Index].Value.ToString();
                    item_type = "1";
                }

                try
                {
                    //HIS.Base_BLL.MatchManager.AddMatchInfo( ncms_code, hospital_code, item_type );
                    datamatch.AddMatchRelation(ncms_code, hospital_code, item_type);
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
            ShowData( this.chkInsur.Checked,this.chkHIS.Checked,this.chkRelation.Checked );
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
                datamatch.DownLoadContent();
                MessageBox.Show( "下载完毕！", "", MessageBoxButtons.OK, MessageBoxIcon.Information );
                LoadData();
                ShowData(true, true, true);
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
            //for ( int i = 0; i < dgvRelation.Rows.Count; i++ )
            //{
            //    string his_code = dgvRelation["HOSPITAL_CODE",i].Value.ToString();
            //    string ncms_code = dgvRelation["NCMS_CODE", i].Value.ToString();
            //    string type = dgvRelation["TYPE", i].Value.ToString();
            //    if ( dgvRelation["COMP_RATE", i].Value == null || dgvRelation["COMP_RATE", i].Value.ToString() == "" )
            //    {
            //        MessageBox.Show( ( i + 1 ).ToString() + "行补偿比例填写不正确", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            //        return;
            //    }
            //    else
            //    {
            //        try
            //        {
            //            decimal tmp = Convert.ToDecimal( dgvRelation["COMP_RATE", i].Value );
            //        }
            //        catch
            //        {
            //            MessageBox.Show( ( i + 1 ).ToString() + "行补偿比例填写不正确", "", MessageBoxButtons.OK, MessageBoxIcon.Error );
            //            return;
            //        }
            //    }

            //    decimal rate = Convert.ToDecimal( dgvRelation["COMP_RATE", i].Value.ToString() );

            //    HIS.Base_BLL.MatchManager.SaveCompRate( his_code, ncms_code, type, rate );
            //}

            MessageBox.Show("补偿比例已保存！","",MessageBoxButtons.OK,MessageBoxIcon.Information );
        }


        private void dgvRelation_DataError( object sender, DataGridViewDataErrorEventArgs e )
        {
            e.Cancel = true;
        }

        private void FrmInsurMatch_FormClosed(object sender, FormClosedEventArgs e)
        {
            datamatch.Dispose();
        }

        private void btRest_Click(object sender, EventArgs e)
        {
            if (dgvRelation.DataSource != null && dgvRelation.CurrentCell != null)
            {
                string hosp_code = dgvRelation["hosp_code", dgvRelation.CurrentCell.RowIndex].Value.ToString();
                string item_code = dgvRelation["item_code", dgvRelation.CurrentCell.RowIndex].Value.ToString();
                string serial_match = dgvRelation["serial_match", dgvRelation.CurrentCell.RowIndex].Value.ToString();
                string match_type = dgvRelation["match_type", dgvRelation.CurrentCell.RowIndex].Value.ToString();
                datamatch.UploadSingleMatchRelation(hosp_code, item_code, serial_match, match_type);
                LoadData();
                ShowData(this.chkInsur.Checked, this.chkHIS.Checked, this.chkRelation.Checked);
                MessageBox.Show("操作成功！");
            }
        }

        private void btDel_Click(object sender, EventArgs e)
        {
            if (dgvRelation.DataSource != null && dgvRelation.CurrentCell != null)
            {
                string hosp_code = dgvRelation["hosp_code", dgvRelation.CurrentCell.RowIndex].Value.ToString();
                string item_code = dgvRelation["item_code", dgvRelation.CurrentCell.RowIndex].Value.ToString();
                string serial_match = dgvRelation["serial_match", dgvRelation.CurrentCell.RowIndex].Value.ToString();
                string match_type = dgvRelation["match_type", dgvRelation.CurrentCell.RowIndex].Value.ToString();
                string audit_flag = dgvRelation["audit_flag", dgvRelation.CurrentCell.RowIndex].Value.ToString();
                datamatch.DeleteMatchRelation(hosp_code, item_code, serial_match, match_type,audit_flag);
                LoadData();
                ShowData(this.chkInsur.Checked, this.chkHIS.Checked, this.chkRelation.Checked);
                MessageBox.Show("操作成功！");
            }
        }

        private void btAllRest_Click(object sender, EventArgs e)
        {
            datamatch.UploadAllMatchRelation();
            LoadData();
            ShowData(this.chkInsur.Checked, this.chkHIS.Checked, this.chkRelation.Checked);
            MessageBox.Show("操作成功！");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            string filter = "";
            if (dgvRelation.DataSource != null)
            {
                if (checkBox1.Checked)
                {
                    filter = " VALID_FLAG='0'";
                    ((DataView)dgvRelation.DataSource).RowFilter = filter;
                }
                else
                {
                    ((DataView)dgvRelation.DataSource).RowFilter = filter;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            FrmHelpMatch help = new FrmHelpMatch((DataTable)dgvInsur.DataSource, (DataTable)dgvHIS.DataSource, _matchClass);
            help.ShowDialog();
            this.Refresh();
            if (help.IsOk == true)
            {
                this.toolStripProgressBar1.Maximum = help.matchDt.Rows.Count;
                this.toolStripProgressBar1.Minimum = 0;

                for (int i = 0; i < help.matchDt.Rows.Count; i++)
                {
                    string ncms_code = "";
                    string hospital_code = "";
                    string item_type = "";
                    if (_matchClass == HIS.Base_BLL.Enums.MatchClass.项目匹配)
                    {
                        ncms_code = help.matchDt.Rows[i]["center_code"].ToString();
                        hospital_code = help.matchDt.Rows[i]["his_code"].ToString();
                        item_type = "2";
                    }
                    else//药品匹配
                    {
                        ncms_code = help.matchDt.Rows[i]["center_code"].ToString();
                        hospital_code = help.matchDt.Rows[i]["his_code"].ToString();
                        item_type = "1";
                    }

                    try
                    {
                        datamatch.AddMatchRelation(ncms_code, hospital_code, item_type);
                    }
                    catch (Exception err)
                    {
                        MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    toolStripProgressBar1.Value = (i + 1);
                }
                MessageBox.Show("匹配成功！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadData();
                ShowData(true, true, true);
            }
        }

    }
}
