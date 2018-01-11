using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB
{
    class BasicInfo
    {
        
        public enum LANGUAGE
        {
            CHINESE,
            ENGLISH,
            JAPAN
        }

        public  const int FRAME_ALARM_INFO_SIZE = 128 + 1;  //帧(报警数据)长度为1+128
        public  const int FRAME_ALARM_CHECKSUM_SIZE = 8; //帧(报警数据校验和)的长度
        public  const int FRAME_ALARM_COUNTS_SIZE = 6; //帧(报警总数)的长度

        public struct ALARM_MSG
        {
            public string No;
            public string dateTime;
            public Int32 alarmNo;
        }

        public struct REQUIRE_GET_ALARM_INFO
        {
            public Byte HEAD;
            public Byte LEN;
            public Byte CMDTYPE;
            public Byte FRAMID;
            public Byte DATA;
            public Byte CHECK_SUM1;
            public Byte CHECK_SUM2;
        }

        public enum STOP_BITES
        {
            NONE,
            ONE,
            ONEPOINTFIVE
        }
        public enum PARITY
        {
            NONE,
            ODD,
            EVEN,
            MARK,
            SPACE
        }
    }
}
