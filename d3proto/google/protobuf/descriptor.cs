//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from: google/protobuf/descriptor.proto
namespace google.protobuf
{
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FileDescriptorSet")]
  public partial class FileDescriptorSet : global::ProtoBuf.IExtensible
  {
    public FileDescriptorSet() {}
    
    private readonly global::System.Collections.Generic.List<google.protobuf.FileDescriptorProto> _file = new global::System.Collections.Generic.List<google.protobuf.FileDescriptorProto>();
    [global::ProtoBuf.ProtoMember(1, Name=@"file", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.FileDescriptorProto> file
    {
      get { return _file; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FileDescriptorProto")]
  public partial class FileDescriptorProto : global::ProtoBuf.IExtensible
  {
    public FileDescriptorProto() {}
    

    private string _name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }

    private string _package = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"package", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string package
    {
      get { return _package; }
      set { _package = value; }
    }
    private readonly global::System.Collections.Generic.List<string> _dependency = new global::System.Collections.Generic.List<string>();
    [global::ProtoBuf.ProtoMember(3, Name=@"dependency", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<string> dependency
    {
      get { return _dependency; }
    }
  
    private readonly global::System.Collections.Generic.List<google.protobuf.DescriptorProto> _message_type = new global::System.Collections.Generic.List<google.protobuf.DescriptorProto>();
    [global::ProtoBuf.ProtoMember(4, Name=@"message_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.DescriptorProto> message_type
    {
      get { return _message_type; }
    }
  
    private readonly global::System.Collections.Generic.List<google.protobuf.EnumDescriptorProto> _enum_type = new global::System.Collections.Generic.List<google.protobuf.EnumDescriptorProto>();
    [global::ProtoBuf.ProtoMember(5, Name=@"enum_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.EnumDescriptorProto> enum_type
    {
      get { return _enum_type; }
    }
  
    private readonly global::System.Collections.Generic.List<google.protobuf.ServiceDescriptorProto> _service = new global::System.Collections.Generic.List<google.protobuf.ServiceDescriptorProto>();
    [global::ProtoBuf.ProtoMember(6, Name=@"service", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.ServiceDescriptorProto> service
    {
      get { return _service; }
    }
  
    private readonly global::System.Collections.Generic.List<google.protobuf.FieldDescriptorProto> _extension = new global::System.Collections.Generic.List<google.protobuf.FieldDescriptorProto>();
    [global::ProtoBuf.ProtoMember(7, Name=@"extension", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.FieldDescriptorProto> extension
    {
      get { return _extension; }
    }
  

    private google.protobuf.FileOptions _options = null;
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"options", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public google.protobuf.FileOptions options
    {
      get { return _options; }
      set { _options = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"DescriptorProto")]
  public partial class DescriptorProto : global::ProtoBuf.IExtensible
  {
    public DescriptorProto() {}
    

    private string _name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private readonly global::System.Collections.Generic.List<google.protobuf.FieldDescriptorProto> _field = new global::System.Collections.Generic.List<google.protobuf.FieldDescriptorProto>();
    [global::ProtoBuf.ProtoMember(2, Name=@"field", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.FieldDescriptorProto> field
    {
      get { return _field; }
    }
  
    private readonly global::System.Collections.Generic.List<google.protobuf.FieldDescriptorProto> _extension = new global::System.Collections.Generic.List<google.protobuf.FieldDescriptorProto>();
    [global::ProtoBuf.ProtoMember(6, Name=@"extension", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.FieldDescriptorProto> extension
    {
      get { return _extension; }
    }
  
    private readonly global::System.Collections.Generic.List<google.protobuf.DescriptorProto> _nested_type = new global::System.Collections.Generic.List<google.protobuf.DescriptorProto>();
    [global::ProtoBuf.ProtoMember(3, Name=@"nested_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.DescriptorProto> nested_type
    {
      get { return _nested_type; }
    }
  
    private readonly global::System.Collections.Generic.List<google.protobuf.EnumDescriptorProto> _enum_type = new global::System.Collections.Generic.List<google.protobuf.EnumDescriptorProto>();
    [global::ProtoBuf.ProtoMember(4, Name=@"enum_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.EnumDescriptorProto> enum_type
    {
      get { return _enum_type; }
    }
  
    private readonly global::System.Collections.Generic.List<google.protobuf.DescriptorProto.ExtensionRange> _extension_range = new global::System.Collections.Generic.List<google.protobuf.DescriptorProto.ExtensionRange>();
    [global::ProtoBuf.ProtoMember(5, Name=@"extension_range", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.DescriptorProto.ExtensionRange> extension_range
    {
      get { return _extension_range; }
    }
  

    private google.protobuf.MessageOptions _options = null;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"options", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public google.protobuf.MessageOptions options
    {
      get { return _options; }
      set { _options = value; }
    }
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ExtensionRange")]
  public partial class ExtensionRange : global::ProtoBuf.IExtensible
  {
    public ExtensionRange() {}
    

    private int _start = default(int);
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"start", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int start
    {
      get { return _start; }
      set { _start = value; }
    }

    private int _end = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"end", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int end
    {
      get { return _end; }
      set { _end = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FieldDescriptorProto")]
  public partial class FieldDescriptorProto : global::ProtoBuf.IExtensible
  {
    public FieldDescriptorProto() {}
    

    private string _name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }

    private int _number = default(int);
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"number", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int number
    {
      get { return _number; }
      set { _number = value; }
    }

    private google.protobuf.FieldDescriptorProto.Label _label = google.protobuf.FieldDescriptorProto.Label.LABEL_OPTIONAL;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"label", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(google.protobuf.FieldDescriptorProto.Label.LABEL_OPTIONAL)]
    public google.protobuf.FieldDescriptorProto.Label label
    {
      get { return _label; }
      set { _label = value; }
    }

    private google.protobuf.FieldDescriptorProto.Type _type = google.protobuf.FieldDescriptorProto.Type.TYPE_DOUBLE;
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"type", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(google.protobuf.FieldDescriptorProto.Type.TYPE_DOUBLE)]
    public google.protobuf.FieldDescriptorProto.Type type
    {
      get { return _type; }
      set { _type = value; }
    }

    private string _type_name = "";
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"type_name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string type_name
    {
      get { return _type_name; }
      set { _type_name = value; }
    }

    private string _extendee = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"extendee", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string extendee
    {
      get { return _extendee; }
      set { _extendee = value; }
    }

    private string _default_value = "";
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"default_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string default_value
    {
      get { return _default_value; }
      set { _default_value = value; }
    }

    private google.protobuf.FieldOptions _options = null;
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"options", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public google.protobuf.FieldOptions options
    {
      get { return _options; }
      set { _options = value; }
    }
    [global::ProtoBuf.ProtoContract(Name=@"Type")]
    public enum Type
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_DOUBLE", Value=1)]
      TYPE_DOUBLE = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_FLOAT", Value=2)]
      TYPE_FLOAT = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_INT64", Value=3)]
      TYPE_INT64 = 3,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_UINT64", Value=4)]
      TYPE_UINT64 = 4,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_INT32", Value=5)]
      TYPE_INT32 = 5,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_FIXED64", Value=6)]
      TYPE_FIXED64 = 6,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_FIXED32", Value=7)]
      TYPE_FIXED32 = 7,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_BOOL", Value=8)]
      TYPE_BOOL = 8,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_STRING", Value=9)]
      TYPE_STRING = 9,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_GROUP", Value=10)]
      TYPE_GROUP = 10,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_MESSAGE", Value=11)]
      TYPE_MESSAGE = 11,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_BYTES", Value=12)]
      TYPE_BYTES = 12,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_UINT32", Value=13)]
      TYPE_UINT32 = 13,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_ENUM", Value=14)]
      TYPE_ENUM = 14,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_SFIXED32", Value=15)]
      TYPE_SFIXED32 = 15,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_SFIXED64", Value=16)]
      TYPE_SFIXED64 = 16,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_SINT32", Value=17)]
      TYPE_SINT32 = 17,
            
      [global::ProtoBuf.ProtoEnum(Name=@"TYPE_SINT64", Value=18)]
      TYPE_SINT64 = 18
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"Label")]
    public enum Label
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"LABEL_OPTIONAL", Value=1)]
      LABEL_OPTIONAL = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LABEL_REQUIRED", Value=2)]
      LABEL_REQUIRED = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LABEL_REPEATED", Value=3)]
      LABEL_REPEATED = 3
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EnumDescriptorProto")]
  public partial class EnumDescriptorProto : global::ProtoBuf.IExtensible
  {
    public EnumDescriptorProto() {}
    

    private string _name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private readonly global::System.Collections.Generic.List<google.protobuf.EnumValueDescriptorProto> _value = new global::System.Collections.Generic.List<google.protobuf.EnumValueDescriptorProto>();
    [global::ProtoBuf.ProtoMember(2, Name=@"value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.EnumValueDescriptorProto> value
    {
      get { return _value; }
    }
  

    private google.protobuf.EnumOptions _options = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"options", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public google.protobuf.EnumOptions options
    {
      get { return _options; }
      set { _options = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EnumValueDescriptorProto")]
  public partial class EnumValueDescriptorProto : global::ProtoBuf.IExtensible
  {
    public EnumValueDescriptorProto() {}
    

    private string _name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }

    private int _number = default(int);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"number", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(int))]
    public int number
    {
      get { return _number; }
      set { _number = value; }
    }

    private google.protobuf.EnumValueOptions _options = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"options", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public google.protobuf.EnumValueOptions options
    {
      get { return _options; }
      set { _options = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ServiceDescriptorProto")]
  public partial class ServiceDescriptorProto : global::ProtoBuf.IExtensible
  {
    public ServiceDescriptorProto() {}
    

    private string _name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }
    private readonly global::System.Collections.Generic.List<google.protobuf.MethodDescriptorProto> _method = new global::System.Collections.Generic.List<google.protobuf.MethodDescriptorProto>();
    [global::ProtoBuf.ProtoMember(2, Name=@"method", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.MethodDescriptorProto> method
    {
      get { return _method; }
    }
  

    private google.protobuf.ServiceOptions _options = null;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"options", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public google.protobuf.ServiceOptions options
    {
      get { return _options; }
      set { _options = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MethodDescriptorProto")]
  public partial class MethodDescriptorProto : global::ProtoBuf.IExtensible
  {
    public MethodDescriptorProto() {}
    

    private string _name = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string name
    {
      get { return _name; }
      set { _name = value; }
    }

    private string _input_type = "";
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"input_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string input_type
    {
      get { return _input_type; }
      set { _input_type = value; }
    }

    private string _output_type = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"output_type", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string output_type
    {
      get { return _output_type; }
      set { _output_type = value; }
    }

    private google.protobuf.MethodOptions _options = null;
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"options", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public google.protobuf.MethodOptions options
    {
      get { return _options; }
      set { _options = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FileOptions")]
  public partial class FileOptions : global::ProtoBuf.IExtensible
  {
    public FileOptions() {}
    

    private string _java_package = "";
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"java_package", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string java_package
    {
      get { return _java_package; }
      set { _java_package = value; }
    }

    private string _java_outer_classname = "";
    [global::ProtoBuf.ProtoMember(8, IsRequired = false, Name=@"java_outer_classname", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string java_outer_classname
    {
      get { return _java_outer_classname; }
      set { _java_outer_classname = value; }
    }

    private bool _java_multiple_files = (bool)false;
    [global::ProtoBuf.ProtoMember(10, IsRequired = false, Name=@"java_multiple_files", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool java_multiple_files
    {
      get { return _java_multiple_files; }
      set { _java_multiple_files = value; }
    }

    private google.protobuf.FileOptions.OptimizeMode _optimize_for = google.protobuf.FileOptions.OptimizeMode.SPEED;
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"optimize_for", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(google.protobuf.FileOptions.OptimizeMode.SPEED)]
    public google.protobuf.FileOptions.OptimizeMode optimize_for
    {
      get { return _optimize_for; }
      set { _optimize_for = value; }
    }

    private bool _cc_generic_services = (bool)true;
    [global::ProtoBuf.ProtoMember(16, IsRequired = false, Name=@"cc_generic_services", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)true)]
    public bool cc_generic_services
    {
      get { return _cc_generic_services; }
      set { _cc_generic_services = value; }
    }

    private bool _java_generic_services = (bool)true;
    [global::ProtoBuf.ProtoMember(17, IsRequired = false, Name=@"java_generic_services", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)true)]
    public bool java_generic_services
    {
      get { return _java_generic_services; }
      set { _java_generic_services = value; }
    }

    private bool _py_generic_services = (bool)true;
    [global::ProtoBuf.ProtoMember(18, IsRequired = false, Name=@"py_generic_services", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)true)]
    public bool py_generic_services
    {
      get { return _py_generic_services; }
      set { _py_generic_services = value; }
    }
    private readonly global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> _uninterpreted_option = new global::System.Collections.Generic.List<google.protobuf.UninterpretedOption>();
    [global::ProtoBuf.ProtoMember(999, Name=@"uninterpreted_option", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> uninterpreted_option
    {
      get { return _uninterpreted_option; }
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"OptimizeMode")]
    public enum OptimizeMode
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"SPEED", Value=1)]
      SPEED = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CODE_SIZE", Value=2)]
      CODE_SIZE = 2,
            
      [global::ProtoBuf.ProtoEnum(Name=@"LITE_RUNTIME", Value=3)]
      LITE_RUNTIME = 3
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MessageOptions")]
  public partial class MessageOptions : global::ProtoBuf.IExtensible
  {
    public MessageOptions() {}
    

    private bool _message_set_wire_format = (bool)false;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"message_set_wire_format", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool message_set_wire_format
    {
      get { return _message_set_wire_format; }
      set { _message_set_wire_format = value; }
    }

    private bool _no_standard_descriptor_accessor = (bool)false;
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"no_standard_descriptor_accessor", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool no_standard_descriptor_accessor
    {
      get { return _no_standard_descriptor_accessor; }
      set { _no_standard_descriptor_accessor = value; }
    }
    private readonly global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> _uninterpreted_option = new global::System.Collections.Generic.List<google.protobuf.UninterpretedOption>();
    [global::ProtoBuf.ProtoMember(999, Name=@"uninterpreted_option", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> uninterpreted_option
    {
      get { return _uninterpreted_option; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"FieldOptions")]
  public partial class FieldOptions : global::ProtoBuf.IExtensible
  {
    public FieldOptions() {}
    

    private google.protobuf.FieldOptions.CType _ctype = google.protobuf.FieldOptions.CType.STRING;
    [global::ProtoBuf.ProtoMember(1, IsRequired = false, Name=@"ctype", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(google.protobuf.FieldOptions.CType.STRING)]
    public google.protobuf.FieldOptions.CType ctype
    {
      get { return _ctype; }
      set { _ctype = value; }
    }

    private bool _packed = default(bool);
    [global::ProtoBuf.ProtoMember(2, IsRequired = false, Name=@"packed", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(default(bool))]
    public bool packed
    {
      get { return _packed; }
      set { _packed = value; }
    }

    private bool _deprecated = (bool)false;
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"deprecated", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue((bool)false)]
    public bool deprecated
    {
      get { return _deprecated; }
      set { _deprecated = value; }
    }

    private string _experimental_map_key = "";
    [global::ProtoBuf.ProtoMember(9, IsRequired = false, Name=@"experimental_map_key", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string experimental_map_key
    {
      get { return _experimental_map_key; }
      set { _experimental_map_key = value; }
    }
    private readonly global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> _uninterpreted_option = new global::System.Collections.Generic.List<google.protobuf.UninterpretedOption>();
    [global::ProtoBuf.ProtoMember(999, Name=@"uninterpreted_option", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> uninterpreted_option
    {
      get { return _uninterpreted_option; }
    }
  
    [global::ProtoBuf.ProtoContract(Name=@"CType")]
    public enum CType
    {
            
      [global::ProtoBuf.ProtoEnum(Name=@"STRING", Value=0)]
      STRING = 0,
            
      [global::ProtoBuf.ProtoEnum(Name=@"CORD", Value=1)]
      CORD = 1,
            
      [global::ProtoBuf.ProtoEnum(Name=@"STRING_PIECE", Value=2)]
      STRING_PIECE = 2
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EnumOptions")]
  public partial class EnumOptions : global::ProtoBuf.IExtensible
  {
    public EnumOptions() {}
    
    private readonly global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> _uninterpreted_option = new global::System.Collections.Generic.List<google.protobuf.UninterpretedOption>();
    [global::ProtoBuf.ProtoMember(999, Name=@"uninterpreted_option", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> uninterpreted_option
    {
      get { return _uninterpreted_option; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"EnumValueOptions")]
  public partial class EnumValueOptions : global::ProtoBuf.IExtensible
  {
    public EnumValueOptions() {}
    
    private readonly global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> _uninterpreted_option = new global::System.Collections.Generic.List<google.protobuf.UninterpretedOption>();
    [global::ProtoBuf.ProtoMember(999, Name=@"uninterpreted_option", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> uninterpreted_option
    {
      get { return _uninterpreted_option; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"ServiceOptions")]
  public partial class ServiceOptions : global::ProtoBuf.IExtensible
  {
    public ServiceOptions() {}
    
    private readonly global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> _uninterpreted_option = new global::System.Collections.Generic.List<google.protobuf.UninterpretedOption>();
    [global::ProtoBuf.ProtoMember(999, Name=@"uninterpreted_option", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> uninterpreted_option
    {
      get { return _uninterpreted_option; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"MethodOptions")]
  public partial class MethodOptions : global::ProtoBuf.IExtensible
  {
    public MethodOptions() {}
    
    private readonly global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> _uninterpreted_option = new global::System.Collections.Generic.List<google.protobuf.UninterpretedOption>();
    [global::ProtoBuf.ProtoMember(999, Name=@"uninterpreted_option", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.UninterpretedOption> uninterpreted_option
    {
      get { return _uninterpreted_option; }
    }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"UninterpretedOption")]
  public partial class UninterpretedOption : global::ProtoBuf.IExtensible
  {
    public UninterpretedOption() {}
    
    private readonly global::System.Collections.Generic.List<google.protobuf.UninterpretedOption.NamePart> _name = new global::System.Collections.Generic.List<google.protobuf.UninterpretedOption.NamePart>();
    [global::ProtoBuf.ProtoMember(2, Name=@"name", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public global::System.Collections.Generic.List<google.protobuf.UninterpretedOption.NamePart> name
    {
      get { return _name; }
    }
  

    private string _identifier_value = "";
    [global::ProtoBuf.ProtoMember(3, IsRequired = false, Name=@"identifier_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue("")]
    public string identifier_value
    {
      get { return _identifier_value; }
      set { _identifier_value = value; }
    }

    private ulong _positive_int_value = default(ulong);
    [global::ProtoBuf.ProtoMember(4, IsRequired = false, Name=@"positive_int_value", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(ulong))]
    public ulong positive_int_value
    {
      get { return _positive_int_value; }
      set { _positive_int_value = value; }
    }

    private long _negative_int_value = default(long);
    [global::ProtoBuf.ProtoMember(5, IsRequired = false, Name=@"negative_int_value", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(long))]
    public long negative_int_value
    {
      get { return _negative_int_value; }
      set { _negative_int_value = value; }
    }

    private double _double_value = default(double);
    [global::ProtoBuf.ProtoMember(6, IsRequired = false, Name=@"double_value", DataFormat = global::ProtoBuf.DataFormat.TwosComplement)]
    [global::System.ComponentModel.DefaultValue(default(double))]
    public double double_value
    {
      get { return _double_value; }
      set { _double_value = value; }
    }

    private byte[] _string_value = null;
    [global::ProtoBuf.ProtoMember(7, IsRequired = false, Name=@"string_value", DataFormat = global::ProtoBuf.DataFormat.Default)]
    [global::System.ComponentModel.DefaultValue(null)]
    public byte[] string_value
    {
      get { return _string_value; }
      set { _string_value = value; }
    }
  [global::System.Serializable, global::ProtoBuf.ProtoContract(Name=@"NamePart")]
  public partial class NamePart : global::ProtoBuf.IExtensible
  {
    public NamePart() {}
    
    private string _name_part;
    [global::ProtoBuf.ProtoMember(1, IsRequired = true, Name=@"name_part", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public string name_part
    {
      get { return _name_part; }
      set { _name_part = value; }
    }
    private bool _is_extension;
    [global::ProtoBuf.ProtoMember(2, IsRequired = true, Name=@"is_extension", DataFormat = global::ProtoBuf.DataFormat.Default)]
    public bool is_extension
    {
      get { return _is_extension; }
      set { _is_extension = value; }
    }
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
    private global::ProtoBuf.IExtension extensionObject;
    global::ProtoBuf.IExtension global::ProtoBuf.IExtensible.GetExtensionObject(bool createIfMissing)
      { return global::ProtoBuf.Extensible.GetExtensionObject(ref extensionObject, createIfMissing); }
  }
  
}