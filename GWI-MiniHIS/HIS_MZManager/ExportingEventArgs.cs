using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_MZManager
{
    /// <summary>
    /// Excel输出事件参数
    /// </summary>
    public class ExportingEventArgs : EventArgs
    {
        private int currentCount;
        private int totalCount;

        public int CurrentCount
        {
            get
            {
                return currentCount;
            }
            set
            {
                currentCount = value;
            }
        }

        public int TotalCount
        {
            get
            {
                return totalCount;
            }
            set
            {
                totalCount = value;
            }
        }
    }
}
