using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using GWMHIS.BussinessLogicLayer.Classes;

namespace HIS_ZYDocManager.Action
{

    /// <summary>
    /// 医嘱颜色
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

        public interface IFrmDocModelView : IView
        {

            DataTable BindDocModelData { get; set; }           
           
            int tag { get; set; }        
            PresColor presColor { set; }  
            bool  XDEnabled { set; }           
            bool ItemNameReadOnly { set; }
            bool AmountReadOnly { set; }
            bool PresAmountReadOnly { set; }
            bool UnitReadOnly { set;}
            bool FrenQuencyReadOnly {set;}
            bool UsageReadOnly { set; }
            bool FirstTimeReadOnly { set; }
            bool DropSperReadOnly { set; }
            bool StrucReadOnly { set; }
            string GetYfIds { get; }
        }

}
