namespace My
{
    //2015/5/10
    //My命名空间的扩展

    /// <summary>
    /// 编码与解码函数
    /// </summary>
    public sealed class Security
    {
        /// <summary>
        /// Base64加密算法
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string Base64_Encode(string Source)
        {
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Source));
        }
        /// <summary>
        /// Base64加密算法
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <param name="Encoding">使用的编码格式（默认UTF-8）</param>
        /// <returns>加密后的结果字符串</returns>
        public static string Base64_Encode(string Source, System.Text.Encoding Encoding)
        {
            return System.Convert.ToBase64String(Encoding.GetBytes(Source));
        }
        /// <summary>
        /// Base64解密算法
        /// </summary>
        /// <param name="Source">要解密的字符串</param>
        /// <returns>解密后的结果字符串</returns>
        public static string Base64_Decode(string Source)
        {
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Source));
        }
        /// <summary>
        /// Base64解密算法
        /// </summary>
        /// <param name="Source">要解密的字符串</param>
        /// <param name="Encoding">使用的编码格式（默认UTF-8）</param>
        /// <returns>解密后的结果字符串</returns>
        public static string Base64_Decode(string Source, System.Text.Encoding Encoding)
        {
            return Encoding.GetString(System.Convert.FromBase64String(Source));
        }
        /// <summary>
        /// MD5加密算法（返回16位小写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string MD5_Lower16_Encode(string Source)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Source, "MD5").Substring(8, 0x10).ToLower();
        }
        /// <summary>
        /// MD5加密算法（返回16位大写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string MD5_Upper16_Encode(string Source)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Source, "MD5").Substring(8, 0x10);
        }
        /// <summary>
        /// MD5加密算法（返回32位小写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string MD5_Lower32_Encode(string Source)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Source, "MD5").ToLower();
        }
        /// <summary>
        /// MD5加密算法（返回32位大写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string MD5_Upper32_Encode(string Source)
        {
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(Source, "MD5");
        }
        /// <summary>
        /// SHA1加密算法（返回40位小写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA1_Lower40_Encode(string Source)
        {
            return System.BitConverter.ToString(new System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(System.Text.Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToLower();
        }
        /// <summary>
        /// SHA1加密算法（返回40位大写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA1_Upper40_Encode(string Source)
        {
            return System.BitConverter.ToString(new System.Security.Cryptography.SHA1CryptoServiceProvider().ComputeHash(System.Text.Encoding.UTF8.GetBytes(Source))).Replace("-", "");
        }
        /// <summary>
        /// SHA256加密算法（返回64位小写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA256_Lower64_Encode(string Source)
        {
            return System.BitConverter.ToString(new System.Security.Cryptography.SHA256Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToLower();
        }
        /// <summary>
        /// SHA256加密算法（返回64位大写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA256_Upper64_Encode(string Source)
        {
            return System.BitConverter.ToString(new System.Security.Cryptography.SHA256Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(Source))).Replace("-", "");
        }
        /// <summary>
        /// SHA384加密算法（返回96位小写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA384_Lower96_Encode(string Source)
        {
            return System.BitConverter.ToString(new System.Security.Cryptography.SHA384Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToLower();
        }
        /// <summary>
        /// SHA384加密算法（返回96位大写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA384_Upper96_Encode(string Source)
        {
            return System.BitConverter.ToString(new System.Security.Cryptography.SHA384Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(Source))).Replace("-", "");
        }
        /// <summary>
        /// SHA512加密算法（返回128位小写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA512_Lower128_Encode(string Source)
        {
            return System.BitConverter.ToString(new System.Security.Cryptography.SHA512Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToLower();
        }
        /// <summary>
        /// SHA512加密算法（返回128位大写结果）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA512_Upper128_Encode(string Source)
        {
            return System.BitConverter.ToString(new System.Security.Cryptography.SHA512Managed().ComputeHash(System.Text.Encoding.UTF8.GetBytes(Source))).Replace("-", "");
        }
        /// <summary>
        /// DES加密算法
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <param name="SecretKey">加密密钥（8的整数倍字节数的字符串）</param>
        /// <returns>加密后的结果字符串</returns>
        public static byte[] DES_Encode(string Source, string SecretKey)
        {
            System.Security.Cryptography.DESCryptoServiceProvider provider = new System.Security.Cryptography.DESCryptoServiceProvider();
            try
            {
                provider.Key = System.Text.Encoding.UTF8.GetBytes(SecretKey);
            }
            catch (System.ArgumentException)
            {
                byte[] buffer = new byte[0];
                return buffer;
            }
            provider.IV = System.Text.Encoding.UTF8.GetBytes(SecretKey);
            System.IO.MemoryStream stream2 = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream stream = new System.Security.Cryptography.CryptoStream(stream2, provider.CreateEncryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            stream.Write(System.Text.Encoding.UTF8.GetBytes(Source), 0, System.Text.Encoding.UTF8.GetBytes(Source).Length);
            stream.FlushFinalBlock();
            return stream2.ToArray();
        }
        /// <summary>
        /// DES解密算法
        /// </summary>
        /// <param name="Source">要解密的字符串</param>
        /// <param name="SecretKey">解密密钥（8的整数倍字节数的字符串）</param>
        /// <returns>解密后的结果字符串</returns>
        public static string DES_Decode(byte[] Source, string SecretKey)
        {
            System.Security.Cryptography.DESCryptoServiceProvider provider = new System.Security.Cryptography.DESCryptoServiceProvider();
            provider.Key = System.Text.Encoding.UTF8.GetBytes(SecretKey);
            provider.IV = System.Text.Encoding.UTF8.GetBytes(SecretKey);
            System.IO.MemoryStream stream2 = new System.IO.MemoryStream();
            System.Security.Cryptography.CryptoStream stream = new System.Security.Cryptography.CryptoStream(stream2, provider.CreateDecryptor(), System.Security.Cryptography.CryptoStreamMode.Write);
            stream.Write(Source, 0, Source.Length);
            try
            {
                stream.FlushFinalBlock();
            }
            catch (System.Security.Cryptography.CryptographicException)
            {
                return "";
            }
            return System.Text.Encoding.UTF8.GetString(stream2.ToArray());
        }
        /// <summary>
        /// RSA加密算法
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果字符串</returns>
        public static byte[] RSA_Encode(string Source)
        {
            System.Security.Cryptography.RSACryptoServiceProvider provider = new System.Security.Cryptography.RSACryptoServiceProvider();
            provider.FromXmlString("<RSAKeyValue><Modulus>pZGIiC3CxVYpTJ4dLylSy2TLXW+R9EyRZ39ekSosvRKf7iPuz4oPlHqjssh4Glbj/vTUIMFzHFC/9zC56GggNLfZBjh6fc3adq5cXGKlU74kAyM2z7gdYlUHtLT/GwDp4YcQKeSb9GjcvsXbUp0mrzI/axzueLIqK+R07rnv3yc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
            return provider.Encrypt(System.Text.Encoding.UTF8.GetBytes(Source), true);
        }
        /// <summary>
        /// RSA解密算法
        /// </summary>
        /// <param name="Source">要解密的字符串</param>
        /// <returns>解密后的结果字符串</returns>
        public static string RSA_Decode(byte[] Source)
        {
            string str;
            System.Security.Cryptography.RSACryptoServiceProvider provider = new System.Security.Cryptography.RSACryptoServiceProvider();
            provider.FromXmlString("<RSAKeyValue><Modulus>pZGIiC3CxVYpTJ4dLylSy2TLXW+R9EyRZ39ekSosvRKf7iPuz4oPlHqjssh4Glbj/vTUIMFzHFC/9zC56GggNLfZBjh6fc3adq5cXGKlU74kAyM2z7gdYlUHtLT/GwDp4YcQKeSb9GjcvsXbUp0mrzI/axzueLIqK+R07rnv3yc=</Modulus><Exponent>AQAB</Exponent><P>0wCnxVUMgu+Uqp3UJ18bp9Ahdad36wDMwa0tmHxZJUvBZEfcYpsxmSHLpTUBCcAIg2eJL5g/iK9LrIwDBvUZ+w==</P><Q>yOB6ZwG9TuXMRPCA9cFTKCoHEsreDZluptHEfG3HvnS1lp5xwRCHXVuh7VWOM0G2gnZ/JWwWIfcqf30UTWvTxQ==</Q><DP>BTc67nHPwVzSu/TyzZZYRKmsahAdsr1uUktJmT9ZpMZenW/5Tqavby2arxbEU81faIAir/5/c42BvV4opP9iCQ==</DP><DQ>QETR5LMBxoRvXn80Q2yfFnKb4L9XXDKC3IywuL7G8YCVuKLo8kQ/ivcOT8jXvj6ADi2rcGWsjyFtT2zNWhftoQ==</DQ><InverseQ>jwpY6fpkzwtLOABZQncXMC4h7VbYrx+sZeSrBFXAgw1WMSs9YsT6EQcDRjpGt7JAkP14nSTSIVJNd23jZURCLw==</InverseQ><D>cw6SqcfbLVV198d9EnQOFEgkRvcsn2/CMAFET27WjkHuIAiagWE4+H7NWYWUaQFvCZNMAsNMYiX/cSFMYCRUFBBgkPqaqQ3+3qCs/kKiWpDjRwX8eXrMAnWniFDEoxc229Mxl4QZrcYKVRxrCIq8wKamuoWgwN0M+3CAiLwLvNk=</D></RSAKeyValue>");
            try
            {
                str = System.Text.Encoding.UTF8.GetString(provider.Decrypt(Source, true));
            }
            catch (System.Exception)
            {
                return "";
            }
            return str;
        }
    }

    /// <summary>
    /// 网络访问函数
    /// </summary>
    public sealed class Http
    {
        /// <summary>
        /// 获取网页源码
        /// </summary>
        /// <param name="URL">网页链接</param>
        /// <returns>网页源码字符串</returns>
        public static string GetString(string URL)
        {
            System.Net.WebClient Client = new System.Net.WebClient();
            Client.Encoding = System.Text.Encoding.UTF8;
            try {
                return Client.DownloadString(URL);
            }
            catch(System.Exception){
                return "";
            }
        }
        /// <summary>
        /// 获取网页源码
        /// </summary>
        /// <param name="URL">网页链接</param>
        /// <param name="Encoding">使用的编码格式（默认UTF-8）</param>
        /// <returns>网页源码字符串</returns>
        public static string GetString(string URL, System.Text.Encoding Encoding)
        {
            System.Net.WebClient Client = new System.Net.WebClient();
            Client.Encoding = Encoding;
            try
            {
                return Client.DownloadString(URL);
            }
            catch (System.Exception)
            {
                return "";
            }
        }
        /// <summary>
        /// 下载文件到磁盘
        /// </summary>
        /// <param name="URL">文件链接</param>
        /// <param name="FilePath">文件保存路径（可以是相对路径）</param>
        /// <returns>是否下载成功</returns>
        public static bool DownloadFile(string URL, string FilePath)
        {
            System.Net.WebClient Client = new System.Net.WebClient();
            try
            {
                Client.DownloadFile(new System.Uri(URL), FilePath);
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
    }

    /// <summary>
    /// 磁盘读写函数
    /// </summary>
    public sealed class IO {
        /// <summary>
        /// 将字符串数组写入文件
        /// </summary>
        /// <param name="StringArray">字符串数组</param>
        /// <param name="FilePath">文件路径（可以是相对路径）</param>
        /// <returns>是否写入成功</returns>
        public static bool SaveStringArray(ref System.Collections.ArrayList StringArray, string FilePath)
        {
            System.IO.StreamWriter Writer;
            System.Text.StringBuilder Builder;
            try{
                Builder = new System.Text.StringBuilder();
                for (int i = 0; i < StringArray.Count - 1; i++)
                {
                    Builder.Append(StringArray[i] + "\r\n");
                }
                if (StringArray.Count > 0)
                {
                    Builder.Append(StringArray[StringArray.Count - 1]);
                }
                Writer = new System.IO.StreamWriter(FilePath, false, System.Text.Encoding.UTF8);
                Writer.Write(Builder);
                Writer.Dispose();
                return true;
            }
            catch( System.Exception){
                return false;
            }
        }
        /// <summary>
        /// 将字符串数组写入文件
        /// </summary>
        /// <param name="StringArray">字符串数组</param>
        /// <param name="FilePath">文件路径（可以是相对路径）</param>
        /// <returns>是否写入成功</returns>
        public static bool SaveStringArray(ref System.Collections.Generic.List<string> StringArray, string FilePath)
        {
            System.IO.StreamWriter Writer;
            System.Text.StringBuilder Builder;
            try
            {
                Builder = new System.Text.StringBuilder();
                for (int i = 0; i < StringArray.Count - 1; i++)
                {
                    Builder.Append(StringArray[i] + "\r\n");
                }
                if (StringArray.Count > 0)
                {
                    Builder.Append(StringArray[StringArray.Count - 1]);
                }
                Writer = new System.IO.StreamWriter(FilePath, false, System.Text.Encoding.UTF8);
                Writer.Write(Builder);
                Writer.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 将字符串数组写入文件
        /// </summary>
        /// <param name="StringArray">字符串数组</param>
        /// <param name="FilePath">文件路径（可以是相对路径）</param>
        /// <returns>是否写入成功</returns>
        public static bool SaveStringArray(ref string[] StringArray, string FilePath)
        {
            System.IO.StreamWriter Writer;
            System.Text.StringBuilder Builder;
            try
            {
                Builder = new System.Text.StringBuilder();
                for (int i = 0; i < StringArray.Length - 1; i++)
                {
                    Builder.Append(StringArray[i] + "\r\n");
                }
                if (StringArray.Length > 0)
                {
                    Builder.Append(StringArray[StringArray.Length - 1]);
                }
                Writer = new System.IO.StreamWriter(FilePath, false, System.Text.Encoding.UTF8);
                Writer.Write(Builder);
                Writer.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 读取文件中的字符串数组
        /// </summary>
        /// <param name="StringArray">字符串数组</param>
        /// <param name="FilePath">文件路径（可以是相对路径）</param>
        /// <returns>是否读取成功</returns>
        public static bool ReadStringArray(ref System.Collections.ArrayList StringArray, string FilePath)
        {
            System.IO.StreamReader Reader;
            try
            {
                Reader = new System.IO.StreamReader(FilePath, System.Text.Encoding.UTF8);
                StringArray = new System.Collections.ArrayList(Reader.ReadToEnd().Replace("\r\n", "\n").Split(new char[] { '\n' }));
                Reader.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 读取文件中的字符串数组
        /// </summary>
        /// <param name="StringArray">字符串数组</param>
        /// <param name="FilePath">文件路径（可以是相对路径）</param>
        /// <returns>是否读取成功</returns>
        public static bool ReadStringArray(ref System.Collections.Generic.List<string> StringArray, string FilePath)
        {
            System.IO.StreamReader Reader;
            try
            {
                Reader = new System.IO.StreamReader(FilePath, System.Text.Encoding.UTF8);
                StringArray = new System.Collections.Generic.List<string>(Reader.ReadToEnd().Replace("\r\n", "\n").Split(new char[] { '\n' }));
                Reader.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 读取文件中的字符串数组
        /// </summary>
        /// <param name="StringArray">字符串数组</param>
        /// <param name="FilePath">文件路径（可以是相对路径）</param>
        /// <returns>是否读取成功</returns>
        public static bool ReadStringArray(ref string[] StringArray, string FilePath)
        {
            System.IO.StreamReader Reader;
            try
            {
                Reader = new System.IO.StreamReader(FilePath, System.Text.Encoding.UTF8);
                StringArray = Reader.ReadToEnd().Replace("\r\n", "\n").Split(new char[] { '\n' });
                Reader.Dispose();
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// 获取指定目录下的全部的文件
        /// </summary>
        /// <param name="FilePathArray">保存文件路径的字符串数组</param>
        /// <param name="SearchDirectory">要搜索的文件夹路径</param>
        /// <returns>是否获取成功</returns>
        public static bool GetAllFilePath(ref System.Collections.Generic.List<string> FilePathArray, string SearchDirectory)
        {
            System.Collections.Generic.List<string> Directory = new System.Collections.Generic.List<string>();
            try
            {
                foreach (string Temp in System.IO.Directory.GetFiles(SearchDirectory))
                {
                    FilePathArray.Add(Temp);
                }
                foreach (string Temp in System.IO.Directory.GetDirectories(SearchDirectory))
                {
                    Directory.Add(Temp);
                }
                int Index = 0;
                while (Directory.Count > Index)
                {
                    SearchDirectory = Directory[Index];
                    Index++;
                    foreach (string Temp in System.IO.Directory.GetFiles(SearchDirectory))
                    {
                        FilePathArray.Add(Temp);
                    }
                    foreach (string Temp in System.IO.Directory.GetDirectories(SearchDirectory))
                    {
                        Directory.Add(Temp);
                    }
                }
                return true;
            }
            catch (System.Exception )
            {
                return false;
            }
        }
        /// <summary>
        /// 获取指定文件的行数
        /// </summary>
        /// <param name="FilePath">文件路径（可以是相对路径）</param>
        /// <returns>行数（获取失败时返回0）</returns>
        public static int GetFileLine(string FilePath)
        {
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(FilePath, System.Text.Encoding.UTF8);
                return  reader.ReadToEnd().Replace("\r\n", "\n").Split(new char[] { '\n' }).Length;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
        /// <summary>
        /// 获取指定文件的行数
        /// </summary>
        /// <param name="FilePath">文件路径（可以是相对路径）</param>
        /// <param name="Encoding">使用的编码格式（默认UTF-8）</param>
        /// <returns>行数（获取失败时返回0）</returns>
        public static int GetFileLine(string FilePath, System.Text.Encoding Encoding)
        {
            try
            {
                System.IO.StreamReader reader = new System.IO.StreamReader(FilePath, Encoding);
                return  reader.ReadToEnd().Replace("\r\n", "\n").Split(new char[] { '\n' }).Length;
            }
            catch (System.Exception)
            {
                return 0;
            }
        }
    }

    /// <summary>
    /// 字符串处理函数
    /// </summary>
    public sealed class StringData {
        /// <summary>
        /// 搜索字符串（从第一个开始字符串的位置，向后搜寻结束字符串，取出中间的部分）
        /// </summary>
        /// <param name="SourceCode">要搜索的字符串</param>
        /// <param name="BeginString">开始字符串</param>
        /// <param name="EndString">结束字符串</param>
        /// <returns>搜索结果字符串（无结果时返回空字符串）</returns>
        public static string SearchForward(ref string SourceCode, string BeginString, string EndString)
        {
            if (!SourceCode.Contains(BeginString))
            {
                return "";
            }
            SourceCode = SourceCode.Substring(SourceCode.IndexOf(BeginString) + BeginString.Length);
            if (!SourceCode.Contains(EndString))
            {
                return "";
            }
            return SourceCode.Substring(0, SourceCode.IndexOf(EndString));
        }
        /// <summary>
        /// 搜索字符串（从最后一个结束字符串的位置，向前搜寻开始字符串，取出中间的部分）
        /// </summary>
        /// <param name="SourceCode">要搜索的字符串</param>
        /// <param name="BeginString">开始字符串</param>
        /// <param name="EndString">结束字符串</param>
        /// <returns>搜索结果字符串（无结果时返回空字符串）</returns>
        public static string SearchBackward(ref string SourceCode, string BeginString, string EndString)
        {
            if (!SourceCode.Contains(EndString))
            {
                return "";
            }
            SourceCode = SourceCode.Substring(0, SourceCode.LastIndexOf(EndString));
            if (!SourceCode.Contains(BeginString))
            {
                return "";
            }
            return SourceCode.Substring(SourceCode.LastIndexOf(BeginString) + BeginString.Length);
        }
        /// <summary>
        /// 搜索字符串（从第一个开始字符串的位置，向后搜寻最后一个结束字符串的位置，取出中间的部分）
        /// </summary>
        /// <param name="SourceCode">要搜索的字符串</param>
        /// <param name="BeginString">开始字符串</param>
        /// <param name="EndString">结束字符串</param>
        /// <returns>搜索结果字符串（无结果时返回空字符串）</returns>
        public static string SearchMiddle(ref string SourceCode, string BeginString, string EndString)
        {
            if (!SourceCode.Contains(BeginString))
            {
                return "";
            }
            SourceCode = SourceCode.Substring(SourceCode.IndexOf(BeginString) + BeginString.Length);
            if (!SourceCode.Contains(EndString))
            {
                return "";
            }
            return SourceCode.Substring(0, SourceCode.LastIndexOf(EndString));
        }
        /// <summary>
        /// 搜索字符串（从第一个开始字符串的位置，向后搜寻结束字符串，取出中间的部分，重复向后搜索，返回数组）
        /// </summary>
        /// <param name="SourceCode">要搜索的字符串</param>
        /// <param name="BeginString">开始字符串</param>
        /// <param name="EndString">结束字符串</param>
        /// <returns>搜索结果字符串数组（无结果时返回空数组）</returns>
        public static System.Collections.Generic.List<string> SearchAllForward(ref string SourceCode, string BeginString, string EndString)
        {
            System.Collections.Generic.List<string> Temp = new System.Collections.Generic.List<string>();
            while (SourceCode.Contains(BeginString))
            {
                SourceCode = SourceCode.Substring(SourceCode.IndexOf(BeginString) + BeginString.Length);
                if (!SourceCode.Contains(EndString))
                {
                    return Temp;
                }
                Temp.Add(SourceCode.Substring(0, SourceCode.IndexOf(EndString)));
            }
            return Temp;
        }
        /// <summary>
        /// 搜索字符串（从最后一个结束字符串的位置，向前搜寻开始字符串，取出中间的部分，重复向前搜索，返回数组）
        /// </summary>
        /// <param name="SourceCode">要搜索的字符串</param>
        /// <param name="BeginString">开始字符串</param>
        /// <param name="EndString">结束字符串</param>
        /// <returns>搜索结果字符串数组（无结果时返回空数组）</returns>
        public static System.Collections.Generic.List<string> SearchAllBackward(ref string SourceCode, string BeginString, string EndString)
        {
            System.Collections.Generic.List<string> Temp = new System.Collections.Generic.List<string>();
            while (SourceCode.Contains(EndString))
            {
                SourceCode = SourceCode.Substring(0, SourceCode.LastIndexOf(EndString));
                if (!SourceCode.Contains(BeginString))
                {
                    return Temp;
                }
                Temp.Add(SourceCode.Substring(SourceCode.LastIndexOf(BeginString) + BeginString.Length));
            }
            return Temp;
        }
        /// <summary>
        /// 搜索字符串（从第一个开始字符串的位置，向后搜寻最后一个结束字符串的位置，取出中间的部分，重复向中间搜索，返回数组）
        /// </summary>
        /// <param name="SourceCode">要搜索的字符串</param>
        /// <param name="BeginString">开始字符串</param>
        /// <param name="EndString">结束字符串</param>
        /// <returns>搜索结果字符串数组（无结果时返回空数组）</returns>
        public static System.Collections.Generic.List<string> SearchAllMiddle(ref string SourceCode, string BeginString, string EndString)
        {
            System.Collections.Generic.List<string> Temp = new System.Collections.Generic.List<string>();
            while (SourceCode.Contains(BeginString))
            {
                SourceCode = SourceCode.Substring(SourceCode.IndexOf(BeginString) + BeginString.Length);
                if (!SourceCode.Contains(EndString))
                {
                    return Temp;
                }
                Temp.Add(SourceCode.Substring(0, SourceCode.LastIndexOf(EndString)));
            }
            return Temp;
        }
    }

    /// <summary>
    /// HTML代码处理函数
    /// </summary>
    public sealed class StringData {
        /// <summary>
        /// 获取网页源码中指定标签的元素的文本
        /// </summary>
        /// <param name="Source">网页源代码</param>
        /// <param name="HtmlTag">元素标签</param>
        /// <returns>文本字符串数组</returns>
        public static System.Collections.Generic.List<string> GetTextByTagName(string Source, string HtmlTag)
        {
            System.Collections.Generic.List<string> Temp = new System.Collections.Generic.List<string>();
            System.Windows.Forms.WebBrowser browser = new System.Windows.Forms.WebBrowser();
            browser.DocumentText = "";
            browser.Document.OpenNew(true).Write(Source);
            System.Windows.Forms.HtmlElementCollection elementsByTagName = browser.Document.GetElementsByTagName(HtmlTag);
            for (int i = 0; i <= elementsByTagName.Count - 1; i++)
            {
                Temp.Add(elementsByTagName[i].InnerText);
            }
            return Temp;
        }
        /// <summary>
        /// 获取网页源码中指定ID的元素的文本
        /// </summary>
        /// <param name="Source">网页源代码</param>
        /// <param name="Id">元素ID</param>
        /// <returns>文本字符串</returns>
        public static string GetTextById(string Source, string Id)
        {
            System.Windows.Forms.WebBrowser browser = new System.Windows.Forms.WebBrowser();
            browser.DocumentText = "";
            browser.Document.OpenNew(true).Write(Source);
            return browser.Document.GetElementById(Id).InnerText;
        }
    }
}
