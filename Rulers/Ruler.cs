using IWshRuntimeLibrary;
using Microsoft.Win32;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Rulers
{
    public partial class Ruler : Form
    {
        public Ruler()
        {
            InitializeComponent();
            #region  界面初始化
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true); // 双缓冲
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true); // 双缓冲   
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true); // 禁止擦除背景
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;//固定大小的工具窗口模式
            SetWindowLong(this.Handle, -16, 0);//隐藏标题栏
            this.Size = new Size(800, 60);//首次空命令界面
            listViewRuler.Columns.Add("Name", 655);//程序名称
            listViewRuler.Columns.Add("Path", 0);//程序快捷方式路径
            listViewRuler.Columns.Add("RealPath", 0);//程序真正路径
            listViewRuler.Columns.Add("Number", 100);//程序序号
            #endregion
            #region  AppData和ProgramData文件夹遍历
            for (int a = 0; a < 2; a++)//多一次循环载入会导致无法彻底去重
            {
                if (a == 0) { Address = AppData + @"\Microsoft\Windows\Start Menu\Programs\"; }
                if (a == 1) { Address = ProgramData + @"\Microsoft\Windows\Start Menu\Programs\"; }
                DirectoryInfo TheFolder = new DirectoryInfo(Address);
                DirectoryInfo[] DirInfo = TheFolder.GetDirectories();
                WshShell shell = new WshShell();
                //遍历母文件夹内文件
                foreach (FileInfo Files in TheFolder.GetFiles("*.lnk"))
                {
                    //if (Files.ToString().Contains(".lnk") == true)//仅仅载入快捷方式
                    {
                        ListViewItem item = listViewRuler.Items.Add(Files.Name.Replace(".lnk", ""));
                        item.SubItems.Add(Files.FullName);

                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(Files.FullName);
                        item.SubItems.Add(shortcut.TargetPath);
                        item.SubItems.Add((++x).ToString());
                    }
                }
                //遍历母文件夹内子文件夹
                foreach (DirectoryInfo NextFolder in DirInfo)
                {
                    FileInfo[] FileInfos = NextFolder.GetFiles();
                    //遍历母文件夹内子文件夹内文件
                    foreach (FileInfo NextFiles in FileInfos)
                    {
                        if (NextFiles.ToString().Contains(".lnk") == true)//仅仅载入快捷方式
                        {
                            ListViewItem item = listViewRuler.Items.Add(NextFiles.Name.Replace(".lnk", ""));
                            item.SubItems.Add(NextFiles.FullName);
                            IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(NextFiles.FullName);
                            item.SubItems.Add(shortcut.TargetPath);
                            item.SubItems.Add((++x).ToString());
                        }
                    }
                    //this.listBoxFolder.Items.Add(NextFolder.Name);
                    //遍历母文件夹内子文件夹的子文件夹
                    DirectoryInfo TheSubFolder = new DirectoryInfo(Address + NextFolder.Name.ToString());
                    DirectoryInfo[] SubDirInfo = TheSubFolder.GetDirectories();
                    foreach (DirectoryInfo NextSubFolder in SubDirInfo)
                    {
                        FileInfo[] SubFileInfos = NextSubFolder.GetFiles();
                        //遍历母文件夹内子文件夹内的子文件夹内文件
                        foreach (FileInfo NextSubFiles in SubFileInfos)
                        {
                            if (NextSubFiles.ToString().Contains(".lnk") == true)//仅仅载入快捷方式
                            {
                                ListViewItem item = listViewRuler.Items.Add(NextSubFiles.Name.Replace(".lnk", ""));
                                item.SubItems.Add(NextSubFiles.FullName);
                                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(NextSubFiles.FullName);
                                item.SubItems.Add(shortcut.TargetPath);
                                item.SubItems.Add((++x).ToString());
                            }
                        }
                    }
                }
            }
            #endregion
            #region  去除listViewRuler里的重复项目
            for (int a = 0; a < listViewRuler.Items.Count; a++)
            {
                for (int b = a + 1; b < listViewRuler.Items.Count; b++)
                {
                    if (listViewRuler.Items[a].SubItems[0].Text == (listViewRuler.Items[b].SubItems[0].Text))
                    {
                        listViewRuler.Items[b].Remove();
                        b--;//去除多个重复项目的关键
                    }
                }
            }
            #endregion
            #region  设置窗体图标
            string SelfPath = Application.ExecutablePath;//获取自身默认图标
            Icon icon = System.Drawing.Icon.ExtractAssociatedIcon(SelfPath);
            pictureBoxRuler.Image = icon.ToBitmap();
            this.Icon = icon;
            #endregion
        }
        #region  @全局定义
        [DllImport("user32")]//特效
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);
        private const int AW_HOR_POSITIVE = 1;//从左向右显示
        [DllImport("User32.dll", CharSet = CharSet.Auto)]//隐藏标题栏实现工具窗口模式
        public static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        Mutex mutex = new Mutex(false, "Rulers");
        int Amount;//列表可选数量
        int x = -1;//所以软件序号
        Point mouseOff;
        bool leftFlag;
        string Order;//输入的命令
        string Check;//选中的命令
        string RealPath;//图标匹配的文件路径,通过匹配后的FullPath赋值
        string Address = null;
        string ProgramData = System.Environment.GetEnvironmentVariable("ProgramData");//获取系统路径$ProgramData$=C:\ProgramData
        string AppData = System.Environment.GetEnvironmentVariable("AppData");//获取系统路径$AppData$=C:\Users\(用户名)\AppData
        void OpenCheck()//执行选中的命令
        {
            #region  确认要打开的文件
            this.Hide();//快速响应窗体隐藏
            try
            {
                System.Diagnostics.Process.Start(RealPath);//确定运行指定文件的完整路径
            }
            catch (Exception ex)//防止快捷方式错误或用户取消运行而报错
            {
                onMessage = ex.Message.ToString();
                isPass = false;
                ShowMessage();//系统通知
            }
            #endregion
        }
        void LocateCheck()//打开文件位置
        {
            #region  确定要打开的位置
            this.Hide();//快速响应窗体隐藏
            try
            {
                System.Diagnostics.Process.Start("explorer", "/select," + RealPath);//打开指定文件的文件位置并聚焦文件
            }
            catch (Exception ex)
            {
                onMessage = ex.Message.ToString();
                isPass = false;
                ShowMessage();//系统通知
            }
            #endregion
        }
        void GetPath()//根据选中的命令匹配路径
        {
            Check = listBoxRuler.SelectedItem.ToString();//重新选择项目后给Check赋值
            foreach (ListViewItem lt in listViewRuler.Items)
            {
                if (Check == lt.SubItems[0].Text)
                {
                    RealPath = lt.SubItems[1].Text;
                }
            }
        }
        void ShowMessage()//启用通知窗口
        {
            Hint h = new Hint();
            h.Show();
        }
        public void delay()//自启动隐藏窗口
        {
            this.Hide();
        }
        public static bool isHide;//启动时显示窗口与否
        public static string onMessage;//通知的消息
        public static bool isPass;//成功与否
        private void Ruler_Load(object sender, EventArgs e)
        {
            #region  窗口居上
            int height = System.Windows.Forms.SystemInformation.WorkingArea.Height;
            int width = System.Windows.Forms.SystemInformation.WorkingArea.Width;
            int newY = height / 5;
            int newX = width / 2 - this.Size.Width / 2;
            this.SetDesktopLocation(newX, newY);
            #endregion
            #region  窗口初始化且置顶
            //判断是否已经设置开机启动
            RegistryKey keys = Registry.LocalMachine.OpenSubKey(@"Software\microsoft\windows\currentversion\run", false);//false可读注册表但无权修改注册表
            object isStartup = keys.GetValue("Rulers");
            if (isStartup != null)
            {
                startupToolStripMenuItem.Checked = true;
            }
            if (Ruler.isHide == true)//开机启动且不显示窗口
            {
                this.BeginInvoke(new System.Threading.ThreadStart(delay));
            }
            else
            {
                AnimateWindow(Handle, 500, AW_HOR_POSITIVE);//从左向右显示特效
            }
            this.KeyPreview = true;//Alt+F4或ESC按键隐藏窗体前提
            listViewRuler.Visible = false;
            this.TopMost = true;
            #endregion
            #region  数据库排序
            listViewRuler.Sorting = SortOrder.Ascending;
            for (int i = 0; i < listViewRuler.Items.Count; i++)
            {
                listViewRuler.Items[i].SubItems[3].Text = i.ToString();
            }
            #endregion
        }
        #endregion
        #region  @细节处理
        private void listViewRuler_DoubleClick(object sender, EventArgs e)
        {
            RealPath = listViewRuler.FocusedItem.SubItems[1].Text;
            System.Diagnostics.Process.Start("explorer", "/select," + RealPath);//打开指定文件的文件位置
            this.Hide();//快速响应窗体隐藏
        }
        private void textBoxRuler_KeyDown(object sender, KeyEventArgs e)
        {
            if (Amount > 0)//可选项目不为空时执行操作
            {
                GetPath();//实时获取路径
                int choose = listBoxRuler.SelectedIndex;
                switch (e.KeyCode)
                {
                    case Keys.Enter://接受回车信息
                        OpenCheck();//运行文件
                        break;
                    case Keys.Up://向上聚焦
                        if (listBoxRuler.SelectedIndex <= 0)
                        {
                            choose = Amount;
                        }
                        choose--;
                        listBoxRuler.SelectedIndex = choose;
                        //始终聚焦到文本的最后一个字符的后面
                        System.Windows.Forms.SendKeys.Send("{Right}");//去除上下方向键的干扰
                        break;
                    case Keys.Down://向下聚焦
                        if (choose >= Amount - 1)
                        {
                            choose = -1;
                        }
                        choose++;
                        listBoxRuler.SelectedIndex = choose;
                        System.Windows.Forms.SendKeys.Send("{Right}");//去除上下方向键的干扰
                        break;
                    case Keys.Tab://Tab键实现下方向键
                        System.Windows.Forms.SendKeys.Send("{Down}");//变成下方向键
                        break;
                }
            }
        }
        private void textBoxRuler_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == System.Convert.ToChar(13))
            {
                e.Handled = true;//取消回车提示音
            }
            if (e.KeyChar == System.Convert.ToChar(9))
            {
                e.Handled = true;//取消Tab提示音
            }
            if (e.KeyChar == System.Convert.ToChar(27))
            {
                e.Handled = true;//取消ESC提示音
            }
        }
        private void Ruler_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.F4) && (e.Modifiers == Keys.Alt))
            {
                e.Handled = true;//防止被强制关闭
                this.Visible = false;
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Visible = false;
            }
        }
        #endregion
        #region  @右键菜单
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Restart();
        }
        private void donateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Diagnostics.Process.Start("http://tieba.baidu.com/p/4580165376");
        }
        private void updateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            System.Diagnostics.Process.Start("http://tieba.baidu.com/p/4580877280");
        }
        private void startupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (startupToolStripMenuItem.Checked == true)//取消开机自动启动
            {
                try
                {
                    RegistryKey key = Registry.LocalMachine.OpenSubKey(@"Software\microsoft\windows\currentversion\run", true);
                    object obj = key.GetValue("Rulers");
                    if (obj != null)
                    {
                        key.DeleteValue("Rulers");
                        startupToolStripMenuItem.Checked = false;
                        onMessage = "Cancel the Startup Success";
                        isPass = true;
                        ShowMessage();//系统通知
                    }
                    key.Close();
                }
                catch (Exception ex)
                {
                    onMessage = ex.Message.ToString();
                    isPass = false;
                    ShowMessage();//系统通知
                }
            }
            else//设置开机启动
            {
                try
                {
                    string startup = Application.ExecutablePath;
                    RegistryKey rKey = Registry.LocalMachine;
                    RegistryKey autoRun = rKey.OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run", true);
                    autoRun.SetValue("Rulers", startup + " -auto");//带参数启动标识开机启动
                    rKey.Close();
                    startupToolStripMenuItem.Checked = true;
                    onMessage = "Set the Startup Success";
                    isPass = true;
                    ShowMessage();//系统通知
                }
                catch (Exception ex)
                {
                    onMessage = ex.Message.ToString();
                    isPass = false;
                    ShowMessage();//系统通知
                }
            }
        }
        #endregion
        #region  @窗口移动
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        private void Ruler_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left & this.WindowState == FormWindowState.Normal)
            {
                this.Capture = false;
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void pictureBoxRuler_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                mouseOff = new Point(-e.X, -e.Y); //得到变量的值
                leftFlag = true;                  //按下左键时标记为true;
            }
        }
        private void pictureBoxRuler_MouseMove(object sender, MouseEventArgs e)
        {
            if (leftFlag)
            {
                Point mouseSet = Control.MousePosition;
                mouseSet.Offset(mouseOff.X - 748, mouseOff.Y - 12);  //设置移动后的位置
                this.Location = mouseSet;
            }
        }
        private void pictureBoxRuler_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Top < 0)
            {
                this.Location = new Point(this.Location.X, 0);
            }
            if (leftFlag)
            {
                leftFlag = false;//释放鼠标时标记为false;
            }
        }
        #endregion
        #region  @全局热键
        private const int WM_HOTKEY = 0x312; //窗口消息：热键
        private const int WM_CREATE = 0x1; //窗口消息：创建
        private const int WM_DESTROY = 0x2; //窗口消息：销毁
        private const int HotKeyID = 0x1000; //注册的热键ID
        protected override void WndProc(ref Message msg)
        {
            base.WndProc(ref msg);
            switch (msg.Msg)
            {
                case WM_HOTKEY: //窗口消息：响应热键
                    int tmpWParam = msg.WParam.ToInt32();
                    if (tmpWParam == HotKeyID)//Alt+Space 显示和隐藏
                    {//热键事件
                        if (this.Visible == true)
                        {
                            this.Visible = false;
                        }
                        else
                        {
                            this.Visible = true;
                            this.Activate();
                            this.textBoxRuler.SelectAll();
                        }
                    }
                    break;
                case WM_CREATE: //窗口消息：创建热键
                    SystemHotkey.RegHotKey(this.Handle, HotKeyID, SystemHotkey.KeyModifiers.Alt, Keys.Space);//注册Alt+Space
                    break;
                case WM_DESTROY: //窗口消息：销毁热键
                    SystemHotkey.UnRegHotKey(this.Handle, HotKeyID); //销毁热键
                    break;
            }
        }
        #endregion
        #region  @界面重绘
        private void listBoxRuler_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (listBoxRuler.Items.Count != 0)
            {
                e.Graphics.FillRectangle(Brushes.Black, e.Bounds);//未选中行背景色
                if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)//选中行背景色
                {
                    e.Graphics.FillRectangle(Brushes.HotPink, e.Bounds);
                }

                Image image = imageListRuler.Images[e.Index];//绘制图标 
                Graphics g = e.Graphics;
                Rectangle bounds = e.Bounds;
                Rectangle imageRect = new Rectangle(//初始化图标
                    bounds.X + 4,
                    bounds.Y + 6,//微调图标垂直居中
                                 //bounds.Height,//可以自定义图标宽度
                                 //bounds.Height//可以自定义图标高度
                    32,
                    32);
                Rectangle textRect = new Rectangle(//初始化文本
                    imageRect.Right,
                    bounds.Y,
                    bounds.Width,
                    bounds.Height);
                if (image != null)//载入图标
                {
                    g.DrawImage(
                        image,
                        imageRect,
                        0,
                        0,
                        image.Width,
                        image.Height,
                        GraphicsUnit.Pixel);
                }

                StringFormat strFormat = new StringFormat();//文本布局设置
                strFormat.LineAlignment = StringAlignment.Center;//文本垂直居中
                e.Graphics.DrawString(listBoxRuler.Items[e.Index].ToString(), e.Font, Brushes.White, textRect, strFormat);//设置文字颜色
            }
        }
        #endregion
        #region  @输入焦点
        private void listBoxRuler_Click(object sender, EventArgs e)
        {
            textBoxRuler.Focus();
            GetPath();//实时获取路径
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Tab://防止输入框因为Tab失去聚焦
                    textBoxRuler.Focus();
                    return false;
            }
            return base.ProcessDialogKey(keyData);
        }
        private void listBoxRuler_DoubleClick(object sender, EventArgs e)
        {
            textBoxRuler.Focus();//双击后返回聚焦
            LocateCheck();//打开文件位置
        }
        #endregion
        private async void textBoxRuler_TextChanged(object sender, EventArgs e)
        {
            #region  所有搜索引擎
            listBoxRuler.Items.Clear();//清空所有列举选项并重新载入
            imageListRuler.Images.Clear();//情况所有图标重新匹配
            Order = textBoxRuler.Text;//给Order赋值
            if (Order.Length > 1)//大于一个字符给予搜索
            {
                foreach (ListViewItem lt in listViewRuler.Items)
                {
                    string strSearchResults = lt.SubItems[0].Text;//获取待匹配数据(普通匹配查询引擎)
                    string strWord = await SearchEngines.GeneralQueryAsync(strSearchResults);//获取英文首字母缩写(英文首字母查询引擎)
                    string strAcronym = await ChineseQuery.GetChineseSpellAsync(strSearchResults); //获得各汉字拼音首字母缩写(拼音首字母查询引擎)
                    if (strSearchResults.ToUpper().Contains(Order.ToUpper()) || strWord.Contains(Order.ToUpper()) || strAcronym.Contains(Order.ToUpper()))
                    {
                        try
                        {
                            Icon icon = await GetIcon(lt.SubItems[2].Text);
                            imageListRuler.Images.Add(icon);//载入对应图标
                            listBoxRuler.Items.Add(strSearchResults.Replace(".lnk", ""));//载入搜索结果
                            listBoxRuler.SelectedIndex = 0;//默认选择第一行防止获取获取选中项目出错
                        }
                        catch { }
                    }
                }
            }
            #endregion
            #region  窗体大小随数据多少而改变
            Amount = listBoxRuler.Items.Count;//列表全部加载完成后赋值列表可选数量
            switch (Amount)
            {
                case 0:
                    this.Size = new Size(800, 60);
                    break;
                case 1:
                    this.Size = new Size(800, 125);
                    this.listBoxRuler.Size = new Size(776, 50);
                    break;
                case 2:
                    this.Size = new Size(800, 175);
                    this.listBoxRuler.Size = new Size(776, 100);
                    break;
                case 3:
                    this.Size = new Size(800, 225);
                    this.listBoxRuler.Size = new Size(776, 150);
                    break;
                case 4:
                    this.Size = new Size(800, 275);
                    this.listBoxRuler.Size = new Size(776, 200);
                    break;
                case 5:
                    this.Size = new Size(800, 325);
                    this.listBoxRuler.Size = new Size(776, 250);
                    break;
                case 6:
                    this.Size = new Size(800, 375);
                    this.listBoxRuler.Size = new Size(776, 300);
                    break;
                default:
                    this.Size = new Size(800, 375);
                    this.listBoxRuler.Size = new Size(776, 300);
                    break;
            }
            #endregion
            #region  内置命令界面初始化
            if (Order.ToUpper() == "ADMIN")//高级预览界面
            {
                Amount = 0;//拒绝空项目运行
                this.Size = new Size(800, 375);//恢复大小可选择执行操作
                listBoxRuler.Visible = false;
                listViewRuler.Visible = true;
            }
            else
            {
                listBoxRuler.Visible = true;
                listViewRuler.Visible = false;
            }
            #endregion
        }

        private Task<Icon> GetIcon(string filePath)
        {
            Task<Icon> t = new Task<Icon>(() =>
            {
                if (filePath.Length > 0 && System.IO.File.Exists(filePath))
                    return Icon.ExtractAssociatedIcon(filePath);
                else
                    return null;
            });

            t.Start();
            return t;
        }
    }
}
