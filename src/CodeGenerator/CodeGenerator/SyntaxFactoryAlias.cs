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
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Microsoft.CodeAnalysis.Formatting;

namespace CodeGenerator
{
    class SyntaxFactoryAlias
    {
        public static string Generate()
        {
            var cu = CompilationUnit()
.WithMembers(
    SingletonList<MemberDeclarationSyntax>(
        NamespaceDeclaration(
            QualifiedName(
                QualifiedName(
                    QualifiedName(
                        IdentifierName("Azure"),
                        IdentifierName("Storage")),
                    IdentifierName("Blobs")),
                IdentifierName(
                    Identifier(
                        TriviaList(),
                        "Models",
                        TriviaList(
                            CarriageReturnLineFeed)))))
        .WithNamespaceKeyword(
            Token(
                TriviaList(
                    new[]{
                        Comment("// Copyright (c) Microsoft Corporation. All rights reserved."),
                        CarriageReturnLineFeed,
                        Comment("// Licensed under the MIT License."),
                        CarriageReturnLineFeed,
                        CarriageReturnLineFeed,
                        Trivia(
                            PragmaWarningDirectiveTrivia(
                                Token(
                                    TriviaList(),
                                    SyntaxKind.DisableKeyword,
                                    TriviaList(
                                        Space)),
                                true)
                            .WithPragmaKeyword(
                                Token(
                                    TriviaList(),
                                    SyntaxKind.PragmaKeyword,
                                    TriviaList(
                                        Space)))
                            .WithWarningKeyword(
                                Token(
                                    TriviaList(),
                                    SyntaxKind.WarningKeyword,
                                    TriviaList(
                                        Space)))
                            .WithErrorCodes(
                                SingletonSeparatedList<ExpressionSyntax>(
                                    IdentifierName(
                                        Identifier(
                                            TriviaList(),
                                            "IDE0016",
                                            TriviaList(
                                                new []{
                                                    Space,
                                                    Comment("// Null check can be simplified")})))))
                            .WithEndOfDirectiveToken(
                                Token(
                                    TriviaList(),
                                    SyntaxKind.EndOfDirectiveToken,
                                    TriviaList(
                                        CarriageReturnLineFeed)))),
                        CarriageReturnLineFeed,
                        Trivia(
                            RegionDirectiveTrivia(
                                true)
                            .WithRegionKeyword(
                                Token(
                                    TriviaList(),
                                    SyntaxKind.RegionKeyword,
                                    TriviaList(
                                        Space)))
                            .WithEndOfDirectiveToken(
                                Token(
                                    TriviaList(
                                        PreprocessingMessage("Models")),
                                    SyntaxKind.EndOfDirectiveToken,
                                    TriviaList(
                                        CarriageReturnLineFeed))))}),
                SyntaxKind.NamespaceKeyword,
                TriviaList(
                    Space)))
        .WithOpenBraceToken(
            Token(
                TriviaList(),
                SyntaxKind.OpenBraceToken,
                TriviaList(
                    CarriageReturnLineFeed)))
        .WithMembers(
            SingletonList<MemberDeclarationSyntax>(
                ClassDeclaration(
                    Identifier(
                        TriviaList(),
                        "AccessPolicy",
                        TriviaList(
                            CarriageReturnLineFeed)))
                .WithModifiers(
                    TokenList(
                        new[]{
                            Token(
                                TriviaList(
                                    new []{
                                        Whitespace("    "),
                                        Trivia(
                                            DocumentationCommentTrivia(
                                                SyntaxKind.SingleLineDocumentationCommentTrivia,
                                                List<XmlNodeSyntax>(
                                                    new XmlNodeSyntax[]{
                                                        XmlText()
                                                        .WithTextTokens(
                                                            TokenList(
                                                                XmlTextLiteral(
                                                                    TriviaList(
                                                                        DocumentationCommentExterior("///")),
                                                                    " ",
                                                                    " ",
                                                                    TriviaList()))),
                                                        XmlExampleElement(
                                                            SingletonList<XmlNodeSyntax>(
                                                                XmlText()
                                                                .WithTextTokens(
                                                                    TokenList(
                                                                        new []{
                                                                            XmlTextNewLine(
                                                                                TriviaList(),
                                                                                Environment.NewLine,
                                                                                Environment.NewLine,
                                                                                TriviaList()),
                                                                            XmlTextLiteral(
                                                                                TriviaList(
                                                                                    DocumentationCommentExterior("    ///")),
                                                                                " An Access policy",
                                                                                " An Access policy",
                                                                                TriviaList()),
                                                                            XmlTextNewLine(
                                                                                TriviaList(),
                                                                                Environment.NewLine,
                                                                                Environment.NewLine,
                                                                                TriviaList()),
                                                                            XmlTextLiteral(
                                                                                TriviaList(
                                                                                    DocumentationCommentExterior("    ///")),
                                                                                " ",
                                                                                " ",
                                                                                TriviaList())}))))
                                                        .WithStartTag(
                                                            XmlElementStartTag(
                                                                XmlName(
                                                                    Identifier("summary"))))
                                                        .WithEndTag(
                                                            XmlElementEndTag(
                                                                XmlName(
                                                                    Identifier("summary")))),
                                                        XmlText()
                                                        .WithTextTokens(
                                                            TokenList(
                                                                XmlTextNewLine(
                                                                    TriviaList(),
                                                                    Environment.NewLine,
                                                                    Environment.NewLine,
                                                                    TriviaList())))}))),
                                        Whitespace("    ")}),
                                SyntaxKind.PublicKeyword,
                                TriviaList(
                                    Space)),
                            Token(
                                TriviaList(),
                                SyntaxKind.PartialKeyword,
                                TriviaList(
                                    Space))}))
                .WithKeyword(
                    Token(
                        TriviaList(),
                        SyntaxKind.ClassKeyword,
                        TriviaList(
                            Space)))
                .WithOpenBraceToken(
                    Token(
                        TriviaList(
                            Whitespace("    ")),
                        SyntaxKind.OpenBraceToken,
                        TriviaList(
                            CarriageReturnLineFeed)))
                .WithMembers(
                    List<MemberDeclarationSyntax>(
                        new MemberDeclarationSyntax[]{
                            PropertyDeclaration(
                                QualifiedName(
                                    IdentifierName("System"),
                                    IdentifierName(
                                        Identifier(
                                            TriviaList(),
                                            "DateTimeOffset",
                                            TriviaList(
                                                Space)))),
                                Identifier(
                                    TriviaList(),
                                    "Start",
                                    TriviaList(
                                        Space)))
                            .WithModifiers(
                                TokenList(
                                    Token(
                                        TriviaList(
                                            new []{
                                                Whitespace("        "),
                                                Trivia(
                                                    DocumentationCommentTrivia(
                                                        SyntaxKind.SingleLineDocumentationCommentTrivia,
                                                        List<XmlNodeSyntax>(
                                                            new XmlNodeSyntax[]{
                                                                XmlText()
                                                                .WithTextTokens(
                                                                    TokenList(
                                                                        XmlTextLiteral(
                                                                            TriviaList(
                                                                                DocumentationCommentExterior("///")),
                                                                            " ",
                                                                            " ",
                                                                            TriviaList()))),
                                                                XmlExampleElement(
                                                                    SingletonList<XmlNodeSyntax>(
                                                                        XmlText()
                                                                        .WithTextTokens(
                                                                            TokenList(
                                                                                new []{
                                                                                    XmlTextNewLine(
                                                                                        TriviaList(),
                                                                                        Environment.NewLine,
                                                                                        Environment.NewLine,
                                                                                        TriviaList()),
                                                                                    XmlTextLiteral(
                                                                                        TriviaList(
                                                                                            DocumentationCommentExterior("        ///")),
                                                                                        " the date-time the policy is active",
                                                                                        " the date-time the policy is active",
                                                                                        TriviaList()),
                                                                                    XmlTextNewLine(
                                                                                        TriviaList(),
                                                                                        Environment.NewLine,
                                                                                        Environment.NewLine,
                                                                                        TriviaList()),
                                                                                    XmlTextLiteral(
                                                                                        TriviaList(
                                                                                            DocumentationCommentExterior("        ///")),
                                                                                        " ",
                                                                                        " ",
                                                                                        TriviaList())}))))
                                                                .WithStartTag(
                                                                    XmlElementStartTag(
                                                                        XmlName(
                                                                            Identifier("summary"))))
                                                                .WithEndTag(
                                                                    XmlElementEndTag(
                                                                        XmlName(
                                                                            Identifier("summary")))),
                                                                XmlText()
                                                                .WithTextTokens(
                                                                    TokenList(
                                                                        XmlTextNewLine(
                                                                            TriviaList(),
                                                                            Environment.NewLine,
                                                                            Environment.NewLine,
                                                                            TriviaList())))}))),
                                                Whitespace("        ")}),
                                        SyntaxKind.PublicKeyword,
                                        TriviaList(
                                            Space))))
                            .WithAccessorList(
                                AccessorList(
                                    List<AccessorDeclarationSyntax>(
                                        new AccessorDeclarationSyntax[]{
                                            AccessorDeclaration(
                                                SyntaxKind.GetAccessorDeclaration)
                                            .WithSemicolonToken(
                                                Token(
                                                    TriviaList(),
                                                    SyntaxKind.SemicolonToken,
                                                    TriviaList(
                                                        Space))),
                                            AccessorDeclaration(
                                                SyntaxKind.SetAccessorDeclaration)
                                            .WithSemicolonToken(
                                                Token(
                                                    TriviaList(),
                                                    SyntaxKind.SemicolonToken,
                                                    TriviaList(
                                                        Space)))}))
                                .WithOpenBraceToken(
                                    Token(
                                        TriviaList(),
                                        SyntaxKind.OpenBraceToken,
                                        TriviaList(
                                            Space)))
                                .WithCloseBraceToken(
                                    Token(
                                        TriviaList(),
                                        SyntaxKind.CloseBraceToken,
                                        TriviaList(
                                            CarriageReturnLineFeed)))),
                            MethodDeclaration(
                                QualifiedName(
                                    QualifiedName(
                                        QualifiedName(
                                            IdentifierName("System"),
                                            IdentifierName("Xml")),
                                        IdentifierName("Linq")),
                                    IdentifierName(
                                        Identifier(
                                            TriviaList(),
                                            "XElement",
                                            TriviaList(
                                                Space)))),
                                Identifier("ToXml"))
                            .WithModifiers(
                                TokenList(
                                    new []{
                                        Token(
                                            TriviaList(
                                                new []{
                                                    CarriageReturnLineFeed,
                                                    Whitespace("        "),
                                                    Trivia(
                                                        DocumentationCommentTrivia(
                                                            SyntaxKind.SingleLineDocumentationCommentTrivia,
                                                            List<XmlNodeSyntax>(
                                                                new XmlNodeSyntax[]{
                                                                    XmlText()
                                                                    .WithTextTokens(
                                                                        TokenList(
                                                                            XmlTextLiteral(
                                                                                TriviaList(
                                                                                    DocumentationCommentExterior("///")),
                                                                                " ",
                                                                                " ",
                                                                                TriviaList()))),
                                                                    XmlExampleElement(
                                                                        SingletonList<XmlNodeSyntax>(
                                                                            XmlText()
                                                                            .WithTextTokens(
                                                                                TokenList(
                                                                                    new []{
                                                                                        XmlTextNewLine(
                                                                                            TriviaList(),
                                                                                            Environment.NewLine,
                                                                                            Environment.NewLine,
                                                                                            TriviaList()),
                                                                                        XmlTextLiteral(
                                                                                            TriviaList(
                                                                                                DocumentationCommentExterior("        ///")),
                                                                                            " Serialize a AccessPolicy instance as XML.",
                                                                                            " Serialize a AccessPolicy instance as XML.",
                                                                                            TriviaList()),
                                                                                        XmlTextNewLine(
                                                                                            TriviaList(),
                                                                                            Environment.NewLine,
                                                                                            Environment.NewLine,
                                                                                            TriviaList()),
                                                                                        XmlTextLiteral(
                                                                                            TriviaList(
                                                                                                DocumentationCommentExterior("        ///")),
                                                                                            " ",
                                                                                            " ",
                                                                                            TriviaList())}))))
                                                                    .WithStartTag(
                                                                        XmlElementStartTag(
                                                                            XmlName(
                                                                                Identifier("summary"))))
                                                                    .WithEndTag(
                                                                        XmlElementEndTag(
                                                                            XmlName(
                                                                                Identifier("summary")))),
                                                                    XmlText()
                                                                    .WithTextTokens(
                                                                        TokenList(
                                                                            new []{
                                                                                XmlTextNewLine(
                                                                                    TriviaList(),
                                                                                    Environment.NewLine,
                                                                                    Environment.NewLine,
                                                                                    TriviaList()),
                                                                                XmlTextLiteral(
                                                                                    TriviaList(
                                                                                        DocumentationCommentExterior("        ///")),
                                                                                    " ",
                                                                                    " ",
                                                                                    TriviaList())})),
                                                                    XmlExampleElement(
                                                                        SingletonList<XmlNodeSyntax>(
                                                                            XmlText()
                                                                            .WithTextTokens(
                                                                                TokenList(
                                                                                    XmlTextLiteral(
                                                                                        TriviaList(),
                                                                                        "The AccessPolicy instance to serialize.",
                                                                                        "The AccessPolicy instance to serialize.",
                                                                                        TriviaList())))))
                                                                    .WithStartTag(
                                                                        XmlElementStartTag(
                                                                            XmlName(
                                                                                Identifier("param")))
                                                                        .WithAttributes(
                                                                            SingletonList<XmlAttributeSyntax>(
                                                                                XmlNameAttribute(
                                                                                    XmlName(
                                                                                        Identifier(
                                                                                            TriviaList(
                                                                                                Space),
                                                                                            "name",
                                                                                            TriviaList())),
                                                                                    Token(SyntaxKind.DoubleQuoteToken),
                                                                                    IdentifierName("value"),
                                                                                    Token(SyntaxKind.DoubleQuoteToken)))))
                                                                    .WithEndTag(
                                                                        XmlElementEndTag(
                                                                            XmlName(
                                                                                Identifier("param")))),
                                                                    XmlText()
                                                                    .WithTextTokens(
                                                                        TokenList(
                                                                            new []{
                                                                                XmlTextNewLine(
                                                                                    TriviaList(),
                                                                                    Environment.NewLine,
                                                                                    Environment.NewLine,
                                                                                    TriviaList()),
                                                                                XmlTextLiteral(
                                                                                    TriviaList(
                                                                                        DocumentationCommentExterior("        ///")),
                                                                                    " ",
                                                                                    " ",
                                                                                    TriviaList())})),
                                                                    XmlExampleElement(
                                                                        SingletonList<XmlNodeSyntax>(
                                                                            XmlText()
                                                                            .WithTextTokens(
                                                                                TokenList(
                                                                                    XmlTextLiteral(
                                                                                        TriviaList(),
                                                                                        "An optional name to use for the root element instead of \"AccessPolicy\".",
                                                                                        "An optional name to use for the root element instead of \"AccessPolicy\".",
                                                                                        TriviaList())))))
                                                                    .WithStartTag(
                                                                        XmlElementStartTag(
                                                                            XmlName(
                                                                                Identifier("param")))
                                                                        .WithAttributes(
                                                                            SingletonList<XmlAttributeSyntax>(
                                                                                XmlNameAttribute(
                                                                                    XmlName(
                                                                                        Identifier(
                                                                                            TriviaList(
                                                                                                Space),
                                                                                            "name",
                                                                                            TriviaList())),
                                                                                    Token(SyntaxKind.DoubleQuoteToken),
                                                                                    IdentifierName("name"),
                                                                                    Token(SyntaxKind.DoubleQuoteToken)))))
                                                                    .WithEndTag(
                                                                        XmlElementEndTag(
                                                                            XmlName(
                                                                                Identifier("param")))),
                                                                    XmlText()
                                                                    .WithTextTokens(
                                                                        TokenList(
                                                                            new []{
                                                                                XmlTextNewLine(
                                                                                    TriviaList(),
                                                                                    Environment.NewLine,
                                                                                    Environment.NewLine,
                                                                                    TriviaList()),
                                                                                XmlTextLiteral(
                                                                                    TriviaList(
                                                                                        DocumentationCommentExterior("        ///")),
                                                                                    " ",
                                                                                    " ",
                                                                                    TriviaList())})),
                                                                    XmlExampleElement(
                                                                        SingletonList<XmlNodeSyntax>(
                                                                            XmlText()
                                                                            .WithTextTokens(
                                                                                TokenList(
                                                                                    XmlTextLiteral(
                                                                                        TriviaList(),
                                                                                        "An optional namespace to use for the root element instead of \"\".",
                                                                                        "An optional namespace to use for the root element instead of \"\".",
                                                                                        TriviaList())))))
                                                                    .WithStartTag(
                                                                        XmlElementStartTag(
                                                                            XmlName(
                                                                                Identifier("param")))
                                                                        .WithAttributes(
                                                                            SingletonList<XmlAttributeSyntax>(
                                                                                XmlNameAttribute(
                                                                                    XmlName(
                                                                                        Identifier(
                                                                                            TriviaList(
                                                                                                Space),
                                                                                            "name",
                                                                                            TriviaList())),
                                                                                    Token(SyntaxKind.DoubleQuoteToken),
                                                                                    IdentifierName("ns"),
                                                                                    Token(SyntaxKind.DoubleQuoteToken)))))
                                                                    .WithEndTag(
                                                                        XmlElementEndTag(
                                                                            XmlName(
                                                                                Identifier("param")))),
                                                                    XmlText()
                                                                    .WithTextTokens(
                                                                        TokenList(
                                                                            new []{
                                                                                XmlTextNewLine(
                                                                                    TriviaList(),
                                                                                    Environment.NewLine,
                                                                                    Environment.NewLine,
                                                                                    TriviaList()),
                                                                                XmlTextLiteral(
                                                                                    TriviaList(
                                                                                        DocumentationCommentExterior("        ///")),
                                                                                    " ",
                                                                                    " ",
                                                                                    TriviaList())})),
                                                                    XmlExampleElement(
                                                                        SingletonList<XmlNodeSyntax>(
                                                                            XmlText()
                                                                            .WithTextTokens(
                                                                                TokenList(
                                                                                    XmlTextLiteral(
                                                                                        TriviaList(),
                                                                                        "The serialized XML element.",
                                                                                        "The serialized XML element.",
                                                                                        TriviaList())))))
                                                                    .WithStartTag(
                                                                        XmlElementStartTag(
                                                                            XmlName(
                                                                                Identifier("returns"))))
                                                                    .WithEndTag(
                                                                        XmlElementEndTag(
                                                                            XmlName(
                                                                                Identifier("returns")))),
                                                                    XmlText()
                                                                    .WithTextTokens(
                                                                        TokenList(
                                                                            XmlTextNewLine(
                                                                                TriviaList(),
                                                                                Environment.NewLine,
                                                                                Environment.NewLine,
                                                                                TriviaList())))}))),
                                                    Whitespace("        ")}),
                                            SyntaxKind.InternalKeyword,
                                            TriviaList(
                                                Space)),
                                        Token(
                                            TriviaList(),
                                            SyntaxKind.StaticKeyword,
                                            TriviaList(
                                                Space))}))
                            .WithParameterList(
                                ParameterList(
                                    SeparatedList<ParameterSyntax>(
                                        new SyntaxNodeOrToken[]{
                                            Parameter(
                                                Identifier("value"))
                                            .WithType(
                                                QualifiedName(
                                                    QualifiedName(
                                                        QualifiedName(
                                                            QualifiedName(
                                                                IdentifierName("Azure"),
                                                                IdentifierName("Storage")),
                                                            IdentifierName("Blobs")),
                                                        IdentifierName("Models")),
                                                    IdentifierName(
                                                        Identifier(
                                                            TriviaList(),
                                                            "AccessPolicy",
                                                            TriviaList(
                                                                Space))))),
                                            Token(
                                                TriviaList(),
                                                SyntaxKind.CommaToken,
                                                TriviaList(
                                                    Space)),
                                            Parameter(
                                                Identifier(
                                                    TriviaList(),
                                                    "name",
                                                    TriviaList(
                                                        Space)))
                                            .WithType(
                                                PredefinedType(
                                                    Token(
                                                        TriviaList(),
                                                        SyntaxKind.StringKeyword,
                                                        TriviaList(
                                                            Space))))
                                            .WithDefault(
                                                EqualsValueClause(
                                                    LiteralExpression(
                                                        SyntaxKind.StringLiteralExpression,
                                                        Literal("AccessPolicy")))
                                                .WithEqualsToken(
                                                    Token(
                                                        TriviaList(),
                                                        SyntaxKind.EqualsToken,
                                                        TriviaList(
                                                            Space)))),
                                            Token(
                                                TriviaList(),
                                                SyntaxKind.CommaToken,
                                                TriviaList(
                                                    Space)),
                                            Parameter(
                                                Identifier(
                                                    TriviaList(),
                                                    "ns",
                                                    TriviaList(
                                                        Space)))
                                            .WithType(
                                                PredefinedType(
                                                    Token(
                                                        TriviaList(),
                                                        SyntaxKind.StringKeyword,
                                                        TriviaList(
                                                            Space))))
                                            .WithDefault(
                                                EqualsValueClause(
                                                    LiteralExpression(
                                                        SyntaxKind.StringLiteralExpression,
                                                        Literal("")))
                                                .WithEqualsToken(
                                                    Token(
                                                        TriviaList(),
                                                        SyntaxKind.EqualsToken,
                                                        TriviaList(
                                                            Space))))}))
                                .WithCloseParenToken(
                                    Token(
                                        TriviaList(),
                                        SyntaxKind.CloseParenToken,
                                        TriviaList(
                                            CarriageReturnLineFeed))))
                            .WithBody(
                                Block(
                                    ExpressionStatement(
                                        InvocationExpression(
                                            MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                MemberAccessExpression(
                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                    MemberAccessExpression(
                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                        IdentifierName(
                                                            Identifier(
                                                                TriviaList(
                                                                    Whitespace("            ")),
                                                                "System",
                                                                TriviaList())),
                                                        IdentifierName("Diagnostics")),
                                                    IdentifierName("Debug")),
                                                IdentifierName("Assert")))
                                        .WithArgumentList(
                                            ArgumentList(
                                                SingletonSeparatedList<ArgumentSyntax>(
                                                    Argument(
                                                        BinaryExpression(
                                                            SyntaxKind.NotEqualsExpression,
                                                            IdentifierName(
                                                                Identifier(
                                                                    TriviaList(),
                                                                    "value",
                                                                    TriviaList(
                                                                        Space))),
                                                            LiteralExpression(
                                                                SyntaxKind.NullLiteralExpression))
                                                        .WithOperatorToken(
                                                            Token(
                                                                TriviaList(),
                                                                SyntaxKind.ExclamationEqualsToken,
                                                                TriviaList(
                                                                    Space))))))))
                                    .WithSemicolonToken(
                                        Token(
                                            TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            TriviaList(
                                                CarriageReturnLineFeed))),
                                    LocalDeclarationStatement(
                                        VariableDeclaration(
                                            QualifiedName(
                                                QualifiedName(
                                                    QualifiedName(
                                                        IdentifierName(
                                                            Identifier(
                                                                TriviaList(
                                                                    Whitespace("            ")),
                                                                "System",
                                                                TriviaList())),
                                                        IdentifierName("Xml")),
                                                    IdentifierName("Linq")),
                                                IdentifierName(
                                                    Identifier(
                                                        TriviaList(),
                                                        "XElement",
                                                        TriviaList(
                                                            Space)))))
                                        .WithVariables(
                                            SingletonSeparatedList<VariableDeclaratorSyntax>(
                                                VariableDeclarator(
                                                    Identifier(
                                                        TriviaList(),
                                                        "_element",
                                                        TriviaList(
                                                            Space)))
                                                .WithInitializer(
                                                    EqualsValueClause(
                                                        ObjectCreationExpression(
                                                            QualifiedName(
                                                                QualifiedName(
                                                                    QualifiedName(
                                                                        IdentifierName("System"),
                                                                        IdentifierName("Xml")),
                                                                    IdentifierName("Linq")),
                                                                IdentifierName("XElement")))
                                                        .WithNewKeyword(
                                                            Token(
                                                                TriviaList(),
                                                                SyntaxKind.NewKeyword,
                                                                TriviaList(
                                                                    Space)))
                                                        .WithArgumentList(
                                                            ArgumentList(
                                                                SingletonSeparatedList<ArgumentSyntax>(
                                                                    Argument(
                                                                        InvocationExpression(
                                                                            MemberAccessExpression(
                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        MemberAccessExpression(
                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                            IdentifierName("System"),
                                                                                            IdentifierName("Xml")),
                                                                                        IdentifierName("Linq")),
                                                                                    IdentifierName("XName")),
                                                                                IdentifierName("Get")))
                                                                        .WithArgumentList(
                                                                            ArgumentList(
                                                                                SeparatedList<ArgumentSyntax>(
                                                                                    new SyntaxNodeOrToken[]{
                                                                                        Argument(
                                                                                            IdentifierName("name")),
                                                                                        Token(
                                                                                            TriviaList(),
                                                                                            SyntaxKind.CommaToken,
                                                                                            TriviaList(
                                                                                                Space)),
                                                                                        Argument(
                                                                                            IdentifierName("ns"))}))))))))
                                                    .WithEqualsToken(
                                                        Token(
                                                            TriviaList(),
                                                            SyntaxKind.EqualsToken,
                                                            TriviaList(
                                                                Space)))))))
                                    .WithSemicolonToken(
                                        Token(
                                            TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            TriviaList(
                                                CarriageReturnLineFeed))),
                                    ExpressionStatement(
                                        InvocationExpression(
                                            MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                IdentifierName(
                                                    Identifier(
                                                        TriviaList(
                                                            Whitespace("            ")),
                                                        "_element",
                                                        TriviaList())),
                                                IdentifierName("Add")))
                                        .WithArgumentList(
                                            ArgumentList(
                                                SingletonSeparatedList<ArgumentSyntax>(
                                                    Argument(
                                                        ObjectCreationExpression(
                                                            QualifiedName(
                                                                QualifiedName(
                                                                    QualifiedName(
                                                                        IdentifierName("System"),
                                                                        IdentifierName("Xml")),
                                                                    IdentifierName("Linq")),
                                                                IdentifierName("XElement")))
                                                        .WithNewKeyword(
                                                            Token(
                                                                TriviaList(),
                                                                SyntaxKind.NewKeyword,
                                                                TriviaList(
                                                                    Space)))
                                                        .WithArgumentList(
                                                            ArgumentList(
                                                                SeparatedList<ArgumentSyntax>(
                                                                    new SyntaxNodeOrToken[]{
                                                                        Argument(
                                                                            InvocationExpression(
                                                                                MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        MemberAccessExpression(
                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                            MemberAccessExpression(
                                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                                IdentifierName(
                                                                                                    Identifier(
                                                                                                        TriviaList(
                                                                                                            Whitespace("                ")),
                                                                                                        "System",
                                                                                                        TriviaList())),
                                                                                                IdentifierName("Xml")),
                                                                                            IdentifierName("Linq")),
                                                                                        IdentifierName("XName")),
                                                                                    IdentifierName("Get")))
                                                                            .WithArgumentList(
                                                                                ArgumentList(
                                                                                    SeparatedList<ArgumentSyntax>(
                                                                                        new SyntaxNodeOrToken[]{
                                                                                            Argument(
                                                                                                LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    Literal("Start"))),
                                                                                            Token(
                                                                                                TriviaList(),
                                                                                                SyntaxKind.CommaToken,
                                                                                                TriviaList(
                                                                                                    Space)),
                                                                                            Argument(
                                                                                                LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    Literal("")))})))),
                                                                        Token(
                                                                            TriviaList(),
                                                                            SyntaxKind.CommaToken,
                                                                            TriviaList(
                                                                                CarriageReturnLineFeed)),
                                                                        Argument(
                                                                            InvocationExpression(
                                                                                MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        IdentifierName(
                                                                                            Identifier(
                                                                                                TriviaList(
                                                                                                    Whitespace("                ")),
                                                                                                "value",
                                                                                                TriviaList())),
                                                                                        IdentifierName("Start")),
                                                                                    IdentifierName("ToString")))
                                                                            .WithArgumentList(
                                                                                ArgumentList(
                                                                                    SeparatedList<ArgumentSyntax>(
                                                                                        new SyntaxNodeOrToken[]{
                                                                                            Argument(
                                                                                                LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    Literal("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ"))),
                                                                                            Token(
                                                                                                TriviaList(),
                                                                                                SyntaxKind.CommaToken,
                                                                                                TriviaList(
                                                                                                    Space)),
                                                                                            Argument(
                                                                                                MemberAccessExpression(
                                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                                    MemberAccessExpression(
                                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                                        MemberAccessExpression(
                                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                                            IdentifierName("System"),
                                                                                                            IdentifierName("Globalization")),
                                                                                                        IdentifierName("CultureInfo")),
                                                                                                    IdentifierName("InvariantCulture")))}))))}))
                                                            .WithOpenParenToken(
                                                                Token(
                                                                    TriviaList(),
                                                                    SyntaxKind.OpenParenToken,
                                                                    TriviaList(
                                                                        CarriageReturnLineFeed)))))))))
                                    .WithSemicolonToken(
                                        Token(
                                            TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            TriviaList(
                                                CarriageReturnLineFeed))),
                                    ExpressionStatement(
                                        InvocationExpression(
                                            MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                IdentifierName(
                                                    Identifier(
                                                        TriviaList(
                                                            Whitespace("            ")),
                                                        "_element",
                                                        TriviaList())),
                                                IdentifierName("Add")))
                                        .WithArgumentList(
                                            ArgumentList(
                                                SingletonSeparatedList<ArgumentSyntax>(
                                                    Argument(
                                                        ObjectCreationExpression(
                                                            QualifiedName(
                                                                QualifiedName(
                                                                    QualifiedName(
                                                                        IdentifierName("System"),
                                                                        IdentifierName("Xml")),
                                                                    IdentifierName("Linq")),
                                                                IdentifierName("XElement")))
                                                        .WithNewKeyword(
                                                            Token(
                                                                TriviaList(),
                                                                SyntaxKind.NewKeyword,
                                                                TriviaList(
                                                                    Space)))
                                                        .WithArgumentList(
                                                            ArgumentList(
                                                                SeparatedList<ArgumentSyntax>(
                                                                    new SyntaxNodeOrToken[]{
                                                                        Argument(
                                                                            InvocationExpression(
                                                                                MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        MemberAccessExpression(
                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                            MemberAccessExpression(
                                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                                IdentifierName(
                                                                                                    Identifier(
                                                                                                        TriviaList(
                                                                                                            Whitespace("                ")),
                                                                                                        "System",
                                                                                                        TriviaList())),
                                                                                                IdentifierName("Xml")),
                                                                                            IdentifierName("Linq")),
                                                                                        IdentifierName("XName")),
                                                                                    IdentifierName("Get")))
                                                                            .WithArgumentList(
                                                                                ArgumentList(
                                                                                    SeparatedList<ArgumentSyntax>(
                                                                                        new SyntaxNodeOrToken[]{
                                                                                            Argument(
                                                                                                LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    Literal("Expiry"))),
                                                                                            Token(
                                                                                                TriviaList(),
                                                                                                SyntaxKind.CommaToken,
                                                                                                TriviaList(
                                                                                                    Space)),
                                                                                            Argument(
                                                                                                LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    Literal("")))})))),
                                                                        Token(
                                                                            TriviaList(),
                                                                            SyntaxKind.CommaToken,
                                                                            TriviaList(
                                                                                CarriageReturnLineFeed)),
                                                                        Argument(
                                                                            InvocationExpression(
                                                                                MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        IdentifierName(
                                                                                            Identifier(
                                                                                                TriviaList(
                                                                                                    Whitespace("                ")),
                                                                                                "value",
                                                                                                TriviaList())),
                                                                                        IdentifierName("Expiry")),
                                                                                    IdentifierName("ToString")))
                                                                            .WithArgumentList(
                                                                                ArgumentList(
                                                                                    SeparatedList<ArgumentSyntax>(
                                                                                        new SyntaxNodeOrToken[]{
                                                                                            Argument(
                                                                                                LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    Literal("yyyy'-'MM'-'dd'T'HH':'mm':'ss.fffffffZ"))),
                                                                                            Token(
                                                                                                TriviaList(),
                                                                                                SyntaxKind.CommaToken,
                                                                                                TriviaList(
                                                                                                    Space)),
                                                                                            Argument(
                                                                                                MemberAccessExpression(
                                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                                    MemberAccessExpression(
                                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                                        MemberAccessExpression(
                                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                                            IdentifierName("System"),
                                                                                                            IdentifierName("Globalization")),
                                                                                                        IdentifierName("CultureInfo")),
                                                                                                    IdentifierName("InvariantCulture")))}))))}))
                                                            .WithOpenParenToken(
                                                                Token(
                                                                    TriviaList(),
                                                                    SyntaxKind.OpenParenToken,
                                                                    TriviaList(
                                                                        CarriageReturnLineFeed)))))))))
                                    .WithSemicolonToken(
                                        Token(
                                            TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            TriviaList(
                                                CarriageReturnLineFeed))),
                                    ExpressionStatement(
                                        InvocationExpression(
                                            MemberAccessExpression(
                                                SyntaxKind.SimpleMemberAccessExpression,
                                                IdentifierName(
                                                    Identifier(
                                                        TriviaList(
                                                            Whitespace("            ")),
                                                        "_element",
                                                        TriviaList())),
                                                IdentifierName("Add")))
                                        .WithArgumentList(
                                            ArgumentList(
                                                SingletonSeparatedList<ArgumentSyntax>(
                                                    Argument(
                                                        ObjectCreationExpression(
                                                            QualifiedName(
                                                                QualifiedName(
                                                                    QualifiedName(
                                                                        IdentifierName("System"),
                                                                        IdentifierName("Xml")),
                                                                    IdentifierName("Linq")),
                                                                IdentifierName("XElement")))
                                                        .WithNewKeyword(
                                                            Token(
                                                                TriviaList(),
                                                                SyntaxKind.NewKeyword,
                                                                TriviaList(
                                                                    Space)))
                                                        .WithArgumentList(
                                                            ArgumentList(
                                                                SeparatedList<ArgumentSyntax>(
                                                                    new SyntaxNodeOrToken[]{
                                                                        Argument(
                                                                            InvocationExpression(
                                                                                MemberAccessExpression(
                                                                                    SyntaxKind.SimpleMemberAccessExpression,
                                                                                    MemberAccessExpression(
                                                                                        SyntaxKind.SimpleMemberAccessExpression,
                                                                                        MemberAccessExpression(
                                                                                            SyntaxKind.SimpleMemberAccessExpression,
                                                                                            MemberAccessExpression(
                                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                                IdentifierName(
                                                                                                    Identifier(
                                                                                                        TriviaList(
                                                                                                            Whitespace("                ")),
                                                                                                        "System",
                                                                                                        TriviaList())),
                                                                                                IdentifierName("Xml")),
                                                                                            IdentifierName("Linq")),
                                                                                        IdentifierName("XName")),
                                                                                    IdentifierName("Get")))
                                                                            .WithArgumentList(
                                                                                ArgumentList(
                                                                                    SeparatedList<ArgumentSyntax>(
                                                                                        new SyntaxNodeOrToken[]{
                                                                                            Argument(
                                                                                                LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    Literal("Permission"))),
                                                                                            Token(
                                                                                                TriviaList(),
                                                                                                SyntaxKind.CommaToken,
                                                                                                TriviaList(
                                                                                                    Space)),
                                                                                            Argument(
                                                                                                LiteralExpression(
                                                                                                    SyntaxKind.StringLiteralExpression,
                                                                                                    Literal("")))})))),
                                                                        Token(
                                                                            TriviaList(),
                                                                            SyntaxKind.CommaToken,
                                                                            TriviaList(
                                                                                CarriageReturnLineFeed)),
                                                                        Argument(
                                                                            MemberAccessExpression(
                                                                                SyntaxKind.SimpleMemberAccessExpression,
                                                                                IdentifierName(
                                                                                    Identifier(
                                                                                        TriviaList(
                                                                                            Whitespace("                ")),
                                                                                        "value",
                                                                                        TriviaList())),
                                                                                IdentifierName("Permission")))}))
                                                            .WithOpenParenToken(
                                                                Token(
                                                                    TriviaList(),
                                                                    SyntaxKind.OpenParenToken,
                                                                    TriviaList(
                                                                        CarriageReturnLineFeed)))))))))
                                    .WithSemicolonToken(
                                        Token(
                                            TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            TriviaList(
                                                CarriageReturnLineFeed))),
                                    ReturnStatement(
                                        IdentifierName("_element"))
                                    .WithReturnKeyword(
                                        Token(
                                            TriviaList(
                                                Whitespace("            ")),
                                            SyntaxKind.ReturnKeyword,
                                            TriviaList(
                                                Space)))
                                    .WithSemicolonToken(
                                        Token(
                                            TriviaList(),
                                            SyntaxKind.SemicolonToken,
                                            TriviaList(
                                                CarriageReturnLineFeed))))
                                .WithOpenBraceToken(
                                    Token(
                                        TriviaList(
                                            Whitespace("        ")),
                                        SyntaxKind.OpenBraceToken,
                                        TriviaList(
                                            CarriageReturnLineFeed)))
                                .WithCloseBraceToken(
                                    Token(
                                        TriviaList(
                                            Whitespace("        ")),
                                        SyntaxKind.CloseBraceToken,
                                        TriviaList(
                                            CarriageReturnLineFeed))))}))
                .WithCloseBraceToken(
                    Token(
                        TriviaList(
                            Whitespace("    ")),
                        SyntaxKind.CloseBraceToken,
                        TriviaList(
                            CarriageReturnLineFeed)))))
        .WithCloseBraceToken(
            Token(
                TriviaList(),
                SyntaxKind.CloseBraceToken,
                TriviaList(
                    CarriageReturnLineFeed)))))
.WithEndOfFileToken(
    Token(
        TriviaList(
            Trivia(
                EndRegionDirectiveTrivia(
                    true))),
        SyntaxKind.EndOfFileToken,
        TriviaList()))
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
