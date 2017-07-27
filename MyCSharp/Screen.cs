namespace My
{
    using System;
    using System.Drawing;

    /// <summary>
    /// 屏幕截图相关函数
    /// </summary>
    public sealed partial class Screen
    {

        /// <summary>
        /// 获取屏幕截图（全屏区域的截图）
        /// </summary>
        /// <returns>结果图片（失败返回1*1个像素，#00000000透明色的图片）</returns>
        public static Bitmap Image()
        {
            try
            {
                Rectangle bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
                Bitmap image = new Bitmap(bounds.Width, bounds.Height);
                Graphics graphics = Graphics.FromImage(image);
                graphics.CopyFromScreen(0, 0, 0, 0, bounds.Size);
                graphics.Dispose();
                return image;
            }
            catch (Exception ex)
            {
                return new Bitmap(1, 1);
            }
        }

        /// <summary>
        /// 获取屏幕截图（指定区域的截图）
        /// </summary>
        /// <param name="Area">指定区域（System.Drawing.Rectangle）</param>
        /// <returns>结果图片（失败返回1*1个像素，#00000000透明色的图片）</returns>
        public static Bitmap Image(Rectangle Area)
        {
            try
            {
                Bitmap image = new Bitmap(Area.Width, Area.Height);
                Graphics graphics = Graphics.FromImage(image);
                graphics.CopyFromScreen(Area.Left, Area.Top, 0, 0, Area.Size);
                graphics.Dispose();
                return image;
            }
            catch (Exception ex)
            {
                return new Bitmap(1, 1);
            }
        }

        /// <summary>
        /// 获取屏幕截图（全屏区域的缩略图）
        /// </summary>
        /// <param name="Scale">缩略比例（应大于0，且小于等于1）</param>
        /// <returns>结果图片（失败返回1*1个像素，#00000000透明色的图片）</returns>
        public static Bitmap ImageThumbnail(double Scale)
        {
            if (Scale <= 0 | Scale > 1)
            {
                return new Bitmap(1, 1);
            }
            try
            {
                Rectangle bounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;
                Bitmap image = new Bitmap(bounds.Width, bounds.Height);
                Graphics graphics = Graphics.FromImage(image);
                graphics.CopyFromScreen(0, 0, 0, 0, bounds.Size);
                graphics.Dispose();
                Bitmap thumbnail = (Bitmap)image.GetThumbnailImage((int)Math.Round((double)(bounds.Width * Scale)), (int)Math.Round((double)(bounds.Height * Scale)), null, new IntPtr(0));
                image.Dispose();
                return thumbnail;
            }
            catch (Exception ex)
            {
                return new Bitmap(1, 1);
            }
        }
        /// <summary>
        /// 获取屏幕截图（指定区域的缩略图）
        /// </summary>
        /// <param name="Area">指定区域（System.Drawing.Rectangle）</param>
        /// <param name="Scale">缩略比例（应大于0，且小于等于1）</param>
        /// <returns>结果图片（失败返回1*1个像素，#00000000透明色的图片）</returns>
        public static Bitmap ImageThumbnail(Rectangle Area, double Scale)
        {
            if (Scale <= 0 | Scale > 1)
            {
                return new Bitmap(1, 1);
            }
            try
            {
                Bitmap image = new Bitmap(Area.Width, Area.Height);
                Graphics graphics = Graphics.FromImage(image);
                graphics.CopyFromScreen(Area.Left, Area.Top, 0, 0, Area.Size);
                graphics.Dispose();
                Bitmap thumbnail = (Bitmap)image.GetThumbnailImage((int)Math.Round((double)(Area.Width * Scale)), (int)Math.Round((double)(Area.Height * Scale)), null, new IntPtr(0));
                image.Dispose();
                return thumbnail;
            }
            catch (Exception ex)
            {
                return new Bitmap(1, 1);
            }
        }



        /// <summary>
        /// 获取屏幕区域
        /// </summary>
        /// <returns>结果区域值（System.Drawing.Rectangle）</returns>
        public static Rectangle Area()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.Bounds;
        }
        /// <summary>
        /// 获取屏幕区域大小
        /// </summary>
        /// <returns>结果大小值（System.Drawing.Size）</returns>
        public static System.Drawing.Size Size()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.Bounds.Size;
        }
        /// <summary>
        /// 获取屏幕中心点坐标
        /// </summary>
        /// <returns>结果坐标值（System.Drawing.Point）</returns>
        public static Point CenterPoint()
        {
            return new Point(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width / 2, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height / 2);
        }
        /// <summary>
        /// 获取屏幕工作区域
        /// </summary>
        /// <returns>结果区域值（System.Drawing.Rectangle）</returns>
        public static Rectangle WorkingArea()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
        }
        /// <summary>
        /// 获取屏幕工作区域大小
        /// </summary>
        /// <returns>结果大小值（System.Drawing.Size）</returns>
        public static System.Drawing.Size WorkingAreaSize()
        {
            return System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Size;
        }
        /// <summary>
        /// 获取屏幕工作区域中心点坐标
        /// </summary>
        /// <returns>结果坐标值（System.Drawing.Point）</returns>
        public static Point WorkingAreaCenterPoint()
        {
            return new Point(System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2, System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / 2);
        }

    }
}