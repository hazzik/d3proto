using System.Linq;
using System.Numerics;

namespace d3emu
{
    class BigInt
    {
        private BigInteger _bn;

        public BigInt(byte[] data)
        {
            var newdata = new byte[0]
                .Concat(data)
                .Concat(new byte[] { 0 })
                .ToArray();

            _bn = new BigInteger(newdata);
        }

        public byte[] ToByteArray()
        {
            return _bn.ToByteArray();
        }

        public BigInt ModPow(BigInt exponent, BigInt modulus)
        {
            return BigInteger.ModPow(this, exponent, modulus);
        }

        public static BigInt operator *(BigInt left, BigInt right)
        {
            return (BigInteger)left * (BigInteger)right;
        }

        public static BigInt operator /(BigInt left, int right)
        {
            return (BigInteger)left / (BigInteger)right;
        }

        public static BigInt operator +(BigInt left, BigInt right)
        {
            return (BigInteger)left + (BigInteger)right;
        }

        public static BigInt operator -(BigInt left, BigInt right)
        {
            return (BigInteger)left - (BigInteger)right;
        }

        public static BigInt operator %(BigInt left, BigInt right)
        {
            return (BigInteger)left % (BigInteger)right;
        }

        public static bool operator ==(BigInt left, BigInt right)
        {
            return (BigInteger)left == (BigInteger)right;
        }

        public static bool operator ==(BigInt left, int right)
        {
            return (BigInteger)left == (BigInteger)right;
        }

        public static bool operator !=(BigInt left, BigInt right)
        {
            return (BigInteger)left != (BigInteger)right;
        }

        public static bool operator !=(BigInt left, int right)
        {
            return (BigInteger)left != (BigInteger)right;
        }

        public static bool operator >(BigInt left, int right)
        {
            return (BigInteger)left > (BigInteger)right;
        }

        public static bool operator <(BigInt left, int right)
        {
            return (BigInteger)left < (BigInteger)right;
        }

        public static implicit operator BigInteger(BigInt value)
        {
            return new BigInteger(value.ToByteArray());
        }

        public static implicit operator BigInt(BigInteger value)
        {
            return new BigInt(value.ToByteArray());
        }

        public override bool Equals(object obj)
        {
            return _bn == (BigInteger)obj;
        }

        public override int GetHashCode()
        {
            return _bn.GetHashCode();
        }
    }
}
