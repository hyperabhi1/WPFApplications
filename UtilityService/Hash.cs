using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UtilityService.Models;

namespace UtilityService
{
    public class Hash
    {
        public static Guid NewGuid()
        {
            return Guid.NewGuid();
        }
        /// <summary>
        /// N-00000000000000000000000000000000
        /// D-00000000-0000-0000-0000-000000000000
        /// B-{00000000-0000-0000-0000-000000000000}
        /// P-(00000000-0000-0000-0000-000000000000)
        /// </summary>
        /// <param name="format">N/D/B/P</param>
        /// <returns>Guid Format</returns>
        public static string NewGuid(GuidFormat format)
        {
            return Guid.NewGuid().ToString(format.ToString());
        }
        public static bool IsGuid(string guid)
        {
            return Guid.TryParse(guid, out Guid x);
        }

        public static string GenerateMd5Hash(string content)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                return Shorty.GetMd5Hash(md5Hash, content);
            }
        }
    }
}
