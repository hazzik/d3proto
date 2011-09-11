using System;
using System.Collections.Generic;
using System.IO;

using Label = Google.ProtocolBuffers.DescriptorProtos.FieldDescriptorProto.Types.Label;
using Type = Google.ProtocolBuffers.DescriptorProtos.FieldDescriptorProto.Types.Type;

namespace d3emu
{
    class Program
    {
        static readonly Dictionary<Label, string> Labels = new Dictionary<Label, string>
        {
            { default(Label), "unknown" },
            { Label.LABEL_OPTIONAL, "optional" },
            { Label.LABEL_REQUIRED, "required" },
            { Label.LABEL_REPEATED, "repeated" }
        };

        static readonly Dictionary<Type, string> Types = new Dictionary<Type, string>
        {
            { default(Type), "unknown" },
            { Type.TYPE_DOUBLE, "double" },
            { Type.TYPE_FLOAT, "float" },
            { Type.TYPE_INT64, "int64" },
            { Type.TYPE_UINT64, "uint64" },
            { Type.TYPE_INT32, "int32" },
            { Type.TYPE_FIXED64, "fixed64" },
            { Type.TYPE_FIXED32, "fixed32" },
            { Type.TYPE_BOOL, "bool" },
            { Type.TYPE_STRING, "string" },
            { Type.TYPE_GROUP, "group" },
            { Type.TYPE_MESSAGE, "message" },
            { Type.TYPE_BYTES, "bytes" },
            { Type.TYPE_UINT32, "uint32" },
            { Type.TYPE_ENUM, "enum" },
            { Type.TYPE_SFIXED32, "sfixed32" },
            { Type.TYPE_SFIXED64, "sfixed64" },
            { Type.TYPE_SINT32, "sint32" },
            { Type.TYPE_SINT64, "sint64" }
        };

        class Ext
        {
            public string Name;
            public int Number;
            public Type Type;

            public Ext(string e, int n, Type t)
            {
                Name = e;
                Number = n;
                Type = t;
            }
        }

        static List<Ext> Extensions = new List<Ext>();

        static void Main(string[] args)
        {
            Console.WriteLine("protobin decompiler v0.1");

            var files = Directory.GetFiles("protobins", "*.protobin", SearchOption.AllDirectories);

            // called twice for a reason, don't touch
            foreach (var file in files)
                ParseProtoBin(file);

            foreach (var file in files)
                ParseProtoBin(file);

            Console.WriteLine("Done! {0} files decompiled.", files.Length);

            Console.ReadKey();
        }

        static Ext GetExtByNumber(int num)
        {
            foreach (var e in Extensions)
                if (e.Number == num)
                    return e;

            return null;
        }

        private static void ParseProtoBin(string file)
        {
            var stream = new FileStream(file, FileMode.Open);

            var dp = Google.ProtocolBuffers.DescriptorProtos.FileDescriptorProto.ParseFrom(stream);

            using (var w = new StreamWriter(file + ".txt"))
            {
                dp.PrintTo(w);
            }

            var fn = file.Substring(0, file.Length - 3);

            using (var w = new StreamWriter(fn))
            {
                foreach (var d in dp.DependencyList)
                {
                    w.WriteLine("import \"{0}\";", d);
                }

                if (dp.DependencyCount > 0)
                    w.WriteLine();

                if (dp.HasPackage)
                {
                    w.WriteLine("package {0};", dp.Package);
                    w.WriteLine();
                }

                //if (dp.HasOptions)
                //{
                //    if (dp.Options.HasCcGenericServices)
                //    {
                //        w.WriteLine("option cc_generic_services = {0};", dp.Options.CcGenericServices.ToString().ToLower());
                //        w.WriteLine();
                //    }
                //}

                foreach (var m in dp.MessageTypeList)
                {
                    w.WriteLine("message {0}", m.Name);
                    w.WriteLine("{");

                    foreach (var n in m.NestedTypeList)
                    {
                        w.WriteLine("    message {0}", n.Name);
                        w.WriteLine("    {");
                        foreach (var ef in n.FieldList)
                        {
                            if (ef.HasTypeName)
                                w.WriteLine("        {0} {1} {2} = {3};", Labels[ef.Label], ef.TypeName, ef.Name, ef.Number);
                            else
                                w.WriteLine("        {0} {1} {2} = {3};", Labels[ef.Label], Types[ef.Type], ef.Name, ef.Number);
                        }
                        w.WriteLine("    }");
                        w.WriteLine();
                    }

                    foreach (var e in m.EnumTypeList)
                    {
                        w.WriteLine("    enum {0}", e.Name);
                        w.WriteLine("    {");
                        foreach (var ev in e.ValueList)
                        {
                            w.WriteLine("        {0} = {1};", ev.Name, ev.Number);
                        }
                        w.WriteLine("    }");
                        w.WriteLine();
                    }

                    //if (m.EnumTypeCount > 0)
                    //    w.WriteLine();

                    foreach (var f in m.FieldList)
                    {
                        if (f.HasDefaultValue)
                        {
                            if (f.Type == Type.TYPE_STRING) // string need to be in quotes
                            {
                                if (f.HasTypeName)
                                    w.WriteLine("    {0} {1} {2} = {3} [default = \"{4}\"];", Labels[f.Label], f.TypeName, f.Name, f.Number, f.DefaultValue);
                                else
                                    w.WriteLine("    {0} {1} {2} = {3} [default = \"{4}\"];", Labels[f.Label], Types[f.Type], f.Name, f.Number, f.DefaultValue);
                            }
                            else
                            {
                                if (f.HasTypeName)
                                    w.WriteLine("    {0} {1} {2} = {3} [default = {4}];", Labels[f.Label], f.TypeName, f.Name, f.Number, f.DefaultValue);
                                else
                                    w.WriteLine("    {0} {1} {2} = {3} [default = {4}];", Labels[f.Label], Types[f.Type], f.Name, f.Number, f.DefaultValue);
                            }
                        }
                        else
                        {
                            if (f.HasOptions && f.Options.HasPacked)
                            {
                                if (f.HasTypeName)
                                    w.WriteLine("    {0} {1} {2} = {3} [packed={4}];", Labels[f.Label], f.TypeName, f.Name, f.Number, f.Options.Packed.ToString().ToLower());
                                else
                                    w.WriteLine("    {0} {1} {2} = {3} [packed={4}];", Labels[f.Label], Types[f.Type], f.Name, f.Number, f.Options.Packed.ToString().ToLower());
                            }
                            else
                            {
                                if (f.HasTypeName)
                                    w.WriteLine("    {0} {1} {2} = {3};", Labels[f.Label], f.TypeName, f.Name, f.Number);
                                else
                                    w.WriteLine("    {0} {1} {2} = {3};", Labels[f.Label], Types[f.Type], f.Name, f.Number);
                            }
                        }
                    }

                    //if (m.FieldCount > 0)
                    //    w.WriteLine();

                    foreach (var er in m.ExtensionRangeList)
                    {
                        w.WriteLine("    extensions {0} to {1};", er.Start, er.End == 0x20000000 ? "max" : er.End.ToString());
                    }

                    //if (m.ExtensionRangeCount > 0)
                    //    w.WriteLine();

                    foreach (var ext in m.ExtensionList)
                    {
                        Extensions.Add(new Ext(ext.Name, ext.Number, ext.Type));

                        w.WriteLine("    extend {0}", ext.Extendee);
                        w.WriteLine("    {");
                        {
                            if (ext.HasTypeName)
                                w.WriteLine("        {0} {1} {2} = {3};", Labels[ext.Label], ext.TypeName, ext.Name, ext.Number);
                            else
                                w.WriteLine("        {0} {1} {2} = {3};", Labels[ext.Label], Types[ext.Type], ext.Name, ext.Number);
                        }
                        w.WriteLine("    }");
                    }

                    w.WriteLine("}");
                    w.WriteLine();
                }

                foreach (var s in dp.ServiceList)
                {
                    w.WriteLine("service {0}", s.Name);
                    w.WriteLine("{");

                    foreach (var m in s.MethodList)
                    {
                        w.Write("    rpc {0}({1}) returns ({2})", m.Name, m.InputType, m.OutputType);

                        if (m.HasOptions)
                        {
                            w.WriteLine();
                            w.WriteLine("    {");

                            foreach (var o in m.Options.UnknownFields.FieldDictionary)
                            {
                                var ext = GetExtByNumber(o.Key);

                                if (ext == null)
                                    continue;

                                if (o.Value.VarintList.Count > 0)
                                {
                                    w.WriteLine("        option ({0}) = {1};", ext.Name, o.Value.VarintList[0]);
                                }
                                else if (o.Value.Fixed32List.Count > 0)
                                {
                                    if (ext.Type == Type.TYPE_FLOAT)
                                    {
                                        var value = BitConverter.ToSingle(BitConverter.GetBytes(o.Value.Fixed32List[0]), 0);
                                        w.WriteLine("        option ({0}) = {1};", ext.Name, value);
                                    }
                                    else
                                    {
                                        w.WriteLine("        option ({0}) = {1};", ext.Name, o.Value.Fixed32List[0]);
                                    }
                                }
                                else
                                    throw new Exception();
                            }
                            w.WriteLine("    }");
                        }
                        else
                            w.WriteLine(";");

                        //w.WriteLine("    rpc {0}({1}) returns ({2});", m.Name, m.InputType, m.OutputType);
                    }

                    w.WriteLine("}");
                    w.WriteLine();
                }

                foreach (var e in dp.EnumTypeList)
                {
                    w.WriteLine("enum {0}", e.Name);
                    w.WriteLine("{");
                    foreach (var ev in e.ValueList)
                    {
                        w.WriteLine("    {0} = {1};", ev.Name, ev.Number);
                    }
                    w.WriteLine("}");
                    w.WriteLine();
                }

                foreach (var ext in dp.ExtensionList)
                {
                    Extensions.Add(new Ext(ext.Name, ext.Number, ext.Type));

                    w.WriteLine("extend {0}", ext.Extendee);
                    w.WriteLine("{");
                    {
                        if (ext.HasTypeName)
                            w.WriteLine("    {0} {1} {2} = {3};", Labels[ext.Label], ext.TypeName, ext.Name, ext.Number);
                        else
                            w.WriteLine("    {0} {1} {2} = {3};", Labels[ext.Label], Types[ext.Type], ext.Name, ext.Number);
                    }
                    w.WriteLine("}");
                    w.WriteLine();
                }
            }

            stream.Close();
        }
    }
}
