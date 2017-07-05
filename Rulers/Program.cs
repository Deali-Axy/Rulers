using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rulers
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {//启动前检测是否同互斥体冲突
            Mutex mutex = new Mutex(false, "Rulers");
            bool Running = !mutex.WaitOne(0, false);//关键
            if (!Running)
            {
                if (args.Length == 1 && args[0] == "-auto") { Ruler.isHide = true; }//自启动不显示窗口
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Ruler());
            }
            else
            {//激活已经存在的进程
                IntPtr HWnd = FindWindow(null, "Rulers");
                ShowWindow(HWnd, SW_SHOW);
                SetForegroundWindow(HWnd);
            }
        }
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        public const int SW_SHOW = 5;
    }
}
