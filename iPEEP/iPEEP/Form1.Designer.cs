namespace WEB
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox_serialPort_set = new System.Windows.Forms.GroupBox();
            this.pictureBox_serialPort = new System.Windows.Forms.PictureBox();
            this.button_open_serial = new System.Windows.Forms.Button();
            this.comboBox_serial_verifyBits = new System.Windows.Forms.ComboBox();
            this.comboBox_serial_stopBits = new System.Windows.Forms.ComboBox();
            this.label_serialPort_parity = new System.Windows.Forms.Label();
            this.label_serialPort_stopBit = new System.Windows.Forms.Label();
            this.comboBox_serial_dataBits = new System.Windows.Forms.ComboBox();
            this.label_serialPort_dataBits = new System.Windows.Forms.Label();
            this.comboBox_serial_baud = new System.Windows.Forms.ComboBox();
            this.label_serialPort_baud = new System.Windows.Forms.Label();
            this.comboBox_serial_port = new System.Windows.Forms.ComboBox();
            this.label_serialPort_name = new System.Windows.Forms.Label();
            this.groupBox_equip_Operation = new System.Windows.Forms.GroupBox();
            this.button_deleteAlarmData = new System.Windows.Forms.Button();
            this.button_importAlarmData = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_exportListView = new System.Windows.Forms.Button();
            this.button_clearListview = new System.Windows.Forms.Button();
            this.listView_alarm = new System.Windows.Forms.ListView();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.语言选择ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.中文ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.英文ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.软件版本ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox_serialPort_set.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_serialPort)).BeginInit();
            this.groupBox_equip_Operation.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_serialPort_set
            // 
            this.groupBox_serialPort_set.Controls.Add(this.pictureBox_serialPort);
            this.groupBox_serialPort_set.Controls.Add(this.button_open_serial);
            this.groupBox_serialPort_set.Controls.Add(this.comboBox_serial_verifyBits);
            this.groupBox_serialPort_set.Controls.Add(this.comboBox_serial_stopBits);
            this.groupBox_serialPort_set.Controls.Add(this.label_serialPort_parity);
            this.groupBox_serialPort_set.Controls.Add(this.label_serialPort_stopBit);
            this.groupBox_serialPort_set.Controls.Add(this.comboBox_serial_dataBits);
            this.groupBox_serialPort_set.Controls.Add(this.label_serialPort_dataBits);
            this.groupBox_serialPort_set.Controls.Add(this.comboBox_serial_baud);
            this.groupBox_serialPort_set.Controls.Add(this.label_serialPort_baud);
            this.groupBox_serialPort_set.Controls.Add(this.comboBox_serial_port);
            this.groupBox_serialPort_set.Controls.Add(this.label_serialPort_name);
            this.groupBox_serialPort_set.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_serialPort_set.Location = new System.Drawing.Point(3, 3);
            this.groupBox_serialPort_set.Name = "groupBox_serialPort_set";
            this.groupBox_serialPort_set.Size = new System.Drawing.Size(212, 278);
            this.groupBox_serialPort_set.TabIndex = 0;
            this.groupBox_serialPort_set.TabStop = false;
            this.groupBox_serialPort_set.Text = "串口设置";
            // 
            // pictureBox_serialPort
            // 
            this.pictureBox_serialPort.Location = new System.Drawing.Point(14, 219);
            this.pictureBox_serialPort.Name = "pictureBox_serialPort";
            this.pictureBox_serialPort.Size = new System.Drawing.Size(45, 35);
            this.pictureBox_serialPort.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_serialPort.TabIndex = 11;
            this.pictureBox_serialPort.TabStop = false;
            // 
            // button_open_serial
            // 
            this.button_open_serial.Location = new System.Drawing.Point(92, 222);
            this.button_open_serial.Name = "button_open_serial";
            this.button_open_serial.Size = new System.Drawing.Size(93, 23);
            this.button_open_serial.TabIndex = 10;
            this.button_open_serial.Text = "开启串口";
            this.button_open_serial.UseVisualStyleBackColor = true;
            this.button_open_serial.Click += new System.EventHandler(this.button_open_serial_Click);
            // 
            // comboBox_serial_verifyBits
            // 
            this.comboBox_serial_verifyBits.FormattingEnabled = true;
            this.comboBox_serial_verifyBits.Location = new System.Drawing.Point(104, 177);
            this.comboBox_serial_verifyBits.Name = "comboBox_serial_verifyBits";
            this.comboBox_serial_verifyBits.Size = new System.Drawing.Size(81, 20);
            this.comboBox_serial_verifyBits.TabIndex = 9;
            // 
            // comboBox_serial_stopBits
            // 
            this.comboBox_serial_stopBits.FormattingEnabled = true;
            this.comboBox_serial_stopBits.Location = new System.Drawing.Point(104, 141);
            this.comboBox_serial_stopBits.Name = "comboBox_serial_stopBits";
            this.comboBox_serial_stopBits.Size = new System.Drawing.Size(81, 20);
            this.comboBox_serial_stopBits.TabIndex = 8;
            // 
            // label_serialPort_parity
            // 
            this.label_serialPort_parity.AutoSize = true;
            this.label_serialPort_parity.Location = new System.Drawing.Point(6, 180);
            this.label_serialPort_parity.Name = "label_serialPort_parity";
            this.label_serialPort_parity.Size = new System.Drawing.Size(41, 12);
            this.label_serialPort_parity.TabIndex = 7;
            this.label_serialPort_parity.Text = "校验：";
            // 
            // label_serialPort_stopBit
            // 
            this.label_serialPort_stopBit.AutoSize = true;
            this.label_serialPort_stopBit.Location = new System.Drawing.Point(6, 144);
            this.label_serialPort_stopBit.Name = "label_serialPort_stopBit";
            this.label_serialPort_stopBit.Size = new System.Drawing.Size(53, 12);
            this.label_serialPort_stopBit.TabIndex = 6;
            this.label_serialPort_stopBit.Text = "停止位：";
            // 
            // comboBox_serial_dataBits
            // 
            this.comboBox_serial_dataBits.FormattingEnabled = true;
            this.comboBox_serial_dataBits.Location = new System.Drawing.Point(104, 101);
            this.comboBox_serial_dataBits.Name = "comboBox_serial_dataBits";
            this.comboBox_serial_dataBits.Size = new System.Drawing.Size(81, 20);
            this.comboBox_serial_dataBits.TabIndex = 5;
            // 
            // label_serialPort_dataBits
            // 
            this.label_serialPort_dataBits.AutoSize = true;
            this.label_serialPort_dataBits.Location = new System.Drawing.Point(6, 104);
            this.label_serialPort_dataBits.Name = "label_serialPort_dataBits";
            this.label_serialPort_dataBits.Size = new System.Drawing.Size(53, 12);
            this.label_serialPort_dataBits.TabIndex = 4;
            this.label_serialPort_dataBits.Text = "数据位：";
            // 
            // comboBox_serial_baud
            // 
            this.comboBox_serial_baud.FormattingEnabled = true;
            this.comboBox_serial_baud.Location = new System.Drawing.Point(104, 61);
            this.comboBox_serial_baud.Name = "comboBox_serial_baud";
            this.comboBox_serial_baud.Size = new System.Drawing.Size(81, 20);
            this.comboBox_serial_baud.TabIndex = 3;
            // 
            // label_serialPort_baud
            // 
            this.label_serialPort_baud.AutoSize = true;
            this.label_serialPort_baud.Location = new System.Drawing.Point(6, 64);
            this.label_serialPort_baud.Name = "label_serialPort_baud";
            this.label_serialPort_baud.Size = new System.Drawing.Size(53, 12);
            this.label_serialPort_baud.TabIndex = 2;
            this.label_serialPort_baud.Text = "波特率：";
            // 
            // comboBox_serial_port
            // 
            this.comboBox_serial_port.FormattingEnabled = true;
            this.comboBox_serial_port.Location = new System.Drawing.Point(104, 22);
            this.comboBox_serial_port.Name = "comboBox_serial_port";
            this.comboBox_serial_port.Size = new System.Drawing.Size(81, 20);
            this.comboBox_serial_port.TabIndex = 1;
            this.comboBox_serial_port.SelectedIndexChanged += new System.EventHandler(this.comboBox_serial_port_SelectedIndexChanged);
            this.comboBox_serial_port.SelectionChangeCommitted += new System.EventHandler(this.comboBox_serial_port_SelectionChangeCommitted);
            this.comboBox_serial_port.SelectedValueChanged += new System.EventHandler(this.comboBox_serial_port_SelectedValueChanged);
            // 
            // label_serialPort_name
            // 
            this.label_serialPort_name.AutoSize = true;
            this.label_serialPort_name.Location = new System.Drawing.Point(6, 30);
            this.label_serialPort_name.Name = "label_serialPort_name";
            this.label_serialPort_name.Size = new System.Drawing.Size(53, 12);
            this.label_serialPort_name.TabIndex = 0;
            this.label_serialPort_name.Text = "串口号：";
            // 
            // groupBox_equip_Operation
            // 
            this.groupBox_equip_Operation.Controls.Add(this.button_deleteAlarmData);
            this.groupBox_equip_Operation.Controls.Add(this.button_importAlarmData);
            this.groupBox_equip_Operation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_equip_Operation.Location = new System.Drawing.Point(3, 287);
            this.groupBox_equip_Operation.Name = "groupBox_equip_Operation";
            this.groupBox_equip_Operation.Size = new System.Drawing.Size(212, 189);
            this.groupBox_equip_Operation.TabIndex = 1;
            this.groupBox_equip_Operation.TabStop = false;
            this.groupBox_equip_Operation.Text = "设备操作";
            // 
            // button_deleteAlarmData
            // 
            this.button_deleteAlarmData.Location = new System.Drawing.Point(44, 122);
            this.button_deleteAlarmData.Name = "button_deleteAlarmData";
            this.button_deleteAlarmData.Size = new System.Drawing.Size(130, 23);
            this.button_deleteAlarmData.TabIndex = 1;
            this.button_deleteAlarmData.Text = "删除报警";
            this.button_deleteAlarmData.UseVisualStyleBackColor = true;
            // 
            // button_importAlarmData
            // 
            this.button_importAlarmData.Location = new System.Drawing.Point(44, 43);
            this.button_importAlarmData.Name = "button_importAlarmData";
            this.button_importAlarmData.Size = new System.Drawing.Size(130, 23);
            this.button_importAlarmData.TabIndex = 0;
            this.button_importAlarmData.Text = "导入报警";
            this.button_importAlarmData.UseVisualStyleBackColor = true;
            this.button_importAlarmData.Click += new System.EventHandler(this.button_importAlarmData_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 218F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox_equip_Operation, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_serialPort_set, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.49895F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.50105F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(794, 479);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(221, 3);
            this.panel1.Name = "panel1";
            this.tableLayoutPanel1.SetRowSpan(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(570, 473);
            this.panel1.TabIndex = 2;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox3, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.listView_alarm, 0, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.31924F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.68076F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(570, 473);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.progressBar1);
            this.groupBox3.Controls.Add(this.button_exportListView);
            this.groupBox3.Controls.Add(this.button_clearListview);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(564, 57);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(3, 38);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(558, 16);
            this.progressBar1.TabIndex = 3;
            // 
            // button_exportListView
            // 
            this.button_exportListView.Location = new System.Drawing.Point(208, 9);
            this.button_exportListView.Name = "button_exportListView";
            this.button_exportListView.Size = new System.Drawing.Size(75, 23);
            this.button_exportListView.TabIndex = 3;
            this.button_exportListView.Text = "导出";
            this.button_exportListView.UseVisualStyleBackColor = true;
            this.button_exportListView.Click += new System.EventHandler(this.button_exportListView_Click);
            // 
            // button_clearListview
            // 
            this.button_clearListview.Location = new System.Drawing.Point(26, 9);
            this.button_clearListview.Name = "button_clearListview";
            this.button_clearListview.Size = new System.Drawing.Size(75, 23);
            this.button_clearListview.TabIndex = 2;
            this.button_clearListview.Text = "清除";
            this.button_clearListview.UseVisualStyleBackColor = true;
            this.button_clearListview.Click += new System.EventHandler(this.button_clearListview_Click);
            // 
            // listView_alarm
            // 
            this.listView_alarm.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.listView_alarm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView_alarm.Location = new System.Drawing.Point(3, 66);
            this.listView_alarm.Name = "listView_alarm";
            this.listView_alarm.Size = new System.Drawing.Size(564, 404);
            this.listView_alarm.TabIndex = 0;
            this.listView_alarm.UseCompatibleStateImageBehavior = false;
            this.listView_alarm.View = System.Windows.Forms.View.Details;
            // 
            // serialPort1
            // 
            this.serialPort1.BaudRate = 115200;
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.语言选择ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 语言选择ToolStripMenuItem
            // 
            this.语言选择ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.中文ToolStripMenuItem1,
            this.英文ToolStripMenuItem});
            this.语言选择ToolStripMenuItem.Name = "语言选择ToolStripMenuItem";
            this.语言选择ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.语言选择ToolStripMenuItem.Text = "语言选择";
            // 
            // 中文ToolStripMenuItem1
            // 
            this.中文ToolStripMenuItem1.Name = "中文ToolStripMenuItem1";
            this.中文ToolStripMenuItem1.Size = new System.Drawing.Size(100, 22);
            this.中文ToolStripMenuItem1.Text = "中文";
            this.中文ToolStripMenuItem1.Click += new System.EventHandler(this.中文ToolStripMenuItem1_Click);
            // 
            // 英文ToolStripMenuItem
            // 
            this.英文ToolStripMenuItem.Name = "英文ToolStripMenuItem";
            this.英文ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.英文ToolStripMenuItem.Text = "英文";
            this.英文ToolStripMenuItem.Click += new System.EventHandler(this.英文ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.软件版本ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 软件版本ToolStripMenuItem
            // 
            this.软件版本ToolStripMenuItem.Name = "软件版本ToolStripMenuItem";
            this.软件版本ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.软件版本ToolStripMenuItem.Text = "软件版本";
            this.软件版本ToolStripMenuItem.Click += new System.EventHandler(this.软件版本ToolStripMenuItem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 25);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(800, 499);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Paint += new System.Windows.Forms.PaintEventHandler(this.groupBox4_Paint);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(458, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 12);
            this.label2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 524);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电子空氧混合器报警管理软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox_serialPort_set.ResumeLayout(false);
            this.groupBox_serialPort_set.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_serialPort)).EndInit();
            this.groupBox_equip_Operation.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_serialPort_set;
        private System.Windows.Forms.PictureBox pictureBox_serialPort;
        private System.Windows.Forms.Button button_open_serial;
        private System.Windows.Forms.ComboBox comboBox_serial_verifyBits;
        private System.Windows.Forms.ComboBox comboBox_serial_stopBits;
        private System.Windows.Forms.Label label_serialPort_parity;
        private System.Windows.Forms.Label label_serialPort_stopBit;
        private System.Windows.Forms.ComboBox comboBox_serial_dataBits;
        private System.Windows.Forms.Label label_serialPort_dataBits;
        private System.Windows.Forms.ComboBox comboBox_serial_baud;
        private System.Windows.Forms.Label label_serialPort_baud;
        private System.Windows.Forms.ComboBox comboBox_serial_port;
        private System.Windows.Forms.Label label_serialPort_name;
        private System.Windows.Forms.GroupBox groupBox_equip_Operation;
        private System.Windows.Forms.Button button_deleteAlarmData;
        private System.Windows.Forms.Button button_importAlarmData;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView listView_alarm;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 语言选择ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 中文ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 英文ToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 软件版本ToolStripMenuItem;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_exportListView;
        private System.Windows.Forms.Button button_clearListview;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

