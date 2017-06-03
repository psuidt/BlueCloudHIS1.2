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
    /// 处方信息类
    /// </summary>
    public class Prescription : Model.Mz_Doc_PresList,IBasePresList,HIS.Interface.IPresDetail
    {
        #region 成员变量
        /// <summary>
        /// 数据库对象
        /// </summary>
        private RelationalDatabase _oleDb = null;

        private int _presNo;                 //处方号
        private int _dept_id;                //执行科室代码
        private string _dept_name = "";      //执行科室名称
        private Public.PresStatus _status = HIS.MZDoc_BLL.Public.PresStatus.新建状态; //处方明细状态
        private DateTime _pres_date;         //处方时间

        private string _usage_name = "";     //用法名称
        private string _frequency_name = ""; //频次名称
        private int _frequency_ExecNum = 1;  //频次对应的执行次数
        private int _frequency_CycleDay = 1; //频次对应的执行周期
        private string _frequency_Caption = ""; //频次说明


        private bool _selected;              //是否选中
        private bool _isFloat;               //是否是按含量取整的药品

        private int _item_id;
        private string _item_name;
        private decimal _usage_amount;
        private int _dosage;
        private int _days;
        private int _item_amount;
        private string _item_money;
        #endregion

        /// <summary>
        /// 处方信息类构造函数
        /// </summary>
        public Prescription()
        {
            _oleDb = BaseBLL.oleDb;
        }

        /// <summary>
        /// 处方信息类构造函数
        /// </summary>
        /// <param name="oleDB">数据库对象</param>
        public Prescription(RelationalDatabase oleDB)
        {
            _oleDb = oleDB;
        }

        #region 属性

        #region 处方头属性
        /// <summary>
        /// 处方号
        /// </summary>
        public int PresNo
        {
            get { return _presNo; }
            set { _presNo = value; }
        }
        /// <summary>
        /// 处方号
        /// </summary>
        public string TmpNo
        {
            get { return base.OrderNo == 1 ? this.PresNo.ToString() : ""; }
            set { }
        }
        /// <summary>
        /// 执行科室
        /// </summary>
        public int Dept_Id
        {
            get { return _dept_id; }
            set { _dept_id = value; }

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
        /// 处方时间
        /// </summary>
        public DateTime Pres_Date
        {
            get { return _pres_date; }
            set { _pres_date = value; }
        }
        #endregion

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
                try
                {
                    string name = base.Item_Name;
                    if (this.FootNote != null && this.FootNote != "")
                    {
                        name += "【" + this.FootNote + "】";
                    }
                    string usageId = OP_ReadBaseData.GetConfigValue("002");
                    if (base.Usage_Id != (usageId == "" ? 0 : Convert.ToInt32(usageId)))
                    {
                        switch (this.SkinTest_Flag)
                        {
                            case 1:
                                name += "(皮试)";
                                break;
                            case 2:
                                name += "(-)";
                                break;
                            case 3:
                                name += "(+)";
                                break;
                            case 4:
                                name += "(免试)";
                                break;
                            default:
                                break;
                        }
                    }
                    if (this.IsDrug && this.SelfDrug_Flag == 1)
                    {
                        name += "【自备】";
                    }
                    return name;
                }
                catch
                {
                    return base.Item_Name;
                }
            }
            set
            {
                _item_name = value;
            }
        }
        /// <summary>
        /// 项目单价
        /// </summary>
        public string Item_Price_S
        {
            get
            {
                return this.Item_Price == 0 ? "" : base.Item_Price.ToString("0.0000");
            }
            set
            {
            }
        }
        /// <summary>
        /// 每次用量
        /// </summary>
        public string Usage_Amount_S
        {
            get
            {
                return base.Usage_Amount == 0 ? "" : base.Usage_Amount.ToString("0.0000");
            }
            set
            {
                try
                {
                    _usage_amount = Convert.ToDecimal(value);
                    if (_usage_amount <= 0)
                    {
                        _usage_amount = 1;
                    }
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
                    if (_item_amount <= 0)
                    {
                        _item_amount = 1;
                    }
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

        #region 扩展属性
        /// <summary>
        /// 处方明细金额
        /// </summary>
        public string Item_Money
        {
            get
            {
                return _item_money;
            }
            set
            {
                _item_money = value;
            }
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
        /// 频次说明
        /// </summary>
        public string Frequency_Caption
        {
            get { return _frequency_Caption; }
            set { _frequency_Caption = value; }
        }
        /// <summary>
        /// 药品标志
        /// </summary>
        public bool IsDrug
        {
            get
            {
                return this.StatItem_Code == "01" || this.StatItem_Code == "02" || this.StatItem_Code == "03";
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

        #region 门诊处方费用计算接口属性
        /// <summary>
        /// 大项目代码
        /// </summary>
        public string BigItemCode
        {
            get
            {
                return this.StatItem_Code;
            }
            set
            {
                this.StatItem_Code = value;
            }
        }
        /// <summary>
        /// 金额
        /// </summary>
        public decimal Money
        {
            get
            {
                return Convert.ToDecimal(this.Item_Money);
            }
            set
            {
                this.Item_Money = value.ToString("0.0000");
            }
        }
        #endregion

        #endregion

        #region 方法
        /// <summary>
        /// 将扩展的String类型的值赋到原属性上
        /// </summary>
        public void SetRealValue()
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
                        this.Item_Amount = Convert.ToInt32(Math.Ceiling(Math.Ceiling(this.Usage_Amount * (this.Frequency_ExecNum / this.Frequency_CycleDay) * this.Days / this.Usage_Rate) * this.Item_Rate / this.RelationNum));
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
            CalculateItemMoney();
        }

        /// <summary>
        /// 计算处方金额
        /// </summary>
        public void CalculateItemMoney()
        {
            if (this.SelfDrug_Flag == 1 && this.IsDrug)
            {
                this.Item_Money = "0.0000";
            }
            else
            {
                this.Item_Money = (this.Item_Price * this.Dosage * this.Item_Amount).ToString("0.0000");
            }
        }

        /// <summary>
        /// 计算金额
        /// </summary>
        public void CalculateMoney()
        {
            this.SetRealValue();
            //if (!this.IsDrug)
            //{
            //    this.Usage_Amount = this.Item_Amount;
            //}
            CalculateItemMoney();
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
                this.Frequency_Caption = frequency.Caption;
            }

            _status = HIS.MZDoc_BLL.Public.PresStatus.保存状态;
            CalculateItemMoney();
        }

        /// <summary>
        /// 删除单条处方明细记录
        /// </summary>
        public int Delete()
        {
            _oleDb.BeginTransaction();
            try
            {
                Model.Mz_Doc_PresHead presHead = BindEntity<Model.Mz_Doc_PresHead>.CreateInstanceDAL(_oleDb).GetModel(this.PresHeadId);
                if (presHead.Pres_Flag > 0)
                {
                    return presHead.Pres_Flag;
                }
                this.Delete_Bit = 1;
                BindEntity<Model.Mz_Doc_PresList>.CreateInstanceDAL(_oleDb).Update(this);
                string strsql = @"update mz_doc_preslist set orderno=orderno-1 
                         where presheadid=" + this.PresHeadId + " and orderno>" + this.OrderNo + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID;
                if (this.Group_Id > 0)
                {
                    strsql = @"update mz_doc_preslist set group_id=group_id-1 
                         where presheadid=" + this.PresNo + " and orderno>" + this.OrderNo + " and orderno-group_id=" + (this.OrderNo - this.Group_Id) + " and workid=" + HIS.SYSTEM.Core.EntityConfig.WorkID;
                    _oleDb.DoCommand(strsql);
                }
                _oleDb.DoCommand(strsql);
                _oleDb.CommitTransaction();
                return presHead.Pres_Flag;
            }
            catch (Exception e)
            {
                _oleDb.RollbackTransaction();
                throw e;
            }
        }

        /// <summary>
        /// 保存处方明细
        /// </summary>
        /// <param name="prescriptions"></param>
        public int Save(IList prescriptions)
        {
            _oleDb.BeginTransaction();
            try
            {
                foreach (Prescription prescription in prescriptions)
                {
                    Model.Mz_Doc_PresHead presHead = BindEntity<Model.Mz_Doc_PresHead>.CreateInstanceDAL(_oleDb).GetModel(prescription.PresHeadId);
                    if (presHead.Pres_Flag > 0)
                    {
                        return presHead.Pres_Flag;
                    }
                    prescription.SetRealValue();
                    if (prescription.Status == HIS.MZDoc_BLL.Public.PresStatus.新建状态)
                    {
                        BindEntity<Model.Mz_Doc_PresList>.CreateInstanceDAL(_oleDb).Add(prescription);
                    }
                    else if (prescription.Status == HIS.MZDoc_BLL.Public.PresStatus.修改状态)
                    {
                        BindEntity<Model.Mz_Doc_PresList>.CreateInstanceDAL(_oleDb).Update(prescription);
                    }
                }
                _oleDb.CommitTransaction();
                return Public.PresStatus.保存状态.GetHashCode() ;
            }
            catch (Exception e)
            {
                _oleDb.RollbackTransaction();
                throw e;
            }
        }

        /// <summary>
        /// 检查药品实时库存
        /// </summary>
        /// <returns>库存是否充足</returns>
        public bool CheckDrugStoreNum()
        {
            if (this.IsDrug)
            {
                string strsql = Views.vi_clinical_all_items.DRUG_FLAG + _oleDb.EuqalTo() + 1
                   + _oleDb.And() + Views.vi_clinical_all_items.ITEMID + _oleDb.EuqalTo() + this.Item_Id
                   + _oleDb.And() + Views.vi_clinical_all_items.EXECDEPTCODE + _oleDb.EuqalTo() + this.Dept_Id;
                DataTable table = BindEntity<object>.CreateInstanceDAL(_oleDb, Views.VI_CLINICAL_ALL_ITEMS).GetList(strsql);
                if (table != null && table.Rows.Count > 0)
                {
                    decimal storeNum = Convert.ToDecimal(table.Rows[0]["StoreNum"]);
                    if (this.Item_Amount * this.RelationNum * this.Dosage / this.Item_Rate > storeNum)
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取处方实时状态
        /// </summary>
        /// <returns>状态编号</returns>
        public int CurrentPresStatus()
        {
            Model.Mz_Doc_PresHead presHead = BindEntity<Model.Mz_Doc_PresHead>.CreateInstanceDAL(_oleDb).GetModel(this.PresHeadId);
            return presHead.Pres_Flag;
        }
        #endregion
    }
}
