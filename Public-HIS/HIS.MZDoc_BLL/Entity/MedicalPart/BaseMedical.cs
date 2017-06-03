using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 医技申请基础类
    /// </summary>
    public abstract class BaseMedical :Model.Mz_Doc_Medical_Apply
    {
        #region 成员变量
        /// <summary>
        /// 数据库对象
        /// </summary>
        protected RelationalDatabase _oleDb = null;
        private string _statitem_code;
        private int _dept_id;
        private string _dept_name;
        private decimal _price;
        private int _num;
        private string _unit;
        private int _tc_flag;
        private int _service_item_id;
        private HIS.MZDoc_BLL.Public.PresStatus _status;
        private bool _selected = true;              //是否选中
        #endregion

        #region 属性
        /// <summary>
        /// 大项目代码
        /// </summary>
        public string StatItem_Code
        {
            get { return _statitem_code; }
            set { _statitem_code = value; }
        }
        /// <summary>
        /// 执行科室ID
        /// </summary>
        public int Dept_Id
        {
            get { return _dept_id; }
            set { _dept_id = value; }
        }
        /// <summary>
        /// 执行科室名称
        /// </summary>
        public string Dept_Name
        {
            get { return _dept_name; }
            set { _dept_name = value; }
        }
        /// <summary>
        /// 项目价格
        /// </summary>
        public decimal Price
        {
            get { return _price; }
            set { _price = value; }
        }
        /// <summary>
        /// 项目数量
        /// </summary>
        public int Num
        {
            get { return _num; }
            set { _num = value; }
        }
        /// <summary>
        /// 项目单位
        /// </summary>
        public string Unit 
        {
            get { return _unit; }
            set { _unit = value; }
        }
        /// <summary>
        /// 套餐标志
        /// </summary>
        public int Tc_Flag 
        {
            get { return _tc_flag; }
            set { _tc_flag = value; }
        }
        /// <summary>
        /// 收费项目ID
        /// </summary>
        public int Service_Item_Id
        {
            get { return _service_item_id; }
            set { _service_item_id = value; }
        }
        /// <summary>
        /// 申请状态
        /// </summary>
        public Public.PresStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected
        {
            get
            {
                return (this.Status == HIS.MZDoc_BLL.Public.PresStatus.保存状态 || this.Status == HIS.MZDoc_BLL.Public.PresStatus.新建状态) && _selected;
            }
            set { _selected = value; }
        }
        #endregion

        /// <summary>
        /// 获得医技科室
        /// </summary>
        /// <param name="dataSet">基础数据集</param>
        /// <returns></returns>
        public abstract DataTable LoadMedicalDept(DataSet dataSet);

        /// <summary>
        /// 获得医技项目类型
        /// </summary>
        /// <param name="dataSet">基础数据集</param>
        /// <param name="deptId">科室ID</param>
        /// <returns></returns>
        public abstract DataTable LoadMedicalClass(DataSet dataSet, int deptId);

        /// <summary>
        /// 获得医技项目类型
        /// </summary>
        /// <returns></returns>
        public abstract List<Model.Base_Medical_Class> LoadMedicalClass();

        /// <summary>
        /// 获得医技项目明细
        /// </summary>
        /// <param name="dataSet">基础数据集</param>
        /// <param name="deptId">科室ID</param>
        /// <param name="medicalClass">医技分类</param>
        /// <returns></returns>
        public abstract DataTable LoadMedicalItem(DataSet dataSet, int deptId, int medicalClass);

        /// <summary>
        /// 获取医技项目基础数据
        /// </summary>
        /// <param name="dataSet">用来存放数据的数据集</param>
        public void LoadMedicalItem(DataSet dataSet)
        {
            if (dataSet.Tables.IndexOf("MedicalItem") >= 0)
            {
                dataSet.Tables.Remove("MedicalItem");
            }
            DAL.MZDoc_DAL mzdoc_dal = new HIS.DAL.MZDoc_DAL(_oleDb);
            DataTable table = mzdoc_dal.Load_MedicalItem();
            table.TableName = "MedicalItem";
            dataSet.Tables.Add(table);
        }

        /// <summary>
        /// 创建申请记录
        /// </summary>
        /// <param name="item">医技申请项目</param>
        protected void CreateBaseApply(Medical_Order_Item item)
        {
            this.Item_Id = item.Order_Id;
            this.Item_Name = item.Order_Name;
            this.StatItem_Code = item.StatItem_Code;
            this.Medical_Class = item.Medical_Class;
            this.Price = item.Price;
            this.Dept_Id = item.Dept_Id;
            this.Dept_Name = item.Dept_Name;
            this.Unit = item.Order_Unit;
            this.Tc_Flag = item.Tc_Flag;
            this.Service_Item_Id = item.Item_Id;
            this.Apply_Date = HIS.SYSTEM.PubicBaseClasses.XcDate.ServerDateTime;
            this.Status = HIS.MZDoc_BLL.Public.PresStatus.新建状态;
        }

        /// <summary>
        /// 创建申请记录
        /// </summary>
        /// <param name="item">医技申请项目类</param>
        public abstract void CreateApply(Medical_Order_Item item);

        /// <summary>
        /// 合成申请内容
        /// </summary>
        public abstract void ComposeApplyContent();

        /// <summary>
        /// 分解申请内容
        /// </summary>
        public abstract void DeComposeApplyContent();
    }
}
