using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace HIS.ZYDoc_BLL.NurseInterface
{
    public interface INurseBase
    {      
        int order_id { get; set; }
        /// <summary>
        /// 获得医嘱类别
        /// </summary>
        /// <returns></returns>
        OrderType GetOrderType(); //获得医嘱类别

        /// <summary>
        /// 获得药品、项目类型
        /// </summary>
       /// <returns></returns>
        ItemType GetItemType();　//获得药品、项目类型

        /// <summary>
        /// 获得医嘱状态
       /// </summary>
       /// <returns></returns>
       Status GetStatus();　　　//获得医嘱状态

       /// <summary>
       /// 获得项目ＩＤ  
       /// </summary>
       /// <returns></returns>
        int GetItemId();          //获得项目ＩＤ   

        /// <summary>
        /// 获得首次
        /// </summary>
        /// <returns></returns>
        int GetFirstTimes(); //获得首次

         /// <summary>
        /// 获得末次
        /// </summary>
        /// <returns></returns>
        int GetTeminalTimes();//获得末次
     

        /// <summary>
        /// 判断是否需要皮试
        /// </summary>
        /// <returns>true=需要 false=不需要</returns>
        bool IsNeedPs(); //判断是否需要皮试

        /// <summary>
        /// 插入皮试结果
        /// </summary>   
        /// <param name="ps_flag"></param>
        /// <returns></returns>
        bool SetPsResult(int ps_flag);//插入皮试结果
    }
}
