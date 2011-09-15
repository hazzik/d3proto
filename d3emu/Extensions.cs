using System;
using System.Linq;
using System.Numerics;
using System.Net.Sockets;
using Google.ProtocolBuffers;

namespace d3emu
{
    public static class Extensions
    {
        public static uint ToUnixTime(this DateTime time)
        {
            return (uint)((time.ToUniversalTime().Ticks - 621355968000000000L) / 10000000L);
        }

        public static byte[] Append(this byte[] a, byte[] b)
        {
            var result = new byte[a.Length + b.Length];

            a.CopyTo(result, 0);
            b.CopyTo(result, a.Length);

            return result;
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
            string retStr = "";
            foreach (byte b in byteArray)
                retStr += b.ToString("x2");
            return retStr;
        }

        public static bool CompareTo(this byte[] byteArray, byte[] second)
        {
            if (byteArray.Length != second.Length)
                return false;

            for (var i = 0; i < byteArray.Length; ++i)
            {
                if (second[i] != byteArray[i])
                    return false;
            }

            return true;
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

        public static M ReadMessage<M, B>(this CodedInputStream s, IBuilderLite builder) where M : IMessage<M, B> where B : IBuilder<M, B>
        {
            s.ReadMessage(builder, ExtensionRegistry.Empty);
            return (M)((B)builder).Build();
        }
    }
}
