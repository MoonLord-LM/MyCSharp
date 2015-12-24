using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;

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
            MessageBox.Show(My.Computer.FindWindow("PVP.net 客户端").ToString());
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            My.Computer.ShowWindowNormal("PVP.net 客户端");
            My.Computer.SetForegroundWindow("PVP.net 客户端");
        }
    }
}
