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

using System.Collections.Generic;
using System.Linq;
using FluffIt;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Framework.Runtime.Roslyn;
using XprsIo.API.DataAccessLayer.Compiler.Preprocess.Conventions;

namespace XprsIo.API.DataAccessLayer.Compiler.Preprocess
{
    internal static class FluentEntityExtensions
    {
        private static readonly DiagnosticDescriptor InvalidParentNamespaceDescriptor = new DiagnosticDescriptor(
            "GFE0001",
            "Invalid parent namespace.",
            "The entity template {0} must be directly within a namespace",
            "FluentEntities.Structure",
            DiagnosticSeverity.Error,
            true
        );

        public static IEnumerable<KeyValuePair<ClassDeclarationSyntax, SyntaxTree>> GetExistingEntities(this IBeforeCompileContext context)
        {
            return context.Compilation.SyntaxTrees
                .SelectMany(st =>
                {
                    var root = st.GetRoot();

                    return root.GetClassWithAttributeConvention(FluentEntityAttributeConvention.Instance)
                        .Select(cls => new KeyValuePair<ClassDeclarationSyntax, SyntaxTree>(cls, st));
                });
        }

        public static IEnumerable<KeyValuePair<ClassDeclarationSyntax, SyntaxTree>> GetEntitiesFromTemplates(this IBeforeCompileContext context)
        {
            return context.Compilation.SyntaxTrees
                .SelectMany(st =>
                {
                    var root = st.GetRoot();

                    return root.GetClassWithAttributeConvention(FluentEntityTemplateAttributeConvention.Instance)
                        .Select(t => new
                        {
                            TemplateNamespace = t.GetTemplateNamespace(),
                            Entity = t.ToEntity()
                        })
                        .Do(r =>
                        {
                            r.TemplateNamespace.Publish(context);
                            r.Entity.Publish(context);
                        })
                        .Where(r => r.TemplateNamespace.IsPassed() && r.Entity.IsPassed())
                        .Select(r => new
                        {
                            r.TemplateNamespace,
                            r.Entity,
                            EntityNamespace = r.TemplateNamespace.Value.ToEntityNamespace(r.Entity.Value),
                            FilePath = st.GetEntityFilePath()
                        })
                        .Do(r =>
                        {
                            r.EntityNamespace.Publish(context);
                            r.FilePath.Publish(context);
                        })
                        .Where(r => r.EntityNamespace.IsPassed() && r.FilePath.IsPassed())
                        .Select(r => new KeyValuePair<ClassDeclarationSyntax, SyntaxTree>(
                            r.Entity.Value,
                            SyntaxFactory.SyntaxTree(
                                root.ReplaceNode(r.TemplateNamespace.Value, r.EntityNamespace.Value),
                                st.Options,
                                r.FilePath.Value,
                                st.Encoding
                            )
                        ));
                });
        }

        private static IEnumerable<ClassDeclarationSyntax> GetClassWithAttributeConvention(this SyntaxNode syntaxNode, IConvention<AttributeSyntax> convention)
        {
            return syntaxNode
                .DescendantNodes()
                .OfType<AttributeSyntax>()
                .Where(convention.Match)
                .Select(a => a.Parent.Parent)
                .OfType<ClassDeclarationSyntax>();
        }

        private static DiagnosticWrapper<NamespaceDeclarationSyntax> GetTemplateNamespace(this ClassDeclarationSyntax template)
        {
            var ns = template.Parent.As<NamespaceDeclarationSyntax>();

            return ns == null
                ? DiagnosticWrapper<NamespaceDeclarationSyntax>.Fail(Diagnostic.Create(
                    InvalidParentNamespaceDescriptor,
                    template.GetLocation(),
                    template.Identifier.ToString()
                ))
                : DiagnosticWrapper<NamespaceDeclarationSyntax>.Pass(ns);
        }
        
        private static DiagnosticWrapper<NamespaceDeclarationSyntax> ToEntityNamespace(this NamespaceDeclarationSyntax templateNamespace, ClassDeclarationSyntax entity)
        {
            if (!EntityTemplateNamespaceConvention.Instance.Match(templateNamespace))
            {
                return DiagnosticWrapper<NamespaceDeclarationSyntax>.Fail(
                    EntityTemplateNamespaceConvention.Instance.Diagnostic(templateNamespace)
                );
            }

            return DiagnosticWrapper<NamespaceDeclarationSyntax>.Pass(templateNamespace
                .WithName(EntityTemplateNamespaceConvention.Instance.Transform(templateNamespace).Name)
                .WithMembers(SyntaxFactory.List(new[] { (MemberDeclarationSyntax)entity }))
            );
        }

        private static DiagnosticWrapper<string> GetEntityFilePath(this SyntaxTree syntaxTree)
        {
            var filePath = syntaxTree.FilePath;

            if (!EntityTemplateFilePathConvention.Instance.Match(filePath))
            {
                return DiagnosticWrapper<string>.Fail(
                    EntityTemplateFilePathConvention.Instance.Diagnostic(filePath)
                );
            }

            return DiagnosticWrapper<string>.Pass(EntityTemplateFilePathConvention.Instance.Transform(filePath));
        }
    }
}