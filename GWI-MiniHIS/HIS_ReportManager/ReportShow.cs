using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.Report_BLL;
using System.Data;

namespace HIS_ReportManager
{
   public  class ReportShow
    {
        
        #region 加载报表树
        /// <summary>
        /// 加载报表树
        /// </summary>
        public  static  void loadReportdata(TreeView TvReport)
        {
          
            TvReport.Nodes.Clear();
            TreeNode ppnode = new TreeNode();
            ppnode.Text = "公共报表";
            OpReportMaster _master = new OpReportMaster();
            _master.REPORTMASTER_ID = -1;
            _master.REPORT_TYPE = 0;
            ppnode.Tag = _master;
            ppnode.ImageIndex = 14;
            TvReport.Nodes.Add(ppnode);
            ReportProcess _reportProcess = new ReportProcess();
            List<HIS.Model.BASE_REPORTMASTER> reportmaster = _reportProcess.GetReportMaster();
            for (int i = 0; i < reportmaster.Count; i++)
            {
                TreeNode pnode = new TreeNode();
                OpReportMaster master = new OpReportMaster();
                master.NAME = reportmaster[i].NAME;
                master.REPORTMASTER_ID = reportmaster[i].REPORTMASTER_ID;
                master.P_ID = reportmaster[i].P_ID;
                pnode.Tag = master;
                pnode.ImageIndex = 14;
                pnode.Text = reportmaster[i].NAME;
                ppnode.Nodes.Add(pnode);
                AddNode(pnode);
            }
            ppnode.ExpandAll();
           // TvReport.ExpandAll();
        }
        private static  void AddNode(TreeNode TopNode)
        {
            OpReportMaster master = (OpReportMaster)TopNode.Tag;
            ReportProcess _reportProcess = new ReportProcess();
            List<HIS.Model.BASE_REPORTMASTER> _listmaster = _reportProcess.GetMasterList(master.REPORTMASTER_ID);
            AddSubNode(TopNode);
            //循环加载顶级菜单
            for (int i = 0; i < _listmaster.Count; i++)
            {

                TreeNode node = new TreeNode();
                OpReportMaster _master = new OpReportMaster();
                _master.NAME = _listmaster[i].NAME;
                _master.REPORTMASTER_ID = _listmaster[i].REPORTMASTER_ID;
                _master.P_ID = _listmaster[i].P_ID;
                node.Tag = _master;
                node.ImageIndex = 14;
                node.Text = _listmaster[i].NAME;
                TopNode.Nodes.Add(node);
                AddNode(node);
            }

        }

        private static  void AddSubNode(TreeNode ParentNode)
        {
            OpReportMaster master = (OpReportMaster)ParentNode.Tag;
            ReportProcess _reportProcess = new ReportProcess();
            List<HIS.Model.BASE_REPORT> _listreport = _reportProcess.GetReportList(master.REPORTMASTER_ID);
            for (int j = 0; j < _listreport.Count; j++)
            {

                TreeNode node = new TreeNode();
                node.Text = _listreport[j].NAME;
                node.ImageIndex = 15;
                Reportdat order = new Reportdat();
                order.NAME = _listreport[j].NAME;
                order.REPORT_ID = _listreport[j].REPORT_ID;
                order.REPORTMASTER_ID = _listreport[j].REPORTMASTER_ID;
                order.PROCEDURES = _listreport[j].PROCEDURES;
                order.REMARK = _listreport[j].REMARK;
                node.Tag = order;
                ParentNode.Nodes.Add(node);
            }
        }
        #endregion




        static   bool ishasReport = false;
        #region 加载报表树
        /// <summary>
        /// 加载报表树
        /// </summary>
        public static void loadShowReportdata(TreeView TvReport,DataTable  groupid)
        {
           
            TvReport.Nodes.Clear();
            TreeNode ppnode = new TreeNode();
            ppnode.Text = "公共报表";
            OpReportMaster _master = new OpReportMaster();
            _master.REPORTMASTER_ID = -1;
            _master.REPORT_TYPE = 0;
            ppnode.Tag = _master;
            ppnode.ImageIndex = 14;
            TvReport.Nodes.Add(ppnode);
            ReportProcess _reportProcess = new ReportProcess();
            List<HIS.Model.BASE_REPORTMASTER> reportmaster = _reportProcess.GetReportMaster();
            for (int i = 0; i < reportmaster.Count; i++)
            {
                ishasReport = false;
                TreeNode pnode = new TreeNode();
                OpReportMaster master = new OpReportMaster();
                master.NAME = reportmaster[i].NAME;
                master.REPORTMASTER_ID = reportmaster[i].REPORTMASTER_ID;
                master.P_ID = reportmaster[i].P_ID;
                pnode.Tag = master;
                pnode.ImageIndex = 14;
                pnode.Text = reportmaster[i].NAME;

                AddShowNode(pnode, groupid);
                if(ishasReport)
                {
                    ppnode.Nodes.Add(pnode);
                }

            }
            ppnode.ExpandAll();
            TvReport.ExpandAll();
        }
        private static void AddShowNode(TreeNode TopNode, DataTable groupid)
        {
            OpReportMaster master = (OpReportMaster)TopNode.Tag;
            ReportProcess _reportProcess = new ReportProcess();
            List<HIS.Model.BASE_REPORTMASTER> _listmaster = _reportProcess.GetMasterList(master.REPORTMASTER_ID);
            //AddShowSubNode(TopNode, groupid);
            //循环加载顶级菜单
            for (int i = 0; i < _listmaster.Count; i++)
            {

                TreeNode node = new TreeNode();
                OpReportMaster _master = new OpReportMaster();
                _master.NAME = _listmaster[i].NAME;
                _master.REPORTMASTER_ID = _listmaster[i].REPORTMASTER_ID;
                _master.P_ID = _listmaster[i].P_ID;
                node.Tag = _master;
                node.ImageIndex = 14;
                node.Text = _listmaster[i].NAME;
                if (AddShowSubNode(node, groupid))
                {
                    TopNode.Nodes.Add(node);
                    ishasReport = true;
                }
                AddShowNode(node, groupid);
            }

        }

        private static bool AddShowSubNode(TreeNode ParentNode, DataTable groupid)
        {
            OpReportMaster master = (OpReportMaster)ParentNode.Tag;
            ReportProcess _reportProcess = new ReportProcess();
            System.Data.DataTable _listreport = _reportProcess.getReportList(groupid, master.REPORTMASTER_ID);
            if (_listreport == null || _listreport.Rows.Count < 1)
            {
                return false;
            }
            TreeNode node = new TreeNode();
            DataRow[] drows = _listreport.Select("");
            foreach (DataRow dr in drows)
            {
                Reportdat mould = new Reportdat();
                mould.NAME = dr["NAME"].ToString();
                mould.PROCEDURES = dr["PROCEDURES"].ToString();
                mould.REMARK = dr["REMARK"].ToString();
                mould.REPORT_ID = int.Parse(dr["REPORT_ID"].ToString());
                mould.Isglobal = int.Parse(dr["isglobal"].ToString());
                node = new TreeNode(mould.NAME, 15, 13);
                node.Tag = mould;
                ParentNode.Nodes.Add(node);
            }
            return true;
        }
        #endregion
    }
}
