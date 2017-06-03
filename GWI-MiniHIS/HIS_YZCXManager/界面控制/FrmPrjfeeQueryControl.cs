using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.YZCX_BLL;

namespace HIS_YZCXManager
{
    public class FrmPrjfeeQueryControl
    {
        /// <summary>
        /// 大项目信息表
        /// </summary>
        private DataTable _bigItemDt;
        /// <summary>
        /// 核算项目信息表
        /// </summary>
        private DataTable _hsItemDt;
        /// <summary>
        /// 检索大项目编号
        /// </summary>
        private int _searchItemId;
        /// <summary>
        /// 住院开方医生统计信息表
        /// </summary>
        private DataTable _presDocFeeDt;

        /// <summary>
        /// 住院开方科室统计信息表
        /// </summary>
        private DataTable _presDeptFeeDt;
        /// <summary>
        /// 检索类型
        /// </summary>
        public SearchType _searchType;
        /// <summary>
        /// 项目金额查询接口
        /// </summary>
        private IFrmPrjfeeQuery _frmprjfeequery;

        public FrmPrjfeeQueryControl(IFrmPrjfeeQuery frmprjfeequery)
        {
            _frmprjfeequery = frmprjfeequery;
            //_presDocFeeDt = new DataTable();
            //_presDocFeeDt.Columns.Add("docname");
            //_presDocFeeDt.Columns.Add("totalfee", new Decimal().GetType());
            //_presDocFeeDt.Columns.Add("num", new Int32().GetType());
            //_presDocFeeDt.Columns.Add("presdoccode");
            //_presDeptFeeDt = new DataTable();
            //_presDocFeeDt.Columns.Add("deptname");
            //_presDocFeeDt.Columns.Add("totalfee", new Decimal().GetType());
            //_presDocFeeDt.Columns.Add("num", new Int32().GetType());
            //_presDocFeeDt.Columns.Add("presdeptcode");
        }

        public void LoadInitData()
        {
            try
            {
                _bigItemDt = PublicDataReader.GetBigItemList();
                _hsItemDt = PublicDataReader.GetHSItemList();
                _frmprjfeequery.RefreshItemTree(_hsItemDt, _bigItemDt);               
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        public void LoadData(DateTime beginTime, DateTime endTime, string itemCode)
        {
            try
            {
                switch (_searchType)
                {
                    case SearchType.门诊:
                        _presDeptFeeDt = MZ_Loader.LoadItemFeeByDept(beginTime, endTime, itemCode);
                        _presDocFeeDt = MZ_Loader.LoadItemFeeByDoc(beginTime, endTime, itemCode);
                        break;
                    case SearchType.住院:
                        _presDeptFeeDt = ZY_Loader.LoadItemFeeByDept(beginTime, endTime, itemCode);
                        _presDocFeeDt = ZY_Loader.LoadItemFeeByDoc(beginTime, endTime, itemCode);
                        break;
                    default:
                        DataTable dtMZDoc = MZ_Loader.LoadItemFeeByDoc(beginTime, endTime, itemCode);
                        DataTable dtZYDoc = ZY_Loader.LoadItemFeeByDoc(beginTime, endTime, itemCode);
                        DataTable dtMZDept = MZ_Loader.LoadItemFeeByDept(beginTime, endTime, itemCode);
                        DataTable dtZYDept = ZY_Loader.LoadItemFeeByDept(beginTime, endTime, itemCode);
                        for (int index = 0; index < dtMZDoc.Rows.Count; index++)
                        {
                            dtZYDoc.Rows.Add(dtMZDoc.Rows[index].ItemArray);
                        }
                        _presDocFeeDt = dtZYDoc;                      
                        for (int index = 0; index < dtMZDept.Rows.Count; index++)
                        {
                            dtZYDept.Rows.Add(dtMZDept.Rows[index].ItemArray);
                        }
                        _presDeptFeeDt = dtZYDept;
                        break;
                }
            }
            catch (Exception error)
            {
                throw error;
            }
        }

    }

    public interface IFrmPrjfeeQuery
    {
        void RefreshPrjDocFee(DataTable presDocDt);
        void RefreshPrjDeptFee(DataTable presDeptDt);
        void RefreshItemTree(DataTable hsItemDt, DataTable bigItemDt);
    }
}
