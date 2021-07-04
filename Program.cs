using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace cmd_try
{
    class Program
    {
        static void Main(string[] args)
        {
            isNet();//启动时运行一下函数
            static void isNet() {
                try
                {
                    IPAddress ip = Dns.GetHostAddresses("baidu.com")[0];//断网情况下这个方法会报错，后面代码也就不会去执行了，可以算是很特别的if语句

                    //我是用来开机自启动运行frp，这个代码仅供参考
                    //RunCmd("D:\\Programs\\frp_0.29.0_windows_amd64\\frpc.exe -c D:\\Programs\\frp_0.29.0_windows_amd64\\frpc.ini");
                }
                catch (Exception)//本是用来捕抓错误，被我当做if判断
                {
                    //Console.WriteLine("未联网");//这个输出是方便测试，另外这个软件是控制台程序，但是我到项目属性把他改成了窗口程序，这样就不会有窗口显示，
                    System.Threading.Thread.Sleep(5000);//延迟5s
                    isNet();//报错就一直就回调自己
                }
            }

            static void RunCmd(string command)//运行cmd命令
            {
                //例Process
                Process p = new Process();

                p.StartInfo.FileName = "cmd.exe";           //确定程序名
                p.StartInfo.Arguments = "/k " + command;    //确定程式命令行，/k是窗口关闭后仍会运行，/c是窗口关闭后停止运行
                p.StartInfo.UseShellExecute = false;        //Shell的使用
                p.StartInfo.RedirectStandardInput = true;   //重定向输入
                p.StartInfo.RedirectStandardOutput = true; //重定向输出，这个false的话内容就会输出到这个程序的控制台窗口内，方便调试
                p.StartInfo.RedirectStandardError = true;   //重定向输出错误
                p.StartInfo.CreateNoWindow = true;          //设置置不显示示窗口¿

                p.Start();   //运行cmd命令
            }


        }


    }
}
