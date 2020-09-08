using System;
using System.Collections.Generic;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace UtilityService
{
    class Shorty
    {
        private static long[] mgc_arr = new long[] { 518715534842869223, 280042546585394647 };

        private static int[] seed_Arr = new int[]
        {
            48,49,50,51,52,53,54,55,56,57,65,
            66,67,68,69,70,71,72,73,74,75,
            76,77,78,79,80,81,82,83,84,85,
            86,87,88,89,90,97,98,99,100,101,
            102,103,104,105,106,107,108,109,110,
            111,112,113,114,115,116,117,118,119,
            120,121,122
        };

        private static string ConvertToString(BigInteger i)
        {
            List<char> key = new List<char>();

            while (BigInteger.Compare(i, 0) > 0)
            {
                key.Add((char)seed_Arr[(int)(i % 62)]);
                i = BigInteger.Divide(i, 62);
            }

            key.Reverse();
            return new string(key.ToArray());
        }

        public static string Shorten(long num, int len = 6)
        {
            BigInteger dec = BigInteger.Multiply(num, mgc_arr[0]) % BigInteger.Pow(62, len);
            return ConvertToString(dec).PadLeft(len, '0');
        }



        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash. 
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes 
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data  
            // and format each one as a hexadecimal string. 
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string. 
            return sBuilder.ToString();
        }


    }
}
