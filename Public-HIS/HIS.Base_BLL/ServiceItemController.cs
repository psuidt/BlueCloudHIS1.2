using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.Core;
using System.Data;
using HIS.BLL;
using HIS.Model;

namespace HIS.Base_BLL
{
    public class ServiceItemController : BaseBLL
    {
        /// <summary>
        /// 增加一个医疗服务项目
        /// </summary>
        /// <param name="Item"></param>
        public void AddServiceItems(ServiceItem Item)
        {
            try
            {
                //增加数据库记录                
                int new_item_id = BindEntity<Model.BASE_SERVICE_ITEMS>.CreateInstanceDAL(oleDb).Add(Item.EntityModel);
                //将返回的新ID值赋给当前对象
                Item.EntityModel.ITEM_ID = new_item_id;
                
            }
            catch (Exception err)
            {

                throw err;
            }
        }
        /// <summary>
        /// 更新医疗服务项目
        /// </summary>
        /// <param name="Item"></param>
        public void UpdateServiceItem( ServiceItem Item )
        {
            try
            {
                //更新记录信息
                BindEntity<Model.BASE_SERVICE_ITEMS>.CreateInstanceDAL(oleDb).Update(Item.EntityModel);
                
            }
            catch (Exception err)
            {
                throw err;
            }
        }
        /// <summary>
        /// 填充项目的执行科室
        /// </summary>
        public void ServiceItemFillExecDept(ServiceItem Item)
        {
            List<Department> lstDept = new List<Department>();
            DataRow[] drs = BaseDataReader.Get_Hsitem_ExecDept().Select("COMPLEX_ID=0 and ITEM_ID=" + Item.ITEM_ID);
            for (int i = 0; i < drs.Length; i++)
            {
                Department dept = new Department();
                dept.DeptID = Convert.ToInt32(drs[i]["DEPT_ID"]);
                dept.Name = drs[i]["DEPT_NAME"].ToString().Trim();
                lstDept.Add(dept);
            }
            Item.ExecDepts = lstDept.ToArray();
        }
        /// <summary>
        /// 按ID获得服务项目
        /// </summary>
        /// <param name="ServiceItemId"></param>
        /// <returns></returns>
        public ServiceItem GetServiceItemById(int ServiceItemId)
        {
            ServiceItem item = new ServiceItem(ServiceItemId);
            return item;
        }

        

        /// <summary>
        /// 为医院增加一个服务项目
        /// </summary>
        /// <param name="Item"></param>
        public void AddServiceItemToHospital(ServiceItem Item)
        {
            string strWhere = Tables.base_hospital_items.ITEM_ID + oleDb.EuqalTo() + Item.ITEM_ID + oleDb.And()  + Tables.base_hospital_items.COMPLEX_ID + oleDb.EuqalTo() + "0" ;

            Model.BASE_HOSPITAL_ITEMS model = BindEntity<Model.BASE_HOSPITAL_ITEMS>.CreateInstanceDAL( oleDb ).GetModel( strWhere );

            if ( model == null )
            {
                model = new HIS.Model.BASE_HOSPITAL_ITEMS( );
                model.ITEM_ID = Item.ITEM_ID;
                model.COMPLEX_ID = 0;
                BindEntity<Model.BASE_HOSPITAL_ITEMS>.CreateInstanceDAL( oleDb ).Add( model );
            }
        }
        /// <summary>
        /// 医院移除一个服务项目
        /// </summary>
        /// <param name="Item"></param>
        public void RemoveServiceItemFromHospital( ServiceItem Item )
        {
            //1、从医院项目中移除
            string strWhere = Tables.base_hospital_items.ITEM_ID + oleDb.EuqalTo( ) + Item.ITEM_ID + oleDb.And()  +  Tables.base_hospital_items.COMPLEX_ID + oleDb.EuqalTo( ) + "0";

            Model.BASE_HOSPITAL_ITEMS model = BindEntity<Model.BASE_HOSPITAL_ITEMS>.CreateInstanceDAL( oleDb ).GetModel( strWhere );

            if ( model != null )
            {
                BindEntity<Model.BASE_HOSPITAL_ITEMS>.CreateInstanceDAL( oleDb ).Delete( strWhere );
                //2、删除执行设置的执行科室
                strWhere = Tables.base_item_dept.ITEM_ID + oleDb.EuqalTo() + Item.ITEM_ID + oleDb.And() + Tables.base_item_dept.COMPLEX_ID + oleDb.EuqalTo()  + "0";
                BindEntity<BASE_ITEM_DEPT>.CreateInstanceDAL(oleDb).Delete(strWhere);
            }
        }
        /// <summary>
        /// 移除本院医疗服务项目前的引用检查
        /// </summary>
        /// <param name="Item"></param>
        /// <param name="message"></param>
        public bool CheckServiceItemReferencedBeforeRemove(ServiceItem Item,out string message)
        {
            string strWhere = "";
            //1、检查是否被组合项目引用
            strWhere = Tables.base_complex_detail.SERVICE_ITEM_ID + oleDb.EuqalTo() + Item.ITEM_ID;
            BASE_COMPLEX_DETAIL base_complex_detail = BindEntity<BASE_COMPLEX_DETAIL>.CreateInstanceDAL(oleDb).GetModel(strWhere);
            if (base_complex_detail != null)
            {
                strWhere = Tables.base_complex_item.COMPLEX_ID + oleDb.EuqalTo() + base_complex_detail.COMPLEX_ID;
                BASE_COMPLEX_ITEM base_complex_item = BindEntity<BASE_COMPLEX_ITEM>.CreateInstanceDAL(oleDb).GetModel(strWhere);
                message = "【" + Item.ITEM_NAME + "】正在被组合项目【"+base_complex_item.COMPLEX_NAME+"】所引用";
                return false;
            }
            //2、检查是否被医嘱项目引用
            strWhere = Tables.base_order_items.ITEM_ID + oleDb.EuqalTo() + Item.ITEM_ID + oleDb.And() + Tables.base_order_items.TC_FLAG + oleDb.EuqalTo() + "0";
            Base_Order_Items base_order_item = BindEntity<Base_Order_Items>.CreateInstanceDAL(oleDb).GetModel(strWhere);
            if (base_order_item != null)
            {
                message = "【" + Item.ITEM_NAME + "】正在被医嘱项目【" + base_order_item.Order_Name + "】所引用";
                return false;
            }
            //3、检查是否被用法引用
            strWhere = "HSITEM_ID = " + Item.ITEM_ID;
            DataTable tb = BindEntity<object>.CreateInstanceDAL( oleDb , "BASE_USEAGE_FEE" ).GetList( strWhere );
            if ( tb.Rows.Count > 0 )
            {
                message = "【" + Item.ITEM_NAME + "】正在被用法【" + tb.Rows[0]["USE_NAME"].ToString().Trim() + "】联动";
                return false;
            }
            message = null;
            return true;
        } 

        

        /// <summary>
        /// 增加一个医院组合项目
        /// </summary>
        public void AddComplexItemByHospital(ComplexItem complexItem)
        {           
            if ( complexItem.Details.Count == 0 )
            {
                throw new CustomException( "组合项目的子项目不能为空" );
            }
            Model.BASE_COMPLEX_ITEM base_complex_item = new HIS.Model.BASE_COMPLEX_ITEM( );

            base_complex_item.COMPLEX_NAME = complexItem.ITEM_NAME;
            base_complex_item.ITEM_UNIT = complexItem.ITEM_UNIT;
            base_complex_item.PRICE = complexItem.PRICE;
            base_complex_item.PY_CODE = complexItem.PY_CODE;
            base_complex_item.WB_CODE = complexItem.WB_CODE;
            base_complex_item.STATITEM_CODE = complexItem.STATITEM_CODE;
            base_complex_item.VALID_FLAG = complexItem.VALID_FLAG;
            try
            {
                oleDb.BeginTransaction( );
                base_complex_item.COMPLEX_ID = BindEntity<Model.BASE_COMPLEX_ITEM>.CreateInstanceDAL( oleDb ).Add( base_complex_item );
                decimal cost = 0;
                foreach ( ComplexDetailItem detail in complexItem.Details )
                {
                    if (detail.ITEM_ID == 0) //2010-06-03 组合项目增加明细时，名称为空时，数据库里会增加一条空的记录  heyan
                    {
                        continue;
                    }
                    Model.BASE_COMPLEX_DETAIL base_complex_detail = new HIS.Model.BASE_COMPLEX_DETAIL( );
                    base_complex_detail.COMPLEX_ID = base_complex_item.COMPLEX_ID;
                    base_complex_detail.NUM = detail.Num;
                    base_complex_detail.SERVICE_ITEM_ID = detail.ITEM_ID;
                    cost += base_complex_detail.NUM * detail.PRICE;

                    BindEntity<Model.BASE_COMPLEX_DETAIL>.CreateInstanceDAL( oleDb ).Add( base_complex_detail );
                }
                //if ( complexItem.PRICE > cost )
                //{
                //    throw new CustomException( "定义的价格不能高于明细总价" );
                //}

                Model.BASE_HOSPITAL_ITEMS base_hospital_items = new HIS.Model.BASE_HOSPITAL_ITEMS( );
                base_hospital_items.COMPLEX_ID = base_complex_item.COMPLEX_ID;
                base_hospital_items.ITEM_ID = base_complex_item.COMPLEX_ID;
                BindEntity<Model.BASE_HOSPITAL_ITEMS>.CreateInstanceDAL( oleDb ).Add( base_hospital_items );
                oleDb.CommitTransaction( );
            }
            catch ( CustomException ce )
            {
                oleDb.RollbackTransaction( );
                throw ce;
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction( );
                throw new CustomException( "新增组合项目发生错误！" );
            }
        }
        /// <summary>
        /// 更新组合项目
        /// </summary>
        /// <param name="complexItem"></param>
        public void UpdateComplexItemByHospital( ComplexItem complexItem )
        {
            if ( complexItem.Details.Count == 0 )
            {
                throw new CustomException( "组合项目的子项目不能为空" );
            }
            Model.BASE_COMPLEX_ITEM base_complex_item = null;

            base_complex_item = BindEntity<Model.BASE_COMPLEX_ITEM>.CreateInstanceDAL( oleDb ).GetModel( Tables.base_complex_item.COMPLEX_ID + oleDb.EuqalTo( ) + complexItem.ITEM_ID );
            if ( base_complex_item == null )
                throw new CustomException( "读取组合项目失败！" );

            base_complex_item.COMPLEX_NAME = complexItem.ITEM_NAME;
            base_complex_item.ITEM_UNIT = complexItem.ITEM_UNIT;
            base_complex_item.PRICE = complexItem.PRICE;
            base_complex_item.PY_CODE = complexItem.PY_CODE;
            base_complex_item.WB_CODE = complexItem.WB_CODE;
            base_complex_item.STATITEM_CODE = complexItem.STATITEM_CODE;
            base_complex_item.VALID_FLAG = complexItem.VALID_FLAG;
            try
            {
                oleDb.BeginTransaction( );
                BindEntity<Model.BASE_COMPLEX_ITEM>.CreateInstanceDAL( oleDb ).Update( Tables.base_complex_item.COMPLEX_ID + oleDb.EuqalTo( ) + complexItem.ITEM_ID ,
                                                                                        Tables.base_complex_item.COMPLEX_NAME + oleDb.EuqalTo( ) + "'" + complexItem.ITEM_NAME + "'" ,
                                                                                        Tables.base_complex_item.ITEM_UNIT + oleDb.EuqalTo( ) + "'" + complexItem.ITEM_UNIT + "'" ,
                                                                                        Tables.base_complex_item.PRICE + oleDb.EuqalTo( ) + complexItem.PRICE ,
                                                                                        Tables.base_complex_item.PY_CODE + oleDb.EuqalTo( ) + "'" + complexItem.PY_CODE + "'" ,
                                                                                        Tables.base_complex_item.STATITEM_CODE + oleDb.EuqalTo( ) + "'" + complexItem.STATITEM_CODE + "'" ,
                                                                                        Tables.base_complex_item.VALID_FLAG + oleDb.EuqalTo( ) + complexItem.VALID_FLAG ,
                                                                                        Tables.base_complex_item.WB_CODE + oleDb.EuqalTo( ) + "'" + complexItem.WB_CODE + "'" );

                decimal cost = 0;
                BindEntity<Model.BASE_COMPLEX_DETAIL>.CreateInstanceDAL( oleDb ).Delete( Tables.base_complex_item.COMPLEX_ID + oleDb.EuqalTo( ) + complexItem.ITEM_ID );
                foreach ( ComplexDetailItem detail in complexItem.Details )
                {
                    if (detail.ITEM_ID == 0) //2010-06-03 组合项目增加明细时，名称为空时，数据库里会增加一条空的记录  heyan
                    {
                        continue;
                    }
                    Model.BASE_COMPLEX_DETAIL base_complex_detail = new HIS.Model.BASE_COMPLEX_DETAIL( );
                    base_complex_detail.COMPLEX_ID = base_complex_item.COMPLEX_ID;
                    base_complex_detail.NUM = detail.Num;
                    base_complex_detail.SERVICE_ITEM_ID = detail.ITEM_ID;
                    cost += base_complex_detail.NUM * detail.PRICE;

                    BindEntity<Model.BASE_COMPLEX_DETAIL>.CreateInstanceDAL( oleDb ).Add( base_complex_detail );
                }
                //if ( complexItem.PRICE > cost )
                //{
                //    throw new CustomException( "定义的价格不能高于明细总价" );
                //}

                oleDb.CommitTransaction( );
            }
            catch ( CustomException ce )
            {
                oleDb.RollbackTransaction( );
                throw ce;
            }
            catch 
            {
                oleDb.RollbackTransaction( );
                throw new CustomException( "更新组合项目发生错误！" );

            }
        }

        

        /// <summary>
        /// 保存执行科室
        /// </summary>
        /// <param name="ItemId"></param>
        /// <param name="ComplexId"></param>
        /// <param name="Depts"></param>
        public void SaveHospitalItemExecDept( int ItemId,int ComplexId, List<Department> Depts)
        {
            string strWhere = Tables.base_item_dept.ITEM_ID + oleDb.EuqalTo( ) + ItemId;
            strWhere += oleDb.And( );
            strWhere += Tables.base_item_dept.COMPLEX_ID + oleDb.EuqalTo( ) + ComplexId;

            oleDb.BeginTransaction( );
            try
            {
                BindEntity<Model.BASE_ITEM_DEPT>.CreateInstanceDAL( oleDb ).Delete( strWhere );

                foreach ( Department dept in Depts )
                {
                    Model.BASE_ITEM_DEPT base_item_dept = new HIS.Model.BASE_ITEM_DEPT( );
                    base_item_dept.ITEM_ID = ItemId;
                    base_item_dept.COMPLEX_ID = ComplexId;
                    base_item_dept.DEPT_ID = dept.DeptID;
                    base_item_dept.DEFAULT_FLAG = dept.DefaultFlag;
                    BindEntity<Model.BASE_ITEM_DEPT>.CreateInstanceDAL( oleDb ).Add( base_item_dept );
                }
                oleDb.CommitTransaction( );
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction( );
                ErrorController.Instance().LogEvent(err);
                throw err;
            }
        }

        

        /// <summary>
        /// 新增模板
        /// </summary>
        /// <param name="templateItem"></param>
        public void AddTemplateItem(TemplateItem templateItem)
        {
            if ( templateItem.Details == null || templateItem.Details.Count == 0 )
                throw new Exception( "模板没有明细，不能保存" );
            if ( templateItem.Tmplate_Name.Trim( ) == "" )
                throw new Exception( "模板名称不能为空" );
            try
            {
                oleDb.BeginTransaction( );
                Model.BASE_TEMPLATE_ITEM base_temp_item = new HIS.Model.BASE_TEMPLATE_ITEM( );
                base_temp_item.CREATE_DATE = templateItem.Create_Date;
                base_temp_item.CREATOR_ID = templateItem.Creator_Id;
                base_temp_item.CREATOR_NAME = templateItem.Creator_Name;
                base_temp_item.EXEC_DEPT_ID = templateItem.Exec_Dept_Id;
                base_temp_item.EXEC_DEPT_NAME = templateItem.Exce_Dept_Name;
                base_temp_item.DEPT_ID = templateItem.Dept_Id;
                base_temp_item.DEPT_NAME = templateItem.Dept_Name;
                base_temp_item.PY_CODE = templateItem.Py_Code;
                base_temp_item.SHARE_LEVEL = templateItem.Share_Level;
                base_temp_item.TMPLATE_NAME = templateItem.Tmplate_Name;
                base_temp_item.TMPLATE_TYPE = templateItem.Tmplate_Type;
                base_temp_item.VALID_FLAG = templateItem.Valid_Flag;
                base_temp_item.WB_CODE = templateItem.Wb_Code;

                BindEntity<Model.BASE_TEMPLATE_ITEM>.CreateInstanceDAL( oleDb ).Add( base_temp_item );
                foreach ( TemplateDetailItem item in templateItem.Details )
                {
                    Model.BASE_TEMPLATE_DETAIL detail = new HIS.Model.BASE_TEMPLATE_DETAIL( );
                    detail.TEMPLATE_ID = base_temp_item.TMPLATE_ID;
                    detail.BIGITEMCODE = item.BIGITEMCODE;
                    detail.COMPLEX_ID = item.COMPLEX_ID;
                    detail.DAYS = item.DAYS;
                    detail.DOSAGE = item.DOSAGE;
                    detail.FREQUEN_ID = item.FREQUEN_ID;
                    detail.FREQUEN_NAME = item.FREQUEN_NAME;
                    detail.GROUP_FLAG = item.GROUP_FLAG;
                    detail.ITEM_ID = item.ITEM_ID;
                    detail.ITEM_NAME = item.ITEM_NAME;
                    detail.SORT_NO = item.SORT_NO;
                    detail.STANDARD = item.STANDARD;
                    detail.UNIT = item.UNIT;
                    detail.USAGE_NAME = item.USAGE_NAME;
                    detail.Amount = item.AMOUNT;
                    BindEntity<Model.BASE_TEMPLATE_DETAIL>.CreateInstanceDAL( oleDb ).Add( detail );
                }
                oleDb.CommitTransaction( );
            }
            catch
            {
                oleDb.RollbackTransaction( );
                throw new Exception( "保存模板发生错误！" );
            }
        }
        /// <summary>
        /// 保存模板修改
        /// </summary>
        /// <param name="templateItem"></param>
        public void UpdateTemplateItem( TemplateItem templateItem )
        {
            if ( templateItem.Details == null || templateItem.Details.Count == 0 )
                throw new Exception( "模板没有明细，不能保存" );
            if ( templateItem.Tmplate_Name.Trim( ) == "" )
                throw new Exception( "模板名称不能为空" );
            try
            {
                oleDb.BeginTransaction( );
                string strWhere = Tables.base_template_item.TMPLATE_ID + oleDb.EuqalTo() + templateItem.Tmplate_Id;

                BindEntity<Model.BASE_TEMPLATE_ITEM>.CreateInstanceDAL( oleDb ).Update( strWhere ,
                                Tables.base_template_item.PY_CODE + oleDb.EuqalTo( ) + "'" + templateItem.Py_Code + "'" ,
                                Tables.base_template_item.WB_CODE + oleDb.EuqalTo( ) + "'" + templateItem.Wb_Code + "'" ,
                                Tables.base_template_item.SHARE_LEVEL + oleDb.EuqalTo( ) + "" + templateItem.Share_Level + "" ,
                                Tables.base_template_item.EXEC_DEPT_ID + oleDb.EuqalTo() + "" + templateItem.Exec_Dept_Id + "",
                                Tables.base_template_item.EXEC_DEPT_NAME + oleDb.EuqalTo() + "'" + templateItem.Exce_Dept_Name + "'",
                                Tables.base_template_item.TMPLATE_NAME + oleDb.EuqalTo( ) + "'" + templateItem.Tmplate_Name + "'" ,
                                Tables.base_template_item.VALID_FLAG + oleDb.EuqalTo( ) + "" + templateItem.Valid_Flag + "" );

                strWhere = Tables.base_template_detail.TEMPLATE_ID + oleDb.EuqalTo( ) + templateItem.Tmplate_Id;
                BindEntity<Model.BASE_TEMPLATE_DETAIL>.CreateInstanceDAL( oleDb ).Delete( strWhere );               
                foreach ( TemplateDetailItem item in templateItem.Details )
                {
                    Model.BASE_TEMPLATE_DETAIL detail = new HIS.Model.BASE_TEMPLATE_DETAIL( );
                    detail.TEMPLATE_ID = templateItem.Tmplate_Id;
                    detail.BIGITEMCODE = item.BIGITEMCODE;
                    detail.COMPLEX_ID = item.COMPLEX_ID;
                    detail.DAYS = item.DAYS;
                    detail.DOSAGE = item.DOSAGE;
                    detail.FREQUEN_ID = item.FREQUEN_ID;
                    detail.FREQUEN_NAME = item.FREQUEN_NAME;
                    detail.GROUP_FLAG = item.GROUP_FLAG;
                    detail.ITEM_ID = item.ITEM_ID;
                    detail.ITEM_NAME = item.ITEM_NAME;
                    detail.SORT_NO = item.SORT_NO;
                    detail.STANDARD = item.STANDARD;
                    detail.UNIT = item.UNIT;
                    detail.USAGE_NAME = item.USAGE_NAME;
                    detail.Amount = item.AMOUNT;
                    BindEntity<Model.BASE_TEMPLATE_DETAIL>.CreateInstanceDAL( oleDb ).Add( detail );
                }
                oleDb.CommitTransaction( );
            }
            catch
            {
                oleDb.RollbackTransaction( );
                throw new Exception( "保存模板发生错误！" );
            }
        }
        /// <summary>
        /// 删除模板
        /// </summary>
        /// <param name="templateItemId"></param>
        public void DeleteTemplateItem( int templateItemId )
        {
            
            try
            {
                oleDb.BeginTransaction( );

                string strWhere = Tables.base_template_item.TMPLATE_ID + oleDb.EuqalTo( ) + templateItemId;
                BindEntity<BASE_TEMPLATE_ITEM>.CreateInstanceDAL( oleDb ).Delete( strWhere );

                strWhere = Tables.base_template_detail.TEMPLATE_ID + oleDb.EuqalTo( ) + templateItemId;
                BindEntity<BASE_TEMPLATE_DETAIL>.CreateInstanceDAL( oleDb ).Delete( strWhere );
                oleDb.CommitTransaction( );
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction( );
                throw err;
            }
        }

        

        /// <summary>
        /// 增加医嘱项目
        /// </summary>
        /// <param name="order"></param>
        public void AddOrderItem(OrderItem order)
        {
            try
            {
                oleDb.BeginTransaction();
                Base_Order_Items base_order_item = new Base_Order_Items();
                base_order_item.Book_Date = order.BOOK_DATE;
                base_order_item.Bz = order.BZ;
                base_order_item.D_Code = order.D_CODE;
                base_order_item.Default_Usage = order.DEFAULT_USAGE;
                base_order_item.Del_Date = order.DEL_DATE;
                base_order_item.Delete_Bit = order.DELETE_BIT;
                base_order_item.Item_Id = order.ITEM_ID;
                if ( order.ORDER_TYPE == 7 ) //说明类医嘱不关联收费项目
                    base_order_item.Item_Id = 0;

                if ( order.MEDICAL_CLASS != 0 )
                    base_order_item.Medical_Class = order.MEDICAL_CLASS;
                else
                    base_order_item.Medical_Class = GetMedicalClass( order.ORDER_TYPE );
                base_order_item.Order_Name = order.ORDER_NAME;
                base_order_item.Order_Type = order.ORDER_TYPE;
                base_order_item.Order_Unit = order.ORDER_UNIT;
                base_order_item.Py_Code = order.PY_CODE;
                base_order_item.Tc_Flag = order.TC_FLAG;
                base_order_item.Wb_Code = order.WB_CODE;
                if (order.TC_FLAG == 1)
                {
                    AddComplexDetail(order);
                }
                BindEntity<Base_Order_Items>.CreateInstanceDAL(oleDb).Add(base_order_item);
                oleDb.CommitTransaction();
            }
            catch(Exception err)
            {
                oleDb.RollbackTransaction();
                ErrorController.Instance().LogEvent(err);
                throw new Exception("新增医嘱项目发生错误！");
            }
        }

        // * 20100604.2.03 组合项目应用到医嘱项目时，组合项目明细也自动应用。
        /// <summary>
        /// 如果是组合项目，自动把组合项目明细应用到医嘱项目。医嘱类型和医技类型和组合项目一样，如果已经存在，则不修改，
        /// </summary>
        /// <param name="order"></param>
        private void AddComplexDetail(OrderItem order)
        {
            string strWhere=Tables.base_complex_detail.COMPLEX_ID+oleDb.EuqalTo()+order.ITEM_ID;
            List<Model.BASE_COMPLEX_DETAIL> details = BindEntity<Model.BASE_COMPLEX_DETAIL>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
            try
            {               
                foreach (Model.BASE_COMPLEX_DETAIL detail in details)
                {
                    Base_Order_Items item = new Base_Order_Items();
                   
                    item.Book_Date = order.BOOK_DATE;
                    item.Bz = order.BZ;
                    item.Default_Usage = order.DEFAULT_USAGE;
                    item.Medical_Class = order.MEDICAL_CLASS;
                    item.Order_Type = order.ORDER_TYPE;
                    Model.BASE_SERVICE_ITEMS seveice = BindEntity<Model.BASE_SERVICE_ITEMS>.CreateInstanceDAL(oleDb).GetModel(Tables.base_service_items.ITEM_ID + oleDb.EuqalTo() + detail.SERVICE_ITEM_ID);
                    item.Item_Id = seveice.ITEM_ID;
                    item.Order_Name = seveice.ITEM_NAME;
                    item.Order_Unit = seveice.ITEM_UNIT;
                    item.Py_Code = seveice.PY_CODE;
                    item.Wb_Code = seveice.WB_CODE;
                    item.Tc_Flag = 0;
                    if (CheckItem(item))
                    {
                        continue;
                    }
                    BindEntity<Base_Order_Items>.CreateInstanceDAL(oleDb).Add(item);
                }
                
            }
            catch (Exception err)            
            {
               
                throw new Exception("新增医嘱组合项目明细发生错误！");
            }

        }

        /// <summary>
        /// 检查组合项目明细是否已应用
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private bool CheckItem(Base_Order_Items item)
        {    
            object obj = null;
            //string strWhere=Tables.base_order_items.ORDER_NAME+oleDb.EuqalTo()+"'"+item.Order_Name+"'" +
            //    oleDb.And()+Tables.base_order_items.ORDER_TYPE+oleDb.EuqalTo()+ item.Order_Type+
            //        oleDb.And()+Tables.base_order_items.ITEM_ID+oleDb.EuqalTo()+item.Item_Id;
            string strWhere = Tables.base_order_items.ITEM_ID + oleDb.EuqalTo() + item.Item_Id;
            obj = BindEntity<Base_Order_Items>.CreateInstanceDAL(oleDb).GetModel(strWhere);
            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 更新医嘱项目
        /// </summary>
        /// <param name="order"></param>
        public void UpdateOrderItem(OrderItem order)
        {
            try
            {
                oleDb.BeginTransaction();
                string strWhere = Tables.base_order_items.ORDER_ID + oleDb.EuqalTo() + order.ORDER_ID;

                Base_Order_Items base_order_item = BindEntity<Base_Order_Items>.CreateInstanceDAL(oleDb).GetModel(strWhere);
                if (base_order_item == null)
                    throw new Exception("无效的医嘱标识！");

                base_order_item.Book_Date = order.BOOK_DATE;
                base_order_item.Bz = order.BZ;
                base_order_item.D_Code = order.D_CODE;
                base_order_item.Default_Usage = order.DEFAULT_USAGE;
                base_order_item.Del_Date = order.DEL_DATE;
                base_order_item.Delete_Bit = order.DELETE_BIT;
                base_order_item.Item_Id = order.ITEM_ID;
                if ( order.ORDER_TYPE == 7 ) //说明类医嘱不关联收费项目
                    base_order_item.Item_Id = 0;

                if ( order.MEDICAL_CLASS != 0 )
                    base_order_item.Medical_Class = order.MEDICAL_CLASS;
                else
                    base_order_item.Medical_Class = GetMedicalClass( order.ORDER_TYPE );
                base_order_item.Order_Name = order.ORDER_NAME;
                base_order_item.Order_Type = order.ORDER_TYPE;
                base_order_item.Order_Unit = order.ORDER_UNIT;
                base_order_item.Py_Code = order.PY_CODE;
                base_order_item.Tc_Flag = order.TC_FLAG;
                base_order_item.Wb_Code = order.WB_CODE;
                if (order.TC_FLAG == 1)
                {
                    AddComplexDetail(order);
                }
                BindEntity<Base_Order_Items>.CreateInstanceDAL(oleDb).Update(base_order_item);
                oleDb.CommitTransaction();

            }
            catch (Exception err)
            {
                oleDb.RollbackTransaction();
                ErrorController.Instance().LogEvent(err);
                throw new Exception("保存医嘱项目发生错误！");
            }
        }
        /// <summary>
        /// 名称是否有效
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool ItemNameExists(object item)
        {
            object obj = null ;
            
            string strWhere = "";
            if (item is ServiceItem)
            {
                strWhere = Tables.base_service_items.ITEM_NAME + oleDb.EuqalTo() + "'" + ((ServiceItem)item).ITEM_NAME + "' and " + Tables.base_service_items.ITEM_ID + oleDb.NotEqualTo() + ((ServiceItem)item).ITEM_ID;
                obj = BindEntity<BASE_SERVICE_ITEMS>.CreateInstanceDAL(oleDb).GetModel(strWhere);
            }
            else if (item is ComplexItem)
            {
                strWhere = Tables.base_complex_item.COMPLEX_NAME + oleDb.EuqalTo() + "'" + ((ComplexItem)item).ITEM_NAME + "' and " + Tables.base_complex_item.COMPLEX_ID + oleDb.NotEqualTo() + ((ComplexItem)item).ITEM_ID;
                obj = BindEntity<BASE_COMPLEX_ITEM>.CreateInstanceDAL(oleDb).GetModel(strWhere);
            }
            else if (item is OrderItem)
            {
                strWhere = Tables.base_order_items.ORDER_NAME + oleDb.EuqalTo() + "'" + ((OrderItem)item).ORDER_NAME + "' and " + Tables.base_order_items.ORDER_TYPE + oleDb.EuqalTo() + ((OrderItem)item).ORDER_TYPE + " and " + Tables.base_order_items.ORDER_ID + oleDb.NotEqualTo() + ((OrderItem)item).ORDER_ID;
                obj = BindEntity<Base_Order_Items>.CreateInstanceDAL(oleDb).GetModel(strWhere);
            }
            else if ( item is UsageItem )
            {
                strWhere = Tables.base_usagediction.NAME + oleDb.EuqalTo( ) + "'" + ( (UsageItem)item ).Name + "' and " + Tables.base_usagediction.ID + oleDb.NotEqualTo( ) + ( (UsageItem)item ).ID;
                obj = BindEntity<Base_UsageDiction>.CreateInstanceDAL( oleDb ).GetModel( strWhere );
            }
            else
                throw new Exception( "参数不正确！对象必须为ServiceItem、ComplexItem、OrderItem,UsageItem" );

            if (obj == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// 数据检验
        /// </summary>
        /// <param name="item"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool DataCheckBeforeSave(OrderItem item ,out string message)
        {
            
            if (item.ORDER_NAME.Trim() == "")
            {
                message = "医嘱名称为空";
                return false;
            }
            if ( item.ORDER_TYPE == 0 )
            {
                message = "医嘱类型没有指定";
                return false;
            }
            if (item.ORDER_TYPE != 7 && item.ITEM_ID<=0)
            {
                message = "非说明类医嘱没有设置对应的收费项目";
                return false;
            }
            if (item.ORDER_TYPE == 5 && item.MEDICAL_CLASS <= 0)
            {
                message = "医技类医嘱没有指定医技类型";
                return false;
            }
            if (item.ORDER_NAME.Trim().Length > 50)
            {
                message = "医嘱名称过长！";
                return false;
            }
            if (ItemNameExists(item))
            {
                message = "同类型的医嘱名称重复";
                return false;
            }
            message = null;
            return true;
        }
        /// <summary>
        /// 获取医技分类，该方法为治疗项目特殊处理，如果是医嘱类型为治疗项目（4）
        /// 返回医技分类表中CLASS_TYPE=2的分类ID
        /// </summary>
        /// <param name="OrderType"></param>
        /// <returns></returns>
        private int GetMedicalClass(int OrderType)
        {
            if ( OrderType == 4 )
            {
                string strWhere = Tables.base_medical_class.CLASS_TYPE + oleDb.EuqalTo() + "2";
                Base_Medical_Class base_medical_class = BindEntity<Base_Medical_Class>.CreateInstanceDAL(oleDb).GetModel(strWhere);
                if ( base_medical_class == null )
                    return 0;
                else
                    return base_medical_class.Id;
            }
            else
                return 0;
        }

        /// <summary>
        /// 增加用法
        /// </summary>
        /// <param name="usage"></param>
        public void AddUsageItem( UsageItem usage )
        {
            try
            {
                Base_UsageDiction base_usagediction = new Base_UsageDiction( );
                base_usagediction.Name = usage.Name;
                base_usagediction.Py_Code = usage.Py_Code;
                base_usagediction.Wb_Code = usage.Wb_Code;
                base_usagediction.D_Code = "0";
                base_usagediction.Unit = usage.Unit;
                base_usagediction.Print_Long = usage.PrintLongOrder == true ? 1 : 0;
                base_usagediction.Print_Temp = usage.PrintTempOrder == true ? 1 : 0;
                base_usagediction.Delete_Bit = usage.DeleteBit == true ? 1 : 0;
                BindEntity<Base_UsageDiction>.CreateInstanceDAL( oleDb ).Add( base_usagediction );
                UpdateUsageAssociatedItems( usage );

            }
            catch ( Exception err)
            {
                ErrorController.Instance( ).LogEvent( err );
                throw new Exception( "保存用法项目发生错误！" );
            }
        }
        /// <summary>
        /// 更新用法
        /// </summary>
        /// <param name="usage"></param>
        public void UpdateUsageItem( UsageItem usage )
        {
            try
            {
                string strWhere = Tables.base_usagediction.ID + oleDb.EuqalTo( ) + usage.ID;

                Base_UsageDiction base_usagediction = BindEntity<Base_UsageDiction>.CreateInstanceDAL( oleDb ).GetModel( strWhere );
                if ( base_usagediction == null )
                    throw new Exception( "无效的用法标识！" );
                string old_name = base_usagediction.Name.Trim( );
                base_usagediction.Name = usage.Name;
                base_usagediction.Py_Code = usage.Py_Code;
                base_usagediction.Wb_Code = usage.Wb_Code;
                base_usagediction.D_Code = "0";
                base_usagediction.Unit = usage.Unit;
                base_usagediction.Print_Long = usage.PrintLongOrder == true ? 1 : 0;
                base_usagediction.Print_Temp = usage.PrintTempOrder == true ? 1 : 0;
                base_usagediction.Delete_Bit = usage.DeleteBit == true ? 1 : 0;
                BindEntity<Base_UsageDiction>.CreateInstanceDAL( oleDb ).Update( base_usagediction );
                UpdateUsageAssociatedItems( usage ,old_name);

            }
            catch ( Exception err )
            {
                ErrorController.Instance( ).LogEvent( err );
                throw new Exception( "保存用法项目发生错误！" );
            }
        }
        /// <summary>
        /// 更新用法联动的费用表
        /// </summary>
        /// <param name="usage"></param>
        private void UpdateUsageAssociatedItems(UsageItem usage  )
        {
            try
            {
                oleDb.BeginTransaction( );
                string strSql = "DELETE FROM BASE_USEAGE_FEE WHERE USE_NAME = '" + usage.Name + "'";
                oleDb.DoCommand( strSql );
                foreach ( LinkageItem item in usage.AssociatedItems )
                {
                    strSql = "INSERT INTO BASE_USEAGE_FEE(USE_NAME,NUM,HSITEM_ID,WORKID)";
                    strSql += "VALUES('" + usage.Name + "'," + item.Num + "," + item.ITEM_ID + "," + HIS.SYSTEM.Core.EntityConfig.WorkID + ")";
                    oleDb.DoCommand( strSql );
                }
                oleDb.CommitTransaction( );
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction( );
                ErrorController.Instance( ).LogEvent( err );
                throw new Exception( "保存用法对应联动收费项目！" );
            }
        }
        /// <summary>
        /// 更新用法联动的费用表(该方法用途为防止直接修改用法名称导致原来的明细丢失)
        /// 因为表结构设计上的缺陷，用用法名称做外键，所以更新前需要判断是否修改过名称
        /// </summary>
        /// <param name="usage"></param>
        /// <param name="oldUsageName">原用法名称</param>
        private void UpdateUsageAssociatedItems( UsageItem usage ,string oldUsageName)
        {
            try
            {
                oleDb.BeginTransaction( );
                string strSql = "DELETE FROM BASE_USEAGE_FEE WHERE USE_NAME = '" + oldUsageName + "'";
                oleDb.DoCommand( strSql );
                foreach ( LinkageItem item in usage.AssociatedItems )
                {
                    strSql = "INSERT INTO BASE_USEAGE_FEE(USE_NAME,NUM,HSITEM_ID,WORKID)";
                    strSql += "VALUES('" + usage.Name + "'," + item.Num + "," + item.ITEM_ID + "," + HIS.SYSTEM.Core.EntityConfig.WorkID + ")";
                    oleDb.DoCommand( strSql );
                }
                oleDb.CommitTransaction( );
            }
            catch ( Exception err )
            {
                oleDb.RollbackTransaction( );
                ErrorController.Instance( ).LogEvent( err );
                throw new Exception( "保存用法对应联动收费项目！" );
            }
        }
    }
}
