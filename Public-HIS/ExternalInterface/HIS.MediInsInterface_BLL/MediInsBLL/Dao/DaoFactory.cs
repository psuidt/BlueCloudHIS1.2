using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.MediInsInterface_BLL.MediInsBLL.Dao
{

    public class DaoFactory
    {
        public static T GetObject<T>(Type t)
        {
            return (T)Activator.CreateInstance(t);
        }
    }
}
