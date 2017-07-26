namespace My
{
    using System;
    using System.IO;
    using System.Drawing;
    using System.Collections;
    using System.Diagnostics;
    using System.Windows.Forms;
    using System.ComponentModel;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.Devices;
    using Microsoft.VisualBasic.CompilerServices;

    /// <summary>
    /// 范例代码（暂未整理到 MyCSharp 库中的可参考代码）
    /// </summary>
    public sealed class Example
    {

        /// <summary>
        /// 内存检测（不断申请256MB空间的Int数组，并反复读写内容，检测内存质量）
        /// </summary>
        public static void MemoryTest()
        {
            GC.Collect();
            ArrayList tested = new ArrayList();
            uint blockSize = 256 * 1024 * 1024;
            uint blockSizeMB = blockSize / 1024 / 1024;
            uint testedGB = 0;
            while ((new ComputerInfo()).AvailablePhysicalMemory > blockSize)
            {
                uint[] testing = null;
                //初始0
                try
                {
                    testing = new uint[blockSize / 4];
                }
                catch (OutOfMemoryException ex)
                {
                    ex = new OutOfMemoryException("【内存检测通过】：\r\n测试通过 " + tested.Count + " * " + blockSizeMB + " MB（" + testedGB + "GB）。");
                    tested.Clear();
                    GC.Collect();
                    throw ex;
                }
                for (int i = 0; i <= testing.Length; i++)
                {
                    if (testing[i] != 0)
                    {
                        throw new Exception("【发现内存错误】初始0值异常：\r\n测试通过 " + tested.Count + " * " + blockSizeMB + " MB（" + testedGB + "GB），错误位置 " + i * 4 / 1024 / 1024 + " MB。");
                    }
                }
                //重置1
                for (int i = 0; i < testing.Length; i++)
                {
                    testing[i] = uint.MaxValue;
                }
                for (int i = 0; i < testing.Length; i++)
                {
                    if (testing[i] != uint.MaxValue)
                    {
                        throw new Exception("【发现内存错误】重置1值异常：\r\n测试通过 " + tested.Count + " * " + blockSizeMB + " MB（" + testedGB + "GB），错误位置 " + i * 4 / 1024 / 1024 + " MB。");
                    }
                }
                //重置0
                for (int i = 0; i < testing.Length; i++)
                {
                    testing[i] = 0;
                }
                for (int i = 0; i < testing.Length; i++)
                {
                    if (testing[i] != 0)
                    {
                        throw new Exception("【发现内存错误】重置0值异常：\r\n测试通过 " + tested.Count + " * " + blockSizeMB + " MB（" + testedGB + "GB），错误位置 " + i * 4 / 1024 / 1024 + " MB。");
                    }
                }
                tested.Add(testing);
                testedGB = (uint)tested.Count * blockSizeMB / 1024;
            }
        }



        /// <summary>
        /// 获取上一次调用Win32 API产生的错误信息（实测：错误信息会一直保留，直到下一次调用Win32 API）
        /// </summary>
        /// <returns>错误信息（默认为"0 操作成功完成。"）</returns>
        public static string Win32Error()
        {
            int errorCode = Marshal.GetLastWin32Error();
            string errorMessage = new Win32Exception(Marshal.GetLastWin32Error()).Message;
            return errorCode + " " + errorMessage;
        }



        /// <summary>
        /// 在鼠标位置附近，创建一个无边框窗口，实时显示全屏的截图
        /// </summary>
        public static void CaptureScreen()
        {
            new CaptureForm().Show();
        }
        [DesignerGenerated]
        private class CaptureForm : Form
        {
            [DebuggerNonUserCode]
            protected override void Dispose(bool disposing)
            {
                try
                {
                    if (disposing && (this.components != null))
                    {
                        this.components.Dispose();
                    }
                }
                finally
                {
                    base.Dispose(disposing);
                }
            }
            private IContainer components;
            [DebuggerStepThrough]
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.Timer1 = new Timer(this.components);
                this.SuspendLayout();
                this.Timer1.Enabled = true;
                this.Timer1.Interval = 16;
                this.AutoScaleMode = AutoScaleMode.None;
                this.ResumeLayout(false);
            }
            private Timer Timer1;
            private void FormMain_Load(object sender, EventArgs e)
            {
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            }
            private void Timer1_Tick(object sender, EventArgs e)
            {
                this.Timer1.Enabled = false;
                if (this.BackgroundImage != null)
                {
                    this.BackgroundImage.Dispose();
                }
                this.BackgroundImage = My.Screen.ImageThumbnail(0.5);
                this.Size = this.BackgroundImage.Size;
                Point point2 = new Point(10, 10);
                this.Location = Mouse.Position() + ((Size)point2);
                this.Timer1.Enabled = true;
            }
        }



        /// <summary>
        /// 获取一个窗体的所有的可见子窗体句柄，保存信息并截图
        /// </summary>
        /// <param name="hWnd">窗口句柄（IntPtr）</param>
        public static void AnalysisChildren(IntPtr hWnd)
        {
            Window.SetFocus(hWnd);
            string path = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
            string title = Window.GetTitle(hWnd);
            path = path + @"\" + title + Conversions.ToString(Time.Stamp());
            Directory.CreateDirectory(path);
            IO.WriteString("", path + @"\Name_ClassName_Left_Top_Width_Height_Child_Father.txt");
            List<IntPtr> list = new List<IntPtr>(Window.ListChildren(hWnd));
            for (int i = 0; i < list.Count; i++)
            {
                IntPtr ptr = list[i];
                Rectangle area = Window.GetRectangle(ptr);
                if (area.Width > 0 & area.Height > 0)
                {
                    string str4 = Window.GetTitle(ptr);
                    string className = Window.GetClassName(ptr);
                    IntPtr ptr2 = Window.FindParent(ptr);
                    Image image = My.Screen.Image(area);
                    image.Save(path + @"\" + str4 + "_" + className + "_" + Conversions.ToString(area.Left) + "_" + Conversions.ToString(area.Top) + "_" + Conversions.ToString(area.Width) + "_" + Conversions.ToString(area.Height) + "_" + ptr.ToString() + "_" + ptr2.ToString() + ".png");
                    image.Dispose();
                }
            }
        }



        /// <summary>
        /// 将当前目录下的，所有用.NET Reflector从“.vb”转换生成的“.cs”文件，进行简单的修正
        /// </summary>
        public static void CheckVBToCSharp()
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择反编译出的 C# 代码的路径";
            dialog.SelectedPath = @"F:\Desktop\新建文件夹\MyVisualBasic\My";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string[] csFiles = IO.ListFile(dialog.SelectedPath);
                for (int fi = 0; fi < csFiles.Length; fi++)
                {
                    string filePath = csFiles[fi];
                    string[] codes = IO.ReadStringArray(filePath);
                    for (int ci = 0; ci < codes.Length; ci++)
                    {
                        string code = codes[ci];
                        if (code.Contains("ProjectData.SetProjectError(exception1);"))
                        {
                            codes[ci] = "";
                            continue;
                        }
                        if (code.Contains("Exception exception = exception1;"))
                        {
                            codes[ci] = "";
                            continue;
                        }
                        if (code.Contains("ProjectData.ClearProjectError();"))
                        {
                            codes[ci] = "";
                            continue;
                        }
                        if (code.Contains("using Microsoft.VisualBasic.CompilerServices;"))
                        {
                            codes[ci] = "";
                            continue;
                        }
                        code = code.Replace("namespace MyVisualBasic.My", "namespace My");
                        code = code.Replace("catch (Exception exception1)", "catch (Exception ex)");
                        code = code.Replace("catch (Exception exception3)", "catch (Exception ex)");
                        code = code.Replace("catch (Exception exception5)", "catch (Exception ex)");
                        code = code.Replace("string str;", "string result;");
                        code = code.Replace("str = ", "result = ");
                        code = code.Replace("return str;", "return result;");
                        code = code.Replace("byte[] buffer;", "byte[] result;");
                        code = code.Replace("buffer = ", "result = ");
                        code = code.Replace("return buffer;", "return result;");
                        code = code.Replace("bool flag;", "bool result;");
                        code = code.Replace("flag = ", "result = ");
                        code = code.Replace("return flag;", "return result;");
                        codes[ci] = code;
                    }
                    codes = StringProcessing.SelectNotEmpty(codes);
                    IO.WriteStringArray(ref codes, filePath);
                }
            }
        }

    }
}