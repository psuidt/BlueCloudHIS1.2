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
    partial class ZyConfir : ConfirCenter
    {
        #region 得到住院病人列表
        /// <summary>
        /// 得到住院病人列表
        /// </summary>
        /// <param name="IsConfird"> true=已确费 false=未确费</param>
        /// <param name="deptid"></param>
        /// <param name="docid"></param>
        /// <param name="bdate"></param>
        /// <param name="edate"></param>
        /// <returns></returns>
        public override List<HIS.Model.ZY_PatList> GetZyList(bool IsConfird, int deptid, int docid, DateTime? bdate, DateTime? edate)
        {
            if (IsConfird)
            {
                string strWhere = //Tables.medical_confir.CONFIRDOC + oleDb.EuqalTo() + docid + oleDb.And() +  //不按确费医生加载 2010.9.19 heyan
                                 Tables.medical_confir.CANCEL_FLAG + oleDb.EuqalTo() + 0
                            + oleDb.And() + Tables.medical_confir.CONFIRDATE + oleDb.GreaterThanAndEqualTo() + "'" + bdate.Value.Date + "'" + oleDb.And() 
                            + Tables.medical_confir.CONFIRDATE + oleDb.LessThanAndEqualTo() + "'" + edate.Value.Date.AddDays(1) + "'"
                            + oleDb.And() + Tables.medical_confir.MARK_FLAG + oleDb.EuqalTo() + 1;
                List<HIS.Model.Medical_Confir> Confird = BindEntity<HIS.Model.Medical_Confir>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
                if (Confird == null || Confird.Count == 0)
                {
                    return null;
                }
                List<HIS.Model.ZY_PatList> patlists = new List<HIS.Model.ZY_PatList>();
                for (int i = 0; i < Confird.Count; i++)
                {
                    HIS.Model.ZY_PatList plist = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(Confird[i].PatListId);
                    int j = 0;
                    for ( j = 0; j < patlists.Count; j++)
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
                object confirtype = GetConfig();
                string strsql = "";
                if (confirtype == null || confirtype.ToString().Trim() == "1")   //增加参数，医技确费是否按医技执行科室确 2010.9.19 heyan
                {
                    strsql = "select distinct(patlistid) from zy_presorder a left outer join BASE_ITEM_DEPT b on a.itemid=b.item_id  "
                                       + " where a.prestype='4' and a.record_flag=0 and a.costdate>='" + bdate.Value.Date + "' and a.costdate<='" + edate.Value.Date.AddDays(1) + "' "
                                      + " and b.dept_id =" + deptid + " and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " and a.presorderid not in  "
                                      + " (select presorderid from medical_confir where cancel_flag=0 and mark_flag=1)";
                }
                else
                {
                  //strsql = "select distinct(patlistid) from zy_presorder a left outer join zy_doc_orderrecord b on a.order_id=b.order_id  "
                  //                    + " where b.item_type=5 and a.record_flag=0 and a.costdate>='" + bdate.Value.Date + "' and a.costdate<='" + edate.Value.Date.AddDays(1) + "' "
                  //                   + " and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " and a.presorderid not in  "
                  //                   + " (select presorderid from medical_confir where cancel_flag=0 and mark_flag=1)"; //不要执行科室
                  strsql = "select distinct(patlistid) from zy_presorder a "
                                    + " where a.prestype='4' and a.record_flag=0 and a.costdate>='" + bdate.Value.Date + "' and a.costdate<='" + edate.Value.Date.AddDays(1) + "' "
                                   + " and a.workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID + " and a.presorderid not in  "
                                   + " (select presorderid from medical_confir where cancel_flag=0 and mark_flag=1)"; //不要执行科室
                }
                DataTable dt = oleDb.GetDataTable(strsql);
                if (dt == null || dt.Rows.Count == 0)
                {
                    return null;
                }
                List<HIS.Model.ZY_PatList> patlists = new List<HIS.Model.ZY_PatList>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    HIS.Model.ZY_PatList plist = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(Convert.ToInt32(dt.Rows[i]["patlistid"]));
                    patlists.Add(plist);
                }
                return patlists;
            }
        }
        #endregion

        public override List<HIS.Model.MZ_PatList> GetMzList(bool IsConfird, int deptid, int docid, DateTime? bdate, DateTime? edate) { return null; }    

        #region  通过病人ID获得病人的项目明细
        /// <summary>
        /// 通过病人ID获得病人的项目明细
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="IsConfird">false=没有确费的 true=已经确费的</param>
        /// <returns></returns>
        public override DataTable GetItemDetails( bool IsConfird, int deptid, int docid)
        {
            return ZyGetFee.GetZyItems(zyPlist, IsConfird, deptid, docid);
           
        }
        #endregion

        #region 确费
        /// <summary>
        /// 确费
        /// </summary>
        /// <param name="presorders"></param>
        /// <param name="ConfirDoc"></param>
        /// <returns></returns>
        public override bool SaveConfir(List<int> presorders, int ConfirDoc,int ConfirDept)
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
                    HIS.Model.ZY_PresOrder presorder = BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).GetModel(presorders[i]);
                    HIS.Model.Medical_Confir Confir = new HIS.Model.Medical_Confir();
                    Confir.Cancel_Flag = 0;
                    Confir.ConfirDate = XcDate.ServerDateTime;
                    Confir.ConfirDept = ConfirDept;
                    Confir.ConfirDoc = ConfirDoc;
                    Confir.Mark_Flag = 1;
                    Confir.PatListId = presorder.PatListID;
                    Confir.PresOrderId = presorder.PresOrderID;
                    string strWhere = Tables.medical_confir.PRESORDERID + oleDb.EuqalTo() + presorder.PresOrderID + oleDb.And() + Tables.medical_confir.CANCEL_FLAG +
                        oleDb.EuqalTo() + 0 + oleDb.And() + Tables.medical_confir.MARK_FLAG + oleDb.EuqalTo() + 1;
                    if (BindEntity<HIS.Model.Medical_Confir>.CreateInstanceDAL(oleDb).Exists(strWhere) || presorder.Record_Flag != 0)
                    {
                        continue;
                    }
                    BindEntity<HIS.Model.Medical_Confir>.CreateInstanceDAL(oleDb).Add(Confir);
                    
                    if (obj == null || obj.ToString().Trim() == "1") //2010.9.19 update by heyan
                    {
                        presorder.ExecDeptCode = ConfirDept.ToString(); //修改执行科室
                        BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(presorder);
                    }
                }
                oleDb.CommitTransaction();
                return true;
            }
            catch(System.Exception e)
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
                        + oleDb.And() + Tables.medical_confir.PRESORDERID + oleDb.EuqalTo() + presorders[i] + oleDb.And() + Tables.medical_confir.MARK_FLAG + oleDb.EuqalTo() + 1;
                    BindEntity<HIS.Model.Medical_Confir>.CreateInstanceDAL(oleDb).Update(strWhere, strSet);
                   
                    if (obj == null || obj.ToString().Trim() == "1") //2010.9.19 update by heyan
                    {
                        string strSet1 = Tables.zy_presorder.EXECDEPTCODE + oleDb.EuqalTo() + "'0'"; //修改执行科室
                        BindEntity<HIS.Model.ZY_PresOrder>.CreateInstanceDAL(oleDb).Update(Tables.zy_presorder.PRESORDERID + oleDb.EuqalTo() + presorders[i], strSet1);
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
            string strWhere = Tables.zy_patlist.CURENO + oleDb.EuqalTo() + "'" + id + "'";
            HIS.Model.ZY_PatList zypat = BindEntity<HIS.Model.ZY_PatList>.CreateInstanceDAL(oleDb).GetModel(strWhere);
            if (zypat == null)
            {
                return null;
            }
            List<HIS.Model.ZY_PatList> plist = new List<HIS.Model.ZY_PatList>();
            plist.Add(zypat);
            return ZyGetFee.GetZyItems(plist, IsConfird, deptid, docid);
        }
        #endregion
    }
}
