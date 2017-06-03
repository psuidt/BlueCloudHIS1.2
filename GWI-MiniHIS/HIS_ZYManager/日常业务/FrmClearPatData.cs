using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.ZY_BLL.ObjectModel.CostManager;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel;
using HIS.ZY_BLL;

namespace HIS_ZYManager
{
    public partial class FrmClearPatData : ZYBaseFrom
    {
        private IcostManager icM = null;

        public FrmClearPatData()
        {
            InitializeComponent();
            base.HIS_DoubleClick += new lvPatList_DoubleClickEvent(FrmCharge_HIS_DoubleClick);
            icM = ObjectFactory.GetObject<IcostManager>(typeof(ZY_CostMaster));
            
        }
        //双击病人列表
        private void FrmCharge_HIS_DoubleClick(object sender, EventArgs e)
        {
            icM.PatListID = zy_PatList.PatListID;
            this.BindDataGrid();
        }
        //绑定数据
        public void BindDataGrid()
        {
            this.tbInpatNo.Text = base.zy_PatList.CureNo;
            this.tbpatName.Text = base.zy_PatList.patientInfo.PatName;
            PatFee patFee = icM.GetPatFee();
            this.lbChargeTolFee.Text = patFee.chargeFee.ToString();
            this.lbCoseTolFee.Text = patFee.costFee.ToString();
        }
        //一键清零
        private void btQuest_Click(object sender, EventArgs e)
        {
            if (base.zy_PatList != null)
            {
                if (MessageBox.Show("您确定要清零该病人吗？数据清零后不能复原，请认真核对！", "询问", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    bool b = icM.ClearPatData(base.zy_PatList.PatListID);
                    if (b)
                        MessageBox.Show("清零成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    else
                        MessageBox.Show("清零失败！", "提示", MessageBoxButtons.OK, MessageBoxIcon.None, MessageBoxDefaultButton.Button1);
                    BindDataGrid();
                }
            }
        }
        //关闭
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
