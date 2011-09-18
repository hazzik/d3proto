using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace d3emu
{
    enum BufferIds : uint
    {
        /// <summary>
        /// Stores 64 bytes session key.
        /// </summary>
        Buf_0xB6E372AE = 0xB6E372AE,
        /// <summary>
        /// Stores HEX string (65 bytes null terminated, which represents account name somehow...).
        /// </summary>
        Buf_0x98D4D24E = 0x98D4D24E,
        /// <summary>
        /// Password salt (s).
        /// </summary>
        Buf_0xAA0B44F6 = 0xAA0B44F6,
        /// <summary>
        /// Server challenge (B).
        /// </summary>
        Buf_0x11F43626 = 0x11F43626,
        /// <summary>
        /// Second challenge.
        /// </summary>
        Buf_0x1B3433E7 = 0x1B3433E7,
        /// <summary>
        /// Stores plain text battle.net account name.
        /// </summary>
        Buf_0x59F8A2FC = 0x59F8A2FC,
        /// <summary>
        /// Status.
        /// </summary>
        Buf_0x92C4A81F = 0x92C4A81F,
        /// <summary>
        /// Thumbprint buffer, stores server IPv6 address.
        /// </summary>
        Buf_0xF8AC9F37 = 0xF8AC9F37,
        /// <summary>
        /// Client seed buffer used for second challenge (a???).
        /// </summary>
        Buf_0x7A7D7B79 = 0x7A7D7B79,
        /// <summary>
        /// Stores plain text accountPassword.
        /// </summary>
        Buf_0x2CC30838 = 0x2CC30838,
        /// <summary>
        /// 128 bytes received in 0x03 command.
        /// </summary>
        Buf_0xFD2FD63E = 0xFD2FD63E,
        /// <summary>
        /// 128 bytes RequestPassword buffer (A).
        /// </summary>
        Buf_0x486B15AA = 0x486B15AA,
        /// <summary>
        /// 32 bytes RequestPassword buffer (M1).
        /// </summary>
        Buf_0xBFD92CAD = 0xBFD92CAD,
        /// <summary>
        /// 64 bytes RequestPassword buffer (K).
        /// </summary>
        Buf_0x1609A775 = 0x1609A775,
    }

    /// <summary>
    /// Client size implementation of module 8f52906a2c85b416a595702251570f96d3522f39237603115f2f1ab24962043c.auth
    /// </summary>
    class Password
    {
        byte[] g = new byte[] { 0x02 };

        byte[] N = new byte[]
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

        Random random = new Random();

        private Dictionary<BufferIds, byte[]> buffers = new Dictionary<BufferIds, byte[]>();

        public byte[] ResponseBuffer { get; private set; }

        private string accountName;

        public string AccountName
        {
            get { return accountName; }
            set
            {
                accountName = value;
                SetAccountName();
            }
        }

        private string accountPassword;

        public string AccountPassword
        {
            get { return accountPassword; }
            set
            {
                accountPassword = value;
                SetPassword();
            }
        }

        public byte[] SessionKey
        {
            get
            {
                return buffers[BufferIds.Buf_0xB6E372AE];
            }
        }

        public byte[] Seed
        {
            get
            {
                return buffers[BufferIds.Buf_0x7A7D7B79];
            }
        }

        public byte Status
        {
            get
            {
                return buffers[BufferIds.Buf_0x92C4A81F][0];
            }
        }

        public Password()
        {
            // Init client seed
            buffers[BufferIds.Buf_0x7A7D7B79] = GetRandomBytes(128);
        }

        private void SetAccountName()
        {
            buffers[BufferIds.Buf_0x59F8A2FC] = Encoding.ASCII.GetBytes(accountName.ToUpperInvariant());
        }

        private void SetPassword()
        {
            buffers[BufferIds.Buf_0x2CC30838] = Encoding.ASCII.GetBytes(accountPassword.ToUpperInvariant());
        }

        private byte[] GetRandomBytes(int count)
        {
            var bytes = new byte[count];
            random.NextBytes(bytes);
            return bytes;
        }

        public void HandleData(byte[] data)
        {
            using (var ms = new MemoryStream(data))
            {
                using (var br = new BinaryReader(ms))
                {
                    var opcode = br.ReadByte();

                    switch (opcode)
                    {
                        case 0:
                            Handle_0x00_or_0x01_packet(br, true);
                            break;
                        case 1:
                            Handle_0x00_or_0x01_packet(br, false);
                            break;
                        case 2:
                            Handle_0x02_packet();
                            break;
                        case 3:
                            Handle_0x03_packet(br);
                            break;
                        default:
                            throw new ArgumentException(String.Format("Unhandled opcode {0}", opcode));
                    }
                }
            }
        }

        // .text:38961CC0 Handle_0x00_or_0x01_packet
        private void Handle_0x00_or_0x01_packet(BinaryReader reader, bool hasAccountSalt)
        {
            if (hasAccountSalt)
            {
                var m_accountSalt = reader.ReadBytes(32);

                var str = BitConverter.ToString(m_accountSalt).Replace("-", "").ToUpperInvariant();
                Console.WriteLine("U as string: {0}", str);

                var strBytes = Encoding.ASCII.GetBytes(str);
                Console.WriteLine("U as bytes: {0}", strBytes.ToHexDump());

                buffers[BufferIds.Buf_0x98D4D24E] = strBytes;
            }
            else
            {
                if (!buffers.ContainsKey(BufferIds.Buf_0x59F8A2FC))
                {
                    throw new ArgumentNullException("Account name isn't set!");
                }
            }

            var m_passwordSalt = reader.ReadBytes(32);
            buffers[BufferIds.Buf_0xAA0B44F6] = m_passwordSalt;
            Console.WriteLine(m_passwordSalt.ToHexDump());

            var m_serverChallenge = reader.ReadBytes(128);
            buffers[BufferIds.Buf_0x11F43626] = m_serverChallenge;
            Console.WriteLine(m_serverChallenge.ToHexDump());

            var m_secondaryChallenge = reader.ReadBytes(128);
            buffers[BufferIds.Buf_0x1B3433E7] = m_secondaryChallenge;
            Console.WriteLine(m_secondaryChallenge.ToHexDump());
        }

        // .text:389610A0 Handle_0x02_packet
        private void Handle_0x02_packet()
        {
            buffers[BufferIds.Buf_0x92C4A81F] = new byte[] { 0x04 };
        }

        // .text:38961F80 Handle_0x03_packet
        private void Handle_0x03_packet(BinaryReader reader)
        {
            var M2 = reader.ReadBytes(32);
            var data2 = reader.ReadBytes(128);

            if (!buffers.ContainsKey(BufferIds.Buf_0x59F8A2FC))
            {
                throw new ArgumentException("Account name isn't set!");
            }

            var accountNameBytes = buffers[BufferIds.Buf_0x59F8A2FC];

            if (!buffers.ContainsKey(BufferIds.Buf_0x486B15AA) ||
                !buffers.ContainsKey(BufferIds.Buf_0xBFD92CAD) ||
                !buffers.ContainsKey(BufferIds.Buf_0x1609A775))
            {
                throw new ArgumentException("RequestPassword should be called first!");
            }

            // RequestPassword buffers
            var A = buffers[BufferIds.Buf_0x486B15AA];
            var M1 = buffers[BufferIds.Buf_0xBFD92CAD];
            var K = buffers[BufferIds.Buf_0x1609A775];

            if (!Check_M2(M1, M2, A, K))
            {
                throw new ArgumentException("M2 doesn't match!");
            }

            Console.WriteLine("M2 check passed!");

            var secondChallenge = buffers[BufferIds.Buf_0x1B3433E7];
            var seed = buffers[BufferIds.Buf_0x7A7D7B79];

            // this is probably for http://trevp.net/tls_srp/draft-ietf-tls-srp-10.html (2.5.1.3. Unknown SRP Username)
            if (!Check2(data2, seed, secondChallenge, accountNameBytes))
            {
                throw new ArgumentException("Data2 doesn't match!");
            }

            Console.WriteLine("Check2 passed!");

            buffers[BufferIds.Buf_0xB6E372AE] = K;
            buffers[BufferIds.Buf_0xFD2FD63E] = data2;
            buffers[BufferIds.Buf_0x92C4A81F] = new byte[] { 0x03 };
        }

        // .text:38961230 Calc_M2
        private bool Check_M2(byte[] M1, byte[] M2, byte[] A, byte[] K)
        {
            var bytes = new byte[0]
                .Concat(A)
                .Concat(M1)
                .Concat(K)
                .ToArray();

            var M2_client = SHA256Managed.Create().ComputeHash(bytes);

            if (M2_client.CompareTo(M2))
                return true;

            return false;
        }

        // .text:389627A0 sub_389627A0
        private bool Check2(byte[] data2, byte[] seed, byte[] secondChallenge, byte[] accountNameBytes)
        {
            var N = new byte[]
                {
                    0xA3, 0x48, 0xF5, 0xDC, 0xFB, 0x38, 0x2D, 0x0B, 0x88, 0xA3, 0xC9, 0x32, 0xE9, 0x31, 0x58, 0x15,
                    0x6E, 0x98, 0x17, 0x73, 0x3B, 0xF0, 0xA4, 0x02, 0x8E, 0x0E, 0xC4, 0x32, 0x0B, 0x9B, 0xE1, 0x3A,
                    0xDB, 0x6B, 0x4F, 0x04, 0x4C, 0x0E, 0xF1, 0x11, 0xD3, 0xFF, 0x27, 0x92, 0xED, 0xC4, 0x08, 0xFB,
                    0x7B, 0x42, 0x4D, 0x49, 0xE5, 0x72, 0xEC, 0xB5, 0x6D, 0x9D, 0x2A, 0x96, 0x55, 0x85, 0x44, 0x45,
                    0xED, 0x75, 0x68, 0x13, 0xAC, 0x7C, 0x18, 0xB7, 0xB6, 0xCC, 0xB8, 0x53, 0x79, 0x47, 0x73, 0x9B,
                    0x19, 0x95, 0x5F, 0x8F, 0x18, 0xBA, 0x4F, 0xCA, 0xC5, 0xDD, 0xDF, 0xA1, 0xF1, 0xCD, 0x0F, 0x5D,
                    0x6B, 0xA2, 0xBA, 0xEB, 0x6D, 0x51, 0x33, 0xA6, 0x9A, 0xC2, 0xBE, 0x34, 0x50, 0xDA, 0xA1, 0x70,
                    0x2B, 0xB2, 0xDA, 0x7E, 0xA5, 0xFF, 0xA3, 0x67, 0x43, 0x10, 0x80, 0x24, 0x86, 0x63, 0x34, 0x8D
                };

            var Unknown = new byte[]
                {
                    0x71, 0x68, 0x3A, 0x6C, 0xFF, 0x38, 0xF8, 0x55, 0x80, 0x38, 0xFF, 0x6A, 0x2D, 0x4C, 0x30, 0xF9,
                    0x52, 0xE9, 0xCB, 0xB0, 0x2F, 0x7D, 0xDE, 0x3A, 0x23, 0xFF, 0xCD, 0xC1, 0x8B, 0xD9, 0xC4, 0x4E,
                    0x58, 0xA6, 0xD5, 0x68, 0xDC, 0x30, 0xF9, 0xB1, 0x56, 0xEB, 0x92, 0x1B, 0x94, 0xD3, 0x10, 0x6F,
                    0x2C, 0x9F, 0x55, 0x17, 0x02, 0x93, 0xC5, 0x56, 0xB6, 0xC0, 0xFC, 0x30, 0x2B, 0xFA, 0x8D, 0xA0,
                    0x4B, 0xCD, 0xF0, 0xD7, 0x8D, 0x96, 0xB8, 0xE9, 0x6B, 0xF8, 0xAD, 0x89, 0x52, 0xFC, 0xF3, 0xA6,
                    0x48, 0x8E, 0xFE, 0x58, 0x16, 0xA2, 0xAA, 0xA3, 0xD9, 0xCE, 0xCB, 0xFF, 0x39, 0xC5, 0x6A, 0x26,
                    0x1A, 0x00, 0x9A, 0x3D, 0x8D, 0x06, 0x54, 0x6E, 0xAE, 0x8A, 0xF2, 0x67, 0x57, 0xA4, 0x5F, 0xCF,
                    0x15, 0x3A, 0xB9, 0xCE, 0x3D, 0xEC, 0xCA, 0x3B, 0x54, 0x7D, 0x9E, 0xAB, 0x7B, 0x25, 0x68, 0x42
                };

            var g = new byte[] { 0x04 };

            var m_N = N.ToPosBigInteger();
            var m_Unknown = Unknown.ToPosBigInteger();
            var m_g = g.ToPosBigInteger();
            var m_UNKN = data2.ToPosBigInteger();
            var m_B = secondChallenge.ToPosBigInteger();

            // check secondChallenge
            var m_Ndiv2 = m_N / 2;
            if (BigInteger.ModPow(m_B, m_Ndiv2, m_N) != 1) // if (m_B.ModPow(m_Ndiv2, m_N) != 1)
                return false;

            var hmac = new HMACSHA512(accountNameBytes);
            var HMAC = hmac.ComputeHash(seed);

            var m_HMAC = HMAC.ToPosBigInteger();

            //var m_g2 = m_g.ModPow(m_UNKN, m_N);
            var m_g2 = BigInteger.ModPow(m_g, m_UNKN, m_N);

            //var m_Unknown2 = m_Unknown.ModPow(m_HMAC, m_N);
            var m_Unknown2 = BigInteger.ModPow(m_Unknown, m_HMAC, m_N);

            var m_clientB = (m_g2 * m_Unknown2) % m_N;

            if (m_clientB < 0)
                m_clientB += m_N;

            if (m_clientB != m_B)
            {
                Console.WriteLine("Check 2 Fail!");
                return true;
            }

            return true;
        }

        // .text:389619E0 RequestPasswordCommand
        public void RequestPassword()
        {
            if (!buffers.ContainsKey(BufferIds.Buf_0x2CC30838))
            {
                throw new ArgumentException("Password isn't set!");
            }

            var p = buffers[BufferIds.Buf_0x2CC30838];
            Console.WriteLine("p: {0}{1}", Environment.NewLine, p.ToHexDump());
            var U = buffers[BufferIds.Buf_0x98D4D24E];
            Console.WriteLine("U: {0}{1}", Environment.NewLine, U.ToHexDump());
            var s = buffers[BufferIds.Buf_0xAA0B44F6];
            Console.WriteLine("s: {0}{1}", Environment.NewLine, s.ToHexDump());
            var B = buffers[BufferIds.Buf_0x11F43626];
            Console.WriteLine("B: {0}{1}", Environment.NewLine, B.ToHexDump());
            var seed = buffers[BufferIds.Buf_0x7A7D7B79];
            Console.WriteLine("seed: {0}{1}", Environment.NewLine, seed.ToHexDump());

            byte[] A;
            byte[] M1;
            byte[] K;

            SRP6_CalcM1(U, p, s, B, out A, out M1, out K);

            Console.WriteLine("A: {0}{1}", Environment.NewLine, A.ToHexDump());
            Console.WriteLine("M1: {0}{1}", Environment.NewLine, M1.ToHexDump());
            Console.WriteLine("K: {0}{1}", Environment.NewLine, K.ToHexDump());

            buffers[BufferIds.Buf_0x486B15AA] = A;
            buffers[BufferIds.Buf_0xBFD92CAD] = M1;
            buffers[BufferIds.Buf_0x1609A775] = K;

            // Response to server is: A, M1, seed (289 bytes)
            ResponseBuffer = new byte[0]
                .Concat(new byte[] { 0x02 })
                .Concat(A)
                .Concat(M1)
                .Concat(seed) // SC2 stuff
                .ToArray();

            buffers[BufferIds.Buf_0x92C4A81F] = new byte[] { 0x02 };
        }

        // .text:389614F0 SRP6__CalculateM1
        private void SRP6_CalcM1(byte[] U, byte[] p, byte[] s, byte[] B, out byte[] A, out byte[] M1, out byte[] K)
        {
            var bn_g = g.ToPosBigInteger();

            var bn_N = N.ToPosBigInteger();

            var bn_B = B.ToPosBigInteger();

            var bn_k = Calc_k();

            var bn_a = GetRandomBytes(128).ToPosBigInteger();

            Console.WriteLine("a: {0}{1}", Environment.NewLine, bn_a.ToByteArray().ToHexDump());

            var bn_A = Calc_A(bn_g, bn_N, bn_a);

            A = bn_A.ToByteArray();

            var I = Calc_I(U);

            var bn_x = Calc_x(U, p, s);

            var bn_u = Calc_u(B, A);

            var bn_S = Calc_S(bn_g, bn_N, bn_B, bn_k, bn_a, bn_x, bn_u);

            K = Calc_K(bn_S.ToByteArray());

            M1 = Calc_M1(s, B, A, K, I);
        }

        private byte[] Calc_M1(byte[] s, byte[] B, byte[] A, byte[] K, byte[] I)
        {
            var M1_Bytes = new byte[0]
            .Concat(Hash_g_and_N_and_xor_them())
            .Concat(I)
            .Concat(s)
            .Concat(A)
            .Concat(B)
            .Concat(K)
            .ToArray();

            Console.WriteLine("M1 bytes: {0}{1}", Environment.NewLine, M1_Bytes.ToHexDump());

            byte[] M1 = SHA256Managed.Create().ComputeHash(M1_Bytes);
            return M1;
        }

        private static byte[] Calc_I(byte[] accountSaltBytes)
        {
            var I = SHA256Managed.Create().ComputeHash(accountSaltBytes);
            Console.WriteLine("I: {0}{1}", Environment.NewLine, I.ToHexDump());
            return I;
        }

        private static BigInteger Calc_S(BigInteger g, BigInteger N, BigInteger B, BigInteger k, BigInteger a, BigInteger x, BigInteger u)
        {
            // why the fuck it doesn't work?
            //var bn_v = bn_g.ModPow(bn_x, bn_N);
            //Console.WriteLine("v: {0}{1}", Environment.NewLine, bn_v.ToByteArray().ToHexDump());

            //var bn_S = ((bn_B - bn_k * bn_g.ModPow(bn_x, bn_N)) % bn_N).ModPow(bn_a + bn_u * bn_x, bn_N);
            //Console.WriteLine("S: {0}{1}", Environment.NewLine, bn_S.ToByteArray().ToHexDump());
            //return bn_S;

            //var bn_S = (bn_B - bn_k * bn_g.ModPow(bn_x, bn_N)).ModPow(bn_a + bn_u * bn_x, bn_N);
            //Console.WriteLine("S: {0}{1}", Environment.NewLine, bn_S.ToByteArray().ToHexDump());
            //return bn_S;

            //var S = (B + (N - ((k * g.ModPow(x, N)) % N))).ModPow(a + u * x, N);
            //return S;
            var S = BigInteger.ModPow(B + (N - ((k * BigInteger.ModPow(g, x, N)) % N)), a + u * x, N);
            return S;
        }

        private static BigInteger Calc_A(BigInteger g, BigInteger N, BigInteger a)
        {
            //var bn_A = g.ModPow(a, N);
            var bn_A = BigInteger.ModPow(g, a, N);
            Console.WriteLine("A: {0}{1}", Environment.NewLine, bn_A.ToByteArray().ToHexDump());
            return bn_A;
        }

        private static BigInteger Calc_u(byte[] B, byte[] A)
        {
            var AB = new byte[0]
                .Concat(A)
                .Concat(B)
                .ToArray();

            var u = SHA256Managed.Create().ComputeHash(AB);
            Console.WriteLine("u: {0}{1}", Environment.NewLine, u.ToHexDump());
            return u.ToPosBigInteger();
        }

        private byte[] Calc_K(byte[] S)
        {
            //  Interleave SHA256 Key
            var K = new byte[64];

            var half_S = new byte[64];

            for (int i = 0; i < 64; ++i)
            {
                half_S[i] = S[i * 2];
            }

            var p1 = SHA256Managed.Create().ComputeHash(half_S);

            for (int i = 0; i < 32; ++i)
            {
                K[i * 2] = p1[i];
            }

            for (int i = 0; i < 64; ++i)
            {
                half_S[i] = S[i * 2 + 1];
            }

            var p2 = SHA256Managed.Create().ComputeHash(half_S);

            for (int i = 0; i < 32; ++i)
            {
                K[i * 2 + 1] = p2[i];
            }

            return K;
        }

        private static BigInteger Calc_x(byte[] U, byte[] p, byte[] s)
        {
            var U_p_Bytes = new byte[0]
                .Concat(U)
                .Concat(new byte[] { 0x3A }) // ":"
                .Concat(p)
                .ToArray();

            var accPassHash = SHA256Managed.Create().ComputeHash(U_p_Bytes);

            Console.WriteLine("accPassHash: {0}{1}", Environment.NewLine, accPassHash.ToHexDump());

            var x_Bytes = new byte[0]
                .Concat(s)
                .Concat(accPassHash)
                .ToArray();

            var x = SHA256Managed.Create().ComputeHash(x_Bytes);
            Console.WriteLine("x: {0}{1}", Environment.NewLine, x.ToHexDump());
            return x.ToPosBigInteger();
        }

        private byte[] Hash_g_and_N_and_xor_them()
        {
            var hash_N = SHA256Managed.Create().ComputeHash(N);
            var hash_g = SHA256Managed.Create().ComputeHash(g);

            for (var i = 0; i < 32; ++i)
            {
                hash_N[i] ^= hash_g[i];
            }

            return hash_N;
        }

        private BigInteger Calc_k()
        {
            var N_g_bytes = new byte[0]
                .Concat(N)
                .Concat(g)
                .ToArray();

            var k = SHA256Managed.Create().ComputeHash(N_g_bytes);
            Console.WriteLine("k: {0}{1}", Environment.NewLine, k.ToHexDump());
            return k.ToPosBigInteger();
        }
    }
}
