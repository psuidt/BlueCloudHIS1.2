using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

using GWMHIS.BussinessLogicLayer.Classes;
using HIS.ZY_BLL.DataModel;
using HIS.ZY_BLL;
namespace HIS_ZYManager.Action
{
    /// <summary>
    /// 划价的状态
    /// </summary>
    public enum PresType
    {
        默认,
        划价,
        记账
    };
    /// <summary>
    /// 处方颜色
    /// </summary>
    public struct PresColor
    {
        public PresColor(int _rowIndex, int _colIndex, System.Drawing.Color _ForeColor, System.Drawing.Color _BackColor)
        {
            rowIndex = _rowIndex;
            colIndex = _colIndex;
            ForeColor = _ForeColor;
            BackColor = _BackColor;
        }
        /// <summary>
        /// 行号
        /// </summary>
        public int rowIndex;
        /// <summary>
        /// 列号
        /// </summary>
        public int colIndex;
        /// <summary>
        /// 行字体颜色
        /// </summary>
        public System.Drawing.Color ForeColor;
        /// <summary>
        /// 行背景颜色
        /// </summary>
        public System.Drawing.Color BackColor;
    }
    /// <summary>
    /// 划价记账界面接口
    /// </summary>
    public interface IFrmPresManagerView:IView
    {
        PresType PresType { get; }
        string InpatNo { get; set; }
        DateTime PresDate { get; }
        string PresDocCode { get; set; }
        string PresDocName { get; }

        ZY_PatList BindPatControlData { set; }
        PatFee BindPatFeeControlData { set; }

        DataTable BindLongPresControlData { get; set; }
        DataTable BindShortPresControlData { get; set; }
        string lblongFee { set; }
        string lbshortFee { set; }

        FlatStyle XDEnabled { set; }
        bool ItemIDReadOnly { set; }
        bool BigNumReadOnly { set; }
        bool SmallNumReadOnly { set; }

        PresColor presColor { set; }

        int yfDeptID { get; }
        void ReLoadDurgData(DataTable _dt);
    }
}
