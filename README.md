# MyCSharp
MyCSharp, a function library for Windows application development, creates the "My" namespace, like VB.NET does.  
  
## [简介]
Windows应用程序开发函数库，创建类似于 VB.NET 中的 "My" 命名空间  
对Win32 API，VBScript，Batch等进行了封装，对常用的函数功能进行了分类整理  
  
## [用法]
引入【MyCSharp】文件夹中的任意 ".cs" 文件，获得函数功能的扩展  
引入方法：解决方案资源管理器，显示所有文件，刷新，右键 ".cs"文件 ，包括在项目内  
各个 ".cs" 文件之间互不依赖，可根据需要选择使用，推荐完全引入，直接复制粘贴整个文件夹  
  
## [结构]
<table>
    <tr>
        <td><a href="MyCSharp\Security.cs">Security.cs</a></td>
        <td>编码解码、加密解密相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\Http.cs">Http.cs</a></td>
        <td>HTTP网络请求相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\IO.cs">IO.cs</a></td>
        <td>磁盘文件读写相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\Resource.cs">Resource.cs</a></td>
        <td>程序资源文件相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\StringProcessing.cs">StringProcessing.cs</a></td>
        <td>字符串处理相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\Power.cs">Power.cs</a></td>
        <td>电源管理计划相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\Task.cs">Task.cs</a></td>
        <td>进程管理相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\Screen.cs">Screen.cs</a></td>
        <td>屏幕截图相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\Keyboard.cs">Keyboard.cs</a></td>
        <td>模拟键盘操作相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\Time.cs">Time.cs</a></td>
        <td>时间管理、转换相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\Mouse.cs">Mouse.cs</a></td>
        <td>模拟鼠标操作相关函数</td>
    </tr>
    <tr>
        <td><a href="MyCSharp\Window.cs">Window.cs</a></td>
        <td>窗口管理、控制相关函数</td>
    </tr>
</table>

## [示例]
    '创建快捷方式  
    My.IO.WriteLinkFile("MyCSharp.exe", "快捷方式名称.lnk", "参数", "描述");  
    
    '将字符串转换为类似01010101的二进制形式的字符串，并写入到txt文件中  
    My.IO.WriteString(My.Security.Binary_Encode("字符串"), "binary.txt");  
    
    '获取当前目录下所有的文件列表，并保存到txt文件中  
    My.IO.WriteStringArray(My.IO.ListFile(), "list.txt");  
    
    '获取网页源码，并分离出其中所有的href属性值，返回字符串数组  
    My.StringProcessing.FindAll(My.Http.GetString("http://www.baidu.com"), "href=""", """");  

    '打开和关闭记事本程序，在cmd窗口同步阻塞  
    My.Task.RunAsync("notepad");  
    My.Task.Run("cmd");  
    My.Task.KillAsync("notepad");  

    '将完整的屏幕截图保存为png文件，并将60%比例的屏幕缩略图保存为jpg文件  
    My.Screen.Image().Save("10.png");  
    My.Screen.ImageThumbnail(0.6).Save("6.jpg", Imaging.ImageFormat.Jpeg);  

    '模拟键盘敲击，发送组合键：切换输入法Ctrl+Shift，关闭当前窗口Alt+F4，QQ屏幕截图Ctrl+Alt+A  
    My.Keyboard.Click(Keys.ControlKey, Keys.ShiftKey);  
    My.Keyboard.Click(Keys.Menu, Keys.F4);  
    My.Keyboard.Click(Keys.ControlKey, Keys.Menu, Keys.A);  

    '模拟键盘敲击，输入一段字符串，输入每个字符的时间间隔为50毫秒  
    My.Keyboard.Input("1!2@3#4$5%6^7&8*9(0)-_=+Aa", 50);  

    '模拟连续复制粘贴字符，输入一段字符串，输入每个字符的时间间隔为100毫秒  
    My.Keyboard.PasteDelay("这是一段中文字符。", 100);  

    '模拟用户操作，打开“画图”程序，粘贴屏幕截图，并将文件保存到桌面，关闭“画图”程序  
    Dim Screenshot As Bitmap = My.Screen.Image();  
    Dim SavePath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);  
    My.Task.RunAsync("mspaint.exe");  
    My.Time.Wait(500);  
    My.Keyboard.Paste(Screenshot);  
    My.Keyboard.Click(Keys.ControlKey, Keys.S);  
    My.Time.Wait(500);  
    My.Keyboard.Paste(SavePath & "\截图" & My.Time.Stamp() & ".png");  
    My.Keyboard.Click(Keys.Enter);  
    My.Time.Wait(500);  
    My.Task.KillAsync("mspaint.exe");  

    '模拟用户操作，移动鼠标到桌面右下角（显示桌面），单击2下，并将鼠标移回初始位置  
    Dim Position As Point = My.Mouse.Position();  
    My.Mouse.MoveToPercent(1, 1);  
    My.Mouse.LeftClick();  
    My.Time.Wait(1000);  
    My.Mouse.LeftClick();  
    My.Mouse.MoveToPosition(Position);  

    '模拟用户操作，打开“计算器”程序，在窗体无焦点的情况下，输入“1+2/3-4*5=”，保存结果截图  
    Dim SavePath As String = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);  
    My.Task.RunAsync("calc.exe");  
    My.Time.Wait(1000);  
    My.Window.SetFocus(Me.Handle);  
    Dim Calc As IntPtr = My.Window.FindByTitle("计算器");  
    My.Window.SendKey(Calc, Keys.D1);  
    My.Time.Wait(100);  
    My.Window.SendKey(Calc, Keys.Add);  
    My.Time.Wait(100);  
    My.Window.SendKey(Calc, Keys.D2);  
    My.Time.Wait(100);  
    My.Window.SendKey(Calc, Keys.Divide);  
    My.Time.Wait(100);  
    My.Window.SendKey(Calc, Keys.D3);  
    My.Time.Wait(100);  
    My.Window.SendKey(Calc, Keys.Subtract);  
    My.Time.Wait(100);  
    My.Window.SendKey(Calc, Keys.D4);  
    My.Time.Wait(100);  
    My.Window.SendKey(Calc, Keys.Multiply);  
    My.Time.Wait(100);  
    My.Window.SendKey(Calc, Keys.D5);  
    My.Time.Wait(100);  
    My.Window.SendKey(Calc, Keys.Oemplus);  
    My.Time.Wait(100);  
    My.Window.Image(Calc).Save(SavePath & "\计算结果" & My.Time.Stamp() & ".png");  
    My.Task.KillAsync("calc.exe");  

## [说明]
- 默认字符编码：UTF-8  
- 开发测试环境：Windows 7 + Visual Studio 2010（.NET Franmework 2.0）  
- 项目需要引用：System，System.Drawing，System.Web，System.Windows.Forms，Microsoft.VisualBasic  
- 代码空行规则：可以重载的或功能类似的函数不用空行隔开，有一定关系的函数隔开一行，无关的函数隔开三行  
- 代码注释示例：“结果字符串（失败返回空字符串）”，“结果Byte数组（失败返回空Byte数组）”，“使用特定的字符编码（默认UTF-8）”  
- 总体设计准则：采用面向过程(Procedure Oriented)为主，面向对象（Object Oriented）为辅的设计和实现方法，函数功能模块化  
- 函数实现准则：所有可供外部调用的函数功能，都采用公共静态（public static）声明，并且保证相互之间没有依赖关系  
- 其它语言实现：<a href="https://github.com/MoonLord-LM/MyVisualBasic">MyVisualBasic（本函数库的 VB.NET 语言等价实现）</a>
  
## [笔记]
01. 在Visual Studio中显示行号：工具，选项，文本编辑器，所有语言，显示行号  
02. C#中，数组与ArrayList互相转换：  
    (new System.Collections.ArrayList(new String[] { })).ToArray(String.Empty.GetType());  
03. C#中，数组元素个数的声明与 VB.NET 不同，以下代码会输出2：  
    string[] array = new string[2];  
    System.Windows.Forms.MessageBox.Show(array.Length.ToString());  
04. C#中，双引号使用反斜杠加双引号来转义替代，如 \" 表示1个双引号的字符串，字符串用 + 符号来连接  
05. C#中，没有 VB.NET 中的“启用应用程序框架”，“启动对象”为自定义的Main函数（参考本函数库中的 Program.cs 文件）  
06. 从 .NET Framework 2.0 版开始，将无法通过 try-catch 块捕获 StackOverflowException 对象，并且默认情况下将立即终止相应的进程，而 OutOfMemoryException 则可以捕获并处理  
07. System.Drawing.Imaging.ImageFormat的图片保存质量及文件大小降序排列，实测结果：  
    Bmp（最大）> Tiff > Exif/Icon/MemoryBmp > Png/Emf/Wmf（默认） > Gif > Jpeg（最小）  
08. C#中，SendKeys函数不能模拟发送PrintScreen键（全屏截图），必须使用底层的keybd_event函数实现才可以：  
    System.Windows.Forms.SendKeys.Send(Keys.PrintScreen); //内置函数，无效  
    My.Keyboard.Click(Keys.PrintScreen); //本函数库，有效  
09. 在Windows中，底层的keybd_event函数，也不能发送某些（跳转到当前用户的界面之外的）特殊组合键：  
    My.Keyboard.Click(Keys.LWin, Keys.D); //Win+D 显示桌面，有效  
    My.Keyboard.Click(Keys.LWin, Keys.L); //Win+L 锁定电脑，无效  
    My.Keyboard.Click(Keys.ControlKey, Keys.ShiftKey, Keys.Escape); //Ctrl+Shift+Esc 打开任务管理器，有效  
    My.Keyboard.Click(Keys.ControlKey, Keys.Menu, Keys.Delete); //Ctrl+Alt+Delete 跳转系统界面，无效  
10. 无法模拟“Win+L”的问题，本函数库提供了一个替代方案，调用“user32.dll”中的“LockWorkStation”：  
    My.Power.Lock(); //锁定电脑，有效  
11. C#中，需要将函数指针作为参数传递时，可以用“delegate”定义一个函数类型，然后直接用函数名称传递函数的指针  
12. C#中，调用.dll文件时，EntryPoint中的函数名才是.dll中真正起作用的函数的名称，EntryPoint不存在时，才会寻找同名函数  
13. C#中，频繁修改窗体内容（如修改背景图片），会导致内存泄露和卡顿闪烁的问题，解决方案：  
    if (BackgroundImage != null) { BackgroundImage.Dispose(); } //在修改背景图片之前，销毁旧的背景图片  
    System.GC.Collect(); //在适当的时机和代码位置，强制进行即时垃圾回收（会增加 CPU 负荷）  
    SetStyle(ControlStyles.OptimizedDoubleBuffer, True); //先在缓冲区中绘制，然后再绘制到屏幕上，以减少闪烁  
    SetStyle(ControlStyles.AllPaintingInWmPaint, True); //忽略擦除背景的窗口消息，不擦除之前的背景，以减少闪烁  
14. C#中，同步锁“synchronized(this)”代码块，类似于 VB.NET 中的“SyncLock Me”和“End SyncLock”  
15. C#中，“IntPtr.Zero”、“New IntPtr(0)”，不完全等同于“null”空指针（判断相等为false）  
16. C#中，使用“0xffffffff”的形式，来表示16进制的32位无符号整数，即UInt32.MaxValue  
17. C#中，逻辑判断短路“&&”、“||”，类似于 VB.NET 中的“AndAlso”、“OrElse”  
18. 要想让窗体在启动的时候就隐藏，最好使用“Opacity = 0;”来隐藏  
    如果使用“Visible = False;”或“Hide();”，写在Form_Load事件中无效果，写在Form_Shown事件中会导致窗体闪一下再消失  