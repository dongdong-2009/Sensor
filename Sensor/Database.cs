using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Sensor
{
    class Database
    {
        FileStream fs;
        StreamWriter sw;
        public static string lastRecordPath = "";
        public static string lastRecordDateTime = "";

        public void create()
        {
            try
            {
                DateTime now = DateTime.Now;
                string path = Environment.CurrentDirectory + "\\" + now.ToString("rec_yyyyMMdd") + "\\";
                Directory.CreateDirectory(path);
                path += now.ToString("HHmmss") + ".txt";
                fs = File.Open(path, FileMode.OpenOrCreate);
                sw = new StreamWriter(fs);
                sw.AutoFlush = true;
                lastRecordPath = path;
                lastRecordDateTime = now.ToString("yyyy-MM-dd HH.mm.ss");
            }
            catch (Exception e)
            {
                MessageBox.Show("创建数据文件出错:" + e.Message);
            }
        }
        public void close()
        {
        }
        internal void insertLowTestVal(int cycle, int slot, int ch, string sensor_nm, double lowval, bool lpass)
        {

            string s = "L " + cycle + " " + slot +" "+ ch + " " + lowval + " " + lpass + " " + sensor_nm;
            sw.WriteLine(s);
        }

        internal void insertHightTestVal(int cycle, int slot, int ch, string sensor_nm, double highval, bool hpass)
        {
            string s = "H " + cycle + " " + slot + " " + ch + " " + highval + " " + hpass + " " + sensor_nm;
            sw.WriteLine(s);
        }

        
    }
}
