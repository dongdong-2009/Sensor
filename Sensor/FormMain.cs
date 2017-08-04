using Aspose.Cells;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Sensor
{
    public partial class FormMain : Form
    {
        public class ParamDesc
        {
            private double value;
            private string fmt;     //显示格式
            private string unit;    //单位
            private double min;
            private double max;
            private double step;

            public ParamDesc(double default_value, string fmt, string unit, double min, double max, double step)
            {
                this.value = default_value;
                this.fmt = fmt;
                this.unit = unit;
                this.min = min;
                this.max = max;
                this.step = step;

            }
            public string getValue()
            {
                if (unit.Trim() == "%")
                    return (value * 100).ToString(fmt);
                return value.ToString(fmt);
            }
            public double getValue2()
            {
                return value;
            }
            public string getUnit()
            {
                return unit;
            }

            internal void setValue(string v)
            {
                if (unit.Trim() == "%")
                {
                    value = Convert.ToDouble(v)/100.0;
                }
                else
                {
                    value = Convert.ToDouble(v);
                }
            }
            internal void setValue(double v)
            {
                value = v;
            }

            internal string getFormat()
            {
                return fmt;
            }

            internal double getMin()
            {
                return min;
            }
            internal double getMax()
            {
                return max;
            }
        }

        ParamDesc pressureParamDesc; //压力值用的格式化字符串和单位等描述用于测试时界面显示.
        public Dictionary<String, ParamDesc> sensorParamTable = new Dictionary<string, ParamDesc>();        //传感器参数表
        public Dictionary<String, ParamDesc> testParamTable = new Dictionary<string, ParamDesc>();          //测试参数表
        public bool[,] channelEnableTable = new bool[10, 5];        //通道使能表
        string[] channelNumbers = new string[50];                   //传感器编号
        Config config;              //配置文件
        Database db ;               //数据存储
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //主表创建
            channelsCrid.Rows.Clear();
            channelsCrid.Rows.Add(50);
            startBtn.Enabled = true;
            pauseBtn.Enabled = false;
            stopBtn.Enabled = false;

            //主表
            for (int i = 0; i < 50; i++)
            {
                //通道名
                channelsCrid[channelCol.Index, i].Value = String.Format("{0:D2}插槽{1}端口", (i / 5 + 1), (i % 5 + 1));
                //状态
                channelsCrid[stateCol.Index, i].Value = "未知";
            }

            LoadConfig();
            UpdateDisp();

            //禁止选中
            foreach (DataGridViewRow i in channelsCrid.Rows)
            {
                i.Selected = false;
            }
            foreach (DataGridViewRow i in sensorParamsGrid.Rows)
            {
                i.Selected = false;
            }
            foreach (DataGridViewRow i in testParamsGrid.Rows)
            {
                i.Selected = false;
            }

        }
        


        private void LoadConfig()
        {
            config = new Config();
            config.LoadIniFileInCurDir("default.cfg");
            //默认参数
            //传感器参数
            sensorParamTable.Add("传感器量程最小值", new ParamDesc(config.传感器参数.传感器量程最小值, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            sensorParamTable.Add("传感器量程最大值", new ParamDesc(config.传感器参数.传感器量程最大值, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            sensorParamTable.Add("传感器输出电压最小值", new ParamDesc(config.传感器参数.传感器输出电压最小值, "0.00", "V", 0.00, 12.00, 0.01));
            sensorParamTable.Add("传感器输出电压最大值", new ParamDesc(config.传感器参数.传感器输出电压最大值, "0.00", "V", 0.01, 12.00, 0.01));
            sensorParamTable.Add("传感器精度", new ParamDesc(config.传感器参数.传感器精度, "0.00", "%", 0.001, 10.000, 0.001));
            sensorParamTable.Add("传感器供电电压", new ParamDesc(config.传感器参数.传感器供电电压, "0.00", "V", 0.01, 24.00, 0.01));

            //测试参数
            testParamTable.Add("老化周期数", new ParamDesc(config.测试参数.老化周期数, "", "次", 1, 10000, 1));
            testParamTable.Add("充气(高压)压力", new ParamDesc(config.测试参数.充气高压压力, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            testParamTable.Add("充气(高压)时间", new ParamDesc(config.测试参数.充气高压时间, "", "秒", 1, 200, 1));
            testParamTable.Add("排气(静置)时间", new ParamDesc(config.测试参数.排气静置时间, "", "秒", 1, 200, 1));
            testParamTable.Add("测量周期步进", new ParamDesc(config.测试参数.测量周期步进, "", "周期", 0, 10000, 1));

            pressureParamDesc = testParamTable["充气(高压)压力"];
            if (pressureParamDesc == null)
            {
                MessageBox.Show("程序故障!");
                Application.Exit();
            }

            //传感器编号
            string s = config.设备参数.设备标签.Trim();
            string[] ss = s.Split(' ');
            int i = 0;
            for(; i < ss.Count(); i++) 
                channelNumbers[i] = ss[i];
            for(;i<50;i++)
                channelNumbers[i] = "NoSet";

            //使能
            s = config.设备参数.禁用的通道.Trim();
            ss = s.Split(',');
            for (int slot = 0; slot < 10; slot++)
            {
                for (int ch = 0; ch < 5; ch++)
                {
                    channelEnableTable[slot, ch] = true;
                    for (i = 0; i < ss.Count(); i++)
                    {
                        try
                        {
                            if (int.Parse(ss[i]) == (slot * 5 + ch))
                                channelEnableTable[slot, ch] = false;
                        }
                        catch { }
                    }
                    
                }
            }
        }
        private void UpdateConfig()
        {
            config.传感器参数.传感器量程最小值 = sensorParamTable["传感器量程最小值"].getValue2();
            config.传感器参数.传感器量程最大值 = sensorParamTable["传感器量程最大值"].getValue2();
            config.传感器参数.传感器输出电压最小值 = sensorParamTable["传感器输出电压最小值"].getValue2();
            config.传感器参数.传感器输出电压最大值 = sensorParamTable["传感器输出电压最大值"].getValue2();
            config.传感器参数.传感器精度 = sensorParamTable["传感器精度"].getValue2();
            config.传感器参数.传感器供电电压 = sensorParamTable["传感器供电电压"].getValue2();

            config.测试参数.老化周期数 = (int)testParamTable["老化周期数"].getValue2();
            config.测试参数.充气高压压力 = testParamTable["充气(高压)压力"].getValue2();
            config.测试参数.充气高压时间 = (int)testParamTable["充气(高压)时间"].getValue2();
            config.测试参数.排气静置时间 = (int)testParamTable["排气(静置)时间"].getValue2();

            config.设备参数.禁用的通道 = "";
            for (int slot = 0; slot < 10; slot++)
            {
                for (int ch = 0; ch < 5; ch++)
                {
                    if (channelEnableTable[slot, ch] == false)
                    {
                        config.设备参数.禁用的通道 += "" + (slot * 5 + ch) + ",";
                    }
                }
            }

            config.设备参数.设备标签 = "";
            for (int i = 0; i < 50; i++)
            {
                config.设备参数.设备标签 += channelNumbers[i] + " ";
            }


            config.SaveIniFile();
        }

        private void UpdateDisp()
        {
            addParamsToGrid(sensorParamsGrid, sensorParamTable);
            addParamsToGrid(testParamsGrid, testParamTable);
           
            //传感器编号
            //使能
            for (int i = 0; i < 50; i++)
            {
                channelsCrid[channelsCrid.ColumnCount - 1, i].Value = channelEnableTable[(i / 5), (i % 5)];
                channelsCrid[sensorNameCol.Index, i].Value = channelNumbers[i];
            }
        }

        public static void addParamsToGrid(DataGridView grid, Dictionary<String, ParamDesc> table)
        {
            grid.Rows.Clear();
            grid.Rows.Add(table.Count);
            for (int i = 0; i < table.Count; i++)
            {
                String key = table.Keys.ToArray()[i];
                grid.Rows[i].Cells[0].Value = key;
                grid.Rows[i].Cells[1].Value = table[key].getValue();
                grid.Rows[i].Cells[2].Value = table[key].getUnit();
            }
        }
        internal static void writeParamsFromGrid(Dictionary<string, ParamDesc> table, DataGridView grid)
        {
            for (int i = 0; i < grid.Rows.Count; i++)
            {
                string key = grid.Rows[i].Cells[0].Value.ToString();
                table[key].setValue(grid.Rows[i].Cells[1].Value.ToString());
            }
        }
        private void configBtn_Click(object sender, EventArgs e)
        {
            FormConfig f = new FormConfig(sensorParamTable,testParamTable, channelEnableTable, channelNumbers);
            f.ShowDialog(this);

            //将变化反应到ui
            UpdateDisp();
            //更新到配置文件
            UpdateConfig();

        }


        private void testParamsGrid_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow i in testParamsGrid.Rows)
            {
                i.Selected = false;
            }
        }

        private void sensorParamsGrid_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow i in sensorParamsGrid.Rows)
            {
                i.Selected = false;
            }

        }

        private void channelsCrid_MouseUp(object sender, MouseEventArgs e)
        {
            foreach (DataGridViewRow i in channelsCrid.Rows)
            {
                i.Selected = false;
            }
        }

        private void 导入配置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog d = new OpenFileDialog();
            d.Multiselect = false;
            d.Filter = "cfg文件(*.cfg)|*.cfg";
            if (d.ShowDialog(this) == DialogResult.OK)
            {
                string s = d.FileName;
                Config c = new Config();
                string[] errlist;
                bool res =  c.LoadIniFileEx(s,out errlist);
                if (res==false) {
                    MessageBox.Show(this, "读取配置文件发生错误!");
                    return;
                }
                if (errlist.Length > 0) {
                    MessageBox.Show(this, "配置文件不完整,无法加载所有参数!");
                    return;
                }
                config.SaveIniFile();
                config = null; 
                config = c;
            }
        }


        private void 导出配置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog d = new SaveFileDialog();
            d.Filter = "cfg文件(*.cfg)|*.cfg";
            if (d.ShowDialog(this) == DialogResult.OK)
            {

                string s = d.FileName;
                if (config.SaveIniFileTo(s) == false)
                {
                    MessageBox.Show("导出失败!");
                }
            }
        }
        public enum TestEvent {
            /*
             * 用末尾的字符代表了参数的个数和类型例如
             * XXX_ds  两个参数, 第一个为int, 第二个为string.
             * c:char d:int, f:double, s:string o:class-object 
             */
            ShowMessageBox_s,           //显示消息框
            ChannelsState,              //端口状态监测
            TestBegain,                  //测试开始
            TestEnd,                    //测试完成
            TestAbort,                    //测试中断
            CycleBegain,                //一个周期开始
            CurrentCycleCount_d,        //当前测试周期
            CurrentTestState_s,         //当前测试状态,排气,充气
            CurrentTestSlotChannel_dd,   //当前测试通道
            TestTotleTime,              //总时间
            TestCurrentTime,            //当前周期历时
            LowPressureVal_dddf,          //传感器低压信息,参数:插槽,通道,传感器输出电压值,气源压力值,工装内压力值
            HighPressureVal_dddf,          //传感器高压信息,同上
            EndChannelTest_dd,                 //完成一个通道的高低压测试.

            //HXD 20170804
            EndChargePresure_ff,           //充气完成
            EndReleasePresure_ff,          //放气完成
        }
        volatile bool runFlag = false;
        Thread testThread = null;
        Device device = null;
        int timeBegainTest = 0;
        int timeBegainCycle = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (runFlag)
            {
                if(timeBegainTest>0)
                {
                    int s = (System.Environment.TickCount - timeBegainTest)/1000;
                    int hh = s / 3600;
                    int mm = s % 3600 / 60;
                    int ss = s % 60;
                    labelTotleTime.Text = String.Format("总历时: {0}:{1}:{2}", hh, mm, ss);
                }
                if(timeBegainCycle>0)
                {
                    int s = (System.Environment.TickCount - timeBegainCycle)/1000;
                    int hh = s / 3600;
                    int mm = s % 3600 / 60;
                    int ss = s % 60;
                    labelCurrentTime.Text = String.Format("当前周期历时: {0}:{1}:{2}", hh, mm, ss);
                }
            }
        }
        public delegate void d_SendTestEvent(TestEvent e, params object[] p);
        public void SendTestEvent(TestEvent e, params object[] p)
        {
            if (InvokeRequired)
            {
                d_SendTestEvent d = new d_SendTestEvent(SendTestEvent);
                Invoke(d, e, p);
            }
            else
            {
                switch (e) {
                    case TestEvent.ShowMessageBox_s:
                        MessageBox.Show(this, p[0].ToString());
                        break;
                    case TestEvent.TestBegain:
                        startBtn.Enabled = false;
                        pauseBtn.Enabled = true;
                        stopBtn.Enabled = true;
                        configBtn.Enabled = false;
                        findBtn.Enabled = false;
                        导入配置文件ToolStripMenuItem.Enabled = false;
                        导出测试数据ToolStripMenuItem.Enabled = false;
                        导出配置文件ToolStripMenuItem.Enabled = false;
                        for (int i = 0; i < 50; i++)
                        {
                            channelsCrid[highValueCol.Index, i].Value = "";
                            channelsCrid[lowValueCol.Index, i].Value = "";
                            channelsCrid[resultCol.Index, i].Value = "";
                        }
                        timeBegainTest = System.Environment.TickCount;
                        break;
                    case TestEvent.TestEnd:
                        startBtn.Enabled = true;
                        pauseBtn.Enabled = false;
                        stopBtn.Enabled = false;
                        configBtn.Enabled = true;
                        findBtn.Enabled = true;
                        导入配置文件ToolStripMenuItem.Enabled = true;
                        导出测试数据ToolStripMenuItem.Enabled = true;
                        导出配置文件ToolStripMenuItem.Enabled = true;

                        timeBegainTest = 0;
                        timeBegainCycle = 0;

                        db.close();
                        db = null;
                        break;
                    case TestEvent.TestAbort:
                        startBtn.Enabled = true;
                        pauseBtn.Enabled = false;
                        stopBtn.Enabled = false;
                        configBtn.Enabled = true;
                        findBtn.Enabled = true;
                        导入配置文件ToolStripMenuItem.Enabled = true;
                        导出测试数据ToolStripMenuItem.Enabled = true;
                        导出配置文件ToolStripMenuItem.Enabled = true;

                        timeBegainTest = 0;
                        timeBegainCycle = 0;

                        db.close();
                        db = null;
                        break;
                    case TestEvent.CycleBegain:
                        for (int i = 0; i < 50; i++)
                        {
                            channelsCrid[highValueCol.Index, i].Value = "";
                            channelsCrid[lowValueCol.Index, i].Value = "";

                            channelsCrid[highValueCol.Index, i].Style.BackColor = Color.White;
                            channelsCrid[lowValueCol.Index, i].Style.BackColor = Color.White;
                            channelsCrid[resultCol.Index, i].Style.BackColor = Color.White;

                        }
                        timeBegainCycle = System.Environment.TickCount;
                        break;
                    case TestEvent.CurrentCycleCount_d:
                        labelCycleCount.Text = "正在进行的周期数: " + ((int)p[0] + 1);
                        break;
                    case TestEvent.CurrentTestState_s:
                        labelState.Text = "当前实验的状态: " + ((string)p[0]);
                        break;
                    case TestEvent.CurrentTestSlotChannel_dd:
                        {
                            int slot = (int)p[0];
                            int ch = (int)p[1];
                            labelCurrentChannel.Text = String.Format("正在测量的通道: 第{0}插槽,第{1}通道", slot+1, ch+1);
                            for (int i = 0; i < channelsCrid.RowCount; i++)
                            {
                                if (i == slot * 5 + ch)
                                    channelsCrid.Rows[i].Selected = true;
                                else
                                    channelsCrid.Rows[i].Selected = false;
                            }
                            break;
                        }
                    case TestEvent.HighPressureVal_dddf:
                        {
                            int cycle = (int)p[0];
                            int slot = (int)p[1];
                            int ch = (int)p[2];
                            double sensor_volt = (double)p[3];
                            double sensor_pressure = calc_sensor_pres(sensor_volt);

                            string s = sensor_pressure.ToString(pressureParamDesc.getFormat());
                            channelsCrid[highValueCol.Index, slot * 5 + ch].Value = s;
                            channelsCrid[lowValueCol.Index, slot * 5 + ch].Selected = true;

                            //测试结果
                            double highval = 0.0;
                            double.TryParse(channelsCrid[highValueCol.Index, slot * 5 + ch].Value.ToString(), out highval);
                            double dlta = config.传感器参数.传感器精度 * (config.传感器参数.传感器量程最大值 - config.传感器参数.传感器量程最小值);
                            double h_lval = config.测试参数.充气高压压力 - dlta;
                            double h_rval = config.测试参数.充气高压压力 + dlta;
                            bool hpass = true;
                            if (highval < h_lval || highval > h_rval)
                            {
                                hpass = false;
                                channelsCrid[highValueCol.Index, slot * 5 + ch].Style.BackColor = Color.Red;
                            }
                            if (hpass)
                            {
                                channelsCrid[resultCol.Index, slot * 5 + ch].Value = "PASS";
                                channelsCrid[resultCol.Index, slot * 5 + ch].Style.BackColor = Color.Green;
                            }
                            else
                            {
                                channelsCrid[resultCol.Index, slot * 5 + ch].Value = "FALSE";
                                channelsCrid[resultCol.Index, slot * 5 + ch].Style.BackColor = Color.Red;
                                //HXD 20170804
                                //一项测试失败不停止继续
                                //runFlag = false;
                                foreach (DataGridViewRow i in channelsCrid.Rows)
                                {
                                    i.Selected = false;
                                }
                            }
                            string sensor_nm = channelsCrid[sensorNameCol.Index, slot * 5 + ch].Value.ToString();
                            db.insertHightTestVal(cycle, slot, ch, sensor_nm, highval, hpass);

                            break;
                        }
                    case TestEvent.LowPressureVal_dddf:
                        {
                            int cycle = (int)p[0];
                            int slot = (int)p[1];
                            int ch = (int)p[2];
                            double sensor_volt = (double)p[3];
                            double sensor_pressure = calc_sensor_pres(sensor_volt);

                            
                            string s = sensor_pressure.ToString(pressureParamDesc.getFormat());
                            channelsCrid[lowValueCol.Index, slot * 5 + ch].Value = s;
                            channelsCrid[lowValueCol.Index, slot * 5 + ch].Selected = true;

                            //测试结果
                            double lowval = 0.0;
                            double.TryParse(channelsCrid[lowValueCol.Index, slot * 5 + ch].Value.ToString(), out lowval);
                            double dlta = config.传感器参数.传感器精度 * (config.传感器参数.传感器量程最大值 - config.传感器参数.传感器量程最小值);
                            double l_lval = -dlta;
                            double l_rval = dlta;
                            bool lpass = true;
                           
                            if (lowval < l_lval || lowval > l_rval)
                            {
                                lpass = false;
                                channelsCrid[lowValueCol.Index, slot * 5 + ch].Style.BackColor = Color.Red;
                            }
                            if (lpass)
                            {
                                channelsCrid[resultCol.Index, slot * 5 + ch].Value = "PASS";
                                channelsCrid[resultCol.Index, slot * 5 + ch].Style.BackColor = Color.Green;
                            }
                            else
                            {
                                channelsCrid[resultCol.Index, slot * 5 + ch].Value = "FALSE";
                                channelsCrid[resultCol.Index, slot * 5 + ch].Style.BackColor = Color.Red;
                                foreach (DataGridViewRow i in channelsCrid.Rows)
                                {
                                    i.Selected = false;
                                }
                                //HXD 20170804
                                //一项测试失败不停止继续
                                //runFlag = false;

                            }
                            string sensor_nm = channelsCrid[sensorNameCol.Index, slot * 5 + ch].Value.ToString();
                            db.insertLowTestVal(cycle,slot, ch, sensor_nm, lowval,lpass);
                            break;
                        }
                        //HXD 20170804
                        //充放气稳定后发送一次结果供显示
                    case TestEvent.EndChargePresure_ff: 
                    case TestEvent.EndReleasePresure_ff:
                        {
                            double source_pressure = (double)p[4];
                            double inner_pressure = (double)p[5];
                            labelSourcePressure.Text = "气源压力: " +
                                source_pressure.ToString(pressureParamDesc.getFormat()) + " " + pressureParamDesc.getUnit();
                            labelInnerPressure.Text = "传感器工装内压力: " +
                                inner_pressure.ToString(pressureParamDesc.getFormat()) + " " + pressureParamDesc.getUnit();
                            break;
                        }
                    case TestEvent.EndChannelTest_dd:
                        {

                            /* //如果测完一轮充放气才报结果就这样
                            int slot = (int)p[0];
                            int ch = (int)p[1];
                            double lowval = 0.0,highval=0.0;
                            double.TryParse(channelsCrid[lowValueCol.Index, slot * 5 + ch].Value.ToString(), out lowval);
                            double.TryParse(channelsCrid[highValueCol.Index, slot * 5 + ch].Value.ToString(), out highval);
                            
                            double dlta = config.传感器参数.传感器精度 * (config.传感器参数.传感器量程最大值 - config.传感器参数.传感器量程最小值);

                            double h_lval = config.测试参数.充气高压压力 - dlta;
                            double h_rval = config.测试参数.充气高压压力 + dlta;
                            double l_lval = 0.0 * (1 - config.测试参数.传感器精度);
                            double l_rval = 0.0 * (1 + config.测试参数.传感器精度);
                            bool hpass=true, lpass=true;
                            if (highval < h_lval || highval > h_rval)
                            {
                                hpass = false;
                                channelsCrid[highValueCol.Index, slot * 5 + ch].Style.BackColor = Color.Red;
                            }
                            if (lowval < l_lval || lowval > l_rval)
                            {
                                lpass = false;
                                channelsCrid[lowValueCol.Index, slot * 5 + ch].Style.BackColor = Color.Red;
                            }
                            if (hpass && lpass)
                            {
                                channelsCrid[resultCol.Index, slot * 5 + ch].Value = "PASS";
                                channelsCrid[resultCol.Index, slot * 5 + ch].Style.BackColor = Color.Green;
                            }
                            else
                            {
                                channelsCrid[resultCol.Index, slot * 5 + ch].Value = "FALSE";
                                channelsCrid[resultCol.Index, slot * 5 + ch].Style.BackColor = Color.Red;
                                runFlag = false;
                                foreach (DataGridViewRow i in channelsCrid.Rows)
                                {
                                    i.Selected = false;
                                }
                            }*/
                        }
                        break;
                    default:
                        break;

                }
            }
        }

        private double calc_sensor_pres(double sensor_volt)
        {
            //WT 20170730
            //修改传感器压力计算方法
            sensor_volt = sensor_volt / 1000.0;
            double pleft = config.传感器参数.传感器量程最小值;
            double pright = config.传感器参数.传感器量程最大值;
            double vleft = config.传感器参数.传感器输出电压最小值;
            double vright = config.传感器参数.传感器输出电压最大值;
            double pres = ((sensor_volt - vleft) /(vright- vleft)) * (pright- pleft) + pleft;                //计算输出的压力值
            return pres;
        }

        void testProc()
        {
            runFlag = true;
            device = new Device();
            int cycle_count=0;
            int period_start_time;


            try
            {
                if( device.Connect() == false)
                    throw new Exception("无法连接到设备");
                SendTestEvent(TestEvent.TestBegain);

                for (cycle_count=0; cycle_count<config.测试参数.老化周期数 && runFlag; cycle_count++)
                {

                    SendTestEvent(TestEvent.CycleBegain);
                    SendTestEvent(TestEvent.CurrentCycleCount_d, cycle_count);

                    device.closeAllChannel();
                    device.setPowerVoltage(config.传感器参数.传感器供电电压);
                    device.enablePressure();
                    //记录此时时刻
                    period_start_time = System.Environment.TickCount/ 1000;
                    SendTestEvent(TestEvent.CurrentTestState_s, "正在充气");
                    //WT 20170730 
                    //注释掉进气等待时间
                    //进气后约500ms气压就会稳定可以切换通道开始测量
                    //测量过程中花费的时间是算在进气时间内的
                    //如果测量时间超过近期时间，测量完毕后切换状态，否则继续等待直到超时
                    //Thread.Sleep(config.测试参数.排气静置时间 * 1000);
                    //添加进气稳定延时
                    Thread.Sleep(500);

                    //HXD 20170804
                    //充气完了发送一个事件
                    double source_pressure = device.getSourcePressure();
                    double inner_pressure = device.getInnerPressure();
                    SendTestEvent(TestEvent.EndChargePresure_ff, source_pressure, inner_pressure);

                    if (config.测试参数.测量周期步进!=0 && (cycle_count % config.测试参数.测量周期步进) == 0)
                    {
                        for (int slot = 0; slot < 10 && runFlag; slot++)
                        {
                            for (int ch = 0; ch < 5; ch++)
                            {
                                if (channelsCrid[stateCol.Index, slot * 5 + ch].Value.ToString() == "空缺" ||
                                    (bool)(channelsCrid[enableCol.Index, slot * 5 + ch].Value) == false)
                                    continue;
                                if (runFlag == false)
                                    goto end;

                                device.selectSlotChannel(slot, ch);
                                //WT 20170730
                                //取消此时的延时
                                // Thread.Sleep(500);
                                SendTestEvent(TestEvent.CurrentTestSlotChannel_dd, slot, ch);
                                Thread.Sleep(200);
                                //不必每次都测量压力
                                //double source_pressure = device.getSourcePressure();
                                //double inner_pressure = device.getInnerPressure();
                                double sensor_volt = device.getTestVoltage();

                                SendTestEvent(TestEvent.HighPressureVal_dddf, cycle_count, slot, ch, sensor_volt);

                                if (ch == 4)
                                    device.closeSlotChannel(slot, ch);  //最後一個通道是需要關閉的.
                            }

                        }
                    }
                    //等待该流程结束
                    while (System.Environment.TickCount / 1000 - period_start_time <= config.测试参数.充气高压时间)
                    {
                    }
                    device.disablePressure();
                    //记录此刻时间
                    period_start_time = System.Environment.TickCount / 1000;
                    SendTestEvent(TestEvent.CurrentTestState_s, "正在排气");
                    //Thread.Sleep(config.测试参数.排气静置时间 * 1000);
                    Thread.Sleep(500);  //等待⽓气压稳定的时间约为500ms 

                    //HXD 20170804
                    //放气完了发送一个事件
                    source_pressure = device.getSourcePressure();
                    inner_pressure = device.getInnerPressure();
                    SendTestEvent(TestEvent.EndChargePresure_ff, source_pressure, inner_pressure);
                    if (config.测试参数.测量周期步进 != 0 && (cycle_count % config.测试参数.测量周期步进) == 0)
                    {
                        for (int slot = 0; slot < 10 && runFlag; slot++)
                        {
                            for (int ch = 0; ch < 5; ch++)
                            {
                                if (channelsCrid[stateCol.Index, slot * 5 + ch].Value.ToString() == "空缺" ||
                                    (bool)(channelsCrid[enableCol.Index, slot * 5 + ch].Value) == false)
                                    continue;
                                if (runFlag == false)
                                    goto end;

                                device.selectSlotChannel(slot, ch);
                                SendTestEvent(TestEvent.CurrentTestSlotChannel_dd, slot, ch);
                                Thread.Sleep(200); //等待传感器器输出稳定的时间200ms
                                                   //double source_pressure = device.getSourcePressure();
                                                   //double inner_pressure = device.getInnerPressure();
                                double sensor_volt = device.getTestVoltage();
                                SendTestEvent(TestEvent.LowPressureVal_dddf, cycle_count, slot, ch, sensor_volt);

                                SendTestEvent(TestEvent.EndChannelTest_dd, slot, ch);

                                if (ch == 4)
                                    device.closeSlotChannel(slot, ch);  //最後一個通道是需要關閉的.
                            }

                        }
                    }
                    //等待该流程结束
                    while (System.Environment.TickCount / 1000 - period_start_time <= config.测试参数.排气静置时间)
                    {
                    }
                }
            }
            catch (Exception e)
            {
                runFlag = false;
                device.Disconnect();
                device = null;
                SendTestEvent(TestEvent.TestEnd);
                SendTestEvent(TestEvent.ShowMessageBox_s, "测试异常中断: " + e.Message);
                return;
            }

        end:
            runFlag = false;
            device.Disconnect();
            device = null;
            if (cycle_count >= config.测试参数.老化周期数)
            {
                SendTestEvent(TestEvent.TestEnd);
                SendTestEvent(TestEvent.ShowMessageBox_s, String.Format("测试完成 共{0}个周期", config.测试参数.老化周期数));
            }
            else
            {
                SendTestEvent(TestEvent.TestAbort);
                SendTestEvent(TestEvent.ShowMessageBox_s,
                String.Format("测试中断 共{0}个周期, 当前周期{1}", config.测试参数.老化周期数, cycle_count));
            }
            return;
        }





        private void startBtn_Click(object sender, EventArgs e)
        {
            db = new Database();
            db.create();
            startBtn.Enabled = false;
            pauseBtn.Enabled = true;
            stopBtn.Enabled = true;
            configBtn.Enabled = false;
            findBtn.Enabled = false;

            导入配置文件ToolStripMenuItem.Enabled = false;
            导出测试数据ToolStripMenuItem.Enabled = false;
            导出配置文件ToolStripMenuItem.Enabled = false;

            testThread = new Thread(new ThreadStart(testProc));
            testThread.Start();
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {
            if (testThread.ThreadState != ThreadState.Suspended)
            {
                if(device!=null)
                    device.pause();
                testThread.Suspend();
                stopBtn.Enabled = false;
            }
            else
            {
                stopBtn.Enabled = true;
                testThread.Resume();
                if (device != null)
                    device.resume();
            }
        }

        private void stopBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "确认停止测试么,停止后将不能被恢复.", "提示",
                MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                runFlag = false;
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (runFlag) {
                MessageBox.Show(this, "正在测试中,请停止测试后关闭!");
                e.Cancel = true;
                return;
            }
            config.SaveIniFile();
            config = null;
        }

        private void findBtn_Click(object sender, EventArgs e)
        {
            startBtn.Enabled = false;
            configBtn.Enabled = false;
            bool haveError = false;
            device = new Device();
            if (device.Connect())
            {
                for (int slot = 0; slot < 10; slot++)
                {
                    bool state = device.findSlot(slot);

                    for (int ch = 0; ch < 5; ch++)
                    {
                        if (state == false && (bool)(channelsCrid[enableCol.Index, slot * 5 + ch].Value))
                            haveError = true;
                        channelsCrid[stateCol.Index, slot * 5 + ch].Value = state?"接入":"空缺";
                        channelsCrid[stateCol.Index, slot * 5 + ch].Style.ForeColor = state ? Color.Black : Color.Red;
                    }
                }
                if (haveError)
                    MessageBox.Show(this, "注意:部分使能的端口没有找到.");
                else
                    MessageBox.Show(this, "所有使能的端口都已经接入.");
            }
            else
            {
                MessageBox.Show(this, "无法连接到设备");
            }
            startBtn.Enabled = true;
            configBtn.Enabled = true;

        }
        
        private void 导出测试数据ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (device != null)
            {
                device.Disconnect();
                device = null;
            }
            string s = Database.lastRecordPath;
            string sname = Database.lastRecordDateTime;
            if (s == null || s == "") {
                MessageBox.Show(this, "还没有测试数据.");
                return;
            }
            try
            {
                SaveFileDialog d = new SaveFileDialog();
                d.Filter = "xls文件(*.xls)|*.xls";
                if (d.ShowDialog(this) != DialogResult.OK)
                    return;
                string path = d.FileName;
                try
                {

                    Workbook book=null;
                    try
                    {
                        book = new Workbook(Environment.CurrentDirectory + "\\xls.tmpl");
                    }
                    catch { }
                    if (book == null)
                        book = new Workbook();  //没有模板也得用啊
                    book.Worksheets.Add(SheetType.Worksheet);
                    book.Worksheets.Add(SheetType.Worksheet);
                    Worksheet sheetHigh = book.Worksheets[0];
                    Worksheet sheetLow = book.Worksheets[1];
                    sheetHigh.Name = "高压测试数据_" + sname;
                    sheetLow.Name = "低压测试数据_" + sname;

                    sheetHigh.Cells[0, 0].Value = "测试周期";
                    sheetHigh.Cells[0, 1].Value = "插槽号";
                    sheetHigh.Cells[0, 2].Value = "通道号";
                    sheetHigh.Cells[0, 3].Value = "传感器编号";
                    sheetHigh.Cells[0, 4].Value = "高压值";
                    sheetHigh.Cells[0, 5].Value = "测试结果";

                    sheetLow.Cells[0, 0].Value = "测试周期";
                    sheetLow.Cells[0, 1].Value = "插槽号";
                    sheetLow.Cells[0, 2].Value = "通道号";
                    sheetLow.Cells[0, 3].Value = "传感器编号";
                    sheetLow.Cells[0, 4].Value = "低压值";
                    sheetLow.Cells[0, 5].Value = "测试结果";

                    /*
                     * 周期 slot ch
                     * 0    0    0
                     * 0    0    1
                     * 
                     */
                    FileStream fs = File.Open(s, FileMode.OpenOrCreate);
                    StreamReader sr = new StreamReader(fs);
                    string l = sr.ReadLine();
                    if (l == null || l == "")
                    {
                        MessageBox.Show("没有数据需要导出.");
                        sr.Close();
                        fs.Close();
                        return;
                    }
                    int rowcountLow = 1;
                    int rowcountHight = 1;
                    do
                    {
                        string[] ss = l.Split(' ');
                        string flag = ss[0];
                        int cycle = int.Parse(ss[1]);
                        int slot = int.Parse(ss[2]);
                        int ch = int.Parse(ss[3]);
                        double val = double.Parse(ss[4]);
                        bool pass = bool.Parse(ss[5]);
                        string sensor_nm = ss[6];

                        if (flag == "H")
                        {
                            sheetHigh.Cells[rowcountHight, 0].Value = cycle;
                            sheetHigh.Cells[rowcountHight, 1].Value = slot;
                            sheetHigh.Cells[rowcountHight, 2].Value = ch;
                            sheetHigh.Cells[rowcountHight, 3].Value = sensor_nm;
                            sheetHigh.Cells[rowcountHight, 4].Value = val;
                            sheetHigh.Cells[rowcountHight, 5].Value = pass? "PASS" : "FAIL";
                        }
                        else if (flag == "L")
                        {
                            sheetLow.Cells[rowcountLow, 0].Value = cycle;
                            sheetLow.Cells[rowcountLow, 1].Value = slot;
                            sheetLow.Cells[rowcountLow, 2].Value = ch;
                            sheetLow.Cells[rowcountLow, 3].Value = sensor_nm;
                            sheetLow.Cells[rowcountLow, 4].Value = val;
                            sheetLow.Cells[rowcountLow, 5].Value = pass ? "PASS" : "FAIL";
                        }
                        else
                        {

                        }
                        rowcountHight++;
                        rowcountLow++;
                        l = sr.ReadLine();
                    } while (l != null && l != "");

                    book.Save(path);

                    sr.Close();
                    fs.Close();
                }
                catch (Exception ee)
                {
                    MessageBox.Show("导出失败." + ee.Message);
                    return;
                }
                MessageBox.Show("导出完成.");
            
            }
            catch(Exception ee)
            {
                MessageBox.Show(this, "读取记录错误." + ee.Message);

            }
        }

        private void labelCurrentTime_Click(object sender, EventArgs e)
        {

        }
    }
}
