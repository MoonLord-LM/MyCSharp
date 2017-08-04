namespace My
{
    using System;
    using System.IO;
    using System.Web;
    using System.Text;
    using System.Web.Security;
    using System.Collections.Generic;
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
        /// <returns>编码后的结果字符串</returns>
        public static string URL_Encode(string Source)
        {
            return HttpUtility.UrlEncode(Source, Encoding.UTF8);
        }
        /// <summary>
        /// URL编码
        /// </summary>
        /// <param name="Source"></param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>编码后的结果字符串</returns>
        public static string URL_Encode(string Source, Encoding Encoding)
        {
            return HttpUtility.UrlEncode(Source, Encoding);
        }

        /// <summary>
        /// URL解码
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <returns>解码后的结果字符串</returns>
        public static string URL_Decode(string Source)
        {
            return HttpUtility.UrlDecode(Source, Encoding.UTF8);
        }
        /// <summary>
        /// URL解码
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
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
            string result = "";
            if (ContainSpace)
            {
                foreach (byte sourceByte in Source)
                {
                    result = result + Convert.ToString(sourceByte, 2).PadLeft(8, '0') + " ";
                }
            }
            else
            {
                foreach (byte sourceByte in Source)
                {
                    result = result + Convert.ToString(sourceByte, 2).PadLeft(8, '0');
                }
            }
            return result.Trim();
        }
        /// <summary>
        /// 二进制形式化（只由0和1组成的，8的整数倍位数的2进制字符串）
        /// </summary>
        /// <param name="Source">要编码的字符串</param>
        /// <param name="ContainSpace">是否将结果每8位以空格隔开</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Binary_Encode(string Source, [Optional, DefaultParameterValue(true)] bool ContainSpace)
        {
            string result = "";
            if (ContainSpace)
            {
                foreach (byte sourceByte in Encoding.UTF8.GetBytes(Source))
                {
                    result = result + Convert.ToString(sourceByte, 2).PadLeft(8, '0') + " ";
                }
            }
            else
            {
                foreach (byte sourceByte in Encoding.UTF8.GetBytes(Source))
                {
                    result = result + Convert.ToString(sourceByte, 2).PadLeft(8, '0');
                }
            }
            return result.Trim();
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
            string result = "";
            if (ContainSpace)
            {
                foreach (byte sourceByte in Encoding.GetBytes(Source))
                {
                    result = result + Convert.ToString(sourceByte, 2).PadLeft(8, '0') + " ";
                }
            }
            else
            {
                foreach (byte sourceByte in Encoding.GetBytes(Source))
                {
                    result = result + Convert.ToString(sourceByte, 2).PadLeft(8, '0');
                }
            }
            return result.Trim();
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



        /// <summary>
        /// 十六进制编码（由0-F组成的，2的整数倍位数的16进制字符串）
        /// </summary>
        /// <param name="Source">要编码的Byte数组</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Hex_Encode(byte[] Source, bool ToUpper = true)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(Source).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(Source).Replace("-", "").ToLower();
        }
        /// <summary>
        /// 十六进制编码（由0-F组成的，2的整数倍位数的16进制字符串）
        /// </summary>
        /// <param name="Source">要编码的Int32值</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Hex_Encode(Int32 Source, bool ToUpper = true)
        {
            if (ToUpper)
            {
                return Source.ToString("X8");
            }
            return Source.ToString("x8");
        }
        /// <summary>
        /// 十六进制编码（由0-F组成的，2的整数倍位数的16进制字符串）
        /// </summary>
        /// <param name="Source">要编码的字符串</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>编码后的结果字符串</returns>
        public static string Hex_Encode(string Source, bool ToUpper = true)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(Encoding.UTF8.GetBytes(Source)).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(Encoding.UTF8.GetBytes(Source)).Replace("-", "").ToLower();
        }
        /// <summary>
        /// 十六进制编码（由0-F组成的，2的整数倍位数的16进制字符串）
        /// </summary>
        /// <param name="Source">要编码的字符串</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns></returns>
        public static string Hex_Encode(string Source, Encoding Encoding, bool ToUpper = true)
        {
            if (ToUpper)
            {
                return BitConverter.ToString(Encoding.GetBytes(Source)).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(Encoding.GetBytes(Source)).Replace("-", "").ToLower();
        }

        /// <summary>
        /// 十六进制解码（将由0-F组成的，2的整数倍位数的16进制字符串，转换为原始意义的Byte数组）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <returns>解码后的结果Byte数组</returns>
        public static byte[] Hex_Decode(string Source)
        {
            byte[] result = new byte[Source.Length / 2];
            for (int i = 0; i < Source.Length / 2; i++)
            {
                string sourceByte = Source.Substring(i * 2, 2);
                result[i] = Convert.ToByte(sourceByte, 16);
            }
            return result;
        }
        /// <summary>
        /// 十六进制解码（将由0-F组成的，2的整数倍位数的16进制字符串，转换为原始意义的Int32值）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <returns>解码后的结果Int32值</returns>
        public static Int32 Hex_Decode_Int32(string Source)
        {
            return Int32.Parse(Source, System.Globalization.NumberStyles.HexNumber);
        }
        /// <summary>
        /// 十六进制解码（将由0-F组成的，2的整数倍位数的16进制字符串，转换为原始意义的字符串）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <returns>解码后的结果字符串</returns>
        public static string Hex_Decode_String(string Source)
        {
            byte[] result = new byte[Source.Length / 2];
            for (int i = 0; i < Source.Length / 2; i++)
            {
                string sourceByte = Source.Substring(i * 2, 2);
                result[i] = Convert.ToByte(sourceByte, 16);
            }
            return Encoding.UTF8.GetString(result);
        }
        /// <summary>
        /// 十六进制解码（将由0-F组成的，2的整数倍位数的16进制字符串，转换为原始意义的字符串）
        /// </summary>
        /// <param name="Source">要解码的字符串</param>
        /// <param name="Encoding">使用特定的字符编码（默认UTF-8）</param>
        /// <returns>解码后的结果字符串</returns>
        public static string Hex_Decode_String(string Source, Encoding Encoding)
        {
            byte[] result = new byte[Source.Length / 2];
            for (int i = 0; i < Source.Length / 2; i++)
            {
                string sourceByte = Source.Substring(i * 2, 2);
                result[i] = Convert.ToByte(sourceByte, 16);
            }
            return Encoding.UTF8.GetString(result);
        }



        public class MD4_Hash_Algorithm
        {
            private const int BlockSize = 512 / 8;
            private uint[] Context = new uint[] { 0x67452301, 0xefcdab89, 0x98badcfe, 0x10325476 };
            private byte[] InputBuffer = new byte[BlockSize];
            private int ProcessedCount = 0;
            private uint[] WorkBuffer = new uint[BlockSize / 4];
            public MD4_Hash_Algorithm(byte[] InputBytes)
            {
                Update(InputBytes);
            }
            private void Update(byte[] InputBytes)
            {
                int unhashedBufferLength = ProcessedCount % 0x40;
                int partLength = BlockSize - unhashedBufferLength;
                int index = 0;
                if (InputBytes.Length >= partLength)
                {
                    Array.Copy(InputBytes, index, InputBuffer, unhashedBufferLength, partLength);
                    Transform(ref InputBuffer, 0);
                    index = partLength;
                    while (index + BlockSize - 1 < InputBytes.Length)
                    {
                        Transform(ref InputBytes, index);
                        index += BlockSize;
                    }
                    unhashedBufferLength = 0;
                }
                if (index < InputBytes.Length)
                {
                    Array.Copy(InputBytes, index, InputBuffer, unhashedBufferLength, InputBytes.Length - index);
                }
                ProcessedCount += InputBytes.Length;
            }
            private void Transform(ref byte[] Block, int Offset)
            {
                for (int i = 0; i < 16; i++)
                {
                    if (Offset >= Block.Length)
                    {
                        break;
                    }
                    WorkBuffer[i] = (uint)(Block[Offset + 0] & Byte.MaxValue);
                    WorkBuffer[i] |= (uint)((Block[Offset + 1] & Byte.MaxValue) << 8);
                    WorkBuffer[i] |= (uint)((Block[Offset + 2] & Byte.MaxValue) << 16);
                    WorkBuffer[i] |= (uint)((Block[Offset + 3] & Byte.MaxValue) << 24);
                    Offset += 4;
                }
                uint A = Context[0];
                uint B = Context[1];
                uint C = Context[2];
                uint D = Context[3];
                A = Round1(A, B, C, D, WorkBuffer[0], 3);
                D = Round1(D, A, B, C, WorkBuffer[1], 7);
                C = Round1(C, D, A, B, WorkBuffer[2], 11);
                B = Round1(B, C, D, A, WorkBuffer[3], 0x13);
                A = Round1(A, B, C, D, WorkBuffer[4], 3);
                D = Round1(D, A, B, C, WorkBuffer[5], 7);
                C = Round1(C, D, A, B, WorkBuffer[6], 11);
                B = Round1(B, C, D, A, WorkBuffer[7], 0x13);
                A = Round1(A, B, C, D, WorkBuffer[8], 3);
                D = Round1(D, A, B, C, WorkBuffer[9], 7);
                C = Round1(C, D, A, B, WorkBuffer[10], 11);
                B = Round1(B, C, D, A, WorkBuffer[11], 0x13);
                A = Round1(A, B, C, D, WorkBuffer[12], 3);
                D = Round1(D, A, B, C, WorkBuffer[13], 7);
                C = Round1(C, D, A, B, WorkBuffer[14], 11);
                B = Round1(B, C, D, A, WorkBuffer[15], 0x13);
                A = Round2(A, B, C, D, WorkBuffer[0], 3);
                D = Round2(D, A, B, C, WorkBuffer[4], 5);
                C = Round2(C, D, A, B, WorkBuffer[8], 9);
                B = Round2(B, C, D, A, WorkBuffer[12], 13);
                A = Round2(A, B, C, D, WorkBuffer[1], 3);
                D = Round2(D, A, B, C, WorkBuffer[5], 5);
                C = Round2(C, D, A, B, WorkBuffer[9], 9);
                B = Round2(B, C, D, A, WorkBuffer[13], 13);
                A = Round2(A, B, C, D, WorkBuffer[2], 3);
                D = Round2(D, A, B, C, WorkBuffer[6], 5);
                C = Round2(C, D, A, B, WorkBuffer[10], 9);
                B = Round2(B, C, D, A, WorkBuffer[14], 13);
                A = Round2(A, B, C, D, WorkBuffer[3], 3);
                D = Round2(D, A, B, C, WorkBuffer[7], 5);
                C = Round2(C, D, A, B, WorkBuffer[11], 9);
                B = Round2(B, C, D, A, WorkBuffer[15], 13);
                A = Round3(A, B, C, D, WorkBuffer[0], 3);
                D = Round3(D, A, B, C, WorkBuffer[8], 9);
                C = Round3(C, D, A, B, WorkBuffer[4], 11);
                B = Round3(B, C, D, A, WorkBuffer[12], 15);
                A = Round3(A, B, C, D, WorkBuffer[2], 3);
                D = Round3(D, A, B, C, WorkBuffer[10], 9);
                C = Round3(C, D, A, B, WorkBuffer[6], 11);
                B = Round3(B, C, D, A, WorkBuffer[14], 15);
                A = Round3(A, B, C, D, WorkBuffer[1], 3);
                D = Round3(D, A, B, C, WorkBuffer[9], 9);
                C = Round3(C, D, A, B, WorkBuffer[5], 11);
                B = Round3(B, C, D, A, WorkBuffer[13], 15);
                A = Round3(A, B, C, D, WorkBuffer[3], 3);
                D = Round3(D, A, B, C, WorkBuffer[11], 9);
                C = Round3(C, D, A, B, WorkBuffer[7], 11);
                B = Round3(B, C, D, A, WorkBuffer[15], 15);
                Context[0] = (uint)(0xffffffffL & (Context[0] + Convert.ToInt64(A)));
                Context[1] = (uint)(0xffffffffL & (Context[1] + Convert.ToInt64(B)));
                Context[2] = (uint)(0xffffffffL & (Context[2] + Convert.ToInt64(C)));
                Context[3] = (uint)(0xffffffffL & (Context[3] + Convert.ToInt64(D)));
            }
            private uint Round1(uint P1, uint P2, uint P3, uint P4, uint X, int S)
            {
                uint T = (uint)(0xffffffffL & (0xffffffffL & (Convert.ToInt64(P1) + ((P2 & P3) | (~P2 & P4))) + Convert.ToInt64(X)));
                return T << S | T >> (32 - S);
            }
            private uint Round2(uint P1, uint P2, uint P3, uint P4, uint X, int S)
            {
                uint T = (uint)(0xffffffffL & (0xffffffffL & (Convert.ToInt64(P1) + ((P2 & (P3 | P4)) | (P3 & P4))) + Convert.ToInt64(X) + 0x5a827999L));
                return T << S | T >> (32 - S);
            }
            private uint Round3(uint P1, uint P2, uint P3, uint P4, uint X, int S)
            {
                uint T = (uint)(0xffffffffL & (0xffffffffL & (Convert.ToInt64(P1) + (P2 ^ P3 ^ P4)) + Convert.ToInt64(X) + 0x6ed9eba1L));
                return T << S | T >> (32 - S);
            }
            public byte[] DigestResult()
            {
                int unhashedBufferLength = ProcessedCount % BlockSize;
                int paddingLength;
                if (unhashedBufferLength < 56)
                {
                    paddingLength = 56 - unhashedBufferLength;
                }
                else
                {
                    paddingLength = 120 - unhashedBufferLength;
                }
                byte[] tail = new byte[paddingLength + 8];
                tail[0] = 128;
                BitConverter.GetBytes((int)(ProcessedCount * 8)).CopyTo(tail, paddingLength);
                Update(tail);
                byte[] result = new byte[16];
                for (int i = 0; i < 4; i++)
                {
                    BitConverter.GetBytes(Context[i]).CopyTo(result, i * 4);
                }
                return result;
            }
        }
        /// <summary>
        /// MD4加密（摘要结果为32位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的Byte数组</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string MD4_Encode(byte[] Source, bool ToUpper = true)
        {
            MD4_Hash_Algorithm MD4 = new MD4_Hash_Algorithm(Source);
            if (ToUpper)
            {
                return BitConverter.ToString(MD4.DigestResult()).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(MD4.DigestResult()).Replace("-", "").ToLower();
        }
        /// <summary>
        /// MD4加密（摘要结果为32位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的字符串</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string MD4_Encode(string Source, bool ToUpper = true)
        {
            MD4_Hash_Algorithm MD4 = new MD4_Hash_Algorithm(Encoding.UTF8.GetBytes(Source));
            if (ToUpper)
            {
                return BitConverter.ToString(MD4.DigestResult()).Replace("-", "").ToUpper();
            }
            return BitConverter.ToString(MD4.DigestResult()).Replace("-", "").ToLower();
        }



        /// <summary>
        /// MD4混合加密（用于ED2K链接中的文件哈希值的计算，摘要结果为32位16进制字符串）
        /// </summary>
        /// <param name="Source">要加密的Byte数组</param>
        /// <param name="ToUpper">是否将结果转换为大写字母形式</param>
        /// <returns>加密后的结果字符串</returns>
        public static string MD4_ED2K_Encode(byte[] Source, bool ToUpper = true)
        {
            int chunkSize = 9728000;
            int chunkCount = (int)Math.Ceiling((double)(Source.Length / chunkSize));
            byte[] chunkBuffer = new byte[chunkSize];
            List<byte> chunkHash = new List<byte>();
            for (int i = 0; i < chunkCount; i++)
            {
                if ((Source.Length - (chunkSize * i)) > chunkSize)
                {
                    Array.Copy(Source, chunkSize * i, chunkBuffer, 0, chunkSize);
                    chunkHash.AddRange(new MD4_Hash_Algorithm(chunkBuffer).DigestResult());
                    for (int j = 0; j < chunkBuffer.Length; j++)
                    {
                        chunkBuffer[j] = 0;
                    }
                }
                else
                {
                    chunkBuffer = new byte[Source.Length - (chunkSize * i)];
                    Array.Copy(Source, chunkSize * i, chunkBuffer, 0, chunkBuffer.Length);
                    chunkHash.AddRange(new MD4_Hash_Algorithm(chunkBuffer).DigestResult());
                }
            }
            if (chunkCount == 1)
            {
                if (ToUpper)
                {
                    return BitConverter.ToString(chunkHash.ToArray()).Replace("-", "").ToUpper();
                }
                return BitConverter.ToString(chunkHash.ToArray()).Replace("-", "").ToLower();
            }
            else
            {
                if (ToUpper)
                {
                    return BitConverter.ToString(new MD4_Hash_Algorithm(chunkHash.ToArray()).DigestResult()).Replace("-", "").ToUpper();
                }
                return BitConverter.ToString(new MD4_Hash_Algorithm(chunkHash.ToArray()).DigestResult()).Replace("-", "").ToLower();
            }
        }

        /// <summary>
        /// 根据文件的名称、大小、哈希值，生成文件的ED2K下载链接
        /// </summary>
        /// <param name="FileName">文件名称（不能为空字符串）</param>
        /// <param name="FileLength">文件大小（必须大于0）</param>
        /// <param name="FileHash">文件哈希值（用于ED2K链接中的MD4混合哈希值）</param>
        /// <returns>生成的ED2K链接结果字符串（失败返回空字符串）</returns>
        public static string Generate_ED2K_Link(string FileName, int FileLength, string FileHash)
        {
            if (FileName == "" || FileHash.Length != 32 || FileLength <= 0)
            {
                return "";
            }
            FileName = HttpUtility.UrlEncode(FileName, Encoding.UTF8);
            return ("ed2k://|file|" + FileName + "|" + FileLength + "|" + FileHash + "|/");
        }
        /// <summary>
        /// 根据文件的名称和字节内容，生成文件的ED2K下载链接
        /// </summary>
        /// <param name="FileName">文件名称（不能为空字符串）</param>
        /// <param name="Source">文件内容（不能为空Byte数组）</param>
        /// <returns>生成的ED2K链接结果字符串（失败返回空字符串）</returns>
        public static string Generate_ED2K_Link(string FileName, byte[] Source)
        {
            if ((FileName == "") || (Source.Length == 0))
            {
                return "";
            }
            FileName = HttpUtility.UrlEncode(FileName, Encoding.UTF8);
            int chunkSize = 9728000;
            int chunkCount = (int)Math.Ceiling((double)(Source.Length / chunkSize));
            byte[] chunkBuffer = new byte[chunkSize];
            List<byte> chunkHash = new List<byte>();
            for (int i = 0; i < chunkCount; i++)
            {
                if ((Source.Length - (chunkSize * i)) > chunkSize)
                {
                    Array.Copy(Source, chunkSize * i, chunkBuffer, 0, chunkSize);
                    chunkHash.AddRange(new MD4_Hash_Algorithm(chunkBuffer).DigestResult());
                    for (int j = 0; j < chunkBuffer.Length; j++)
                    {
                        chunkBuffer[j] = 0;
                    }
                }
                else
                {
                    chunkBuffer = new byte[Source.Length - (chunkSize * i)];
                    Array.Copy(Source, chunkSize * i, chunkBuffer, 0, chunkBuffer.Length);
                    chunkHash.AddRange(new MD4_Hash_Algorithm(chunkBuffer).DigestResult());
                }
            }
            string fileHash;
            if (chunkCount == 1)
            {
                fileHash = BitConverter.ToString(chunkHash.ToArray()).Replace("-", "");
            }
            else
            {
                fileHash = BitConverter.ToString(new MD4_Hash_Algorithm(chunkHash.ToArray()).DigestResult()).Replace("-", "");
            }
            return ("ed2k://|file|" + FileName + "|" + Source.Length + "|" + fileHash + "|/");
        }

    }
}