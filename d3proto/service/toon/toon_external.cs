//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: service/toon/toon_external.proto
// Note: requires additional types generated from: lib/rpc/rpc.proto
// Note: requires additional types generated from: lib/protocol/entity.proto
// Note: requires additional types generated from: lib/protocol/attribute.proto
// Note: requires additional types generated from: service/toon/toon.proto
namespace bnet.protocol.toon.external
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ToonListRequest")]
  public partial class ToonListRequest : global::ProtoBuf.IExtensible
  {
    public ToonListRequest() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ToonListResponse")]
  public partial class ToonListResponse : global::ProtoBuf.IExtensible
  {
    public ToonListResponse() {}
    
    private readonly global::System.Collections.Generic.List<bnet.protocol.EntityId> _toons = new global::System.Collections.Generic.List<bnet.protocol.EntityId>();
    [global::ProtoBuf.ProtoMember(2, Name=@"toons", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.EntityId> toons
    {
      get { return _toons; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SelectToonRequest")]
  public partial class SelectToonRequest : global::ProtoBuf.IExtensible
  {
    public SelectToonRequest() {}
    
    private bnet.protocol.EntityId _toon;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"toon", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId toon
    {
      get { return _toon; }
      set { _toon = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SelectToonResponse")]
  public partial class SelectToonResponse : global::ProtoBuf.IExtensible
  {
    public SelectToonResponse() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateToonRequest")]
  public partial class CreateToonRequest : global::ProtoBuf.IExtensible
  {
    public CreateToonRequest() {}
    

    private string _name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private readonly global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> _attribute = new global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute>();
    [global::ProtoBuf.ProtoMember(2, Name=@"attribute", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<bnet.protocol.attribute.Attribute> attribute
    {
      get { return _attribute; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"CreateToonResponse")]
  public partial class CreateToonResponse : global::ProtoBuf.IExtensible
  {
    public CreateToonResponse() {}
    

    private bnet.protocol.EntityId _toon = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"toon", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.EntityId toon
    {
      get { return _toon; }
      set { _toon = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DeleteToonRequest")]
  public partial class DeleteToonRequest : global::ProtoBuf.IExtensible
  {
    public DeleteToonRequest() {}
    
    private bnet.protocol.EntityId _toon;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"toon", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.EntityId toon
    {
      get { return _toon; }
      set { _toon = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DeleteToonResponse")]
  public partial class DeleteToonResponse : global::ProtoBuf.IExtensible
  {
    public DeleteToonResponse() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    public interface IToonServiceExternal
    {
      bnet.protocol.toon.external.ToonListResponse ToonList(bnet.protocol.toon.external.ToonListRequest request);
    bnet.protocol.toon.external.SelectToonResponse SelectToon(bnet.protocol.toon.external.SelectToonRequest request);
    bnet.protocol.toon.external.CreateToonResponse CreateToon(bnet.protocol.toon.external.CreateToonRequest request);
    bnet.protocol.toon.external.DeleteToonResponse DeleteToon(bnet.protocol.toon.external.DeleteToonRequest request);
    
    }
    
    
}