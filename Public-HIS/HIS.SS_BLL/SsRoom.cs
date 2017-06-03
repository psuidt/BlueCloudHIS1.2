using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;
using Entity = HIS.Model;
using System.Data;
using HIS.SYSTEM.Core;
using HIS.BLL;
using HIS.SYSTEM.PubicBaseClasses;

namespace HIS.SS_BLL
{
    public class SsRoom : BaseBLL
    {
        //获得所有手术房间名
        public List<HIS.Model.SS_ROOM> GetRooms()
        {         
            return BindEntity<HIS.Model.SS_ROOM>.CreateInstanceDAL(oleDb).GetListArray("");
        }
        //保存房间名
        public bool SaveNewRoom(string roomno)
        {
            HIS.Model.SS_ROOM room = new HIS.Model.SS_ROOM();
            room.ROOMNO = roomno;
            room.ROOMNAME = roomno + "间";
            string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode(room.ROOMNAME);
            room.PYM = pywb[0];
            room.WBM = pywb[1];
            try
            {
                BindEntity<HIS.Model.SS_ROOM>.CreateInstanceDAL(oleDb).Add(room);
                return true;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //判断房间名是否存在
        public bool IsExistRoom(string roomno)
        {
            string strWhere = Tables.ss_room.ROOMNO + oleDb.EuqalTo() + "'" + roomno + "'";
            return BindEntity<HIS.Model.SS_ROOM>.CreateInstanceDAL(oleDb).Exists(strWhere);
        }

        //判断该房间有没有已占用的台次
        public bool IsExistBed(int roomid)
        {
            string strWhere = Tables.ss_roombed.ROOMID + oleDb.EuqalTo() + roomid +oleDb.And()+Tables.ss_roombed.USE_FLAG+oleDb.EuqalTo()+1;
            return BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).Exists(strWhere);
        }
        //手术房间删除
        public bool DelRoom(int roomid)
        {
            try
            {
                oleDb.BeginTransaction();
                BindEntity<HIS.Model.SS_ROOM>.CreateInstanceDAL(oleDb).Delete(roomid);
                string strWhere = Tables.ss_roombed.ROOMID + oleDb.EuqalTo() + roomid + oleDb.And() + Tables.ss_roombed.USE_FLAG + oleDb.EuqalTo() + 0;
                BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).Delete(strWhere);
                oleDb.CommitTransaction();
                return true;
            }
            catch (System.Exception e)
            {
                oleDb.RollbackTransaction();
                throw new Exception(e.Message);
            }
        }
    }
}
