//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Hireling.proto
namespace D3.Hireling
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Info")]
  public partial class Info : global::ProtoBuf.IExtensible
  {
    public Info() {}
    
    private int _hireling_class;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"hireling_class", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int hireling_class
    {
      get { return _hireling_class; }
      set { _hireling_class = value; }
    }
    private int _gbid_name;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"gbid_name", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public int gbid_name
    {
      get { return _gbid_name; }
      set { _gbid_name = value; }
    }
    private int _level;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"level", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public int level
    {
      get { return _level; }
      set { _level = value; }
    }
    private uint _attribute_experience_next;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"attribute_experience_next", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint attribute_experience_next
    {
      get { return _attribute_experience_next; }
      set { _attribute_experience_next = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _power_key_params = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(11, Name=@"power_key_params", DataFormat = global::ProtoBuf.DataFormat.ZigZag)]
    public global::System.Collections.Generic.List<int> power_key_params
    {
      get { return _power_key_params; }
    }
  
    private bool _dead;
    [global::ProtoBuf.ProtoMember(12, IsRequired = true, Name=@"dead", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool dead
    {
      get { return _dead; }
      set { _dead = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SavedData")]
  public partial class SavedData : global::ProtoBuf.IExtensible
  {
    public SavedData() {}
    
    private readonly global::System.Collections.Generic.List<D3.Hireling.Info> _hirelings = new global::System.Collections.Generic.List<D3.Hireling.Info>();
    [global::ProtoBuf.ProtoMember(1, Name=@"hirelings", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<D3.Hireling.Info> hirelings
    {
      get { return _hirelings; }
    }
  
    private uint _active_hireling;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"active_hireling", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint active_hireling
    {
      get { return _active_hireling; }
      set { _active_hireling = value; }
    }
    private uint _available_hirelings_bitfield;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"available_hirelings_bitfield", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint available_hirelings_bitfield
    {
      get { return _available_hirelings_bitfield; }
      set { _available_hirelings_bitfield = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}