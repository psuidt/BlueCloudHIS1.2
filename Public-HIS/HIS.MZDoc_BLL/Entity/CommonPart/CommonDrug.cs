using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS;
using HIS.BLL;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 常用药品类
    /// </summary>
    public class CommonDrug : Model.Mz_Doc_CommonItem, IBaseCommon
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;   

        private string _itemname;
        private string _STANDARD;
        private string _unit;
        private string _ADDRESS;
        private string _PY_CODE;
        private string _WB_CODE;
        private string _D_CODE;

        /// <summary>
        /// 常用药品类构造函数
        /// </summary>
        public CommonDrug()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 常用药品类构造函数
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public CommonDrug(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        #region 属性
        /// <summary>
        /// 药品名称
        /// </summary>
        public string itemname
        {
            get { return _itemname; }
            set { _itemname = value; }
        }

        /// <summary>
        /// 药品规格
        /// </summary>
        public string STANDARD
        {
            get { return _STANDARD; }
            set { _STANDARD = value; }
        }

        /// <summary>
        /// 药品单位
        /// </summary>
        public string unit
        {
            get { return _unit; }
            set { _unit = value; }
        }

        /// <summary>
        /// 药品产地
        /// </summary>
        public string ADDRESS
        {
            get { return _ADDRESS; }
            set { _ADDRESS = value; }
        }

        /// <summary>
        /// 拼音码
        /// </summary>
        public string PY_CODE
        {
            get { return _PY_CODE; }
            set { _PY_CODE = value; }
        }

        /// <summary>
        /// 五笔码
        /// </summary>
        public string WB_CODE
        {
            get { return _WB_CODE; }
            set { _WB_CODE = value; }
        }

        /// <summary>
        /// 数字码
        /// </summary>
        public string D_CODE
        {
            get { return _D_CODE; }
            set { _D_CODE = value; }
        }

        /// <summary>
        /// 药品ID
        /// </summary>
        public int ItemId
        {
            get { return this.Item_Id; }
            set { this.Item_Id = value; }
        }
        #endregion

        /// <summary>
        /// 加载常用药品数据
        /// </summary>
        /// <param name="employeeid">所属医生Id</param>
        /// <returns>用药品数据表</returns>
        public DataTable LoadCommonData(long employeeid)
        {
            DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(_oleDb);
            return mzdoc_dal.Load_CommonDrug(employeeid);
        }

        /// <summary>
        /// 加载检索数据
        /// </summary>
        /// <returns>药品基础数据</returns>
        public DataTable LoadShowCardData()
        {
            DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(_oleDb);
            DataTable table = mzdoc_dal.Load_DrugDic();
            table.Columns["ITEMID"].ColumnName = Tables.mz_doc_commonitem.ITEM_ID;
            table.Columns["ITEMNAME"].ColumnName = Views.vi_item_drug.ITEMNAME+"1";
            table.Columns["BYNAME"].ColumnName = Views.vi_item_drug.ITEMNAME;
            table.Columns["PACKUNIT"].ColumnName = Views.vi_item_drug.UNIT;
            return table;
        }

        /// <summary>
        /// 新增常用药品数据
        /// </summary>
        /// <returns></returns>
        public bool Add()
        {
            this.Type = 1;
            BindEntity<Model.Mz_Doc_CommonItem>.CreateInstanceDAL(_oleDb).Add(this);
            return true;
        }

        /// <summary>
        /// 修改常用药品数据
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            this.Type = 1;
            BindEntity<Model.Mz_Doc_CommonItem>.CreateInstanceDAL(_oleDb).Update(this);
            return true;
        }

        /// <summary>
        /// 删除常用药品数据
        /// </summary>
        /// <returns></returns>
        public bool Delete()
        {
            this.Delete_Bit = 1;
            BindEntity<Model.Mz_Doc_CommonItem>.CreateInstanceDAL(_oleDb).Update(this);
            return true;
        }

        /// <summary>
        /// 累加常用项
        /// </summary>
        /// <param name="itemId">药品Id</param>
        /// <param name="employeeId">操作人员ID</param>
        public void Increase(int itemId, long employeeId)
        {
            Model.Mz_Doc_CommonItem commonItem = BindEntity<Model.Mz_Doc_CommonItem>.CreateInstanceDAL(_oleDb).GetModel(
                BLL.Tables.mz_doc_commonitem.ITEM_ID + _oleDb.EuqalTo() + itemId
                + _oleDb.And() + BLL.Tables.mz_doc_commonitem.RECORD_DOC + _oleDb.EuqalTo() + employeeId
                + _oleDb.And() + BLL.Tables.mz_doc_commonitem.TYPE + _oleDb.EuqalTo() + 1);

            //如果该药品在常用药品表中不存在，则添加新纪录，否则在使用频度上累加一次
            if (commonItem == null)
            {
                commonItem = new HIS.Model.Mz_Doc_CommonItem();
                commonItem.Item_Id = itemId;
                commonItem.Type = 1;
                commonItem.Record_Doc = (int)employeeId;
                commonItem.Frequency = 1;
                BindEntity<Model.Mz_Doc_CommonItem>.CreateInstanceDAL(_oleDb).Add(commonItem);
            }
            else
            {
                commonItem.Frequency = commonItem.Frequency + 1;
                BindEntity<Model.Mz_Doc_CommonItem>.CreateInstanceDAL(_oleDb).Update(commonItem);
            }
        }
    }
}
