using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.Base_BLL;
using HIS.BLL;
using GWI.HIS.Windows.Controls;
using HIS.Base_BLL.Enums;
using System.Windows.Forms;
using HIS.Report_BLL;

namespace HIS_ReportManager.Controller
{
    class FrmGetInParaterController
    {

        private Panel _propertyPanel;
        private int isblobal;
        private long employeeid;
        private string employeename;
        private GWMHIS.BussinessLogicLayer.Classes.Deptment _dept;
        List<Paramater> _paralist;

        /// <summary>
        /// 控件
        /// </summary>
        public Panel propertyPanel
        {
            get
            {
                return _propertyPanel;
            }
            set
            {
                _propertyPanel = value;
            }
        }

        public FrmGetInParaterController(List<Paramater> pp, int Isblobal, GWMHIS.BussinessLogicLayer.Classes.User user, GWMHIS.BussinessLogicLayer.Classes.Deptment dept)
        {
            _paralist = pp;
            isblobal = Isblobal;
            employeeid = user.EmployeeID;
            employeename = user.Name;
            _dept = dept;
        }

        /// <summary>
        /// 初始化控件
        /// </summary>
        public void CreateControls()
        {
            propertyPanel.Controls.Clear();
            bool dtbegin = true;
            for (int i = 0; i < _paralist.Count; i++)
            {

                Paramater config = new Paramater();
                config = _paralist[i];

                Control ctrl = new Control();

                #region 设置控件和列样式
                if (config.UIC_TYPE == 2)
                {
                    ctrl = new CheckBox();
                    ((CheckBox)ctrl).Text = config.PARAMETER_CN;
                    ((CheckBox)ctrl).AutoSize = true;

                }
                else if (config.UIC_TYPE == 1)
                {

                    ctrl = new ComboBox();
                    DataTable dtcopy = new DataTable();
                    if (config.ENUMEID > 0)
                    {
                        string strWhere = HIS.BLL.Tables.base_enumeorder.ENUMEID + "=" + config.ENUMEID;
                        DataTable tb = HIS.SYSTEM.Core.BindEntity<HIS.Model.BASE_ENUMEORDER>.CreateInstanceDAL(HIS.Base_BLL.BaseDataController.oleDb).GetList(strWhere);

                        if (config.ENUMEID == 1) //医生枚举
                        {
                            DataRow[] rows = tb.Select("enumvalue <> " + employeeid + "");
                            dtcopy = tb.Clone();
                            if (rows != null && rows.Length > 0)
                            {

                                dtcopy.Clear();
                                DataRow row = dtcopy.NewRow();
                                row["NAME"] = employeename;
                                row["ENUMVALUE"] = employeeid;
                                dtcopy.Rows.Add(row);
                                for (int j = 0; j < rows.Length; j++)
                                {
                                    dtcopy.Rows.Add(tb.Rows[j].ItemArray);
                                }
                            }
                        }
                        else //if (HIS.BLL.Tables.base_enumeorder.ENUMEID.ToString().Trim() == "2") //科室枚举
                        {
                            DataRow[] rows = tb.Select("enumvalue <> " + _dept.DeptID + "");
                            dtcopy = tb.Clone();
                            if (rows != null && rows.Length > 0)
                            {

                                dtcopy.Clear();
                                DataRow row = dtcopy.NewRow();
                                row["NAME"] = _dept.Name; ;
                                row["ENUMVALUE"] = _dept.DeptID;
                                dtcopy.Rows.Add(row);
                                for (int j = 0; j < rows.Length; j++)
                                {
                                    dtcopy.Rows.Add(tb.Rows[j].ItemArray);
                                }
                            }
                        }
                        ((ComboBox)ctrl).DataSource = dtcopy;
                        ((ComboBox)ctrl).DisplayMember = HIS.BLL.Tables.base_enumeorder.NAME;
                        ((ComboBox)ctrl).ValueMember = HIS.BLL.Tables.base_enumeorder.ENUMVALUE;
                        ((ComboBox)ctrl).DropDownStyle = ComboBoxStyle.DropDown;
                        ((ComboBox)ctrl).MaxDropDownItems = 25;
                        ((ComboBox)ctrl).DropDownStyle = ComboBoxStyle.DropDownList;
                        //((ComboBox)ctrl).Text = employeename;
                        //((ComboBox)ctrl).SelectedValue = employeeid.ToString();

                    }
                    else
                    {
                        //如果是外键，设置外键的数据来源和显示字段，值字段
                        try
                        {
                            DataTable tb = BaseDataController.GetBaseTableData(config.FOREIGNER_TABLE, new string[] { "rtrim(cast(" + config.FOREIGNER_FIELD_DB_NAME + " as char(30))) as " + config.FOREIGNER_FIELD_DB_NAME, config.FOREIGNER_FIELD_CN_NAME }, config.FOREIGNER_FILTER_SQL);
                            if (tb.Rows.Count > 0 && config.FOREIGNER_TABLE == "HIS_WORKERS")
                            {

                                if (isblobal == 0)
                                {
                                    DataTable dbfor = tb.Clone();
                                    DataRow[] rows = tb.Select("workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID);
                                    foreach (DataRow dr in rows)
                                    {
                                        dbfor.Rows.Add(dr.ItemArray);
                                    }
                                    tb = new DataTable();
                                    tb = dbfor;

                                }
                                else
                                {
                                    //DataRow drr = tb.NewRow();
                                    //drr[0] = 0;
                                    //drr[1] = "全部医院";
                                    //tb.Rows.Add(drr);
                                    for (int index = 0; index < tb.Rows.Count; index++)
                                    {
                                        if (Convert.ToInt32(tb.Rows[index]["workid"].ToString()) == 42)
                                        {
                                            tb.Rows[index]["workid"] = 0;
                                            break;
                                        }
                                    }
                                }
                            }


                            ((ComboBox)ctrl).DataSource = tb;
                            ((ComboBox)ctrl).DisplayMember = config.FOREIGNER_FIELD_CN_NAME;
                            ((ComboBox)ctrl).ValueMember = config.FOREIGNER_FIELD_DB_NAME;
                            ((ComboBox)ctrl).DropDownStyle = ComboBoxStyle.DropDown;
                            ((ComboBox)ctrl).MaxDropDownItems = 25;
                            ((ComboBox)ctrl).DropDownStyle = ComboBoxStyle.DropDownList;
                        }
                        catch { }
                    }



                }
                else if (config.UIC_TYPE == 0)
                {


                    ctrl = new TextBox();
                    ((TextBox)ctrl).MaxLength = config.DATALENGTH;
                }
                else if (config.UIC_TYPE == 3)
                {

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
                }
                else
                {
                    ctrl = new TextBox();
                    ctrl.Text = employeeid.ToString();
                    ctrl.Visible = false;

                }



                #endregion

                #region 创建控件和列
                //定义标签
                Label lbl = new Label();
                lbl.Text = config.PARAMETER_CN != "" ? config.PARAMETER_CN : config.PARAMETER;
                lbl.AutoSize = true;
                int lblWidth = 0;
                int lblHeight = 0;
                using (System.Drawing.Graphics g = propertyPanel.CreateGraphics())
                {
                    System.Drawing.SizeF size = g.MeasureString(lbl.Text, propertyPanel.Font);
                    lblWidth = Convert.ToInt32(size.Width);
                    lblHeight = Convert.ToInt32(size.Height);
                }

                //定义控件
                ctrl.Name = config.PARAMETER;
                ctrl.Size = new System.Drawing.Size(config.WIDTH, config.HEIGHT);
                ctrl.Location = new System.Drawing.Point(config.UIC_X_LOCA, config.UIC_Y_LOCA);
                ctrl.Enabled = true;

                //ctrl.KeyPress += new KeyPressEventHandler(ctrl_KeyPress);
                ctrl.Tag = config;

                if (config.UIC_TYPE != 2 && config.UIC_TYPE != 4)
                {
                    lbl.Left = ctrl.Left - lblWidth - 4;
                    lbl.Top = ctrl.Top + (ctrl.Height - lblHeight);
                    //if (!config.ALLOW_EMPTY)
                    //    lbl.ForeColor = System.Drawing.Color.Red;
                    propertyPanel.Controls.Add(lbl);
                }


                propertyPanel.Controls.Add(ctrl);


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
                if ((ReControlTyp)paramaterlinshi.UIC_TYPE == ReControlTyp.CheckBox)
                {
                    objvalue = ((CheckBox)ctrl).Checked ? 1 : 0;

                }
                if ((ReControlTyp)paramaterlinshi.UIC_TYPE == ReControlTyp.ComboBox)
                {
                    objvalue = ((ComboBox)ctrl).SelectedValue;
                    objvaluecn = ((ComboBox)ctrl).Text;
                }
                if ((ReControlTyp)paramaterlinshi.UIC_TYPE == ReControlTyp.TextBox)
                {
                    objvalue = ((TextBox)ctrl).Text;

                }
                if ((ReControlTyp)paramaterlinshi.UIC_TYPE == ReControlTyp.dateTimePicker)
                {
                    objvalue = ((DateTimePicker)ctrl).Value;//.ToString("yyyy-MM-dd");
                    objvaluecn = ((DateTimePicker)ctrl).Value;//.ToString("yyyy-MM-dd");
                }

                paramaterlinshi.objvalue = objvalue;
                paramaterlinshi.objvalueCN = objvaluecn;
                linshipara.Add(paramaterlinshi);

            }
            Paramater paramater = new Paramater();
            return linshipara;

        }
    }
     
}
