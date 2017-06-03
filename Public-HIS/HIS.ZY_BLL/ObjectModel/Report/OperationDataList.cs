// File:    OperationDataList.cs
// Author:  Administrator
// Created: 2009年9月3日星期四 11:53:51
// Purpose: Definition of Class OperationDataList

using System;
using System.Collections.Generic;
using HIS.ZY_BLL.DataModel;
using System.Data;

namespace HIS.ZY_BLL.Report
{
   
    //zenghao [20100507.2.01]
    public class OperationDataList
    {
        public List<ZY_Account> zyAccountList;
        public List<ZY_ChargeList> zyChargeList;
        public List<ZY_CostMaster> zyCostmasterList;
        public List<ZY_CostOrder> zyCostorderList;
        public List<ZY_PresOrder> zyPresorderList;
        public List<ZY_PatList> zyPatList;
        public List<PatientInfo> patientinfoList;

        public DataTable PresDT;
    }
}
