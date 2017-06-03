using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HIS.ZYNurse_BLL;

namespace HIS_ZYNurseManager
{
    public class PublicFeeModel
    {
        #region 加载模板树
        /// <summary>
        /// 加载模板树
        /// </summary>
        public static TreeNode LoadModeTree(int level,int deptid,int userid )
        {
            TreeNode ppnode = new TreeNode();
            ppnode.Text = "所有模板";
            FeeModelProcess _master = new FeeModelProcess();
            _master.MODEL_ID = -1;
            _master.MODEL_TYPE = 0;
            ppnode.Tag = _master;
            ppnode.ImageIndex = 14;
            List<HIS.Model.ZY_NURSE_FEEMODEL> modelmaster = _master.GetModelType(level, userid, deptid);
            for (int i = 0; i < modelmaster.Count; i++)
            {
                TreeNode pnode = new TreeNode();
                FeeModelProcess master = new FeeModelProcess();
                master.MODEL_NAME = modelmaster[i].MODEL_NAME;
                master.MODEL_ID = modelmaster[i].MODEL_ID;
                master.MODEL_LEVEL = modelmaster[i].MODEL_LEVEL;
                master.P_ID = modelmaster[i].P_ID;
                master.MODEL_TYPE = modelmaster[i].MODEL_TYPE;
                master.CREATE_DATE = modelmaster[i].CREATE_DATE;
                master.CREATE_DEPT = modelmaster[i].CREATE_DEPT;
                master.CREATE_NURSE = modelmaster[i].CREATE_NURSE;
                pnode.Tag = master;
                if (master.MODEL_TYPE == 0)
                {
                    pnode.ImageIndex = 14;
                }
                else
                {
                    pnode.ImageIndex = 15;
                }
                pnode.Text = modelmaster[i].MODEL_NAME;
                ppnode.Nodes.Add(pnode);
                pnode.ExpandAll();
                AddNode(pnode);
            }
            ppnode.ExpandAll();
            return ppnode;
        }
        private static void AddNode(TreeNode TopNode)
        {
            FeeModelProcess master = (FeeModelProcess)TopNode.Tag;
            FeeModelProcess _master = new FeeModelProcess();
            List<HIS.Model.ZY_NURSE_FEEMODEL> _listmaster = _master.GetModelName(master.MODEL_ID);          
            //循环加载结点
            for (int i = 0; i < _listmaster.Count; i++)
            {
                TreeNode node = new TreeNode();
                FeeModelProcess _lmaster = new FeeModelProcess();
                _lmaster.MODEL_NAME = _listmaster[i].MODEL_NAME;
                _lmaster.MODEL_ID = _listmaster[i].MODEL_ID;
                _lmaster.MODEL_LEVEL = _listmaster[i].MODEL_LEVEL;
                _lmaster.P_ID = _listmaster[i].P_ID;
                _lmaster.MODEL_TYPE = _listmaster[i].MODEL_TYPE;
                _lmaster.CREATE_DATE = _listmaster[i].CREATE_DATE;
                _lmaster.CREATE_DEPT = _listmaster[i].CREATE_DEPT;
                _lmaster.CREATE_NURSE = _listmaster[i].CREATE_NURSE;
                node.Tag = _lmaster;
                if (_lmaster.MODEL_TYPE == 0)
                {
                    node.ImageIndex = 14;
                }
                else
                {
                    node.ImageIndex = 15;
                }
                node.Text = _listmaster[i].MODEL_NAME;             
                TopNode.Nodes.Add(node);
                if (_master.MODEL_TYPE == 0)
                {
                    AddNode(node);
                }
            }
        }
        public static System.Data.DataTable GetFeeModelList(int modelid)
        {
            FeeModelList modellist = new FeeModelList();
            return modellist.GetFeeList(modelid);
        }    

        #endregion
    }
}
