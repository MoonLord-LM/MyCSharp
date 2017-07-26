namespace My
{
    using System;
    using System.IO;
    using System.Threading;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.VisualBasic;

    /// <summary>
    /// 进程管理相关函数
    /// </summary>
    /// <remarks></remarks>
    public sealed partial class Task
    {

        /// <summary>
        /// 运行程序（同步阻塞，TaskName程序会获得鼠标焦点，直到TaskName程序结束才继续向下执行）
        /// </summary>
        /// <param name="TaskName">程序名称（例如"notepad"或"notepad.exe"）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool Run(string TaskName)
        {
            try
            {
                if (!TaskName.ToLower().EndsWith(".exe"))
                {
                    TaskName = TaskName + ".exe";
                }
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine("start \"\"\"\" \"" + TaskName + "\" >nul 2>nul");
                process.StandardInput.WriteLine("exit");
                process.StandardOutput.ReadToEnd();
                process.StandardOutput.Close();
                process.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 运行程序（异步执行，多次调用本函数会打开多个TaskName程序）
        /// </summary>
        /// <param name="TaskName">程序名称（例如"notepad"或"notepad.exe"）</param>
        /// <param name="MouseFocus">TaskName程序是否获得鼠标焦点（程序运行后，有些可能会遮挡焦点窗体，如“记事本”、“画图”，有些甚至会强制抢占焦点，如“计算器”）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool RunAsync(string TaskName, [Optional, DefaultParameterValue(true)] bool MouseFocus)
        {
            try
            {
                if (!TaskName.ToLower().EndsWith(".exe"))
                {
                    TaskName = TaskName + ".exe";
                }
                if (MouseFocus)
                {
                    Interaction.Shell(TaskName, AppWinStyle.NormalFocus, false, -1);
                }
                else
                {
                    Interaction.Shell(TaskName, AppWinStyle.NormalNoFocus, false, -1);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 关闭程序（同步阻塞，强制结束所有的TaskName程序的进程树）
        /// </summary>
        /// <param name="TaskName">程序名称（例如"notepad"或"notepad.exe"）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool Kill(string TaskName)
        {
            try
            {
                if (!TaskName.ToLower().EndsWith(".exe"))
                {
                    TaskName = TaskName + ".exe";
                }
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine("taskkill /f /t /im \"" + TaskName + "\" >nul 2>nul");
                process.StandardInput.WriteLine("exit");
                process.StandardOutput.ReadToEnd();
                process.StandardOutput.Close();
                process.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 关闭程序（异步执行，强制结束所有的TaskName程序的进程树）
        /// </summary>
        /// <param name="TaskName">程序名称（例如"notepad"或"notepad.exe"）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool KillAsync(string TaskName)
        {
            try
            {
                if (!TaskName.ToLower().EndsWith(".exe"))
                {
                    TaskName = TaskName + ".exe";
                }
                Interaction.Shell("taskkill /f /t /im \"" + TaskName + "\"", AppWinStyle.Hide, false, -1);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 获取进程名称列表（全部进程，包括"Idle"进程，返回结果的字符串中不含".exe"后缀）
        /// </summary>
        /// <returns>结果字符串数组（失败返回空String数组）</returns>
        /// <remarks></remarks>
        public static string[] ListName()
        {
            Process[] processes = Process.GetProcesses();
            List<string> list = new List<string>(processes.Length);
            foreach (Process process in processes)
            {
                list.Add(process.ProcessName);
            }
            return list.ToArray();
        }
        /// <summary>
        /// 获取窗口标题列表（有窗体的进程，只能获取到进程的主窗体的标题）
        /// </summary>
        /// <returns>结果字符串数组（失败返回空String数组）</returns>
        /// <remarks></remarks>
        public static string[] ListTitle()
        {
            Process[] processes = Process.GetProcesses();
            List<string> list = new List<string>(processes.Length);
            foreach (Process process in processes)
            {
                if (process.MainWindowTitle != "")
                {
                    list.Add(process.MainWindowTitle);
                }
            }
            return list.ToArray();
        }
        /// <summary>
        /// 获取进程文件路径列表（部分进程获取不到）
        /// </summary>
        /// <returns>结果字符串数组（失败返回空String数组）</returns>
        /// <remarks></remarks>
        public static string[] ListFilePath()
        {
            Process[] processes = Process.GetProcesses();
            List<string> list = new List<string>(processes.Length);
            foreach (Process process in processes)
            {
                try
                {
                    list.Add(process.MainModule.FileName);
                }
                catch (Exception ex)
                {
                }
            }
            return list.ToArray();
        }



        /// <summary>
        /// 根据进程名称，获取进程
        /// </summary>
        /// <param name="TaskName">进程名称（不含".exe"后缀）</param>
        /// <returns>结果进程（Process，失败返回null）</returns>
        /// <remarks></remarks>
        public static Process FindByName(string TaskName)
        {
            foreach (Process process2 in Process.GetProcesses())
            {
                if (process2.ProcessName.ToLower() == TaskName.ToLower())
                {
                    return process2;
                }
            }
            return null;
        }
        /// <summary>
        /// 根据进程文件路径，获取进程
        /// </summary>
        /// <param name="FilePath">文件路径（可以是相对路径）</param>
        /// <returns>结果进程（Process，失败返回null）</returns>
        /// <remarks></remarks>
        public static Process FindByFilePath(string FilePath)
        {
            Process[] processes = Process.GetProcesses();
            if (!FilePath.Contains(":"))
            {
                FilePath = Directory.GetCurrentDirectory() + @"\" + FilePath;
            }
            foreach (Process process2 in processes)
            {
                try
                {
                    if (process2.MainModule.FileName.ToLower() == FilePath.ToLower())
                    {
                        return process2;
                    }
                }
                catch (Exception ex)
                {
                    //System.Windows.Forms.MessageBox.Show(P.ProcessName & ex.ToString());
                }
            }
            return null;
        }
        /// <summary>
        /// 搜索窗口标题，获取进程（优先搜索字符串完全相同的，然后搜索包含有指定字符串的）
        /// </summary>
        /// <param name="Title">窗口标题（字符串不必完全相同）</param>
        /// <returns>结果进程（Process，失败返回null）</returns>
        /// <remarks></remarks>
        public static Process SearchByTitle(string Title)
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process process2 in processes)
            {
                if (process2.MainWindowTitle.ToLower() == Title.ToLower())
                {
                    return process2;
                }
            }
            foreach (Process process3 in processes)
            {
                if (process3.MainWindowTitle.ToLower().Contains(Title.ToLower()))
                {
                    return process3;
                }
            }
            return null;
        }




        [DllImport("user32.dll", EntryPoint = "SuspendThread", SetLastError = true)]
        private static extern int SuspendThread(IntPtr hThread);
        [DllImport("user32.dll", EntryPoint = "ResumeThread", SetLastError = true)]
        private static extern int ResumeThread(IntPtr hThread);
        [DllImport("user32.dll", EntryPoint = "OpenThread", SetLastError = true)]
        private static extern IntPtr OpenThread(uint dwDesiredAccess, bool bInheritHandle, uint dwThreadId);
        [Flags]
        private enum ThreadAccess : uint
        {
            Standard = 0xf0000,
            Synchronize = 0x100000,
            All = 0x1f0fff
        }

        /// <summary>
        /// 挂起进程的所有线程（Suspend Count加1）
        /// </summary>
        /// <param name="Process">进程（Process）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ThreadSuspend(Process Process)
        {
            if ((Process == null) || Process.HasExited)
            {
                return false;
            }
            ProcessThreadCollection threads = Process.Threads;
            bool result = true;
            int num3 = threads.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                int id = threads[i].Id;
                IntPtr hThread = OpenThread(0x1f0fff, false, (uint)id);
                result &= SuspendThread(hThread) != -1;
            }
            return result;
        }
        /// <summary>
        /// 恢复进程的所有线程（Suspend Count减1）
        /// </summary>
        /// <param name="Process">进程（Process）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ThreadResume(Process Process)
        {
            if ((Process == null) || Process.HasExited)
            {
                return false;
            }
            ProcessThreadCollection threads = Process.Threads;
            bool result = true;
            int num3 = threads.Count - 1;
            for (int i = 0; i <= num3; i++)
            {
                int id = threads[i].Id;
                IntPtr hThread = OpenThread(0x1f0fff, false, (uint)id);
                result &= ResumeThread(hThread) != -1;
            }
            return result;
        }
        /// <summary>
        /// 强制恢复进程的所有线程（Suspend Count减到0）
        /// </summary>
        /// <param name="Process">进程（Process）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ThreadFree(Process Process)
        {
            if ((Process == null) || Process.HasExited)
            {
                return false;
            }
            ProcessThreadCollection threads = Process.Threads;
            bool result = true;
            int num4 = threads.Count - 1;
            for (int i = 0; i <= num4; i++)
            {
                int id = threads[i].Id;
                IntPtr hThread = OpenThread(0x1f0fff, false, (uint)id);
                int num2 = ResumeThread(hThread);
                result &= num2 != -1;
                while (num2 > 0)
                {
                    num2 = ResumeThread(hThread);
                    result &= num2 != -1;
                }
            }
            return result;
        }

        /// <summary>
        /// 限制进程的CPU占用（通过不断挂起和恢复线程）
        /// </summary>
        /// <param name="Process">进程（Process）</param>
        /// <param name="SleepMillisecond">挂起等待的持续时间（默认50毫秒，最少1毫秒）</param>
        /// <param name="IntervalMillisecond">挂起恢复的间隔时间（默认50毫秒，最少1毫秒）</param>
        /// <returns>是否执行成功</returns>
        /// <remarks></remarks>
        public static bool ThreadLimit(Process Process, [Optional, DefaultParameterValue((uint)50)] uint SleepMillisecond, [Optional, DefaultParameterValue((uint)50)] uint IntervalMillisecond)
        {
            if ((Process == null) || Process.HasExited)
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
            ThreadLimitTask task = new ThreadLimitTask(Process, SleepMillisecond, IntervalMillisecond);
            return true;
        }
        private class ThreadLimitTask
        {
            private uint IntervalMillisecond;
            private System.Diagnostics.Process Process;
            private uint SleepMillisecond;
            private System.Threading.Thread Thread;
            public ThreadLimitTask(System.Diagnostics.Process TaskProcess, uint TaskSleepMillisecond, uint TaskIntervalMillisecond)
            {
                this.Thread = new System.Threading.Thread(new ThreadStart(this.Run));
                this.Process = TaskProcess;
                this.SleepMillisecond = TaskSleepMillisecond;
                this.IntervalMillisecond = TaskIntervalMillisecond;
                this.Thread.Start();
            }
            private void Run()
            {
                while (this.Thread.IsAlive)
                {
                    if (this.Process.HasExited)
                    {
                        this.Thread.Abort();
                    }
                    ProcessThreadCollection threads = this.Process.Threads;
                    int num5 = threads.Count - 1;
                    for (int i = 0; i <= num5; i++)
                    {
                        int id = threads[i].Id;
                        Task.SuspendThread(Task.OpenThread(0x1f0fff, false, (uint)id));
                    }
                    try
                    {
                        System.Threading.Thread.Sleep((int)this.SleepMillisecond);
                    }
                    catch (Exception ex) { }
                    int num6 = threads.Count - 1;
                    for (int j = 0; j <= num6; j++)
                    {
                        int num4 = threads[j].Id;
                        Task.ResumeThread(Task.OpenThread(0x1f0fff, false, (uint)num4));
                    }
                    try
                    {
                        System.Threading.Thread.Sleep((int)this.IntervalMillisecond);
                    }
                    catch (Exception ex) { }
                }
            }
        }

    }
}