namespace My
{
    using System;
    using System.Drawing;
    using System.Threading;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using Microsoft.VisualBasic;
    using Microsoft.VisualBasic.CompilerServices;

    /// <summary>
    /// 模拟键盘操作相关函数
    /// </summary>
    public sealed partial class Keyboard
    {

        [DllImport("user32.dll", EntryPoint = "keybd_event", SetLastError = true)]
        private static extern void keybd_event(byte bVk, byte bScan, int dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll", EntryPoint = "MapVirtualKeyA", SetLastError = true)]
        private static extern uint MapVirtualKey(uint wCode, uint wMapType);
        [Flags]
        private enum KeyEvent : int
        {
            Down = 0,
            Up = 2
        }

        /// <summary>
        /// 按下单个键位（保持按下状态，要注意，按下+释放才是一次完整的按键过程）
        /// </summary>
        /// <param name="Key">键位（Windows.Forms.Keys）</param>
        /// <returns>是否执行成功</returns>
        public static bool Down(Keys Key)
        {
            try
            {
                keybd_event((byte)Key, (byte)MapVirtualKey((uint)Key, 0), (int)KeyEvent.Down, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 释放单个键位（取消按下状态，要注意，按下+释放才是一次完整的按键过程）
        /// </summary>
        /// <param name="Key">键位（Windows.Forms.Keys）</param>
        /// <returns>是否执行成功</returns>
        public static bool Up(Keys Key)
        {
            try
            {
                keybd_event((byte)Key, (byte)MapVirtualKey((uint)Key, 0), (int)KeyEvent.Up, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 点击单个键位（包括按下+释放过程）
        /// </summary>
        /// <param name="Key">键位（Windows.Forms.Keys）</param>
        /// <returns>是否执行成功</returns>
        public static bool Click(Keys Key)
        {
            try
            {
                keybd_event((byte)Key, (byte)MapVirtualKey((uint)Key, 0), (int)KeyEvent.Down, 0);
                keybd_event((byte)Key, (byte)MapVirtualKey((uint)Key, 0), (int)KeyEvent.Up, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 点击多个键位，完成组合键（包括按下+释放过程）
        /// </summary>
        /// <param name="Keys">键位数组（Windows.Forms.Keys）</param>
        /// <returns>是否执行成功</returns>
        public static bool Click(Keys[] Keys)
        {
            try
            {
                foreach (Keys key in Keys)
                {
                    keybd_event((byte)key, (byte)MapVirtualKey((uint)key, 0), (int)KeyEvent.Down, 0);
                }
                foreach (Keys key in Keys)
                {
                    keybd_event((byte)key, (byte)MapVirtualKey((uint)key, 0), (int)KeyEvent.Up, 0);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 点击多个键位，完成组合键（包括按下+释放过程）
        /// </summary>
        /// <param name="Keys1">键位1（Windows.Forms.Keys）</param>
        /// <param name="Keys2">键位2（Windows.Forms.Keys）</param>
        /// <param name="Keys3">键位3（Windows.Forms.Keys）</param>
        /// <param name="Keys4">键位4（Windows.Forms.Keys）</param>
        /// <returns>是否执行成功</returns>
        public static bool Click(Keys Keys1, Keys Keys2, [Optional, DefaultParameterValue(0)] Keys Keys3, [Optional, DefaultParameterValue(0)] Keys Keys4)
        {
            try
            {
                List<Keys> list = new List<Keys>();
                list.Add(Keys1);
                list.Add(Keys2);
                if (Keys3 != Keys.None)
                {
                    list.Add(Keys3);
                }
                if (Keys4 != Keys.None)
                {
                    list.Add(Keys4);
                }
                foreach (Keys keys in list)
                {
                    keybd_event((byte)keys, (byte)MapVirtualKey((uint)keys, 0), (int)KeyEvent.Down, 0);
                }
                foreach (Keys keys2 in list)
                {
                    keybd_event((byte)keys2, (byte)MapVirtualKey((uint)keys2, 0), (int)KeyEvent.Up, 0);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        [DllImport("user32.dll", EntryPoint = "GetAsyncKeyState", SetLastError = true)]
        private static extern short GetAsyncKeyState(int vKey);
        [Flags]
        private enum KeyState : short
        {
            Down1 = -32767,
            Down2 = -32768
        }

        /// <summary>
        /// 判断单个键位是否处于按下状态
        /// </summary>
        /// <param name="Key">键位（Windows.Forms.Keys）</param>
        /// <returns>是否处于按下状态</returns>
        public static bool CheckDown(Keys Key)
        {
            short asyncKeyState = GetAsyncKeyState((int)Key);
            return asyncKeyState == (short)KeyState.Down1 | asyncKeyState == (short)KeyState.Down2;
        }

        /// <summary>
        /// 设置CapsLock的状态
        /// </summary>
        /// <param name="State">是否打开CapsLock</param>
        /// <returns>是否执行成功</returns>
        public static bool SetCapsLock(bool State)
        {
            try
            {
                if ((new Microsoft.VisualBasic.Devices.Keyboard()).CapsLock != State)
                {
                    keybd_event((byte)Keys.CapsLock, (byte)MapVirtualKey((uint)Keys.CapsLock, 0), (int)KeyEvent.Down, 0);
                    keybd_event((byte)Keys.CapsLock, (byte)MapVirtualKey((uint)Keys.CapsLock, 0), (int)KeyEvent.Up, 0);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 设置ScrollLock的状态
        /// </summary>
        /// <param name="State">是否打开ScrollLock</param>
        /// <returns>是否执行成功</returns>
        public static bool SetScrollLock(bool State)
        {
            try
            {
                if ((new Microsoft.VisualBasic.Devices.Keyboard()).ScrollLock != State)
                {
                    keybd_event((byte)Keys.Scroll, (byte)MapVirtualKey((uint)Keys.Scroll, 0), (int)KeyEvent.Down, 0);
                    keybd_event((byte)Keys.Scroll, (byte)MapVirtualKey((uint)Keys.Scroll, 0), (int)KeyEvent.Up, 0);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 设置NumLock的状态
        /// </summary>
        /// <param name="State">是否打开NumLock</param>
        /// <returns>是否执行成功</returns>
        public static bool SetNumLock(bool State)
        {
            try
            {
                if ((new Microsoft.VisualBasic.Devices.Keyboard()).NumLock != State)
                {
                    keybd_event((byte)Keys.NumLock, (byte)MapVirtualKey((uint)Keys.NumLock, 0), (int)KeyEvent.Down, 0);
                    keybd_event((byte)Keys.NumLock, (byte)MapVirtualKey((uint)Keys.NumLock, 0), (int)KeyEvent.Up, 0);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 点击多个键位，输入一段字符串（包括按下+释放过程，限定字符串内容）
        /// </summary>
        /// <param name="KeyString">键位字符串（只支持输入字母、数字、空格、换行、键盘上有的英文特殊符号，其它字符会被忽略）</param>
        /// <param name="MillisecondsInterval">输入每个字符的时间间隔（单位毫秒，默认值为0，无时间间隔）</param>
        /// <returns>是否执行成功</returns>
        public static bool Input(string KeyString, [Optional, DefaultParameterValue(0)] int MillisecondsInterval)
        {
            string AscString = "QWERTYUIOPASDFGHJKLZXCVBNM1234567890 \r\n";
            string LowerString = "qwertyuiopasdfghjklzxcvbnm";
            string OemString = @";=,-./`[\]'";
            string ShiftOemString = ":+<_>?~{|}\"";
            Keys[] OemKeys = new Keys[] { Keys.Oem1, Keys.Oemplus, Keys.Oemcomma, Keys.OemMinus, Keys.OemPeriod, Keys.Oem2, Keys.Oem3, Keys.Oem4, Keys.Oem5, Keys.Oem6, Keys.Oem7 };
            string ShiftNumString = "!@#$%^&*()";
            Keys[] NumKeys = new Keys[] { Keys.D1, Keys.D2, Keys.D3, Keys.D4, Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.D0 };
            try
            {
                char[] KeyArray = KeyString.ToCharArray();
                for (int i = 0; i <= KeyArray.Length - 1; i++)
                {
                    char Key = KeyArray[i];
                    if ((i > 0) & (MillisecondsInterval != 0))
                    {
                        try
                        {
                            Thread.Sleep(MillisecondsInterval);
                        }
                        catch (Exception ex) { }
                    }
                    if (AscString.Contains(Conversions.ToString(Key)))
                    {
                        //大写字母、数字、空格（虚拟键码VK值，与字符ASCII值相同）
                        if ((new Microsoft.VisualBasic.Devices.Keyboard()).CapsLock == false)
                        {
                            keybd_event((byte)Keys.CapsLock, (byte)MapVirtualKey((uint)Keys.CapsLock, 0), (int)KeyEvent.Down, 0);
                            keybd_event((byte)Keys.CapsLock, (byte)MapVirtualKey((uint)Keys.CapsLock, 0), (int)KeyEvent.Up, 0);
                        }
                        keybd_event((byte)Strings.Asc(Key), (byte)MapVirtualKey((uint)Strings.Asc(Key), 0), (int)KeyEvent.Down, 0);
                        keybd_event((byte)Strings.Asc(Key), (byte)MapVirtualKey((uint)Strings.Asc(Key), 0), (int)KeyEvent.Up, 0);
                    }
                    else if (LowerString.Contains(Conversions.ToString(Key)))
                    {
                        //小写字母
                        if ((new Microsoft.VisualBasic.Devices.Keyboard()).CapsLock)
                        {
                            keybd_event((byte)Keys.CapsLock, (byte)MapVirtualKey((uint)Keys.CapsLock, 0), (int)KeyEvent.Down, 0);
                            keybd_event((byte)Keys.CapsLock, (byte)MapVirtualKey((uint)Keys.CapsLock, 0), (int)KeyEvent.Up, 0);
                        }
                        Key = Conversions.ToChar(Key.ToString().ToUpper());
                        keybd_event((byte)Strings.Asc(Key), (byte)MapVirtualKey((uint)Strings.Asc(Key), 0), (int)KeyEvent.Down, 0);
                        keybd_event((byte)Strings.Asc(Key), (byte)MapVirtualKey((uint)Strings.Asc(Key), 0), (int)KeyEvent.Up, 0);
                    }
                    else if (OemString.Contains(Conversions.ToString(Key)))
                    {
                        //OEM键特殊符号
                        int index = OemString.IndexOf(Key);
                        keybd_event((byte)OemKeys[index], (byte)MapVirtualKey((uint)OemKeys[index], 0), (int)KeyEvent.Down, 0);
                        keybd_event((byte)OemKeys[index], (byte)MapVirtualKey((uint)OemKeys[index], 0), (int)KeyEvent.Up, 0);
                    }
                    else if (ShiftOemString.Contains(Conversions.ToString(Key)))
                    {
                        //Shift+OEM键特殊符号
                        int index = ShiftOemString.IndexOf(Key);
                        keybd_event((byte)Keys.ShiftKey, (byte)MapVirtualKey((uint)Keys.ShiftKey, 0), (int)KeyEvent.Down, 0);
                        keybd_event((byte)OemKeys[index], (byte)MapVirtualKey((uint)OemKeys[index], 0), (int)KeyEvent.Down, 0);
                        keybd_event((byte)OemKeys[index], (byte)MapVirtualKey((uint)OemKeys[index], 0), (int)KeyEvent.Up, 0);
                        keybd_event((byte)Keys.ShiftKey, (byte)MapVirtualKey((uint)Keys.ShiftKey, 0), (int)KeyEvent.Up, 0);
                    }
                    else if (ShiftNumString.Contains(Conversions.ToString(Key)))
                    {
                        //Shift+数字键特殊符号
                        int index = ShiftNumString.IndexOf(Key);
                        keybd_event((byte)Keys.ShiftKey, (byte)MapVirtualKey((uint)Keys.ShiftKey, 0), (int)KeyEvent.Down, 0);
                        keybd_event((byte)NumKeys[index], (byte)MapVirtualKey((uint)NumKeys[index], 0), (int)KeyEvent.Down, 0);
                        keybd_event((byte)NumKeys[index], (byte)MapVirtualKey((uint)NumKeys[index], 0), (int)KeyEvent.Up, 0);
                        keybd_event((byte)Keys.ShiftKey, (byte)MapVirtualKey((uint)Keys.ShiftKey, 0), (int)KeyEvent.Up, 0);
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        /// <summary>
        /// 连续复制粘贴字符，输入一段字符串（使用Ctrl+V组合键，速度太快时可能出错）
        /// </summary>
        /// <param name="Source">要输入的字符串</param>
        /// <param name="MillisecondsInterval">输入每个字符的时间间隔（单位毫秒，默认值为100，实测，在值较小、系统卡顿时，可能会发生字符混乱，建议设置为(byte)Keys.CapsLock以上）</param>
        /// <returns>是否执行成功</returns>
        public static bool PasteDelay(string Source, [Optional, DefaultParameterValue(100)] int MillisecondsInterval)
        {
            try
            {
                string str = "QWERTYUIOPASDFGHJKLZXCVBNM";
                int num2 = Source.Length - 1;
                for (int i = 0; i <= num2; i++)
                {
                    if ((i > 0) & (MillisecondsInterval != 0))
                    {
                        try
                        {
                            Thread.Sleep(MillisecondsInterval);
                        }
                        catch (Exception ex)
                        {
                        }
                    }
                    if (str.Contains(Conversions.ToString(Source[i])) && (new Microsoft.VisualBasic.Devices.Keyboard()).CapsLock == false)
                    {
                        keybd_event((byte)Keys.CapsLock, (byte)MapVirtualKey((uint)Keys.CapsLock, 0), (int)KeyEvent.Down, 0);
                        keybd_event((byte)Keys.CapsLock, (byte)MapVirtualKey((uint)Keys.CapsLock, 0), (int)KeyEvent.Up, 0);
                    }
                    Clipboard.SetText(Conversions.ToString(Source[i]));
                    keybd_event((byte)Keys.ControlKey, (byte)MapVirtualKey((uint)Keys.ControlKey, 0), (int)KeyEvent.Down, 0);
                    keybd_event((byte)Keys.V, (byte)MapVirtualKey((uint)Keys.V, 0), (int)KeyEvent.Down, 0);
                    keybd_event((byte)Keys.V, (byte)MapVirtualKey((uint)Keys.V, 0), (int)KeyEvent.Up, 0);
                    keybd_event((byte)Keys.ControlKey, (byte)MapVirtualKey((uint)Keys.ControlKey, 0), (int)KeyEvent.Up, 0);
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 复制粘贴，输入一段字符串（使用Ctrl+V组合键）
        /// </summary>
        /// <param name="Source">要输入的字符串</param>
        /// <returns>是否执行成功</returns>
        public static bool Paste(Bitmap Source)
        {
            try
            {
                Clipboard.SetImage(Source);
                keybd_event((byte)Keys.ControlKey, (byte)MapVirtualKey((uint)Keys.ControlKey, 0), (int)KeyEvent.Down, 0);
                keybd_event((byte)Keys.V, (byte)MapVirtualKey((uint)Keys.V, 0), (int)KeyEvent.Down, 0);
                keybd_event((byte)Keys.V, (byte)MapVirtualKey((uint)Keys.V, 0), (int)KeyEvent.Up, 0);
                keybd_event((byte)Keys.ControlKey, (byte)MapVirtualKey((uint)Keys.ControlKey, 0), (int)KeyEvent.Up, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 复制粘贴，输入一个图片（使用Ctrl+V组合键）
        /// </summary>
        /// <param name="Source">要输入的图片</param>
        /// <returns>是否执行成功</returns>
        public static bool Paste(string Source)
        {
            try
            {
                Clipboard.SetText(Source);
                keybd_event((byte)Keys.ControlKey, (byte)MapVirtualKey((uint)Keys.ControlKey, 0), (int)KeyEvent.Down, 0);
                keybd_event((byte)Keys.V, (byte)MapVirtualKey((uint)Keys.V, 0), (int)KeyEvent.Down, 0);
                keybd_event((byte)Keys.V, (byte)MapVirtualKey((uint)Keys.V, 0), (int)KeyEvent.Up, 0);
                keybd_event((byte)Keys.ControlKey, (byte)MapVirtualKey((uint)Keys.ControlKey, 0), (int)KeyEvent.Up, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}