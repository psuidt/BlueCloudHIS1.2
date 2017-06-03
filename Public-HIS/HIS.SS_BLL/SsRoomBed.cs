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
    public class SsRoomBed : BaseBLL
    {
        //获得所有台次
        public List<HIS.Model.SS_ROOMBED> GetBeds(int roomid)
        {
            string strWhere = Tables.ss_roombed.ROOMID + oleDb.EuqalTo() + roomid;
            return BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).GetListArray(strWhere);
        }
        //增加台次
        public bool  AddBeds(HIS.Model.SS_ROOM room,string tcno)
        {
            try
            {               
                HIS.Model.SS_ROOMBED bed = new HIS.Model.SS_ROOMBED();
                bed.ROOMID = room.ROOMID;
                bed.USE_FLAG = 0;
                bed.NAME = room.ROOMNO+"间" + tcno + "台";
                string[] pywb = GWMHIS.BussinessLogicLayer.Classes.PublicStaticFun.GetPyWbCode(bed.NAME);
                bed.PYM = pywb[0];
                bed.WBM = pywb[1];
                BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).Add(bed);
                return true;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        //删除台次
        public bool DelBeds(HIS.Model.SS_ROOMBED bed)
        {
            try
            {
                string strWhere = Tables.ss_roombed.USE_FLAG + oleDb.EuqalTo() + 0+oleDb.And()+Tables.ss_roombed.ID+oleDb.EuqalTo()+bed.ID;
                BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).Delete(strWhere);
                return true;
            }
            catch (System.Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        //判断台次名是否存在
        public bool IsExistBed(string bed,HIS.Model.SS_ROOM room)
        {
            string bedName = room.ROOMNO + "间" + bed  + "台";
            string strWhere = Tables.ss_roombed.NAME + oleDb.EuqalTo() + "'" + bedName + "'";
            return BindEntity<HIS.Model.SS_ROOMBED>.CreateInstanceDAL(oleDb).Exists(strWhere);
        }
    }
}
