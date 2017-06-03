using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS_MediInsInterface.Action
{
    public interface IpatInfo
    {
        DataTable dgvpatInfo{set;}
        int currentRow { get; }
        DataTable cbywlb {set; }
        string ywlb { get; }
        string ywid { set; }

        string ylzh { get; set; }
        string DiseaseCode { get; set; }
        string DiseaseName { get; set; }

        void Initialize(DataSet _dataSet);
    }
}
