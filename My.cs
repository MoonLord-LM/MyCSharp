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
            return System.Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(Source));
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
            return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(Source));
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
}
