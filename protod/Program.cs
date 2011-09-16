using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Google.ProtocolBuffers;

using EnumValue = Google.ProtocolBuffers.Descriptors.EnumValueDescriptor;
using FieldProto = Google.ProtocolBuffers.DescriptorProtos.FieldDescriptorProto;
using FieldType = Google.ProtocolBuffers.Descriptors.FieldType;
using FileProto = Google.ProtocolBuffers.DescriptorProtos.FileDescriptorProto;
using Label = Google.ProtocolBuffers.DescriptorProtos.FieldDescriptorProto.Types.Label;
using Type = Google.ProtocolBuffers.DescriptorProtos.FieldDescriptorProto.Types.Type;

namespace d3emu
{
    internal class Program
    {
        private static readonly Dictionary<Label, string> Labels = new Dictionary<Label, string>
                                                                       {
                                                                           {default(Label), "unknown"},
                                                                           {Label.LABEL_OPTIONAL, "optional"},
                                                                           {Label.LABEL_REQUIRED, "required"},
                                                                           {Label.LABEL_REPEATED, "repeated"}
                                                                       };

        private static readonly Dictionary<Type, string> Types = new Dictionary<Type, string>
                                                                     {
                                                                         {default(Type), "unknown"},
                                                                         {Type.TYPE_DOUBLE, "double"},
                                                                         {Type.TYPE_FLOAT, "float"},
                                                                         {Type.TYPE_INT64, "int64"},
                                                                         {Type.TYPE_UINT64, "uint64"},
                                                                         {Type.TYPE_INT32, "int32"},
                                                                         {Type.TYPE_FIXED64, "fixed64"},
                                                                         {Type.TYPE_FIXED32, "fixed32"},
                                                                         {Type.TYPE_BOOL, "bool"},
                                                                         {Type.TYPE_STRING, "string"},
                                                                         {Type.TYPE_GROUP, "group"},
                                                                         {Type.TYPE_MESSAGE, "message"},
                                                                         {Type.TYPE_BYTES, "bytes"},
                                                                         {Type.TYPE_UINT32, "uint32"},
                                                                         {Type.TYPE_ENUM, "enum"},
                                                                         {Type.TYPE_SFIXED32, "sfixed32"},
                                                                         {Type.TYPE_SFIXED64, "sfixed64"},
                                                                         {Type.TYPE_SINT32, "sint32"},
                                                                         {Type.TYPE_SINT64, "sint64"}
                                                                     };

        private static readonly List<FileProto> Protos = new List<FileProto>();

        private static void Main()
        {
            Console.WriteLine("protobin decompiler v0.2");

            var files = Directory.GetFiles("..\\protobins", "*.protobin", SearchOption.AllDirectories);

            foreach (var file in files)
                Protos.Add(FileProto.ParseFrom(File.ReadAllBytes(file)));

            foreach (var p in Protos)
                ParseProtoBin(p);

            GenerateServices();

            Process.Start("xcopy", "..\\protobins\\*.proto ..\\tools /e /i /h /y");

            Console.WriteLine("Done! {0} files decompiled.", files.Length);

            Console.ReadKey();
        }

        private static void GenerateServices()
        {
            using (var w = new StreamWriter(File.Open(@"..\d3emu\Services.cs", FileMode.Truncate, FileAccess.Write)))
            {
                w.WriteLine(@"using System.Collections.Generic;");
                w.WriteLine();
                w.WriteLine("namespace d3emu");
                w.WriteLine("{");
                w.WriteLine(Indent(1, "public class Services"));
                w.WriteLine(Indent(1, "{"));
                w.WriteLine(Indent(2, "public static readonly IDictionary<string, IDictionary<int, string>> Methods ="));
                w.WriteLine(Indent(3, "new Dictionary<string, IDictionary<int, string>>"));
                w.WriteLine(Indent(4, "{"));

                foreach (var s in Protos.SelectMany(dp => dp.ServiceList))
                {
                    w.WriteLine(Indent(5, "{"));
                    w.WriteLine(Indent(6, "\"{0}\",", s.Name));
                    w.WriteLine(Indent(6, "new Dictionary<int, string>"));
                    w.WriteLine(Indent(7, "{"));
                    foreach (var m in s.MethodList)
                    {
                        if (m.HasOptions)
                        {
                            foreach (var o in m.Options.UnknownFields.FieldDictionary)
                            {
                                var fdp = GetExtFieldDescriptorById(o.Key);
                                var value = GetValue(fdp, o.Value);
                                if (fdp.Name == "method_id")
                                {
                                    w.WriteLine(Indent(8, "{{{0}, \"{1}\"}},", value, m.Name));
                                }
                            }
                        }
                    }
                    w.WriteLine(Indent(7, "}"));
                    w.WriteLine(Indent(6, "},"));
                }
                w.WriteLine(Indent(4, "};"));
                w.WriteLine(Indent(1, "}"));
                w.WriteLine("}");
                w.Flush();
            }
        }

        public static string Indent(int indent, string value)
        {
            return string.Format("{0}{1}", string.Join("", Enumerable.Repeat("\t", indent)), value);
        }

        public static string Indent(int indent, string format, params object[] values)
        {
            return Indent(indent, string.Format(format, values));
        }

        private static FieldProto GetExtFieldDescriptorById(int num)
        {
            return Protos.Where(p => p.ExtensionCount != 0)
                .SelectMany(p => p.ExtensionList)
                .FirstOrDefault(e => e.Number == num);
        }

        private static void ParseProtoBin(FileProto proto)
        {
            var dp = proto;

            SaveTxt(dp);

            SaveProto(dp);

        }

        private static object GetValue(FieldProto fdp, UnknownField unknownField)
        {
            if (unknownField.VarintList.Count > 0) return unknownField.VarintList[0];
            if (unknownField.Fixed32List.Count > 0)
            {
                if (fdp.Type == Type.TYPE_FLOAT)
                    return BitConverter.ToSingle(BitConverter.GetBytes(unknownField.Fixed32List[0]), 0);
                return unknownField.Fixed32List[0];
            }
            throw new Exception();
        }

        private static void SaveProto(FileProto dp)
        {
            using (var w = new StreamWriter("..\\protobins\\" + dp.Name))
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

                if (dp.HasOptions)
                {
                    foreach (var o in dp.Options.AllFields)
                    {
                        if (o.Key.FieldType == FieldType.Enum)
                            w.WriteLine("option {0} = {1};", o.Key.Name, ((EnumValue) o.Value).Name);
                        else if (o.Key.FieldType == FieldType.String)
                            w.WriteLine("option {0} = \"{1}\";", o.Key.Name, o.Value);
                        else
                            w.WriteLine("option {0} = {1};", o.Key.Name, o.Value.ToString().ToLower());
                    }

                    w.WriteLine();
                }

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
                            w.WriteLine("        {0} {1} {2} = {3};", Labels[ef.Label], GetTypeName(ef), ef.Name, ef.Number);
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
                            w.WriteLine("    {0} {1} {2} = {3} [default = {4}];", Labels[f.Label], GetTypeName(f), f.Name, f.Number, f.Type == Type.TYPE_STRING ? string.Format("\"{0}\"", f.DefaultValue) : f.DefaultValue);
                        }
                        else
                        {
                            if (f.HasOptions && f.Options.HasPacked)
                            {
                                w.WriteLine("    {0} {1} {2} = {3} [packed={4}];", Labels[f.Label], GetTypeName(f), f.Name, f.Number, f.Options.Packed.ToString().ToLower());
                            }
                            else
                            {
                                w.WriteLine("    {0} {1} {2} = {3};", Labels[f.Label], GetTypeName(f), f.Name, f.Number);
                            }
                        }
                    }

                    //if (m.FieldCount > 0)
                    //    w.WriteLine();

                    foreach (var er in m.ExtensionRangeList)
                    {
                        w.WriteLine("    extensions {0} to {1};", er.Start,
                                    er.End == 0x20000000 ? "max" : er.End.ToString());
                    }

                    //if (m.ExtensionRangeCount > 0)
                    //    w.WriteLine();

                    foreach (var ext in m.ExtensionList)
                    {
                        w.WriteLine("    extend {0}", ext.Extendee);
                        w.WriteLine("    {");
                        {
                            w.WriteLine("        {0} {1} {2} = {3};", Labels[ext.Label], GetTypeName(ext), ext.Name, ext.Number);
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
                        w.Write("    rpc {0}({1}) returns({2})", m.Name, m.InputType, m.OutputType);

                        if (m.HasOptions)
                        {
                            w.WriteLine();
                            w.WriteLine("    {");

                            foreach (var o in m.Options.UnknownFields.FieldDictionary)
                            {
                                var fdp = GetExtFieldDescriptorById(o.Key);

                                w.WriteLine("        option ({0}) = {1};", fdp.Name, GetValue(fdp, o.Value));
                            }
                            w.WriteLine("    }");
                        }
                        else
                            w.WriteLine(";");
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
                    w.WriteLine("extend {0}", ext.Extendee);
                    w.WriteLine("{");
                    {
                        w.WriteLine("    {0} {1} {2} = {3};", Labels[ext.Label], GetTypeName(ext), ext.Name, ext.Number);
                    }
                    w.WriteLine("}");
                    w.WriteLine();
                }
            }
        }

        private static string GetTypeName(FieldProto ext)
        {
            return ext.HasTypeName ? ext.TypeName : Types[ext.Type];
        }

        private static void SaveTxt(FileProto dp)
        {
            using (var w = new StreamWriter("..\\protobins\\" + dp.Name + ".txt"))
            {
                dp.PrintTo(w);
            }
        }
    }
}
