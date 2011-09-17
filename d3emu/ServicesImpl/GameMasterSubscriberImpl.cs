namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.game_master;
    using Google.ProtocolBuffers;

    public class GameMasterSubscriberImpl : GameMasterSubscriber
    {
        public override void NotifyFactoryUpdate(IRpcController controller, FactoryUpdateNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}
