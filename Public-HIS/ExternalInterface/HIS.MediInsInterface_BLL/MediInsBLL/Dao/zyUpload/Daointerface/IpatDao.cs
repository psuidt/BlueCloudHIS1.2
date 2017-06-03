using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.MediInsInterface_BLL.MediInsBLL.Dao.zyUpload.Daointerface
{
    public interface IpatDao:IbaseDao
    {
        void UpdatePatinfo(string patid, string patlistid, string patname, string grbm, string ywlb, string ywid, string id, string diseaseCode, string diseaseName);

        void SavePatYlzh(string patid, string ylzh);

        DataTable GetPresOrderNoPass(int patlistid);

        DataTable GetPresOrderPass(int patlistid);

        void UpdatePresOrderPassID(DataTable dt);

        decimal GetPatAllFee(int patlistid);

        void DeleteYwid(int patlistid);
    }
}
