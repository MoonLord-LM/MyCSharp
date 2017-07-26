namespace My
{
    using System;
    using System.IO;
    using System.Text;
    using System.Drawing;
    using System.Reflection;

    /// <summary>
    /// 程序资源文件相关函数
    /// </summary>
    public sealed partial class Resource
    {

        /// <summary>
        /// 读取程序嵌入的资源文件（注意必须在解决方案资源管理器中，将资源文件的"属性"-"生成操作"设置为"嵌入的资源"）
        /// </summary>
        /// <param name="ResourceName">资源文件名称（注意这个参数的值为资源文件在工程内的相对路径，例如A.zip文件在Resources文件夹内，则此处的参数应为"Resources.A.zip"）</param>
        /// <returns>结果Byte数组（失败返回空Byte数组）</returns>
        public static byte[] ReadByte(string ResourceName)
        {
            try
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + "." + ResourceName);
                byte[] buffer2 = new byte[((int) (manifestResourceStream.Length - 1L)) + 1];
                manifestResourceStream.Read(buffer2, 0, buffer2.Length);
                manifestResourceStream.Dispose();
                return buffer2;
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }

        /// <summary>
        /// 读取程序嵌入的图片类型的资源文件（注意必须在解决方案资源管理器中，将资源文件的"属性"-"生成操作"设置为"嵌入的资源"）
        /// </summary>
        /// <param name="ResourceName">资源文件名称（注意这个参数的值为资源文件在工程内的相对路径，例如A.jpg文件在Resources文件夹内，则此处的参数应为"Resources.A.jpg"）</param>
        /// <returns>结果图片（失败返回1*1个像素，#00000000透明色的图片）</returns>
        public static Bitmap ReadPicture(string ResourceName)
        {
            try
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                return new Bitmap(executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + "." + ResourceName));
            }
            catch (Exception ex)
            {
                return new Bitmap(1, 1);
            }
        }

        /// <summary>
        /// 读取程序嵌入的文本类型的资源文件（注意必须在解决方案资源管理器中，将资源文件的"属性"-"生成操作"设置为"嵌入的资源"）
        /// </summary>
        /// <param name="ResourceName">资源文件名称（注意这个参数的值为资源文件在工程内的相对路径，例如A.txt文件在Resources文件夹内，则此处的参数应为"Resources.A.txt"）</param>
        /// <returns>结果字符串（失败返回空字符串）</returns>
        public static string ReadString(string ResourceName)
        {
            try
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + "." + ResourceName);
                byte[] temp = new byte[((int) (manifestResourceStream.Length - 1L)) + 1];
                manifestResourceStream.Read(temp, 0, temp.Length);
                manifestResourceStream.Dispose();
                return Encoding.UTF8.GetString(temp);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// 读取程序嵌入的文本类型的资源文件（注意必须在解决方案资源管理器中，将资源文件的"属性"-"生成操作"设置为"嵌入的资源"）
        /// </summary>
        /// <param name="ResourceName">资源文件名称（注意这个参数的值为资源文件在工程内的相对路径，例如A.txt文件在Resources文件夹内，则此处的参数应为"Resources.A.txt"）</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>结果字符串（失败返回空字符串）</returns>
        public static string ReadString(string ResourceName, Encoding Encoding)
        {
            try
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + "." + ResourceName);
                byte[] temp = new byte[((int)(manifestResourceStream.Length - 1L)) + 1];
                manifestResourceStream.Read(temp, 0, temp.Length);
                manifestResourceStream.Dispose();
                return Encoding.UTF8.GetString(temp);
            }
            catch (Exception ex)
            {
                return "";
            }
        }

        /// <summary>
        /// 读取程序嵌入的字符串数组类型的资源文件（注意必须在解决方案资源管理器中，将资源文件的"属性"-"生成操作"设置为"嵌入的资源"）
        /// </summary>
        /// <param name="ResourceName">资源文件名称（注意这个参数的值为资源文件在工程内的相对路径，例如A.txt文件在Resources文件夹内，则此处的参数应为"Resources.A.txt"）</param>
        /// <returns>结果字符串数组（失败返回空String数组）</returns>
        public static string[] ReadStringArray(string ResourceName)
        {
            try
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + "." + ResourceName);
                byte[] temp = new byte[((int)(manifestResourceStream.Length - 1L)) + 1];
                manifestResourceStream.Read(temp, 0, temp.Length);
                manifestResourceStream.Dispose();
                return Encoding.UTF8.GetString(temp).Replace("\r\n", "\n").Split(new char[] { '\n' });
            }
            catch (Exception ex)
            {
                return new string[0];
            }
        }
        /// <summary>
        /// 读取程序嵌入的字符串数组类型的资源文件（注意必须在解决方案资源管理器中，将资源文件的"属性"-"生成操作"设置为"嵌入的资源"）
        /// </summary>
        /// <param name="ResourceName">资源文件名称（注意这个参数的值为资源文件在工程内的相对路径，例如A.txt文件在Resources文件夹内，则此处的参数应为"Resources.A.txt"）</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>结果字符串数组（失败返回空String数组）</returns>
        public static string[] ReadStringArray(string ResourceName, Encoding Encoding)
        {
            try
            {
                Assembly executingAssembly = Assembly.GetExecutingAssembly();
                Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(executingAssembly.GetName().Name + "." + ResourceName);
                byte[] temp = new byte[((int)(manifestResourceStream.Length - 1L)) + 1];
                manifestResourceStream.Read(temp, 0, temp.Length);
                manifestResourceStream.Dispose();
                return Encoding.GetString(temp).Replace("\r\n", "\n").Split(new char[] { '\n' });
            }
            catch (Exception ex)
            {
                return new string[0];
            }
        }

    }
}