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
            My.Computer.MoveWindow("PVP.net 客户端", PVP窗口位置);
            this.Opacity = 0;
            this.Visible = false;
            this.ShowInTaskbar = false;
            if (My.Computer.ShowWindowNormal("League of Legends (TM) Client") == false && My.Computer.ShowWindowNormal("PVP.net 客户端") == false)
            {
                MessageBox.Show("请先运行英雄联盟游戏（League of Legends）！", "程序即将退出");
                Application.Exit();
            }
            else
            {
                string 提示 = "";
                提示 = 提示 + "程序将在后台运行。\r\n";
                提示 = 提示 + "按住ESC键、Delete键、BackSpace键任意一个不松（约1秒），即可结束程序。\r\n";
                提示 = 提示 + "————————————————————\r\n";
                提示 = 提示 + "请保证游戏内的分辨率为【1280*720】。\r\n";
                提示 = 提示 + "请保证游戏内的窗口模式为【无边框】。\r\n";
                提示 = 提示 + "————————————————————\r\n";
                提示 = 提示 + "请尽量关闭可能会弹出窗口的第三方程序。\r\n";
                提示 = 提示 + "请尽量不要在挂机过程中做其它操作。\r\n";
                MessageBox.Show(提示, "提示");
            }
            PVP监控Timer.Interval = 20000;
            LOL监控Timer.Interval = 3000;
            退出监控Timer.Interval = 200;
            PVP监控Timer.Enabled = true;
            LOL监控Timer.Enabled = true;
            退出监控Timer.Enabled = true;
            My.Computer.ShowDesktop();
            new Thread(delegate()
            {
                Thread.Sleep(500);
                PVP监控(sender, e);
                Thread.Sleep(500);
                LOL监控(sender, e);
            }
            ).Start();
        }
        private void 退出监控(object sender, EventArgs e)
        {
            if (My.Computer.KeyBeingPressed(Keys.Escape) || My.Computer.KeyBeingPressed(Keys.Delete) || My.Computer.KeyBeingPressed(Keys.Back))
            {
                Application.Exit();
            }
        }
        public void PVP统治战场玩家匹配()
        {
            //7级才可以打统治战场（匹配）
            //5级才可以打统治战场（人机）
            //开始匹配
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 985, PVP窗口位置.Top + 50);//关闭浏览英雄的界面（正常界面下点击此处无效果）
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 70, PVP窗口位置.Top + 35);//英雄联盟
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 510, PVP窗口位置.Top + 30);//开始游戏
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 260, PVP窗口位置.Top + 100);//玩家对战
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 375, PVP窗口位置.Top + 145);//统治战场
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 540, PVP窗口位置.Top + 120);//水晶之痕
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 710, PVP窗口位置.Top + 130);//匹配模式
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 600, PVP窗口位置.Top + 570);//单人
            My.Computer.MouseLeftClick();
        }
        public void PVP召唤师峡谷人机匹配()
        {
            //1级就可以打简单人机
            //25级以下才能获得奖励
            //开始匹配
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 985, PVP窗口位置.Top + 50);//关闭浏览英雄的界面（正常界面下点击此处无效果）
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 70, PVP窗口位置.Top + 35);//英雄联盟
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 510, PVP窗口位置.Top + 30);//开始游戏
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 260, PVP窗口位置.Top + 145);//人机对战
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 390, PVP窗口位置.Top + 120);//经典对战
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 545, PVP窗口位置.Top + 120);//召唤师峡谷
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 690, PVP窗口位置.Top + 120);//入门
            My.Computer.MouseLeftClick();
            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 600, PVP窗口位置.Top + 570);//单人
            My.Computer.MouseLeftClick();
        }
        Rectangle PVP窗口位置 = new Rectangle((Screen.PrimaryScreen.Bounds.Width - 1024) / 2, (Screen.PrimaryScreen.Bounds.Height - 640) / 2, 1024, 640);//最小分辨率1024*640
        Bitmap 英雄联盟_PVP截图;
        private void PVP监控(object sender, EventArgs e)
        {
            if (My.Computer.FindFocusWindowTitle().Equals("PVP.net 客户端") == true || My.Computer.ShowWindowNormal("PVP.net 客户端") == true)
            {
                //LOL监控Timer.Enabled = false;
                My.Computer.SetForegroundWindow("PVP.net 客户端");
                My.Computer.MoveWindow("PVP.net 客户端", PVP窗口位置);
                My.Computer.ShowWindowNormal("PVP.net 客户端");
                My.Computer.SetForegroundWindow("PVP.net 客户端");
                My.Computer.MoveWindow("PVP.net 客户端", PVP窗口位置);
                英雄联盟_PVP截图 = My.Computer.SaveScreen(PVP窗口位置);
                Color 商店按钮 = 英雄联盟_PVP截图.GetPixel(723, 34);
                Color 开始游戏按钮 = 英雄联盟_PVP截图.GetPixel(555, 30);//开始游戏按钮，位置555, 30，未点击的颜色172,34,21，点击后没开游戏的颜色15,44,48
                Color 重新连接按钮 = 英雄联盟_PVP截图.GetPixel(512, 360);//重新连接按钮，位置512,360，出现按钮时的颜色208,121,52
                //英雄联盟_PVP截图.Save("英雄联盟PVP" + "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second + ".bmp");
                //MessageBox.Show(商店按钮.ToString() + 开始游戏按钮.ToString());
                if (商店按钮.R == 22 && 商店按钮.G == 10 && 商店按钮.B == 26)//位置723, 34客户端启动中22,10,26
                {
                    //LOL监控Timer.Enabled = true;
                    return;
                }
                if (商店按钮.R == 193 && 商店按钮.G == 104 && 商店按钮.B == 0)//位置723, 34默认颜色193,104,0
                {
                    if ((开始游戏按钮.R == 172 && 开始游戏按钮.G == 34 && 开始游戏按钮.B == 21) || (开始游戏按钮.R == 15 && 开始游戏按钮.G == 44 && 开始游戏按钮.B == 48))
                    {
                        PVP统治战场玩家匹配();
                        英雄联盟_PVP截图 = My.Computer.SaveScreen(PVP窗口位置);
                        商店按钮 = 英雄联盟_PVP截图.GetPixel(723, 34);
                        开始游戏按钮 = 英雄联盟_PVP截图.GetPixel(555, 30);
                        new Thread(delegate()
                        {
                            Thread.Sleep(1000);
                            if ((开始游戏按钮.R == 172 && 开始游戏按钮.G == 34 && 开始游戏按钮.B == 21) || (开始游戏按钮.R == 15 && 开始游戏按钮.G == 44 && 开始游戏按钮.B == 48))
                            {
                                PVP召唤师峡谷人机匹配();
                            }
                        }
                        ).Start();
                    }
                    PVP监控Timer.Interval = 2000;
                    //LOL监控Timer.Enabled = true;
                    return;
                }
                if (商店按钮.R == 224 && 商店按钮.G == 143 && 商店按钮.B == 22)//位置723, 34鼠标悬停224,143,22
                {
                    if ((开始游戏按钮.R == 172 && 开始游戏按钮.G == 34 && 开始游戏按钮.B == 21) || (开始游戏按钮.R == 15 && 开始游戏按钮.G == 44 && 开始游戏按钮.B == 48))
                    {
                        PVP统治战场玩家匹配();
                        英雄联盟_PVP截图 = My.Computer.SaveScreen(PVP窗口位置);
                        商店按钮 = 英雄联盟_PVP截图.GetPixel(723, 34);
                        开始游戏按钮 = 英雄联盟_PVP截图.GetPixel(555, 30);
                        new Thread(delegate()
                        {
                            Thread.Sleep(1000);
                            if ((开始游戏按钮.R == 172 && 开始游戏按钮.G == 34 && 开始游戏按钮.B == 21) || (开始游戏按钮.R == 15 && 开始游戏按钮.G == 44 && 开始游戏按钮.B == 48))
                            {
                                PVP召唤师峡谷人机匹配();
                            }
                        }
                        ).Start();
                    }
                    PVP监控Timer.Interval = 2000;
                    //LOL监控Timer.Enabled = true;
                    return;
                }
                if (商店按钮.R == 95 && 商店按钮.G == 50 && 商店按钮.B == 0)//位置723, 34已找到对手95,50,0
                {
                    My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 620, PVP窗口位置.Top + 400);//现在开始
                    My.Computer.MouseLeftClick();
                    PVP监控Timer.Interval = 2000;
                    //LOL监控Timer.Enabled = true;
                    return;
                }
                if (商店按钮.R == 6 && 商店按钮.G == 3 && 商店按钮.B == 1)//位置723, 34选择英雄6,3,1
                {
                    My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 260, PVP窗口位置.Top + 170);//随机英雄
                    My.Computer.MouseLeftClick();
                    new Thread(delegate()
                    {
                        Thread.Sleep(1000);
                        My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 735, PVP窗口位置.Top + 415);//确定
                        My.Computer.MouseLeftClick();
                    }
                    ).Start();
                    PVP监控Timer.Interval = 20000;
                    //LOL监控Timer.Enabled = true;
                    return;
                }
                if (商店按钮.R == 5 && 商店按钮.G == 4 && 商店按钮.B == 10)//位置723, 34游戏进行中&中途退出游戏5,4,10
                {
                    //MessageBox.Show("" + 重新连接按钮);
                    if (重新连接按钮.R == 208 && 重新连接按钮.G == 121 && 重新连接按钮.B == 52)
                    {
                        My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 512, PVP窗口位置.Top + 365);//重新连接
                        My.Computer.MouseLeftClick();
                        PVP监控Timer.Interval = 2000;
                    }
                    else
                    {
                        PVP监控Timer.Interval = 40000;
                    }
                    //LOL监控Timer.Enabled = true;
                    return;
                }
                if (商店按钮.R == 47 && 商店按钮.G == 71 && 商店按钮.B == 99)//位置723, 34游戏结束47,71,99
                {
                    My.Computer.ShellKill("League of Legends");
                    string SaveFileName1 = "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
                    英雄联盟_PVP截图.Save("英雄联盟PVP" + SaveFileName1 + ".jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    My.IO.WriteString("商店按钮" + 商店按钮.ToString() + "\r\n" + "开始游戏按钮" + 开始游戏按钮.ToString() + "\r\n" + "重新连接按钮" + 重新连接按钮.ToString() + "\r\n", "英雄联盟PVP" + SaveFileName1 + ".txt");
                    My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 890, PVP窗口位置.Top + 590);//再来一局
                    My.Computer.MouseLeftClick();
                    new Thread(delegate()
                    {
                        Thread.Sleep(1000);
                        英雄联盟_PVP截图 = My.Computer.SaveScreen(PVP窗口位置);
                        商店按钮 = 英雄联盟_PVP截图.GetPixel(723, 34);
                        if (商店按钮.R == 47 && 商店按钮.G == 71 && 商店按钮.B == 99)
                        {
                            My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 730, PVP窗口位置.Top + 590);//回到大厅
                            My.Computer.MouseLeftClick();
                        }
                    }
                    ).Start();
                    PVP监控Timer.Interval = 2000;
                    //LOL监控Timer.Enabled = true;
                    return;
                }
                if (商店按钮.R == 77 && 商店按钮.G == 41 && 商店按钮.B == 0)//位置723, 34客户端关闭中&新赛季全新天赋77,41,0
                {
                    My.Computer.MouseMoveToPixel(PVP窗口位置.Left + 465, PVP窗口位置.Top + 365);//是
                    My.Computer.MouseLeftClick();
                    PVP监控Timer.Interval = 2000;
                    //LOL监控Timer.Enabled = true;
                    return;
                }
                if ((商店按钮.R == 0 && 商店按钮.G == 0 && 商店按钮.B == 0) || (商店按钮.R == 255 && 商店按钮.G == 255 && 商店按钮.B == 255))//位置723, 34卡顿中
                {
                    //LOL监控Timer.Enabled = true;
                    return;
                }
                /*
                string SaveFileName = "-" + DateTime.Now.Hour + "-" + DateTime.Now.Minute + "-" + DateTime.Now.Second;
                英雄联盟_PVP截图.Save("英雄联盟PVP" + SaveFileName + ".bmp", System.Drawing.Imaging.ImageFormat.Bmp);
                My.IO.WriteString("商店按钮" + 商店按钮.ToString() + "\r\n" + "开始游戏按钮" + 开始游戏按钮.ToString() + "\r\n" + "重新连接按钮" + 重新连接按钮.ToString() + "\r\n", "英雄联盟PVP" + SaveFileName + ".txt");
                 * */
                //LOL监控Timer.Enabled = true;
                return;
            }
        }
        Rectangle LOL窗口位置 = new Rectangle((Screen.PrimaryScreen.Bounds.Width - 1280) / 2, (Screen.PrimaryScreen.Bounds.Height - 720) / 2, 1280, 720);//分辨率1280*720
        Bitmap 英雄联盟_LOL截图;
        private void LOL监控(object sender, EventArgs e)
        {
            if (My.Computer.FindFocusWindowTitle().Equals("League of Legends (TM) Client") == true || My.Computer.ShowWindowNormal("League of Legends (TM) Client") == true)
            {
                My.Computer.SetForegroundWindow("League of Legends (TM) Client");
                My.Computer.MoveWindow("League of Legends (TM) Client", LOL窗口位置);
                //原地随机移动
                Random R = new Random();
                My.Computer.MouseMoveToPixel(LOL窗口位置.Left + LOL窗口位置.Width / 2 - 50 + R.Next(-50, 50), LOL窗口位置.Top + LOL窗口位置.Height / 2 + 50 + R.Next(-50, 50));
                My.Computer.MouseRightDown();
                My.Computer.MouseRightUp();
                My.Computer.MouseRightUp();
                new Thread(delegate()
                {
                    Thread.Sleep(10);
                    My.Computer.MouseLeftDown();
                    My.Computer.MouseLeftUp();
                    My.Computer.MouseLeftUp();
                }
                ).Start();
                new Thread(delegate()
                {
                    Thread.Sleep(20);
                    My.Computer.MouseRightDown();
                    My.Computer.MouseRightUp();
                    My.Computer.MouseRightUp();
                }
                ).Start();
                //游戏结束后点击结束
                //My.Computer.MouseMoveToPixel(LOL窗口位置.Left + 640, LOL窗口位置.Top + 460);
                //My.Computer.MouseMoveToPixel(LOL窗口位置.Left + LOL窗口位置.Width / 2  , LOL窗口位置.Top + LOL窗口位置.Height / 2 );
                return;
            }
        }
    }
}
