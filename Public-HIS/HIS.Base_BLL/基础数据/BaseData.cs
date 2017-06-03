using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS.Base_BLL
{
    /// <summary>
    /// 基础数据集
    /// </summary>
    public class BaseData
    {
        private static DataCollection collection;

        public BaseData()
        {
            collection = new DataCollection();
        }
        /// <summary>
        /// 数据集
        /// </summary>
        public static DataCollection Collection
        {
            get
            {
                if ( collection == null )
                    collection = new DataCollection();
                return collection;
            }
        }
        /// <summary>
        /// 已加载的数据个数
        /// </summary>
        public static int LoadedDataCount
        {
            get
            {
                if ( collection == null )
                    return 0;
                else
                    return collection.Count;
            }

        }
        /// <summary>
        /// 重新加载数据
        /// </summary>
        public static void ReLoad()
        {
            foreach ( object obj in Enum.GetValues( typeof( DataEnum ) ) )
                collection.ReLoad( (DataEnum)obj );
        }
        /// <summary>
        /// 重新加载指定的数据
        /// </summary>
        /// <param name="dataEnum"></param>
        public static void ReLoad( DataEnum dataEnum )
        {
            collection.ReLoad( dataEnum );
        }

    }
}
