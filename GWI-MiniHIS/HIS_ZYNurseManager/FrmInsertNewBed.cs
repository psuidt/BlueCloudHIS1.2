using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using HIS.SYSTEM.BussinessLogicLayer.Classes;
using GWMHIS.BussinessLogicLayer.Classes;
using HIS.SYSTEM.PubicBaseClasses;
using HIS.ZYNurse_BLL;



namespace HIS_ZYNurseManager
{
    public partial class FrmInsertNewBed : GWI.HIS.Windows.Controls.BaseMainForm
    {
        private  OP_Bed op_bed = new OP_Bed();
        bool currdeptonly = true;//是否只显示当前科室床位
        string dept_id;
        string bed_no;
        string dept_name;
        DataTable dt;

        #region 属性
        private User _currentUser;
        /// <summary>
        /// 当前用户对象
        /// </summary>
        public User currentUser
        {
            get
            {
                return _currentUser;
            }
        }

        private Deptment _currentDept;
        /// <summary>
        /// 当前科室对象
        /// </summary>
        public Deptment currentDept
        {
            get
            {
                return _currentDept;
            }
        }
        #endregion

        #region 构造方法
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentUserId"></param>
        /// <param name="currentDeptId"></param>
        /// <param name="chineseName"></param>
        /// <param name="showcurrdept">是否只显示当前科室床位</param>
        public FrmInsertNewBed(long currentUserId, long currentDeptId, string chineseName,bool showcurrdept)
        {
            InitializeComponent();
            _currentUser = new User(currentUserId);
            _currentDept = new Deptment(currentDeptId);
            this.Text = chineseName;
            dt = op_bed.getAllBedInfo(_currentDept.DeptID);
            dataGridViewEx1.DataSource = dt;
            cmbDeptName.DisplayMember = "name";
            cmbDeptName.ValueMember = "code";
            currdeptonly = showcurrdept;
            cmbDeptName.DataSource = op_bed.getdept();
            label3.Visible = textBox3.Visible = false;//TODO:屏蔽房间号
            dataGridViewEx1.Columns["Column1"].Visible = label1.Visible = cmbDeptName.Visible = !currdeptonly;
            InitListView(_currentDept.DeptID);
            cmbDeptName.SelectedValue = _currentDept.DeptID;
            InitGroupBox2(_currentDept.DeptID);
        }
        #endregion

        #region 删除床位
        /// <summary>
        /// 床位删除操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btncancelbed_Click(object sender, EventArgs e)
        {
            int rownum = dataGridViewEx1.CurrentCell.RowIndex;
            string deptid = dataGridViewEx1[2, rownum].Value.ToString();
            string bedno = dataGridViewEx1[1, rownum].Value.ToString(); 
            string deptname=dataGridViewEx1[0, rownum].Value.ToString();
            if (bed_no != "" && dept_id != "" && dept_name != "")
            {
                deptid = dept_id;
                bedno = bed_no;
                deptname = dept_name;
            }
            DialogResult dr=MessageBox.Show("您确定删除"+deptname+"【"+bedno+"】号床吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr==DialogResult.Yes)
            {
                bool assignresult = op_bed.cancelbedassign(deptid,bedno);
                if (assignresult == true)
                {
                    MessageBox.Show("床位删除成功！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGridViewEx1.DataSource = op_bed.getAllBedInfo(_currentDept.DeptID);
                    InitListView(Convert.ToInt64(deptid));
                    InitGroupBox2(Convert.ToInt64(deptid));

                }
                else
                {
                    MessageBox.Show("该床位已有病人存在，不允许删除该床位！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                return;
            }
        }
        #endregion

        #region 添加床位
        /// <summary>
        /// /// <summary>
        /// 添加床位操作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btninsertbed_Click(object sender, EventArgs e)
        {
            OP_Bed op_bed = new OP_Bed();
            bool insertResult;
            HIS.Model.ZY_NURSE_BED bedlist = new HIS.Model.ZY_NURSE_BED();
            if (chkaddbed.Checked == false)
            {
                bedlist.BED_NO = queryTextBox1.Text;
            }
            else
            {
                bedlist.BED_NO = "加"+queryTextBox1.Text;
            }
            //如果只显示当前科室
            if (currdeptonly)
                bedlist.DEPT_ID = Convert.ToInt32(_currentDept.DeptID);
            else
                bedlist.DEPT_ID = Convert.ToInt32(cmbDeptName.SelectedValue.ToString());
            bedlist.ROOM_NO = textBox3.Text;
            if (bedlist.BED_NO == "")
            {
                MessageBox.Show("床号不能为空，请输入床号！", "提示", MessageBoxButtons.OK);
                return;
            }
            else
            {
                insertResult = op_bed.insertNewBed(bedlist);
            }
            if (insertResult == true)
            {
                MessageBox.Show("添加床位成功", "提示", MessageBoxButtons.OK);
                dataGridViewEx1.DataSource = op_bed.getAllBedInfo(_currentDept.DeptID);
                InitListView(Convert.ToInt64(cmbDeptName.SelectedValue.ToString()));
                InitGroupBox2(Convert.ToInt64(cmbDeptName.SelectedValue.ToString()));
            }
            else
            {
                MessageBox.Show("该床位已经存在，请重新输入床位号", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        #endregion

        #region 科室名称更换选项
        private void cmbDeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            dt = op_bed.getAllBedInfo(Convert.ToInt64(cmbDeptName.SelectedValue));
            dataGridViewEx1.DataSource = dt;
            InitListView(Convert.ToInt64(cmbDeptName.SelectedValue));
            InitGroupBox2(Convert.ToInt64(cmbDeptName.SelectedValue));
        }
        #endregion

        #region 床位列表Paint事件
        private void dataGridViewEx1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < dataGridViewEx1.Rows.Count; i++)
            {
                if (dataGridViewEx1.Rows[i].Cells["Used"].Value.ToString() != "")
                    dataGridViewEx1.Rows[i].DefaultCellStyle.BackColor = Color.Lavender;
                else
                    dataGridViewEx1.Rows[i].DefaultCellStyle.BackColor = Color.White;
            }
        }
        #endregion

        #region 初始化床位ListView
        /// <summary>
        /// 初始化床位ListView
        /// </summary>
        public void InitListView(long deptid)
        {
            dt = op_bed.getAllBedInfo(deptid);
            listView1.LargeImageList = imageList1;
            if (listView1.Items.Count > 0)
                listView1.Items.Clear();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ListViewItem lvi = new ListViewItem();
                if (dt.Rows[i]["Bed_Sex"].ToString() == "")
                {
                    lvi.ImageIndex = 0;
                    lvi.Text = dt.Rows[i]["Bed_NO"].ToString() + "床";
                    lvi.Tag = dt.Rows[i]["Dept_Id"].ToString() + "-" + dt.Rows[i]["Name"].ToString();//科室ID和科室名称
                }
                else if (dt.Rows[i]["Bed_Sex"].ToString() == "男")
                {
                    lvi.ImageIndex = 5;
                    lvi.Text = dt.Rows[i]["Bed_NO"].ToString() + "床";
                    lvi.Tag = dt.Rows[i]["Dept_Id"].ToString() + "-" + dt.Rows[i]["Name"].ToString();//科室ID和科室名称
                }
                else if (dt.Rows[i]["Bed_Sex"].ToString() == "女")
                {
                    lvi.ImageIndex = 10;
                    lvi.Text = dt.Rows[i]["Bed_NO"].ToString() + "床";
                    lvi.Tag = dt.Rows[i]["Dept_Id"].ToString() + "-" + dt.Rows[i]["Name"].ToString();//科室ID和科室名称
                }
                else
                {
                    lvi.ImageIndex = 19;
                    lvi.Text = dt.Rows[i]["Bed_NO"].ToString() + "床";
                    lvi.Tag = dt.Rows[i]["Dept_Id"].ToString() + "-" + dt.Rows[i]["Name"].ToString();//科室ID和科室名称
                }
                listView1.Items.Add(lvi);
            }
        }
        #endregion

        #region 退出
        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 选中listView1中的项
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            dept_id = listView1.FocusedItem.Tag.ToString().Substring(0, listView1.FocusedItem.Tag.ToString().IndexOf("-"));//获取科室ID
            bed_no = listView1.FocusedItem.Text.Substring(0, listView1.FocusedItem.Text.IndexOf("床"));
            dept_name = listView1.FocusedItem.Tag.ToString().Substring(listView1.FocusedItem.Tag.ToString().IndexOf("-") + 1);
        }
        #endregion

        #region 刷新
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            InitListView(_currentDept.DeptID);
            cmbDeptName.SelectedValue = _currentDept.DeptID;
            InitGroupBox2(_currentDept.DeptID);
        }
        #endregion

        #region 初始化GroupBox2
        /// <summary>
        /// 初始化GroupBox2
        /// </summary>
        /// <param name="DeptID">科室ID</param>
        public void InitGroupBox2(long DeptID)
        {
            DataTable dttmp = op_bed.getAllBedInfo(DeptID);
            int BedNumUnused = 0;//未使用床位数
            int BedNumUsed = 0;//已使用床位数
            lbl_BedNumAll.Text = dttmp.Rows.Count.ToString();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["Used"].ToString() == "")
                    BedNumUnused++;
                else if (dt.Rows[i]["Used"].ToString() == "已分配")
                    BedNumUsed++;
            }
            lbl_BedNumUnused.Text = BedNumUnused.ToString();
            lbl_BedNumUsed.Text = BedNumUsed.ToString();
            lbl_CurrDeptName.Text = BaseData.GetDeptName(DeptID.ToString());
        }
        #endregion
    }
}
