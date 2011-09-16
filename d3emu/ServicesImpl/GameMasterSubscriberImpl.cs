namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.game_master;

    public class GameMasterSubscriberImpl : GameMasterSubscriber
    {
        public override void NotifyFactoryUpdate(IRpcController controller, FactoryUpdateNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}