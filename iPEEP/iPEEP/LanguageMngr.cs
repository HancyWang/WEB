using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WEB
{
    class LanguageMngr
    {
        //public static bool m_bChinese = true;
        //public static bool m_bEnglish = false;
        public static BasicInfo.LANGUAGE m_lang = BasicInfo.LANGUAGE.CHINESE;
        public static string open_serial_port()
        {
            if (m_lang==BasicInfo.LANGUAGE.CHINESE)
            {
                return "开启串口";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Open serial port";
            }
            else
            {
                return "";
            }
        }
        //序号
        public static string No()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "序号";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "No.";
            }
            else
            {
                return "";
            }
        }
        //时间
        public static string Date()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "时间";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Date";
            }
            else
            {
                return "";
            }
        }
        //报警信息
        public static string Alarm_Info()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "报警信息";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Alarm Info";
            }
            else
            {
                return "";
            }
        }
        //请先打开串口
        public static string pls_open_serial_port_first()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "请先打开串口";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Please open serial port first!";
            }
            else
            {
                return "";
            }
        }
        //关闭串口
        public static string close_serial_port()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "关闭串口";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Close serial port";
            }
            else
            {
                return "";
            }
        }

        public static string lang_select()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "语言选择";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Language Select";
            }
            else
            {
                return "";
            }
        }
        public static string chinese()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "中文";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Chinese";
            }
            else
            {
                return "";
            }
        }
        public static string english()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "英文";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "English";
            }
            else
            {
                return "";
            }
        }
        public static string help()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "帮助";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Help";
            }
            else
            {
                return "";
            }
        }

        public static string software_ver()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "软件版本";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Software Ver";
            }
            else
            {
                return "";
            }
        }

        public static string serial_port_set()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "串口设置";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Serial Port Set";
            }
            else
            {
                return "";
            }
        }

        public static string port_name()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "串口号：";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Port Name：";
            }
            else
            {
                return "";
            }
        }

        public static string baud()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "波特率：";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Baud：";
            }
            else
            {
                return "";
            }
        }

        public static string dataBits()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "数据位：";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "DateBits：";
            }
            else
            {
                return "";
            }
        }

        public static string stopBit()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "停止位：";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Stopbit：";
            }
            else
            {
                return "";
            }
        }

        public static string parity()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "校验：";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Parity：";
            }
            else
            {
                return "";
            }
        }

        public static string equip_operation()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "设备操作";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Equipment Operate";
            }
            else
            {
                return "";
            }
        }

        public static string import_alarm()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "导入报警";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Import Alarm Info";
            }
            else
            {
                return "";
            }
        }

        public static string delete_alarm()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "删除报警";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Delete Alarm Info";
            }
            else
            {
                return "";
            }
        }

        public static string clear()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "清除";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Clear";
            }
            else
            {
                return "";
            }
        }

        public static string export()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "导出";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Export";
            }
            else
            {
                return "";
            }
        }
        //无数据
        public static string no_data()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "无数据！";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "No data!";
            }
            else
            {
                return "";
            }
        }
        //数据导出完成
        public static string export_data_complete()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "数据导出完成！";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Export data successful!";
            }
            else
            {
                return "";
            }
        }
        //数据已经导入成功，如果想重新导入，请先清除数据
        public static string data_already_exported_clear_then_re_import()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "数据已经导入成功，如果想重新导入，请先清除数据！";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Data already import successfully,if you wanna re-import,please click clear button first!";
            }
            else
            {
                return "";
            }
        }
        //数据正在导入中，请勿重复点击按钮
        public static string data_is_importing_do_not_click_again()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "数据正在导入中，请勿重复点击按钮！";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Data is importing,please do not click the button twice or more!";
            }
            else
            {
                return "";
            }
        }
        //数据导入失败
        public static string data_import_failed()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "数据导入失败！";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Failed to import data!";
            }
            else
            {
                return "";
            }
        }
        //系统错误
        public static string system_error()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "系统错误";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "System error";
            }
            else
            {
                return "";
            }
        }

        public static string no_air()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "无气体";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "No air";
            }
            else
            {
                return "";
            }
        }

        public static string low_oxy()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "低氧";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Low oxygen";
            }
            else
            {
                return "";
            }
        }

        public static string high_oxy()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "高氧";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "High oxygen";
            }
            else
            {
                return "";
            }
        }


        public static string low_battery()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "低电池电量";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Low battery";
            }
            else
            {
                return "";
            }
        }
        //数据接收中，请勿切换语言
        public static string pls_do_not_switch_language()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "数据接收中，请勿切换语言！";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Data is receiving,please do not switch language!";
            }
            else
            {
                return "";
            }
        }

        public static string elec_air_oxy_mixer_alarm_management_software()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "电子空氧混合器报警管理软件";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Electronic air oxygen mixer alarm management software";
            }
            else
            {
                return "";
            }
        }
        //接收数据失败，请关闭串口再打开
        public static string recv_data_time_out_close_serialport_then_open()
        {
            if (m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return "接收数据失败，请关闭串口再打开！";
            }
            else if (m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return "Failed to receive data,please re-open serial port!";
            }
            else
            {
                return "";
            }
        }
    }
}
