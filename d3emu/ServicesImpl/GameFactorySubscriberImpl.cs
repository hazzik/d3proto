namespace d3emu.ServicesImpl
{
    using System;
    using Google.ProtocolBuffers;
    using bnet.protocol;
    using bnet.protocol.game_master;

    public class GameFactorySubscriberImpl : GameFactorySubscriber
    {
        public override void NotifyGameFound(IRpcController controller, GameFoundNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}