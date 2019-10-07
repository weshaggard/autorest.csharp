using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using RoslynQuoter;
using static RoslynQuoter.Quoter;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.Formatting;
using System.Security.Cryptography.X509Certificates;

namespace CodeGenerator
{
    public abstract class CodeWriter
    {
        private StringBuilder _builder;
        public CodeWriter()
        {
            _builder = new StringBuilder();
        }

        public class Block : IDisposable
        {
            public Action _endBlockAction;

            public Block(Action endBlockAction)
            {
                _endBlockAction = endBlockAction;
            }

            public void EndBlock()
            {
                Action action = _endBlockAction;
                _endBlockAction = null;
                if (action != null)
                {
                    action();
                }
            }

            public void Dispose()
            {
                EndBlock();
            }
        }

        public void Line(string str = "")
        {
            _builder.AppendLine(str);
        }

        public void Append(string str = "")
        {
            _builder.Append(str);
        }

        public Block Scope(string start = "{", string end = "}")
        {
            Line(start);

            return new Block(() => EndScope(end));
        }

        public void EndScope(string end = "}")
        {
            Line(end);
        }

        public override string ToString()
        {
            return _builder.ToString();
        }

        public Block Namespace(string name)
        {
            Line($"namespace {name}");
            return Scope();
        }

        public Block Class(string modifiers, string name)
        {
            Line($"{modifiers} class {name}");
            return Scope();
        }

        public Block Method(string methodDeclaration)
        {
            Line(methodDeclaration);
            return Scope();
        }

        public void AutoProperty(string modifiers, string type, string name)
        {
            Line($"{modifiers} {type} {name}" + "{ get; set; }");
        }

        public Block Method(string modifiers, string type, string name, params string[] parameters)
        {
            Line($"{modifiers} {type} {name}({string.Join(", ", parameters)})");
            return Scope();
        }

        public void DocSummary(string summary)
        {
            Line("/// <summary>");
            string[] summaryLines = summary.Split(Environment.NewLine);
            foreach (var summaryLine in summaryLines)
            {
                Line($"/// {summaryLine}");
            }
            Line("/// </summary>");
        }
        public void DocParam(string paramName, string paramSummary)
        {
            Line($"/// <param name=\"{paramName}\">{paramSummary}</param>");
        }

        public void DocReturns(string returns)
        {
            Line($"/// <returns>{returns}</returns>");
        }


        private HashSet<string> _usings = new HashSet<string>();

        public void Usings(params string[] namespaces)
        {
            foreach(var ns in namespaces)
            {
                _usings.Add(ns);
            }

            var sortedList = _usings.ToList();
            sortedList.Sort();
            foreach (var u in sortedList)
            {
                Line($"using {u};");
            }

            if (_usings.Any())
            {
                Line();
            }
        }
        public string TypeReference(string name)
        {
            int index = name.LastIndexOf('.');

            if (index > 0)
            {
                string ns = name.Substring(0, index);
                name = name.Substring(index + 1);

                _usings.Add(ns);
            }
            return name;
        }
    }
    class GenerateWithStrings : CodeWriter
    {
        public string WriteCode()
        {
            var dateTimeOffset = TypeReference("System.DateTimeOffset");
            var xElement = TypeReference("System.Xml.Linq.XElement");
            var accessPolicy = TypeReference("Azure.Storage.Blobs.Models.AccessPolicy");
            var debugType = TypeReference("System.Diagnostics.Debug");
            var xName = TypeReference("System.Xml.Linq.XName");
            var cultureInfo = TypeReference("System.Globalization.CultureInfo");


            Line("// Copyright (c) Microsoft Corporation. All rights reserved.");
            Line("// Licensed under the MIT License.");
            Line();
            Line("#pragma warning disable IDE0016 // Null check can be simplified");
            Line();
            Usings();
            Line("#region Models");
            using (Namespace("Azure.Storage.Blobs.Models"))
            {
                DocSummary("An Access policy");
                using (Class("public partial", "AccessPolicy"))
                {
                    DocSummary("the date-time the policy is active");
                    AutoProperty("public", dateTimeOffset, "Start");
                    Line();

                    DocSummary("Serialize a AccessPolicy instance as XML.");
                    DocParam("value", "The AccessPolicy instance to serialize.");
                    DocParam("name", "An optional name to use for the root element instead of \"AccessPolicy\".");
                    DocParam("ns", "An optional namespace to use for the root element instead of \"\".");
                    DocReturns("The serialized XML element.");

                    using (Method("internal static", xElement, "ToXml",
                        $"{accessPolicy} value",
                        "string name = \"AccessPolicy\"",
                        "string ns = \"\""
                        ))
                    {
                        Line($"{debugType}.Assert(value != null);");
                        Line($"{xElement} _element = new {xElement}({xName}.Get(name, ns));");
                        Line($"_element.Add(new {xElement}(");
                        Line($"    {xName}.Get(\"Start\", \"\"),");
                        Line($"    value.Start.ToString(\"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ\", {cultureInfo}.InvariantCulture)));");
                        Line($"_element.Add(new {xElement}(");
                        Line($"    {xName}.Get(\"Expiry\", \"\"),");
                        Line($"    value.Expiry.ToString(\"yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ\", {cultureInfo}.InvariantCulture)));");
                        Line($"_element.Add(new {xElement}(");
                        Line($"    {xName}.Get(\"Permission\", \"\"),");
                        Line($"    value.Permission));");
                        Line($"return _element;");
                    }
                }
            }
            Line("#endregion");

            var workspace = new AdhocWorkspace();
            var cu = SyntaxFactory.ParseCompilationUnit(ToString());
            var formattedCode = Formatter.Format(cu, workspace);
            
            return formattedCode.ToFullString();

            //return ToString();
        }

        public static string Generate()
        {
            return new GenerateWithStrings().WriteCode();
        }
    }
}
