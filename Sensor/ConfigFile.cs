using System;
using hxUtils;

public class Config : INIConfig
{
    public string rem_配置文件版本
     = "说明: \n"
     + "1. 删除该配置文件后应用程序一般会自动重新生成一个新的,并设置每个配置项为默认参数\n"
     + "2. 配置文件按行读取,每一行一个配置项\n"
     + "3. 符号\"#\"之后直到一行末尾为注释,对应用程序无任何影响.\n"
     + "4. 不建议直接修改配置文件.\n";
    public string 配置文件版本 = "0.3";

    public class Section_传感器参数
    {
        public double 传感器量程最小值 = -1000.000;
        public double 传感器量程最大值 = 1000.000;
        public double 传感器输出电压最小值 = 0.01;
        public double 传感器输出电压最大值 = 12.00;
        public double 传感器精度 = 0.01;
        public double 传感器供电电压 = 12.00;

    }

    public string rem_传感器参数
        = "======================================================";
    public Section_传感器参数 传感器参数 = new Section_传感器参数();


    public class Section_测试参数 { 
        public int 老化周期数 = 1;
        public string rem_传感器精度 = "传感精度设置不加百分号, 如0.01代表1%. 范围从0.001 到 10.000";
        public double 传感器精度 = 0.01;
        public double 充气高压压力 = 1000.000;
        public int 充气高压时间 = 1;
        public int 排气静置时间 = 1;

    }

    public string rem_测试参数
        = "======================================================";
    public Section_测试参数 测试参数 = new Section_测试参数();



    public class Section_设备参数
    { 
        public string 禁用的通道 = "0,1";
        public string 设备标签 = "SN0 SN1";

    }

    public string rem_设备参数
        = "======================================================";
    public Section_设备参数 设备参数 = new Section_设备参数();
}