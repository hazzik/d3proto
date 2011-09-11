//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: lib/rpc/rpc.proto
// Note: requires additional types generated from: google/protobuf/descriptor.proto
namespace bnet.protocol
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NO_RESPONSE")]
  public partial class NO_RESPONSE : global::ProtoBuf.IExtensible
  {
    public NO_RESPONSE() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Address")]
  public partial class Address : global::ProtoBuf.IExtensible
  {
    public Address() {}
    
    private string _address;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"address", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string address
    {
      get { return _address; }
      set { _address = value; }
    }

    private uint _port = default(uint);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"port", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(uint))]
    public uint port
    {
      get { return _port; }
      set { _port = value; }
    }

    private bnet.protocol.Address _next = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"next", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public bnet.protocol.Address next
    {
      get { return _next; }
      set { _next = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ProcessId")]
  public partial class ProcessId : global::ProtoBuf.IExtensible
  {
    public ProcessId() {}
    
    private uint _label;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"label", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint label
    {
      get { return _label; }
      set { _label = value; }
    }
    private uint _epoch;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"epoch", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint epoch
    {
      get { return _epoch; }
      set { _epoch = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ObjectAddress")]
  public partial class ObjectAddress : global::ProtoBuf.IExtensible
  {
    public ObjectAddress() {}
    
    private bnet.protocol.ProcessId _host;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"host", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bnet.protocol.ProcessId host
    {
      get { return _host; }
      set { _host = value; }
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
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NoData")]
  public partial class NoData : global::ProtoBuf.IExtensible
  {
    public NoData() {}
    
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}