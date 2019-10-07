using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp.Formatting;
using RoslynQuoter;
using static RoslynQuoter.Quoter;
using Microsoft.CodeAnalysis.Formatting;

namespace CodeGenerator
{
    class RawSyntaxFactory
    {
        public static string Generate()
        {
            var cu = SyntaxFactory.CompilationUnit()
.WithMembers(
    SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
        SyntaxFactory.NamespaceDeclaration(
            SyntaxFactory.QualifiedName(
                SyntaxFactory.QualifiedName(
                    SyntaxFactory.QualifiedName(
                        SyntaxFactory.IdentifierName("Azure"),
                        SyntaxFactory.IdentifierName("Storage")),
                    SyntaxFactory.IdentifierName("Blobs")),
                SyntaxFactory.IdentifierName(
                    SyntaxFactory.Identifier(
                        SyntaxFactory.TriviaList(),
                        "Models",
                        SyntaxFactory.TriviaList(
                            SyntaxFactory.CarriageReturnLineFeed)))))
        .WithNamespaceKeyword(
            SyntaxFactory.Token(
                SyntaxFactory.TriviaList(
                    new[]{
                        SyntaxFactory.Comment("// Copyright (c) Microsoft Corporation. All rights reserved."),
                        SyntaxFactory.CarriageReturnLineFeed,
                        SyntaxFactory.Comment("// Licensed under the MIT License."),
                        SyntaxFactory.CarriageReturnLineFeed,
                        SyntaxFactory.CarriageReturnLineFeed,
                        SyntaxFactory.Trivia(
                            SyntaxFactory.PragmaWarningDirectiveTrivia(
                                SyntaxFactory.Token(
                                    SyntaxFactory.TriviaList(),
                                    SyntaxKind.DisableKeyword,
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.Space)),
                                true)
                            .WithPragmaKeyword(
                                SyntaxFactory.Token(
                                    SyntaxFactory.TriviaList(),
                                    SyntaxKind.PragmaKeyword,
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.Space)))
                            .WithWarningKeyword(
                                SyntaxFactory.Token(
                                    SyntaxFactory.TriviaList(),
                                    SyntaxKind.WarningKeyword,
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.Space)))
                            .WithErrorCodes(
                                SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(
                                    SyntaxFactory.IdentifierName(
                                        SyntaxFactory.Identifier(
                                            SyntaxFactory.TriviaList(),
                                            "IDE0016",
                                            SyntaxFactory.TriviaList(
                                                new []{
                                                    SyntaxFactory.Space,
                                                    SyntaxFactory.Comment("// Null check can be simplified")})))))
                            .WithEndOfDirectiveToken(
                                SyntaxFactory.Token(
                                    SyntaxFactory.TriviaList(),
                                    SyntaxKind.EndOfDirectiveToken,
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.CarriageReturnLineFeed)))),
                        SyntaxFactory.CarriageReturnLineFeed,
                        SyntaxFactory.Trivia(
                            SyntaxFactory.RegionDirectiveTrivia(
                                true)
                            .WithRegionKeyword(
                                SyntaxFactory.Token(
                                    SyntaxFactory.TriviaList(),
                                    SyntaxKind.RegionKeyword,
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.Space)))
                            .WithEndOfDirectiveToken(
                                SyntaxFactory.Token(
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.PreprocessingMessage("Models")),
                                    SyntaxKind.EndOfDirectiveToken,
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.CarriageReturnLineFeed))))}),
                SyntaxKind.NamespaceKeyword,
                SyntaxFactory.TriviaList(
                    SyntaxFactory.Space)))
        .WithOpenBraceToken(
            SyntaxFactory.Token(
                SyntaxFactory.TriviaList(),
                SyntaxKind.OpenBraceToken,
                SyntaxFactory.TriviaList(
                    SyntaxFactory.CarriageReturnLineFeed)))
        .WithMembers(
            SyntaxFactory.SingletonList<MemberDeclarationSyntax>(
                SyntaxFactory.ClassDeclaration(
                    SyntaxFactory.Identifier(
                        SyntaxFactory.TriviaList(),
                        "AccessPolicy",
                        SyntaxFactory.TriviaList(
                            SyntaxFactory.CarriageReturnLineFeed)))
                .WithModifiers(
                    SyntaxFactory.TokenList(
                        new[]{
                            SyntaxFactory.Token(
                                SyntaxFactory.TriviaList(
                                    new []{
                                        SyntaxFactory.Whitespace("    "),
                                        SyntaxFactory.Trivia(
                                            SyntaxFactory.DocumentationCommentTrivia(
                                                SyntaxKind.SingleLineDocumentationCommentTrivia,
                                                SyntaxFactory.List<XmlNodeSyntax>(
                                                    new XmlNodeSyntax[]{
                                                        SyntaxFactory.XmlText()
                                                        .WithTextTokens(
                                                            SyntaxFactory.TokenList(
                                                                SyntaxFactory.XmlTextLiteral(
                                                                    SyntaxFactory.TriviaList(
                                                                        SyntaxFactory.DocumentationCommentExterior("///")),
                                                                    " ",
                                                                    " ",
                                                                    SyntaxFactory.TriviaList()))),
                                                        SyntaxFactory.XmlExampleElement(
                                                            SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                                                SyntaxFactory.XmlText()
                                                                .WithTextTokens(
                                                                    SyntaxFactory.TokenList(
                                                                        new []{
                                                                            SyntaxFactory.XmlTextNewLine(
                                                                                SyntaxFactory.TriviaList(),
                                                                                Environment.NewLine,
                                                                                Environment.NewLine,
                                                                                SyntaxFactory.TriviaList()),
                                                                            SyntaxFactory.XmlTextLiteral(
                                                                                SyntaxFactory.TriviaList(
                                                                                    SyntaxFactory.DocumentationCommentExterior("    ///")),
                                                                                " An Access policy",
                                                                                " An Access policy",
                                                                                SyntaxFactory.TriviaList()),
                                                                            SyntaxFactory.XmlTextNewLine(
                                                                                SyntaxFactory.TriviaList(),
                                                                                Environment.NewLine,
                                                                                Environment.NewLine,
                                                                                SyntaxFactory.TriviaList()),
                                                                            SyntaxFactory.XmlTextLiteral(
                                                                                SyntaxFactory.TriviaList(
                                                                                    SyntaxFactory.DocumentationCommentExterior("    ///")),
                                                                                " ",
                                                                                " ",
                                                                                SyntaxFactory.TriviaList())}))))
                                                        .WithStartTag(
                                                            SyntaxFactory.XmlElementStartTag(
                                                                SyntaxFactory.XmlName(
                                                                    SyntaxFactory.Identifier("summary"))))
                                                        .WithEndTag(
                                                            SyntaxFactory.XmlElementEndTag(
                                                                SyntaxFactory.XmlName(
                                                                    SyntaxFactory.Identifier("summary")))),
                                                        SyntaxFactory.XmlText()
                                                        .WithTextTokens(
                                                            SyntaxFactory.TokenList(
                                                                SyntaxFactory.XmlTextNewLine(
                                                                    SyntaxFactory.TriviaList(),
                                                                    Environment.NewLine,
                                                                    Environment.NewLine,
                                                                    SyntaxFactory.TriviaList())))}))),
                                        SyntaxFactory.Whitespace("    ")}),
                                SyntaxKind.PublicKeyword,
                                SyntaxFactory.TriviaList(
                                    SyntaxFactory.Space)),
                            SyntaxFactory.Token(
                                SyntaxFactory.TriviaList(),
                                SyntaxKind.PartialKeyword,
                                SyntaxFactory.TriviaList(
                                    SyntaxFactory.Space))}))
                .WithKeyword(
                    SyntaxFactory.Token(
                        SyntaxFactory.TriviaList(),
                        SyntaxKind.ClassKeyword,
                        SyntaxFactory.TriviaList(
                            SyntaxFactory.Space)))
                .WithOpenBraceToken(
                    SyntaxFactory.Token(
                        SyntaxFactory.TriviaList(
                            SyntaxFactory.Whitespace("    ")),
                        SyntaxKind.OpenBraceToken,
                        SyntaxFactory.TriviaList(
                            SyntaxFactory.CarriageReturnLineFeed)))
                .WithMembers(
                    SyntaxFactory.List<MemberDeclarationSyntax>(
                        new MemberDeclarationSyntax[]{
                            SyntaxFactory.PropertyDeclaration(
                                SyntaxFactory.QualifiedName(
                                    SyntaxFactory.IdentifierName("System"),
                                    SyntaxFactory.IdentifierName(
                                        SyntaxFactory.Identifier(
                                            SyntaxFactory.TriviaList(),
                                            "DateTimeOffset",
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.Space)))),
                                SyntaxFactory.Identifier(
                                    SyntaxFactory.TriviaList(),
                                    "Start",
                                    SyntaxFactory.TriviaList(
                                        SyntaxFactory.Space)))
                            .WithModifiers(
                                SyntaxFactory.TokenList(
                                    SyntaxFactory.Token(
                                        SyntaxFactory.TriviaList(
                                            new []{
                                                SyntaxFactory.Whitespace("        "),
                                                SyntaxFactory.Trivia(
                                                    SyntaxFactory.DocumentationCommentTrivia(
                                                        SyntaxKind.SingleLineDocumentationCommentTrivia,
                                                        SyntaxFactory.List<XmlNodeSyntax>(
                                                            new XmlNodeSyntax[]{
                                                                SyntaxFactory.XmlText()
                                                                .WithTextTokens(
                                                                    SyntaxFactory.TokenList(
                                                                        SyntaxFactory.XmlTextLiteral(
                                                                            SyntaxFactory.TriviaList(
                                                                                SyntaxFactory.DocumentationCommentExterior("///")),
                                                                            " ",
                                                                            " ",
                                                                            SyntaxFactory.TriviaList()))),
                                                                SyntaxFactory.XmlExampleElement(
                                                                    SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                                                        SyntaxFactory.XmlText()
                                                                        .WithTextTokens(
                                                                            SyntaxFactory.TokenList(
                                                                                new []{
                                                                                    SyntaxFactory.XmlTextNewLine(
                                                                                        SyntaxFactory.TriviaList(),
                                                                                        Environment.NewLine,
                                                                                        Environment.NewLine,
                                                                                        SyntaxFactory.TriviaList()),
                                                                                    SyntaxFactory.XmlTextLiteral(
                                                                                        SyntaxFactory.TriviaList(
                                                                                            SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                                        " the date-time the policy is active",
                                                                                        " the date-time the policy is active",
                                                                                        SyntaxFactory.TriviaList()),
                                                                                    SyntaxFactory.XmlTextNewLine(
                                                                                        SyntaxFactory.TriviaList(),
                                                                                        Environment.NewLine,
                                                                                        Environment.NewLine,
                                                                                        SyntaxFactory.TriviaList()),
                                                                                    SyntaxFactory.XmlTextLiteral(
                                                                                        SyntaxFactory.TriviaList(
                                                                                            SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                                        " ",
                                                                                        " ",
                                                                                        SyntaxFactory.TriviaList())}))))
                                                                .WithStartTag(
                                                                    SyntaxFactory.XmlElementStartTag(
                                                                        SyntaxFactory.XmlName(
                                                                            SyntaxFactory.Identifier("summary"))))
                                                                .WithEndTag(
                                                                    SyntaxFactory.XmlElementEndTag(
                                                                        SyntaxFactory.XmlName(
                                                                            SyntaxFactory.Identifier("summary")))),
                                                                SyntaxFactory.XmlText()
                                                                .WithTextTokens(
                                                                    SyntaxFactory.TokenList(
                                                                        SyntaxFactory.XmlTextNewLine(
                                                                            SyntaxFactory.TriviaList(),
                                                                            Environment.NewLine,
                                                                            Environment.NewLine,
                                                                            SyntaxFactory.TriviaList())))}))),
                                                SyntaxFactory.Whitespace("        ")}),
                                        SyntaxKind.PublicKeyword,
                                        SyntaxFactory.TriviaList(
                                            SyntaxFactory.Space))))
                            .WithAccessorList(
                                SyntaxFactory.AccessorList(
                                    SyntaxFactory.List<AccessorDeclarationSyntax>(
                                        new AccessorDeclarationSyntax[]{
                                            SyntaxFactory.AccessorDeclaration(
                                                SyntaxKind.GetAccessorDeclaration)
                                            .WithSemicolonToken(
                                                SyntaxFactory.Token(
                                                    SyntaxFactory.TriviaList(),
                                                    SyntaxKind.SemicolonToken,
                                                    SyntaxFactory.TriviaList(
                                                        SyntaxFactory.Space))),
                                            SyntaxFactory.AccessorDeclaration(
                                                SyntaxKind.SetAccessorDeclaration)
                                            .WithSemicolonToken(
                                                SyntaxFactory.Token(
                                                    SyntaxFactory.TriviaList(),
                                                    SyntaxKind.SemicolonToken,
                                                    SyntaxFactory.TriviaList(
                                                        SyntaxFactory.Space)))}))
                                .WithOpenBraceToken(
                                    SyntaxFactory.Token(
                                        SyntaxFactory.TriviaList(),
                                        SyntaxKind.OpenBraceToken,
                                        SyntaxFactory.TriviaList(
                                            SyntaxFactory.Space)))
                                .WithCloseBraceToken(
                                    SyntaxFactory.Token(
                                        SyntaxFactory.TriviaList(),
                                        SyntaxKind.CloseBraceToken,
                                        SyntaxFactory.TriviaList(
                                            SyntaxFactory.CarriageReturnLineFeed)))),
                            SyntaxFactory.MethodDeclaration(
                                SyntaxFactory.QualifiedName(
                                    SyntaxFactory.QualifiedName(
                                        SyntaxFactory.QualifiedName(
                                            SyntaxFactory.IdentifierName("System"),
                                            SyntaxFactory.IdentifierName("Xml")),
                                        SyntaxFactory.IdentifierName("Linq")),
                                    SyntaxFactory.IdentifierName(
                                        SyntaxFactory.Identifier(
                                            SyntaxFactory.TriviaList(),
                                            "XElement",
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.Space)))),
                                SyntaxFactory.Identifier("ToXml"))
                            .WithModifiers(
                                SyntaxFactory.TokenList(
                                    new []{
                                        SyntaxFactory.Token(
                                            SyntaxFactory.TriviaList(
                                                new []{
                                                    SyntaxFactory.CarriageReturnLineFeed,
                                                    SyntaxFactory.Whitespace("        "),
                                                    SyntaxFactory.Trivia(
                                                        SyntaxFactory.DocumentationCommentTrivia(
                                                            SyntaxKind.SingleLineDocumentationCommentTrivia,
                                                            SyntaxFactory.List<XmlNodeSyntax>(
                                                                new XmlNodeSyntax[]{
                                                                    SyntaxFactory.XmlText()
                                                                    .WithTextTokens(
                                                                        SyntaxFactory.TokenList(
                                                                            SyntaxFactory.XmlTextLiteral(
                                                                                SyntaxFactory.TriviaList(
                                                                                    SyntaxFactory.DocumentationCommentExterior("///")),
                                                                                " ",
                                                                                " ",
                                                                                SyntaxFactory.TriviaList()))),
                                                                    SyntaxFactory.XmlExampleElement(
                                                                        SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                                                            SyntaxFactory.XmlText()
                                                                            .WithTextTokens(
                                                                                SyntaxFactory.TokenList(
                                                                                    new []{
                                                                                        SyntaxFactory.XmlTextNewLine(
                                                                                            SyntaxFactory.TriviaList(),
                                                                                            Environment.NewLine,
                                                                                            Environment.NewLine,
                                                                                            SyntaxFactory.TriviaList()),
                                                                                        SyntaxFactory.XmlTextLiteral(
                                                                                            SyntaxFactory.TriviaList(
                                                                                                SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                                            " Serialize a AccessPolicy instance as XML.",
                                                                                            " Serialize a AccessPolicy instance as XML.",
                                                                                            SyntaxFactory.TriviaList()),
                                                                                        SyntaxFactory.XmlTextNewLine(
                                                                                            SyntaxFactory.TriviaList(),
                                                                                            Environment.NewLine,
                                                                                            Environment.NewLine,
                                                                                            SyntaxFactory.TriviaList()),
                                                                                        SyntaxFactory.XmlTextLiteral(
                                                                                            SyntaxFactory.TriviaList(
                                                                                                SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                                            " ",
                                                                                            " ",
                                                                                            SyntaxFactory.TriviaList())}))))
                                                                    .WithStartTag(
                                                                        SyntaxFactory.XmlElementStartTag(
                                                                            SyntaxFactory.XmlName(
                                                                                SyntaxFactory.Identifier("summary"))))
                                                                    .WithEndTag(
                                                                        SyntaxFactory.XmlElementEndTag(
                                                                            SyntaxFactory.XmlName(
                                                                                SyntaxFactory.Identifier("summary")))),
                                                                    SyntaxFactory.XmlText()
                                                                    .WithTextTokens(
                                                                        SyntaxFactory.TokenList(
                                                                            new []{
                                                                                SyntaxFactory.XmlTextNewLine(
                                                                                    SyntaxFactory.TriviaList(),
                                                                                    Environment.NewLine,
                                                                                    Environment.NewLine,
                                                                                    SyntaxFactory.TriviaList()),
                                                                                SyntaxFactory.XmlTextLiteral(
                                                                                    SyntaxFactory.TriviaList(
                                                                                        SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                                    " ",
                                                                                    " ",
                                                                                    SyntaxFactory.TriviaList())})),
                                                                    SyntaxFactory.XmlExampleElement(
                                                                        SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                                                            SyntaxFactory.XmlText()
                                                                            .WithTextTokens(
                                                                                SyntaxFactory.TokenList(
                                                                                    SyntaxFactory.XmlTextLiteral(
                                                                                        SyntaxFactory.TriviaList(),
                                                                                        "The AccessPolicy instance to serialize.",
                                                                                        "The AccessPolicy instance to serialize.",
                                                                                        SyntaxFactory.TriviaList())))))
                                                                    .WithStartTag(
                                                                        SyntaxFactory.XmlElementStartTag(
                                                                            SyntaxFactory.XmlName(
                                                                                SyntaxFactory.Identifier("param")))
                                                                        .WithAttributes(
                                                                            SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                                                SyntaxFactory.XmlNameAttribute(
                                                                                    SyntaxFactory.XmlName(
                                                                                        SyntaxFactory.Identifier(
                                                                                            SyntaxFactory.TriviaList(
                                                                                                SyntaxFactory.Space),
                                                                                            "name",
                                                                                            SyntaxFactory.TriviaList())),
                                                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                                                    SyntaxFactory.IdentifierName("value"),
                                                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken)))))
                                                                    .WithEndTag(
                                                                        SyntaxFactory.XmlElementEndTag(
                                                                            SyntaxFactory.XmlName(
                                                                                SyntaxFactory.Identifier("param")))),
                                                                    SyntaxFactory.XmlText()
                                                                    .WithTextTokens(
                                                                        SyntaxFactory.TokenList(
                                                                            new []{
                                                                                SyntaxFactory.XmlTextNewLine(
                                                                                    SyntaxFactory.TriviaList(),
                                                                                    Environment.NewLine,
                                                                                    Environment.NewLine,
                                                                                    SyntaxFactory.TriviaList()),
                                                                                SyntaxFactory.XmlTextLiteral(
                                                                                    SyntaxFactory.TriviaList(
                                                                                        SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                                    " ",
                                                                                    " ",
                                                                                    SyntaxFactory.TriviaList())})),
                                                                    SyntaxFactory.XmlExampleElement(
                                                                        SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                                                            SyntaxFactory.XmlText()
                                                                            .WithTextTokens(
                                                                                SyntaxFactory.TokenList(
                                                                                    SyntaxFactory.XmlTextLiteral(
                                                                                        SyntaxFactory.TriviaList(),
                                                                                        "An optional name to use for the root element instead of \"AccessPolicy\".",
                                                                                        "An optional name to use for the root element instead of \"AccessPolicy\".",
                                                                                        SyntaxFactory.TriviaList())))))
                                                                    .WithStartTag(
                                                                        SyntaxFactory.XmlElementStartTag(
                                                                            SyntaxFactory.XmlName(
                                                                                SyntaxFactory.Identifier("param")))
                                                                        .WithAttributes(
                                                                            SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                                                SyntaxFactory.XmlNameAttribute(
                                                                                    SyntaxFactory.XmlName(
                                                                                        SyntaxFactory.Identifier(
                                                                                            SyntaxFactory.TriviaList(
                                                                                                SyntaxFactory.Space),
                                                                                            "name",
                                                                                            SyntaxFactory.TriviaList())),
                                                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                                                    SyntaxFactory.IdentifierName("name"),
                                                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken)))))
                                                                    .WithEndTag(
                                                                        SyntaxFactory.XmlElementEndTag(
                                                                            SyntaxFactory.XmlName(
                                                                                SyntaxFactory.Identifier("param")))),
                                                                    SyntaxFactory.XmlText()
                                                                    .WithTextTokens(
                                                                        SyntaxFactory.TokenList(
                                                                            new []{
                                                                                SyntaxFactory.XmlTextNewLine(
                                                                                    SyntaxFactory.TriviaList(),
                                                                                    Environment.NewLine,
                                                                                    Environment.NewLine,
                                                                                    SyntaxFactory.TriviaList()),
                                                                                SyntaxFactory.XmlTextLiteral(
                                                                                    SyntaxFactory.TriviaList(
                                                                                        SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                                    " ",
                                                                                    " ",
                                                                                    SyntaxFactory.TriviaList())})),
                                                                    SyntaxFactory.XmlExampleElement(
                                                                        SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                                                            SyntaxFactory.XmlText()
                                                                            .WithTextTokens(
                                                                                SyntaxFactory.TokenList(
                                                                                    SyntaxFactory.XmlTextLiteral(
                                                                                        SyntaxFactory.TriviaList(),
                                                                                        "An optional namespace to use for the root element instead of \"\".",
                                                                                        "An optional namespace to use for the root element instead of \"\".",
                                                                                        SyntaxFactory.TriviaList())))))
                                                                    .WithStartTag(
                                                                        SyntaxFactory.XmlElementStartTag(
                                                                            SyntaxFactory.XmlName(
                                                                                SyntaxFactory.Identifier("param")))
                                                                        .WithAttributes(
                                                                            SyntaxFactory.SingletonList<XmlAttributeSyntax>(
                                                                                SyntaxFactory.XmlNameAttribute(
                                                                                    SyntaxFactory.XmlName(
                                                                                        SyntaxFactory.Identifier(
                                                                                            SyntaxFactory.TriviaList(
                                                                                                SyntaxFactory.Space),
                                                                                            "name",
                                                                                            SyntaxFactory.TriviaList())),
                                                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken),
                                                                                    SyntaxFactory.IdentifierName("ns"),
                                                                                    SyntaxFactory.Token(SyntaxKind.DoubleQuoteToken)))))
                                                                    .WithEndTag(
                                                                        SyntaxFactory.XmlElementEndTag(
                                                                            SyntaxFactory.XmlName(
                                                                                SyntaxFactory.Identifier("param")))),
                                                                    SyntaxFactory.XmlText()
                                                                    .WithTextTokens(
                                                                        SyntaxFactory.TokenList(
                                                                            new []{
                                                                                SyntaxFactory.XmlTextNewLine(
                                                                                    SyntaxFactory.TriviaList(),
                                                                                    Environment.NewLine,
                                                                                    Environment.NewLine,
                                                                                    SyntaxFactory.TriviaList()),
                                                                                SyntaxFactory.XmlTextLiteral(
                                                                                    SyntaxFactory.TriviaList(
                                                                                        SyntaxFactory.DocumentationCommentExterior("        ///")),
                                                                                    " ",
                                                                                    " ",
                                                                                    SyntaxFactory.TriviaList())})),
                                                                    SyntaxFactory.XmlExampleElement(
                                                                        SyntaxFactory.SingletonList<XmlNodeSyntax>(
                                                                            SyntaxFactory.XmlText()
                                                                            .WithTextTokens(
                                                                                SyntaxFactory.TokenList(
                                                                                    SyntaxFactory.XmlTextLiteral(
                                                                                        SyntaxFactory.TriviaList(),
                                                                                        "The serialized XML element.",
                                                                                        "The serialized XML element.",
                                                                                        SyntaxFactory.TriviaList())))))
                                                                    .WithStartTag(
                                                                        SyntaxFactory.XmlElementStartTag(
                                                                            SyntaxFactory.XmlName(
                                                                                SyntaxFactory.Identifier("returns"))))
                                                                    .WithEndTag(
                                                                        SyntaxFactory.XmlElementEndTag(
                                                                            SyntaxFactory.XmlName(
                                                                                SyntaxFactory.Identifier("returns")))),
                                                                    SyntaxFactory.XmlText()
                                                                    .WithTextTokens(
                                                                        SyntaxFactory.TokenList(
                                                                            SyntaxFactory.XmlTextNewLine(
                                                                                SyntaxFactory.TriviaList(),
                                                                                Environment.NewLine,
                                                                                Environment.NewLine,
                                                                                SyntaxFactory.TriviaList())))}))),
                                                    SyntaxFactory.Whitespace("        ")}),
                                            SyntaxKind.InternalKeyword,
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.Space)),
                                        SyntaxFactory.Token(
                                            SyntaxFactory.TriviaList(),
                                            SyntaxKind.StaticKeyword,
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.Space))}))
                            .WithParameterList(
                                SyntaxFactory.ParameterList(
                                    SyntaxFactory.SeparatedList<ParameterSyntax>(
                                        new SyntaxNodeOrToken[]{
                                            SyntaxFactory.Parameter(
                                                SyntaxFactory.Identifier("value"))
                                            .WithType(
                                                SyntaxFactory.QualifiedName(
                                                    SyntaxFactory.QualifiedName(
                                                        SyntaxFactory.QualifiedName(
                                                            SyntaxFactory.QualifiedName(
                                                                SyntaxFactory.IdentifierName("Azure"),
                                                                SyntaxFactory.IdentifierName("Storage")),
                                                            SyntaxFactory.IdentifierName("Blobs")),
                                                        SyntaxFactory.IdentifierName("Models")),
                                                    SyntaxFactory.IdentifierName(
                                                        SyntaxFactory.Identifier(
                                                            SyntaxFactory.TriviaList(),
                                                            "AccessPolicy",
                                                            SyntaxFactory.TriviaList(
                                                                SyntaxFactory.Space))))),
                                            SyntaxFactory.Token(
                                                SyntaxFactory.TriviaList(),
                                                SyntaxKind.CommaToken,
                                                SyntaxFactory.TriviaList(
                                                    SyntaxFactory.Space)),
                                            SyntaxFactory.Parameter(
                                                SyntaxFactory.Identifier(
                                                    SyntaxFactory.TriviaList(),
                                                    "name",
                                                    SyntaxFactory.TriviaList(
                                                        SyntaxFactory.Space)))
                                            .WithType(
                                                SyntaxFactory.PredefinedType(
                                                    SyntaxFactory.Token(
                                                        SyntaxFactory.TriviaList(),
                                                        SyntaxKind.StringKeyword,
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.Space))))
                                            .WithDefault(
                                                SyntaxFactory.EqualsValueClause(
                                                    SyntaxFactory.LiteralExpression(
                                                        SyntaxKind.StringLiteralExpression,
                                                        SyntaxFactory.Literal("AccessPolicy")))
                                                .WithEqualsToken(
                                                    SyntaxFactory.Token(
                                                        SyntaxFactory.TriviaList(),
                                                        SyntaxKind.EqualsToken,
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.Space)))),
                                            SyntaxFactory.Token(
                                                SyntaxFactory.TriviaList(),
                                                SyntaxKind.CommaToken,
                                                SyntaxFactory.TriviaList(
                                                    SyntaxFactory.Space)),
                                            SyntaxFactory.Parameter(
                                                SyntaxFactory.Identifier(
                                                    SyntaxFactory.TriviaList(),
                                                    "ns",
                                                    SyntaxFactory.TriviaList(
                                                        SyntaxFactory.Space)))
                                            .WithType(
                                                SyntaxFactory.PredefinedType(
                                                    SyntaxFactory.Token(
                                                        SyntaxFactory.TriviaList(),
                                                        SyntaxKind.StringKeyword,
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.Space))))
                                            .WithDefault(
                                                SyntaxFactory.EqualsValueClause(
                                                    SyntaxFactory.LiteralExpression(
                                                        SyntaxKind.StringLiteralExpression,
                                                        SyntaxFactory.Literal("")))
                                                .WithEqualsToken(
                                                    SyntaxFactory.Token(
                                                        SyntaxFactory.TriviaList(),
                                                        SyntaxKind.EqualsToken,
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.Space))))}))
                                .WithCloseParenToken(
                                    SyntaxFactory.Token(
                                        SyntaxFactory.TriviaList(),
                                        SyntaxKind.CloseParenToken,
                                        SyntaxFactory.TriviaList(
                                            SyntaxFactory.CarriageReturnLineFeed))))
                            .WithBody(
                                SyntaxFactory.Block(
                                    SyntaxFactory.ExpressionStatement(
                                        SyntaxFactory.InvocationExpression(
                                            SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    SyntaxFactory.MemberAccessExpression(
                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                        SyntaxFactory.IdentifierName(
                                                            SyntaxFactory.Identifier(
                                                                SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.Whitespace("            ")),
                                                                "System",
                                                                SyntaxFactory.TriviaList())),
                                                        SyntaxFactory.IdentifierName("Diagnostics")),
                                                    SyntaxFactory.IdentifierName("Debug")),
                                                SyntaxFactory.IdentifierName("Assert")))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList(
                                                SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                    SyntaxFactory.Argument(
                                                        SyntaxFactory.BinaryExpression(
                                                            SyntaxKind.NotEqualsExpression,
                                                            SyntaxFactory.IdentifierName(
                                                                SyntaxFactory.Identifier(
                                                                    SyntaxFactory.TriviaList(),
                                                                    "value",
                                                                    SyntaxFactory.TriviaList(
                                                                        SyntaxFactory.Space))),
                                                            SyntaxFactory.LiteralExpression(
                                                                SyntaxKind.NullLiteralExpression))
                                                        .WithOperatorToken(
                                                            SyntaxFactory.Token(
                                                                SyntaxFactory.TriviaList(),
                                                                SyntaxKind.ExclamationEqualsToken,
                                                                SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.Space))))))))
                                    .WithSemicolonToken(
                                        SyntaxFactory.Token(
                                            SyntaxFactory.TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.CarriageReturnLineFeed))),
                                    SyntaxFactory.LocalDeclarationStatement(
                                        SyntaxFactory.VariableDeclaration(
                                            SyntaxFactory.QualifiedName(
                                                SyntaxFactory.QualifiedName(
                                                    SyntaxFactory.QualifiedName(
                                                        SyntaxFactory.IdentifierName(
                                                            SyntaxFactory.Identifier(
                                                                SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.Whitespace("            ")),
                                                                "System",
                                                                SyntaxFactory.TriviaList())),
                                                        SyntaxFactory.IdentifierName("Xml")),
                                                    SyntaxFactory.IdentifierName("Linq")),
                                                SyntaxFactory.IdentifierName(
                                                    SyntaxFactory.Identifier(
                                                        SyntaxFactory.TriviaList(),
                                                        "XElement",
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.Space)))))
                                        .WithVariables(
                                            SyntaxFactory.SingletonSeparatedList<VariableDeclaratorSyntax>(
                                                SyntaxFactory.VariableDeclarator(
                                                    SyntaxFactory.Identifier(
                                                        SyntaxFactory.TriviaList(),
                                                        "_element",
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.Space)))
                                                .WithInitializer(
                                                    SyntaxFactory.EqualsValueClause(
                                                        SyntaxFactory.ObjectCreationExpression(
                                                            SyntaxFactory.QualifiedName(
                                                                SyntaxFactory.QualifiedName(
                                                                    SyntaxFactory.QualifiedName(
                                                                        SyntaxFactory.IdentifierName("System"),
                                                                        SyntaxFactory.IdentifierName("Xml")),
                                                                    SyntaxFactory.IdentifierName("Linq")),
                                                                SyntaxFactory.IdentifierName("XElement")))
                                                        .WithNewKeyword(
                                                            SyntaxFactory.Token(
                                                                SyntaxFactory.TriviaList(),
                                                                SyntaxKind.NewKeyword,
                                                                SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.Space)))
                                                        .WithArgumentList(
                                                            SyntaxFactory.ArgumentList(
                                                                SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                                    SyntaxFactory.Argument(
                                                                        SyntaxFactory.InvocationExpression(
                                                                            SyntaxFactory.MemberAccessExpression(
                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                SyntaxFactory.MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    SyntaxFactory.MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        SyntaxFactory.MemberAccessExpression(
                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                            SyntaxFactory.IdentifierName("System"),
                                                                                            SyntaxFactory.IdentifierName("Xml")),
                                                                                        SyntaxFactory.IdentifierName("Linq")),
                                                                                    SyntaxFactory.IdentifierName("XName")),
                                                                                SyntaxFactory.IdentifierName("Get")))
                                                                        .WithArgumentList(
                                                                            SyntaxFactory.ArgumentList(
                                                                                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                                    new SyntaxNodeOrToken[]{
                                                                                        SyntaxFactory.Argument(
                                                                                            SyntaxFactory.IdentifierName("name")),
                                                                                        SyntaxFactory.Token(
                                                                                            SyntaxFactory.TriviaList(),
                                                                                            SyntaxKind.CommaToken,
                                                                                            SyntaxFactory.TriviaList(
                                                                                                SyntaxFactory.Space)),
                                                                                        SyntaxFactory.Argument(
                                                                                            SyntaxFactory.IdentifierName("ns"))}))))))))
                                                    .WithEqualsToken(
                                                        SyntaxFactory.Token(
                                                            SyntaxFactory.TriviaList(),
                                                            SyntaxKind.EqualsToken,
                                                            SyntaxFactory.TriviaList(
                                                                SyntaxFactory.Space)))))))
                                    .WithSemicolonToken(
                                        SyntaxFactory.Token(
                                            SyntaxFactory.TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.CarriageReturnLineFeed))),
                                    SyntaxFactory.ExpressionStatement(
                                        SyntaxFactory.InvocationExpression(
                                            SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.IdentifierName(
                                                    SyntaxFactory.Identifier(
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.Whitespace("            ")),
                                                        "_element",
                                                        SyntaxFactory.TriviaList())),
                                                SyntaxFactory.IdentifierName("Add")))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList(
                                                SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                    SyntaxFactory.Argument(
                                                        SyntaxFactory.ObjectCreationExpression(
                                                            SyntaxFactory.QualifiedName(
                                                                SyntaxFactory.QualifiedName(
                                                                    SyntaxFactory.QualifiedName(
                                                                        SyntaxFactory.IdentifierName("System"),
                                                                        SyntaxFactory.IdentifierName("Xml")),
                                                                    SyntaxFactory.IdentifierName("Linq")),
                                                                SyntaxFactory.IdentifierName("XElement")))
                                                        .WithNewKeyword(
                                                            SyntaxFactory.Token(
                                                                SyntaxFactory.TriviaList(),
                                                                SyntaxKind.NewKeyword,
                                                                SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.Space)))
                                                        .WithArgumentList(
                                                            SyntaxFactory.ArgumentList(
                                                                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                    new SyntaxNodeOrToken[]{
                                                                        SyntaxFactory.Argument(
                                                                            SyntaxFactory.InvocationExpression(
                                                                                SyntaxFactory.MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    SyntaxFactory.MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        SyntaxFactory.MemberAccessExpression(
                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                            SyntaxFactory.MemberAccessExpression(
                                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                                SyntaxFactory.IdentifierName(
                                                                                                    SyntaxFactory.Identifier(
                                                                                                        SyntaxFactory.TriviaList(
                                                                                                            SyntaxFactory.Whitespace("                ")),
                                                                                                        "System",
                                                                                                        SyntaxFactory.TriviaList())),
                                                                                                SyntaxFactory.IdentifierName("Xml")),
                                                                                            SyntaxFactory.IdentifierName("Linq")),
                                                                                        SyntaxFactory.IdentifierName("XName")),
                                                                                    SyntaxFactory.IdentifierName("Get")))
                                                                            .WithArgumentList(
                                                                                SyntaxFactory.ArgumentList(
                                                                                    SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                                        new SyntaxNodeOrToken[]{
                                                                                            SyntaxFactory.Argument(
                                                                                                SyntaxFactory.LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    SyntaxFactory.Literal("Start"))),
                                                                                            SyntaxFactory.Token(
                                                                                                SyntaxFactory.TriviaList(),
                                                                                                SyntaxKind.CommaToken,
                                                                                                SyntaxFactory.TriviaList(
                                                                                                    SyntaxFactory.Space)),
                                                                                            SyntaxFactory.Argument(
                                                                                                SyntaxFactory.LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    SyntaxFactory.Literal("")))})))),
                                                                        SyntaxFactory.Token(
                                                                            SyntaxFactory.TriviaList(),
                                                                            SyntaxKind.CommaToken,
                                                                            SyntaxFactory.TriviaList(
                                                                                SyntaxFactory.CarriageReturnLineFeed)),
                                                                        SyntaxFactory.Argument(
                                                                            SyntaxFactory.InvocationExpression(
                                                                                SyntaxFactory.MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    SyntaxFactory.MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        SyntaxFactory.IdentifierName(
                                                                                            SyntaxFactory.Identifier(
                                                                                                SyntaxFactory.TriviaList(
                                                                                                    SyntaxFactory.Whitespace("                ")),
                                                                                                "value",
                                                                                                SyntaxFactory.TriviaList())),
                                                                                        SyntaxFactory.IdentifierName("Start")),
                                                                                    SyntaxFactory.IdentifierName("ToString")))
                                                                            .WithArgumentList(
                                                                                SyntaxFactory.ArgumentList(
                                                                                    SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                                        new SyntaxNodeOrToken[]{
                                                                                            SyntaxFactory.Argument(
                                                                                                SyntaxFactory.LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    SyntaxFactory.Literal("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ"))),
                                                                                            SyntaxFactory.Token(
                                                                                                SyntaxFactory.TriviaList(),
                                                                                                SyntaxKind.CommaToken,
                                                                                                SyntaxFactory.TriviaList(
                                                                                                    SyntaxFactory.Space)),
                                                                                            SyntaxFactory.Argument(
                                                                                                SyntaxFactory.MemberAccessExpression(
                                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                                    SyntaxFactory.MemberAccessExpression(
                                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                                        SyntaxFactory.MemberAccessExpression(
                                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                                            SyntaxFactory.IdentifierName("System"),
                                                                                                            SyntaxFactory.IdentifierName("Globalization")),
                                                                                                        SyntaxFactory.IdentifierName("CultureInfo")),
                                                                                                    SyntaxFactory.IdentifierName("InvariantCulture")))}))))}))
                                                            .WithOpenParenToken(
                                                                SyntaxFactory.Token(
                                                                    SyntaxFactory.TriviaList(),
                                                                    SyntaxKind.OpenParenToken,
                                                                    SyntaxFactory.TriviaList(
                                                                        SyntaxFactory.CarriageReturnLineFeed)))))))))
                                    .WithSemicolonToken(
                                        SyntaxFactory.Token(
                                            SyntaxFactory.TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.CarriageReturnLineFeed))),
                                    SyntaxFactory.ExpressionStatement(
                                        SyntaxFactory.InvocationExpression(
                                            SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.IdentifierName(
                                                    SyntaxFactory.Identifier(
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.Whitespace("            ")),
                                                        "_element",
                                                        SyntaxFactory.TriviaList())),
                                                SyntaxFactory.IdentifierName("Add")))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList(
                                                SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                    SyntaxFactory.Argument(
                                                        SyntaxFactory.ObjectCreationExpression(
                                                            SyntaxFactory.QualifiedName(
                                                                SyntaxFactory.QualifiedName(
                                                                    SyntaxFactory.QualifiedName(
                                                                        SyntaxFactory.IdentifierName("System"),
                                                                        SyntaxFactory.IdentifierName("Xml")),
                                                                    SyntaxFactory.IdentifierName("Linq")),
                                                                SyntaxFactory.IdentifierName("XElement")))
                                                        .WithNewKeyword(
                                                            SyntaxFactory.Token(
                                                                SyntaxFactory.TriviaList(),
                                                                SyntaxKind.NewKeyword,
                                                                SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.Space)))
                                                        .WithArgumentList(
                                                            SyntaxFactory.ArgumentList(
                                                                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                    new SyntaxNodeOrToken[]{
                                                                        SyntaxFactory.Argument(
                                                                            SyntaxFactory.InvocationExpression(
                                                                                SyntaxFactory.MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    SyntaxFactory.MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        SyntaxFactory.MemberAccessExpression(
                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                            SyntaxFactory.MemberAccessExpression(
                                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                                SyntaxFactory.IdentifierName(
                                                                                                    SyntaxFactory.Identifier(
                                                                                                        SyntaxFactory.TriviaList(
                                                                                                            SyntaxFactory.Whitespace("                ")),
                                                                                                        "System",
                                                                                                        SyntaxFactory.TriviaList())),
                                                                                                SyntaxFactory.IdentifierName("Xml")),
                                                                                            SyntaxFactory.IdentifierName("Linq")),
                                                                                        SyntaxFactory.IdentifierName("XName")),
                                                                                    SyntaxFactory.IdentifierName("Get")))
                                                                            .WithArgumentList(
                                                                                SyntaxFactory.ArgumentList(
                                                                                    SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                                        new SyntaxNodeOrToken[]{
                                                                                            SyntaxFactory.Argument(
                                                                                                SyntaxFactory.LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    SyntaxFactory.Literal("Expiry"))),
                                                                                            SyntaxFactory.Token(
                                                                                                SyntaxFactory.TriviaList(),
                                                                                                SyntaxKind.CommaToken,
                                                                                                SyntaxFactory.TriviaList(
                                                                                                    SyntaxFactory.Space)),
                                                                                            SyntaxFactory.Argument(
                                                                                                SyntaxFactory.LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    SyntaxFactory.Literal("")))})))),
                                                                        SyntaxFactory.Token(
                                                                            SyntaxFactory.TriviaList(),
                                                                            SyntaxKind.CommaToken,
                                                                            SyntaxFactory.TriviaList(
                                                                                SyntaxFactory.CarriageReturnLineFeed)),
                                                                        SyntaxFactory.Argument(
                                                                            SyntaxFactory.InvocationExpression(
                                                                                SyntaxFactory.MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    SyntaxFactory.MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        SyntaxFactory.IdentifierName(
                                                                                            SyntaxFactory.Identifier(
                                                                                                SyntaxFactory.TriviaList(
                                                                                                    SyntaxFactory.Whitespace("                ")),
                                                                                                "value",
                                                                                                SyntaxFactory.TriviaList())),
                                                                                        SyntaxFactory.IdentifierName("Expiry")),
                                                                                    SyntaxFactory.IdentifierName("ToString")))
                                                                            .WithArgumentList(
                                                                                SyntaxFactory.ArgumentList(
                                                                                    SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                                        new SyntaxNodeOrToken[]{
                                                                                            SyntaxFactory.Argument(
                                                                                                SyntaxFactory.LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    SyntaxFactory.Literal("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ"))),
                                                                                            SyntaxFactory.Token(
                                                                                                SyntaxFactory.TriviaList(),
                                                                                                SyntaxKind.CommaToken,
                                                                                                SyntaxFactory.TriviaList(
                                                                                                    SyntaxFactory.Space)),
                                                                                            SyntaxFactory.Argument(
                                                                                                SyntaxFactory.MemberAccessExpression(
                                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                                    SyntaxFactory.MemberAccessExpression(
                                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                                        SyntaxFactory.MemberAccessExpression(
                                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                                            SyntaxFactory.IdentifierName("System"),
                                                                                                            SyntaxFactory.IdentifierName("Globalization")),
                                                                                                        SyntaxFactory.IdentifierName("CultureInfo")),
                                                                                                    SyntaxFactory.IdentifierName("InvariantCulture")))}))))}))
                                                            .WithOpenParenToken(
                                                                SyntaxFactory.Token(
                                                                    SyntaxFactory.TriviaList(),
                                                                    SyntaxKind.OpenParenToken,
                                                                    SyntaxFactory.TriviaList(
                                                                        SyntaxFactory.CarriageReturnLineFeed)))))))))
                                    .WithSemicolonToken(
                                        SyntaxFactory.Token(
                                            SyntaxFactory.TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.CarriageReturnLineFeed))),
                                    SyntaxFactory.ExpressionStatement(
                                        SyntaxFactory.InvocationExpression(
                                            SyntaxFactory.MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                SyntaxFactory.IdentifierName(
                                                    SyntaxFactory.Identifier(
                                                        SyntaxFactory.TriviaList(
                                                            SyntaxFactory.Whitespace("            ")),
                                                        "_element",
                                                        SyntaxFactory.TriviaList())),
                                                SyntaxFactory.IdentifierName("Add")))
                                        .WithArgumentList(
                                            SyntaxFactory.ArgumentList(
                                                SyntaxFactory.SingletonSeparatedList<ArgumentSyntax>(
                                                    SyntaxFactory.Argument(
                                                        SyntaxFactory.ObjectCreationExpression(
                                                            SyntaxFactory.QualifiedName(
                                                                SyntaxFactory.QualifiedName(
                                                                    SyntaxFactory.QualifiedName(
                                                                        SyntaxFactory.IdentifierName("System"),
                                                                        SyntaxFactory.IdentifierName("Xml")),
                                                                    SyntaxFactory.IdentifierName("Linq")),
                                                                SyntaxFactory.IdentifierName("XElement")))
                                                        .WithNewKeyword(
                                                            SyntaxFactory.Token(
                                                                SyntaxFactory.TriviaList(),
                                                                SyntaxKind.NewKeyword,
                                                                SyntaxFactory.TriviaList(
                                                                    SyntaxFactory.Space)))
                                                        .WithArgumentList(
                                                            SyntaxFactory.ArgumentList(
                                                                SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                    new SyntaxNodeOrToken[]{
                                                                        SyntaxFactory.Argument(
                                                                            SyntaxFactory.InvocationExpression(
                                                                                SyntaxFactory.MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    SyntaxFactory.MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        SyntaxFactory.MemberAccessExpression(
                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                            SyntaxFactory.MemberAccessExpression(
                                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                                SyntaxFactory.IdentifierName(
                                                                                                    SyntaxFactory.Identifier(
                                                                                                        SyntaxFactory.TriviaList(
                                                                                                            SyntaxFactory.Whitespace("                ")),
                                                                                                        "System",
                                                                                                        SyntaxFactory.TriviaList())),
                                                                                                SyntaxFactory.IdentifierName("Xml")),
                                                                                            SyntaxFactory.IdentifierName("Linq")),
                                                                                        SyntaxFactory.IdentifierName("XName")),
                                                                                    SyntaxFactory.IdentifierName("Get")))
                                                                            .WithArgumentList(
                                                                                SyntaxFactory.ArgumentList(
                                                                                    SyntaxFactory.SeparatedList<ArgumentSyntax>(
                                                                                        new SyntaxNodeOrToken[]{
                                                                                            SyntaxFactory.Argument(
                                                                                                SyntaxFactory.LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    SyntaxFactory.Literal("Permission"))),
                                                                                            SyntaxFactory.Token(
                                                                                                SyntaxFactory.TriviaList(),
                                                                                                SyntaxKind.CommaToken,
                                                                                                SyntaxFactory.TriviaList(
                                                                                                    SyntaxFactory.Space)),
                                                                                            SyntaxFactory.Argument(
                                                                                                SyntaxFactory.LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    SyntaxFactory.Literal("")))})))),
                                                                        SyntaxFactory.Token(
                                                                            SyntaxFactory.TriviaList(),
                                                                            SyntaxKind.CommaToken,
                                                                            SyntaxFactory.TriviaList(
                                                                                SyntaxFactory.CarriageReturnLineFeed)),
                                                                        SyntaxFactory.Argument(
                                                                            SyntaxFactory.MemberAccessExpression(
                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                SyntaxFactory.IdentifierName(
                                                                                    SyntaxFactory.Identifier(
                                                                                        SyntaxFactory.TriviaList(
                                                                                            SyntaxFactory.Whitespace("                ")),
                                                                                        "value",
                                                                                        SyntaxFactory.TriviaList())),
                                                                                SyntaxFactory.IdentifierName("Permission")))}))
                                                            .WithOpenParenToken(
                                                                SyntaxFactory.Token(
                                                                    SyntaxFactory.TriviaList(),
                                                                    SyntaxKind.OpenParenToken,
                                                                    SyntaxFactory.TriviaList(
                                                                        SyntaxFactory.CarriageReturnLineFeed)))))))))
                                    .WithSemicolonToken(
                                        SyntaxFactory.Token(
                                            SyntaxFactory.TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.CarriageReturnLineFeed))),
                                    SyntaxFactory.ReturnStatement(
                                        SyntaxFactory.IdentifierName("_element"))
                                    .WithReturnKeyword(
                                        SyntaxFactory.Token(
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.Whitespace("            ")),
                                            SyntaxKind.ReturnKeyword,
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.Space)))
                                    .WithSemicolonToken(
                                        SyntaxFactory.Token(
                                            SyntaxFactory.TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            SyntaxFactory.TriviaList(
                                                SyntaxFactory.CarriageReturnLineFeed))))
                                .WithOpenBraceToken(
                                    SyntaxFactory.Token(
                                        SyntaxFactory.TriviaList(
                                            SyntaxFactory.Whitespace("        ")),
                                        SyntaxKind.OpenBraceToken,
                                        SyntaxFactory.TriviaList(
                                            SyntaxFactory.CarriageReturnLineFeed)))
                                .WithCloseBraceToken(
                                    SyntaxFactory.Token(
                                        SyntaxFactory.TriviaList(
                                            SyntaxFactory.Whitespace("        ")),
                                        SyntaxKind.CloseBraceToken,
                                        SyntaxFactory.TriviaList(
                                            SyntaxFactory.CarriageReturnLineFeed))))}))
                .WithCloseBraceToken(
                    SyntaxFactory.Token(
                        SyntaxFactory.TriviaList(
                            SyntaxFactory.Whitespace("    ")),
                        SyntaxKind.CloseBraceToken,
                        SyntaxFactory.TriviaList(
                            SyntaxFactory.CarriageReturnLineFeed)))))
        .WithCloseBraceToken(
            SyntaxFactory.Token(
                SyntaxFactory.TriviaList(),
                SyntaxKind.CloseBraceToken,
                SyntaxFactory.TriviaList(
                    SyntaxFactory.CarriageReturnLineFeed)))))
.WithEndOfFileToken(
    SyntaxFactory.Token(
        SyntaxFactory.TriviaList(
            SyntaxFactory.Trivia(
                SyntaxFactory.EndRegionDirectiveTrivia(
                    true))),
        SyntaxKind.EndOfFileToken,
        SyntaxFactory.TriviaList()))
            ;

            var workspace = new AdhocWorkspace();
            var formattedCode = Formatter.Format(cu, workspace);
            return formattedCode.ToFullString();
        }

        public static void GenerateQuoter(string csFile)
        {
            Quoter q = new Quoter();
            q.UseDefaultFormatting = false;

            ApiCall c = q.Quote(csFile, NodeKind.CompilationUnit);

            string code = q.Print(c);

            File.WriteAllText("Quoter.txt", code);
        }
    }
}
