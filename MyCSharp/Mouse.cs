namespace My
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;

    /// <summary>
    /// 模拟鼠标操作相关函数
    /// </summary>
    public sealed partial class Mouse
    {

        [DllImport("user32.dll", EntryPoint = "mouse_event", SetLastError = true)]
        private static extern void mouse_event(int dwFlags, int dX, int dY, int dwData, uint dwExtraInfo);
        [Flags]
        private enum MouseEvent : int
        {
            Move = 1,
            LeftButtonDown = 2,
            LeftButtonUp = 4,
            RightButtonDown = 8,
            RightButtonUp = 16,
            MiddleButtonDown = 32,
            MiddleButtonUp = 64,
            Wheel = 2048,
            AbsoluteLocation = 32768,
            AbsoluteScale = 65535
        }

        /// <summary>
        /// 移动鼠标位置，位移一定的像素点距离
        /// </summary>
        /// <param name="x">横向位移（向右为正方向）</param>
        /// <param name="y">纵向位移（向下为正方向）</param>
        /// <returns>是否执行成功</returns>
        public static bool MoveByPixel(int x, int y)
        {
            try
            {
                mouse_event((int)MouseEvent.Move, x, y, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 移动鼠标位置，位移一定的屏幕百分比
        /// </summary>
        /// <param name="x">横向位移（百分比，向右为正方向）</param>
        /// <param name="y">纵向位移（百分比，向下为正方向）</param>
        /// <returns>是否执行成功</returns>
        public static bool MoveByPercent(double x, double y)
        {
            try
            {
                mouse_event((int)MouseEvent.Move, (int)Math.Round(x * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width), (int)Math.Round(y * System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height), 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 移动鼠标位置，到指定的像素点坐标
        /// </summary>
        /// <param name="x">横坐标（原点为屏幕左上角，向右为正方向）</param>
        /// <param name="y">纵坐标（原点为屏幕左上角，向下为正方向）</param>
        /// <returns>是否执行成功</returns>
        public static bool MoveToPixel(int x, int y)
        {
            try
            {
                mouse_event((int)MouseEvent.Move | (int)MouseEvent.AbsoluteLocation, (int)Math.Round((double)(x / System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * (int)MouseEvent.AbsoluteScale)), (int)Math.Round((double)(y / System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height * (int)MouseEvent.AbsoluteScale)), 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 移动鼠标位置，到指定的屏幕百分比坐标
        /// </summary>
        /// <param name="x">横坐标（百分比，原点为屏幕左上角，向右为正方向）</param>
        /// <param name="y">纵坐标（百分比，原点为屏幕左上角，向下为正方向）</param>
        /// <returns>是否执行成功</returns>
        public static bool MoveToPercent(double x, double y)
        {
            try
            {
                mouse_event((int)MouseEvent.Move | (int)MouseEvent.AbsoluteLocation, (int)Math.Round(x * (int)MouseEvent.AbsoluteScale), (int)Math.Round(y * (int)MouseEvent.AbsoluteScale), 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 获取鼠标位置，像素点坐标值
        /// </summary>
        /// <returns>结果坐标值（原点为屏幕左上角，X向右为正方向，Y向下为正方向）</returns>
        public static Point Position()
        {
            return Control.MousePosition;
        }
        /// <summary>
        /// 获取鼠标位置的显示颜色，像素点Color值
        /// </summary>
        /// <returns>结果颜色值（System.Drawing.Color）</returns>
        public static Color PositionColor()
        {
            Rectangle bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
            Bitmap image = new Bitmap(bounds.Width, bounds.Height);
            Graphics graphics = Graphics.FromImage(image);
            graphics.CopyFromScreen(0, 0, 0, 0, bounds.Size);
            graphics.Dispose();
            Color pixel = image.GetPixel(Cursor.Position.X, Cursor.Position.Y);
            image.Dispose();
            return pixel;
        }
        /// <summary>
        /// 移动鼠标位置，到指定的像素点坐标
        /// </summary>
        /// <param name="Position">位置坐标（原点为屏幕左上角，X向右为正方向，Y向下为正方向）</param>
        /// <returns>是否执行成功</returns>
        public static bool MoveToPosition(Point Position)
        {
            try
            {
                mouse_event((int)MouseEvent.Move | (int)MouseEvent.AbsoluteLocation, (int)Math.Round((double)(Position.X / System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width * (int)MouseEvent.AbsoluteScale)), (int)Math.Round((double)(Position.Y / System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height * (int)MouseEvent.AbsoluteScale)), 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 按下鼠标左键（保持按下状态）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool LeftDown()
        {
            try
            {
                mouse_event((int)MouseEvent.LeftButtonDown, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 释放鼠标左键（取消按下状态）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool LeftUp()
        {
            try
            {
                mouse_event((int)MouseEvent.LeftButtonUp, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 鼠标左键单击
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool LeftClick()
        {
            try
            {
                mouse_event((int)MouseEvent.LeftButtonDown | (int)MouseEvent.LeftButtonUp, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 鼠标左键双击
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool LeftDoubleClick()
        {
            try
            {
                mouse_event((int)MouseEvent.LeftButtonDown | (int)MouseEvent.LeftButtonUp, 0, 0, 0, 0);
                mouse_event((int)MouseEvent.LeftButtonDown | (int)MouseEvent.LeftButtonUp, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 按下鼠标中键（保持按下状态）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool MiddleDown()
        {
            try
            {
                mouse_event((int)MouseEvent.MiddleButtonDown, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 释放鼠标中键（取消按下状态）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool MiddleUp()
        {
            try
            {
                mouse_event((int)MouseEvent.MiddleButtonUp, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 鼠标中键单击
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool MiddleClick()
        {
            try
            {
                mouse_event((int)MouseEvent.MiddleButtonDown | (int)MouseEvent.MiddleButtonUp, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 鼠标中键双击
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool MiddleDoubleClick()
        {
            try
            {
                mouse_event((int)MouseEvent.MiddleButtonDown | (int)MouseEvent.MiddleButtonUp, 0, 0, 0, 0);
                mouse_event((int)MouseEvent.MiddleButtonDown | (int)MouseEvent.MiddleButtonUp, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 按下鼠标右键（保持按下状态）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool RightDown()
        {
            try
            {
                mouse_event((int)MouseEvent.RightButtonDown, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 释放鼠标右键（取消按下状态）
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool RightUp()
        {
            try
            {
                mouse_event((int)MouseEvent.RightButtonUp, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 鼠标右键单击
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool RightClick()
        {
            try
            {
                mouse_event((int)MouseEvent.RightButtonDown | (int)MouseEvent.RightButtonUp, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 鼠标右键双击
        /// </summary>
        /// <returns>是否执行成功</returns>
        public static bool RightDoubleClick()
        {
            try
            {
                mouse_event((int)MouseEvent.RightButtonDown | (int)MouseEvent.RightButtonUp, 0, 0, 0, 0);
                mouse_event((int)MouseEvent.RightButtonDown | (int)MouseEvent.RightButtonUp, 0, 0, 0, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }



        /// <summary>
        /// 鼠标滚轮向下滚动
        /// </summary>
        /// <param name="ScrollValue">滚动距离（单位为像素）</param>
        /// <returns>是否执行成功</returns>
        public static bool WheelDown(int ScrollValue)
        {
            try
            {
                mouse_event((int)MouseEvent.Wheel, 0, 0, -ScrollValue, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 鼠标滚轮向上滚动
        /// </summary>
        /// <param name="ScrollValue">滚动距离（单位为像素）</param>
        /// <returns>是否执行成功</returns>
        public static bool WheelUp(int ScrollValue)
        {
            try
            {
                mouse_event((int)MouseEvent.Wheel, 0, 0, ScrollValue, 0);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

    }
}