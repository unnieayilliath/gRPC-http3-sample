using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gRPC_HTTP3_Client
{
    internal class DataGenerator
    {
        /// <summary>
        /// This method generates data depending on the number of bits passed.
        /// </summary>
        /// <param name="numberOfKiloBytes"></param>
        /// <returns></returns>
        public static string GenerateData(int numberOfKiloBytes)
        {
            // 1 kb =1024 bytes and 1 byte = 8 bits
            int numberOfBits = numberOfKiloBytes * 1024 * 8;
            // 1 character is 16 bits
            int numberofChars= numberOfBits/16;
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var list = Enumerable.Repeat(0, numberofChars).Select(x => chars[random.Next(chars.Length)]);
            return string.Join("", list);
        }
    }
}
