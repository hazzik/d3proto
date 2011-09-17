using System;
using System.Linq;
using System.Net.Sockets;
using System.Numerics;
using Google.ProtocolBuffers;

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
            return byteArray.Aggregate("", (current, b) => current + b.ToString("x2"));
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

        public static BigInteger BigIntFromArray(byte[] src)
        {
            return new BigInteger(new byte[0]
                .Concat(src)
                .Concat(new byte[] { 0 })
                .ToArray());
        }

        public static bool IsConnected(this Socket socket)
        {
            try
            {
                return !(socket.Poll(1, SelectMode.SelectRead) && socket.Available == 0);
            }
            catch (SocketException)
            {
                return false;
            }
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
    }
}
