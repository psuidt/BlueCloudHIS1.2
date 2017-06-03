using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GWMHIS.BussinessLogicLayer.Classes;
using System.Data;

namespace HIS_MediConfirManager.Action
{
    public interface IFrmConfirView
    {          
        User currentUser { get; } 
        Deptment currentDept { get; }
        bool IsConfird { get; set; } //标志是确费的还是未确费的
        HIS.MedicalConfir_BLL.ConfirType ConfirType { get; set; } //类型。表示是住院还是门诊
        DateTime? GetBdate { get; } //已确费时获得开始日期
        DateTime? GetEdate { get; } //已确费的获得结束日期 
        void BindPatlist(); //绑定病人列表
        List<HIS.Model.MZ_PatList> mzPatlist { get; set; } //门诊病人列表
        List<HIS.Model.ZY_PatList> zyPatlist { get; set; } //住院病人列表
        DataTable BindItems { get; set; }

        List<HIS.Model.ZY_PatList> selectPatlist { get; set; } //选中的病人列表
        List<HIS.Model.MZ_PatList> selectMzPatlist { get; set; } //选中的门诊病人列表
    }
}
