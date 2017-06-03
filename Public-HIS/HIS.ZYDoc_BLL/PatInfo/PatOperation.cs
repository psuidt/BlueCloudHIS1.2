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

namespace HIS.ZYDoc_BLL.PatInfo
{
    public class PatOperation
    {
        private static GetInBed inbed = new GetInBed();
        private static GetOutPat outpat = new GetOutPat();
        private static PatType pattype = new PatType();
        #region 得到分床的病人列表
       /// <summary>
        /// 得到分床的病人列表
       /// </summary>
       /// <param name="sign">0=管辖内病人 1=全科室病人</param>
       /// <param name="docid"></param>
       /// <param name="deptid"></param>
       /// <returns></returns>
        public static List<HIS.Model.ZY_PatList> GetInBedPatList(int sign, int docid, int deptid)
        {
            return inbed.GetInBedPatList(sign, docid, deptid);
        }
        #endregion

        #region 获得病人的主治医生，经治医生，护士
        /// <summary>
        /// 获得病人的主治医生，经治医生，护士
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public static string[] GetDoc(int patlistid)
        {
            return inbed.GetDoc(patlistid);
        }
        #endregion

        #region 根据条件查询出院病人列表
        /// <summary>
        /// 根据条件查询出院病人列表
        /// </summary>
        /// <param name="IsIn"></param>
        /// <returns></returns>
        public static List<HIS.Model.ZY_PatList> GetOutPatList(string CureDeptCode, DateTime? Bdate, DateTime? Edate)
        {
            return outpat.GetOutPatList(CureDeptCode, Bdate, Edate);
        }
        #endregion

        #region 根据病人姓名查询
        /// <summary>
        /// 根据病人姓名查询
        /// </summary>
        /// <param name="patname"></param>
        /// <returns></returns>
        public static List<HIS.Model.ZY_PatList> GetOutPatName(string patname)
        {
            return outpat.GetOutPatName(patname);
        }
        #endregion

        #region 根据病人住院号查询
        /// <summary>
        /// 根据病人住院号查询
        /// </summary>
        /// <param name="cureno"></param>
        /// <returns></returns>
        public static List<HIS.Model.ZY_PatList> GetOutPatCureNo(string cureno)
        {
            return outpat.GetOutPatCureNo(cureno);
        }
        #endregion

        #region  判断病人是否存在转科记录
        /// <summary>
        /// 判断病人是否存在转科记录
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public static bool IsTurnDept(int patlistid)
        {
            return pattype.IsTurnDept(patlistid);
        }
        #endregion

        #region 通过patlistid获得patlist实体对象
        /// <summary>
        ///　通过patlistid获得patlist实体对象
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public static HIS.Model.ZY_PatList GetNewPatModel(int patlistid)
        {
            return pattype.GetNewPatModel(patlistid);
        }
        #endregion

        #region 出院和死亡医嘱时修改病人状态
        /// <summary>
        /// 出院和死亡医嘱时修改病人状态
        /// </summary>
        /// <param name="patlist"></param>
        internal static  void OutDeath(HIS.Model.ZY_PatList patlist)
        {
            pattype.OutDeath(patlist);
        }
        #endregion

        #region 取消出院和死亡时修改病人
        /// <summary>
        /// 取消出院和死亡时修改病人
        /// </summary>
        /// <param name="patlistid"></param>
        internal static  void CancelOutDeath(int patlistid)
        {
            pattype.CancelOutDeath(patlistid);
        }
        #endregion

        #region 判断是否可以修改医嘱
        /// <summary>
        /// 判断是否可以修改医嘱
        /// </summary>
        /// <param name="patlist"></param>
        /// <returns></returns>
        public static bool NotCanUpdate(HIS.Model.ZY_PatList patlist)
        {
            return pattype.NotCanUpdate(patlist);
        }
        #endregion

        // * 20100512.1.03  病人出院时判断病人是否存在未完成的手术
        public static bool ExistNotFinishSs(HIS.Model.ZY_PatList patlist)
        {
            return pattype.NotFinishSs(patlist);
        }

        #region 判断是否可以出院
        /// <summary>
        /// 判断是否可以出院
        /// </summary>
        /// <param name="patlistid"></param>
        /// <returns></returns>
        public static  string NotCanOut(int patlistid)
        {
            return pattype.NotCanOut(patlistid);
        }
        #endregion

        public static List<HIS.Model.ZY_PatList> GetPlistByno(string cureno)
        {
            return inbed.GetPlistByNo(cureno);
        }
    }
}
