//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service/game_utilities/game_utilities.proto
// Note: requires additional types generated from: service/game_master/game_master.proto
// Note: requires additional types generated from: service/server_pool/server_pool.proto
// Note: requires additional types generated from: lib/protocol/attribute.proto
// Note: requires additional types generated from: lib/protocol/entity.proto
// Note: requires additional types generated from: lib/rpc/rpc.proto
namespace bnet.protocol.game_utilities
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ClientRequest")]
  public partial class ClientRequest : global::ProtoBuf.IExtensible
  {
    public ClientRequest() {}
    
    private readonly global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> _attribute = new global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute>();
    [global::ProtoBuf.ProtoMember(1, Name=@"attribute", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> attribute
    {
      get { return _attribute; }
    }
  

    private bnet.protocol.ProcessId _host = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.ProcessId host
    {
      get { return _host; }
      set { _host = value; }
    }

    private bnet.protocol.EntityId _bnet_account_id = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"bnet_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId bnet_account_id
    {
      get { return _bnet_account_id; }
      set { _bnet_account_id = value; }
    }

    private bnet.protocol.EntityId _game_account_id = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"game_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId game_account_id
    {
      get { return _game_account_id; }
      set { _game_account_id = value; }
    }

    private bnet.protocol.EntityId _toon_id = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"toon_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId toon_id
    {
      get { return _toon_id; }
      set { _toon_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ClientResponse")]
  public partial class ClientResponse : global::ProtoBuf.IExtensible
  {
    public ClientResponse() {}
    
    private readonly global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> _attribute = new global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute>();
    [global::ProtoBuf.ProtoMember(1, Name=@"attribute", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> attribute
    {
      get { return _attribute; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateToonRequest")]
  public partial class CreateToonRequest : global::ProtoBuf.IExtensible
  {
    public CreateToonRequest() {}
    
    private bnet.protocol.EntityId _bnet_account_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"bnet_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId bnet_account_id
    {
      get { return _bnet_account_id; }
      set { _bnet_account_id = value; }
    }
    private bnet.protocol.EntityId _game_account_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"game_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId game_account_id
    {
      get { return _game_account_id; }
      set { _game_account_id = value; }
    }
    private bnet.protocol.EntityId _toon_id;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"toon_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId toon_id
    {
      get { return _toon_id; }
      set { _toon_id = value; }
    }
    private string _name;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private readonly global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> _attribute = new global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute>();
    [global::ProtoBuf.ProtoMember(5, Name=@"attribute", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> attribute
    {
      get { return _attribute; }
    }
  

    private bnet.protocol.ProcessId _host = null;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.ProcessId host
    {
      get { return _host; }
      set { _host = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateToonResponse")]
  public partial class CreateToonResponse : global::ProtoBuf.IExtensible
  {
    public CreateToonResponse() {}
    

    private string _name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DeleteToonRequest")]
  public partial class DeleteToonRequest : global::ProtoBuf.IExtensible
  {
    public DeleteToonRequest() {}
    

    private bnet.protocol.EntityId _bnet_account_id = null;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"bnet_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId bnet_account_id
    {
      get { return _bnet_account_id; }
      set { _bnet_account_id = value; }
    }

    private bnet.protocol.EntityId _game_account_id = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"game_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId game_account_id
    {
      get { return _game_account_id; }
      set { _game_account_id = value; }
    }
    private bnet.protocol.EntityId _toon_id;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"toon_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId toon_id
    {
      get { return _toon_id; }
      set { _toon_id = value; }
    }

    private bnet.protocol.ProcessId _host = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.ProcessId host
    {
      get { return _host; }
      set { _host = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"TransferToonRequest")]
  public partial class TransferToonRequest : global::ProtoBuf.IExtensible
  {
    public TransferToonRequest() {}
    
    private bnet.protocol.EntityId _toon_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"toon_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId toon_id
    {
      get { return _toon_id; }
      set { _toon_id = value; }
    }

    private bnet.protocol.game_utilities.TransferToonRequest.Account _source = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"source", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.game_utilities.TransferToonRequest.Account source
    {
      get { return _source; }
      set { _source = value; }
    }

    private bnet.protocol.game_utilities.TransferToonRequest.Account _target = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"target", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.game_utilities.TransferToonRequest.Account target
    {
      get { return _target; }
      set { _target = value; }
    }

    private bnet.protocol.ProcessId _host = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.ProcessId host
    {
      get { return _host; }
      set { _host = value; }
    }
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Account")]
  public partial class Account : global::ProtoBuf.IExtensible
  {
    public Account() {}
    
    private bnet.protocol.EntityId _bnet_account_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"bnet_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId bnet_account_id
    {
      get { return _bnet_account_id; }
      set { _bnet_account_id = value; }
    }
    private bnet.protocol.EntityId _game_account_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"game_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId game_account_id
    {
      get { return _game_account_id; }
      set { _game_account_id = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SelectToonRequest")]
  public partial class SelectToonRequest : global::ProtoBuf.IExtensible
  {
    public SelectToonRequest() {}
    
    private bnet.protocol.EntityId _bnet_account_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"bnet_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId bnet_account_id
    {
      get { return _bnet_account_id; }
      set { _bnet_account_id = value; }
    }
    private bnet.protocol.EntityId _game_account_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"game_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId game_account_id
    {
      get { return _game_account_id; }
      set { _game_account_id = value; }
    }
    private bnet.protocol.EntityId _toon_id;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"toon_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId toon_id
    {
      get { return _toon_id; }
      set { _toon_id = value; }
    }

    private bnet.protocol.ProcessId _host = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.ProcessId host
    {
      get { return _host; }
      set { _host = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PresenceChannelCreatedRequest")]
  public partial class PresenceChannelCreatedRequest : global::ProtoBuf.IExtensible
  {
    public PresenceChannelCreatedRequest() {}
    
    private bnet.protocol.EntityId _id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId id
    {
      get { return _id; }
      set { _id = value; }
    }

    private bnet.protocol.EntityId _toon_id = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"toon_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId toon_id
    {
      get { return _toon_id; }
      set { _toon_id = value; }
    }

    private bnet.protocol.EntityId _game_account_id = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"game_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId game_account_id
    {
      get { return _game_account_id; }
      set { _game_account_id = value; }
    }

    private bnet.protocol.EntityId _bnet_account_id = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"bnet_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId bnet_account_id
    {
      get { return _bnet_account_id; }
      set { _bnet_account_id = value; }
    }

    private bnet.protocol.ProcessId _host = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.ProcessId host
    {
      get { return _host; }
      set { _host = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"PlayerVariablesRequest")]
  public partial class PlayerVariablesRequest : global::ProtoBuf.IExtensible
  {
    public PlayerVariablesRequest() {}
    
    private bnet.protocol.EntityId _bnet_account_id;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"bnet_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId bnet_account_id
    {
      get { return _bnet_account_id; }
      set { _bnet_account_id = value; }
    }
    private bnet.protocol.EntityId _game_account_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"game_account_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId game_account_id
    {
      get { return _game_account_id; }
      set { _game_account_id = value; }
    }
    private bnet.protocol.EntityId _toon_id;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"toon_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId toon_id
    {
      get { return _toon_id; }
      set { _toon_id = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _variable = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(4, Name=@"variable", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> variable
    {
      get { return _variable; }
    }
  

    private bnet.protocol.ProcessId _host = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.ProcessId host
    {
      get { return _host; }
      set { _host = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"GameVariablesRequest")]
  public partial class GameVariablesRequest : global::ProtoBuf.IExtensible
  {
    public GameVariablesRequest() {}
    
    private readonly global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> _attribute = new global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute>();
    [global::ProtoBuf.ProtoMember(1, Name=@"attribute", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> attribute
    {
      get { return _attribute; }
    }
  
    private readonly global::System.Collections.Generic.List<string> _variable = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(2, Name=@"variable", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> variable
    {
      get { return _variable; }
    }
  

    private bnet.protocol.ProcessId _host = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.ProcessId host
    {
      get { return _host; }
      set { _host = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"VariablesResponse")]
  public partial class VariablesResponse : global::ProtoBuf.IExtensible
  {
    public VariablesResponse() {}
    
    private readonly global::System.Collections.Generic.List<float> _value = new global::System.Collections.Generic.List<float>();
    [global::ProtoBuf.ProtoMember(1, Name=@"value", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public global::System.Collections.Generic.List<float> value
    {
      get { return _value; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    public interface IGameUtilities
    {
      bnet.protocol.game_utilities.ClientResponse ProcessClientRequest(bnet.protocol.game_utilities.ClientRequest request);
    bnet.protocol.game_utilities.CreateToonResponse CreateToon(bnet.protocol.game_utilities.CreateToonRequest request);
    bnet.protocol.NoData DeleteToon(bnet.protocol.game_utilities.DeleteToonRequest request);
    bnet.protocol.NoData TransferToon(bnet.protocol.game_utilities.TransferToonRequest request);
    bnet.protocol.NoData SelectToon(bnet.protocol.game_utilities.SelectToonRequest request);
    bnet.protocol.NoData PresenceChannelCreated(bnet.protocol.game_utilities.PresenceChannelCreatedRequest request);
    bnet.protocol.game_utilities.VariablesResponse GetPlayerVariables(bnet.protocol.game_utilities.PlayerVariablesRequest request);
    bnet.protocol.game_utilities.VariablesResponse GetGameVariables(bnet.protocol.game_utilities.GameVariablesRequest request);
    bnet.protocol.server_pool.ServerState GetLoad(bnet.protocol.server_pool.GetLoadRequest request);
    
    }
    
    
}