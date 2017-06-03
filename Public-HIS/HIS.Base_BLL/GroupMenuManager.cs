using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using HIS;
using HIS.SYSTEM.Core;
namespace HIS.Base_BLL 
{
    /// <summary>
    /// 组菜单管理
    /// </summary>
    public class GroupMenuManager : HIS.SYSTEM.Core.BaseBLL
    {
         

        public GroupMenuManager()
        {
            
        }
        /// <summary>
        /// 开始编辑
        /// </summary>
        public void BeginEdit()
        {
            oleDb.BeginTransaction( );
        }
        /// <summary>
        /// 结算编辑
        /// </summary>
        public void EndEdit()
        {
            oleDb.CommitTransaction( );
        }
        /// <summary>
        /// 取消编辑
        /// </summary>
        public void AbortEdit()
        {
            oleDb.RollbackTransaction( );
        }
        /// <summary>
        /// 删除组菜单
        /// </summary>
        /// <param name="groupId">组ID</param>
        /// <param name="moduleId">模块ID</param>
        public void DeleteGroupMenu(int groupId,int moduleId)
        {
            
            BindEntity<Model.BASE_GROUP_MENU>.CreateInstanceDAL( oleDb , BLL.Tables.BASE_GROUP_MENU ).Delete( BLL.Tables.base_group_menu.MODULE_ID + oleDb.EuqalTo( ) + moduleId + oleDb.And( ) + BLL.Tables.base_group_menu.GROUP_ID + oleDb.EuqalTo( ) + groupId );

        }
        /// <summary>
        /// 增加组菜单
        /// </summary>
        /// <param name="GroupID">组ID</param>
        /// <param name="ModuleID">模块ID</param>
        /// <param name="MenuID">菜单ID</param>
        public void AddGroupMenu(int GroupID ,int  ModuleID ,int MenuID)
        {
            
            Model.BASE_GROUP_MENU model = new HIS.Model.BASE_GROUP_MENU( );
            model.GROUP_ID = GroupID;
            model.MODULE_ID = ModuleID;
            model.MENU_ID = MenuID;

            BindEntity<Model.BASE_GROUP_MENU>.CreateInstanceDAL( oleDb ).Add( model );
        }
        /// <summary>
        /// 新增组
        /// </summary>
        /// <param name="newGroupName">组名称</param>
        /// <param name="admin">是否管理员组</param>
        /// <returns></returns>
        public int AddGroup( string newGroupName , bool admin )
        {

            Model.BASE_GROUP base_group = new HIS.Model.BASE_GROUP();
            base_group.NAME = newGroupName;
            base_group.ADMINISTRATORS = admin ? 1: 0;
            base_group.DELETE_FLAG = 0;
            BindEntity<Model.BASE_GROUP>.CreateInstanceDAL( oleDb ).Add( base_group );

            return base_group.GROUP_ID;

        }
        /// <summary>
        /// 更新组信息
        /// </summary>
        /// <param name="groupId">组ID</param>
        /// <param name="name">名称</param>
        /// <param name="admin">是否管理员组</param>
        /// <param name="deleted">删除标志</param>
        /// <returns></returns>
        public bool UpdateGroup( int groupId , string name , bool admin , bool deleted )
        {
            Model.BASE_GROUP base_group = BindEntity<Model.BASE_GROUP>.CreateInstanceDAL( oleDb ).GetModel( groupId );
            if ( base_group != null )
            {
                base_group.NAME = name;
                base_group.ADMINISTRATORS = admin ? 1 : 0;
                base_group.DELETE_FLAG = deleted ? 1 : 0;
                BindEntity<Model.BASE_GROUP>.CreateInstanceDAL( oleDb ).Update( base_group );
                return true;
            }
            else
            {
                throw new Exception( "用户组已不存在！" );
            }
        }
        /// <summary>
        /// 删除组
        /// </summary>
        /// <param name="GroupId"></param>
        public void DeleteGroup( int GroupId )
        {

            BindEntity<Model.BASE_GROUP_MENU>.CreateInstanceDAL( oleDb ).Delete( "group_id=" + GroupId );
            BindEntity<Model.BASE_GROUP_USER>.CreateInstanceDAL( oleDb ).Delete( "group_id=" + GroupId );
            BindEntity<Model.BASE_GROUP>.CreateInstanceDAL( oleDb ).Delete( GroupId );
        }
    }
}
