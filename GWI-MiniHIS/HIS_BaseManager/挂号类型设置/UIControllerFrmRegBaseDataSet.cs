using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Base_BLL;



namespace HIS_BaseManager
{
    public interface IFrmRegBaseDataSet
    {

        DataTable RegTypeDefine
        {
            get;
            set;
        }
        string TypeCode
        {
            get;
            set;
        }
        string TypeName
        {
            get;
            set;
        }
        string Pym
        {
            get;
            set;
        }
        string Wbm
        {
            get;
            set;
        }
        bool Valid
        {
            get;
            set;
        }
    }

    public class UIControllerFrmRegBaseDataSet
    {
        private IFrmRegBaseDataSet view;
        private DataTable tbRegTypeDetailItems;
        private DataTable tbServiceItems;

        public DataTable ServiceItems
        {
            get
            {
                return tbServiceItems;
            }
        }
        public UIControllerFrmRegBaseDataSet(IFrmRegBaseDataSet View)
        {
            view = View;
        }
        
        
        public DataTable GetDetailItems( string TypeCode )
        {
            DataRow[] drs = tbRegTypeDetailItems.Select( "TYPE_CODE='" + TypeCode + "'" );
            DataTable tb = tbRegTypeDetailItems.Clone();
            for ( int i = 0; i < drs.Length; i++ )
                tb.Rows.Add( drs[i].ItemArray );
            return tb;
        }
        
        public void AddNewType(RegTypeItem regtype)
        {
            HIS.Base_BLL.RegTypeItemController controller = new HIS.Base_BLL.RegTypeItemController();
            if ( regtype.Items.Count == 0 )
                throw new Exception( "类型明细不能为空" );
            controller.AddNewType( regtype );
        }
        public void SaveRegType( RegTypeItem regtype )
        {
            HIS.Base_BLL.RegTypeItemController controller = new HIS.Base_BLL.RegTypeItemController();
            if ( regtype.Items.Count == 0 )
                throw new Exception( "类型明细不能为空" );
            controller.SaveRegType( regtype );
        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public void InitData()
        {
            tbServiceItems = BaseDataReader.GetBaseServiceItems();

            tbRegTypeDetailItems = BaseDataReader.GetRegisterTypeAndServiceItemRelation();

            view.RegTypeDefine = BaseDataReader.GetRegisterTypeList();
            
        }
    }
}
