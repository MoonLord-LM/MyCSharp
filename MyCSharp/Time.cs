namespace My
{
    using System;
    using System.Threading;

    /// <summary>
    /// 时间管理、转换相关函数
    /// </summary>
    /// <remarks></remarks>
    public sealed partial class Time
    {

        /// <summary>
        /// 将当前线程挂起指定的时间（System.Threading.Thread.Sleep）
        /// </summary>
        /// <param name="Millisecond">等待时间（单位毫秒，必须为非负值）</param>
        /// <remarks></remarks>
        public static void Wait(uint Millisecond)
        {
            if (Millisecond > 0)
            {
                try
                {
                    Thread.Sleep((int)Millisecond);
                }
                catch (Exception ex) { }
            }
        }



        /// <summary>
        /// 获取UNIX时间戳
        /// </summary>
        /// <returns>UNIX时间戳整数</returns>
        /// <remarks></remarks>
        public static uint Stamp()
        {
            return (uint)Math.Round(((TimeSpan)(DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, 0))).TotalSeconds);
        }

    }
}