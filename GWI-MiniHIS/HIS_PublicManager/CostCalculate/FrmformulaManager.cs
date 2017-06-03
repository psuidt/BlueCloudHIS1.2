using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace HIS_PublicManager
{
    public partial class FrmformulaManager : GWI.HIS.Windows.Controls.BaseForm
    {

        formulaManager.formulaManager fm = null;

        public FrmformulaManager()
        {
            InitializeComponent();
            fm = new HIS_PublicManager.formulaManager.formulaManager();
            fm.LoadData();
        }
       
        private void FrmformulaManager_Load(object sender, EventArgs e)
        {

            this.lbpattype.DataSource=  HIS.Public_BLL.OP_formulaManager.GetPatType();
            this.lbpattype.DisplayMember = "name";
            this.lbpattype.ValueMember = "code";

            List<formulaManager.SysVar> svlist = new List<HIS_PublicManager.formulaManager.SysVar>();
            formulaManager.SysVar sv = new HIS_PublicManager.formulaManager.SysVar();
            sv.name = "总金额";
            sv.value = "1000";
            svlist.Add(sv);
            sv = new HIS_PublicManager.formulaManager.SysVar();
            sv.name = "诊金";
            sv.value = "10";
            svlist.Add(sv);
            sv = new HIS_PublicManager.formulaManager.SysVar();
            sv.name = "自费金额";
            sv.value = "200";
            svlist.Add(sv);
            DataTable ddt= HIS.SYSTEM.PubicBaseClasses.ApiFunction.ObjToDataTable(svlist);
            this.lbsysvar.DataSource = ddt;       
            this.lbsysvar.ValueMember = "value";
            this.lbsysvar.DisplayMember = "name";         

        }

        //添加列
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            fm.AddCol();
        }
        //添加行
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            fm.AddRow();
        }
        //移除列
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            fm.DelCol();
        }
        //移除行
        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            fm.DelRow();
        }
        //保存
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            fm.SaveConfig();
            MessageBox.Show("保存成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
        }
        //导入
        private void toolStripButton9_Click(object sender, EventArgs e)
        {

        }
        //改变病人类型
        private void lbpattype_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dataGridViewEx1.DataSource = fm.ChangedData(this.lbpattype.SelectedValue.ToString());

            Edit();
            ChargeColWidth();
        }
        //关闭
        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //预览
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            Preview();
            
            this.dataGridViewEx1.DataSource = null;
            this.dataGridViewEx1.DataSource = fm.Preview();
            ChargeColWidth();
        }

        //计算
        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            this.toolStrip1.Focus();
            fm.Calculate((DataTable)this.dataGridViewEx1.DataSource);
            ChargeColWidth();
        }

        //编辑
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            Edit();
            this.dataGridViewEx1.DataSource = null;
            this.dataGridViewEx1.DataSource = fm.ChangedData(this.lbpattype.SelectedValue.ToString());
            ChargeColWidth();
        }
        
        //添加系统变量
        private void lbsysvar_DoubleClick(object sender, EventArgs e)
        {
            fm.SetSysVar(this.dataGridViewEx1.CurrentCell.ColumnIndex,this.dataGridViewEx1.CurrentCell.RowIndex,this.lbsysvar.Text,this.lbsysvar.SelectedValue.ToString());
        }

        public void ChargeColWidth()
        {
            if (this.dataGridViewEx1.Columns.Count != 0)
            {
                dataGridViewEx1.Columns[0].Width = 60;
                for (int i = 1; i < this.dataGridViewEx1.Columns.Count; i++)
                {
                    dataGridViewEx1.Columns[i].Width = 200;
                }
            }
        }

        private void Edit()
        {
            this.toolStripButton1.Enabled = true;
            this.toolStripButton2.Enabled = true;
            this.toolStripButton7.Enabled = true;
            this.toolStripButton8.Enabled = true;

            this.toolStripButton5.Enabled = true;
            this.toolStripButton9.Enabled = true;
            this.toolStripButton10.Enabled = false;

        }

        private void Preview()
        {
            this.toolStripButton1.Enabled = false;
            this.toolStripButton2.Enabled = false;
            this.toolStripButton7.Enabled = false;
            this.toolStripButton8.Enabled = false;

            this.toolStripButton5.Enabled = false;
            this.toolStripButton9.Enabled = false;
            this.toolStripButton10.Enabled = true;

        }
        
    }
}
