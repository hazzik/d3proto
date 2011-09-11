//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: Account.proto
// Note: requires additional types generated from: AttributeSerializer.proto
// Note: requires additional types generated from: Items.proto
// Note: requires additional types generated from: OnlineService.proto
// Note: requires additional types generated from: ItemCrafting.proto
namespace D3.Account
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"BannerConfiguration")]
  public partial class BannerConfiguration : global::ProtoBuf.IExtensible
  {
    public BannerConfiguration() {}
    
    private uint _banner_index;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"banner_index", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint banner_index
    {
      get { return _banner_index; }
      set { _banner_index = value; }
    }
    private int _sigil_main;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"sigil_main", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int sigil_main
    {
      get { return _sigil_main; }
      set { _sigil_main = value; }
    }
    private int _sigil_accent;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"sigil_accent", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int sigil_accent
    {
      get { return _sigil_accent; }
      set { _sigil_accent = value; }
    }
    private int _pattern_color_index;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"pattern_color_index", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int pattern_color_index
    {
      get { return _pattern_color_index; }
      set { _pattern_color_index = value; }
    }
    private int _background_color_index;
    [global::ProtoBuf.ProtoMember(5, IsRequired = true, Name=@"background_color_index", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int background_color_index
    {
      get { return _background_color_index; }
      set { _background_color_index = value; }
    }
    private int _sigil_color_index;
    [global::ProtoBuf.ProtoMember(6, IsRequired = true, Name=@"sigil_color_index", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int sigil_color_index
    {
      get { return _sigil_color_index; }
      set { _sigil_color_index = value; }
    }
    private int _placement_index;
    [global::ProtoBuf.ProtoMember(7, IsRequired = true, Name=@"placement_index", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int placement_index
    {
      get { return _placement_index; }
      set { _placement_index = value; }
    }
    private int _pattern;
    [global::ProtoBuf.ProtoMember(8, IsRequired = true, Name=@"pattern", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public int pattern
    {
      get { return _pattern; }
      set { _pattern = value; }
    }
    private bool _use_sigil_variant;
    [global::ProtoBuf.ProtoMember(9, IsRequired = true, Name=@"use_sigil_variant", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool use_sigil_variant
    {
      get { return _use_sigil_variant; }
      set { _use_sigil_variant = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"Digest")]
  public partial class Digest : global::ProtoBuf.IExtensible
  {
    public Digest() {}
    
    private uint _version;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"version", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint version
    {
      get { return _version; }
      set { _version = value; }
    }
    private D3.OnlineService.EntityId _last_played_hero_id;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"last_played_hero_id", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public D3.OnlineService.EntityId last_played_hero_id
    {
      get { return _last_played_hero_id; }
      set { _last_played_hero_id = value; }
    }
    private D3.Account.BannerConfiguration _banner_configuration;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"banner_configuration", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public D3.Account.BannerConfiguration banner_configuration
    {
      get { return _banner_configuration; }
      set { _banner_configuration = value; }
    }
    private uint _flags;
    [global::ProtoBuf.ProtoMember(4, IsRequired = true, Name=@"flags", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint flags
    {
      get { return _flags; }
      set { _flags = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"Flags")]
    public enum Flags
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"HARDCORE_HERO_UNLOCKED", Value=1)]
      HARDCORE_HERO_UNLOCKED = 1
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"SavedDefinition")]
  public partial class SavedDefinition : global::ProtoBuf.IExtensible
  {
    public SavedDefinition() {}
    
    private uint _version;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"version", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    public uint version
    {
      get { return _version; }
      set { _version = value; }
    }

    private D3.Account.Digest _digest = null;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"digest", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public D3.Account.Digest digest
    {
      get { return _digest; }
      set { _digest = value; }
    }
    private D3.AttributeSerializer.SavedAttributes _saved_attributes;
    [global::ProtoBuf.ProtoMember(3, IsRequired = true, Name=@"saved_attributes", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public D3.AttributeSerializer.SavedAttributes saved_attributes
    {
      get { return _saved_attributes; }
      set { _saved_attributes = value; }
    }

    private D3.Items.ItemList _normal_shared_saved_items = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"normal_shared_saved_items", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public D3.Items.ItemList normal_shared_saved_items
    {
      get { return _normal_shared_saved_items; }
      set { _normal_shared_saved_items = value; }
    }

    private D3.Items.ItemList _hardcore_shared_saved_items = null;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"hardcore_shared_saved_items", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public D3.Items.ItemList hardcore_shared_saved_items
    {
      get { return _hardcore_shared_saved_items; }
      set { _hardcore_shared_saved_items = value; }
    }

    private D3.ItemCrafting.CrafterSavedData _crafter_saved_data = null;
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"crafter_saved_data", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public D3.ItemCrafting.CrafterSavedData crafter_saved_data
    {
      get { return _crafter_saved_data; }
      set { _crafter_saved_data = value; }
    }
    private readonly global::System.Collections.Generic.List<int> _seen_tutorials = new global::System.Collections.Generic.List<int>();
    [global::ProtoBuf.ProtoMember(7, Name=@"seen_tutorials", DataFormat = global::ProtoBuf.DataFormat.FixedSize)]
    public global::System.Collections.Generic.List<int> seen_tutorials
    {
      get { return _seen_tutorials; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}