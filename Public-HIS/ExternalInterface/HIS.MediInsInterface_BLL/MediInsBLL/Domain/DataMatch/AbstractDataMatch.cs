using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.MediInsInterface_BLL.MediInsBLL.Dao;
using HIS.MediInsInterface_BLL.MediInsInterface.matchInterface;
using HIS.MediInsInterface_BLL.MediInsBLL.Dao.DataMatch.Daointerface;
using HIS.MediInsInterface_BLL.MediInsBLL.Dao.DataMatch.DaoClass;

namespace HIS.MediInsInterface_BLL.MediInsBLL.Domain.DataMatch
{
    //[20100519.1.03]
    public abstract class AbstractDataMatch : IbaseDao,IDisposable
    {
        /// <summary>
        /// Dao接口
        /// </summary>
        protected ICxHndatamatch idatamatch_dao = null;
        /// <summary>
        /// 外部接口
        /// </summary>
        protected ImatchInterface match_sys = null;

        private string _EmpID;

        public string EmpID
        {
            get { return _EmpID; }
            set { _EmpID = value; }
        }
        private string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }

        #region IbaseDao 成员
        private HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _oleDb;
        public HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase oleDb
        {
            get
            {
                return _oleDb;
            }
            set
            {
                _oleDb = value;
            }
        }

        public AbstractDataMatch()
        {
            _oleDb = BaseBLL.oleDb;

            idatamatch_dao = DaoFactory.GetObject<ICxHndatamatch>(typeof(DataMatchDao));
            idatamatch_dao.oleDb = oleDb;
            match_sys = matchFactory.Create("CxHn");
        }

        public AbstractDataMatch(HIS.SYSTEM.DatabaseAccessLayer.RelationalDatabase _OleDb)
        {
            _oleDb = _OleDb;

            idatamatch_dao = DaoFactory.GetObject<ICxHndatamatch>(typeof(DataMatchDao));
            idatamatch_dao.oleDb = oleDb;
            match_sys = matchFactory.Create("CxHn");
        }

        #endregion
        /// <summary>
        /// 接口外数据
        /// </summary>
        /// <returns></returns>
        public abstract DataTable OuterData(bool b);
        /// <summary>
        /// HIS内数据
        /// </summary>
        /// <returns></returns>
        public abstract DataTable HisData(bool b);
        /// <summary>
        /// 关系数据
        /// </summary>
        /// <returns></returns>
        public abstract DataTable RelationData(bool IsNew, string itemType);

        /// <summary>
        /// 下载接口外目录
        /// </summary>
        public abstract void DownLoadContent();

        /// <summary>
        /// 增加匹配关系
        /// </summary>
        public abstract void AddMatchRelation(string ncms_code,string hospital_code,string item_type );

        /// <summary>
        /// 上传单条匹配关系
        /// </summary>
        public abstract void UploadSingleMatchRelation(string hosp_code, string item_code, string serial_match, string match_type);

        /// <summary>
        /// 上传全部匹配关系
        /// </summary>
        public abstract void UploadAllMatchRelation();

        /// <summary>
        /// 删除匹配信息
        /// </summary>
        public abstract void DeleteMatchRelation(string hosp_code, string item_code, string serial_match, string match_type, string audit_flag);

        #region IDisposable 成员

        public void Dispose()
        {
            ((IDisposable)match_sys).Dispose();
        }

        #endregion
    }
}
