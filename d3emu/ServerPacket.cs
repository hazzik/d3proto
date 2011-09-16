using System.IO;
using Google.ProtocolBuffers;

namespace d3emu
{
    class ServerPacket
    {
        private CodedOutputStream m_stream;
        private MemoryStream m_memStream;

        public ServerPacket(byte service, int method, short requestId, long unk1)
        {
            m_memStream = new MemoryStream();
            m_stream = CodedOutputStream.CreateInstance(m_memStream);

            // Write header
            m_stream.WriteRawByte(service);
            m_stream.WriteInt32NoTag(method);
            m_stream.WriteInt16NoTag(requestId);

            if (service != 0xFE)
                m_stream.WriteInt64NoTag(unk1);
        }

        public byte[] WriteMessage(IMessageLite value)
        {
            m_stream.WriteMessageNoTag(value);
            m_stream.Flush();

            return m_memStream.ToArray();
        }
    }
}
