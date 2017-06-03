using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Base_BLL;

namespace HIS_BaseManager.收费项目维护.UIController
{
    public class FrmComplexController
    {
        private IFrmComplexItem formView;
        /// <summary>
        /// 组合项目
        /// </summary>
        private DataTable tbComplexItems;
        /// <summary>
        /// 组合项目明细
        /// </summary>
        private DataTable tbComplexDetails;
        /// <summary>
        /// 组合项目
        /// </summary>
        public DataTable ComplexItems
        {
            get
            {
                return tbComplexItems;
            }
        }
        /// <summary>
        /// 当前选择的组合项目的明细
        /// </summary>
        public DataTable SelectedComplexItemDetail
        {
            get
            {
                DataRow[] drs = tbComplexDetails.Select("COMPLEX_ID=" + formView.SelectedComplexId );
                DataTable tbDetails = new DataTable();
                tbDetails.Columns.Add("ITEM_ID");
                tbDetails.Columns.Add("ITEM_NAME");
                tbDetails.Columns.Add("NUM");
                tbDetails.Columns.Add("PRICE");
                for (int i = 0; i < drs.Length; i++)
                {
                    DataRow dr = tbDetails.NewRow();
                    dr["ITEM_ID"] = drs[i]["ITEM_ID"];
                    dr["ITEM_NAME"] = drs[i]["ITEM_NAME"];
                    dr["NUM"] = drs[i]["NUM"];
                    dr["PRICE"] = drs[i]["PRICE"];
                    tbDetails.Rows.Add(dr);
                }
                return tbDetails;
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="FormView">界面视图</param>
        public FrmComplexController(IFrmComplexItem FormView)
        {
            formView = FormView;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Initialize()
        {
            //加载本院所有医疗服务项目（包括组合项目）
            DataTable HospitalServiceItemsAndComplexItems = HIS.Base_BLL.BaseDataReader.Get_Hospital_Service_Items();
            //获得本院的组合项目
            tbComplexItems = HospitalServiceItemsAndComplexItems.Clone();
            tbComplexItems.Rows.Clear();
            DataRow[] drs = HospitalServiceItemsAndComplexItems.Select("COMPLEX_ID<>0");
            for (int i = 0; i < drs.Length; i++)
                tbComplexItems.Rows.Add(drs[i].ItemArray);
            //明细
            tbComplexDetails = HIS.Base_BLL.BaseDataReader.Get_Complex_Detail();
        }
        /// <summary>
        /// 增加一个组合项目
        /// </summary>
        public void AddComplexItem()
        {
            try
            {
                
                ComplexItem complexItem = new ComplexItem();
                complexItem.ITEM_NAME = formView.Complex_Name;
                complexItem.ITEM_UNIT = formView.Complex_Item_Unit;
                complexItem.PRICE = formView.Complex_Price;
                complexItem.PY_CODE = formView.Complex_Py_Code;
                complexItem.WB_CODE = formView.Complex_Wb_Code;
                complexItem.STATITEM_CODE = formView.Complex_Statitem_Code;
                complexItem.VALID_FLAG = formView.Complex_Valid_Flag;
                complexItem.Details = formView.ComplexDetail;

                ServiceItemController controller = new ServiceItemController();
                controller.AddComplexItemByHospital(complexItem);
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 保存组合项目
        /// </summary>
        public void UpdateComplexItem()
        {
            try
            {
                ComplexItem complexItem = new ComplexItem();
                complexItem.ITEM_ID = formView.SelectedComplexId;
                complexItem.ITEM_NAME = formView.Complex_Name;
                complexItem.ITEM_UNIT = formView.Complex_Item_Unit;
                complexItem.PRICE = formView.Complex_Price;
                complexItem.PY_CODE = formView.Complex_Py_Code;
                complexItem.WB_CODE = formView.Complex_Wb_Code;
                complexItem.STATITEM_CODE = formView.Complex_Statitem_Code;
                complexItem.VALID_FLAG = formView.Complex_Valid_Flag;
                complexItem.Details = formView.ComplexDetail;

                ServiceItemController controller = new ServiceItemController();
                controller.UpdateComplexItemByHospital(complexItem);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 显示组合项目内容
        /// </summary>
        public void ShowComplexItem()
        {
            DataRow[] dr = tbComplexItems.Select("COMPLEX_ID=" + formView.SelectedComplexId);
            if (dr.Length > 0)
            {
                formView.Complex_Name = dr[0]["ITEM_NAME"].ToString();
                formView.Complex_Py_Code = dr[0]["PY_CODE"].ToString();
                formView.Complex_Wb_Code = dr[0]["WB_CODE"].ToString();
                formView.Complex_Item_Unit = dr[0]["ITEM_UNIT"].ToString();
                formView.Complex_Statitem_Code = dr[0]["STATITEM_CODE"].ToString();
                formView.Complex_Price = Convert.ToDecimal(dr[0]["PRICE"]);
                formView.Complex_Valid_Flag = Convert.ToInt32(dr[0]["VALID_FLAG"]);
                
            }
        }
        /// <summary>
        /// 数据验证
        /// </summary>
        /// <param name="complexItem"></param>
        private void ValidateData(ComplexItem complexItem)
        {
            if (complexItem.ITEM_NAME.Trim() == "")
                throw new CustomException("组合项目名称不能为空");

            if (complexItem.ITEM_UNIT.Trim() == "")
                throw new CustomException("组合项目单位不能为空");

            if (complexItem.STATITEM_CODE.Trim() == "")
                throw new CustomException("统计大类不能为空");

            if (complexItem.PRICE == 0)
                throw new CustomException("组合项目价格不能为0");

            if (complexItem.Details.Count == 0)
                throw new CustomException("组合项目明细至少需要指定一个收费项目");
        }
    }
}
