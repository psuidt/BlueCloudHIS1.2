using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL.ObjectModel.AccountManager;
using System.Windows.Forms;
using HIS.ZY_BLL.ObjectModel.BaseData;

namespace HIS_ZYManager.Action
{
    //zenghao [20100506.1.01]
    public class FrmAllAccountController
    {
        IFrmAllAccountView view;
        private AbstractAllAccount zyAccount = null;
        private AbstractAllAccount NotAccount = null;
        private long workid;
        private long oldworkid;

        public FrmAllAccountController(IFrmAllAccountView _view)
        {
            view = _view;
            zyAccount = new AllAccountList();
            NotAccount = new NotAllAccountList();
            view.Workers = BaseDataFactory.GetData(baseDataType.医疗机构);
        }
        /// <summary>
        /// 统计
        /// </summary>
        public void SearchData()
        {
            BeginChargeWorkid();

            zyAccount.SearchData(view.BeginDate, view.EndDate);
            NotAccount.SearchData(view.BeginDate, view.EndDate);
            view.Data = zyAccount;
            GetTreeNode();

            EndChargeWorkid();
        }

        /// <summary>
        /// 获取树型数据
        /// </summary>
        private void GetTreeNode()
        {
            TreeNode tn = new TreeNode("根节点");
            TreeNode tnn1 = new TreeNode("已交款");
            TreeNode tnn2 = new TreeNode("未交款");
            tn.Nodes.Add(tnn1);
            tn.Nodes.Add(tnn2);
            if (zyAccount.CostEmps != null)
            {
                for (int i = 0; i < zyAccount.CostEmps.Length; i++)
                {
                    TreeNode tnnn = new TreeNode(zyAccount.CostEmps[i].EmpName);
                    tnnn.Tag = zyAccount.CostEmps[i].EmpID;
                    tnn1.Nodes.Add(tnnn);

                    if (zyAccount.CostEmps[i].Chargedates.Length > 0)
                    {
                        TreeNode tnnn1 = new TreeNode("预交金");
                        tnnn.Nodes.Add(tnnn1);
                        for (int j = 0; j < zyAccount.CostEmps[i].Chargedates.Length; j++)
                        {
                            TreeNode tnnnn = new TreeNode(zyAccount.CostEmps[i].Chargedates[j].ToString());
                            tnnnn.Tag = zyAccount.CostEmps[i].ChargeAccountIDs[j].ToString();
                            tnnn1.Nodes.Add(tnnnn);
                        }
                    }

                    if (zyAccount.CostEmps[i].Costdates.Length > 0)
                    {
                        TreeNode tnnn2 = new TreeNode("结算");
                        tnnn.Nodes.Add(tnnn2);

                        for (int j = 0; j < zyAccount.CostEmps[i].Costdates.Length; j++)
                        {
                            TreeNode tnnnn = new TreeNode(zyAccount.CostEmps[i].Costdates[j].ToString());
                            tnnnn.Tag = zyAccount.CostEmps[i].CostAccountIDs[j].ToString();
                            tnnn2.Nodes.Add(tnnnn);
                        }
                    }

                }
            }

            if (NotAccount.CostEmps != null)
            {
                for (int i = 0; i < NotAccount.CostEmps.Length; i++)
                {
                    TreeNode tnnn = new TreeNode(NotAccount.CostEmps[i].EmpName);
                    tnnn.Tag = NotAccount.CostEmps[i].EmpID;
                    tnn2.Nodes.Add(tnnn);

                    if (NotAccount.CostEmps[i].Chargedates.Length > 0)
                    {
                        TreeNode tnnn1 = new TreeNode("预交金");
                        tnnn.Nodes.Add(tnnn1);
                        for (int j = 0; j < NotAccount.CostEmps[i].Chargedates.Length; j++)
                        {
                            TreeNode tnnnn = new TreeNode(NotAccount.CostEmps[i].Chargedates[j].ToString());
                            tnnnn.Tag = NotAccount.CostEmps[i].EmpID;
                            tnnn1.Nodes.Add(tnnnn);
                        }
                    }

                    if (NotAccount.CostEmps[i].Costdates.Length > 0)
                    {
                        TreeNode tnnn2 = new TreeNode("结算");
                        tnnn.Nodes.Add(tnnn2);

                        for (int j = 0; j < NotAccount.CostEmps[i].Costdates.Length; j++)
                        {
                            TreeNode tnnnn = new TreeNode(NotAccount.CostEmps[i].Costdates[j].ToString());
                            tnnnn.Tag = NotAccount.CostEmps[i].EmpID;
                            tnnn2.Nodes.Add(tnnnn);
                        }
                    }
                }
            }

            view.treenode = tn;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="IDs"></param>
        /// <param name="_isAccount"></param>
        public void FiterData(int[] IDs,bool _isAccount)
        {
            BeginChargeWorkid();

            if (_isAccount)
            {
                zyAccount.SearchData(view.BeginDate, view.EndDate, IDs);
                view.Data = zyAccount;
            }
            else
            {               
                NotAccount.SearchData(view.BeginDate, view.EndDate, IDs);
                view.Data = NotAccount;
            }

            EndChargeWorkid();
        }

        public void FiterData(string[] IDs, bool _isAccount)
        {
            BeginChargeWorkid();

            if (_isAccount)
            {
                zyAccount.SearchData(view.BeginDate, view.EndDate, IDs);
                view.Data = zyAccount;
            }
            else
            {
                NotAccount.SearchData(view.BeginDate, view.EndDate, IDs);
                view.Data = NotAccount;
            }

            EndChargeWorkid();
        }

        public void BeginChargeWorkid()
        {
            oldworkid = HIS.SYSTEM.Core.EntityConfig.WorkID;
            workid = view.Worker;
            HIS.SYSTEM.Core.EntityConfig.WorkID = workid;
        }

        public void EndChargeWorkid()
        {
            HIS.SYSTEM.Core.EntityConfig.WorkID = oldworkid;
        }
    }
}
