using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.MedicalConfir_BLL
{
    public class ConfirOP
    { 
        /// <summary>
        /// 得到住院病人列表
        /// </summary>
        /// <param name="IsConfird">false=没有确费的 true=已经确费的</param>
        /// <returns></returns>
        public   List<HIS.Model.ZY_PatList> GetZyConfirdList(bool IsConfird,DateTime ?bdate,DateTime ?edate)
        {         
           
            return ConfirFactory.GetConfirType(type).GetZyList(IsConfird, deptId, docId, bdate, edate);
        }

        /// <summary>
        /// 得到住院病人列表
        /// </summary>
        /// <param name="IsConfird">false=没有确费的 true=已经确费的</param>
        /// <returns></returns>
        public  List<HIS.Model.MZ_PatList> GetMzConfirdList(bool IsConfird, DateTime? bdate, DateTime? edate)
        {     
            return ConfirFactory.GetConfirType(type).GetMzList(IsConfird, deptId, docId, bdate, edate);
        }

        /// <summary>
        /// 通过病人ID获得病人的项目明细
        /// </summary>
        /// <param name="patlistid"></param>
        /// <param name="IsConfird">false=没有确费的 true=已经确费的</param>
        /// <returns></returns>
        public  DataTable GetItemDetails( bool IsConfird)
        {
            ConfirCenter center = ConfirFactory.GetConfirType(type);
            center.zyPlist = zyPlist;
            center.mzPlist = mzPlist;
            return center.GetItemDetails(IsConfird, deptId, docId);
        }

        public DataTable FindDetails(string id, bool IsConfird)
        {
            return ConfirFactory.GetConfirType(type).FindDetails(id, IsConfird, deptId, docId);
        }

        /// <summary>
        /// 确费
        /// </summary>
        /// <param name="presorders"></param>
        /// <param name="ConfirDoc"></param>
        /// <returns></returns>
        public  bool SaveConfir(List<int> presorders)
        {
            return ConfirFactory.GetConfirType(type).SaveConfir(presorders, docId,deptId);
        }

        /// <summary>
        /// 取消确费
        /// </summary>
        /// <param name="presorders"></param>
        /// <param name="CancelDoc"></param>
        /// <returns></returns>
        public  bool CancelConfir(List<int> presorders)
        {
            return ConfirFactory.GetConfirType(type).CancelConfir(presorders, docId);
        }

        #region 属性
        private int _docid;
        private int _deptid;
        private List<HIS.Model.ZY_PatList> _zyplist;
        private List<HIS.Model.MZ_PatList> _mzplist;
        private ConfirType _type;

        public int docId
        {
            get
            {
                return _docid;
            }
            set
            {
                _docid = value;
            }
        }
        public int deptId
        {
            get
            {
                return _deptid;
            }
            set
            {
                _deptid = value;
            }
        }
        public List<HIS.Model.ZY_PatList> zyPlist
        {
            get
            {
                return _zyplist;
            }
            set
            {
                _zyplist = value;
               // ConfirFactory.GetConfirType(type).zyPlist = value;
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
               // ConfirFactory.GetConfirType(type).mzPlist = value;
            }
        }
        public ConfirType type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
                
            }
        }

        #endregion
    }
}
