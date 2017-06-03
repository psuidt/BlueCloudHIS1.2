using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using GWMHIS.BussinessLogicLayer.Classes;
using System.Windows.Forms;
namespace HIS_ZYDocManager.Action
{
  
     
        /// <summary>
        /// 医嘱颜色
        /// </summary>
        public struct OrderColor
        {
            public OrderColor(int _rowIndex, int _colIndex, System.Drawing.Color _ForeColor, System.Drawing.Color _BackColor)
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
        ///诊疗管理界面接口
        /// </summary>
        public interface IFrmOrderManagerView : IView
        {

            HIS.Model.ZY_PatList zy_patlist_get { get; set; }           
            HIS.Model.ZY_PatList BindPatControlData { set; }           
            DataTable BindLongOrderData { get; set; }
            DataTable BindTempOrderData { get; set; }            
            OrderColor OrderColor { set; }            
            void   Plus(int i);
            int GetOrderKind();
            int GetRowIndex();
            bool ItemNameReadOnly { set; }
            bool AmountReadOnly { set; }
            bool PresAmountReadOnly { set; }
            bool UnitReadOnly { set; }
            bool FrenQuencyReadOnly { set; }
            bool UsageReadOnly { set; }
            bool FirstTimeReadOnly { set; }
            bool DropSperReadOnly { set; }
            bool StrucReadOnly { set; }
            string GetYfIds { get;}
            Control EmrControl { set; }
            void CouserNodeAdd(string name, string value);
            string Nodetag { get; }

        }
    
}