namespace Sensor
{
    partial class FormMain
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.导入配置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出配置文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.导出测试数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.startBtn = new System.Windows.Forms.ToolStripButton();
            this.pauseBtn = new System.Windows.Forms.ToolStripButton();
            this.stopBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.configBtn = new System.Windows.Forms.ToolStripButton();
            this.findBtn = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.testParamsGrid = new System.Windows.Forms.DataGridView();
            this.testParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sensorParamsGrid = new System.Windows.Forms.DataGridView();
            this.sensorParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.labelInnerPressure = new System.Windows.Forms.Label();
            this.labelSourcePressure = new System.Windows.Forms.Label();
            this.labelCurrentTime = new System.Windows.Forms.Label();
            this.labelTotleTime = new System.Windows.Forms.Label();
            this.labelCurrentChannel = new System.Windows.Forms.Label();
            this.labelCycleCount = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.channelsCrid = new System.Windows.Forms.DataGridView();
            this.channelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enableCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.testParamsGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sensorParamsGrid)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelsCrid)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1029, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.导入配置文件ToolStripMenuItem,
            this.导出配置文件ToolStripMenuItem,
            this.导出测试数据ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1029, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 导入配置文件ToolStripMenuItem
            // 
            this.导入配置文件ToolStripMenuItem.Name = "导入配置文件ToolStripMenuItem";
            this.导入配置文件ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.导入配置文件ToolStripMenuItem.Text = "导入配置文件";
            this.导入配置文件ToolStripMenuItem.Click += new System.EventHandler(this.导入配置文件ToolStripMenuItem_Click);
            // 
            // 导出配置文件ToolStripMenuItem
            // 
            this.导出配置文件ToolStripMenuItem.Name = "导出配置文件ToolStripMenuItem";
            this.导出配置文件ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.导出配置文件ToolStripMenuItem.Text = "导出配置文件";
            this.导出配置文件ToolStripMenuItem.Click += new System.EventHandler(this.导出配置文件ToolStripMenuItem_Click);
            // 
            // 导出测试数据ToolStripMenuItem
            // 
            this.导出测试数据ToolStripMenuItem.Name = "导出测试数据ToolStripMenuItem";
            this.导出测试数据ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.导出测试数据ToolStripMenuItem.Text = "导出测试数据";
            this.导出测试数据ToolStripMenuItem.Click += new System.EventHandler(this.导出测试数据ToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startBtn,
            this.pauseBtn,
            this.stopBtn,
            this.toolStripSeparator1,
            this.configBtn,
            this.findBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1029, 43);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // startBtn
            // 
            this.startBtn.AutoSize = false;
            this.startBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.startBtn.Image = ((System.Drawing.Image)(resources.GetObject("startBtn.Image")));
            this.startBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.startBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(40, 40);
            this.startBtn.Text = "启动测试";
            this.startBtn.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // pauseBtn
            // 
            this.pauseBtn.AutoSize = false;
            this.pauseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseBtn.Image = ((System.Drawing.Image)(resources.GetObject("pauseBtn.Image")));
            this.pauseBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pauseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(40, 40);
            this.pauseBtn.Text = "暂停或继续测试";
            this.pauseBtn.Click += new System.EventHandler(this.pauseBtn_Click);
            // 
            // stopBtn
            // 
            this.stopBtn.AutoSize = false;
            this.stopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopBtn.Image = ((System.Drawing.Image)(resources.GetObject("stopBtn.Image")));
            this.stopBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stopBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(40, 40);
            this.stopBtn.Text = "终止测试";
            this.stopBtn.Click += new System.EventHandler(this.stopBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 43);
            // 
            // configBtn
            // 
            this.configBtn.AutoSize = false;
            this.configBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.configBtn.Image = ((System.Drawing.Image)(resources.GetObject("configBtn.Image")));
            this.configBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.configBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.configBtn.Name = "configBtn";
            this.configBtn.Size = new System.Drawing.Size(40, 40);
            this.configBtn.Text = "参数配置";
            this.configBtn.Click += new System.EventHandler(this.configBtn_Click);
            // 
            // findBtn
            // 
            this.findBtn.AutoSize = false;
            this.findBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.findBtn.Image = ((System.Drawing.Image)(resources.GetObject("findBtn.Image")));
            this.findBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.findBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findBtn.Name = "findBtn";
            this.findBtn.Size = new System.Drawing.Size(40, 40);
            this.findBtn.Text = "寻找安装的设备端口";
            this.findBtn.Click += new System.EventHandler(this.findBtn_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 68);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(1029, 437);
            this.splitContainer1.SplitterDistance = 307;
            this.splitContainer1.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 53.07262F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 46.92738F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 437);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.testParamsGrid);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 143);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(301, 118);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "测试参数:";
            // 
            // testParamsGrid
            // 
            this.testParamsGrid.AllowUserToAddRows = false;
            this.testParamsGrid.AllowUserToDeleteRows = false;
            this.testParamsGrid.AllowUserToResizeColumns = false;
            this.testParamsGrid.AllowUserToResizeRows = false;
            this.testParamsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.testParamsGrid.BackgroundColor = System.Drawing.Color.White;
            this.testParamsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.testParamsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.testParamsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.testParam,
            this.testValue,
            this.testUnit});
            this.testParamsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.testParamsGrid.Location = new System.Drawing.Point(3, 17);
            this.testParamsGrid.MultiSelect = false;
            this.testParamsGrid.Name = "testParamsGrid";
            this.testParamsGrid.ReadOnly = true;
            this.testParamsGrid.RowHeadersVisible = false;
            this.testParamsGrid.RowTemplate.Height = 23;
            this.testParamsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.testParamsGrid.Size = new System.Drawing.Size(295, 98);
            this.testParamsGrid.TabIndex = 1;
            this.testParamsGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.testParamsGrid_MouseUp);
            // 
            // testParam
            // 
            this.testParam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.testParam.HeaderText = "参数";
            this.testParam.Name = "testParam";
            this.testParam.ReadOnly = true;
            this.testParam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.testParam.Width = 150;
            // 
            // testValue
            // 
            this.testValue.FillWeight = 150F;
            this.testValue.HeaderText = "值";
            this.testValue.Name = "testValue";
            this.testValue.ReadOnly = true;
            this.testValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // testUnit
            // 
            this.testUnit.HeaderText = "单位";
            this.testUnit.Name = "testUnit";
            this.testUnit.ReadOnly = true;
            this.testUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sensorParamsGrid);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 134);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "传感器参数:";
            // 
            // sensorParamsGrid
            // 
            this.sensorParamsGrid.AllowUserToAddRows = false;
            this.sensorParamsGrid.AllowUserToDeleteRows = false;
            this.sensorParamsGrid.AllowUserToResizeColumns = false;
            this.sensorParamsGrid.AllowUserToResizeRows = false;
            this.sensorParamsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.sensorParamsGrid.BackgroundColor = System.Drawing.Color.White;
            this.sensorParamsGrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sensorParamsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.sensorParamsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.sensorParamsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sensorParam,
            this.sensorValue,
            this.sensorUnit});
            this.sensorParamsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sensorParamsGrid.Location = new System.Drawing.Point(3, 17);
            this.sensorParamsGrid.MultiSelect = false;
            this.sensorParamsGrid.Name = "sensorParamsGrid";
            this.sensorParamsGrid.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sensorParamsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.sensorParamsGrid.RowHeadersVisible = false;
            this.sensorParamsGrid.RowTemplate.Height = 23;
            this.sensorParamsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sensorParamsGrid.Size = new System.Drawing.Size(295, 114);
            this.sensorParamsGrid.TabIndex = 1;
            this.sensorParamsGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sensorParamsGrid_MouseUp);
            // 
            // sensorParam
            // 
            this.sensorParam.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.sensorParam.HeaderText = "参数";
            this.sensorParam.Name = "sensorParam";
            this.sensorParam.ReadOnly = true;
            this.sensorParam.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.sensorParam.Width = 150;
            // 
            // sensorValue
            // 
            this.sensorValue.FillWeight = 150F;
            this.sensorValue.HeaderText = "值";
            this.sensorValue.Name = "sensorValue";
            this.sensorValue.ReadOnly = true;
            this.sensorValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // sensorUnit
            // 
            this.sensorUnit.HeaderText = "单位";
            this.sensorUnit.Name = "sensorUnit";
            this.sensorUnit.ReadOnly = true;
            this.sensorUnit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.labelInnerPressure);
            this.groupBox2.Controls.Add(this.labelSourcePressure);
            this.groupBox2.Controls.Add(this.labelCurrentTime);
            this.groupBox2.Controls.Add(this.labelTotleTime);
            this.groupBox2.Controls.Add(this.labelCurrentChannel);
            this.groupBox2.Controls.Add(this.labelCycleCount);
            this.groupBox2.Controls.Add(this.labelState);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 267);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 167);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前状态:";
            // 
            // labelInnerPressure
            // 
            this.labelInnerPressure.AutoSize = true;
            this.labelInnerPressure.Location = new System.Drawing.Point(10, 137);
            this.labelInnerPressure.Name = "labelInnerPressure";
            this.labelInnerPressure.Size = new System.Drawing.Size(107, 12);
            this.labelInnerPressure.TabIndex = 6;
            this.labelInnerPressure.Text = "传感器工装内压力:";
            // 
            // labelSourcePressure
            // 
            this.labelSourcePressure.AutoSize = true;
            this.labelSourcePressure.Location = new System.Drawing.Point(10, 118);
            this.labelSourcePressure.Name = "labelSourcePressure";
            this.labelSourcePressure.Size = new System.Drawing.Size(59, 12);
            this.labelSourcePressure.TabIndex = 5;
            this.labelSourcePressure.Text = "气源压力:";
            // 
            // labelCurrentTime
            // 
            this.labelCurrentTime.AutoSize = true;
            this.labelCurrentTime.Location = new System.Drawing.Point(10, 98);
            this.labelCurrentTime.Name = "labelCurrentTime";
            this.labelCurrentTime.Size = new System.Drawing.Size(83, 12);
            this.labelCurrentTime.TabIndex = 4;
            this.labelCurrentTime.Text = "当前周期历时:";
            this.labelCurrentTime.Click += new System.EventHandler(this.labelCurrentTime_Click);
            // 
            // labelTotleTime
            // 
            this.labelTotleTime.AutoSize = true;
            this.labelTotleTime.Location = new System.Drawing.Point(10, 78);
            this.labelTotleTime.Name = "labelTotleTime";
            this.labelTotleTime.Size = new System.Drawing.Size(47, 12);
            this.labelTotleTime.TabIndex = 3;
            this.labelTotleTime.Text = "总历时:";
            // 
            // labelCurrentChannel
            // 
            this.labelCurrentChannel.AutoSize = true;
            this.labelCurrentChannel.Location = new System.Drawing.Point(10, 59);
            this.labelCurrentChannel.Name = "labelCurrentChannel";
            this.labelCurrentChannel.Size = new System.Drawing.Size(95, 12);
            this.labelCurrentChannel.TabIndex = 2;
            this.labelCurrentChannel.Text = "正在测量的通道:";
            // 
            // labelCycleCount
            // 
            this.labelCycleCount.AutoSize = true;
            this.labelCycleCount.Location = new System.Drawing.Point(10, 39);
            this.labelCycleCount.Name = "labelCycleCount";
            this.labelCycleCount.Size = new System.Drawing.Size(107, 12);
            this.labelCycleCount.TabIndex = 1;
            this.labelCycleCount.Text = "正在进行的周期数:";
            // 
            // labelState
            // 
            this.labelState.AutoSize = true;
            this.labelState.Location = new System.Drawing.Point(10, 20);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(95, 12);
            this.labelState.TabIndex = 0;
            this.labelState.Text = "当前试验的状态:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.channelsCrid);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(718, 437);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "通道列表:";
            // 
            // channelsCrid
            // 
            this.channelsCrid.AllowUserToAddRows = false;
            this.channelsCrid.AllowUserToDeleteRows = false;
            this.channelsCrid.AllowUserToResizeColumns = false;
            this.channelsCrid.AllowUserToResizeRows = false;
            this.channelsCrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.channelsCrid.BackgroundColor = System.Drawing.Color.White;
            this.channelsCrid.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.channelsCrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.channelsCrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.channelCol,
            this.sensorNameCol,
            this.highValueCol,
            this.lowValueCol,
            this.resultCol,
            this.stateCol,
            this.enableCol});
            this.channelsCrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.channelsCrid.Location = new System.Drawing.Point(3, 17);
            this.channelsCrid.MultiSelect = false;
            this.channelsCrid.Name = "channelsCrid";
            this.channelsCrid.ReadOnly = true;
            this.channelsCrid.RowHeadersVisible = false;
            this.channelsCrid.RowTemplate.Height = 23;
            this.channelsCrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.channelsCrid.Size = new System.Drawing.Size(712, 417);
            this.channelsCrid.TabIndex = 0;
            this.channelsCrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.channelsCrid_MouseUp);
            // 
            // channelCol
            // 
            this.channelCol.FillWeight = 30F;
            this.channelCol.HeaderText = "通道号";
            this.channelCol.Name = "channelCol";
            this.channelCol.ReadOnly = true;
            // 
            // sensorNameCol
            // 
            this.sensorNameCol.FillWeight = 50F;
            this.sensorNameCol.HeaderText = "传感器编号";
            this.sensorNameCol.Name = "sensorNameCol";
            this.sensorNameCol.ReadOnly = true;
            // 
            // highValueCol
            // 
            this.highValueCol.FillWeight = 50F;
            this.highValueCol.HeaderText = "高压时测量值(Mpa)";
            this.highValueCol.Name = "highValueCol";
            this.highValueCol.ReadOnly = true;
            // 
            // lowValueCol
            // 
            this.lowValueCol.FillWeight = 50F;
            this.lowValueCol.HeaderText = "低压时测量值(Mpa)";
            this.lowValueCol.Name = "lowValueCol";
            this.lowValueCol.ReadOnly = true;
            // 
            // resultCol
            // 
            this.resultCol.FillWeight = 40F;
            this.resultCol.HeaderText = "测量结果";
            this.resultCol.Name = "resultCol";
            this.resultCol.ReadOnly = true;
            // 
            // stateCol
            // 
            this.stateCol.FillWeight = 20F;
            this.stateCol.HeaderText = "状态";
            this.stateCol.Name = "stateCol";
            this.stateCol.ReadOnly = true;
            // 
            // enableCol
            // 
            this.enableCol.FillWeight = 15F;
            this.enableCol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.enableCol.HeaderText = "使能";
            this.enableCol.Name = "enableCol";
            this.enableCol.ReadOnly = true;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 527);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "SensorAg";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.testParamsGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sensorParamsGrid)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.channelsCrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem 导入配置文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出配置文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 导出测试数据ToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView sensorParamsGrid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView channelsCrid;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.DataGridView testParamsGrid;
        private System.Windows.Forms.ToolStripButton configBtn;
        private System.Windows.Forms.ToolStripButton startBtn;
        private System.Windows.Forms.ToolStripButton pauseBtn;
        private System.Windows.Forms.ToolStripButton stopBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn testParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn testValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn testUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorParam;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorUnit;
        private System.Windows.Forms.Label labelTotleTime;
        private System.Windows.Forms.Label labelCurrentChannel;
        private System.Windows.Forms.Label labelCycleCount;
        private System.Windows.Forms.Label labelState;
        private System.Windows.Forms.Label labelCurrentTime;
        private System.Windows.Forms.Label labelInnerPressure;
        private System.Windows.Forms.Label labelSourcePressure;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ToolStripButton findBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn channelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn highValueCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowValueCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enableCol;
    }
}

