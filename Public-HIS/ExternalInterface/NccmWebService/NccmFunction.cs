using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using ICSharpCode.SharpZipLib.GZip;
namespace NccmWebService
{
    public class NccmFunction
    {
        private const string charSerail = "guilei55";
        /// <summary>
        /// des加密
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string encrypt( string message, string key )
        {
            DES des = new DESCryptoServiceProvider();
            des.Key = Encoding.UTF8.GetBytes( key );
            des.IV = Encoding.UTF8.GetBytes( charSerail );

            byte[] bytes = Encoding.UTF8.GetBytes( message );

            byte[] resultBytes = des.CreateEncryptor().TransformFinalBlock( bytes, 0, bytes.Length );

            return Convert.ToBase64String( resultBytes );

        }
        
        /// <summary>
        /// des解密
        /// </summary>
        /// <param name="message"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string decrypt( string message, string key )
        {
            string outString = "";
            byte[] byKey = Encoding.UTF8.GetBytes( key );
            byte[] IV = Encoding.UTF8.GetBytes( charSerail );
            byte[] inputByteArray = Convert.FromBase64String( message );
            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream( ms, des.CreateDecryptor( byKey, IV ), CryptoStreamMode.Write );
                cs.Write( inputByteArray, 0, inputByteArray.Length );
                cs.FlushFinalBlock();
                System.Text.Encoding encoding = new System.Text.UTF8Encoding();
                outString = encoding.GetString( ms.ToArray() );
            }
            catch ( System.Exception error )
            {
            }
            return outString;
        }

        /// <summary>
        /// 压缩   
        /// </summary>
        /// <param name="uncompressedString"></param>
        /// <returns></returns>
        public static string gZipCompress( string uncompressedString )
        {
            byte[] bytData = System.Text.Encoding.UTF8.GetBytes( uncompressedString );
            System.IO.MemoryStream ms = new MemoryStream();
            GZipOutputStream zip = new GZipOutputStream( ms );
            zip.Write( bytData, 0, bytData.Length );
            zip.Close();
            byte[] compressedData = (byte[])ms.ToArray();
            return System.Convert.ToBase64String( compressedData, 0, compressedData.Length );
        }


        /// <summary>
        /// 解压   
        /// </summary>
        /// <param name="compressedString"></param>
        /// <returns></returns>
        public static string gZipDeCompress( string compressedString )
        {

            System.Text.StringBuilder uncompressedString = new System.Text.StringBuilder();
            int totalLength = 0;
            byte[] bytInput = System.Convert.FromBase64String( compressedString );
            ;
            byte[] writeData = new byte[512];
            //Stream s2 = new ICSharpCode.SharpZipLib.BZip2.BZip2InputStream(new MemoryStream(bytInput));
            GZipInputStream s2 = new GZipInputStream( new MemoryStream( bytInput ) );
            while ( true )
            {
                int size = s2.Read( writeData, 0, writeData.Length );
                if ( size > 0 )
                {
                    totalLength += size;
                    uncompressedString.Append( System.Text.Encoding.UTF8.GetString( writeData, 0, size ) );
                }
                else
                {
                    break;
                }
            }
            s2.Close();
            return uncompressedString.ToString();
        }

    }
}
