using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.MediInsInterface_BLL.MediInsBLL.Dao.DataMatch.Daointerface
{
    public interface ICxHndatamatch : IbaseDao, Ibasematch
	{
        /// <summary>
        /// 获取公共卫生农合药品目录
        /// </summary>
        /// <returns></returns>
        DataTable CxHn_GetDrugList(bool b);
        /// <summary>
        /// 获取农合医疗服务项目
        /// </summary>
        /// <returns></returns>
        DataTable CxHn_GetTherapyList(bool b);
        /// <summary>
        /// 获取匹配关心
        /// </summary>
        /// <param name="IsNew">是否是新增的匹配关系,true:已上传 false:未上传</param>
        /// <param name="itemType">项目类型1-全部(不用);2-药品;3-项目</param>
        /// <returns></returns>
        DataTable CxHn_GetMatchInfo(bool IsNew, string itemType);
        /// <summary>
        /// 插入数据到药品目录表
        /// </summary>
        /// <param name="dt"></param>
        void CxHn_AddDrugContent(DataTable dt);

        void CxHn_AddItemContent(DataTable dt);
        /// <summary>
        /// 插入匹配数据
        /// </summary>
        /// <param name="fvs"></param>
        void CxHn_AddMatchData(string[] fvs);
        /// <summary>
        /// 更新匹配表数据
        /// </summary>
        /// <param name="dt"></param>
        void CxHn_UpdateMatchData(DataTable dt,bool isValid);
        /// <summary>
        /// 删除匹配信息
        /// </summary>
        /// <param name="hosp_code"></param>
        /// <param name="item_code"></param>
        /// <param name="serial_match"></param>
        /// <param name="match_type"></param>
        void CxHn_DeleteMatchData(string hosp_code, string item_code, string serial_match, string match_type);
	}
}
