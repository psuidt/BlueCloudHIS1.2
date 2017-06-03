using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS.Base_BLL;
using HIS.BLL;
using HIS.Base_BLL.收费项目及医嘱维护;


namespace HIS_BaseManager.收费项目维护.UIController
{
    /// <summary>
    /// 项目执行科室维护类
    /// </summary>
    public class FrmItemExecDeptController
    {
        private IFrmItemExecDept formView;
        /// <summary>
        /// 本院所有的医疗服务项目（包括组合项目）
        /// </summary>
        private DataTable tbHospitalServiceItems;
        /// <summary>
        /// 项目的执行科室列表（所有）
        /// </summary>
        private DataTable tbItemExecDept;

        public FrmItemExecDeptController(IFrmItemExecDept FormView)
        {
            formView = FormView;
        }
        /// <summary>
        /// 本院所有的医疗服务项目（包括组合项目）
        /// </summary>
        public DataTable HospitalServiceItems
        {
            get
            {
                return tbHospitalServiceItems;
            }
        }
        /// <summary>
        /// 项目的执行科室列表（所有）
        /// </summary>
        public DataTable ItemExecDepts
        {
            get
            {
                return tbItemExecDept;
            }
        }
        /// <summary>
        /// 当前选择的项目的执行科室列表
        /// </summary>
        public List<Department> ExecDeptOfSelectedItem
        {
            get
            {
                List<Department> lstDept = new List<Department>();
                if ( formView.SelectedItems.Count == 0 )
                    return lstDept;

                DataRow[] drsExec = tbItemExecDept.Select("ITEM_ID = " + formView.SelectedItems[0].ItemId + " AND COMPLEX_ID = " + formView.SelectedItems[0].ComplexId );

                for (int i = 0; i < drsExec.Length; i++)
                {
                    Department dept = new Department();

                    dept.DeptID = Convert.ToInt32(drsExec[i]["DEPT_ID"]);
                    dept.Name = drsExec[i]["DEPT_NAME"].ToString();
                    dept.DefaultFlag = Convert.ToInt32( drsExec[i]["DEFAULT_FLAG"] );
                    lstDept.Add(dept);
                }
                return lstDept;
            }
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public void Initiazle()
        {
            //加载服务项目
            tbHospitalServiceItems = HIS.Base_BLL.BaseDataReader.Get_Hospital_Service_Items();
            //加载执行科室 ITEM_ID,COMPLEX_ID,DEPT_ID,DEPT_NAME,DEFAULT_FLAG
            tbItemExecDept = HIS.Base_BLL.BaseDataReader.Get_Hsitem_ExecDept();
        }
        /// <summary>
        /// 保存当前设置的执行科室
        /// </summary>
        public void SaveItemExceDept()
        {
            try
            {
                ServiceItemController controller = new ServiceItemController();
                List<BaseItem> selectedItems = formView.SelectedItems;
                for ( int i = 0 ; i < selectedItems.Count ; i++ )
                {
                    controller.SaveHospitalItemExecDept( selectedItems[i].ItemId , selectedItems[i].ComplexId , formView.SelectedDepts );
                }
            }
            catch
            {
                throw new Exception("保存执行科室发生错误！");
            }
            
        }
    }
}
