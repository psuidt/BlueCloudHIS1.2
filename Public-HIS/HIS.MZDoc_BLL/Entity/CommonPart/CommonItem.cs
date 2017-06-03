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
    /// 常用项目类
    /// </summary>
    public class CommonItem : Model.Mz_Doc_CommonItem, IBaseCommon
    {
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;   
        private HIS.Model.Base_Order_Items _order_items = new HIS.Model.Base_Order_Items();

        /// <summary>
        /// 常用项目类构造函数
        /// </summary>
        public CommonItem()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 常用项目类构造函数
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public CommonItem(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        #region 属性
        /// <summary>
        /// 名称
        /// </summary>
        public string Order_Name
        {
            get { return _order_items.Order_Name; }
            set { _order_items.Order_Name = value; }

        }
        /// <summary>
        /// 单位
        /// </summary>
        public string Order_Unit
        {
            get { return _order_items.Order_Unit; }
            set { _order_items.Order_Unit = value; }

        }
        /// <summary>
        /// 医嘱类型
        /// </summary>
        public int Order_Type
        {
            get { return _order_items.Order_Type; }
            set { _order_items.Order_Type = value; }

        }
        /// <summary>
        /// 医技项目类型
        /// </summary>
        public int Medical_Class
        {
            get { return _order_items.Medical_Class; }
            set { _order_items.Medical_Class = value; }

        }
        /// <summary>
        /// 默认用法
        /// </summary>
        public string Default_Usage
        {
            get { return _order_items.Default_Usage; }
            set { _order_items.Default_Usage = value; }

        }
        /// <summary>
        /// 拼音码
        /// </summary>
        public string Py_Code
        {
            get { return _order_items.Py_Code; }
            set { _order_items.Py_Code = value; }

        }
        /// <summary>
        /// 五笔码
        /// </summary>
        public string Wb_Code
        {
            get { return _order_items.Wb_Code; }
            set { _order_items.Wb_Code = value; }

        }
        /// <summary>
        /// 数字码
        /// </summary>
        public string D_Code
        {
            get { return _order_items.D_Code; }
            set { _order_items.D_Code = value; }

        }
        /// <summary>
        /// 套餐标志
        /// </summary>
        public int Tc_Flag
        {
            get { return _order_items.Tc_Flag; }
            set { _order_items.Tc_Flag = value; }

        }
        /// <summary>
        /// 备注
        /// </summary>
        public string Bz
        {
            get { return _order_items.Bz; }
            set { _order_items.Bz = value; }

        }
        #endregion

        /// <summary>
        /// 加载常用项目数据
        /// </summary>
        /// <param name="employeeid">所属医生Id</param>
        /// <returns>常用项目数据表</returns>
        public DataTable LoadCommonData(long employeeid)
        {
            DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(_oleDb);
            return mzdoc_dal.Load_CommonItem(employeeid);
        }

        /// <summary>
        /// 加载检索数据
        /// </summary>
        /// <returns>医嘱项目基础数据</returns>
        public DataTable LoadShowCardData()
        {
            DataTable table = BindEntity<object>.CreateInstanceDAL(_oleDb, HIS.BLL.Tables.BASE_ORDER_ITEMS).GetList("delete_bit=0");
            table.Columns.Remove(Tables.base_order_items.ITEM_ID);
            table.Columns[Tables.base_order_items.ORDER_ID].ColumnName = Tables.mz_doc_commonitem.ITEM_ID;
            return table;
        }

        /// <summary>
        /// 新增常用项目数据
        /// </summary>
        /// <returns></returns>
        public bool Add()
        {
            this.Type = 0;
            BindEntity<Model.Mz_Doc_CommonItem>.CreateInstanceDAL(_oleDb).Add(this);
            return true;
        }

        /// <summary>
        /// 修改常用项目数据
        /// </summary>
        /// <returns></returns>
        public bool Update()
        {
            this.Type = 0;
            BindEntity<Model.Mz_Doc_CommonItem>.CreateInstanceDAL(_oleDb).Update(this);
            return true;
        }

        /// <summary>
        /// 删除常用项目数据
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
        /// <param name="itemId">医嘱项目ID</param>
        /// <param name="employeeId">操作人员ID</param>
        public void Increase(int itemId, long employeeId)
        {
            Model.Mz_Doc_CommonItem commonItem = BindEntity<Model.Mz_Doc_CommonItem>.CreateInstanceDAL(_oleDb).GetModel(
                BLL.Tables.mz_doc_commonitem.ITEM_ID + _oleDb.EuqalTo() + itemId
                + _oleDb.And() + BLL.Tables.mz_doc_commonitem.RECORD_DOC + _oleDb.EuqalTo() + employeeId
                + _oleDb.And() + BLL.Tables.mz_doc_commonitem.TYPE + _oleDb.EuqalTo() + 0);

            //如果该项目在常用项目表中不存在，则添加新纪录，否则在使用频度上累加一次
            if (commonItem == null)
            {
                commonItem = new HIS.Model.Mz_Doc_CommonItem();
                commonItem.Item_Id = itemId;
                commonItem.Type = 0;
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
