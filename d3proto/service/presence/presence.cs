//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service/presence/presence.proto
// Note: requires additional types generated from: lib/protocol/attribute.proto
// Note: requires additional types generated from: lib/protocol/entity.proto
// Note: requires additional types generated from: lib/rpc/rpc.proto
// Note: requires additional types generated from: service/presence/presence_types.proto
namespace bnet.protocol.presence
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SubscribeRequest")]
  public partial class SubscribeRequest : global::ProtoBuf.IExtensible
  {
    public SubscribeRequest() {}
    

    private bnet.protocol.EntityId _agent_id = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"agent_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId agent_id
    {
      get { return _agent_id; }
      set { _agent_id = value; }
    }
    private bnet.protocol.EntityId _entity_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"entity_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId entity_id
    {
      get { return _entity_id; }
      set { _entity_id = value; }
    }
    private ulong _object_id;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"object_id", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public ulong object_id
    {
      get { return _object_id; }
      set { _object_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UnsubscribeRequest")]
  public partial class UnsubscribeRequest : global::ProtoBuf.IExtensible
  {
    public UnsubscribeRequest() {}
    

    private bnet.protocol.EntityId _agent_id = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"agent_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId agent_id
    {
      get { return _agent_id; }
      set { _agent_id = value; }
    }
    private bnet.protocol.EntityId _entity_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"entity_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId entity_id
    {
      get { return _entity_id; }
      set { _entity_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UpdateRequest")]
  public partial class UpdateRequest : global::ProtoBuf.IExtensible
  {
    public UpdateRequest() {}
    
    private bnet.protocol.EntityId _entity_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"entity_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId entity_id
    {
      get { return _entity_id; }
      set { _entity_id = value; }
    }
    private readonly global::System.Collections.Generic.List<bnet.protocol.presence.FieldOperation> _field_operation = new global::System.Collections.Generic.List<bnet.protocol.presence.FieldOperation>();
    [global::ProtoBuf.ProtoMember(2, Name=@"field_operation", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.presence.FieldOperation> field_operation
    {
      get { return _field_operation; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"QueryRequest")]
  public partial class QueryRequest : global::ProtoBuf.IExtensible
  {
    public QueryRequest() {}
    
    private bnet.protocol.EntityId _entity_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"entity_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId entity_id
    {
      get { return _entity_id; }
      set { _entity_id = value; }
    }
    private readonly global::System.Collections.Generic.List<bnet.protocol.presence.FieldKey> _key = new global::System.Collections.Generic.List<bnet.protocol.presence.FieldKey>();
    [global::ProtoBuf.ProtoMember(2, Name=@"key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.presence.FieldKey> key
    {
      get { return _key; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"QueryResponse")]
  public partial class QueryResponse : global::ProtoBuf.IExtensible
  {
    public QueryResponse() {}
    
    private readonly global::System.Collections.Generic.List<bnet.protocol.presence.Field> _field = new global::System.Collections.Generic.List<bnet.protocol.presence.Field>();
    [global::ProtoBuf.ProtoMember(2, Name=@"field", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.presence.Field> field
    {
      get { return _field; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    public interface IPresenceService
    {
      bnet.protocol.NoData Subscribe(bnet.protocol.presence.SubscribeRequest request);
    bnet.protocol.NoData Unsubscribe(bnet.protocol.presence.UnsubscribeRequest request);
    bnet.protocol.NoData Update(bnet.protocol.presence.UpdateRequest request);
    bnet.protocol.presence.QueryResponse Query(bnet.protocol.presence.QueryRequest request);
    
    }
    
    
}