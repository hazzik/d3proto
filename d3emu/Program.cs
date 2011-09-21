using System;

namespace d3emu
{
    static class Program
    {
        private static BnetServer m_bnetServer;
        private static GameServer m_gameServer;

        static void Main(string[] args)
        {
            m_bnetServer = new BnetServer(6666);
            m_gameServer = new GameServer(6665);

            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("exit", StringComparison.OrdinalIgnoreCase))
                    break;
            }

            m_bnetServer.Shutdown();
            m_gameServer.Shutdown();
        }
    }
}
