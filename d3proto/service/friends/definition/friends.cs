//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service/friends/definition/friends.proto
// Note: requires additional types generated from: lib/protocol/attribute.proto
// Note: requires additional types generated from: lib/protocol/entity.proto
// Note: requires additional types generated from: lib/protocol/invitation.proto
// Note: requires additional types generated from: lib/rpc/rpc.proto
// Note: requires additional types generated from: service/friends/friends_types.proto
namespace bnet.protocol.friends
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SubscribeToFriendsRequest")]
  public partial class SubscribeToFriendsRequest : global::ProtoBuf.IExtensible
  {
    public SubscribeToFriendsRequest() {}
    

    private bnet.protocol.EntityId _agent_id = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"agent_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId agent_id
    {
      get { return _agent_id; }
      set { _agent_id = value; }
    }
    private ulong _object_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"object_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong object_id
    {
      get { return _object_id; }
      set { _object_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SubscribeToFriendsResponse")]
  public partial class SubscribeToFriendsResponse : global::ProtoBuf.IExtensible
  {
    public SubscribeToFriendsResponse() {}
    

    private uint _max_friends = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"max_friends", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint max_friends
    {
      get { return _max_friends; }
      set { _max_friends = value; }
    }

    private uint _max_received_invitations = default(uint);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"max_received_invitations", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint max_received_invitations
    {
      get { return _max_received_invitations; }
      set { _max_received_invitations = value; }
    }

    private uint _max_sent_invitations = default(uint);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"max_sent_invitations", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint max_sent_invitations
    {
      get { return _max_sent_invitations; }
      set { _max_sent_invitations = value; }
    }
    private readonly global::System.Collections.Generic.List<bnet.protocol.friends.Friend> _friends = new global::System.Collections.Generic.List<bnet.protocol.friends.Friend>();
    [global::ProtoBuf.ProtoMember(5, Name=@"friends", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.friends.Friend> friends
    {
      get { return _friends; }
    }
  
    private readonly global::System.Collections.Generic.List<bnet.protocol.invitation.Invitation> _sent_invitations = new global::System.Collections.Generic.List<bnet.protocol.invitation.Invitation>();
    [global::ProtoBuf.ProtoMember(6, Name=@"sent_invitations", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.invitation.Invitation> sent_invitations
    {
      get { return _sent_invitations; }
    }
  
    private readonly global::System.Collections.Generic.List<bnet.protocol.invitation.Invitation> _received_invitations = new global::System.Collections.Generic.List<bnet.protocol.invitation.Invitation>();
    [global::ProtoBuf.ProtoMember(7, Name=@"received_invitations", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.invitation.Invitation> received_invitations
    {
      get { return _received_invitations; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UnsubscribeToFriendsRequest")]
  public partial class UnsubscribeToFriendsRequest : global::ProtoBuf.IExtensible
  {
    public UnsubscribeToFriendsRequest() {}
    

    private bnet.protocol.EntityId _agent_id = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"agent_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId agent_id
    {
      get { return _agent_id; }
      set { _agent_id = value; }
    }

    private ulong _object_id = default(ulong);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"object_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong object_id
    {
      get { return _object_id; }
      set { _object_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GenericFriendRequest")]
  public partial class GenericFriendRequest : global::ProtoBuf.IExtensible
  {
    public GenericFriendRequest() {}
    

    private bnet.protocol.EntityId _agent_id = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"agent_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId agent_id
    {
      get { return _agent_id; }
      set { _agent_id = value; }
    }
    private bnet.protocol.EntityId _target_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"target_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId target_id
    {
      get { return _target_id; }
      set { _target_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GenericFriendResponse")]
  public partial class GenericFriendResponse : global::ProtoBuf.IExtensible
  {
    public GenericFriendResponse() {}
    

    private bnet.protocol.friends.Friend _target_friend = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"target_friend", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.friends.Friend target_friend
    {
      get { return _target_friend; }
      set { _target_friend = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SendInvitationRequest")]
  public partial class SendInvitationRequest : global::ProtoBuf.IExtensible
  {
    public SendInvitationRequest() {}
    

    private string _target_email = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"target_email", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string target_email
    {
      get { return _target_email; }
      set { _target_email = value; }
    }

    private string _display_string = "";
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"display_string", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string display_string
    {
      get { return _display_string; }
      set { _display_string = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ViewFriendsRequest")]
  public partial class ViewFriendsRequest : global::ProtoBuf.IExtensible
  {
    public ViewFriendsRequest() {}
    

    private bnet.protocol.EntityId _agent_id = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"agent_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId agent_id
    {
      get { return _agent_id; }
      set { _agent_id = value; }
    }
    private bnet.protocol.EntityId _target_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"target_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId target_id
    {
      get { return _target_id; }
      set { _target_id = value; }
    }
    private bnet.protocol.attribute.AttributeFilter _filter;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"filter", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.attribute.AttributeFilter filter
    {
      get { return _filter; }
      set { _filter = value; }
    }

    private uint _start_index = (uint)0;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"start_index", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((uint)0)]
    public uint start_index
    {
      get { return _start_index; }
      set { _start_index = value; }
    }

    private uint _max_results = (uint)100;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"max_results", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((uint)100)]
    public uint max_results
    {
      get { return _max_results; }
      set { _max_results = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ViewFriendsResponse")]
  public partial class ViewFriendsResponse : global::ProtoBuf.IExtensible
  {
    public ViewFriendsResponse() {}
    
    private readonly global::System.Collections.Generic.List<bnet.protocol.friends.Friend> _friends = new global::System.Collections.Generic.List<bnet.protocol.friends.Friend>();
    [global::ProtoBuf.ProtoMember(1, Name=@"friends", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.friends.Friend> friends
    {
      get { return _friends; }
    }
  

    private uint _total_results = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"total_results", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint total_results
    {
      get { return _total_results; }
      set { _total_results = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UpdateFriendStateRequest")]
  public partial class UpdateFriendStateRequest : global::ProtoBuf.IExtensible
  {
    public UpdateFriendStateRequest() {}
    

    private bnet.protocol.EntityId _agent_id = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"agent_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId agent_id
    {
      get { return _agent_id; }
      set { _agent_id = value; }
    }
    private bnet.protocol.EntityId _target_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"target_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId target_id
    {
      get { return _target_id; }
      set { _target_id = value; }
    }
    private readonly global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> _attribute = new global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute>();
    [global::ProtoBuf.ProtoMember(3, Name=@"attribute", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> attribute
    {
      get { return _attribute; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UpdateFriendStateResponse")]
  public partial class UpdateFriendStateResponse : global::ProtoBuf.IExtensible
  {
    public UpdateFriendStateResponse() {}
    
    private bnet.protocol.EntityId _target_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"target_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId target_id
    {
      get { return _target_id; }
      set { _target_id = value; }
    }
    private readonly global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> _attribute = new global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute>();
    [global::ProtoBuf.ProtoMember(3, Name=@"attribute", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> attribute
    {
      get { return _attribute; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FriendNotification")]
  public partial class FriendNotification : global::ProtoBuf.IExtensible
  {
    public FriendNotification() {}
    
    private bnet.protocol.friends.Friend _target;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"target", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.friends.Friend target
    {
      get { return _target; }
      set { _target = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"InvitationAddedNotification")]
  public partial class InvitationAddedNotification : global::ProtoBuf.IExtensible
  {
    public InvitationAddedNotification() {}
    
    private bnet.protocol.invitation.Invitation _invitation;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"invitation", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.invitation.Invitation invitation
    {
      get { return _invitation; }
      set { _invitation = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"InvitationRemovedNotification")]
  public partial class InvitationRemovedNotification : global::ProtoBuf.IExtensible
  {
    public InvitationRemovedNotification() {}
    
    private bnet.protocol.invitation.Invitation _invitation;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"invitation", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.invitation.Invitation invitation
    {
      get { return _invitation; }
      set { _invitation = value; }
    }

    private uint _reason = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"reason", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint reason
    {
      get { return _reason; }
      set { _reason = value; }
    }

    private bnet.protocol.friends.Friend _added_friend = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"added_friend", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.friends.Friend added_friend
    {
      get { return _added_friend; }
      set { _added_friend = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    public interface IFriendsService
    {
      bnet.protocol.friends.SubscribeToFriendsResponse SubscribeToFriends(bnet.protocol.friends.SubscribeToFriendsRequest request);
    bnet.protocol.invitation.SendInvitationResponse SendInvitation(bnet.protocol.invitation.SendInvitationRequest request);
    bnet.protocol.NoData AcceptInvitation(bnet.protocol.invitation.GenericRequest request);
    bnet.protocol.NoData RevokeInvitation(bnet.protocol.invitation.GenericRequest request);
    bnet.protocol.NoData DeclineInvitation(bnet.protocol.invitation.GenericRequest request);
    bnet.protocol.NoData IgnoreInvitation(bnet.protocol.invitation.GenericRequest request);
    bnet.protocol.friends.GenericFriendResponse RemoveFriend(bnet.protocol.friends.GenericFriendRequest request);
    bnet.protocol.friends.ViewFriendsResponse ViewFriends(bnet.protocol.friends.ViewFriendsRequest request);
    bnet.protocol.friends.UpdateFriendStateResponse UpdateFriendState(bnet.protocol.friends.UpdateFriendStateRequest request);
    bnet.protocol.NoData UnsubscribeToFriends(bnet.protocol.friends.UnsubscribeToFriendsRequest request);
    
    }
    
    
    public interface IFriendsNotify
    {
      bnet.protocol.NO_RESPONSE NotifyFriendAdded(bnet.protocol.friends.FriendNotification request);
    bnet.protocol.NO_RESPONSE NotifyFriendRemoved(bnet.protocol.friends.FriendNotification request);
    bnet.protocol.NO_RESPONSE NotifyReceivedInvitationAdded(bnet.protocol.friends.InvitationAddedNotification request);
    bnet.protocol.NO_RESPONSE NotifyReceivedInvitationRemoved(bnet.protocol.friends.InvitationRemovedNotification request);
    bnet.protocol.NO_RESPONSE NotifySentInvitationRemoved(bnet.protocol.friends.InvitationRemovedNotification request);
    
    }
    
    
}