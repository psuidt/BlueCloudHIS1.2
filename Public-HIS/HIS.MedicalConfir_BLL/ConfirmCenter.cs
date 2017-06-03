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
     abstract class ConfirCenter:BaseBLL
    {
       
         /// <summary>
         /// 得到住院病人列表
         /// </summary>
         /// <param name="IsConfird"></param>
         /// <param name="deptid"></param>
         /// <param name="docid"></param>
         /// <param name="bdate"></param>
         /// <param name="edate"></param>
         /// <returns></returns>
        public abstract List<HIS.Model.ZY_PatList> GetZyList(bool IsConfird, int deptid, int docid, DateTime? bdate, DateTime? edate);

         /// <summary>
         /// 得到门诊病人列表
         /// </summary>
         /// <param name="IsConfird"></param>
         /// <param name="deptid"></param>
         /// <param name="docid"></param>
         /// <param name="bdate"></param>
         /// <param name="edate"></param>
         /// <returns></returns>
        public abstract List<HIS.Model.MZ_PatList> GetMzList(bool IsConfird, int deptid, int docid, DateTime? bdate, DateTime? edate);
   
        /// <summary>
        /// 通过病人ID获得病人的项目明细
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="IsConfird">false=没有确费的 true=已经确费的</param>
        /// <returns></returns>
        public abstract DataTable GetItemDetails(bool IsConfird, int deptid, int docid);


         /// <summary>
         /// 查询指定病人的费用明细
         /// </summary>
         /// <param name="id"></param>
         /// <param name="IsConfird"></param>
         /// <param name="deptid"></param>
         /// <param name="docid"></param>
         /// <returns></returns>
        public abstract DataTable FindDetails(string  id,bool IsConfird,int deptid,int docid);

        /// <summary>
        /// 确费
        /// </summary>
        /// <param name="presorders"></param>
        /// <param name="ConfirDoc"></param>
        /// <returns></returns>
        public abstract bool SaveConfir(List<int> presorders, int ConfirDoc, int ConfirDept);

        /// <summary>
        /// 取消确费
        /// </summary>
        /// <param name="presorders"></param>
        /// <param name="CancelDoc"></param>
        /// <returns></returns>
        public abstract bool  CancelConfir(List<int> presorders,int CancelDoc);

        public object GetConfig()
        {
            return  BindEntity<HIS.Model.ZY_DOC_CONFIG>.CreateInstanceDAL(oleDb).GetFieldValue(Tables.zy_doc_config.VALUE, "code='007'");
        }
        #region 属性       
        private List<HIS.Model.ZY_PatList> _zyplist;
        private List<HIS.Model.MZ_PatList> _mzplist;
       
        public List<HIS.Model.ZY_PatList> zyPlist
        {
            get
            {
                return _zyplist;
            }
            set
            {
                _zyplist = value;
            }
        }
        public List<HIS.Model.MZ_PatList> mzPlist
        {
            get
            {
                return _mzplist;
            }
            set
            {
                _mzplist = value;
            }
        }
        #endregion
    }
}
