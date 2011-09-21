using System.Threading;

namespace d3emu
{
    static class Program
    {
        private static BnetServer m_bnetServer;
        private static GameServer m_gameServer;

        public const byte PrevService = 0xFE;

        static void Main(string[] args)
        {
            m_bnetServer = new BnetServer(6666);
            m_gameServer = new GameServer(6665);

            while (true)
            {
                Thread.Sleep(10);
            }
        }
    }
}
