using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HIS_YZCXManager
{
    public partial class FrmProjectfeeQurey : GWI.HIS.Windows.Controls.BaseMainForm,IFrmPrjfeeQuery
    {
        private FrmPrjfeeQueryControl _control;
        public FrmProjectfeeQurey()
        {
            InitializeComponent();
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        public void RefreshPrjDocFee(DataTable presDocDt)
        { 
        }

        public void RefreshPrjDeptFee(DataTable presDeptDt)
        { 
        }

        public void RefreshItemTree(DataTable hsItemDt, DataTable bigItemDt)
        {
            try
            {
                if (hsItemDt != null  && bigItemDt != null)
                {
                    for (int index = 0; index < hsItemDt.Rows.Count; index++)
                    {
                        DataRow hsItemRow = hsItemDt.Rows[index];
                        TreeNode hsNode = new TreeNode(hsItemRow["ITEM_NAME"].ToString());
                        hsNode.Tag = hsItemRow["CODE"].ToString();
                        for (int temp = 0; temp < bigItemDt.Rows.Count; temp++)
                        {
                            DataRow bigItemRow = bigItemDt.Rows[temp];
                            if (bigItemRow["HS_CODE"].ToString() == hsNode.Tag.ToString())
                            {
                                TreeNode bigItemNode = new TreeNode(bigItemRow["ITEM_NAME"].ToString());
                                bigItemNode.Tag = bigItemRow["CODE"].ToString();
                                hsNode.Nodes.Add(bigItemNode);
                            }
                        }
                        treePorject.Nodes.Add(hsNode);
                    }
                }
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void FrmProjectfeeQurey_Load(object sender, EventArgs e)
        {
            try
            {
                _control = new FrmPrjfeeQueryControl(this);
                _control.LoadInitData();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }
    }
}
