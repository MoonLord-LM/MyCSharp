namespace My
{
    using System;
    using System.IO;
    using System.Text;
    using System.Drawing;
    using System.Threading;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;

    /// <summary>
    /// 窗口管理、控制相关函数
    /// </summary>
    /// <remarks></remarks>
    public sealed partial class Window
    {

        [DllImport("user32.dll", EntryPoint = "FindWindowA", SetLastError = true)]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "GetForegroundWindow", SetLastError = true)]
        private static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll", EntryPoint = "GetParent", SetLastError = true)]
        private static extern IntPtr GetParent(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint", SetLastError = true)]
        private static extern IntPtr WindowFromPoint(Point Point);

        /// <summary>
        /// 获取系统焦点窗口的窗口句柄
        /// </summary>
        /// <returns>结果窗口句柄（IntPtr）</returns>
        /// <remarks></remarks>
        public static IntPtr FindFocus()
        {
            return GetForegroundWindow();
        }
        /// <summary>
        /// 获取父窗口的窗口句柄
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果窗口句柄（IntPtr）</returns>
        /// <remarks></remarks>
        public static IntPtr FindParent(IntPtr hWnd)
        {
            return GetParent(hWnd);
        }
        /// <summary>
        /// 获取鼠标位置的窗口句柄
        /// </summary>
        /// <returns>结果窗口句柄（IntPtr）</returns>
        /// <remarks></remarks>
        public static IntPtr FindByMouse()
        {
            return WindowFromPoint(Control.MousePosition);
        }
        /// <summary>
        /// 获取指定位置的窗口句柄
        /// </summary>
        /// <param name="Position">相对于屏幕的位置（Point）</param>
        /// <returns>结果窗口句柄（IntPtr）</returns>
        /// <remarks></remarks>
        public static IntPtr FindByPoint(Point Position)
        {
            return WindowFromPoint(Position);
        }
        /// <summary>
        /// 根据窗口标题，获取窗口句柄（当有多个标题相同的窗体存在时，默认获取上一个活动的窗体）
        /// </summary>
        /// <param name="Title">窗口标题（字符串必须完全相同）</param>
        /// <returns>结果窗口句柄（IntPtr）</returns>
        /// <remarks></remarks>
        public static IntPtr FindByTitle(string Title)
        {
            return FindWindow(null, Title);
        }
        /// <summary>
        /// 根据窗口类名，获取窗口句柄（当有多个类名相同的窗体存在时，默认获取上一个活动的窗体）
        /// </summary>
        /// <param name="ClassName">窗口类名（字符串必须完全相同）</param>
        /// <returns>结果窗口句柄（IntPtr）</returns>
        /// <remarks></remarks>
        public static IntPtr FindByClassName(string ClassName)
        {
            return FindWindow(ClassName, null);
        }
        /// <summary>
        /// 根据进程名称，获取窗口句柄
        /// </summary>
        /// <param name="TaskName">进程名称（不含".exe"后缀）</param>
        /// <returns>结果窗口句柄（IntPtr）</returns>
        /// <remarks></remarks>
        public static IntPtr FindByTaskName(string TaskName)
        {
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.ToLower() == TaskName.ToLower())
                {
                    return process.MainWindowHandle;
                }
            }
            return new IntPtr(0);
        }
        /// <summary>
        /// 根据进程文件路径，获取窗口句柄
        /// </summary>
        /// <param name="FilePath">文件路径（可以是相对路径）</param>
        /// <returns>结果窗口句柄（IntPtr）</returns>
        /// <remarks></remarks>
        public static IntPtr FindByFilePath(string FilePath)
        {
            Process[] processes = Process.GetProcesses();
            if (!FilePath.Contains(":"))
            {
                FilePath = Directory.GetCurrentDirectory() + @"\" + FilePath;
            }
            foreach (Process process in processes)
            {
                try
                {
                    if (process.MainModule.FileName.ToLower() == FilePath.ToLower())
                    {
                        return process.MainWindowHandle;
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return new IntPtr(0);
        }
        /// <summary>
        /// 搜索窗口标题，获取窗口句柄（优先搜索字符串完全相同的，然后搜索包含有指定字符串的）
        /// </summary>
        /// <param name="Title">窗口标题（字符串不必完全相同）</param>
        /// <returns>结果窗口句柄（IntPtr）</returns>
        /// <remarks></remarks>
        public static IntPtr SearchByTitle(string Title)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle.ToLower() == Title.ToLower())
                {
                    return process.MainWindowHandle;
                }
            }
            foreach (Process process2 in processes)
            {
                if (process2.MainWindowTitle.ToLower().Contains(Title.ToLower()))
                {
                    return process2.MainWindowHandle;
                }
            }
            return new IntPtr(0);
        }



        [DllImport("user32.dll", EntryPoint = "EnumWindows", SetLastError = true)]
        private static extern bool EnumWindows(EnumWindowsProc lpEnumFunc, object lParam);
        [DllImport("user32.dll", EntryPoint = "EnumChildWindows", SetLastError = true)]
        private static extern bool EnumChildWindows(IntPtr hWndParent, EnumWindowsProc lpEnumFunc, object lParam);
        private delegate bool EnumWindowsProc(IntPtr hWnd, object lParam);
        private static bool EnumWindows(IntPtr hWnd, object lParam)
        {
            ((List<IntPtr>)lParam).Add(hWnd);
            return true;
        }

        /// <summary>
        /// 获取所有屏幕上的顶层窗口的句柄列表
        /// </summary>
        /// <returns>结果IntPtr数组（失败返回空IntPtr数组）</returns>
        /// <remarks></remarks>
        public static IntPtr[] List()
        {
            List<IntPtr> lParam = new List<IntPtr>();
            EnumWindows(EnumWindows, lParam);
            return lParam.ToArray();
        }
        /// <summary>
        /// 获取指定窗口的子窗口的句柄列表
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果IntPtr数组（失败返回空IntPtr数组）</returns>
        /// <remarks></remarks>
        public static IntPtr[] ListChildren(IntPtr hWnd)
        {
            List<IntPtr> lParam = new List<IntPtr>();
            EnumChildWindows(hWnd, EnumWindows, lParam);
            return lParam.ToArray();
        }



        [DllImport("user32.dll", EntryPoint = "IsWindow", SetLastError = true)]
        private static extern bool IsWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "IsIconic", SetLastError = true)]
        private static extern bool IsIconic(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "IsZoomed", SetLastError = true)]
        private static extern bool IsZoomed(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "IsWindowVisible", SetLastError = true)]
        private static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "IsWindowEnabled", SetLastError = true)]
        private static extern bool IsWindowEnabled(IntPtr hWnd);

        /// <summary>
        /// 判断窗口是否获得了系统焦点
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否获得焦点</returns>
        /// <remarks></remarks>
        public static bool CheckFocus(IntPtr hWnd)
        {
            return hWnd == GetForegroundWindow();
        }
        /// <summary>
        /// 判断窗口是否处于最小化状态
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否最小化</returns>
        /// <remarks></remarks>
        public static bool CheckMinimized(IntPtr hWnd)
        {
            return IsIconic(hWnd);
        }
        /// <summary>
        /// 判断窗口是否处于最大化状态
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否最大化</returns>
        /// <remarks></remarks>
        public static bool CheckMaximized(IntPtr hWnd)
        {
            return IsZoomed(hWnd);
        }
        /// <summary>
        /// 判断窗口是否处于可见状态
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否可见</returns>
        /// <remarks></remarks>
        public static bool CheckVisible(IntPtr hWnd)
        {
            return IsWindowVisible(hWnd);
        }
        /// <summary>
        /// 判断窗口是否处于允许接受键鼠输入的状态
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否接受输入</returns>
        /// <remarks></remarks>
        public static bool CheckEnabled(IntPtr hWnd)
        {
            return IsWindowEnabled(hWnd);
        }



        [DllImport("user32.dll", EntryPoint = "GetWindowRect", SetLastError = true)]
        private static extern bool GetWindowRect(IntPtr hWnd, out Rect lpRect);
        [DllImport("user32.dll", EntryPoint = "GetWindowPlacement", SetLastError = true)]
        private static extern bool GetWindowPlacement(IntPtr hWnd, out Placement lpwndpl);
        [StructLayout(LayoutKind.Sequential)]
        private struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct Placement
        {
            public uint length;
            public uint results;
            public uint showCmd;
            public Point ptMinPosition;
            public Point ptMaxPosition;
            public Rect rcNormalPosition;
        }
        [DllImport("user32.dll", EntryPoint = "GetClassNameA", SetLastError = true)]
        private static extern uint GetClassName(IntPtr hWnd, StringBuilder lpClassName, uint nMaxCount);
        [DllImport("user32.dll", EntryPoint = "GetWindowThreadProcessId", SetLastError = true)]
        private static extern int GetWindowThreadProcessId(IntPtr hWnd, out int lpdwProcessId);
        [DllImport("user32.dll", EntryPoint = "GetWindowLongA", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll", EntryPoint = "GetLayeredWindowAttributes", SetLastError = true)]
        private static extern bool GetLayeredWindowAttributes(IntPtr hWnd, IntPtr crKey, out byte bAlpha, int dwFlags);
        [Flags]
        private enum LayeredWindowAttribute : int
        {
            ColorKey = 1,
            Alpha = 2
        }
        [DllImport("user32.dll", EntryPoint = "SendMessageA", SetLastError = true)]
        private static extern int SendMessage(IntPtr hWnd, uint wMsg, int wParam, StringBuilder lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA", SetLastError = true)]
        private static extern int SendMessage(IntPtr hWnd, uint wMsg, [Optional, DefaultParameterValue(null)] object wParam, [Optional, DefaultParameterValue(null)] object lParam);
        [Flags]
        private enum WindowsMessage : uint
        {
            Destory = 2,
            Quit = 10,
            SetRedraw = 11,
            SetText = 12,
            GetText = 13,
            GetTextLength = 14,
            Close = 16,
            MouseActivate = 33,
            KeyDown = 256,
            KeyUp = 257,
            KeyChar = 258,
            SystemKeyDown = 260,
            SystemKeyUp = 261,
            SystemKeyChar = 262,
            SystemCommand = 274,
            MouseMove = 512,
            LeftButtonDown = 513,
            LeftButtonUp = 514,
            LeftButtonDoubleClick = 515,
            RightButtonDown = 516,
            RightButtonUp = 517,
            RightButtonDoubleClick = 518,
            MiddleButtonDown = 519,
            MiddleButtonUp = 520,
            MiddleButtonDoubleClick = 521,
            MouseWheel = 522,
            XButtonDown = 523,
            XButtonUp = 524,
            XButtonDoubleClick = 525,
            MouseHorizontalWheel = 526,
            ParentNotify = 528,
            MouseHover = 673,
            MouseLeave = 675
        }



        /// <summary>
        /// 获取窗口区域（大小和位置，即使窗口处于隐藏、最小化、最大化状态也能获取到）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果区域值（System.Drawing.Rectangle）</returns>
        /// <remarks></remarks>
        public static Rectangle GetRectangle(IntPtr hWnd)
        {
            Rect rcNormalPosition;
            if (IsIconic(hWnd) | IsZoomed(hWnd))
            {
                Placement placement;
                GetWindowPlacement(hWnd, out placement);
                rcNormalPosition = placement.rcNormalPosition;
            }
            else
            {
                GetWindowRect(hWnd, out rcNormalPosition);
            }
            return new Rectangle(rcNormalPosition.Left, rcNormalPosition.Top, rcNormalPosition.Right - rcNormalPosition.Left, rcNormalPosition.Bottom - rcNormalPosition.Top);
        }
        /// <summary>
        /// 获取窗口位置（即使窗口处于隐藏、最小化、最大化状态也能获取到）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果窗口位置值（System.Drawing.Point）</returns>
        /// <remarks></remarks>
        public static Point GetLocation(IntPtr hWnd)
        {
            Rect rcNormalPosition;
            if (IsIconic(hWnd) | IsZoomed(hWnd))
            {
                Placement placement;
                GetWindowPlacement(hWnd, out placement);
                rcNormalPosition = placement.rcNormalPosition;
            }
            else
            {
                GetWindowRect(hWnd, out rcNormalPosition);
            }
            return new Point(rcNormalPosition.Left, rcNormalPosition.Top);
        }
        /// <summary>
        /// 获取窗口大小（即使窗口处于隐藏、最小化、最大化状态也能获取到）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果窗口大小值（System.Drawing.Size）</returns>
        /// <remarks></remarks>
        public static Size GetSize(IntPtr hWnd)
        {
            Rect rcNormalPosition;
            if (IsIconic(hWnd) | IsZoomed(hWnd))
            {
                Placement placement;
                GetWindowPlacement(hWnd, out placement);
                rcNormalPosition = placement.rcNormalPosition;
            }
            else
            {
                GetWindowRect(hWnd, out rcNormalPosition);
            }
            return new Size(rcNormalPosition.Right - rcNormalPosition.Left, rcNormalPosition.Bottom - rcNormalPosition.Top);
        }
        /// <summary>
        /// 获取窗口中心点坐标（相对于屏幕的位置，即使窗口处于隐藏、最小化、最大化状态也能获取到）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果坐标值（System.Drawing.Point）</returns>
        /// <remarks></remarks>
        public static Point GetCenterPoint(IntPtr hWnd)
        {
            Rect rcNormalPosition;
            if (IsIconic(hWnd) | IsZoomed(hWnd))
            {
                Placement placement;
                GetWindowPlacement(hWnd, out placement);
                rcNormalPosition = placement.rcNormalPosition;
            }
            else
            {
                GetWindowRect(hWnd, out rcNormalPosition);
            }
            return new Point(rcNormalPosition.Left + (rcNormalPosition.Right - rcNormalPosition.Left) / 2, rcNormalPosition.Top + (rcNormalPosition.Bottom - rcNormalPosition.Top) / 2);
        }
        /// <summary>
        /// 获取窗口类名（结果字符串最大长度限制为1024）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果字符串（失败返回空字符串）</returns>
        /// <remarks></remarks>
        public static string GetClassName(IntPtr hWnd)
        {
            int capacity = 1024 + 1;
            StringBuilder lpClassName = new StringBuilder(capacity);
            GetClassName(hWnd, lpClassName, (uint)capacity);
            return lpClassName.ToString();
        }
        /// <summary>
        /// 获取窗口线程ID
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果线程ID</returns>
        /// <remarks></remarks>
        public static int GetThreadId(IntPtr hWnd)
        {
            int lpdwProcessId;
            return GetWindowThreadProcessId(hWnd, out lpdwProcessId);
        }
        /// <summary>
        /// 获取窗口进程ID
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果进程ID</returns>
        /// <remarks></remarks>
        public static int GetProcessId(IntPtr hWnd)
        {
            int pid;
            GetWindowThreadProcessId(hWnd, out pid);
            return pid;
        }
        /// <summary>
        /// 获取窗口进程
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果进程（Process，失败返回null）</returns>
        /// <remarks></remarks>
        public static Process GetProcess(IntPtr hWnd)
        {
            int pid;
            GetWindowThreadProcessId(hWnd, out pid);
            if (pid != 0)
            {
                return Process.GetProcessById(pid);
            }
            return null;
        }
        /// <summary>
        /// 获取窗体的不透明度级别
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns></returns>
        /// <remarks>不透明程度（介于0到1之间，0为完全透明，1为完全不透明）</remarks>
        public static double GetOpacity(IntPtr hWnd)
        {
            byte temp;
            GetLayeredWindowAttributes(hWnd, IntPtr.Zero, out temp, (int)LayeredWindowAttribute.Alpha);
            return temp / 255;
        }
        /// <summary>
        /// 获取窗口标题
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果字符串（失败返回空字符串）</returns>
        /// <remarks></remarks>
        public static string GetTitle(IntPtr hWnd)
        {
            int capacity = SendMessage(hWnd, (uint)WindowsMessage.GetTextLength) + 1;
            StringBuilder temp = new StringBuilder(capacity);
            SendMessage(hWnd, (uint)WindowsMessage.GetText, capacity, temp);
            return temp.ToString();
        }



        [DllImport("user32.dll", EntryPoint = "GetWindowDC", SetLastError = true)]
        private static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "ReleaseDC", SetLastError = true)]
        private static extern bool ReleaseDC(IntPtr hWnd, IntPtr hDC);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleDC", SetLastError = true)]
        private static extern IntPtr CreateCompatibleDC(IntPtr hDC);
        [DllImport("gdi32.dll", EntryPoint = "DeleteDC", SetLastError = true)]
        private static extern bool DeleteDC(IntPtr hDC);
        [DllImport("gdi32.dll", EntryPoint = "CreateCompatibleBitmap", SetLastError = true)]
        private static extern IntPtr CreateCompatibleBitmap(IntPtr hDC, int nWidth, int nHeight);
        [DllImport("gdi32.dll", EntryPoint = "DeleteObject", SetLastError = true)]
        private static extern bool DeleteObject(IntPtr hObject);
        [DllImport("gdi32.dll", EntryPoint = "SelectObject", SetLastError = true)]
        private static extern IntPtr SelectObject(IntPtr hDC, IntPtr hgdiobj);
        [DllImport("user32.dll", EntryPoint = "PrintWindow", SetLastError = true)]
        private static extern bool PrintWindow(IntPtr hWnd, IntPtr hDCBlt, uint nFlags);

        /// <summary>
        /// 获取窗口截图（即使窗口处于屏幕外、被遮挡、最小化等状态，也能获取到）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>结果图片（失败返回1*1个像素，#00000000透明色的图片）</returns>
        /// <remarks></remarks>
        public static Bitmap Image(IntPtr hWnd)
        {
            try
            {
                Placement placement;
                GetWindowPlacement(hWnd, out placement);
                Rect rcNormalPosition = placement.rcNormalPosition;
                IntPtr windowDC = GetWindowDC(hWnd);
                IntPtr hDC = CreateCompatibleDC(windowDC);
                IntPtr hgdiobj = CreateCompatibleBitmap(windowDC, rcNormalPosition.Right - rcNormalPosition.Left, rcNormalPosition.Bottom - rcNormalPosition.Top);
                SelectObject(hDC, hgdiobj);
                PrintWindow(hWnd, hDC, 0);
                Bitmap bitmap = System.Drawing.Image.FromHbitmap(hgdiobj);
                DeleteObject(hgdiobj);
                DeleteDC(hDC);
                ReleaseDC(hWnd, windowDC);
                return bitmap;
            }
            catch (Exception ex)
            {
                return new Bitmap(1, 1);
            }
        }



        [DllImport("user32.dll", EntryPoint = "SetWindowPos", SetLastError = true)]
        private static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);
        [Flags]
        private enum WindowPos
        {
            Top = 0,
            Bottom = 1,
            TopMost = -1,
            NoTopMost = -2
        }
        [Flags]
        private enum SetPos : uint
        {
            NoSize = 1,  //忽略 cx、cy, 保持大小
            NoMove = 2,  //忽略 X、Y, 保持位置
            NoZOrder = 4,  //忽略 hWndInsertAfter, 保持窗口排列Z顺序
            NoRedraw = 8,  //不重绘
            NoActivate = 16,  //不激活，不改变窗口排列Z顺序
            FrameChanged = 32,  //给窗口发送WM_NCCALCSIZE消息，即使窗口尺寸没有改变也会发送该消息。如果未指定这个标志，只有在改变了窗口尺寸时才发送WM_NCCALCSIZE。
            ShowWindow = 64,  //显示窗口
            HideWindow = 128,  //隐藏窗口
            AsyncWindowPos = 16384  //异步请求，不阻塞调用线程
        }
        [DllImport("user32.dll", EntryPoint = "ShowWindow", SetLastError = true)]
        private static extern bool ShowWindow(IntPtr hWnd, uint nCmdShow);
        [Flags]
        enum ShowState : uint
        {
            Hide = 0,
            ShowNormal = 1,
            ShowMinimized = 2,
            ShowMaximized = 3,
            ShowNoActivate = 4,
            Restore = 9
        }
        [DllImport("user32.dll", EntryPoint = "EnableWindow", SetLastError = true)]
        private static extern bool EnableWindow(IntPtr hWnd, bool bEnable);
        [DllImport("user32.dll", EntryPoint = "RedrawWindow", SetLastError = true)]
        private static extern bool RedrawWindow(IntPtr hWnd, Rect lprcUpdate, IntPtr hrgnUpdate, uint fuRedraw);
        [Flags]
        private enum Redraw : uint
        {
            Invalidate = 1,
            InternalPaint = 2,
            DoErase = 4,
            Validate = 8,
            NoInternalPaint = 16,
            NoErase = 32,
            NoChildren = 64,
            AllChildren = 128,
            UpdateNow = 256,
            EraseNow = 512,
            Frame = 1024,
            NoFrame = 2048
        }
        [DllImport("user32.dll", EntryPoint = "AttachThreadInput", SetLastError = true)]
        private static extern bool AttachThreadInput(int idAttach, int idAttachTo, bool fAttach);
        [DllImport("user32.dll", EntryPoint = "SetForegroundWindow", SetLastError = true)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);
        [DllImport("user32.dll", EntryPoint = "SetLayeredWindowAttributes", SetLastError = true)]
        private static extern bool SetLayeredWindowAttributes(IntPtr hWnd, IntPtr crKey, byte bAlpha, int dwFlags);
        [Flags]
        private enum WindowStyleEx : int
        {
            Layered = 524288
        }
        [Flags]
        private enum WindowLong : int
        {
            ExStyle = -20
        }
        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint wMsg, [Optional, DefaultParameterValue(null)] object wParam, [Optional, DefaultParameterValue(null)] object lParam);

        /// <summary>
        /// 设置窗口区域（即使窗口处于隐藏、最小化、最大化状态也能设置）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Rectangle">窗口区域（System.Drawing.Rectangle）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SetRectangle(IntPtr hWnd, Rectangle Rectangle)
        {
            bool result;
            IntPtr ptr = new IntPtr(0);
            if (IsIconic(hWnd))
            {
                ShowWindow(hWnd, (uint)ShowState.Hide);
                ShowWindow(hWnd, (uint)ShowState.ShowNormal);
                result = SetWindowPos(hWnd, ptr, Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height, (uint)(uint)SetPos.NoActivate);
                ShowWindow(hWnd, (uint)ShowState.ShowMinimized);
                return result;
            }
            if (IsZoomed(hWnd))
            {
                ShowWindow(hWnd, (uint)ShowState.Hide);
                ShowWindow(hWnd, (uint)ShowState.ShowNormal);
                result = SetWindowPos(hWnd, ptr, Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height, (uint)(uint)SetPos.NoActivate);
                ShowWindow(hWnd, (uint)ShowState.ShowMaximized);
                return result;
            }
            return SetWindowPos(hWnd, ptr, Rectangle.Left, Rectangle.Top, Rectangle.Width, Rectangle.Height, (uint)(uint)SetPos.NoActivate);
        }
        /// <summary>
        /// 设置窗口位置（即使窗口处于隐藏、最小化、最大化状态也能设置）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Point">窗口相对于屏幕左上角的位置，Left和Top（System.Drawing.Point）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SetLocation(IntPtr hWnd, Point Point)
        {
            bool result;
            IntPtr ptr = new IntPtr(0);
            if (IsIconic(hWnd))
            {
                ShowWindow(hWnd, (uint)ShowState.Hide);
                ShowWindow(hWnd, (uint)ShowState.ShowNormal);
                result = SetWindowPos(hWnd, ptr, Point.X, Point.Y, 0, 0, (uint)(uint)SetPos.NoSize | (uint)(uint)SetPos.NoActivate);
                ShowWindow(hWnd, (uint)ShowState.ShowMinimized);
                return result;
            }
            if (IsZoomed(hWnd))
            {
                ShowWindow(hWnd, (uint)ShowState.Hide);
                ShowWindow(hWnd, (uint)ShowState.ShowNormal);
                result = SetWindowPos(hWnd, ptr, Point.X, Point.Y, 0, 0, (uint)(uint)SetPos.NoSize | (uint)(uint)SetPos.NoActivate);
                ShowWindow(hWnd, (uint)ShowState.ShowMaximized);
                return result;
            }
            return SetWindowPos(hWnd, ptr, Point.X, Point.Y, 0, 0, (uint)(uint)SetPos.NoSize | (uint)(uint)SetPos.NoActivate);
        }
        /// <summary>
        /// 设置窗口居中（即使窗口处于隐藏、最小化、最大化状态也能设置，效果类似于StartPosition = FormStartPosition.CenterScreen）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SetCenterScreen(IntPtr hWnd)
        {
            bool result;
            Placement placement;
            IntPtr ptr = new IntPtr(0);
            Rectangle bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            GetWindowPlacement(hWnd, out placement);
            Rect rcNormalPosition = placement.rcNormalPosition;
            if (IsIconic(hWnd))
            {
                ShowWindow(hWnd, (uint)ShowState.Hide);
                ShowWindow(hWnd, (uint)ShowState.ShowNormal);
                result = SetWindowPos(hWnd, ptr, (int)Math.Round((double)(((double)(bounds.Width - (rcNormalPosition.Right - rcNormalPosition.Left))) / 2.0)), (int)Math.Round((double)(((double)(bounds.Height - (rcNormalPosition.Bottom - rcNormalPosition.Top))) / 2.0)), 0, 0, (uint)(uint)SetPos.NoSize | (uint)(uint)SetPos.NoActivate);
                ShowWindow(hWnd, (uint)ShowState.ShowMinimized);
                return result;
            }
            if (IsZoomed(hWnd))
            {
                ShowWindow(hWnd, (uint)ShowState.Hide);
                ShowWindow(hWnd, (uint)ShowState.ShowNormal);
                result = SetWindowPos(hWnd, ptr, bounds.Width - (rcNormalPosition.Right - rcNormalPosition.Left) / 2, bounds.Height - (rcNormalPosition.Bottom - rcNormalPosition.Top) / 2, 0, 0, (uint)(uint)SetPos.NoSize | (uint)(uint)SetPos.NoActivate);
                ShowWindow(hWnd, (uint)ShowState.ShowMaximized);
                return result;
            }
            return SetWindowPos(hWnd, ptr, bounds.Width - (rcNormalPosition.Right - rcNormalPosition.Left) / 2, bounds.Height - (rcNormalPosition.Bottom - rcNormalPosition.Top) / 2, 0, 0, (uint)(uint)SetPos.NoSize | (uint)(uint)SetPos.NoActivate);
        }
        /// <summary>
        /// 设置窗口大小（即使窗口处于隐藏、最小化、最大化状态也能设置）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Size">窗口大小，Width和Height（System.Drawing.Size）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SetSize(IntPtr hWnd, Size Size)
        {
            bool result;
            IntPtr ptr = new IntPtr(0);
            if (IsIconic(hWnd))
            {
                ShowWindow(hWnd, (uint)ShowState.Hide);
                ShowWindow(hWnd, (uint)ShowState.ShowNormal);
                result = SetWindowPos(hWnd, ptr, 0, 0, Size.Width, Size.Height, (uint)(uint)SetPos.NoMove | (uint)(uint)SetPos.NoActivate);
                ShowWindow(hWnd, (uint)ShowState.ShowMinimized);
                return result;
            }
            if (IsZoomed(hWnd))
            {
                ShowWindow(hWnd, (uint)ShowState.Hide);
                ShowWindow(hWnd, (uint)ShowState.ShowNormal);
                result = SetWindowPos(hWnd, ptr, 0, 0, Size.Width, Size.Height, (uint)(uint)SetPos.NoMove | (uint)(uint)SetPos.NoActivate);
                ShowWindow(hWnd, (uint)ShowState.ShowMaximized);
                return result;
            }
            return SetWindowPos(hWnd, ptr, 0, 0, Size.Width, Size.Height, (uint)(uint)SetPos.NoMove | (uint)(uint)SetPos.NoActivate);
        }
        /// <summary>
        /// 显示窗口（不获得系统焦点）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool Show(IntPtr hWnd)
        {
            IntPtr ptr = new IntPtr(0);
            return SetWindowPos(hWnd, ptr, 0, 0, 0, 0, (uint)SetPos.ShowWindow | (uint)SetPos.NoMove | (uint)SetPos.NoSize | (uint)SetPos.NoActivate);
        }
        /// <summary>
        /// 隐藏窗口（不获得系统焦点）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool Hide(IntPtr hWnd)
        {
            IntPtr ptr = new IntPtr(0);
            return SetWindowPos(hWnd, ptr, 0, 0, 0, 0, (uint)SetPos.HideWindow | (uint)SetPos.NoMove | (uint)SetPos.NoSize | (uint)SetPos.NoActivate);
        }
        /// <summary>
        /// 设置窗口是否置顶（置顶窗口，显示在其它所有非置顶窗口之上）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="TopMost">是否置顶</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SetTopMost(IntPtr hWnd, [Optional, DefaultParameterValue(true)] bool TopMost)
        {
            if (TopMost)
            {
                return SetWindowPos(hWnd, (IntPtr)(WindowPos.TopMost), 0, 0, 0, 0, (uint)SetPos.NoMove | (uint)SetPos.NoSize | (uint)SetPos.NoActivate);
            }
            return SetWindowPos(hWnd, (IntPtr)(WindowPos.NoTopMost), 0, 0, 0, 0, (uint)SetPos.NoMove | (uint)SetPos.NoSize | (uint)SetPos.NoActivate);
        }
        /// <summary>
        /// 设置窗口标题
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Title">窗口标题</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SetTitle(IntPtr hWnd, string Title)
        {
            StringBuilder temp = new StringBuilder(Title);
            return (SendMessage(hWnd, (uint)WindowsMessage.SetText, temp.Length + 1, temp) > 0);
        }
        /// <summary>
        /// 还原显示窗口（效果类似于WindowState = FormWindowState.Normal，隐藏的窗口会显示出来，不获得系统焦点）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ShowNormal(IntPtr hWnd)
        {
            ShowWindow(hWnd, (uint)ShowState.Hide);
            return ShowWindow(hWnd, (uint)ShowState.ShowNormal);
        }
        /// <summary>
        /// 最小化显示窗口（效果类似于WindowState = FormWindowState.Minimized，隐藏的窗口会显示出来，不获得系统焦点）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ShowMinimized(IntPtr hWnd)
        {
            ShowWindow(hWnd, (uint)ShowState.Hide);
            return ShowWindow(hWnd, (uint)ShowState.ShowMinimized);
        }
        /// <summary>
        /// 最大化显示窗口（效果类似于WindowState = FormWindowState.Maximized，隐藏的窗口会显示出来，不获得系统焦点）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ShowMaximized(IntPtr hWnd)
        {
            ShowWindow(hWnd, (uint)ShowState.Hide);
            return ShowWindow(hWnd, (uint)ShowState.ShowMaximized);
        }
        /// <summary>
        /// 设置窗口是否允许接受键鼠输入（禁止接收用户输入时，用鼠标点击窗口区域，不会点击到后面的窗口，但会有鼠标无法正常点击的警告声）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Enable">是否允许接受输入</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SetEnable(IntPtr hWnd, [Optional, DefaultParameterValue(true)] bool Enable)
        {
            return EnableWindow(hWnd, Enable);
        }
        /// <summary>
        /// 设置窗口是否允许重绘（禁止重绘后，窗口画面静止不变，可以减轻负荷，但是无法接收用户输入，此时用鼠标点击窗口区域，会点击到后面的窗口）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="CanRedraw">是否允许重绘</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SetCanRedraw(IntPtr hWnd, [Optional, DefaultParameterValue(true)] bool CanRedraw)
        {
            if (CanRedraw)
            {
                return (SendMessage(hWnd, (uint)WindowsMessage.SetRedraw, true, null) == 0);
            }
            return (SendMessage(hWnd, (uint)WindowsMessage.SetRedraw, false, null) == 0);
        }
        /// <summary>
        /// 刷新窗口（更新一帧画面，禁止重绘的窗口仍然禁止重绘）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool Refresh(IntPtr hWnd)
        {
            Rect rect = new Rect();
            IntPtr ptr = new IntPtr(0);
            return RedrawWindow(hWnd, rect, ptr, (uint)Redraw.Invalidate | (uint)Redraw.DoErase | (uint)Redraw.UpdateNow);
        }
        /// <summary>
        /// 使窗口获得系统焦点（隐藏的窗口会显示出来，最小化/最大化的窗口会还原，禁止重绘的窗口会允许重绘）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SetFocus(IntPtr hWnd)
        {
            int lpdwProcessId = 0;
            int windowThreadProcessId = GetWindowThreadProcessId(GetForegroundWindow(), out lpdwProcessId);
            lpdwProcessId = 0;
            int idAttach = GetWindowThreadProcessId(hWnd, out lpdwProcessId);
            AttachThreadInput(idAttach, windowThreadProcessId, true);
            ShowWindow(hWnd, (uint)ShowState.ShowNormal);
            SetWindowPos(hWnd, (IntPtr)(WindowPos.TopMost), 0, 0, 0, 0, (uint)SetPos.NoMove | (uint)SetPos.NoSize);
            SetWindowPos(hWnd, (IntPtr)(WindowPos.NoTopMost), 0, 0, 0, 0, (uint)SetPos.NoMove | (uint)SetPos.NoSize);
            bool result = SetForegroundWindow(hWnd);
            AttachThreadInput(idAttach, windowThreadProcessId, false);
            return result;
        }
        /// <summary>
        /// 设置窗体的不透明度级别
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Opacity">不透明程度（介于0到1之间，0为完全透明，1为完全不透明）</param>
        /// <returns></returns>
        /// <remarks>是否执行成功</remarks>
        public static bool SetOpacity(IntPtr hWnd, [Optional, DefaultParameterValue(1.0)] double Opacity)
        {
            if (Opacity < 0)
            {
                Opacity = 0;
            }
            if (Opacity > 1)
            {
                Opacity = 1;
            }
            int dwNewLong = GetWindowLong(hWnd, (int)WindowLong.ExStyle) | (int)WindowStyleEx.Layered;
            SetWindowLong(hWnd, (int)WindowLong.ExStyle, dwNewLong);
            return SetLayeredWindowAttributes(hWnd, IntPtr.Zero, (byte)(Opacity * 255), (int)LayeredWindowAttribute.Alpha);
        }
        /// <summary>
        /// 关闭窗口（同步阻塞，等待程序处理和用户确认，例如弹出确认关闭的对话框）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool Close(IntPtr hWnd)
        {
            return ((SendMessage(hWnd, (uint)WindowsMessage.Close, null, null) == 0) & (Marshal.GetLastWin32Error() != 1400));
        }
        /// <summary>
        /// 关闭窗口（异步执行，等待程序处理和用户确认，例如弹出确认关闭的对话框）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool CloseAsync(IntPtr hWnd)
        {
            return (PostMessage(hWnd, (uint)WindowsMessage.Close, null, null) & (Marshal.GetLastWin32Error() != 1400));
        }



        [DllImport("user32.dll", EntryPoint = "FlashWindow", SetLastError = true)]
        private static extern bool FlashWindow(IntPtr hWnd, bool bInvert);

        /// <summary>
        /// 闪烁窗口（同步阻塞，包括窗体和任务栏按钮的闪烁效果）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Times">闪烁的次数（默认1次）</param>
        /// <param name="IntervalMillisecond">闪烁的时间间隔（默认1秒）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool Flash(IntPtr hWnd, [Optional, DefaultParameterValue((uint)1)] uint Times, [Optional, DefaultParameterValue((uint)1000)] uint IntervalMillisecond)
        {
            if (IntervalMillisecond <= 0L)
            {
                Times = 1;
            }
            if (Times <= 0L)
            {
                return false;
            }
            long num2 = Times - 1L;
            for (long i = 0L; i <= num2; i += 1L)
            {
                FlashWindow(hWnd, true);
                FlashWindow(hWnd, false);
                try
                {
                    Thread.Sleep((int)IntervalMillisecond);
                }
                catch (Exception ex) { }
            }
            return true;
        }
        /// <summary>
        /// 闪烁窗口（异步执行，包括窗体和任务栏按钮的闪烁效果）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Times">闪烁的次数（默认1次）</param>
        /// <param name="IntervalMillisecond">闪烁的时间间隔（默认1秒）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool FlashAsync(IntPtr hWnd, [Optional, DefaultParameterValue((uint)1)] uint Times, [Optional, DefaultParameterValue((uint)1000)] uint IntervalMillisecond)
        {
            if ((hWnd == IntPtr.Zero) || !IsWindow(hWnd))
            {
                return false;
            }
            if (IntervalMillisecond <= 0L)
            {
                Times = 1;
            }
            if (Times <= 0L)
            {
                return false;
            }
            FlashAsyncTask task = new FlashAsyncTask(hWnd, Times, IntervalMillisecond);
            return true;
        }
        private class FlashAsyncTask
        {
            private IntPtr hWnd;
            private uint IntervalMillisecond;
            private System.Threading.Thread Thread;
            private uint Times;
            public FlashAsyncTask(IntPtr TaskhWnd, [Optional, DefaultParameterValue((uint)1)] uint TaskTimes, [Optional, DefaultParameterValue((uint)1000)] uint TaskIntervalMillisecond)
            {
                this.Thread = new System.Threading.Thread(new ThreadStart(this.Run));
                this.hWnd = TaskhWnd;
                this.Times = TaskTimes;
                this.IntervalMillisecond = TaskIntervalMillisecond;
                this.Thread.Start();
            }
            private void Run()
            {
                long num2 = this.Times - 1L;
                for (long i = 0L; i <= num2; i += 1L)
                {
                    if (!Window.IsWindow(this.hWnd))
                    {
                        this.Thread.Abort();
                    }
                    Window.FlashWindow(this.hWnd, true);
                    Window.FlashWindow(this.hWnd, false);
                    try
                    {
                        Thread.Sleep((int)IntervalMillisecond);
                    }
                    catch (Exception ex) { }
                }
            }
        }



        /// <summary>
        /// 显示或隐藏桌面（效果类似于在Win7系统，用鼠标点击一次屏幕右下角的“显示桌面”）
        /// </summary>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ToggleDesktop()
        {
            bool result;
            try
            {
                NewLateBinding.LateCall(Interaction.CreateObject("Shell.Application", ""), null, "ToggleDesktop", new object[0], null, null, null, true);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                return result;
            }
            return result;
        }
        /// <summary>
        /// 显示或隐藏窗口的3D切换效果（需要Windows Vista及更高版本的系统）
        /// </summary>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool Toggle3DSwitcher()
        {
            bool result;
            try
            {
                NewLateBinding.LateCall(Interaction.CreateObject("Shell.Application", ""), null, "WindowSwitcher", new object[0], null, null, null, true);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                return result;
            }
            return result;
        }
        /// <summary>
        /// 显示关闭计算机界面
        /// </summary>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ShowShutDown()
        {
            bool result;
            try
            {
                NewLateBinding.LateCall(Interaction.CreateObject("Shell.Application", ""), null, "ShutdownWindows", new object[0], null, null, null, true);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                return result;
            }
            return result;
        }
        /// <summary>
        /// 显示文件搜索界面
        /// </summary>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ShowSearchFile()
        {
            bool result;
            try
            {
                NewLateBinding.LateCall(Interaction.CreateObject("Shell.Application", ""), null, "FindFiles", new object[0], null, null, null, true);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                return result;
            }
            return result;
        }
        /// <summary>
        /// 显示时间与日期界面
        /// </summary>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ShowSetTime()
        {
            bool result;
            try
            {
                NewLateBinding.LateCall(Interaction.CreateObject("Shell.Application", ""), null, "SetTime", new object[0], null, null, null, true);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                return result;
            }
            return result;
        }
        /// <summary>
        /// 显示任务栏属性界面
        /// </summary>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ShowTrayProperties()
        {
            bool result;
            try
            {
                NewLateBinding.LateCall(Interaction.CreateObject("Shell.Application", ""), null, "TrayProperties", new object[0], null, null, null, true);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                return result;
            }
            return result;
        }
        /// <summary>
        /// 显示运行界面
        /// </summary>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ShowFileRun()
        {
            bool result;
            try
            {
                NewLateBinding.LateCall(Interaction.CreateObject("Shell.Application", ""), null, "FileRun", new object[0], null, null, null, true);
                result = true;
            }
            catch (Exception ex)
            {
                result = false;
                return result;
            }
            return result;
        }



        [DllImport("kernel32.dll", EntryPoint = "SuspendThread", SetLastError = true)]
        private static extern int SuspendThread(IntPtr hThread);
        [DllImport("kernel32.dll", EntryPoint = "ResumeThread", SetLastError = true)]
        private static extern int ResumeThread(IntPtr hThread);
        [DllImport("kernel32.dll", EntryPoint = "OpenThread", SetLastError = true)]
        private static extern IntPtr OpenThread(uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [Flags]
        private enum ThreadAccess : uint
        {
            Standard = 0xf0000,
            Synchronize = 0x100000,
            All = 0x1f0fff
        }

        /// <summary>
        /// 挂起窗口线程（Suspend Count加1）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ThreadSuspend(IntPtr hWnd)
        {
            if ((hWnd == IntPtr.Zero) || !IsWindow(hWnd))
            {
                return false;
            }
            int lpdwProcessId;
            int windowThreadProcessId = GetWindowThreadProcessId(hWnd, out lpdwProcessId);
            return (SuspendThread(OpenThread(0x1f0fff, false, (uint)windowThreadProcessId)) != -1);
        }
        /// <summary>
        /// 恢复窗口线程（Suspend Count减1）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ThreadResume(IntPtr hWnd)
        {
            if ((hWnd == IntPtr.Zero) || !IsWindow(hWnd))
            {
                return false;
            }
            int lpdwProcessId;
            int windowThreadProcessId = GetWindowThreadProcessId(hWnd, out lpdwProcessId);
            return (ResumeThread(OpenThread(0x1f0fff, false, (uint)windowThreadProcessId)) != -1);
        }
        /// <summary>
        /// 强制恢复窗口线程（Suspend Count减到0）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ThreadFree(IntPtr hWnd)
        {
            if ((hWnd == IntPtr.Zero) || !IsWindow(hWnd))
            {
                return false;
            }
            int lpdwProcessId;
            int windowThreadProcessId = GetWindowThreadProcessId(hWnd, out lpdwProcessId);
            IntPtr hThread = OpenThread(0x1f0fff, false, (uint)windowThreadProcessId);
            int num = ResumeThread(hThread);
            bool result = num != -1;
            while (num > 0)
            {
                num = ResumeThread(hThread);
                result &= num != -1;
            }
            return result;
        }

        /// <summary>
        /// 限制窗口的CPU占用（通过不断挂起和恢复线程）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="SleepMillisecond">挂起等待的持续时间（默认50毫秒，最少1毫秒）</param>
        /// <param name="IntervalMillisecond">挂起恢复的间隔时间（默认50毫秒，最少1毫秒）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ThreadLimit(IntPtr hWnd, [Optional, DefaultParameterValue((uint)50)] uint SleepMillisecond, [Optional, DefaultParameterValue((uint)50)] uint IntervalMillisecond)
        {
            if ((hWnd == IntPtr.Zero) || !IsWindow(hWnd))
            {
                return false;
            }
            if (SleepMillisecond <= 0L)
            {
                SleepMillisecond = 1;
            }
            if (IntervalMillisecond <= 0L)
            {
                IntervalMillisecond = 1;
            }
            ThreadLimitTask task = new ThreadLimitTask(hWnd, SleepMillisecond, IntervalMillisecond);
            return true;
        }
        private class ThreadLimitTask
        {
            private uint IntervalMillisecond;
            private uint SleepMillisecond;
            private System.Threading.Thread Thread;
            private IntPtr ThreadhWnd;
            private IntPtr WindowhWnd;
            public ThreadLimitTask(IntPtr TaskhWnd, uint TaskSleepMillisecond, uint TaskIntervalMillisecond)
            {
                this.Thread = new System.Threading.Thread(new ThreadStart(this.Run));
                this.WindowhWnd = TaskhWnd;
                this.SleepMillisecond = TaskSleepMillisecond;
                this.IntervalMillisecond = TaskIntervalMillisecond;
                int lpdwProcessId = 0;
                int windowThreadProcessId = Window.GetWindowThreadProcessId(this.WindowhWnd, out lpdwProcessId);
                this.ThreadhWnd = Window.OpenThread(0x1f0fff, false, (uint)windowThreadProcessId);
                this.Thread.Start();
            }
            private void Run()
            {
                while (this.Thread.IsAlive)
                {
                    if (!Window.IsWindow(this.WindowhWnd))
                    {
                        this.Thread.Abort();
                    }
                    Window.SuspendThread(this.ThreadhWnd);
                    try
                    {
                        System.Threading.Thread.Sleep((int)this.SleepMillisecond);
                    }
                    catch (Exception ex)
                    {
                    }
                    Window.ResumeThread(this.ThreadhWnd);
                    try
                    {
                        System.Threading.Thread.Sleep((int)this.IntervalMillisecond);
                    }
                    catch (Exception exception3)
                    {
                        ProjectData.SetProjectError(exception3);
                        Exception exception2 = exception3;
                    }
                }
            }
        }



        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyA", SetLastError = true)]
        private static extern uint MapVirtualKey(uint wCode, uint wMapType);
        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint wMsg, uint wParam, uint lParam);
        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, uint dwExtraInfo);
        [Flags]
        private enum KeyEvent : int
        {
            Down = 0,
            Up = 2
        }

        /// <summary>
        /// 向窗口发送按键消息（按键可能不被正常处理）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Key">键位（Windows.Forms.Keys）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SendKey(IntPtr hWnd, Keys Key)
        {
            uint wCode = (uint)Key;
            uint num3 = MapVirtualKey(wCode, 0);
            uint lParam = ((uint)1L) | (num3 << 0x10);
            List<Keys> list = new List<Keys>(new Keys[] { Keys.RShiftKey, Keys.RControlKey, Keys.RMenu });
            if (list.Contains(Key))
            {
                lParam |= 0x1000000;
            }
            bool result = true;
            result &= PostMessage(hWnd, 0x100, wCode, lParam);
            lParam |= 0xc0000000;
            return (result & PostMessage(hWnd, 0x101, wCode, lParam));
        }
        /// <summary>
        /// 向窗口发送按键消息（Alt组合键，实测：可发送Alt+F4组合键）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Key">键位（Windows.Forms.Keys）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SendAltKey(IntPtr hWnd, Keys Key)
        {
            uint wCode = 0x12;
            uint num3 = MapVirtualKey(wCode, 0);
            uint num2 = ((uint)1L) | (num3 << 0x10);
            uint num4 = (uint)Key;
            uint num6 = MapVirtualKey(num4, 0);
            uint lParam = ((uint)1L) | (num6 << 0x10);
            List<Keys> list = new List<Keys>(new Keys[] { Keys.RShiftKey, Keys.RControlKey, Keys.RMenu });
            if (list.Contains(Key))
            {
                lParam |= 0x1000000;
            }
            bool result = true;
            lParam |= 0x20000000;
            result &= PostMessage(hWnd, 260, wCode, (uint)(num2 | 0x20000000));
            result &= PostMessage(hWnd, 260, num4, lParam);
            lParam |= 0xc0000000;
            result &= PostMessage(hWnd, 0x105, num4, lParam);
            return (result & PostMessage(hWnd, 0x101, wCode, (uint)(num2 | 0xc0000000)));
        }
        /// <summary>
        /// 向窗口发送按键消息（Ctrl组合键，实测：可发送Ctrl+S组合键，需要阻塞20毫秒，此过程中Ctrl键被按下）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Key">键位（Windows.Forms.Keys）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SendCtrlKey(IntPtr hWnd, Keys Key)
        {
            uint wCode = (uint)Key;
            uint num3 = MapVirtualKey(wCode, 0);
            uint lParam = ((uint)1L) | (num3 << 0x10);
            List<Keys> list = new List<Keys>(new Keys[] { Keys.RShiftKey, Keys.RControlKey, Keys.RMenu });
            if (list.Contains(Key))
            {
                lParam |= 0x1000000;
            }
            bool result = true;
            keybd_event(0x11, (byte)MapVirtualKey(0x11, 0), 0, 0);
            try
            {
                Thread.Sleep(10);
            }
            catch (Exception ex)
            {
            }
            result &= PostMessage(hWnd, 0x100, wCode, lParam);
            lParam |= 0xc0000000;
            result &= PostMessage(hWnd, 0x105, wCode, lParam);
            try
            {
                Thread.Sleep(10);
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception2 = exception3;
            }
            keybd_event(0x11, (byte)MapVirtualKey(0x11, 0), 2, 0);
            return result;
        }
        /// <summary>
        /// 向窗口发送按键消息（Shift组合键，实测：可发送Shift+1组合键，需要阻塞20毫秒，此过程中Shift键被按下）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <param name="Key">键位（Windows.Forms.Keys）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SendShiftKey(IntPtr hWnd, Keys Key)
        {
            uint wCode = (uint)Key;
            uint num3 = MapVirtualKey(wCode, 0);
            uint lParam = ((uint)1L) | (num3 << 0x10);
            List<Keys> list = new List<Keys>(new Keys[] { Keys.RShiftKey, Keys.RControlKey, Keys.RMenu });
            if (list.Contains(Key))
            {
                lParam |= 0x1000000;
            }
            bool result = true;
            keybd_event(0x10, (byte)MapVirtualKey(0x10, 0), 0, 0);
            try
            {
                Thread.Sleep(10);
            }
            catch (Exception ex)
            {
            }
            result &= PostMessage(hWnd, 0x100, wCode, lParam);
            lParam |= 0xc0000000;
            result &= PostMessage(hWnd, 0x105, wCode, lParam);
            try
            {
                Thread.Sleep(10);
            }
            catch (Exception exception3)
            {
                ProjectData.SetProjectError(exception3);
                Exception exception2 = exception3;
            }
            keybd_event(0x10, (byte)MapVirtualKey(0x10, 0), 2, 0);
            return result;
        }



        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hWnd, uint wMsg, uint wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessageA", SetLastError = true)]
        private static extern bool SendMessage(IntPtr hWnd, uint wMsg, uint wParam, int lParam);
        [Flags]
        private enum MouseKey : uint
        {
            Up = 0,
            LeftButton = 1,
            RightButton = 2,
            Shift = 4,
            Control = 8,
            MiddleButton = 16,
            XButton1 = 32,
            XButton2 = 64
        }

        /// <summary>
        /// 向窗口发送鼠标消息（左键单击，点击可能不被正常处理）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SendLeftClick(IntPtr hWnd, Point Position)
        {
            bool result = true;
            int x = Position.X;
            int y = Position.Y;
            int lParam = Position.X | (Position.Y << 0x10);
            result &= SendMessage(hWnd, 0x210, 0x201, lParam);
            result &= PostMessage(hWnd, 0x201, 1, lParam);
            return (result & PostMessage(hWnd, 0x202, 0, lParam));
        }
        /// <summary>
        /// 向窗口发送鼠标消息（左键双击，点击可能不被正常处理）
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool SendLeftDoubleClick(IntPtr hWnd, Point Position)
        {
            bool result = true;
            int x = Position.X;
            int y = Position.Y;
            int lParam = Position.X | (Position.Y << 0x10);
            result &= SendMessage(hWnd, 0x210, 0x201, lParam);
            result &= PostMessage(hWnd, 0x201, 1, lParam);
            result &= PostMessage(hWnd, 0x202, 0, lParam);
            result &= SendMessage(hWnd, 0x210, 0x201, lParam);
            result &= PostMessage(hWnd, 0x203, 1, lParam);
            return (result & PostMessage(hWnd, 0x202, 0, lParam));
        }

    }
}