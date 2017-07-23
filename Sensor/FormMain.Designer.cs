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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.testParamsGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sensorParamsGrid = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.channelsCrid = new System.Windows.Forms.DataGridView();
            this.testParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.testUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorParam = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.channelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sensorNameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.highValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lowValueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.resultCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enableCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.channelsCrid)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 611);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1029, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // menuStrip1
            // 
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
            // 
            // 导出配置文件ToolStripMenuItem
            // 
            this.导出配置文件ToolStripMenuItem.Name = "导出配置文件ToolStripMenuItem";
            this.导出配置文件ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.导出配置文件ToolStripMenuItem.Text = "导出配置文件";
            // 
            // 导出测试数据ToolStripMenuItem
            // 
            this.导出测试数据ToolStripMenuItem.Name = "导出测试数据ToolStripMenuItem";
            this.导出测试数据ToolStripMenuItem.Size = new System.Drawing.Size(92, 21);
            this.导出测试数据ToolStripMenuItem.Text = "导出测试数据";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startBtn,
            this.pauseBtn,
            this.stopBtn,
            this.toolStripSeparator1,
            this.configBtn});
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
            this.startBtn.Image = global::Sensor.Properties.Resources.toolStripButtonRun_Image;
            this.startBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.startBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.startBtn.Name = "startBtn";
            this.startBtn.Size = new System.Drawing.Size(40, 40);
            this.startBtn.Text = "toolStripButton1";
            // 
            // pauseBtn
            // 
            this.pauseBtn.AutoSize = false;
            this.pauseBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.pauseBtn.Image = global::Sensor.Properties.Resources.toolStripButtonPause_Image;
            this.pauseBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.pauseBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pauseBtn.Name = "pauseBtn";
            this.pauseBtn.Size = new System.Drawing.Size(40, 40);
            this.pauseBtn.Text = "toolStripButton1";
            // 
            // stopBtn
            // 
            this.stopBtn.AutoSize = false;
            this.stopBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.stopBtn.Image = global::Sensor.Properties.Resources.toolStripButtonStop_Image;
            this.stopBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.stopBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stopBtn.Name = "stopBtn";
            this.stopBtn.Size = new System.Drawing.Size(40, 40);
            this.stopBtn.Text = "toolStripButton1";
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
            this.configBtn.Image = global::Sensor.Properties.Resources.config;
            this.configBtn.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.configBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.configBtn.Name = "configBtn";
            this.configBtn.Size = new System.Drawing.Size(40, 40);
            this.configBtn.Text = "toolStripButton1";
            this.configBtn.Click += new System.EventHandler(this.configBtn_Click);
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
            this.splitContainer1.Size = new System.Drawing.Size(1029, 543);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.74468F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.25532F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 128F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 543);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.testParamsGrid);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 192);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(301, 219);
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
            this.testParamsGrid.Size = new System.Drawing.Size(295, 199);
            this.testParamsGrid.TabIndex = 1;
            this.testParamsGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.testParamsGrid_MouseUp);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sensorParamsGrid);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(301, 183);
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
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sensorParamsGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
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
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.sensorParamsGrid.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.sensorParamsGrid.RowHeadersVisible = false;
            this.sensorParamsGrid.RowTemplate.Height = 23;
            this.sensorParamsGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.sensorParamsGrid.Size = new System.Drawing.Size(295, 163);
            this.sensorParamsGrid.TabIndex = 1;
            this.sensorParamsGrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.sensorParamsGrid_MouseUp);
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 417);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(301, 123);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "当前状态:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.channelsCrid);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(718, 543);
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
            this.channelsCrid.Size = new System.Drawing.Size(712, 523);
            this.channelsCrid.TabIndex = 0;
            this.channelsCrid.MouseUp += new System.Windows.Forms.MouseEventHandler(this.channelsCrid_MouseUp);
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
            this.highValueCol.HeaderText = "高压时测量值";
            this.highValueCol.Name = "highValueCol";
            this.highValueCol.ReadOnly = true;
            // 
            // lowValueCol
            // 
            this.lowValueCol.FillWeight = 50F;
            this.lowValueCol.HeaderText = "低压时测量值";
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
            this.enableCol.HeaderText = "使能";
            this.enableCol.Name = "enableCol";
            this.enableCol.ReadOnly = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 633);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Sensor";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn channelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn sensorNameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn highValueCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn lowValueCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn resultCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn stateCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn enableCol;
    }
}

