using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO.Ports;
//System.Runtime.InteropServices.
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;


namespace WEB
{
    public partial class Form1 : Form
    {
        private bool m_bButton_Open = false;
        private List<byte> m_buffer = new List<byte>();
        
        private Thread m_thread_showListview;       //线程，显示listview
        private Thread m_thread_showProgressBar;    //线程，显示进度条

        private int m_nIndex = 0;  //m_list_AlarmMsg中的索引
        private List<BasicInfo.ALARM_MSG> m_list_AlarmMsg = new List<BasicInfo.ALARM_MSG>(); //用于保存接收的数据

        private const int HEAD = 0;
        private const int LEN = 1;
        private const int CMD_TYPE = 2;
        private const int FRAME_ID = 3;

        private int m_alarm_count = 0;             //从信息帧中获得的报警总数
        private int m_current_alarmCount = 0;       //当前的报警数
        private UInt32 m_totalCheckSum = 0;          //用于校验数据包的大小
        private bool m_bPackageRcvCompleted = false; //接收完成标志位
        private bool m_bSerialPortIsWorking = false; //串口正在接收数据标志位，防止正在接收数据时重复点击
        private int m_RcvStates = -1;                //-1表示为开始，0表接收失败，1表示接收成功

        private string[] m_old_serialPortNames;

        private System.Windows.Forms.Timer m_timer = new System.Windows.Forms.Timer();
        private bool m_bCreateTestFile_forDebug = false;  //仅仅用于产生测试文档

        public Form1()
        {
            InitializeComponent();
        }


        
        private void InitListViewAlarm_Columns()
        {
            this.listView_alarm.Columns.Clear();
            this.listView_alarm.Columns.Add(LanguageMngr.No(), 120, HorizontalAlignment.Left);
            this.listView_alarm.Columns.Add(LanguageMngr.Date(), 200, HorizontalAlignment.Left);
            this.listView_alarm.Columns.Add(LanguageMngr.Alarm_Info(), 200, HorizontalAlignment.Left);
        }

        private void InitSerialCfg()
        {
            //串口号
            string[] ports = SerialPort.GetPortNames();
            if(ports.Length!=0)
            {
                Array.Sort(ports);
                m_old_serialPortNames = ports;
                this.comboBox_serial_port.Items.AddRange(ports);
                this.comboBox_serial_port.SelectedIndex = 0;
            }
            
            //波特率
            this.comboBox_serial_baud.Items.Add("115200");
            this.comboBox_serial_baud.SelectedIndex = 0;
            //数据位
            this.comboBox_serial_dataBits.Items.Add(this.serialPort1.DataBits);
            this.comboBox_serial_dataBits.SelectedIndex = 0;
            //停止位
            this.comboBox_serial_stopBits.Items.Add(this.serialPort1.StopBits);
            this.comboBox_serial_stopBits.SelectedIndex = 0;
            //校验位
            this.comboBox_serial_verifyBits.Items.Add(this.serialPort1.Parity);
            this.comboBox_serial_verifyBits.SelectedIndex = 0;
        }

        private void LoadPicture()
        {
            if(!m_bButton_Open)
            {
                this.pictureBox_serialPort.Load(Environment.CurrentDirectory + @"\" + "red.bmp");
            }
            else
            {
                this.pictureBox_serialPort.Load(Environment.CurrentDirectory + @"\" + "green.bmp");
            }
        }

        public struct TEST_FRAME_ALARMCOUNTS
        {
            public byte head;
            public byte len;
            public byte cmdtype;
            public byte frameID;
            public byte data1;
            public byte data2;
            public byte checksum1;
            public byte checksum2;
        }

        //单个报警信息
        public struct TEST_AlARMMSG
        {
            public byte time0;
            public byte time1;
            public byte time2;
            public byte time3;
            public byte data0;
            public byte data1;
            public byte data2;
            public byte data3;
        }

        //帧，共有信息
        public struct TEST_FRAME_COMMON
        {
            public byte head;
            public byte len;
            public byte cmdtype;
            public byte frameID;
        }

        //数据校验和帧
        public struct TEST_FARAM_VERIFY
        {
            public byte head;
            public byte len;
            public byte cmdtype;
            public byte frameID;
            public byte data0;
            public byte data1;
            public byte data2;
            public byte data3;
            public byte checksum1;
            public byte checksum2;
        }

        void CreateTestFile()
        {
            int frame_alarmInfoCount = 1000; //假设报警帧总数量为60000条
            int msgNumInAlarmFrame = 16;
            int alarmTotalNum = msgNumInAlarmFrame * frame_alarmInfoCount;   // 一个报警帧携带16个报警信息
            UInt32 packageCheckSum = 0;

            FileStream fs = new FileStream(@"C:\Users\Administrator\Desktop\temp\test.dat", FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs,Encoding.ASCII);

            DateTime tm_test = new DateTime(2017, 1, 1, 0, 0, 0);
            DateTime tm_begin = new DateTime(1970, 1, 1, 0, 0, 0);

            //产生报警总数帧
            #region
            TEST_FRAME_ALARMCOUNTS frame_alarmCount=new TEST_FRAME_ALARMCOUNTS();
            frame_alarmCount.head=0xFF;
            frame_alarmCount.len=0x06;
            frame_alarmCount.cmdtype=0x00;
            frame_alarmCount.frameID=0x24;
            frame_alarmCount.data1=Convert.ToByte(alarmTotalNum/256);      //报警总数1
            frame_alarmCount.data2=Convert.ToByte(alarmTotalNum%256);      //报警总数2
            byte[] buffer=GetData(frame_alarmCount);
            int sum=0;
            for(int i=1;i<Convert.ToInt32(frame_alarmCount.len);i++)
            {
                sum += Convert.ToInt32(buffer[i]);
            }
            buffer[Convert.ToInt32(frame_alarmCount.len)] = Convert.ToByte(sum / 256);
            buffer[Convert.ToInt32(frame_alarmCount.len)+1] = Convert.ToByte(sum % 256);
            sum += Convert.ToByte(sum / 256) + Convert.ToByte(sum % 256);

            bw.Write(buffer,0,Marshal.SizeOf(frame_alarmCount));
            packageCheckSum = (UInt32)sum;
            #endregion

            //产生报警数据帧，一共alarmTotalNum条
            #region
            Random rd = new Random();
            sum = 0;
            for (int i = 0; i < frame_alarmInfoCount; i++)
            {
                //产生报警信息帧
                TEST_FRAME_COMMON frame_common = new TEST_FRAME_COMMON();
                frame_common.head = 0xFF;
                frame_common.len = 0x85;  //可以产生8个报警信息,假设是满载
                frame_common.cmdtype = 0x00;
                frame_common.frameID = 0x21;
                //sum += frame_common.head + frame_common.len + frame_common.cmdtype + frame_common.frameID;
                sum +=  frame_common.len + frame_common.cmdtype + frame_common.frameID;

                //MessageBox.Show(sum.ToString());
                var bf_frameCommon = GetData(frame_common);
                bw.Write(bf_frameCommon, 0, Marshal.SizeOf(frame_common));  //写入公共信息

                bw.Write(Convert.ToByte(msgNumInAlarmFrame));  //写入信息条数,一个帧带16个报警信息
                sum += msgNumInAlarmFrame;

                for (int j = 0; j < msgNumInAlarmFrame; j++)  //满载,16个
                {
                    TEST_AlARMMSG msg = new TEST_AlARMMSG();
                    tm_test = tm_test.AddMinutes(1);
                    var sec = Convert.ToUInt32((tm_test - tm_begin).TotalSeconds); //获取从1970.1.1到现在的秒数

                    msg.time0 = Convert.ToByte(sec % 256);
                    msg.time1 = Convert.ToByte((sec % (256 * 256)) / 256);
                    msg.time2 = Convert.ToByte((sec / 256 / 256) % 256);
                    msg.time3 = Convert.ToByte(sec / 256 / 256 / 256);
                    msg.data0 = Convert.ToByte(rd.Next(1, 5));
                    msg.data1 = 0x00;
                    msg.data2 = 0x00;
                    msg.data3 = 0x00;

                    sum += msg.time0 + msg.time1 + msg.time2 + msg.time3 + msg.data0 + msg.data1 + msg.data2 + msg.data3;

                    byte[] bf_mgs = GetData(msg);
                    bw.Write(bf_mgs, 0, Marshal.SizeOf(msg));
                }
                
                bw.Write(Convert.ToByte(sum/256));  //写入checksum
                bw.Write(Convert.ToByte(sum%256));
                sum += Convert.ToByte(sum / 256) + Convert.ToByte(sum % 256);
                packageCheckSum += (UInt32)sum;
                sum = 0;
            }

            #endregion

            //产生数据校验和帧，上位机已经改动了，不按这个做；目前按接收的报警条数来计算
            #region
            sum = 0;
            TEST_FARAM_VERIFY frame_verify = new TEST_FARAM_VERIFY();
            frame_verify.head = 0xFF;
            frame_verify.len = 0x08;
            frame_verify.cmdtype = 0x00;
            frame_verify.frameID = 0x22;
            frame_verify.data0 = Convert.ToByte(packageCheckSum % 256);
            frame_verify.data1 = Convert.ToByte((packageCheckSum % (256 * 256)) / 256);
            frame_verify.data2 = Convert.ToByte((packageCheckSum / 256 / 256) % 256);
            frame_verify.data3 = Convert.ToByte(packageCheckSum / 256 / 256 / 256);
            var bf_verify = GetData(frame_verify);
            sum += frame_verify.len + frame_verify.cmdtype + frame_verify.frameID + frame_verify.data0 + frame_verify.data1 + frame_verify.data2 + frame_verify.data3;
           
            bf_verify[Convert.ToInt32(frame_verify.len)] = Convert.ToByte(sum / 256);
            bf_verify[Convert.ToInt32(frame_verify.len) + 1] = Convert.ToByte(sum % 256);
            bw.Write(bf_verify, 0, Marshal.SizeOf(frame_verify));
            #endregion
            

            bw.Close();
            fs.Close();
            //MessageBox.Show(packageCheckSum.ToString());
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.label1.Text = "0/0";
            this.label1.Visible = false;
            //隐藏删除报警button
            this.button_deleteAlarmData.Visible = false;
            //初始化报警列表头
            InitListViewAlarm_Columns();
            //初始化串口配置
            InitSerialCfg();
            //初始化图片
            LoadPicture();

            //m_bButton_Open = false;

            //debug
            if(m_bCreateTestFile_forDebug)
            {
                CreateTestFile();
            }
        }

        private void button_open_serial_Click(object sender, EventArgs e)
        {
            m_bButton_Open = !m_bButton_Open;
            
            if (m_bButton_Open)
            {
                try
                {
                    this.serialPort1.Open();
                }
                catch(Exception ex)
                {
                    m_bButton_Open = false;
                    MessageBox.Show(ex.Message);
                    return;
                }
                this.button_open_serial.Text = LanguageMngr.close_serial_port();
                
                m_bButton_Open = true;
                this.comboBox_serial_port.Enabled = false;
                LoadPicture();

                InitMembers();
            }
            else
            {
                this.button_open_serial.Text = LanguageMngr.open_serial_port();
                this.serialPort1.Close();
                m_bButton_Open = false;
                this.comboBox_serial_port.Enabled = true;
                LoadPicture();
                this.button_clearListview.Enabled = true;
                this.button_exportListView.Enabled = true;

                InitMembers();
            }
            
        }

        private void button_importAlarmData_Click(object sender, EventArgs e)
        {

            if (m_RcvStates == 0)
            {
                InitMembers();
                //return;
            }
            if (!this.serialPort1.IsOpen)
            {
                MessageBox.Show(LanguageMngr.pls_open_serial_port_first());
                return;
            }
            if (m_bPackageRcvCompleted && m_RcvStates == 1)
            {
                MessageBox.Show(LanguageMngr.data_already_exported_clear_then_re_import());
                return;
            }
            
            if (m_bSerialPortIsWorking)
            {
                //取消定时器，这个不需要了
                m_timer.Interval = 200000;  //设置200s的无响应时间
                m_timer.Tick += timer_Tick;
                //m_timer.Start();    //不需要定时器

                //MessageBox.Show(LanguageMngr.data_is_importing_do_not_click_again());
                return;
            }
            this.button_clearListview.Enabled = false;
            this.button_exportListView.Enabled = false;

            var require = new BasicInfo.REQUIRE_GET_ALARM_INFO();
            require.HEAD = 0xFF; //头
            require.LEN = 0x05;
            require.CMDTYPE = 0x01;  //PC端命令
            require.FRAMID = 0x20;
            require.DATA = 0x01;     //发送TRUE
            require.CHECK_SUM1 = 0x00;  //初始化checksum
            require.CHECK_SUM2 = 0x00;
            byte[] buffer = GetData(require);

            int sum = 0;
            for (int i = 1; i < Convert.ToInt32(require.LEN); i++)
            {
                sum += buffer[i];
            }
            buffer[Convert.ToInt32(require.LEN)] = Convert.ToByte(sum / 256); //高位
            buffer[Convert.ToInt32(require.LEN)+1] = Convert.ToByte(sum % 256); //低位

            //串口下发命令到下位机
            this.serialPort1.Write(buffer, 0, Marshal.SizeOf(require));

            //开后台线程来显示数据到listview控件
            m_thread_showListview = new Thread(new ThreadStart(ShowListView));
            m_thread_showListview.IsBackground = true;
            m_thread_showListview.Start();

            //显示进度条
            m_thread_showProgressBar = new Thread(new ThreadStart(ShowProgressBar));
            m_thread_showProgressBar.IsBackground = true;
            m_thread_showProgressBar.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            if(m_timer!=null)
            {
                m_timer.Stop();
                MessageBox.Show(LanguageMngr.recv_data_time_out_close_serialport_then_open());
            }    
        }
        
        private void ShowProgressBar()
        {
            while(true)
            {
                if(m_RcvStates==1)
                {
                    this.progressBar1.Maximum = m_alarm_count;
                    this.progressBar1.Value = m_current_alarmCount;
                    this.label1.Text = m_current_alarmCount.ToString() + @"/" + m_alarm_count.ToString();
                }
                //说明：m_alarm_count和m_current_alarmCount已经更新到最新数据，
                //但加了Thread.Sleep(50)会导致m_bSerialPortIsWorking变成false后没法执行下面的代码
                //进度条没办法更新到100%,所以加了上面的代码if(m_RcvStates==1)
                //如果去掉Thread.Sleep(50)会导致cpu占有率非常高
                if (m_bSerialPortIsWorking)  
                {
                    if (this.progressBar1!=null)
                    {
                        this.progressBar1.Maximum = m_alarm_count;
                        this.progressBar1.Value = m_current_alarmCount;
                    }
                    if(this.label1!=null)
                    {
                        this.label1.Text = m_current_alarmCount.ToString() + @"/" + m_alarm_count.ToString();
                    }    
                }
                Thread.Sleep(50);
            }    
        }

        private void ShowListView()
        {
            while(true)
            {
                if (m_bPackageRcvCompleted && m_RcvStates==1)
                    break;
                Thread.Sleep(50);
            }
            //接收完成了才显示
            this.listView_alarm.Items.Clear();
            this.listView_alarm.BeginUpdate();
            foreach (var msg in m_list_AlarmMsg)
            {
                ListViewItem lvi = new ListViewItem();

                lvi.Text = msg.No;
                lvi.SubItems.Add(msg.dateTime);
                lvi.SubItems.Add(GetAlarmStrByType(msg.alarmNo));
                this.listView_alarm.Items.Add(lvi);
                
                //this.progressBar1.Value += 1;
            }
            this.listView_alarm.EndUpdate();
        }

        public static byte[] GetData(object obj)
        {
            int size = Marshal.SizeOf(obj.GetType());
            byte[] data = new byte[size];
            IntPtr ptr = Marshal.AllocHGlobal(size);

            try
            {
                Marshal.StructureToPtr(obj, ptr, true);
                Marshal.Copy(ptr, data, 0, size);
                return data;
            }
            finally
            {
                Marshal.FreeHGlobal(ptr);
            }
        }

        private string GetAlarmStrByType(int num)
        {
            string str = "";
            switch(num)
            {
                case 1:
                    str=LanguageMngr.system_error();
                    break;
                case 2:
                    str=LanguageMngr.no_air();
                    break;
                case 3:
                    str=LanguageMngr.low_oxy();
                    break;
                case 4:
                    str=LanguageMngr.low_battery();
                    break;
                case 5:
                    str=LanguageMngr.high_oxy();
                    break;
                default:
                    break;
            }
            return str;
        }

        private void GetMsgToList()
        {
            int alarmNum_in_Frame = m_buffer[FRAME_ID + 1];//获取一帧中的报警条数
            //MessageBox.Show(alarmNum_in_Frame.ToString());
            for(int i=0;i<alarmNum_in_Frame;i++)
            {
                m_nIndex++;
                UInt32 nDate = 256 * 256 * 256 * Convert.ToUInt32(m_buffer[5 + 8 * i + 3])
                            + 256 * 256 * Convert.ToUInt32(m_buffer[5 + 8 * i + 2])
                            + 256 * Convert.ToUInt32(m_buffer[5 + 8 * i + 1])
                            + Convert.ToUInt32(m_buffer[5+8*i+0]);
                DateTime tmp = new DateTime(1970, 1, 1, 0, 0, 0);
                DateTime tmFromMsg = tmp.AddSeconds(nDate); //转换成日期
                //MessageBox.Show(tmFromMsg.ToString());
                BasicInfo.ALARM_MSG msg=new BasicInfo.ALARM_MSG();
                msg.No=m_nIndex.ToString();
                msg.dateTime=tmFromMsg.ToString("yyyy-MM-dd HH:mm:ss");
                //msg.alarmStr=GetAlarmStrByType(Convert.ToInt32(m_buffer[5 + 8 * i + 7]));
                msg.alarmNo = Convert.ToInt32(m_buffer[5 + 8 * i + 4]);
                //MessageBox.Show(msg.alarmStr);
                //先将信息挂入到链表中
                m_list_AlarmMsg.Add(msg);
                m_current_alarmCount=m_nIndex; //记录当前报警数
                //MessageBox.Show(m_list_AlarmMsg.Count.ToString());
            }
            //MessageBox.Show(m_current_alarmCount.ToString());
        }
        private void VerifyTotalCheckSum()
        {
            //屏蔽
            #region
            //UInt32 sum = 256 * 256 * 256 * Convert.ToUInt32(m_buffer[7])
            //                + 256 * 256 * Convert.ToUInt32(m_buffer[6])
            //                + 256 * Convert.ToUInt32(m_buffer[5])
            //                + Convert.ToUInt32(m_buffer[4]);
            ////MessageBox.Show(m_totalCheckSum.ToString()+"......."+sum.ToString());
            //byte data_3 = Convert.ToByte(m_totalCheckSum / 256 / 256 / 256);
            //byte data_2 = Convert.ToByte(m_totalCheckSum / 256 / 256 % 256);
            //byte data_1 = Convert.ToByte(m_totalCheckSum % (256 * 256) / 256);
            //byte data_0 = Convert.ToByte(m_totalCheckSum % 256);
            //data_3 &= 0xee;
            //data_2 &= 0xee;
            //data_1 &= 0xee;
            //data_0 &= 0xee;

            //m_totalCheckSum = 256 * 256 * 256 * Convert.ToUInt32(data_3) + 256 * 256 * Convert.ToUInt32(data_2)
            //                + 256 * Convert.ToUInt32(data_1) + Convert.ToUInt32(data_0);
            ////MessageBox.Show(m_totalCheckSum.ToString()+"......."+sum.ToString());
            ////m_totalCheckSum = 9924; //debug
            #endregion

            //直接校验接收msg的条数，不按校验和来校验了
            if (m_current_alarmCount == m_alarm_count)
            //if(sum==m_totalCheckSum)
            {
                m_RcvStates = 1;
                m_bSerialPortIsWorking = false;
                m_bPackageRcvCompleted = true;
                //MessageBox.Show("ok");
                this.button_clearListview.Enabled = true;
                this.button_exportListView.Enabled = true;
            }
            else
            {
                //初始化资源
                m_RcvStates = 0;
                this.m_bSerialPortIsWorking = false;
                this.progressBar1.Value = 0;
                //InitMembers();
                MessageBox.Show(LanguageMngr.data_import_failed());
            }
            
        }
        
        //解析收到的帧，按照帧类型来解析
        private void ParseAlarmInfo()
        {
            if(m_buffer[CMD_TYPE] != 0x00)
            {
                return;
            }
            
            for(int i=0;i< Convert.ToInt32(m_buffer[LEN])+2;i++)
            {
                if (m_buffer[FRAME_ID] != 0x22 && m_buffer[FRAME_ID] != 0x24)
                {
                    m_totalCheckSum += Convert.ToUInt32(m_buffer[i]);  //数据包的CheckSum  
                }  
            }
            //MessageBox.Show(m_totalCheckSum.ToString());
            //MessageBox.Show("m_totalCheckSum:"+m_totalCheckSum.ToString());
            //根据帧类型来判断
            switch (m_buffer[FRAME_ID])
            {
                case 0x24:  //如果是帧(报警总个数)
                    m_alarm_count = 256 * Convert.ToInt32(m_buffer[4]) + Convert.ToInt32(m_buffer[5]); //获取报警总个数
                    //MessageBox.Show("收到报警总数:" + m_alarm_count.ToString());
                    break;
                case 0x21:  //如果是报警数据帧
                    //MessageBox.Show("ddd");
                    GetMsgToList();
                    break;
                case 0x22: //如果是帧(报警数据校验和)
                    VerifyTotalCheckSum();
                    //m_bPackageRcvCompleted = true;
                    //m_RcvStates = 1;
                    break;
                default:
                    m_RcvStates = 0;
                    break;
            }
        }

        private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var nPendingRead = this.serialPort1.BytesToRead; 
            byte[] tmp = new byte[nPendingRead];
            this.serialPort1.Read(tmp, 0, nPendingRead);
            
            lock(m_buffer)
            {
                m_buffer.AddRange(tmp);
                #region
                while (m_buffer.Count >= 4)
                {
                    m_bSerialPortIsWorking = true;
                    if (m_buffer[HEAD] == 0xFF) //帧头
                    {
                        int len = Convert.ToInt32(m_buffer[LEN]); // 获取帧长度(不包含checksum1和checksum2)
                        if (m_buffer.Count < len + 2)  //数据没有接收完全，继续接收
                        {
                            break;
                        }
                        int checksum = 256 * Convert.ToInt32(m_buffer[len]) + Convert.ToInt32(m_buffer[len + 1]);
                        int sum = 0;
                        for (int i = 1; i < len; i++) //校验和不包含包头
                        {
                            sum += Convert.ToInt32(m_buffer[i]);
                        }
                        //MessageBox.Show(sum.ToString());
                        if (checksum == sum)
                        {
                            //解析数据，加入到链表中
                            ParseAlarmInfo();
                        }
                        else
                        {
                            //校验之后发现数据不对,清除该帧数据
                            m_buffer.RemoveRange(0, len + 2);
                            continue;
                        }
                        //if (m_RcvStates == 0)
                        //{
                        //    InitMembers();
                        //    return;
                        //}
                        m_buffer.RemoveRange(0, len + 2);  
                    }
                    else
                    {
                        m_buffer.RemoveAt(0); //清除帧头
                        //m_RcvStates = 0;
                        //InitMembers();
                    }
                }
                #endregion
            }
        }

        private void groupBox4_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(this.BackColor);
        }

        private void InitMembers()
        {
            m_alarm_count = 0;
            m_current_alarmCount = 0;
            m_totalCheckSum = 0;
            this.m_nIndex = 0;
            m_bSerialPortIsWorking = false;
            m_bPackageRcvCompleted = false;

            
            if(this.m_buffer.Count!=0)
            {
                this.m_buffer.Clear();
            }
            this.listView_alarm.Items.Clear();
            this.progressBar1.Value = 0;
            //m_list_AlarmMsg.Clear();
            if (m_list_AlarmMsg.Count != 0)
            {
                m_list_AlarmMsg.Clear();
            }
        }

        private void button_clearListview_Click(object sender, EventArgs e)
        {
            InitMembers();  
        }

        private void button_exportListView_Click(object sender, EventArgs e)
        {
            if(m_list_AlarmMsg==null||m_list_AlarmMsg.Count==0)
            {
                MessageBox.Show(LanguageMngr.no_data());
                return;
            }
            if(this.folderBrowserDialog1.ShowDialog()==DialogResult.OK)
            {
                var filePath = this.folderBrowserDialog1.SelectedPath;
                FileStream fs = new FileStream(filePath + @"\alarm.csv", FileMode.Create);
                StreamWriter sw = new StreamWriter(fs, Encoding.Default);
                sw.WriteLine(LanguageMngr.No() + "," + LanguageMngr.Date() + "," + LanguageMngr.Alarm_Info());
                foreach(var msg in m_list_AlarmMsg)
                {
                    sw.WriteLine(msg.No + "," + msg.dateTime + "," + GetAlarmStrByType(msg.alarmNo));
                    MessageBox.Show(msg.alarmNo.ToString());
                }

                sw.Close();
                fs.Close();
                MessageBox.Show(LanguageMngr.export_data_complete());
            }
            else
            {
                return;
            }
        }

        private void comboBox_serial_port_SelectedValueChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.comboBox_serial_port.SelectedText);
            //MessageBox.Show(this.comboBox_serial_port.Text);
            if (this.comboBox_serial_port.Text!="")
            {
                if (this.serialPort1.IsOpen)
                {
                    //MessageBox.Show("请先关闭串口")
                    return;
                }
                this.serialPort1.PortName = this.comboBox_serial_port.Text;
            }
            
        }

        private void comboBox_serial_port_SelectionChangeCommitted(object sender, EventArgs e)
        {
            //MessageBox.Show(this.comboBox_serial_port.SelectedText);
            
        }

        private void comboBox_serial_port_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(this.comboBox_serial_port.Text);
        }
        private void InitApplables()
        {
            this.Text = LanguageMngr.elec_air_oxy_mixer_alarm_management_software();

            语言选择ToolStripMenuItem.Text = LanguageMngr.lang_select();
            中文ToolStripMenuItem1.Text = LanguageMngr.chinese();
            英文ToolStripMenuItem.Text = LanguageMngr.english();
            帮助ToolStripMenuItem.Text = LanguageMngr.help();
            软件版本ToolStripMenuItem.Text = LanguageMngr.software_ver();
            this.groupBox_serialPort_set.Text = LanguageMngr.serial_port_set();
            this.label_serialPort_name.Text = LanguageMngr.port_name();
            this.label_serialPort_baud.Text = LanguageMngr.baud();
            this.label_serialPort_dataBits.Text = LanguageMngr.dataBits();
            this.label_serialPort_stopBit.Text = LanguageMngr.stopBit();
            this.label_serialPort_parity.Text = LanguageMngr.parity();
            this.button_open_serial.Text = LanguageMngr.open_serial_port();
            this.groupBox_equip_Operation.Text = LanguageMngr.equip_operation();
            this.button_importAlarmData.Text = LanguageMngr.import_alarm();
            this.button_deleteAlarmData.Text = LanguageMngr.delete_alarm();
            this.button_clearListview.Text = LanguageMngr.clear();
            this.button_exportListView.Text = LanguageMngr.export();

            InitMembers();
            InitListViewAlarm_Columns();
        }
        private void 中文ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (LanguageMngr.m_lang == BasicInfo.LANGUAGE.CHINESE)
            {
                return;
            }
            if((m_list_AlarmMsg.Count!=0)&&!m_bPackageRcvCompleted)
            {
                MessageBox.Show(LanguageMngr.pls_do_not_switch_language());
                return;
            }
            LanguageMngr.m_lang = BasicInfo.LANGUAGE.CHINESE;
            InitApplables();

            
        }

        private void 英文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (LanguageMngr.m_lang == BasicInfo.LANGUAGE.ENGLISH)
            {
                return;
            }
            if ((m_list_AlarmMsg.Count != 0) && !m_bPackageRcvCompleted)
            {
                MessageBox.Show(LanguageMngr.pls_do_not_switch_language());
                return;
            }
            LanguageMngr.m_lang = BasicInfo.LANGUAGE.ENGLISH;
            InitApplables();
            
        }

        private void 软件版本ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(LanguageMngr.m_lang==BasicInfo.LANGUAGE.CHINESE)
            {
                Form_AboutUs_Chinese fm = new Form_AboutUs_Chinese();
                fm.ShowDialog();
            }
            else if(LanguageMngr.m_lang==BasicInfo.LANGUAGE.ENGLISH)
            {
                Form_AboutUs_English fm = new Form_AboutUs_English();
                fm.ShowDialog();
            }
            else
            {
                //其他语言
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            string[] names = SerialPort.GetPortNames();
            if(names.Length==0)
            {
                return;
            }
            Array.Sort(names);
            int nCount = 0;
            if(names.Length==m_old_serialPortNames.Length) 
            {
                for(int i=0;i<names.Length;i++)
                {
                    if(names[i]==m_old_serialPortNames[i])
                    {
                        nCount++;
                    }
                }  
                if(nCount==names.Length)  //如果每个都相同
                {
                    return;
                }
                else
                {
                    m_old_serialPortNames = names;  //如果不匹配，将新的值赋给旧的值
                }
            }
            else
            {
                m_old_serialPortNames = names;
            }
            
            this.comboBox_serial_port.Items.Clear();
            this.comboBox_serial_port.Items.AddRange(names);
            this.comboBox_serial_port.SelectedIndex = 0;
           
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(m_thread_showListview!=null)
            {
                m_thread_showListview.Abort();
            }
            if(m_thread_showProgressBar!=null)
            {
                m_thread_showProgressBar.Abort();
            }
            InitMembers();
        }

    }
}
