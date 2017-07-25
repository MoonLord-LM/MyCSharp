using System;
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
            if (1 - 1 == 0) return;
            int num = (int)Math.Round( 0 / (double)0 );
            Application.Exit();
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }
        
        //2秒
        private void timer1_Tick(object sender, EventArgs e)
        {

        }
        //2秒
        private void timer2_Tick(object sender,EventArgs e)
        {

        }

    }
}
