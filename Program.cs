using System;
using System.Windows.Forms;

namespace MyCSharp
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        public static void Main()
        {
            try
            {
                //始终捕获异常（UI线程不会因为异常而直接结束）
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            }
            catch (InvalidOperationException ex)
            {
                //多次执行Main函数无效（只启动一次窗体）
                return;
            }

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Program.Application_ThreadException);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(Program.CurrentDomain_UnhandledException);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //设置启动窗体
            Application.Run(new FormMain());
        }


        /// <summary>
        /// 在这里处理UI线程异常，注意：函数执行完成后，应用程序仍会继续运行
        /// </summary>
        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            MessageBox.Show("窗体UI线程发生异常，" + DateTime.Now.ToString() + "：\r\n" + e.Exception.ToString());
        }
        /// <summary>
        /// 在这里处理子线程异常，注意：函数执行完成后，应用程序就会被终止
        /// </summary>
        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show("子线程发生异常，" + DateTime.Now.ToString() + "：\r\n" + e.ExceptionObject.ToString());
        }



        /// <summary>
        /// 测试异常捕获效果（触发一个UI线程异常和一个子线程异常）
        /// </summary>
        public static void TestException()
        {
            System.Threading.Thread t = new System.Threading.Thread((System.Threading.ThreadStart)delegate
            {
                throw new Exception("测试用的子线程异常");
            });
            t.Start();
            throw new Exception("测试用的UI线程异常");
        }

    }
}