using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.MedicalConfir_BLL
{
    partial class MzConfir : ConfirCenter
    {
        #region  得到门诊病人列表
        /// <summary>
        /// 得到门诊病人列表
        /// </summary>
        /// <param name="IsConfird">true= 已确费 false=未确费</param>
        /// <param name="deptid"></param>
        /// <param name="docid"></param>
        /// <param name="bdate"></param>
        /// <param name="edate"></param>
        /// <returns></returns>
        public override List<HIS.Model.MZ_PatList> GetMzList(bool IsConfird, int deptid, int docid, DateTime? bdate, DateTime? edate) 
        {
            if (IsConfird)
            {
                string strWhere =// Tables.medical_confir.CONFIRDOC + oleDb.EuqalTo() + docid + oleDb.And() + //不根据确费医生加载
                    Tables.medical_confir.CANCEL_FLAG + oleDb.EuqalTo() + 0
                    + oleDb.And() + Tables.medical_confir.CONFIRDATE + oleDb.GreaterThanAndEqualTo() + "'" + bdate.Value.Date + "'" + oleDb.And() + Tables.medical_confir.CONFIRDATE + oleDb.LessThanAndEqualTo() + "'" + edate.Value.Date.AddDays(1) + "'"
                    + oleDb.And() + Tables.medical_confir.MARK_FLAG + oleDb.EuqalTo() + 0;
                List<HIS.Model.Medical_Confir> confird = BindEntity<HIS.Model.Medical_Confir>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                if (confird == null || confird.Count == 0)
                {
                    return null;
                }

                List<HIS.Model.MZ_PatList> patlists = new List<HIS.Model.MZ_PatList>();
                for (int i = 0; i < confird.Count; i++)
                {
                    HIS.Model.MZ_PatList plist = BindEntity<HIS.Model.MZ_PatList>.CreateInstanceDAL(oleDb).GetModel(confird[i].PatListId);
                    int j = 0;
                    for (j = 0; j < patlists.Count; j++)
                    {
                        if (patlists[j].PatListID == plist.PatListID)
                            break;
                    }
                    if (j == patlists.Count)
                    {
                        patlists.Add(plist);
                    }
                }
                return patlists;
            
            }
            else
            {
                object obj = GetConfig();
                string strsql = "";
                if (obj == null || obj.ToString().Trim() == "1") //按医技科室确费 2010.9.19 heyan
                {
                    strsql = "select distinct(a.patlistid) from mz_presorder a left outer join BASE_ITEM_DEPT b on a.itemid=b.item_id left outer join mz_presmaster c "
                                   + " on a.presmasterid= c.presmasterid  left outer join mz_costmaster d on c.presmasterid=d.presmasterid where  b.dept_id =" + deptid + " "
                                    + " and a.itemtype='00' and d.costdate >='" + bdate.Value.Date + "' and d.costdate<='" + edate.Value.Date.AddDays(1) + "'and c.charge_flag=1 and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " "
                                   + " and a.presorderid not in (select presorderid from medical_confir where cancel_flag=0 and mark_flag=0)";
                }
                else
                {
                    strsql = "select distinct(a.patlistid) from mz_presorder a  left outer join mz_presmaster c "
                    + " on a.presmasterid= c.presmasterid  left outer join mz_costmaster d on c.presmasterid=d.presmasterid where   "
                     + "  a.itemtype='00' and d.costdate >='" + bdate.Value.Date + "' and d.costdate<='" + edate.Value.Date.AddDays(1) + "'and c.charge_flag=1 and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " "
                    + " and a.presorderid not in (select presorderid from medical_confir where cancel_flag=0 and mark_flag=0)";
                }
                DataTable dt = oleDb.GetDataTable(strsql);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return null;
                }
                List<HIS.Model.MZ_PatList> patlists = new List<HIS.Model.MZ_PatList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HIS.Model.MZ_PatList plist = BindEntity<HIS.Model.MZ_PatList>.CreateInstanceDAL(oleDb).GetModel(Convert.ToInt32(dt.Rows[i]["patlistid"]));
                    patlists.Add(plist);
                }
                return patlists;
            }
        }
        #endregion
        public override List<HIS.Model.ZY_PatList> GetZyList(bool IsConfird, int deptid, int docid, DateTime? bdate, DateTime? edate) { return null; }

        #region 通过病人ID获得门诊病人的项目明细
        /// <summary>
        /// 通过病人ID获得门诊病人的项目明细
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="IsConfird">false=没有确费的 true=已经确费的</param>
        /// <returns></returns>
        public override DataTable GetItemDetails( bool IsConfird, int deptid, int docid)
        {
            return MzGetFee.GetMzItems(mzPlist, IsConfird, deptid, docid);
        }
        #endregion

        #region 确费
        /// <summary>
        /// 确费
        /// </summary>
        /// <param name="presorders"></param>
        /// <param name="ConfirDoc"></param>
        /// <returns></returns>
        public override bool SaveConfir(List<int> presorders, int ConfirDoc, int ConfirDept)
        {
            try
            {
                if (presorders.Count == 0)
                {
                    return false;
                }
                object obj = GetConfig();
                oleDb.BeginTransaction();
                for (int i = 0; i < presorders.Count; i++)
                {
                    HIS.Model.MZ_PresOrder presorder = BindEntity<HIS.Model.MZ_PresOrder>.CreateInstanceDAL(oleDb).GetModel(presorders[i]);                 
                    HIS.Model.Medical_Confir Confir =  new HIS.Model.Medical_Confir();
                    Confir.Cancel_Flag = 0;
                    Confir.ConfirDate = XcDate.ServerDateTime;
                    Confir.ConfirDept = ConfirDept;
                    Confir.ConfirDoc = ConfirDoc;
                    Confir.Mark_Flag = 0;
                    Confir.PatListId = presorder.PatListID;
                    Confir.PresOrderId = presorder.PresOrderID;
                    string strWhere = Tables.medical_confir.PRESORDERID + oleDb.EuqalTo() + presorder.PresOrderID + oleDb.And() + Tables.medical_confir.CANCEL_FLAG +
                        oleDb.EuqalTo() + 0 + oleDb.And() + Tables.medical_confir.MARK_FLAG + oleDb.EuqalTo() + 0;
                    if (BindEntity<HIS.Model.Medical_Confir>.CreateInstanceDAL(oleDb).Exists(strWhere) )
                    {
                        continue;
                    }
                    BindEntity<HIS.Model.Medical_Confir>.CreateInstanceDAL(oleDb).Add(Confir);
                    HIS.Model.MZ_PresMaster presmaster = BindEntity<HIS.Model.MZ_PresMaster>.CreateInstanceDAL(oleDb).GetModel(presorder.PresMasterID);                   
                    if (obj == null || obj.ToString().Trim() == "1") //按医技科室确费的修改执行科室
                    {
                        presmaster.ExecDeptCode = ConfirDept.ToString();
                        BindEntity<HIS.Model.MZ_PresMaster>.CreateInstanceDAL(oleDb).Update(presmaster);
                    }
                   
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 取消确费
        /// <summary>
        /// 取消确费
        /// </summary>
        /// <param name="presorders"></param>
        /// <param name="CancelDoc"></param>
        /// <returns></returns>
        public override bool CancelConfir(List<int> presorders, int CancelDoc)
        {
            try
            {
                if (presorders.Count == 0)
                {
                    return false;
                }
                object obj = GetConfig();
                string[] strSet = new string[3];
                strSet[0] = Tables.medical_confir.CANCEL_FLAG + oleDb.EuqalTo() + 1;
                strSet[1] = Tables.medical_confir.CANCELDOC + oleDb.EuqalTo() + CancelDoc;
                strSet[2] = Tables.medical_confir.CANCELDATE + oleDb.EuqalTo() + "'" + XcDate.ServerDateTime + "'";
                oleDb.BeginTransaction();
                for (int i = 0; i < presorders.Count; i++)
                {
                    string strWhere = Tables.medical_confir.CONFIRDOC + oleDb.EuqalTo() + CancelDoc + oleDb.And() + Tables.medical_confir.CANCEL_FLAG + oleDb.EuqalTo() + 0
                        + oleDb.And() + Tables.medical_confir.PRESORDERID + oleDb.EuqalTo() + presorders[i]+oleDb.And()+Tables.medical_confir.MARK_FLAG+oleDb.EuqalTo()+0 ;
                    BindEntity<HIS.Model.Medical_Confir>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                    HIS.Model.MZ_PresOrder order = BindEntity<HIS.Model.MZ_PresOrder>.CreateInstanceDAL(oleDb).GetModel(presorders[i]);
                    if (obj == null || obj.ToString().Trim() == "1")
                    {
                        string strSet1 = Tables.mz_presmaster.EXECDEPTCODE + oleDb.EuqalTo() + "'0'";
                        BindEntity<HIS.Model.MZ_PresMaster>.CreateInstanceDAL(oleDb).Update(Tables.mz_presmaster.PRESMASTERID + oleDb.EuqalTo() + order.PresMasterID, strSet1);
                    }
                }
                
                oleDb.CommitTransaction();
                return true;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
        #endregion

        #region 根据病人ID获得病人的费用明细
        /// <summary>
        /// 根据病人ID获得病人的费用明细
        /// </summary>
        /// <param name="id"></param>
        /// <param name="IsConfird"></param>
        /// <param name="deptid"></param>
        /// <param name="docid"></param>
        /// <returns></returns>
        public override DataTable FindDetails(string id, bool IsConfird, int deptid, int docid)
        {
            string strWhere = Tables.mz_patlist.VISITNO + oleDb.EuqalTo() + "'"+id+"'";
            HIS.Model.MZ_PatList mzpat = BindEntity<HIS.Model.MZ_PatList>.CreateInstanceDAL(oleDb).GetModel(strWhere);
            if (mzpat == null)
            {
                return null;
            }
            List<HIS.Model.MZ_PatList> mzplist = new List<HIS.Model.MZ_PatList>();
            mzplist.Add(mzpat);
            return MzGetFee.GetMzItems(mzplist, IsConfird, deptid, docid);
        }
        #endregion
    }
}
