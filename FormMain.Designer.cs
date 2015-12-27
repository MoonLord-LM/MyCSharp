namespace MyCSharp
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PVP监控Timer = new System.Windows.Forms.Timer(this.components);
            this.LOL监控Timer = new System.Windows.Forms.Timer(this.components);
            this.退出监控Timer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // PVP监控Timer
            // 
            this.PVP监控Timer.Tick += new System.EventHandler(this.PVP监控);
            // 
            // LOL监控Timer
            // 
            this.LOL监控Timer.Tick += new System.EventHandler(this.LOL监控);
            // 
            // 退出监控Timer
            // 
            this.退出监控Timer.Tick += new System.EventHandler(this.退出监控);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(441, 303);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormMain";
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer PVP监控Timer;
        private System.Windows.Forms.Timer LOL监控Timer;
        private System.Windows.Forms.Timer 退出监控Timer;
    }
}

