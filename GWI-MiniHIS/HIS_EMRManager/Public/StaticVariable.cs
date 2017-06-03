using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HIS_EMRManager.Public
{
    class StaticVariable
    {
        public static EMRRecordInfo CurrentRecordInfo = new EMRRecordInfo();

        public static float BodyTitleFontSize = 12f;
        public static int BodyTitleFontBold = 0;
        public static string BodyTitleFontName = "黑体";

        public static float BodyFontSize = 12f;
        public static int BodyFontBold = 0;
        public static string BodyFontName = "宋体";
    }
}
