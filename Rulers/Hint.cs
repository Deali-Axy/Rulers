using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rulers
{
    public partial class Hint : Form
    {
        public Hint()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;//固定大小的工具窗口模式
            SetWindowLong(this.Handle, -16, 0);//隐藏标题栏
            this.Size = new Size(360,85);
            this.BackColor = Color.FromArgb(31, 31, 31);
            #region  设置Logo图标
            string SelfPath = Application.ExecutablePath;//获取自身默认图标
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(SelfPath);
            pictureBoxLogo.Image = icon.ToBitmap();
            this.Icon = icon;
            #endregion
        }
        #region  @全局定义
        [DllImport("user32")]//特效
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HIDE = 0x10000;
        private const int AW_SLIDE = 0x40000;
        private const int AW_HOR_POSITIVE = 0x0001;//从左向右显示
        private const int AW_HOR_NEGATIVE = 0x0002;//从右向左显示
        [DllImport("User32.dll", CharSet = CharSet.Auto)]//隐藏标题栏实现工具窗口模式
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        System.Timers.Timer time = new System.Timers.Timer(3000);
        #endregion
        private void Hint_Load(object sender, EventArgs e)
        {
            #region   通知消息
            labelMessage.Text = Ruler.onMessage;
            int gLeft = this.Width / 2 - labelMessage.Width / 2;
            labelMessage.Location = new Point(gLeft + 32, 45);
            if (Ruler.isPass == false)
            {
                labelMessage.ForeColor = Color.Red;
            }
            else
            {
                labelMessage.ForeColor = Color.Aqua;
            }
            #endregion
            #region  窗口右下方
            int height = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            int width = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            int newY = height * 4 / 5;
            int newX = width - 360;
            this.SetDesktopLocation(newX, newY);
            AnimateWindow(Handle, 100, AW_HOR_NEGATIVE);//从左向右显示特效
            #endregion
            time.Enabled = true;
            time.Elapsed += new System.Timers.ElapsedEventHandler(TimePoc);
        }
        void TimePoc(object sender, System.Timers.ElapsedEventArgs e)
        {
            AnimateWindow(this.Handle, 200, AW_SLIDE | AW_HIDE | AW_HOR_POSITIVE);//从右往左隐藏特效
            this.Dispose();//延时关闭
        }
        private void Hint_MouseLeave(object sender, EventArgs e)
        {
            if (!this.Bounds.Contains(Cursor.Position))//防止在窗体内
            {
                time.Enabled = true;
            }
        }
        private void Hint_MouseEnter(object sender, EventArgs e)
        {
            time.Enabled = false;
        }
    }
}
