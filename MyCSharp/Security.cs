namespace My
{
    using System;
    using System.IO;
    using System.Web;
    using System.Text;
    using System.Web.Security;
    using System.Security.Cryptography;
    using System.Runtime.InteropServices;

    /// <summary>
    /// 编码解码、加密解密相关函数
    /// </summary>
    public sealed partial class Security
    {

        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="Source">要编码的字符串</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>编码后的结果字符串</returns>
        public static string URL_Encode(string Source, [Optional, DefaultParameterValue(false)] bool ToUpper)
        {
            if (ToUpper)
            {
                return HttpUtility.UrlEncode(Source, Encoding.UTF8).ToUpper();
            }
            return HttpUtility.UrlEncode(Source, Encoding.UTF8).ToLower();
        }
        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>编码后的结果字符串</returns>
        public static string URL_Encode(string Source, Encoding Encoding, [Optional, DefaultParameterValue(false)] bool ToUpper)
        {
            if (ToUpper)
            {
                return HttpUtility.UrlEncode(Source, Encoding).ToUpper();
            }
            return HttpUtility.UrlEncode(Source, Encoding).ToLower();
        }

        /// <summary>
        /// URL解码
        /// </summary>
        /// <param name="Source">要解码的字符串（不区分大小写字母形式）</param>
        /// <returns>解码后的结果字符串</returns>
        public static string URL_Decode(string Source)
        {
            return HttpUtility.UrlDecode(Source, Encoding.UTF8);
        }
        /// <summary>
        /// URL解码
        /// </summary>
        /// <param name="Source">要解码的字符串（不区分大小写字母形式）</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>解码后的结果字符串</returns>
        public static string URL_Decode(string Source, Encoding Encoding)
        {
            return HttpUtility.UrlDecode(Source, Encoding);
        }



        /// <summary>
        /// Base64编码（编码结果的字符串中包含字母A-Z，a-z，数字0-9，符号+/=）
        /// </summary>
        /// <param name="Source">要编码的字符串</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Base64_Encode(string Source)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(Source));
        }
        /// <summary>
        /// Base64编码（编码结果的字符串中包含字母A-Z，a-z，数字0-9，符号+/=）
        /// </summary>
        /// <param name="Source">要编码的字符串</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Base64_Encode(string Source, Encoding Encoding)
        {
            return Convert.ToBase64String(Encoding.GetBytes(Source));
        }

        /// <summary>
        /// Base64解码（要解码的字符串可以包含字母A-Z，a-z，数字0-9，符号+/=）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <returns>解码后的结果字符串</returns>
        public static string Base64_Decode(string Source)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(Source));
        }
        /// <summary>
        /// Base64解码（要解码的字符串可以包含字母A-Z，a-z，数字0-9，符号+/=）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>解码后的结果字符串</returns>
        public static string Base64_Decode(string Source, Encoding Encoding)
        {
            return Encoding.GetString(Convert.FromBase64String(Source));
        }



        /// <summary>
        /// Base64编码（用于URL的改进Base64编码，编码结果的字符串中包含字母A-Z，a-z，数字0-9，符号-_=）
        /// </summary>
        /// <param name="Source">要编码的字符串</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Base64_URL_Encode(string Source)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(Source)).Replace("+", "-").Replace("/", "_");
        }
        /// <summary>
        /// Base64编码（用于URL的改进Base64编码，编码结果的字符串中包含字母A-Z，a-z，数字0-9，符号-_=）
        /// </summary>
        /// <param name="Source">要编码的字符串</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Base64_URL_Encode(string Source, Encoding Encoding)
        {
            return Convert.ToBase64String(Encoding.GetBytes(Source)).Replace("+", "-").Replace("/", "_");
        }

        /// <summary>
        /// Base64解码（用于URL的改进Base64解码，要解码的字符串可以包含字母A-Z，a-z，数字0-9，符号-_=）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <returns>解码后的结果字符串</returns>
        public static string Base64_URL_Decode(string Source)
        {
            return Encoding.UTF8.GetString(Convert.FromBase64String(Source.Replace("-", "+").Replace("_", "/")));
        }
        /// <summary>
        /// Base64解码（用于URL的改进Base64解码，要解码的字符串可以包含字母A-Z，a-z，数字0-9，符号-_=）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>解码后的结果字符串</returns>
        public static string Base64_URL_Decode(string Source, Encoding Encoding)
        {
            return Encoding.GetString(Convert.FromBase64String(Source.Replace("-", "+").Replace("_", "/")));
        }



        /// <summary>
        /// MD5加密（摘要结果为32位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的Byte数组</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string MD5_Encode(byte[] Source, [Optional, DefaultParameterValue(true)] bool ToUpper)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Source)).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(Source)).Replace("-", "").ToLower();
        }
        /// <summary>
        /// MD5加密（摘要结果为32位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string MD5_Encode(string Source, [Optional, DefaultParameterValue(true)] bool ToUpper)
        {
            if (ToUpper)
            {
                return FormsAuthentication.HashPasswordForStoringInConfigFile(Source, "MD5").ToUpper();
            }
            return FormsAuthentication.HashPasswordForStoringInConfigFile(Source, "MD5").ToLower();
        }



        /// <summary>
        /// SHA1加密（摘要结果为40位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的Byte数组</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA1_Encode(byte[] Source, [Optional, DefaultParameterValue(true)] bool ToUpper)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(Source)).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(Source)).Replace("-", "").ToLower();
        }
        /// <summary>
        /// SHA1加密（摘要结果为40位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA1_Encode(string Source, [Optional, DefaultParameterValue(true)] bool ToUpper)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(new SHA1CryptoServiceProvider().ComputeHash(Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToLower();
        }



        /// <summary>
        /// SHA256加密（摘要结果为64位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的Byte数组</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA256_Encode(byte[] Source, [Optional, DefaultParameterValue(true)] bool ToUpper)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(new SHA256Managed().ComputeHash(Source)).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(new SHA256Managed().ComputeHash(Source)).Replace("-", "").ToLower();
        }
        /// <summary>
        /// SHA256加密（摘要结果为64位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA256_Encode(string Source, [Optional, DefaultParameterValue(true)] bool ToUpper)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(new SHA256Managed().ComputeHash(Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToLower();
        }



        /// <summary>
        /// SHA384加密（摘要结果为96位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的Byte数组</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA384_Encode(byte[] Source, [Optional, DefaultParameterValue(true)] bool ToUpper)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(new SHA384Managed().ComputeHash(Source)).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(new SHA384Managed().ComputeHash(Source)).Replace("-", "").ToLower();
        }
        /// <summary>
        /// SHA384加密（摘要结果为96位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA384_Encode(string Source, [Optional, DefaultParameterValue(true)] bool ToUpper)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(new SHA384Managed().ComputeHash(Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(new SHA384Managed().ComputeHash(Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToLower();
        }



        /// <summary>
        /// SHA512加密（摘要结果为128位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的Byte数组</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA512_Encode(byte[] Source, [Optional, DefaultParameterValue(true)] bool ToUpper)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(new SHA512Managed().ComputeHash(Source)).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(new SHA512Managed().ComputeHash(Source)).Replace("-", "").ToLower();
        }
        /// <summary>
        /// SHA512加密（摘要结果为128位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string SHA512_Encode(string Source, [Optional, DefaultParameterValue(true)] bool ToUpper)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(new SHA512Managed().ComputeHash(Encoding.UTF8.GetBytes(Source))).Replace("-", "").ToLower();
        }



        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="Source">要加密的Byte数组</param>
        /// <param name="SecretKey">加密密钥（8的整数倍字节数的字符串）</param>
        /// <returns>加密后的结果Byte数组（失败返回空Byte数组）</returns>
        public static byte[] DES_Encode(byte[] Source, string SecretKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            try
            {
                provider.Key = Encoding.UTF8.GetBytes(SecretKey);
                provider.IV = Encoding.UTF8.GetBytes(SecretKey);
            }
            catch (ArgumentException ex)//加密失败（通常是由于SecretKey的字节数不是8的倍数）
            {
                return new byte[0];
            }
            MemoryStream stream2 = new MemoryStream();
            CryptoStream stream = new CryptoStream(stream2, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream.Write(Source, 0, Source.Length);
            stream.FlushFinalBlock();
            return stream2.ToArray();
        }
        /// <summary>
        /// DES加密
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <param name="SecretKey">加密密钥（8的整数倍字节数的字符串）</param>
        /// <returns>加密后的结果Byte数组（失败返回空Byte数组）</returns>
        public static byte[] DES_Encode(string Source, string SecretKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            try
            {
                provider.Key = Encoding.UTF8.GetBytes(SecretKey);
                provider.IV = Encoding.UTF8.GetBytes(SecretKey);
            }
            catch (ArgumentException ex)//加密失败（通常是由于SecretKey的字节数不是8的倍数）
            {
                return new byte[0];
            }
            MemoryStream stream2 = new MemoryStream();
            CryptoStream stream = new CryptoStream(stream2, provider.CreateEncryptor(), CryptoStreamMode.Write);
            stream.Write(Encoding.UTF8.GetBytes(Source), 0, Encoding.UTF8.GetBytes(Source).Length);
            stream.FlushFinalBlock();
            return stream2.ToArray();
        }

        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="Source">要解密的Byte数组</param>
        /// <param name="SecretKey">解密密钥（8的整数倍字节数的字符串）</param>
        /// <returns>解密后的结果Byte数组（失败返回空Byte数组）</returns>
        public static byte[] DES_Decode(byte[] Source, string SecretKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            try
            {
                provider.Key = Encoding.UTF8.GetBytes(SecretKey);
                provider.IV = Encoding.UTF8.GetBytes(SecretKey);
            }
            catch (ArgumentException ex)//解密失败（通常是由于SecretKey的字节数不是8的倍数）
            {
                return new byte[0];
            }
            MemoryStream stream2 = new MemoryStream();
            CryptoStream stream = new CryptoStream(stream2, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream.Write(Source, 0, Source.Length);
            try
            {
                stream.FlushFinalBlock();
            }
            catch (CryptographicException ex)//解密失败（通常是由于SecretKey不匹配）
            {
                return new byte[0];
            }
            return stream2.ToArray();
        }
        /// <summary>
        /// DES解密
        /// </summary>
        /// <param name="Source">要解密的Byte数组</param>
        /// <param name="SecretKey">解密密钥（8的整数倍字节数的字符串）</param>
        /// <returns>解密后的结果字符串（失败返回空字符串）</returns>
        public static string DES_Decode_String(byte[] Source, string SecretKey)
        {
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            try
            {
                provider.Key = Encoding.UTF8.GetBytes(SecretKey);
                provider.IV = Encoding.UTF8.GetBytes(SecretKey);
            }
            catch (ArgumentException ex)//解密失败（通常是由于SecretKey的字节数不是8的倍数）
            {
                return "";
            }
            MemoryStream stream2 = new MemoryStream();
            CryptoStream stream = new CryptoStream(stream2, provider.CreateDecryptor(), CryptoStreamMode.Write);
            stream.Write(Source, 0, Source.Length);
            try
            {
                stream.FlushFinalBlock();
            }
            catch (CryptographicException ex)//解密失败（通常是由于SecretKey不匹配）
            {
                return "";
            }
            return Encoding.UTF8.GetString(stream2.ToArray());
        }



        /// <summary>
        /// RSA加密（使用本函数库内置的密钥）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <returns>加密后的结果Byte数组</returns>
        public static byte[] RSA_Encode(string Source)
        {
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString("<RSAKeyValue><Modulus>pZGIiC3CxVYpTJ4dLylSy2TLXW+R9EyRZ39ekSosvRKf7iPuz4oPlHqjssh4Glbj/vTUIMFzHFC/9zC56GggNLfZBjh6fc3adq5cXGKlU74kAyM2z7gdYlUHtLT/GwDp4YcQKeSb9GjcvsXbUp0mrzI/axzueLIqK+R07rnv3yc=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>");
            return provider.Encrypt(Encoding.UTF8.GetBytes(Source), true);
        }

        /// <summary>
        /// RSA解密（使用本函数库内置的密钥）
        /// </summary>
        /// <param name="Source">要解密的Byte数组</param>
        /// <returns>解密后的结果字符串（失败返回空字符串）</returns>
        public static string RSA_Decode(byte[] Source)
        {
            string result;
            RSACryptoServiceProvider provider = new RSACryptoServiceProvider();
            provider.FromXmlString("<RSAKeyValue><Modulus>pZGIiC3CxVYpTJ4dLylSy2TLXW+R9EyRZ39ekSosvRKf7iPuz4oPlHqjssh4Glbj/vTUIMFzHFC/9zC56GggNLfZBjh6fc3adq5cXGKlU74kAyM2z7gdYlUHtLT/GwDp4YcQKeSb9GjcvsXbUp0mrzI/axzueLIqK+R07rnv3yc=</Modulus><Exponent>AQAB</Exponent><P>0wCnxVUMgu+Uqp3UJ18bp9Ahdad36wDMwa0tmHxZJUvBZEfcYpsxmSHLpTUBCcAIg2eJL5g/iK9LrIwDBvUZ+w==</P><Q>yOB6ZwG9TuXMRPCA9cFTKCoHEsreDZluptHEfG3HvnS1lp5xwRCHXVuh7VWOM0G2gnZ/JWwWIfcqf30UTWvTxQ==</Q><DP>BTc67nHPwVzSu/TyzZZYRKmsahAdsr1uUktJmT9ZpMZenW/5Tqavby2arxbEU81faIAir/5/c42BvV4opP9iCQ==</DP><DQ>QETR5LMBxoRvXn80Q2yfFnKb4L9XXDKC3IywuL7G8YCVuKLo8kQ/ivcOT8jXvj6ADi2rcGWsjyFtT2zNWhftoQ==</DQ><InverseQ>jwpY6fpkzwtLOABZQncXMC4h7VbYrx+sZeSrBFXAgw1WMSs9YsT6EQcDRjpGt7JAkP14nSTSIVJNd23jZURCLw==</InverseQ><D>cw6SqcfbLVV198d9EnQOFEgkRvcsn2/CMAFET27WjkHuIAiagWE4+H7NWYWUaQFvCZNMAsNMYiX/cSFMYCRUFBBgkPqaqQ3+3qCs/kKiWpDjRwX8eXrMAnWniFDEoxc229Mxl4QZrcYKVRxrCIq8wKamuoWgwN0M+3CAiLwLvNk=</D></RSAKeyValue>");
            try
            {
                result = Encoding.UTF8.GetString(provider.Decrypt(Source, true));
            }
            catch (Exception ex)
            {
                result = "";
                return result;
            }
            return result;
        }



        /// <summary>
        /// 二进制形式化（只由0和1组成的，8的整数倍位数的2进制字符串）
        /// </summary>
        /// <param name="Source">要编码的Byte数组</param>
        /// <param name="ContainSpace">是否将结果每8位以空格隔开</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Binary_Encode(byte[] Source, [Optional, DefaultParameterValue(true)] bool ContainSpace)
        {
            string str2 = "";
            if (ContainSpace)
            {
                foreach (byte num in Source)
                {
                    str2 = str2 + Convert.ToString(num, 2).PadLeft(8, '0') + " ";
                }
            }
            else
            {
                foreach (byte num2 in Source)
                {
                    str2 = str2 + Convert.ToString(num2, 2).PadLeft(8, '0');
                }
            }
            return str2.Trim();
        }
        /// <summary>
        /// 二进制形式化（只由0和1组成的，8的整数倍位数的2进制字符串）
        /// </summary>
        /// <param name="Source">要编码的字符串</param>
        /// <param name="ContainSpace">是否将结果每8位以空格隔开</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Binary_Encode(string Source, [Optional, DefaultParameterValue(true)] bool ContainSpace)
        {
            string str2 = "";
            if (ContainSpace)
            {
                foreach (byte num in Encoding.UTF8.GetBytes(Source))
                {
                    str2 = str2 + Convert.ToString(num, 2).PadLeft(8, '0') + " ";
                }
            }
            else
            {
                foreach (byte num2 in Encoding.UTF8.GetBytes(Source))
                {
                    str2 = str2 + Convert.ToString(num2, 2).PadLeft(8, '0');
                }
            }
            return str2.Trim();
        }
        /// <summary>
        /// 二进制形式化（只由0和1组成的，8的整数倍位数的2进制字符串）
        /// </summary>
        /// <param name="Source">要编码的字符串</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <param name="ContainSpace">是否将结果每8位以空格隔开</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Binary_Encode(string Source, Encoding Encoding, [Optional, DefaultParameterValue(true)] bool ContainSpace)
        {
            string str2 = "";
            if (ContainSpace)
            {
                foreach (byte num in Encoding.GetBytes(Source))
                {
                    str2 = str2 + Convert.ToString(num, 2).PadLeft(8, '0') + " ";
                }
            }
            else
            {
                foreach (byte num2 in Encoding.GetBytes(Source))
                {
                    str2 = str2 + Convert.ToString(num2, 2).PadLeft(8, '0');
                }
            }
            return str2.Trim();
        }

        /// <summary>
        /// 二进制反形式化（将只由0和1组成的，8的整数倍位数的2进制字符串，转换为原始意义的Byte数组）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <returns>解码后的结果Byte数组</returns>
        public static byte[] Binary_Decode(string Source)
        {
            Source = Source.Replace(" ", "");
            byte[] result = new byte[Source.Length / 8];
            for (int i = 0; i < Source.Length / 8; i++)
            {
                string temp = Source.Substring(i * 8, 8);
                result[i] = Convert.ToByte(temp, 2);
            }
            return result;
        }
        /// <summary>
        /// 二进制反形式化（将只由0和1组成的，8的整数倍位数的2进制字符串，转换为原始意义的字符串）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <returns>解码后的结果字符串</returns>
        public static string Binary_Decode_String(string Source)
        {
            Source = Source.Replace(" ", "");
            byte[] result = new byte[Source.Length / 8];
            for (int i = 0; i < Source.Length / 8; i++)
            {
                string temp = Source.Substring(i * 8, 8);
                result[i] = Convert.ToByte(temp, 2);
            }
            return Encoding.UTF8.GetString(result);
        }
        /// <summary>
        /// 二进制反形式化（将只由0和1组成的，8的整数倍位数的2进制字符串，转换为原始意义的字符串）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>解码后的结果字符串</returns>
        public static string Binary_Decode_String(string Source, Encoding Encoding)
        {
            Source = Source.Replace(" ", "");
            byte[] result = new byte[Source.Length / 8];
            for (int i = 0; i < Source.Length / 8; i++)
            {
                string temp = Source.Substring(i * 8, 8);
                result[i] = Convert.ToByte(temp, 2);
            }
            return Encoding.GetString(result);
        }



        /// <summary>
        /// 二进制非处理（将二进制形式的0替换为1，1替换为0）
        /// </summary>
        /// <param name="Source">要编码的Byte数组</param>
        /// <returns>编码后的结果Byte数组</returns>
        public static byte[] Binary_Not(byte[] Source)
        {
            string temp = "";
            foreach (byte num in Source)
            {
                temp = temp + Convert.ToString(num, 2).PadLeft(8, '0');
            }
            temp = temp.Replace("0", "2").Replace("1", "0").Replace("2", "1");
            byte[] result = new byte[temp.Length / 8];
            for (int i = 0; i < temp.Length / 8; i++)
            {
                string sourceByte = temp.Substring(i * 8, 8).Remove(0, temp.Substring(i * 8, 8).IndexOf("1"));
                result[i] = Convert.ToByte(sourceByte, 2);
            }
            return result;
        }

    }
}