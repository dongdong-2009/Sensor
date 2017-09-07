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
    public partial class FormConfig : Form
    {
        public CheckBox[] channelsSlotCks;      //插槽复选框
        public CheckBox[,] channelsCks;         //通道复选框
        private Dictionary<string, FormMain.ParamDesc> sensorParamTable;
        private Dictionary<string, FormMain.ParamDesc> testParamTable;
        bool[,] channelEnableTable;
        string[] channelNumbers;
        ComboBox selectComboBox;

        public FormConfig(
            Dictionary<string, FormMain.ParamDesc> sensorParamTable,    //传感器参数 
            Dictionary<string, FormMain.ParamDesc> testParamTable,      //测试参数
            bool[,] channelEnableTable,                                 //通道使能表
            string[] channelNumbers                                     //通道对于的传感器编号
            ) : base()

        {
            this.sensorParamTable = sensorParamTable;
            this.testParamTable = testParamTable;
            this.channelEnableTable = channelEnableTable;
            this.channelNumbers = channelNumbers;
            InitializeComponent();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {

            //检查传入的参数:
            if (sensorParamTable == null ||
                sensorParamTable.Count == 0 ||
                testParamTable == null ||
                testParamTable.Count == 0 ||
                channelEnableTable == null ||
                channelEnableTable.Length != 50 ||
                channelNumbers == null ||
                channelNumbers.Count() != 50      //现在是50

                )
                return;

            channelsSlotCks = new CheckBox[10];        //10个插槽
            channelsCks = new CheckBox[10, 5];         //50个通道         

            FormMain.addParamsToGrid(sensorParamsGrid, sensorParamTable);
            FormMain.addParamsToGrid(testParamsGrid, testParamTable);

            //禁止选中
            foreach (DataGridViewRow i in sensorParamsGrid.Rows)
            {
                i.Selected = false;
            }
            foreach (DataGridViewRow i in testParamsGrid.Rows)
            {
                i.Selected = false;
            }

            //建立复选框数组
            for (int slot = 0; slot < 10; slot++)
            {
                object obj;
                //建立插槽对于的复选框数组
                try
                {
                    obj = (CheckBox)this.GetType().GetField("checkBox" + (50 + slot + 1).ToString(),
                           System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this);
                }
                catch
                {
                    obj = null;
                }
                if (obj == null)
                {
                    MessageBox.Show("程序故障!");
                    Application.Exit();
                }
                channelsSlotCks[slot] = (CheckBox)obj;
                channelsSlotCks[slot].MouseClick += new System.Windows.Forms.MouseEventHandler(this.channelSlotCheckBox_MouseClick);
                channelsSlotCks[slot].Text = "";
                //建立通道对应的复选框数组
                for (int ch = 0; ch < 5; ch++)
                {
                    try
                    {
                        obj = (CheckBox)this.GetType().GetField("checkBox" + (ch * 10 + slot + 1).ToString(),
                            System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance).GetValue(this);
                    }
                    catch
                    {
                        obj = null;
                    }
                    if (obj == null)
                    {
                        MessageBox.Show("程序故障!");
                        Application.Exit();
                    }
                    channelsCks[slot, ch] = (CheckBox)obj;
                    channelsCks[slot, ch].MouseClick += new System.Windows.Forms.MouseEventHandler(this.channelCheckBox_MouseClick);
                    channelsCks[slot, ch].Text = "";

                    channelsSlotCks[slot].Tag = slot; //插槽标记上序号用于操作一组通道
                    channelsCks[slot, ch].Tag = channelsSlotCks[slot]; //将对应的插槽复选框对象标记到通道上
                }

                //通道编号
                channelsGrid.Rows.Clear();
                channelsGrid.Rows.Add(50);
                for (int i = 0; i < 50; i++)
                {
                    channelsGrid[0, i].Value = String.Format("{0:D2}插槽{1}端口", (i / 5 + 1), (i % 5 + 1));
                    channelsGrid[1, i].Value = channelNumbers[i];
                }


            }

            //配置复选框
            for (int slot = 0; slot < 10; slot++)
            {
                channelsSlotCks[slot].Checked = channelsCks[slot, 0].Checked;
                for (int ch = 0; ch < 5; ch++)
                {
                    channelsCks[slot, ch].Checked = channelEnableTable[slot, ch];
                    if (channelsCks[slot, ch].Checked != channelsSlotCks[slot].Checked)
                        channelsSlotCks[slot].CheckState = CheckState.Indeterminate;   //设为3态
                }
            }


            //默认的值
            prefixText.Text = "SN#";
            startText.Text = "0001";
            stepText.Text = "1";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //使能所有端口
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    channelsCks[i, j].Checked = true;
                }
            }
        }

        private void channelSlotCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            CheckBox slotChk = (CheckBox)sender;
            int slot = ((int)(slotChk.Tag));
            for (int ch = 0; ch < 5; ch++)
            {
                channelsCks[slot, ch].Checked = slotChk.Checked;
            }

        }

        private void channelCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            //任何通道操作,将影响插槽复选框
            ((CheckBox)(((CheckBox)sender).Tag)).CheckState = CheckState.Indeterminate;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string fixStr = prefixText.Text;
            string startStr = startText.Text;
            string stepStr = stepText.Text;
            string fmt;
            UInt64 start, step;
            fixStr = fixStr.Trim();
            startStr = startStr.Trim();
            stepStr = stepStr.Trim();
            if (fixStr=="") {
                MessageBox.Show("请输入固定的字符序列");
                return;
            }
            if (fixStr.Contains(" ")) {
                MessageBox.Show("固定的字符序列不应该包含空格");
                return;
            }
            if (startStr == "")
            {
                MessageBox.Show("请输入起始值");
                return;
            }
            if (stepStr == "")
            {
                MessageBox.Show("请输入步进量");
                return;
            }
            if (fixStr.Split('#').Count() > 2) {
                MessageBox.Show("警告:输入太多的#字符,只有首个#被序列代替.");
            }

            try
            {
                start = UInt64.Parse(startStr);
            }
            catch
            {
                MessageBox.Show("起始字符仅允许数字.");
                return;
            }
            try
            {
                step = UInt64.Parse(stepStr);
            }
            catch
            {
                MessageBox.Show("步进量仅允许数字.");
                return;
            }

            try
            {
                int n = fixStr.IndexOf("#");
                if (n < 0)
                    fmt = fixStr;
                else
                {
                    string left = fixStr.Substring(0, n);
                    string right = fixStr.Substring(n + 1, fixStr.Length - (n + 1));
                    fmt = left + "{0:D" + startStr.Length+ "}" + right;
                }
            }
            catch {
                MessageBox.Show("固定的字符序列中包含错误");
                return;
            }

           

            for (UInt64 i = 0; i < 50; i++)
            {
                channelsGrid[1, (int)i].Value = String.Format(fmt, start + i * step);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //DialogResult res = MessageBox.Show(this,"确认放弃修改?","提示", MessageBoxButtons.OKCancel);
            //if (res == DialogResult.Cancel)
            //    return;
            this.Close();
        }


        //保存参数按钮
        private void button2_Click(object sender, EventArgs e)
        {
           /*
            *这里不做参数合法性检查了,修改参数的时候已经检查过了 
            */
            DialogResult res = MessageBox.Show(this, "确认修改参数?", "提示", MessageBoxButtons.OKCancel);
            if (res == DialogResult.Cancel)
                return;
            //写数据到表格
            FormMain.writeParamsFromGrid(sensorParamTable, sensorParamsGrid);
            FormMain.writeParamsFromGrid(testParamTable, testParamsGrid);
            //设置通道有效性
            for (int slot = 0; slot < 10; slot++)
            {
                for (int ch = 0; ch < 5; ch++)
                {
                    channelEnableTable[slot, ch] = channelsCks[slot, ch].Checked;
                }
            }

            int count = channelsGrid.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                channelNumbers[i] = channelsGrid.Rows[i].Cells[1].Value.ToString();
                if (channelNumbers[i] == "")
                    channelNumbers[i] = "NoSet";
            }

            this.Close();
        }

        private void sensorParamsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string key = sensorParamsGrid[e.ColumnIndex - 1, e.RowIndex].Value.ToString();
            string value = sensorParamsGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
            double val;
            FormMain.ParamDesc paramDesc = sensorParamTable[key];
            if (paramDesc.isStrItem())
            {
                if (paramDesc.getStrList().Contains(value) == false)
                {
                    MessageBox.Show(this, "输入值不合法: "+ paramDesc.getFormat());
                }
            }
            else
            {
                if (double.TryParse(value, out val) == false)
                {
                    MessageBox.Show(this, "输入值不合法");
                    sensorParamsGrid[e.ColumnIndex, e.RowIndex].Value = paramDesc.getValue();
                    return;
                }

                if (val < paramDesc.getMin() || val > paramDesc.getMax())
                {
                    MessageBox.Show(this, String.Format("输入值超出范围 [{0},{1}]", paramDesc.getMin(), paramDesc.getMax()));
                    sensorParamsGrid[e.ColumnIndex, e.RowIndex].Value = paramDesc.getValue();
                    return;
                }
            }

        }
        private void testParamsGrid_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            DataGridViewCell keyCell = testParamsGrid[e.ColumnIndex - 1, e.RowIndex];
            DataGridViewCell valCell = testParamsGrid[e.ColumnIndex, e.RowIndex];
            string key = keyCell.Value.ToString();
            string value = valCell.Value.ToString();
            FormMain.ParamDesc paramDesc = testParamTable[key];
            if (paramDesc.isStrItem())
            {
                selectComboBox = new ComboBox();
                selectComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
                selectComboBox.Text = value;
                selectComboBox.Tag = valCell;
                selectComboBox.Items.AddRange(paramDesc.getStrList());
                selectComboBox.Parent = testParamsGrid;
                Rectangle rect = testParamsGrid.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                selectComboBox.Location = rect.Location;
                selectComboBox.Size = rect.Size;
                selectComboBox.Text = value;
                selectComboBox.TextChanged += Comb_TextChanged;
                selectComboBox.FormattingEnabled = true;
                selectComboBox.Show();
            }

        }

        private void Comb_TextChanged(object sender, EventArgs e)
        {
            ComboBox comb = (ComboBox)sender;
            DataGridViewCell valCell = (DataGridViewCell)(comb.Tag);
            valCell.Value = comb.Text;
        }

        private void testParamsGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (selectComboBox!=null)
            {
                selectComboBox.Hide();
                selectComboBox = null;
            }
            string key = testParamsGrid[e.ColumnIndex - 1, e.RowIndex].Value.ToString();
            string value = testParamsGrid[e.ColumnIndex, e.RowIndex].Value.ToString();
            double val;
            FormMain.ParamDesc paramDesc = testParamTable[key];
            if (paramDesc.isStrItem())
            {
                if (paramDesc.getStrList().Contains(value) == false)
                {
                    MessageBox.Show(this, "输入值不合法: " + paramDesc.getFormat());
                }
            }
            else
            {
                if (double.TryParse(value, out val) == false)
                {
                    MessageBox.Show(this, "输入值不合法");
                    testParamsGrid[e.ColumnIndex, e.RowIndex].Value = paramDesc.getValue();
                    return;
                }

                if (val < paramDesc.getMin() || val > paramDesc.getMax())
                {
                    MessageBox.Show(this, String.Format("输入值超出范围 [{0},{1}]", paramDesc.getMin(), paramDesc.getMax()));
                    testParamsGrid[e.ColumnIndex, e.RowIndex].Value = paramDesc.getValue();
                    return;
                }
            }
        }
        private void testParamsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void sensorParamsGrid_MouseUp(object sender, MouseEventArgs e)
        {
            //foreach (DataGridViewRow i in sensorParamsGrid.Rows)
            //{
            //    i.Selected = false;
            //}
        }

        private void testParamsGrid_MouseUp(object sender, MouseEventArgs e)
        {
            //foreach (DataGridViewRow i in sensorParamsGrid.Rows)
            //{
            //    i.Selected = false;
            //}
        }

        private void sensorParamsGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }


    }
}
