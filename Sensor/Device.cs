using hxTestTool;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using static Sensor.FormMain;

namespace Sensor
{
    enum DevAddress
    {
        VOLTMETER = 'V',
        AMMETER = 'A',
        THERMOMETER = 'T',
        PRESSURE_GAUGE = 'P',
        DOUT_ONBOARD = 'O',
        DIN_ONBOARD = 'I',
        POWER_SUPPLY = 'S',
        UNIVERSAL_DIGITAL_INTERFACE = 'D',
        SWITCH_BOARD_0 = '0',
        SWITCH_BOARD_1 = '1',
        SWITCH_BOARD_2 = '2',
        SWITCH_BOARD_3 = '3',
        SWITCH_BOARD_4 = '4',
        SWITCH_BOARD_5 = '5',
        SWITCH_BOARD_6 = '6',
        SWITCH_BOARD_7 = '7',
        SWITCH_BOARD_8 = '8',
        SWITCH_BOARD_9 = '9',
    }
    enum DevFunction
    {
        GET_VOLTAGE = 'a',
        SET_V_SCALE = 'b',
        GET_VOLTAGE_CALIBRATED = 'c',
        SET_VOLTMETER_CP = 'd',
        GET_CURRENT = 'e',
        SET_I_SCALE = 'f',
        GET_CURRENT_CALIBRATED = 'g',
        SET_AMMETER_CP = 'h',
        GET_TEMPERATURE = 'i',
        GET_TEMPERATURE_CALIBRATED = 'j',
        SET_THERMOMETER_CP = 'k',
        GET_PRESSURE = 'l',
        GET_PRESSURE_CALIBRATED = 'm',  
        SET_PRESSURE_GAUGE_CP = 'n',
        SET_DOUT_STA = 'o',
        GET_DIN_STA = 'p',
        SET_POWER_SUPPLY_VOLTAGE = 'q',
        GET_POWER_SUPPLY_VOLTAGE = 'r',
        SET_SWITCH_CHANNEL = 's',
        ACK = 't',
    }
    enum DevChannel
    {
        CH0 = '0',
        CH1 = '1',
        CH2 = '2',
        CH3 = '3',
        CH4 = '4',
        CH5 = '5',
        CH6 = '6',
        CH7 = '7',
        CH_ALL = 'a',
        CH_NONE = 'n',
    };
   
    class Device
    {
        Mutex mut = new Mutex();
        ComPort ser = null;

        public bool Connect()
        {
            mut.WaitOne();
            ser = new ComPort();
            ser.Baudrate = 115200;
            ser.Close();
            if (ser.Open(1) == false)
            {
                ser.Close();
                ser = null;
                mut.ReleaseMutex();
                return false;
            }
            mut.ReleaseMutex();
            return true;
        }
        public void Disconnect()
        {
            mut.WaitOne();
            if (ser != null)
            {
                ser.Close();
                ser = null;
            }
            mut.ReleaseMutex();
        }
        ~Device()
        {
            if (ser!=null)
            {
                ser.Close();
                ser = null;
            }
        }

        /// <summary>
        /// 与设备通讯
        /// </summary>
        /// <param name="devAddr">设备地址</param>
        /// <param name="devFunc">设备功能</param>
        /// <param name="devCh">通道</param>
        /// <param name="data">数据</param>
        /// <returns>返回接受到的结果</returns>
        public string command(DevAddress devAddr, DevFunction devFunc, DevChannel devCh, string data)
        {
            {
                return "1000";
            }
            if (ser == null)
            {
                throw new Exception("内部错误,无效的串口对象");
            }
            mut.WaitOne();
            ser.Recive(1024, 1);    //clear rbuffer
            string cmdstr = String.Format("+{0}{1}{2}{3}{4}-", 
                data.Length, 
                ((char)devAddr).ToString(), 
                ((char)devFunc).ToString(),
                ((char)devCh).ToString(),
                data);

            int trys = 3;
            while (trys-- > 0)
            {
                try
                {
                    ser.Send(cmdstr);
                    string resstr = ser.ReciveString(500);
                    int n = resstr.IndexOf("#");                        //检查开始字符
                    string slen = resstr.Substring(n + 1, 1);           //获取长度
                    int len = int.Parse(slen);
                    DevAddress addr = (DevAddress)(resstr[n + 2]);
                    DevFunction func = (DevFunction)(resstr[n + 3]);
                    DevChannel ch = (DevChannel)(resstr[n + 4]);
                    if (addr != devAddr || func != devFunc || ch != devCh)      //判断回复是否一致
                        throw new Exception();
                    string res = len>0?resstr.Substring(n + 5, len):"";     //获取返回结果数据
                    string end = resstr.Substring(n + 5 + len, 1);      //检查结尾字符
                    if (end != "*")
                        throw new Exception();
                    mut.ReleaseMutex();
                    return res;                 //成功返回
                }
                catch {
                    continue;
                }
            }
            mut.ReleaseMutex();
            throw new Exception("Device send command, but recive error, cmd: " + cmdstr);
        }

        internal void closeAllChannel()
        {
            for (DevAddress devAddr = DevAddress.SWITCH_BOARD_0; devAddr <= DevAddress.SWITCH_BOARD_9; devAddr++)
            {
                command(devAddr, DevFunction.SET_SWITCH_CHANNEL, DevChannel.CH_ALL, "0");
            }
        }

        internal void enablePressure()
        {
            command(DevAddress.DOUT_ONBOARD, DevFunction.SET_DOUT_STA, DevChannel.CH_NONE, "1");
        }
        internal void disablePressure()
        {
            command(DevAddress.DOUT_ONBOARD, DevFunction.SET_DOUT_STA, DevChannel.CH_NONE, "0");
        }
        internal void setPowerVoltage(double volt)
        {
            string s = String.Format("{0:D4}", (int)(volt*100));   //12.00f -> 1200
            command(DevAddress.POWER_SUPPLY, DevFunction.SET_POWER_SUPPLY_VOLTAGE, DevChannel.CH_NONE, s);
        }

        internal void selectSlotChannel(int slot, int ch)
        {
            command(DevAddress.SWITCH_BOARD_0 + slot, DevFunction.SET_SWITCH_CHANNEL, DevChannel.CH0 + ch, "1");
        }

        internal double getTestVoltage()
        {
            string res = command(DevAddress.VOLTMETER, DevFunction.SET_DOUT_STA, DevChannel.CH_NONE, "1");
            return (double.Parse(res)/100);     //1200 -> 12.00f
        }

        internal void closeSlotChannel(int slot, int ch)
        {
            command(DevAddress.SWITCH_BOARD_0 + slot, DevFunction.SET_SWITCH_CHANNEL, DevChannel.CH0 + ch, "0");
        }

        internal double getSourcePressure()
        {
            string res = command(DevAddress.PRESSURE_GAUGE, DevFunction.GET_PRESSURE_CALIBRATED, DevChannel.CH0, "");
            return (double.Parse(res) / 1000);     //1000 -> 1.000f
        }

        internal double getInnerPressure()
        {
            string res = command(DevAddress.PRESSURE_GAUGE, DevFunction.GET_PRESSURE_CALIBRATED, DevChannel.CH1, "");
            return (double.Parse(res) / 1000);     //1000 -> 1.000f
        }
        internal bool findSlot(int v)
        {
            try
            {
                string res = command(DevAddress.SWITCH_BOARD_0 + v, DevFunction.ACK, DevChannel.CH_NONE, "");
                if (res == "")  //只有回应正确,并且无数据为ok
                    return true;
            }
            catch
            {
                //超时或收到不对
            }
            return false;
        }

        internal void pause()
        {
            mut.WaitOne();

        }

        internal void resume()
        {
            mut.ReleaseMutex();
        }


    }
}
