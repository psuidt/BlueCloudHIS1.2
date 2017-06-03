using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GWI.HIS.Windows.Controls;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.Base_BLL.Enums;
using HIS.Base_BLL;
using HIS.Report_BLL;
using System.Reflection;


namespace HIS_ReportManager
{
    public partial class FrmVindicatorConfig : BaseForm
    {
       private int _Reportid;
       ParamProcess _paramProcess;
       private Paramater _currentParam;
       private DataTable BaseTable=new DataTable(); 
       
       public FrmVindicatorConfig(int reportid)
       {
           InitializeComponent();
           _Reportid = reportid;
       }
       private void loadReport()
       {

           List<Paramater> paralist ;
           paralist = _paramProcess.getPara(_Reportid);

           //DataTable Paradat = _paramProcess.getParamlist(_Reportid);
           tvwField.Nodes.Clear();
           TreeNode node = new TreeNode("报表参数集合", 15, 14);           
           Paramater mould;
           mould = new  Paramater();
           mould.PARAMETERID = -1;
           mould.PARAMETER = "公共报表";
           node.Tag = mould;
           tvwField.Nodes.Add(node);
           TreeNode childnode;          
           foreach (Paramater para in paralist)
           {
              
               childnode = new TreeNode(para.PARAMETER, 15, 14);
               childnode.Tag = para;
               node.Nodes.Add(childnode);
           }

       }

       private void FrmVindicatorConfig_Load(object sender, EventArgs e)
       {
           _paramProcess = new ParamProcess();

           foreach (object obj in Enum.GetValues(typeof(HIS.Base_BLL.Enums.FIELD_DB_TYPE)))
               cboParam.Items.Add(obj.ToString());
           cboParam.SelectedIndex = 0;

           foreach (object obj in Enum.GetValues(typeof(HIS.Report_BLL.ReControlTyp)))
               cboUC.Items.Add(obj.ToString());
           cboUC.SelectedIndex = 0;

           foreach (object obj in Enum.GetValues(typeof(HIS.Base_BLL.Enums.FIELD_MARK_TYPE)))
               cboEnume.Items.Add(obj.ToString());
           cboEnume.Text = HIS.Base_BLL.Enums.FIELD_MARK_TYPE.无.ToString();
           DataTable enume = _paramProcess.getEnum();
           DataRow dr = enume.NewRow();
           dr["ENUMNAME"] = "";
           enume.Rows.Add(dr);
           this.cboEnume.DataSource = enume;
           this.cboEnume.SelectedIndex=-1;
          
           

           loadReport();
       }

       private void chkForignerKey_CheckedChanged(object sender, EventArgs e)
       {
           if (this.chkForignerKey.Checked == true)
           {
               grpForignerInfo.Enabled = true;
               BaseTable = HIS.Base_BLL.BaseDataController.GetSystemTableList();
               cboForignerTable.DisplayMember = "NAME";
               cboForignerTable.ValueMember = "NAME";
               cboForignerTable.DataSource = BaseTable;

           }
           else
               grpForignerInfo.Enabled = false;
           //{
           //    this.cboForignerID_Field.Enabled = true;
           //    this.cboForignerName_Field.Enabled = true;
           //    this.cboForignerTable.Enabled = true;
           //    this.txtFilterSql.Enabled = true;
           //    this.btnTestSQL.Enabled = true;
           //}
           //else
           //{
           //    this.cboForignerID_Field.Enabled = false;
           //    this.cboForignerName_Field.Enabled = false;
           //    this.cboForignerTable.Enabled = false;
           //    this.txtFilterSql.Enabled = false;
           //    this.btnTestSQL.Enabled = false; 
           //}
       }

       /// <summary>
       /// 获取指定的表字段
       /// </summary>
       /// <param name="TableName"></param>
       /// <returns></returns>
       private List<string> GetSystemFieldList(string TableName)
       {
           string dllName = System.Windows.Forms.Application.StartupPath + "\\HIS.Entity.dll";
           Assembly assembly = Assembly.LoadFile(dllName);
           string typeName = "HIS.Model." + TableName;
           object obj = assembly.CreateInstance(typeName, true);
           List<string> lstField = new List<string>();
           if (obj != null)
           {
               PropertyInfo[] properies = obj.GetType().GetProperties();
               for (int i = 0; i < properies.Length; i++)
               {
                   lstField.Add(properies[i].Name);
               }
           }
           return lstField;
       }

       private void Combox_SelectedIndexChanged(object sender, EventArgs e)
       {
           ComboBox cbo = (ComboBox)sender;

           if (cbo.Name == cboForignerTable.Name)
           {
               #region ..........
               List<string> lstField = GetSystemFieldList(cboForignerTable.Text);

               cboForignerID_Field.Items.Clear();
               cboForignerName_Field.Items.Clear();
               for (int i = 0; i < lstField.Count; i++)
               {
                   cboForignerID_Field.Items.Add(lstField[i]);
                   cboForignerName_Field.Items.Add(lstField[i]);
               }
               if (cboForignerID_Field.Items.Count > 0)
                   cboForignerID_Field.SelectedIndex = 0;
               if (cboForignerName_Field.Items.Count > 0)
                   cboForignerName_Field.SelectedIndex = 0;
               #endregion
           }

           //if (cbo.Name == cboParam.Name)
           //{
           //    #region ..........
           //    if (cboParam.SelectedIndex == -1)
           //        return;

           //    HIS.Base_BLL.Enums.FIELD_DB_TYPE dbType = HIS.Base_BLL.Enums.FIELD_DB_TYPE.字符;

           //    foreach (object obj in Enum.GetValues(typeof(HIS.Base_BLL.Enums.FIELD_DB_TYPE)))
           //    {
           //        if (obj.ToString() == cboParam.Text)
           //        {
           //            dbType = (HIS.Base_BLL.Enums.FIELD_DB_TYPE)obj;
           //            break;
           //        }
           //    }

           //    switch (dbType)
           //    {
           //        case HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字:
           //            txtMaxLength.Enabled = false;
           //            break;
           //        case HIS.Base_BLL.Enums.FIELD_DB_TYPE.字符:
                       
           //            txtMaxLength.Enabled = true;
           //            if (cboUC.Text == HIS.Base_BLL.Enums.ControlType.CheckBox.ToString())
           //                cboUC.Text = HIS.Base_BLL.Enums.ControlType.TextBox.ToString();
           //            break;
           //        case HIS.Base_BLL.Enums.FIELD_DB_TYPE.日期:
                       
           //            txtMaxLength.Enabled = false;
           //            break;
           //        default:                    
                       
           //            chkForignerKey.Checked = false;
           //            txtMaxLength.Enabled = false;
           //            break;
           //    }
           //    #endregion
           //}
           if (cbo.Name == cboUC.Name)
           {
               if (cboUC.Text == HIS.Base_BLL.Enums.ControlType.CheckBox.ToString())
               {
                   //if (cboParam.Text != HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字.ToString())
                   //{
                   //    cboParam.Text = HIS.Base_BLL.Enums.FIELD_DB_TYPE.数字.ToString();
                   //}
               }
           }
       }

       private void btnSave_Click(object sender, EventArgs e)
       {
           if(_currentParam==null)
           {
              return;
           }
           getParamData();
           _currentParam.UpateParamter();
           showParaData();
           

       }

        /// <summary>
        /// 获取当前参数数据
        /// </summary>
       private void getParamData()
       {
           if (chkForignerKey.Checked == false)
           {
               _currentParam.FOREIGNER_TABLE = "";
               _currentParam.FOREIGNER_FIELD_CN_NAME = "";
               _currentParam.FOREIGNER_FIELD_DB_NAME = "";
               _currentParam.FOREIGNER_FILTER_SQL = "";

           }
           else
           {
               _currentParam.FOREIGNER_TABLE = this.cboForignerTable.Text.Trim();
               _currentParam.FOREIGNER_FIELD_CN_NAME = this.cboForignerID_Field.Text.Trim();
               _currentParam.FOREIGNER_FIELD_DB_NAME = this.cboForignerName_Field.Text.Trim();
               _currentParam.FOREIGNER_FILTER_SQL = this.txtFilterSql.Text.Trim();

           }
           if (this.cboEnume.SelectedIndex != -1&&this.cboEnume.Text!="")
               _currentParam.ENUMEID = Convert.ToInt32(this.cboEnume.SelectedValue.ToString());
           else
               _currentParam.ENUMEID = 0;
           _currentParam.UIC_TYPE = this.cboUC.SelectedIndex;
           _currentParam.UIC_X_LOCA = int.Parse(this.txtLocationX.Text.Trim());
           _currentParam.UIC_Y_LOCA = int.Parse(this.txtLocationY.Text.Trim());
           _currentParam.WIDTH = int.Parse(this.txtWidth.Text.Trim());
           _currentParam.HEIGHT = int.Parse(this.txtHeight.Text.Trim());

 
       }


       
       private void tvwField_AfterSelect(object sender, TreeViewEventArgs e)
       {
           if (tvwField.SelectedNode.Text == "报表参数集合")
               return;
           _currentParam = (Paramater)this.tvwField.SelectedNode.Tag;
           showParaData();


       }
        /// <summary>
        /// 展现参数数据
        /// </summary>
       private void showParaData()
       {
           this.txtParaName.Text = _currentParam.PARAMETER;
           this.txtParamter_cn.Text = _currentParam.PARAMETER_CN;
           this.txtMaxLength.Text = _currentParam.DATALENGTH.ToString();
           this.cboParam.SelectedIndex = _currentParam.PARAMDATATYPE;
           this.cboUC.SelectedIndex = _currentParam.UIC_TYPE;
           this.txtFilterSql.Text = _currentParam.FOREIGNER_FILTER_SQL;
           this.txtWidth.Text = _currentParam.WIDTH.ToString();
           this.txtHeight.Text = _currentParam.HEIGHT.ToString();
           this.txtLocationX.Text = _currentParam.UIC_X_LOCA.ToString();
           this.txtLocationY.Text = _currentParam.UIC_Y_LOCA.ToString();
           if (_currentParam.ENUMEID > 0)
               this.cboEnume.SelectedValue = _currentParam.ENUMEID;
           else
               this.cboEnume.SelectedIndex = -1;
           if (_currentParam.FOREIGNER_TABLE != "")
           {
               this.chkForignerKey.Checked = true;
               this.cboForignerTable.SelectedValue = _currentParam.FOREIGNER_TABLE;
               this.cboForignerID_Field.Text = _currentParam.FOREIGNER_FIELD_CN_NAME;
               this.cboForignerName_Field.Text = _currentParam.FOREIGNER_FIELD_DB_NAME;
               this.txtFilterSql.Text = _currentParam.FOREIGNER_FILTER_SQL;
           }
           else
               this.chkForignerKey.Checked = false;


       }

       private void btnClose_Click(object sender, EventArgs e)
       {
           this.Close();
       }

        /// <summary>
        /// 刷新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       private void btnRefresh_Click(object sender, EventArgs e)
       {
           showParaData();
       }

       private void btnTestSQL_Click(object sender, EventArgs e)
       {
          
           try
           {
               if (TestSQL())
               {
                   MessageBox.Show("SQL语句正确！", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
               }
           }
           catch (Exception err)
           {
               MessageBox.Show(err.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }


       }

       /// <summary>
       /// 测试SQL是否正确
       /// </summary>
       /// <returns></returns>
       public bool TestSQL()
       {
           try
           {
               BaseDataController.GetDataTable(this.cboForignerTable.Text.Trim(),
                   new string[] { this.cboForignerID_Field.Text.Trim(), this.cboForignerName_Field.Text.Trim() },
                   this.txtFilterSql.Text.Trim());
               return true;
           }
           catch (Exception err)
           {
               throw err;
           }
       }

       private void btnSetting_Click(object sender, EventArgs e)
       {
           FrmSetLocation frmSetLocation = new FrmSetLocation( _paramProcess.getParaIN(_Reportid));

           if (frmSetLocation.ShowDialog() == DialogResult.OK)
           {
               List<Paramater> paraqw = frmSetLocation.LocationSettings;
               foreach (Paramater pp in paraqw)
               {
                   pp.UpateParamter();
               }
               //controller.AccecptLoactionSetting(frmSetLocation.LocationSettings);
               //SelectedDefaultNode();
           }
       }

    }
}
