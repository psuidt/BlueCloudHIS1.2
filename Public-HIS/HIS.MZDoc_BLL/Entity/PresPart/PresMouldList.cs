using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.SYSTEM.DatabaseAccessLayer;
using HIS.BLL;

namespace HIS.MZDoc_BLL
{
    /// <summary>
    /// 处方模板明细类
    /// </summary>
    public class PresMouldList : Model.Mz_Doc_PresMouldList,IBasePresList
    {
        #region 成员变量
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;

        private string _price = "";          //单价
        private string _dept_name = "";      //执行科室名称
        private string _usage_name = "";     //用法名称
        private string _frequency_name = ""; //频次名称
        private int _frequency_ExecNum = 1;  //频次对应的执行次数
        private int _frequency_CycleDay = 1;  //频次对应的执行周期

        private bool _selected;              //是否选中
        private bool _isFloat;               //是否是按含量取整的药品

        private int _item_id;
        private string _item_name;
        private decimal _usage_amount;
        private int _dosage;
        private int _days;
        private int _item_amount;

        private Public.PresStatus _status = HIS.MZDoc_BLL.Public.PresStatus.新建状态; //模板明细状态
        #endregion

        /// <summary>
        /// 处方模板明细类构造函数
        /// </summary>
        public PresMouldList()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 处方模板明细类构造函数
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public PresMouldList(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        #region 属性

        #region 扩展的string属性
        /// <summary>
        /// 项目ID
        /// </summary>
        public string Item_Id_S
        {
            get
            {
                return base.Item_Id<=0 ?"":base.Item_Id.ToString();
            }
            set
            {
                try
                {
                    _item_id = Convert.ToInt32(value);
                }
                catch
                {
                    _item_id = -1;
                }
            }
        }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Item_Name_S
        {
            get
            {
                return this.FootNote == "" || this.FootNote == null ? base.Item_Name : (base.Item_Name + "【" + this.FootNote + "】");
            }
            set
            {
                _item_name = value;
            }
        }
        /// <summary>
        /// 每次用量
        /// </summary>
        public string Usage_Amount_S
        {
            get
            {
                return base.Usage_Amount == 0 ? "" : base.Usage_Amount.ToString();
            }
            set
            {
                try
                {
                    _usage_amount = Convert.ToDecimal(value);
                }
                catch
                {
                    _usage_amount = 1;
                }
            }
        }
        /// <summary>
        /// 用量单位
        /// </summary>
        public string Usage_Unit_S
        {
            get
            {
                return base.Usage_Unit;
            }
            set
            {
            }
        }
        /// <summary>
        /// 剂数
        /// </summary>
        public string Dosage_S
        {
            get
            {
                return base.Dosage == 0 ? "" : base.Dosage.ToString();
            }
            set
            {
                try
                {
                    _dosage = Convert.ToInt32(value);
                }
                catch
                {
                    _dosage = 1;
                }
            }
        }
        /// <summary>
        /// 开药天数
        /// </summary>
        public string Days_S
        {
            get
            {
                return base.Days == 0 ? "" : base.Days.ToString();
            }
            set
            {
                try
                {
                    _days = Convert.ToInt32(value);
                }
                catch
                {
                    _days = 1;
                }
            }
        }
        /// <summary>
        /// 开药数量
        /// </summary>
        public string Item_Amount_S
        {
            get
            {
                return base.Item_Amount == 0 ? "" : (this.Item_Amount*this.Dosage).ToString();
            }
            set
            {
                try
                {
                    _item_amount = Convert.ToInt32(value);
                }
                catch
                {
                    _item_amount = 1;
                }
            }
        }
        /// <summary>
        /// 用量单位
        /// </summary>
        public string Item_Unit_S
        {
            get
            {
                return base.Item_Unit;
            }
            set
            {
            }
        }
        #endregion

        /// <summary>
        /// 单价
        /// </summary>
        public string Price
        {
            get { return _price; }
            set { _price = value; }
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
        /// 用法名称
        /// </summary>
        public string Usage_Name
        {
            get { return _usage_name; }
            set { _usage_name = value; }
        }
        /// <summary>
        /// 频次名称
        /// </summary>
        public string Frequency_Name
        {
            get { return _frequency_name; }
            set { _frequency_name = value; }
        }
        /// <summary>
        /// 频次对应的执行次数
        /// </summary>
        public int Frequency_ExecNum
        {
            get { return _frequency_ExecNum; }
            set { _frequency_ExecNum = value; }
        }
        /// <summary>
        /// 频次对应的执行周期
        /// </summary>
        public int Frequency_CycleDay
        {
            get { return _frequency_CycleDay; }
            set { _frequency_CycleDay = value; }
        }
        /// <summary>
        /// 处方号
        /// </summary>
        public string TmpNo
        {
            get { return base.OrderNo == 1 ? base.PresNo.ToString() : ""; }
            set { }
        }
        /// <summary>
        /// 模板明细状态
        /// </summary>
        public Public.PresStatus Status
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// 药品标志
        /// </summary>
        public bool IsDrug
        {
            get
            {
                //update by heyan 材料也属于药品 2010.10.26
                return this.StatItem_Code == "00" || this.StatItem_Code == "01" || this.StatItem_Code == "02" || this.StatItem_Code == "03"; 
            }
            set
            {
            }
        }
        /// <summary>
        /// 中药标志
        /// </summary>
        public bool IsHerb  
        {
            get
            {
                return this.StatItem_Code == "03";
            }
            set
            {
            }
        }
        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Selected
        {
            get { return _selected; }
            set { _selected = value; }
        }
        /// <summary>
        /// 是否是按含量取整的药品
        /// </summary>
        public bool IsFloat
        {
            get { return _isFloat; }
            set { _isFloat = value; }
        }
        #endregion

        /// <summary>
        /// 将扩展的String类型的值赋到原属性上
        /// </summary>
        private void SetRealValue()
        {
            this.Item_Id = this._item_id;
            this.Usage_Amount = this._usage_amount;
            this.Dosage = this._dosage;
            this.Days = this._days;
            this.Item_Amount = this._item_amount/this._dosage;
        }

        /// <summary>
        /// 计算开药总量
        /// </summary>
        public void CalculateAmount()
        {
            this.SetRealValue();
            if (this.IsDrug)
            {
                if (this.IsHerb)
                {
                    this.Days = this.Dosage;
                    this.Item_Amount = Convert.ToInt32(this.Usage_Amount);// *this.Dosage;
                }
                else
                {
                    if (IsFloat)
                    {
                        this.Item_Amount = Convert.ToInt32(Math.Ceiling(Math.Ceiling(this.Usage_Amount * this.Frequency_ExecNum / this.Frequency_CycleDay * this.Days / this.Usage_Rate) * this.Item_Rate / this.RelationNum));
                    }
                    else
                    {
                        this.Item_Amount = Convert.ToInt32(Math.Ceiling(Math.Ceiling(this.Usage_Amount / this.Usage_Rate) * this.Frequency_ExecNum / this.Frequency_CycleDay * this.Days * this.Item_Rate / this.RelationNum));
                    }
                }
            }
            else
            {
                this.Item_Amount = (int)this.Usage_Amount;
            }
        }

        /// <summary>
        /// 加载属性
        /// </summary>
        public void LoadData()
        {
            this._dept_name = HIS.MZDoc_BLL.OP_ReadBaseData.GetDeptName(this.Dept_Id);
            this._usage_name = HIS.MZDoc_BLL.OP_ReadBaseData.GetUsageName(this.Usage_Id);

            HIS.Model.Base_Frequency frequency = BindEntity<Model.Base_Frequency>.CreateInstanceDAL(_oleDb).GetModel(this.Frequency_Id);
            if (frequency != null)
            {
                this._frequency_name = frequency.Name;
                this.Frequency_ExecNum = frequency.ExecNum;
                this.Frequency_CycleDay = frequency.CycleDay;
            }

            _status = HIS.MZDoc_BLL.Public.PresStatus.保存状态;

            if (this.IsDrug)
            {
                HIS.Model.YP_MakerDic drug = BindEntity<Model.YP_MakerDic>.CreateInstanceDAL(_oleDb).GetModel(base.Item_Id);
                this._price = Convert.ToString(drug.RetailPrice / base.Item_Rate);
            }
            else
            {
                if (this.Tc_Flag == 0)
                {
                    HIS.Model.BASE_SERVICE_ITEMS item = BindEntity<Model.BASE_SERVICE_ITEMS>.CreateInstanceDAL(_oleDb).GetModel(base.Service_Item_Id);
                    this._price = item.PRICE.ToString();
                }
                else
                {
                    HIS.Model.BASE_COMPLEX_ITEM item = BindEntity<Model.BASE_COMPLEX_ITEM>.CreateInstanceDAL(_oleDb).GetModel(base.Service_Item_Id);
                    this._price = item.PRICE.ToString();
                }
            }
        }

        /// <summary>
        /// 保存模板明细
        /// </summary>
        /// <param name="mouldLists"></param>
        public int Save(IList mouldLists)
        {
            _oleDb.BeginTransaction();
            try
            {
                foreach (PresMouldList mouldList in mouldLists)
                {
                    mouldList.SetRealValue();
                    if (mouldList.Status == HIS.MZDoc_BLL.Public.PresStatus.新建状态)
                    {
                        BindEntity<Model.Mz_Doc_PresMouldList>.CreateInstanceDAL(_oleDb).Add(mouldList);
                    }
                    else if (mouldList.Status == HIS.MZDoc_BLL.Public.PresStatus.修改状态)
                    {
                        BindEntity<Model.Mz_Doc_PresMouldList>.CreateInstanceDAL(_oleDb).Update(mouldList);
                    }
                }
                _oleDb.CommitTransaction();
                return (int)Public.PresStatus.保存状态;
            }
            catch (Exception e)
            {
                _oleDb.RollbackTransaction();
                throw e;
            }
        }

        /// <summary>
        /// 删除单条处方明细记录
        /// </summary>
        public int Delete()
        {
            _oleDb.BeginTransaction();
            try
            {
                this.Delete_Bit = 1;
                BindEntity<Model.Mz_Doc_PresMouldList>.CreateInstanceDAL(_oleDb).Update(this);
                string strsql = "update mz_doc_presmouldlist set orderno=orderno-1 where presno=" + this.PresNo + " and orderno>" + this.OrderNo + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID;
                int rownum = _oleDb.DoCommand(strsql); 
                if (this.Group_Id > 0)
                {
                    strsql = "update mz_doc_presmouldlist set group_id=group_id-1 where presno=" + this.PresNo + " and orderno>" + this.OrderNo + " and orderno-group_id=" + (this.OrderNo - this.Group_Id) + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID;
                    _oleDb.DoCommand(strsql); 
                }
                if(this.OrderNo==1 && rownum==0)
                {
                    strsql = "update mz_doc_presmouldlist set presno=presno-1 where presmouldheadid=" + this.PresMouldHeadId + " and presno>" + this.PresNo + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID;
                    _oleDb.DoCommand(strsql);
                }
                _oleDb.CommitTransaction();
                return Public.PresStatus.保存状态.GetHashCode();
            }
            catch (Exception e)
            {
                _oleDb.RollbackTransaction();
                throw e;
            }
        }

        /// <summary>
        /// 删除多条处方明细记录
        /// </summary>
        /// <param name="mouldLists">模板明细列表</param>
        public void Delete(List<PresMouldList> mouldLists)
        {
            _oleDb.BeginTransaction();
            try
            {
                int currentPresNo = 0;
                int currentOrderNo = 0;

                int lastPresNo = 0;
                foreach (PresMouldList mouldList in mouldLists)
                {
                    if (mouldList.Selected)
                    {
                        mouldList.Delete_Bit = 1;
                        BindEntity<Model.Mz_Doc_PresMouldList>.CreateInstanceDAL(_oleDb).Update(mouldList);
                    }
                    else
                    {
                        if (mouldList.PresNo == currentPresNo)
                        {
                            if (mouldList.OrderNo != ++currentOrderNo)
                            {
                                mouldList.OrderNo = currentOrderNo;
                                BindEntity<Model.Mz_Doc_PresMouldList>.CreateInstanceDAL(_oleDb).Update(mouldList);
                            }
                        }
                        else
                        {
                            if (mouldList.PresNo == lastPresNo)
                            {
                                mouldList.PresNo = currentPresNo;
                                mouldList.OrderNo = ++currentOrderNo;
                                BindEntity<Model.Mz_Doc_PresMouldList>.CreateInstanceDAL(_oleDb).Update(mouldList);
                            }
                            else
                            {
                                lastPresNo = mouldList.PresNo;
                                currentOrderNo = 1;
                                mouldList.PresNo = ++currentPresNo;
                                mouldList.OrderNo = 1;
                                BindEntity<Model.Mz_Doc_PresMouldList>.CreateInstanceDAL(_oleDb).Update(mouldList);
                            }
                        } 
                    }

                }
                _oleDb.CommitTransaction();
            }
            catch (Exception e)
            {
                _oleDb.RollbackTransaction();
                throw e;
            }
        }
    }
}
