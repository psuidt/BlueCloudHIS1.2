using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.Base_BLL.Enums;
using HIS.Report_BLL;
using HIS.MZ_BLL;

namespace HIS_ReportManager
{
    public partial class FrmQueryControl : GWI.HIS.Windows.Controls.BaseForm
    {
        List<Paramater> _paralist;
        int _employyid;
        int _deptid;
      public   bool isok = false;
        public FrmQueryControl(List<Paramater> pp,long employeeid,long deptid)
        {
            InitializeComponent();
            _paralist = pp;
            _employyid = Convert.ToInt32(employeeid);
            _deptid = Convert.ToInt32(deptid);
            CreateControls();
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        public void CreateControls()
        {
            Paramater _para = new Paramater();
            ParamProcess _paraProcess=new ParamProcess ();
            propertyPanel.Controls.Clear();
            bool dtbegin = true;
            Control ctrl = new Control();
            
            int y_local=9;
            for (int i = 0; i < _paralist.Count; i++)
            {
            
                Paramater config = new Paramater();
                config = _paralist[i];              
                
                #region 设置控件和列样式
                if (config.PARAMETER == "V_CURREMPLOYEEID")
                {   
                    ctrl = new TextBox();
                    ctrl.Enabled = false; 
                    ctrl.Text = _employyid.ToString();
                  
                }
                else if (config.PARAMETER =="V_CURRDEPTID")
                {
                    ctrl = new TextBox();
                    ctrl.Enabled = false;  
                    ctrl.Text = _deptid.ToString();
                                    
                }
                else if (config.UIC_TYPE == 4)
                {
                    #region  quertytext
                    GWI.HIS.Windows.Controls.QueryTextBox txtDepartment = new QueryTextBox();
                    txtDepartment.AllowSelectedNullRow = false;
                    txtDepartment.BackColor = System.Drawing.Color.White;
                    txtDepartment.DisplayField = "name";
                    txtDepartment.Location = new System.Drawing.Point(120, 12);
                    txtDepartment.MatchMode = GWI.HIS.Windows.Controls.MatchModes.ByAnyString;
                    txtDepartment.MemberField = "id";
                    txtDepartment.MemberValue = null;
                    txtDepartment.Name = "txtDepartment";
                    txtDepartment.NextControl = null;
                    txtDepartment.NextControlByEnter = false;
                    txtDepartment.OffsetX = 0;
                    txtDepartment.OffsetY = 0;
                    txtDepartment.QueryFields = new string[] {
                   "PY_CODE"};
                    txtDepartment.SelectedValue = null;
                    txtDepartment.SelectionCardAlternatingRowBackColor = System.Drawing.Color.WhiteSmoke;
                    txtDepartment.SelectionCardBackColor = System.Drawing.Color.White;
                    txtDepartment.SelectionCardColumnHeaderHeight = 20;
                    GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn1 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
                    GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn2 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
                    GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn3 = new GWI.HIS.Windows.Controls.SelectionCardColumn();
                    GWI.HIS.Windows.Controls.SelectionCardColumn selectionCardColumn4= new GWI.HIS.Windows.Controls.SelectionCardColumn();
                    selectionCardColumn1.AutoFill = true;
                    selectionCardColumn1.DataBindField = "name";
                    selectionCardColumn1.HeaderText = "名称";
                    selectionCardColumn1.IsNameField = false;
                    selectionCardColumn1.IsSeachColumn = true;
                    selectionCardColumn1.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
                    selectionCardColumn1.Visiable = true;
                    selectionCardColumn1.Width = 75;
                    selectionCardColumn2.AutoFill = false;
                    selectionCardColumn2.DataBindField = "PY_CODE";
                    selectionCardColumn2.HeaderText = "拼音码";
                    selectionCardColumn2.IsNameField = false;
                    selectionCardColumn2.IsSeachColumn = true;
                    selectionCardColumn2.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
                    selectionCardColumn2.Visiable = false;
                    selectionCardColumn2.Width = 75;
                    selectionCardColumn3.AutoFill = false;
                    selectionCardColumn3.DataBindField = "id";
                    selectionCardColumn3.HeaderText = "id";
                    selectionCardColumn3.IsNameField = false;
                    selectionCardColumn3.IsSeachColumn = false;
                    selectionCardColumn3.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
                    selectionCardColumn3.Visiable = false;
                    selectionCardColumn3.Width = 75;


                    DataTable dtSource = new DataTable();
                    if (config.FOREIGNER_FILTER_SQL != "")
                    {
                        dtSource=_para.GetDataSource(config.FOREIGNER_FILTER_SQL);
                    }
                    else
                    {
                        if (config.ENUMEID != -1)
                        {
                            dtSource=_para.GetDataSource(_paraProcess.GetEnumSql(config.ENUMEID).REMARK);
                        }
                    }
                    if (dtSource.Columns.Contains("备注"))
                    {
                        selectionCardColumn1.AutoFill = false;
                        selectionCardColumn4.AutoFill = true;
                        selectionCardColumn4.DataBindField = "备注";
                        selectionCardColumn4.HeaderText = "备注";
                        selectionCardColumn4.IsNameField = false;
                        selectionCardColumn4.IsSeachColumn = false;
                        selectionCardColumn4.TextAlign = System.Windows.Forms.DataGridViewContentAlignment.NotSet;
                        selectionCardColumn4.Visiable = true;
                        selectionCardColumn4.Width =200;
                        txtDepartment.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3,
         selectionCardColumn4           };
                        txtDepartment.SelectionCardWidth = 350;
                    }
                    else
                    {
                        txtDepartment.SelectionCardColumns = new GWI.HIS.Windows.Controls.SelectionCardColumn[] {
        selectionCardColumn1,
        selectionCardColumn2,
        selectionCardColumn3
                 };
                        txtDepartment.SelectionCardWidth = 150;
                    }
                    txtDepartment.SelectionCardFont = null;
                    txtDepartment.SelectionCardHeight = 200;
                    txtDepartment.SelectionCardInfoLabelBackColor = System.Drawing.Color.Empty;
                    txtDepartment.SelectionCardRowHeaderWidth = 35;
                    txtDepartment.SelectionCardRowHeight = 23;
                    txtDepartment.SelectionCardSelectedRowBackColor = System.Drawing.Color.DarkBlue;
                    txtDepartment.SelectionCardType = GWI.HIS.Windows.Controls.SelectionCardTypes.List;
                  //  txtDepartment.SelectionCardWidth = 225;
                    txtDepartment.ShowRowNumber = true;
                    txtDepartment.ShowSelectionCardAfterEnter = true;
                    txtDepartment.Size = new System.Drawing.Size(123, 21);
                    txtDepartment.TabIndex = 0;
                    txtDepartment.TextFormat = GWI.HIS.Windows.Controls.TextFormatStyle.AnyString;
                    txtDepartment.Visible = true;
                    #endregion
                    if(config.FOREIGNER_FILTER_SQL!="")
                    {
                    txtDepartment.SetSelectionCardDataSource(dtSource);
                    }
                    else
                    {
                        if(config.ENUMEID!=-1)
                        {
                         txtDepartment.SetSelectionCardDataSource(dtSource); 
                        }
                    }
                    txtDepartment.DisplayField = "name";
                    txtDepartment.MemberField = "id";
                    txtDepartment.MemberValue = -1;
                    ctrl = txtDepartment;
                }
                else if (config.UIC_TYPE == 2)
                {
                    #region checkbox
                    ctrl = new CheckBox();
                    ((CheckBox)ctrl).Text = config.PARAMETER_CN;
                    ((CheckBox)ctrl).AutoSize = true;
                    #endregion
                }
                else if (config.UIC_TYPE == 1)
                {
                    #region combobox
                    ctrl = new ComboBox();

                    if (config.FOREIGNER_FILTER_SQL != "")
                    {
                        ((ComboBox)ctrl).DataSource = _para.GetDataSource(config.FOREIGNER_FILTER_SQL);
                    }
                    else
                    {
                        if (config.ENUMEID != -1)
                        {
                            string sql = _paraProcess.GetEnumSql(config.ENUMEID).REMARK;
                            if (sql != null && sql!="")
                            {
                                ((ComboBox)ctrl).DataSource = _para.GetDataSource(sql);
                            }
                            else
                            {
                                ((ComboBox)ctrl).DataSource = _paraProcess.GetEnumOrders(config.ENUMEID);
                            }
                        }
                    }
                    ((ComboBox)ctrl).DisplayMember = "name";
                    ((ComboBox)ctrl).ValueMember = "id";
                    ((ComboBox)ctrl).MaxDropDownItems = 25;
                    ((ComboBox)ctrl).DropDownStyle = ComboBoxStyle.DropDownList;

                    #endregion
                }
                else if (config.UIC_TYPE == 0)
                {
                    #region textbox
                    ctrl = new TextBox();
                    
                    ((TextBox)ctrl).MaxLength = config.DATALENGTH;
                    #endregion
                }
                else if (config.UIC_TYPE == 3)
                {
                    #region datetimepicker
                    DateTimePicker dtpicter = new DateTimePicker();
                    dtpicter.CustomFormat = "yyyy-MM-dd HH:mm:ss";
                    dtpicter.Format = DateTimePickerFormat.Custom;

                    if (dtbegin)
                    {
                        dtpicter.Value = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd") + " 00:00:00");
                        dtbegin = false;
                    }
                    else
                    {
                        dtpicter.Value = Convert.ToDateTime(DateTime.Now.Date.ToString("yyyy-MM-dd") + " 23:59:59");
                    }
                    ctrl = dtpicter;
                    #endregion
                }
                else
                {

                }            

                #endregion

                #region 创建控件和列
               // 定义标签
               Label lbl = new Label();
               lbl.Text = config.PARAMETER_CN != "" ? config.PARAMETER_CN : config.PARAMETER;
                lbl.AutoSize = true;
               int   lblWidth = 0;
               int   lblHeight = 0;
                using (System.Drawing.Graphics g = propertyPanel.CreateGraphics())
                {
                    System.Drawing.SizeF size = g.MeasureString(lbl.Text, propertyPanel.Font);
                    lblWidth = Convert.ToInt32(size.Width);
                    lblHeight = Convert.ToInt32(size.Height);
                }

                //定义控件
                ctrl.Name = config.PARAMETER;
                ctrl.Size = new System.Drawing.Size(140, 21);
                ctrl.Location = new System.Drawing.Point(117, y_local);    
                ctrl.Tag = config;

                if (config.UIC_TYPE != 2)
                {
                    lbl.Left = ctrl.Left - lblWidth - 4;
                    lbl.Top = ctrl.Top + (21 - lblHeight);                  
                    propertyPanel.Controls.Add(lbl);
                }
                if (_paralist[i].PARAMETER_TYPE == "OUT")
                {
                    ctrl.Visible = false;
                    lbl.Visible = false;
                }
                propertyPanel.Controls.Add(ctrl);
                y_local += 27;

                #endregion
            }

        }

        public List<Paramater> GetParaValue()
        {
            List<Paramater> linshipara = new List<Paramater>();
            foreach (Control ctrl in propertyPanel.Controls)
            {
                object objvalue = null;
                object objvaluecn = null;
                if (ctrl is Label)
                    continue;
                if (ctrl.Tag == null)
                    continue;
                Paramater paramaterlinshi = new Paramater();
                paramaterlinshi = (Paramater)ctrl.Tag;
                if ((ReControlTyp)paramaterlinshi.UIC_TYPE == ReControlTyp.QueryText)
                {
                    objvalue = ((GWI.HIS.Windows.Controls.QueryTextBox)ctrl).MemberValue;
                    objvaluecn = ((GWI.HIS.Windows.Controls.QueryTextBox)ctrl).Text;
                }
                else if ((ReControlTyp)paramaterlinshi.UIC_TYPE == ReControlTyp.CheckBox)
                {
                    objvalue = ((CheckBox)ctrl).Checked ? 1 : 0;

                }
                else if ((ReControlTyp)paramaterlinshi.UIC_TYPE == ReControlTyp.ComboBox)
                {
                    objvalue = ((ComboBox)ctrl).SelectedValue;
                    objvaluecn = ((ComboBox)ctrl).Text;
                }
               else if ((ReControlTyp)paramaterlinshi.UIC_TYPE == ReControlTyp.TextBox)
                {
                    objvalue = ((TextBox)ctrl).Text;

                }
                else if ((ReControlTyp)paramaterlinshi.UIC_TYPE == ReControlTyp.dateTimePicker)
                {
                    objvalue = ((DateTimePicker)ctrl).Value;//.ToString("yyyy-MM-dd");
                    objvaluecn = ((DateTimePicker)ctrl).Value;//.ToString("yyyy-MM-dd");
                }
                else
                { }
                paramaterlinshi.objvalue = objvalue;
                paramaterlinshi.objvalueCN = objvaluecn;
                linshipara.Add(paramaterlinshi);

            }
            Paramater paramater = new Paramater();
            return linshipara;

        }

        //给控件赋值
        public void setParamValue(List<Paramater> paramaters)
        {
            foreach (Control ctrl in propertyPanel.Controls)
            {
                if (ctrl.GetType() == typeof(Label))
                {
                    continue;
                }
                for (int j = 0; j < paramaters.Count; j++)
                {
                    if (ctrl.Name == paramaters[j].PARAMETER)
                    {
                        ctrl.Tag = paramaters[j];
                        if ((ReControlTyp)paramaters[j].UIC_TYPE == ReControlTyp.dateTimePicker)
                        {
                            ((DateTimePicker)ctrl).Value =Convert.ToDateTime( paramaters[j].objvalue); 
                        }
                        else if ((ReControlTyp)paramaters[j].UIC_TYPE == ReControlTyp.ComboBox)
                        {
                            ((ComboBox)ctrl).SelectedValue = paramaters[j].objvalue;
                            ((ComboBox)ctrl).Text = paramaters[j].objvalueCN.ToString();
                        }
                        else if ((ReControlTyp)paramaters[j].UIC_TYPE == ReControlTyp.QueryText)
                        {
                           ((GWI.HIS.Windows.Controls.QueryTextBox)ctrl).MemberValue = paramaters[j].objvalue;
                            ((GWI.HIS.Windows.Controls.QueryTextBox)ctrl).Text = paramaters[j].objvalueCN.ToString();
                        }
                        else if ((ReControlTyp)paramaters[j].UIC_TYPE == ReControlTyp.TextBox)
                        {
                         ((TextBox)ctrl).Text = paramaters[j].objvalue.ToString();
                        }
                        else if ((ReControlTyp)paramaters[j].UIC_TYPE == ReControlTyp.CheckBox)
                        {
                            ((CheckBox)ctrl).Checked = paramaters[j].objvalue.ToString() == "1" ? true : false;
                        }
                        else
                        { }
                        break;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {          
            isok = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            isok = false;
            this.Close();
        }
    }
}
