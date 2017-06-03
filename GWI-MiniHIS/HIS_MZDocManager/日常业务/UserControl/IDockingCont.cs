using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_MZDocManager
{
    interface IDockingcontrol
    {
        event EventHandler SelectDataList;

        void RefreshData();
    }
}
