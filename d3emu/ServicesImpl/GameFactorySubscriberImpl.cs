namespace d3emu.ServicesImpl
{
    using System;
    using bnet.protocol;
    using bnet.protocol.game_master;
    using Google.ProtocolBuffers;

    public class GameFactorySubscriberImpl : GameFactorySubscriber
    {
        public override void NotifyGameFound(IRpcController controller, GameFoundNotification request, Action<NO_RESPONSE> done)
        {
            throw new NotImplementedException();
        }
    }
}
