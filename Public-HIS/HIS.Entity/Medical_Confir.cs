using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Model
{
    public class Medical_Confir
    {
        private int _confirid;
        private int _presorderid;
        private int _patlistid;
        private int _confirdoc;
        private DateTime _confirdate;
        private int _confirdept;
        private int _mark_flag;
        private int _cancel_flag;
        private int _canceldoc;
        private DateTime _canceldate;
        public int ConfirId
        {
            get
            {
                return _confirid;
            }
            set
            {
                _confirid = value;
            }
        }

        public int PresOrderId
        {
            get
            {
                return _presorderid;
            }
            set
            {
                _presorderid = value;
            }
        }

        public int PatListId
        {
            get
            {
                return _patlistid;
            }
            set
            {
                _patlistid = value;
            }
        }
        public int ConfirDoc
        {
            get
            {
                return _confirdoc;
            }
            set
            {
                _confirdoc = value;
            }
        }

        public DateTime ConfirDate
        {
            get
            {
                return _confirdate;
            }
            set
            {
                _confirdate = value;
            }
        }

        public int ConfirDept
        {
            get
            {
                return _confirdept;
            }
            set
            {
                _confirdept = value;
            }

        }
        public int Mark_Flag
        {
            get
            {
                return _mark_flag;
            }
            set
            {
                _mark_flag = value;
            }
        }

        public int Cancel_Flag
        {
            get
            {
                return _cancel_flag;
            }
            set
            {
                _cancel_flag = value;
            }
        }

        public int CancelDoc
        {
            get
            {
                return _canceldoc;
            }
            set
            {
                _canceldoc = value;
            }
        }

        public DateTime CancelDate
        {
            get
            {
                return _canceldate;
            }
            set
            {
                _canceldate = value;
            }
        }
      
    }
}
