using System;
using System.Linq;
using System.Numerics;
using System.Text;
using Google.ProtocolBuffers;
using Google.ProtocolBuffers.Descriptors;

namespace d3emu
{
    public static class Extensions
    {
        public static uint ToUnixTime(this DateTime time)
        {
            return (uint)((time.ToUniversalTime().Ticks - 621355968000000000L) / 10000000L);
        }

        public static byte[] ToByteArray(this string str)
        {
            str = str.Replace(" ", String.Empty);

            var res = new byte[str.Length / 2];
            for (int i = 0; i < res.Length; ++i)
            {
                string temp = String.Concat(str[i * 2], str[i * 2 + 1]);
                res[i] = Convert.ToByte(temp, 16);
            }
            return res;
        }

        public static string ToHexDump(this byte[] byteArray)
        {
            var retStr = String.Empty;
            for (int i = 0; i < byteArray.Length; i++)
            {
                if (i > 0 && ((i % 16) == 0))
                    retStr += Environment.NewLine;
                retStr += byteArray[i].ToString("X2") + " ";
            }
            retStr += Environment.NewLine;
            return retStr;
        }

        public static string ToHexString(this byte[] byteArray)
        {
            return byteArray.Aggregate("", (current, b) => current + b.ToString("X2"));
        }

        public static void PrintHex(this byte[] data)
        {
            for (int i = 0; i < data.Length; i++)
            {
                if (i > 0 && (i % 16) == 0)
                    Console.WriteLine();

                Console.Write("{0:X2} ", data[i]);
            }

            Console.WriteLine();
            Console.WriteLine();
        }

        public static bool CompareTo(this byte[] byteArray, byte[] second)
        {
            if (byteArray.Length != second.Length)
                return false;

            return !byteArray.Where((t, i) => second[i] != t).Any();
        }

        public static BigInteger ToPosBigInteger(this byte[] src)
        {
            var dst = new byte[src.Length + 1];
            Array.Copy(src, dst, src.Length);
            return new BigInteger(dst);
        }

        public static byte[] ToArray(this BigInteger b)
        {
            var result = b.ToByteArray();
            if (result[result.Length - 1] == 0 && (result.Length % 0x10) != 0)
                Array.Resize(ref result, result.Length - 1);
            return result;
        }

        public static short ReadInt16(this CodedInputStream s)
        {
            return BitConverter.ToInt16(s.ReadRawBytes(2), 0);
        }

        public static int ReadInt32(this CodedInputStream s)
        {
            int ret = 0;
            s.ReadInt32(ref ret);
            return ret;
        }

        public static void WriteInt16NoTag(this CodedOutputStream s, short value)
        {
            s.WriteRawBytes(BitConverter.GetBytes(value));
        }

        public static int ReadInt32Reversed(this CodedInputStream s)
        {
            return BitConverter.ToInt32(s.ReadRawBytes(4).Reverse().ToArray(), 0);
        }

        /// <summary>
        /// FNV hash implementation
        /// </summary>
        /// <param name="descriptor">Service descriptor</param>
        /// <returns>Service hash</returns>
        public static uint GetHash(this ServiceDescriptor descriptor)
        {
            var name = descriptor.FullName;

            if (name == "bnet.protocol.connection.ConnectionService")
                return 0;

            return Encoding.ASCII.GetBytes(name)
                .Aggregate(0x811C9DC5, (current, t) => 0x1000193 * (t ^ current));
        }
    }
}
