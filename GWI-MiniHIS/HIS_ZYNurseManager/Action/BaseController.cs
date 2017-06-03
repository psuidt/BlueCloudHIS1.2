using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_ZYNurseManager.Action
{
    public class BaseController
    {
        private IView iView;
        public BaseController(IView _iView)
        {
            iView = _iView;
        }
    }
}
