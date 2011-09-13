using System;
using System.Text;

namespace BattleNet.Server
{
    public class BitWriter
    {
        private readonly byte[] _buffer;
        private int _numBits;

        internal BitWriter(int capacity)
        {
            _buffer = new byte[capacity];
        }

        internal byte[] Buffer
        {
            get { return _buffer; }
        }

        internal int NumBits
        {
            get { return _numBits; }
        }

        internal int Length
        {
            get
            {
                //int pos7 = (WritePos & 7);
                //int bitsLeft = 8 - pos7;

                //if (bitsLeft == 0)
                //    return NumBits / 8;
                //return (_numBits + bitsLeft) / 8;
                return WritePos / 8;
            }
        }

        internal int WritePos { get; set; }

        private static int Shift<T>(T left, int right)
        {
            if (typeof(T).Name == "Int32")
                return (int)(Convert.ToInt64(left) >> right);

            if (typeof(T).Name == "UInt32")
                return (int)(Convert.ToUInt64(left) >> right);

            if (typeof(T).Name == "Int16")
                return (int)(Convert.ToInt64(left) >> right);

            if (typeof(T).Name == "UInt16")
                return (int)(Convert.ToUInt64(left) >> right);

            if (typeof(T).Name == "Int64")
                return (int)(Convert.ToInt64(left) >> right);

            if (typeof(T).Name == "UInt64")
                return (int)(Convert.ToUInt64(left) >> right);

            return 0;
        }

        public void AlignToNextByte()
        {
            WritePos = (WritePos + 7) & ~7;
        }

        internal void WriteBytes(byte[] bytes)
        {
            AlignToNextByte();

            foreach (var b in bytes)
            {
                WriteBits((int)b, 8);
            }
        }

        public void WriteBuffer(byte[] bytes, int sizeBitCount)
        {
            WriteBits(bytes.Length, sizeBitCount);
            WriteBytes(bytes);
        }

        public void WriteAsciiString(string str, int bitCount)
        {
            WriteBits(str.Length, bitCount);
            WriteBytes(Encoding.ASCII.GetBytes(str));
        }

        public void WriteAsciiString(string str, int bitCount, int min)
        {
            WriteBits(str.Length - min, bitCount); // ?
            WriteBytes(Encoding.ASCII.GetBytes(str));
        }

        public void ReadUTFString(string str, int bitCount)
        {
            WriteBits(str.Length, bitCount + 2);
            WriteBytes(Encoding.UTF8.GetBytes(str));
        }

        private void WriteBytes(byte[] bytes, int length)
        {
            var buf = new byte[length];
            Array.Copy(bytes, 0, buf, 0, length);
            WriteBytes(buf);
        }

        public void WriteBuffer(byte[] bytes, int byteLength, int sizeBitCount)
        {
            WriteBits(byteLength, sizeBitCount);
            WriteBytes(bytes, byteLength);
        }

        internal void WriteInt32(int intVal)
        {
            WriteBits(intVal, 32);
        }

        internal void WriteBits<T>(T valz, int numBits)
        {
            if (numBits > 0)
            {
                _numBits += numBits;
                while (true)
                {
                    int pos7 = (WritePos & 7);
                    int unk = 8 - pos7;
                    var lShift = (byte)(1 << unk);
                    int subNum;

                    if (unk < numBits)
                        subNum = unk;
                    else
                    {
                        lShift = (byte)(1 << numBits);
                        subNum = numBits;
                    }

                    numBits -= subNum;

                    var firstHalf = (byte)(~((lShift - 1) << pos7));

                    var shifted = (byte)Shift(valz, numBits);
                    var secondHalf = (byte)(((lShift - 1) & shifted) << pos7);

                    Buffer[WritePos >> 3] = (byte)(Buffer[WritePos >> 3] & firstHalf | secondHalf);

                    WritePos += subNum;

                    if (numBits == 0)
                        return;
                }
            }
        }

        internal void WriteFourCC(string fourCC)
        {
            var arr = new byte[4];
            var bytes = Encoding.ASCII.GetBytes(fourCC);
            Array.Reverse(bytes);
            bytes.CopyTo(arr, 0);
            WriteInt32(BitConverter.ToInt32(arr, 0));
        }

        internal void WriteHeader(int packetId, int channelId)
        {
            WriteBits(packetId, 6);
            WriteBits(1, 1);
            WriteBits(channelId, 4);
        }

        public override string ToString()
        {
            string str = "";
            int numBytes = _numBits / 8;

            if (_numBits % 8 > 0)
                numBytes++;

            for (int i = 0; i < numBytes; i++)
            {
                if (i > 0 && i % 16 == 0)
                    str += Environment.NewLine;

                str += string.Format("{0:x2} ", Buffer[i]);
            }
            return str;
        }
    }
}
