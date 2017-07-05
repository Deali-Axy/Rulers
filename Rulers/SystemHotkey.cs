using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rulers
{
    public class SystemHotkey
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        public enum KeyModifiers { None = 0, Alt = 1, Ctrl = 2, Shift = 4, WindowsKey = 8 }
        //注册热键以及占用报错
        public static void RegHotKey(IntPtr hwnd, int hotKeyId, KeyModifiers keyModifiers, Keys key)
        {
            if (!RegisterHotKey(hwnd, hotKeyId, keyModifiers, key))
            {
                int errorCode = Marshal.GetLastWin32Error();
                if (errorCode == 1409)//占用导致注册失败提示
                {
                    Ruler.onMessage = "Hotkey 'Alt+Space' Occupied!";
                    Ruler.isPass = false;
                    Hint h = new Hint();
                    h.Show();
                }
                else//其他原因导致注册失败提示
                {
                    Ruler.onMessage = "Alt+Space Error：" + errorCode;
                    Ruler.isPass = false;
                    Hint h = new Hint();
                    h.Show();
                }
            }
        }
        //注销指定的热键
        public static void UnRegHotKey(IntPtr hwnd, int hotKeyId)
        {
            UnregisterHotKey(hwnd, hotKeyId);
        }
    }
}
