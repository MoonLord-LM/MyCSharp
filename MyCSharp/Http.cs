namespace My
{
    using System;
    using System.Net;
    using System.Text;

    /// <summary>
    /// HTTP网络请求相关函数
    /// </summary>
    public sealed class Http
    {
        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="URL">网址链接</param>
        /// <returns>结果字符串（失败返回空字符串）</returns>
        public static string GetString(string URL)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding.UTF8;
            try
            {
                return client.DownloadString(URL);
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        /// <summary>
        /// 获取字符串
        /// </summary>
        /// <param name="URL">网址链接</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>结果字符串（失败返回空字符串）</returns>
        public static string GetString(string URL, Encoding Encoding)
        {
            WebClient client = new WebClient();
            client.Encoding = Encoding;
            try
            {
                return client.DownloadString(URL);
            }
            catch (Exception ex)
            {
                return "";
            }
        }



        /// <summary>
        /// 获取字节数组
        /// </summary>
        /// <param name="URL">网址链接</param>
        /// <returns>结果Byte数组（失败返回空Byte数组）</returns>
        public static byte[] GetByte(string URL)
        {
            WebClient client = new WebClient();
            try
            {
                return client.DownloadData(URL);
            }
            catch (Exception ex)
            {
                return new byte[0];
            }
        }



        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="URL">文件链接</param>
        /// <param name="FilePath">保存到的文件路径（可以是相对路径）</param>
        /// <returns>是否下载成功</returns>
        public static bool DownloadFile(string URL, string FilePath)
        {
            WebClient client = new WebClient();
            try
            {
                client.DownloadFile(new Uri(URL), FilePath);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
    }
}