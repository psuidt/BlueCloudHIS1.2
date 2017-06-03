using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HIS.Base_BLL.Enums;
using HIS.Base_BLL;

namespace HIS_BaseManager
{
    public interface IParameter
    {
        ParameterCatalog Catalog
        {
            get;
        }

        Parameters Parameters
        {
            get;
            set;
        }
    }
}
