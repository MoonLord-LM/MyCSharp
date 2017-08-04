namespace My
{
    using System;
    using System.IO;
    using System.Text;
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
                for (int i = 0; i < testing.Length; i++)
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
        private class CaptureForm : Form
        {
            public CaptureForm()
            {
                InitializeComponent();
            }
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
            private IContainer components = null;
            private void InitializeComponent()
            {
                this.components = new System.ComponentModel.Container();
                this.timer1 = new Timer(this.components);
                this.SuspendLayout();
                this.timer1.Enabled = true;
                this.timer1.Interval = 16;
                this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
                this.AutoScaleMode = AutoScaleMode.None;
                this.Load += new System.EventHandler(this.FormMain_Load);
                this.ResumeLayout(false);
            }
            private Timer timer1;
            private void FormMain_Load(object sender, EventArgs e)
            {
                this.TopMost = true;
                this.FormBorderStyle = FormBorderStyle.None;
                this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
                this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
                this.Opacity = 0;
            }
            private void timer1_Tick(object sender, EventArgs e)
            {
                this.timer1.Enabled = false;
                if (this.BackgroundImage != null)
                {
                    this.BackgroundImage.Dispose();
                }
                this.BackgroundImage = My.Screen.ImageThumbnail(0.5);
                this.Size = this.BackgroundImage.Size;
                this.Location = Mouse.Position() + new Size(10, 10);
                this.Opacity = 1;
                this.timer1.Enabled = true;
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
            path = path + @"\" + title + Time.Stamp();
            Directory.CreateDirectory(path);
            IO.WriteString("", path + @"\Name_ClassName_Left_Top_Width_Height_Child_Father.txt");
            List<IntPtr> list = new List<IntPtr>(Window.ListChildren(hWnd));
            for (int i = 0; i < list.Count; i++)
            {
                IntPtr child = list[i];
                Rectangle area = Window.GetRectangle(child);
                if (area.Width > 0 & area.Height > 0)
                {
                    string name = Window.GetTitle(child);
                    string className = Window.GetClassName(child);
                    IntPtr father = Window.FindParent(child);
                    Image image = My.Screen.Image(area);
                    image.Save(path + @"\" + name + "_" + className + "_" + area.Left + "_" + area.Top + "_" + area.Width + "_" + area.Height + "_" + child.ToString() + "_" + father.ToString() + ".png");
                    image.Dispose();
                }
            }
        }



        /// <summary>
        /// 对当前目录下的，所有用.NET Reflector从“.vb”转换生成的“.cs”文件，进行简单的修正
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
                        if (code == "")
                        {
                            codes[ci] = " ";
                            continue;
                        }
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
                    IO.WriteStringArray(codes, filePath);
                }
            }
        }



        /// <summary>
        /// 文件列表式备份（保存文件的绝对路径、名称、后缀、大小、哈希值、ED2K链接等）
        /// </summary>
        /// <param name="CalculateHash">是否读取文件内容，计算哈希值（较慢）</param>
        public static void FileListBackup(bool CalculateHash = false)
        {
            FolderBrowserDialog dialog1 = new FolderBrowserDialog();
            dialog1.Description = "请选择要备份的文件夹路径";
            if (dialog1.ShowDialog() == DialogResult.OK)
            {
                DirectoryInfo dirInfo = new DirectoryInfo(dialog1.SelectedPath);
                string savePath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
                savePath = savePath + @"\【" + dirInfo.Name + "】" + Time.Stamp() + ".log";
                IO.WriteString("【备份时间：" + DateAndTime.Now + "】\r\n", savePath);
                IO.AppendString("【备份路径：" + dirInfo.FullName + "】\r\n", savePath);
                IO.AppendString("【本地时区：" + TimeZone.CurrentTimeZone.StandardName + " " + TimeZone.CurrentTimeZone.GetUtcOffset(DateAndTime.Now).ToString() + "】\r\n", savePath);
                string[] files = IO.ListFile(dialog1.SelectedPath);
                IO.AppendString("【文件数目：" + files.Length + "】\r\n", savePath);
                if (CalculateHash == false)
                {
                    IO.AppendString("【属性说明：完整路径、文件名、文件后缀<快捷方式指向位置>、文件大小、创建时间、修改时间、访问时间】\r\n", savePath);
                }
                else
                {
                    IO.AppendString("【属性说明：完整路径、文件名、文件后缀<快捷方式指向位置>、文件大小、创建时间、修改时间、访问时间、ED2K下载链接、MD5值、SHA1值、SHA256值、SHA384值、SHA512值】\r\n", savePath);
                }
                for (int i = 0; i < files.Length; i++)
                {
                    string file = files[i];
                    FileInfo fileInfo = new FileInfo(file);
                    StringBuilder buffer = new StringBuilder();
                    buffer.Append("\r\n");
                    buffer.Append("\"" + (i + 1) + "\"");
                    buffer.Append(" ");
                    buffer.Append("\"" + fileInfo.FullName + "\"");
                    buffer.Append(" ");
                    buffer.Append("\"" + fileInfo.Name + "\"");
                    buffer.Append(" ");
                    if (fileInfo.Extension.ToLower() != ".lnk")
                    {
                        buffer.Append("\"" + fileInfo.Extension + "\"");
                        buffer.Append(" ");
                    }
                    else
                    {
                        string link = IO.ReadLinkFile(file);
                        buffer.Append("\"" + fileInfo.Extension + "<" + link + ">\"");
                        buffer.Append(" ");
                        file = link;
                    }
                    buffer.Append("\"" + fileInfo.Length + "\"");
                    buffer.Append(" ");
                    buffer.Append("\"" + fileInfo.CreationTime + "\"");
                    buffer.Append(" ");
                    buffer.Append("\"" + fileInfo.LastWriteTime + "\"");
                    buffer.Append(" ");
                    buffer.Append("\"" + fileInfo.LastAccessTime + "\"");
                    buffer.Append(" ");
                    if (CalculateHash)
                    {
                        byte[] source = IO.ReadByte(file);
                        buffer.Append("\"" + Security.Generate_ED2K_Link(fileInfo.Name, source) + "\"");
                        buffer.Append(" ");
                        buffer.Append("\"" + Security.MD5_Encode(source, true) + "\"");
                        buffer.Append(" ");
                        buffer.Append("\"" + Security.SHA1_Encode(source, true) + "\"");
                        buffer.Append(" ");
                        buffer.Append("\"" + Security.SHA256_Encode(source, true) + "\"");
                        buffer.Append(" ");
                        buffer.Append("\"" + Security.SHA384_Encode(source, true) + "\"");
                        buffer.Append(" ");
                        buffer.Append("\"" + Security.SHA512_Encode(source, true) + "\"");
                        buffer.Append(" ");
                    }
                    IO.AppendString(buffer.ToString(), savePath);
                }
            }
        }

    }
}