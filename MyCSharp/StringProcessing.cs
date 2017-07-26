namespace My
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// 字符串处理相关函数
    /// </summary>
    public sealed partial class StringProcessing
    {

        /// <summary>
        /// 搜索字符串（搜寻第一个开始字符串，再向后搜寻第一个结束字符串，取出中间的部分）
        /// </summary>
        /// <param name="Source">要搜索的字符串</param>
        /// <param name="BeginString">开始位置的字符串（结果中不包含这一部分）</param>
        /// <param name="EndString">结束位置的字符串（结果中不包含这一部分）</param>
        /// <returns>结果字符串（失败返回空字符串）</returns>
        public static string Find(string Source, string BeginString, string EndString)
        {
            if (!Source.Contains(BeginString))
            {
                return "";
            }
            Source = Source.Substring(Source.IndexOf(BeginString) + BeginString.Length);
            if (!Source.Contains(EndString))
            {
                return "";
            }
            return Source.Substring(0, Source.IndexOf(EndString));
        }

        /// <summary>
        /// 搜索字符串（重复：搜寻开始字符串，再向后搜寻结束字符串，取出中间的部分）
        /// </summary>
        /// <param name="Source">要搜索的字符串</param>
        /// <param name="BeginString">开始位置的字符串（结果中不包含这一部分）</param>
        /// <param name="EndString">结束位置的字符串（结果中不包含这一部分）</param>
        /// <returns>结果字符串数组（失败返回空String数组）</returns>
        public static string[] FindAll(string Source, string BeginString, string EndString)
        {
            List<string> list = new List<string>();
            while (Source.Contains(BeginString))
            {
                Source = Source.Substring(Source.IndexOf(BeginString) + BeginString.Length);
                if (!Source.Contains(EndString))
                {
                    break;
                }
                list.Add(Source.Substring(0, Source.IndexOf(EndString)));
                Source = Source.Substring(Source.IndexOf(EndString) + EndString.Length);
            }
            return list.ToArray();
        }



        /// <summary>
        /// 搜索字符串（搜寻最后一个裁剪标志字符串，取出之后的部分）
        /// </summary>
        /// <param name="Source">要搜索的字符串</param>
        /// <param name="CutString">裁剪位置的标志字符串（结果中不包含这一部分）</param>
        /// <returns>结果字符串（失败返回空字符串）</returns>
        public static string FindAfter(string Source, string CutString)
        {
            if (!Source.Contains(CutString))
            {
                return "";
            }
            return Source.Substring(Source.LastIndexOf(CutString) + CutString.Length);
        }

        /// <summary>
        /// 搜索字符串（搜寻第一个裁剪标志字符串，取出之前的部分）
        /// </summary>
        /// <param name="Source">要搜索的字符串</param>
        /// <param name="CutString">裁剪位置的标志字符串（结果中不包含这一部分）</param>
        /// <returns>结果字符串（失败返回空字符串）</returns>
        public static string FindBefore(string Source, string CutString)
        {
            if (!Source.Contains(CutString))
            {
                return "";
            }
            return Source.Substring(0, Source.IndexOf(CutString));
        }



        /// <summary>
        /// 搜索字符串数组，取出不为空字符串""的元素，返回新数组（包括空格和制表符）
        /// </summary>
        /// <param name="Source">要搜索的字符串数组</param>
        /// <returns>结果字符串数组（失败返回空String数组）</returns>
        public static string[] SelectNotEmpty(string[] Source)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < Source.Length; i++)
            {
                if (Source[i] != "")
                {
                    list.Add(Source[i]);
                }
            }
            return list.ToArray();
        }

    }
}