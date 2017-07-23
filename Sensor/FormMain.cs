using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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


            //默认参数
            //传感器参数
            sensorParamTable.Add("传感器量程最小值", new ParamDesc(0.001, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            sensorParamTable.Add("传感器量程最大值", new ParamDesc(0.001, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            sensorParamTable.Add("传感器输出电压最小值", new ParamDesc(0.01, "0.00", "V", 0.01, 12.00, 0.01));
            sensorParamTable.Add("传感器输出电压最大值", new ParamDesc(0.01, "0.00", "V", 0.01, 12.00, 0.01));
            sensorParamTable.Add("传感器精度", new ParamDesc(0.01, "0.00", "%", 0.01, 10.00, 0.01));

            //测试参数
            testParamTable.Add("传感器压力测量范围最小值", new ParamDesc(0.001, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));      //步进多少
            testParamTable.Add("传感器压力测量范围最大值", new ParamDesc(0.001, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            testParamTable.Add("传感器供电电压", new ParamDesc(0.01, "0.00", "V", 0.01, 12.00, 0.01));               //范围不进
            testParamTable.Add("老化周期数", new ParamDesc(1, "", "次", 1, 10000, 1));
            testParamTable.Add("充气(高压)压力", new ParamDesc(0.001, "0.000", "Mpa", -1000.000f, 1000.000f, 0.001));
            testParamTable.Add("充气(高压)时间", new ParamDesc(1, "", "秒", 1, 200, 1));
            testParamTable.Add("排气(静置)时间", new ParamDesc(1, "", "秒", 1, 200, 1));


            //传感器编号
            for (int i = 0; i < 50; i++)
                channelNumbers[i] = "NoSet";

            //状态
            for (int i = 0; i < 50; i++)
            {
                channelsCrid[stateCol.Index, i].Value = "未知";
            }

            //使能
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    channelEnableTable[i, j] = true;
                }
            }

            //编号
            for (int i = 0; i < 50; i++) {
                channelsCrid[channelCol.Index, i].Value = String.Format("{0:D2}插槽{1}端口", (i / 5 + 1), (i % 5 + 1));
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

            UpdateDisp();

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


    }
}
