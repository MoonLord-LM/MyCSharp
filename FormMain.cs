using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace MyCSharp
{
    /// <summary>
    /// 
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// 
        /// </summary>
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //My.Computer.SendKeys("^+{ESC}");
            //My.Computer.MouseMoveByPercent(1,1);
            //My.Computer.MouseLeftDoubleClick();
            object A = new string[] {"abc","123" };
            MessageBox.Show(My.StringData.ChangeObjectToJson(ref A));
            Thread t = new Thread((ThreadStart)delegate
            {
                //throw new Exception("非窗体线程异常");
            });
            t.Start();
            //throw new Exception(My.Security.Base64_Encode("窗体线程异常"));
            throw new Exception(My.Security.URL_Decode("微软.NET"));
            throw new Exception("窗体线程异常");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.Write(My.Computer.FindFocusWindow().X);
            Console.Write("--");
            Console.Write(My.Computer.FindFocusWindow().Y);
            Console.Write("\r\n");
        }
    }
}
