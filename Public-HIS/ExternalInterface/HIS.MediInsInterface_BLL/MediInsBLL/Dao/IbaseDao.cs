using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.SYSTEM.DatabaseAccessLayer;

namespace HIS.MediInsInterface_BLL.MediInsBLL.Dao
{
    public interface IbaseDao
    {
        RelationalDatabase oleDb { get; set; }
    }
}
