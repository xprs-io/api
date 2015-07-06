// //////////////////////////////////////////////////////////////////////////////////
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// //////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using FluffIt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using XprsIo.API.DataAccessLayer.Compiler.Preprocess.Conventions;
using XprsIo.API.DataAccessLayer.Compiler.Preprocess.Extensions;

namespace XprsIo.API.DataAccessLayer.Compiler.Preprocess
{
    internal static class FluentEntityGenerationExtensions
    {
        private static readonly SyntaxTrivia WhitespaceTrivia = SyntaxFactory.SyntaxTrivia(SyntaxKind.WhitespaceTrivia, " ");
        private static readonly SyntaxTrivia IndentationTrivia = SyntaxFactory.SyntaxTrivia(SyntaxKind.WhitespaceTrivia, "    ");
        private static readonly SyntaxTrivia EndOfLineTrivia = SyntaxFactory.SyntaxTrivia(SyntaxKind.EndOfLineTrivia, Environment.NewLine);
        
        public static DiagnosticWrapper<ClassDeclarationSyntax> ToEntity(this ClassDeclarationSyntax template)
        {
            if (!EntityTemplateClassConvention.Instance.Match(template))
            {
                return DiagnosticWrapper<ClassDeclarationSyntax>.Fail(
                    EntityTemplateClassConvention.Instance.Diagnostic(template)
                );
            }

            var identifier = EntityTemplateClassConvention.Instance.Transform(template).Identifier;

            var attributeLists = template.AttributeLists
                .Select(l => l.Attributes.Any(FluentEntityTemplateAttributeConvention.Instance.Match)
                    ? l.ToFluentEntityAttributeList()
                    : l
                );

            var sourceProperties = template.GetCandidateProperties().ToArray();
            var baseIndentationTrivia = sourceProperties.FirstOrDefault()?.GetLeadingTrivia().ToArray();

            var readonlyProperties = sourceProperties.Select(p => p.ToReadonly());

            var constructor = sourceProperties.ToPublicConstructor(baseIndentationTrivia, identifier);

            var members = Enumerable.Empty<MemberDeclarationSyntax>()
                .Concat(readonlyProperties)
                .Concat(new [] { constructor });
            
            return DiagnosticWrapper<ClassDeclarationSyntax>.Pass(template
                .WithAttributeLists(SyntaxFactory.List(attributeLists))
                .WithIdentifier(identifier)
                .WithMembers(SyntaxFactory.List(members))
            );
        }

        private static IEnumerable<PropertyDeclarationSyntax> GetCandidateProperties(this ClassDeclarationSyntax candidate)
        {
            return candidate
                .DescendantNodes()
                .OfType<PropertyDeclarationSyntax>()
                .Where(p => p.Modifiers.Any(m => m.IsKind(SyntaxKind.PublicKeyword)));
        }

        private static AttributeListSyntax ToFluentEntityAttributeList(this AttributeListSyntax attributeListSyntax)
        {
            var attributes = attributeListSyntax.Attributes
                .Select(a => FluentEntityTemplateAttributeConvention.Instance.Match(a)
                    ? FluentEntityTemplateAttributeConvention.Instance.Transform(a)
                    : a
                );

            return attributeListSyntax
                .WithAttributes(SyntaxFactory.SeparatedList(attributes, attributeListSyntax.Attributes.GetSeparators()));
        }

        private static PropertyDeclarationSyntax ToReadonly(this PropertyDeclarationSyntax property)
        {
            return property
                .WithAccessorList(property.AccessorList
                    .WithAccessors(SyntaxFactory.List(property.AccessorList.Accessors
                        .Select(accessor => accessor.IsKind(SyntaxKind.SetAccessorDeclaration)
                            ? accessor.ToPrivate()
                            : accessor
                        )
                    ))
                );
        }

        private static AccessorDeclarationSyntax ToPrivate(this AccessorDeclarationSyntax accessor)
        {
            return accessor
                .WithModifiers(SyntaxFactory.TokenList(new[]
                {
                    SyntaxFactory.Token(SyntaxKind.PrivateKeyword)
                        .WithTrailingTrivia(WhitespaceTrivia)
                }));
        }

        private static ConstructorDeclarationSyntax ToPublicConstructor(
            this PropertyDeclarationSyntax[] sourceProperties,
            SyntaxTrivia[] baseIndentationTrivia,
            SyntaxToken identifier)
        {
            var parameters = sourceProperties.ToPublicConstructorParameters(baseIndentationTrivia);
            var statements = sourceProperties.ToPublicConstructorStatements(baseIndentationTrivia);

            return SyntaxFactory.ConstructorDeclaration(identifier.WithTrailingTrivia())
                .WithModifiers(
                    SyntaxFactory.TokenList(
                    new[]
                    {
                        SyntaxFactory.Token(SyntaxKind.PublicKeyword)
                            .WithTrailingTrivia(WhitespaceTrivia)
                    }))
                .WithParameterList(
                    SyntaxFactory.ParameterList(
                        SyntaxFactory.Token(SyntaxKind.OpenParenToken),
                        SyntaxFactory.SeparatedList(parameters),
                        SyntaxFactory.Token(SyntaxKind.CloseParenToken)
                    )
                    .WithTrailingTrivia(EndOfLineTrivia)
                )
                .WithBody(
                    SyntaxFactory.Block(
                        SyntaxFactory.Token(SyntaxKind.OpenBraceToken)
                            .WithTrailingTrivia(EndOfLineTrivia),
                        SyntaxFactory.List(statements.Cast<StatementSyntax>()),
                        SyntaxFactory.Token(SyntaxKind.CloseBraceToken)
                            .WithLeadingTrivia(baseIndentationTrivia)
                    )
                    .WithLeadingTrivia(baseIndentationTrivia)
                    .WithTrailingTrivia(EndOfLineTrivia)
                )
                .WithLeadingTrivia(baseIndentationTrivia.Prepend(EndOfLineTrivia));
        }

        private static IEnumerable<ParameterSyntax> ToPublicConstructorParameters(
            this IEnumerable<PropertyDeclarationSyntax> sourceProperties,
            IEnumerable<SyntaxTrivia> baseIndentationTrivia)
        {
            return sourceProperties
                .Select(p => SyntaxFactory.Parameter(SyntaxFactory.Identifier(
                    p.Identifier.ValueText.ToCamelCase()
                ))
                .WithType(p.Type)
                .WithLeadingTrivia(baseIndentationTrivia
                    .Prepend(EndOfLineTrivia)
                    .Append(IndentationTrivia)
                )
            );
        }

        private static IEnumerable<ExpressionStatementSyntax> ToPublicConstructorStatements(
            this IEnumerable<PropertyDeclarationSyntax> sourceProperties,
            IEnumerable<SyntaxTrivia> baseIndentationTrivia)
        {
            return sourceProperties
                .Select(p => SyntaxFactory.ExpressionStatement(SyntaxFactory.AssignmentExpression(
                    SyntaxKind.SimpleAssignmentExpression,
                    SyntaxFactory.IdentifierName(p.Identifier),
                    SyntaxFactory.Token(SyntaxKind.EqualsToken)
                        .WithTrailingTrivia(WhitespaceTrivia),
                    SyntaxFactory.IdentifierName(SyntaxFactory.Identifier(
                        p.Identifier.ValueText.ToCamelCase()
                    ))
                )))
                .Select(e => e
                    .WithLeadingTrivia(baseIndentationTrivia.Prepend(IndentationTrivia))
                    .WithTrailingTrivia(EndOfLineTrivia)
                );
        }
    }
}