//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service/party/definition/party.proto
// Note: requires additional types generated from: service/channel/channel_types.proto
// Note: requires additional types generated from: lib/protocol/attribute.proto
// Note: requires additional types generated from: lib/protocol/entity.proto
// Note: requires additional types generated from: lib/protocol/invitation.proto
// Note: requires additional types generated from: lib/rpc/rpc.proto
namespace bnet.protocol.party
{
    public interface IPartyService
    {
      bnet.protocol.channel.CreateChannelResponse CreateChannel(bnet.protocol.channel.CreateChannelRequest request);
    bnet.protocol.channel.JoinChannelResponse JoinChannel(bnet.protocol.channel.JoinChannelRequest request);
    bnet.protocol.channel.GetChannelInfoResponse GetChannelInfo(bnet.protocol.channel.GetChannelInfoRequest request);
    
    }
    
    
}