using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Editing;
using System;
using System.IO;

namespace CodeGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            string file = File.ReadAllText("BlobRestClient.txt");
            //var workspace = new AdhocWorkspace();
            //var gen = SyntaxGenerator.GetGenerator(workspace, LanguageNames.CSharp);

            //var f1 = RawSyntaxFactory.Generate();
            //File.WriteAllText("f1.txt", f1);

            //RawSyntaxFactory.GenerateQuoter(file);

            var f2 = GenerateWithStrings.Generate();
            File.WriteAllText("f2.txt", f2);
        }
    }
}
