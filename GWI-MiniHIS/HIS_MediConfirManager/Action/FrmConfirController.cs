using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace HIS_MediConfirManager.Action
{
    public class FrmConfirController
    {
        private IFrmConfirView view;
        private int execDeptid;
        private int execEmlpyeeid;
        private HIS.MedicalConfir_BLL.ConfirOP feeOp; 
        public FrmConfirController(IFrmConfirView _view)
        {
            view = _view;
            execDeptid = Convert.ToInt32(view.currentDept.DeptID);
            execEmlpyeeid = Convert.ToInt32(view.currentUser.EmployeeID);
            feeOp = new HIS.MedicalConfir_BLL.ConfirOP();
            feeOp.deptId = execDeptid;
            feeOp.docId = execEmlpyeeid;
            feeOp.type = view.ConfirType;
            GetPatlist();
        }

        #region 得到病人列表
        /// <summary>
        /// 得到病人列表
        /// </summary>
        public void GetPatlist()
        {
            if (view.ConfirType == HIS.MedicalConfir_BLL.ConfirType.住院)
            {               
                view.zyPatlist =feeOp.GetZyConfirdList(view.IsConfird, view.GetBdate, view.GetEdate);
            }
            else
            {
                view.mzPatlist = feeOp.GetMzConfirdList(view.IsConfird,  view.GetBdate, view.GetEdate);
            }
            view.BindPatlist();         
        }
        #endregion

        #region 得到选中的多个病人费用明细
        /// <summary>
        /// 得到选中的多个病人费用明细
        /// </summary>
        public void GetItems()
        {
            if (view.ConfirType == HIS.MedicalConfir_BLL.ConfirType.住院)
            {
                feeOp.zyPlist = view.selectPatlist;
                DataTable items = feeOp.GetItemDetails(view.IsConfird);
                view.BindItems = items;
            }
            else
            {
                feeOp.mzPlist = view.selectMzPatlist;
                DataTable items = feeOp.GetItemDetails(view.IsConfird);
                view.BindItems = items;
            }
        }
        #endregion

        #region 每次选中一个住院病人时，增加这个病人的费用明细
        /// <summary>
        /// 每次选中一个住院病人时，增加这个病人的费用明细
        /// </summary>
        /// <param name="plist"></param>
        public void AddItems(HIS.Model.ZY_PatList plist)
        {
            List<HIS.Model.ZY_PatList> patlist = new List<HIS.Model.ZY_PatList>();
            patlist.Add(plist);
            DataTable dt = view.BindItems;
            feeOp.zyPlist = patlist;
            DataTable items = feeOp.GetItemDetails(view.IsConfird);
            if (dt == null || dt.Rows.Count == 0)
            {
                view.BindItems = items;
            }
            else
            {
                DataTable dtcopy = dt.Clone();
                dtcopy.Clear();
                DataRow[] rows = dt.Select("patlistid <> " + plist.PatListID + "");
                foreach (DataRow row in rows)
                {
                    dtcopy.Rows.Add(row.ItemArray);
                }
                for (int i = 0; i < items.Rows.Count; i++)
                {

                    dtcopy.Rows.Add(items.Rows[i].ItemArray);
                }
                view.BindItems = dtcopy;
            }
        }
        #endregion

        #region 每次取消选中一个住院病人时，删除这个病人的费用明细
        /// <summary>
        /// 每次取消选中一个住院病人时，删除这个病人的费用明细
        /// </summary>
        /// <param name="plist"></param>
        public void PlusItems(HIS.Model.ZY_PatList plist)
        {
            DataTable dt = view.BindItems;
            if (dt == null)
            {
                return;
            }
            DataTable dtcopy = dt.Clone();
            dtcopy.Clear();
            DataRow[] rows = dt.Select("patlistid <> " + plist.PatListID + "");
            foreach(DataRow row in rows)
            {
                dtcopy.Rows.Add(row.ItemArray);
            }
            view.BindItems = dtcopy;
        }
        #endregion

        #region 每次选中一个门诊病人时，增加这个病人的费用明细
        /// <summary>
        /// 每次选中一个门诊病人时，增加这个病人的费用明细
        /// </summary>
        /// <param name="plist"></param>
        public void MzAddItems(HIS.Model.MZ_PatList plist)
        {
            List<HIS.Model.MZ_PatList> patlist = new List<HIS.Model.MZ_PatList>();
            patlist.Add(plist);
            DataTable dt = view.BindItems;
            feeOp.mzPlist = patlist;
            DataTable items = feeOp.GetItemDetails(view.IsConfird);
            if (dt == null || dt.Rows.Count == 0)
            {
                view.BindItems = items;
            }
            else
            {
                DataTable dtcopy = dt.Clone();
                dtcopy.Clear();
                DataRow[] rows = dt.Select("patlistid <> " + plist.PatListID + "");
                foreach (DataRow row in rows)
                {
                    dtcopy.Rows.Add(row.ItemArray);
                }
                for (int i = 0; i < items.Rows.Count; i++)
                {
                    dtcopy.Rows.Add(items.Rows[i].ItemArray);
                }
                view.BindItems = dtcopy;
            }
        }
        #endregion

        #region 每次取消选中一个门诊病人时，删除这个病人的费用明细
        /// <summary>
        ///  每次取消选中一个门诊病人时，删除这个病人的费用明细
        /// </summary>
        /// <param name="plist"></param>
        public void MzPlusItems(HIS.Model.MZ_PatList plist)
        {
            DataTable dt = view.BindItems;
            if (dt == null)
            {
                return;
            }
            DataTable dtcopy = dt.Clone();
            dtcopy.Clear();
            DataRow[] rows = dt.Select("patlistid <> " + plist.PatListID + "");
            foreach (DataRow row in rows)
            {
                dtcopy.Rows.Add(row.ItemArray);
            }
            view.BindItems = dtcopy;
        }
        #endregion

        #region 选定对应的行
        /// <summary>
        /// 选定对应的行
        /// </summary>
        public void CellXD(int rowid, bool b)
        {
            DataTable dt = view.BindItems;
            if (rowid > -1)
            {
                if (Convert.ToBoolean(dt.Rows[rowid]["XD"]) == true)
                {
                    if (b)
                    {
                        dt.Rows[rowid]["XD"] = false;
                    }
                }
                else
                {
                    dt.Rows[rowid]["XD"] = true;
                }
            }
        }
        #endregion

        #region  确费
        /// <summary>
        /// 确费
        /// </summary>
        /// <returns></returns>
        public bool  FeeConfir()
        {          
            DataTable dt = view.BindItems;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("没有需要确费的项目");
                return false;
            }
            if (MessageBox.Show("确认检查完毕吗？", "审核", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }
            DataTable dtCopy = dt.Clone();
            dtCopy.Clear();
            List<int> presorders = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((bool)dt.Rows[i]["XD"] == true)
                {
                    presorders.Add(Convert.ToInt32(dt.Rows[i]["presorderid"]));
                }
                else
                {
                    dtCopy.Rows.Add(dt.Rows[i].ItemArray);
                }
            }
            if (presorders.Count == 0)
            {
                MessageBox.Show("请选择需要确费的项目");
                return false;
            }
            if (feeOp.SaveConfir(presorders))
            {
                view.BindItems = dtCopy;
                return true;
            }
            return false;
        }
        #endregion

        #region 取消确费
        /// <summary>
        /// 取消确费
        /// </summary>
        /// <returns></returns>
        public bool ConcelFee()
        {
            DataTable dt = view.BindItems;
            if (dt == null || dt.Rows.Count == 0)
            {
                MessageBox.Show("没有需要取消确费的项目");
                return false;
            }
            if (MessageBox.Show("确认取消确费吗？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return false;
            }
            List<int> presorders = new List<int>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
               
                if ((bool)dt.Rows[i]["XD"] == true)
                {
                    if (dt.Rows[i]["confirdocid"].ToString().Trim() != execEmlpyeeid.ToString().Trim())
                    {
                        MessageBox.Show("" + dt.Rows[i]["itemname"].ToString() + "不是您确费的，您不能取消此确费,请重新选择");
                        return false;
                    }
                    presorders.Add(Convert.ToInt32(dt.Rows[i]["presorderid"]));
                }
            }
            if (presorders.Count == 0)
            {
                MessageBox.Show("请选择需要取消确费的项目");
                return false;
            }
            return feeOp.CancelConfir(presorders);
        }
        #endregion

        #region 查找指定病人的费用明细
        /// <summary>
        /// 查找指定病人的费用明细
        /// </summary>
        /// <param name="findID"></param>
        public void FindFee(string  findID)
        {
            DataTable dt = feeOp.FindDetails(findID, view.IsConfird);
            view.BindItems = dt;
        }
        #endregion


        public void GetPlistByName(string pywb)
        {
          
        }
    }
}
