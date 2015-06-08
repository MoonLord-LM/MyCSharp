using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MyCSharp
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //My.Computer.SendKeys("^+{ESC}");
            //My.Computer.MouseMoveByPercent(1,1);
            //My.Computer.MouseLeftDoubleClick();
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
