using AutoRest.CSharp.V3.PipelineModels;
using System;
using System.Collections.Generic;
using System.Text;
using Testura.Code;
using Testura.Code.Models;
using Parameter = Testura.Code.Models.Parameter;
using Testura.Code.Builders;
using Testura.Code.Generators.Common;
using Testura.Code.Statements;
using Testura.Code.Generators.Common.Arguments.ArgumentTypes;

namespace AutoRest.CSharp.V3.CodeGen
{
    internal class CodeGenerator
    {
        public string GenerateModels(CodeModel codeModel)
        {
            var c = new ClassBuilder("Program", "HelloWorld")
                .WithUsings("System")
                .WithModifiers(Modifiers.Public)
                .WithMethods(
                    new MethodBuilder("Main")
                    .WithModifiers(Modifiers.Public, Modifiers.Static)
                    .WithParameters(new Parameter("args", typeof(string[])))
                    .WithBody(
                        BodyGenerator.Create(
                            Statement.Expression.Invoke("Console", "WriteLine", new List<IArgument>() { new ValueArgument("Hello world") }).AsStatement(),
                            Statement.Expression.Invoke("Console", "ReadLine").AsStatement()
                            ))
                    .Build())
                .Build();


            Console.WriteLine(c);
            return c.ToFullString();
        }
    }
}
