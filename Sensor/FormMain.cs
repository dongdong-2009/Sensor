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
                value = Convert.ToDouble(v);
            }
        }

        public Dictionary<String, ParamDesc> sensorParamTable = new Dictionary<string, ParamDesc>();        //传感器参数表
        public Dictionary<String, ParamDesc> testParamTable = new Dictionary<string, ParamDesc>();          //测试参数表
        public bool[,] channelEnableTable = new bool[10, 5];        //通道使能表
        string[] channelNumbers = new string[50];                   //传感器编号
        Config config;              //配置文件
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

            //禁止选中
            foreach (DataGridViewRow i in sensorParamsGrid.Rows){
                i.Selected = false;
            }
            foreach (DataGridViewRow i in testParamsGrid.Rows)
            {
                i.Selected = false;
            }
            foreach (DataGridViewRow i in channelsCrid.Rows)
            {
                i.Selected = false;
            }

            LoadConfig();
            UpdateDisp();

        }
        private void LoadConfig()
        {
            config = new Config();
            config.LoadIniFileInCurDir("default.cfg");
            //默认参数
            //传感器参数
            sensorParamTable.Add("传感器量程最小值", new ParamDesc(config.传感器参数.传感器量程最小值, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            sensorParamTable.Add("传感器量程最大值", new ParamDesc(config.传感器参数.传感器量程最大值, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            sensorParamTable.Add("传感器输出电压最小值", new ParamDesc(config.传感器参数.传感器输出电压最小值, "0.00", "V", 0.01, 12.00, 0.01));
            sensorParamTable.Add("传感器输出电压最大值", new ParamDesc(config.传感器参数.传感器输出电压最大值, "0.00", "V", 0.01, 12.00, 0.01));
            sensorParamTable.Add("传感器精度", new ParamDesc(config.传感器参数.传感器精度, "0.00", "%", 0.01, 10.00, 0.01));
            sensorParamTable.Add("传感器供电电压", new ParamDesc(config.传感器参数.传感器供电电压, "0.00", "V", 0.01, 12.00, 0.01));

            //测试参数
            testParamTable.Add("传感器压力测量范围最小值", new ParamDesc(config.测试参数.传感器压力测量范围最小值, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));      //步进多少
            testParamTable.Add("传感器压力测量范围最大值", new ParamDesc(config.测试参数.传感器压力测量范围最大值, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            testParamTable.Add("传感器供电电压", new ParamDesc(config.测试参数.传感器供电电压, "0.00", "V", 0.01, 12.00, 0.01));               //范围不进
            testParamTable.Add("老化周期数", new ParamDesc(config.测试参数.老化周期数, "", "次", 1, 10000, 1));
            testParamTable.Add("充气(高压)压力", new ParamDesc(config.测试参数.充气高压压力, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            testParamTable.Add("充气(高压)时间", new ParamDesc(config.测试参数.充气高压时间, "", "秒", 1, 200, 1));
            testParamTable.Add("排气(静置)时间", new ParamDesc(config.测试参数.排气静置时间, "", "秒", 1, 200, 1));


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
                            if (int.Parse(ss[i]) == (slot * 10 + ch))
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

            config.测试参数.传感器压力测量范围最小值 = testParamTable["传感器压力测量范围最小值"].getValue2();
            config.测试参数.传感器压力测量范围最大值 = testParamTable["传感器压力测量范围最大值"].getValue2();
            config.测试参数.传感器供电电压 = testParamTable["传感器供电电压"].getValue2();
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
                        config.设备参数.禁用的通道 += "" + (slot * 10 + ch) + ",";
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

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            config.SaveIniFile();
            config = null;
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
        volatile bool runFlag =true;
        Thread testThread = null;
        Device dev = null;
        void testProc()
        {
            dev = new Device(this);
            while (runFlag)
            {
                try
                {
                    dev.closeAllChannel();
                    dev.setPowerVoltage(config.传感器参数.传感器供电电压);
                    dev.enablePressure();
                    Thread.Sleep(500);
                    for (int slot = 0; slot < 10; slot++)
                    {
                        for (int ch = 0; ch < 5; ch++)
                        {
                            if (runFlag == false)
                                goto end;
                            dev.selectSlotChannel(slot, ch);
                            Thread.Sleep(200);
                            double v = dev.getTestVoltage();

                            if(ch==4)
                                dev.closeSlotChannel(slot,ch);  //最後一個通道是需要關閉的.
                        }
                        
                    }
                    dev.disablePressure();
                    Thread.Sleep(500);
                    for (int slot = 0; slot < 10; slot++)
                    {
                        for (int ch = 0; ch < 5; ch++)
                        {
                            if (runFlag == false)
                                goto end;
                            dev.selectSlotChannel(slot, ch);
                            Thread.Sleep(200);
                            double v = dev.getTestVoltage();

                            if (ch == 4)
                                dev.closeSlotChannel(slot, ch);  //最後一個通道是需要關閉的.
                        }

                    }
                end:;
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    runFlag = false;
                }
            }
        }
        private void startBtn_Click(object sender, EventArgs e)
        {
            testThread = new Thread(new ThreadStart(testProc));
            testThread.Start();
        }

        private void pauseBtn_Click(object sender, EventArgs e)
        {

        }

        private void stopBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
