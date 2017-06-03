using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using HIS.SYSTEM.PubicBaseClasses;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_SSManager
{
    public partial class FrmSsRoom :  GWI.HIS.Windows.Controls.BaseMainForm
    {

        private User _user;
        private Deptment _dept;
        private HIS.SS_BLL.SsRoom roomop;
        private HIS.SS_BLL.SsRoomBed bedop;
        public FrmSsRoom(long currentUserId, long currentDeptId, string chineseName)
        {
            InitializeComponent();
            _user = new User(currentUserId);
            _dept = new Deptment(currentDeptId);
            roomop = new HIS.SS_BLL.SsRoom();
            bedop = new HIS.SS_BLL.SsRoomBed();
            BindRooms();
        }

        #region 获得所有房间名
        /// <summary>
        /// 获得所有房间名
        /// </summary>
        private void BindRooms()
        {
            tvRoom.Nodes.Clear();
            TreeNode pnode = new TreeNode();
            pnode.Text = "全部房间";
            pnode.Tag = null;
            pnode.ImageIndex = 14;
            List<HIS.Model.SS_ROOM> rooms = roomop.GetRooms();
            for (int i = 0; i < rooms.Count; i++)
            {
                TreeNode node = new TreeNode();
                node.Text = rooms[i].ROOMNAME;
                node.Tag = rooms[i];
                node.ImageIndex = 15;
                pnode.Nodes.Add(node);               
            }
            tvRoom.Nodes.Add(pnode);
            pnode.Expand();
            
        }
        #endregion

        #region 右键事件
        private void 新增房间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmNewRoom newroom = new FrmNewRoom();
            newroom.ShowDialog();
            string roomno = newroom.roomno;
            if (roomno == "")
            {
                return;
            }
            if (roomop.SaveNewRoom(roomno))
            {
               BindRooms();
            }
        }

        private void 删除房间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tvRoom.SelectedNode == null || tvRoom.SelectedNode.Tag==null)
            {
                return;
            }
            HIS.Model.SS_ROOM room = (HIS.Model.SS_ROOM)tvRoom.SelectedNode.Tag;
            if (roomop.IsExistBed(room.ROOMID))
            {
                MessageBox.Show("该房间还有已占用台次，不能删除该房间 ");
                return;
            }
            if (MessageBox.Show("您确定要删除该房间及该房间的所有台次吗？","", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (roomop.DelRoom(room.ROOMID))
            {
                tvRoom.Nodes.Remove(tvRoom.SelectedNode);
                BindBeds();
            }
        }
        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BindRooms();
        }

        private void tvRoom_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Point ClickPoint = new Point(e.X, e.Y);
                TreeNode CurrentNode = tvRoom.GetNodeAt(ClickPoint);
                if (CurrentNode != null)//判断你点的是不是一个节点...
                {
                    this.tvRoom.SelectedNode = CurrentNode;
                }
            }
        }
        #endregion       


        
        #region 获得该房间的所有台次
        private void tvRoom_AfterSelect(object sender, TreeViewEventArgs e)
        {
            tvRoom.ExpandAll();
            BindBeds();
        }
        #endregion

        //新增台次
        private void tbAdd_Click(object sender, EventArgs e)
        {
            if (tvRoom.SelectedNode==null || tvRoom.SelectedNode.Tag == null)
            {
                return;
            }
            HIS.Model.SS_ROOM room = (HIS.Model.SS_ROOM)tvRoom.SelectedNode.Tag;
            FrmNewBed bed = new FrmNewBed(room);
            bed.ShowDialog();
            string tcno = bed.tcNo;
            if (tcno == "")
            {
                return;
            }
            if (bedop.AddBeds(room,tcno))
            {
                BindBeds();
            }           
        }

        private void BindBeds()
        {
            if (tvRoom.SelectedNode.Tag == null)
            {
                return;
            }
            HIS.Model.SS_ROOM room = (HIS.Model.SS_ROOM)tvRoom.SelectedNode.Tag;
            List<HIS.Model.SS_ROOMBED> beds = bedop.GetBeds(room.ROOMID);
            lvBeds.Items.Clear();
            for (int i = 0; i < beds.Count; i++)
            {
                if (beds[i].USE_FLAG == 0)
                {
                    lvBeds.Items.Add(beds[i].NAME, 2).Tag = beds[i];
                }
                else
                {
                    lvBeds.Items.Add(beds[i].NAME, 0).Tag = beds[i];
                }
            }
        }
        //刷新
        private void tbBrush_Click(object sender, EventArgs e)
        {
            BindBeds();
        }
        //退出
        private void tbQuit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //删除
        private void tbDel_Click(object sender, EventArgs e)
        {
            if (lvBeds.FocusedItem == null)
            {
                MessageBox.Show("请选择需要删除的台次");
                return;
            }
            HIS.Model.SS_ROOMBED bed = (HIS.Model.SS_ROOMBED)lvBeds.FocusedItem.Tag;
            if (bed.USE_FLAG == 1)
            {
                MessageBox.Show("该台次正占用，不能删除");
                return;
            }
            if (bedop.DelBeds(bed))
            {
                BindBeds();
            }
          
        }

        private void tvRoom_AfterExpand(object sender, TreeViewEventArgs e)
        {
            e.Node.ExpandAll();
        }
        #region 台次右键操作
        private void 新增ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbAdd_Click(null, null);
        }

        private void 删除ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbDel_Click(null, null);
        }

        private void 刷新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BindBeds();
        }
        #endregion

        private void FrmSsRoom_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.F2:	//新增台次
                    tbAdd_Click(null, null);
                    break;
                case Keys.F3:	//删除台次
                    tbDel_Click(null, null);
                    break;
                case Keys.F4:	//刷新
                    BindBeds();
                    break;
                case Keys.F5:	//取消安排
                    this.Close();
                    break;                
                default:
                    break;
            }
        }
    }
}
