using System;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace d3emu
{
    public class SRP
    {
        private static readonly byte[] gBytes = new byte[] { 0x02 };

        private readonly BigInteger g = gBytes.ToPosBigInteger();

        private static readonly byte[] NBytes = new byte[]
            {
                0xAB, 0x24, 0x43, 0x63, 0xA9, 0xC2, 0xA6, 0xC3, 0x3B, 0x37, 0xE4, 0x61, 0x84, 0x25, 0x9F, 0x8B,
                0x3F, 0xCB, 0x8A, 0x85, 0x27, 0xFC, 0x3D, 0x87, 0xBE, 0xA0, 0x54, 0xD2, 0x38, 0x5D, 0x12, 0xB7,
                0x61, 0x44, 0x2E, 0x83, 0xFA, 0xC2, 0x21, 0xD9, 0x10, 0x9F, 0xC1, 0x9F, 0xEA, 0x50, 0xE3, 0x09,
                0xA6, 0xE5, 0x5E, 0x23, 0xA7, 0x77, 0xEB, 0x00, 0xC7, 0xBA, 0xBF, 0xF8, 0x55, 0x8A, 0x0E, 0x80,
                0x2B, 0x14, 0x1A, 0xA2, 0xD4, 0x43, 0xA9, 0xD4, 0xAF, 0xAD, 0xB5, 0xE1, 0xF5, 0xAC, 0xA6, 0x13,
                0x1C, 0x69, 0x78, 0x64, 0x0B, 0x7B, 0xAF, 0x9C, 0xC5, 0x50, 0x31, 0x8A, 0x23, 0x08, 0x01, 0xA1,
                0xF5, 0xFE, 0x31, 0x32, 0x7F, 0xE2, 0x05, 0x82, 0xD6, 0x0B, 0xED, 0x4D, 0x55, 0x32, 0x41, 0x94,
                0x29, 0x6F, 0x55, 0x7D, 0xE3, 0x0F, 0x77, 0x19, 0xE5, 0x6C, 0x30, 0xEB, 0xDE, 0xF6, 0xA7, 0x86
            };

        private readonly BigInteger N = NBytes.ToPosBigInteger();

        private static readonly SHA256Managed HASH = new SHA256Managed();

        private readonly BigInteger s;
        private readonly BigInteger I;
        private readonly BigInteger v;
        private readonly BigInteger b;
        private readonly BigInteger B;

        private readonly string m_account;
        private readonly string m_accountSalt;

        // Secondary challenge
        private readonly BigInteger m_secondChallengeServer1;
        private BigInteger m_secondChallengeServer2;
        private BigInteger m_secondChallengeClient;

        public SRP(string account, string password)
        {
            m_account = account;

            // workaround...
            m_accountSalt = HASH.ComputeHash(Encoding.ASCII.GetBytes(account)).ToHexString();

            var sBytes = GetRandomBytes(32);
            s = sBytes.ToPosBigInteger();

            var IBytes = HASH.ComputeHash(Encoding.ASCII.GetBytes(m_accountSalt.ToUpper() + ":" + password.ToUpper()));
            I = IBytes.ToPosBigInteger();

            var xBytes = HASH.ComputeHash(new byte[0]
                .Concat(sBytes)
                .Concat(IBytes)
                .ToArray());

            var x = xBytes.ToPosBigInteger();

            v = BigInteger.ModPow(g, x, N);

            b = GetRandomBytes(128).ToPosBigInteger();

            var gMod = BigInteger.ModPow(g, b, N);

            var kBytes = HASH.ComputeHash(new byte[0]
                .Concat(NBytes)
                .Concat(gBytes)
                .ToArray());

            var k = kBytes.ToPosBigInteger();

            B = BigInteger.Remainder((v * k) + gMod, N);

            var secondChallengeBytes1 = GetRandomBytes(128);
            m_secondChallengeServer1 = Extensions.ToPosBigInteger(secondChallengeBytes1);

            Response1 = new byte[0]
                .Concat(new byte[] { 0 }) // command == 0
                .Concat(m_accountSalt.ToByteArray()) // accountSalt
                .Concat(sBytes) // passwordSalt
                .Concat(B.ToArray()) // serverChallenge
                .Concat(secondChallengeBytes1) // secondaryChallenge
                .ToArray();
        }

        // Response structure:
        //     byte command;
        //     if (command == 0 || command == 1) // from server
        //     {
        //         if (command == 0)
        //             byte accountSalt[32]; // static value per account
        //         byte passwordSalt[32]; // static value per account
        //         byte serverChallenge[128]; // changes every login
        //         byte secondaryChallenge[128]; // changes every login
        //     }
        //     else if (command == 2) // from server
        //     {
        //         // empty
        //     }
        //     else if (command == 3) // from server
        //     {
        //         byte M2[32];
        //         byte data2[128]; // for veryfing secondaryChallenge
        //     }
        public byte[] Response1 { get; private set; }

        public byte[] Response2 { get; private set; }

        public bool Verify(byte[] ABytes, byte[] M1Bytes, byte[] seed)
        {
            m_secondChallengeClient = Extensions.ToPosBigInteger(seed);

            var A = ABytes.ToPosBigInteger();

            var uBytes = HASH.ComputeHash(new byte[0]
                .Concat(ABytes)
                .Concat(B.ToArray())
                .ToArray());

            var u = uBytes.ToPosBigInteger();

            var S = BigInteger.ModPow(A * BigInteger.ModPow(v, u, N), b, N);

            var KBytes = Calc_K(S.ToArray());

            var t3Bytes = Hash_g_and_N_and_xor_them();

            var t4 = HASH.ComputeHash(Encoding.ASCII.GetBytes(m_accountSalt));

            var sBytes = s.ToArray();
            var BBytes = B.ToArray();

            //// hack
            //if (sBytes.Length != 0x20)
            //{
            //    sBytes = s.ToArray();
            //    //throw new Exception("sBytes.Length != 0x20");
            //}

            var M = HASH.ComputeHash(new byte[0]
                .Concat(t3Bytes)
                .Concat(t4)
                .Concat(sBytes)
                .Concat(ABytes)
                .Concat(BBytes)
                .Concat(KBytes)
                .ToArray());

            if (!M.CompareTo(M1Bytes)) // fails sometimes due to sBytes.Length != 0x20
                return false;

            var M2 = HASH.ComputeHash(new byte[0]
                .Concat(ABytes)
                .Concat(M)
                .Concat(KBytes)
                .ToArray());

            var secondChallengeServer2Bytes = GetRandomBytes(128);
            m_secondChallengeServer2 = Extensions.ToPosBigInteger(secondChallengeServer2Bytes);

            Response2 = new byte[0]
                .Concat(new byte[] { 3 })
                .Concat(M2)
                .Concat(secondChallengeServer2Bytes) // not random?
                .ToArray();

            return true;
        }

        //  Interleave SHA256 Key
        private byte[] Calc_K(byte[] S)
        {
            var K = new byte[64];

            var half_S = new byte[64];

            for (int i = 0; i < 64; ++i)
                half_S[i] = S[i * 2];

            var p1 = HASH.ComputeHash(half_S);

            for (int i = 0; i < 32; ++i)
                K[i * 2] = p1[i];

            for (int i = 0; i < 64; ++i)
                half_S[i] = S[i * 2 + 1];

            var p2 = HASH.ComputeHash(half_S);

            for (int i = 0; i < 32; ++i)
                K[i * 2 + 1] = p2[i];

            return K;
        }

        private byte[] Hash_g_and_N_and_xor_them()
        {
            var hash_N = HASH.ComputeHash(NBytes);
            var hash_g = HASH.ComputeHash(gBytes);

            for (var i = 0; i < 32; ++i)
                hash_N[i] ^= hash_g[i];

            return hash_N;
        }

        private static byte[] GetRandomBytes(int count)
        {
            var rnd = new Random();
            var result = new byte[count];
            rnd.NextBytes(result);
            return result;
        }
    }
}
