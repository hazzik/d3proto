using System.IO;
using Google.ProtocolBuffers;

namespace d3emu
{
    using System;

    class ServerPacket
    {
        private readonly CodedOutputStream m_stream;
        private readonly MemoryStream m_memStream;

        public byte[] Data
        {
            get { return m_memStream.ToArray(); }
        }

        private IMessage m_message;

        public IMessage Message
        {
            get { return m_message; }
        }

        public ServerPacket(byte service, int method, short requestId, ulong listenerId)
        {
            m_memStream = new MemoryStream();
            m_stream = CodedOutputStream.CreateInstance(m_memStream);

            // Write header
            m_stream.WriteRawByte(service);
            m_stream.WriteInt32NoTag(method);
            m_stream.WriteInt16NoTag(requestId);

            Console.WriteLine("OUT: service {0}, method {1}, requestId {2}, listenerId {3}", service, method, requestId, listenerId);

            if (service != 0xFE)
                m_stream.WriteRawVarint64(listenerId);
        }

        public ServerPacket WriteMessage(IMessage value)
        {
            m_message = value;

            m_stream.WriteMessageNoTag(value);
            m_stream.Flush();

            return this;
        }
    }
}
