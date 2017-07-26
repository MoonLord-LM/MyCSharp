namespace My
{
    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using Microsoft.VisualBasic;

    /// <summary>
    /// 电源管理计划相关函数
    /// </summary>
    public sealed class Power
    {

        /// <summary>
        /// 设定关机计划（同步阻塞，注意会覆盖之前设定的关机/重启计划）
        /// </summary>
        /// <param name="DelaySecond">延时时间（单位秒，最大值315360000，10年，默认值为0，立即执行）</param>
        /// <returns>是否执行成功</returns>
        public static bool ShutDown([Optional, DefaultParameterValue(0)] int DelaySecond)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine("shutdown -a >nul 2>nul");
                process.StandardInput.WriteLine("shutdown -s -t " + DelaySecond + " >nul 2>nul");
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
        /// 设定关机计划（异步执行，注意会覆盖之前设定的关机/重启计划）
        /// </summary>
        /// <param name="DelaySecond">延时时间（单位秒，最大值315360000，10年，默认值为0，立即执行）</param>
        /// <returns>是否执行成功</returns>
        public static bool ShutDownAsync([Optional, DefaultParameterValue(0)] int DelaySecond)
        {
            try
            {
                Interaction.Shell("shutdown -a", AppWinStyle.Hide, false, -1);
                Interaction.Shell("shutdown -s -t " + DelaySecond, AppWinStyle.Hide, false, -1);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 设定重启计划（同步阻塞，注意会覆盖之前设定的关机/重启计划）
        /// </summary>
        /// <param name="DelaySecond">延时时间（单位秒，最大值315360000，10年，默认值为0，立即执行）</param>
        /// <returns>是否执行成功</returns>
        public static bool Reboot([Optional, DefaultParameterValue(0)] int DelaySecond)
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine("shutdown -a >nul 2>nul");
                process.StandardInput.WriteLine("shutdown -r -t " + DelaySecond + " >nul 2>nul");
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
        /// 设定重启计划（异步执行，注意会覆盖之前设定的关机/重启计划）
        /// </summary>
        /// <param name="DelaySecond">延时时间（单位秒，最大值315360000，10年，默认值为0，立即执行）</param>
        /// <returns>是否执行成功</returns>
        public static bool RebootAsync([Optional, DefaultParameterValue(0)] int DelaySecond)
        {
            try
            {
                Interaction.Shell("shutdown -a", AppWinStyle.Hide, false, -1);
                Interaction.Shell("shutdown -r -t " + DelaySecond, AppWinStyle.Hide, false, -1);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 取消所有计划（同步阻塞，之前没有关机/重启计划时则无效果）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool AbortPlan()
        {
            try
            {
                Process process = new Process();
                process.StartInfo.FileName = "cmd.exe";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.StandardInput.WriteLine("shutdown -a >nul 2>nul");
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
        /// 取消所有计划（异步执行，之前没有关机/重启计划时则无效果）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool AbortPlanAsync()
        {
            try
            {
                Interaction.Shell("shutdown -a", AppWinStyle.Hide, false, -1);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 锁定电脑（同步阻塞，立即执行）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool Lock()
        {
            try
            {
                Interaction.Shell("rundll32.exe user32.dll LockWorkStation", AppWinStyle.Hide, true, -1);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 注销用户（同步阻塞，立即执行）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool Logout()
        {
            try
            {
                Interaction.Shell("shutdown -l", AppWinStyle.Hide, true, -1);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 休眠电脑（同步阻塞，立即执行，注意系统必须启用了休眠功能才会有效果）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool Hibernate()
        {
            try
            {
                Interaction.Shell("shutdown -h", AppWinStyle.Hide, true, -1);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}