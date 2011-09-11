//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service/server_pool/server_pool.proto
// Note: requires additional types generated from: lib/protocol/attribute.proto
// Note: requires additional types generated from: lib/rpc/rpc.proto
namespace bnet.protocol.server_pool
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GetLoadRequest")]
  public partial class GetLoadRequest : global::ProtoBuf.IExtensible
  {
    public GetLoadRequest() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ServerState")]
  public partial class ServerState : global::ProtoBuf.IExtensible
  {
    public ServerState() {}
    

    private float _current_load = (float)1;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"current_load", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue((float)1)]
    public float current_load
    {
      get { return _current_load; }
      set { _current_load = value; }
    }

    private int _game_count = (int)0;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"game_count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int game_count
    {
      get { return _game_count; }
      set { _game_count = value; }
    }

    private int _player_count = (int)0;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"player_count", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue((int)0)]
    public int player_count
    {
      get { return _player_count; }
      set { _player_count = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ServerInfo")]
  public partial class ServerInfo : global::ProtoBuf.IExtensible
  {
    public ServerInfo() {}
    
    private bnet.protocol.ProcessId _host;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.ProcessId host
    {
      get { return _host; }
      set { _host = value; }
    }

    private bool _replace = (bool)false;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"replace", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool replace
    {
      get { return _replace; }
      set { _replace = value; }
    }

    private bnet.protocol.server_pool.ServerState _state = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"state", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.server_pool.ServerState state
    {
      get { return _state; }
      set { _state = value; }
    }
    private readonly global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> _attribute = new global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute>();
    [global::ProtoBuf.ProtoMember(4, Name=@"attribute", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> attribute
    {
      get { return _attribute; }
    }
  

    private uint _program_id = default(uint);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"program_id", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint program_id
    {
      get { return _program_id; }
      set { _program_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PoolStateRequest")]
  public partial class PoolStateRequest : global::ProtoBuf.IExtensible
  {
    public PoolStateRequest() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PoolStateResponse")]
  public partial class PoolStateResponse : global::ProtoBuf.IExtensible
  {
    public PoolStateResponse() {}
    
    private readonly global::System.Collections.Generic.List<bnet.protocol.server_pool.ServerInfo> _info = new global::System.Collections.Generic.List<bnet.protocol.server_pool.ServerInfo>();
    [global::ProtoBuf.ProtoMember(1, Name=@"info", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.server_pool.ServerInfo> info
    {
      get { return _info; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    public interface IServerPoolService
    {
      bnet.protocol.server_pool.PoolStateResponse GetPoolState(bnet.protocol.server_pool.PoolStateRequest request);
    
    }
    
    
}