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

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace XprsIo.API.DataAccessLayer.Compiler.Preprocess.Conventions
{
    internal class EntityTemplateNamespaceConvention : IConvention<NamespaceDeclarationSyntax>
    {
        private const string TemplateFolderName = "FluentTemplates";

        public static readonly EntityTemplateNamespaceConvention Instance = new EntityTemplateNamespaceConvention();

        private static readonly DiagnosticDescriptor InvalidTemplateNamespaceDescriptor = new DiagnosticDescriptor(
            "GFE1002",
            "Invalid template namespace.",
            "The entity template namespace {0} must contain the \"FluentTemplates\" identifier.",
            "FluentEntities.Structure",
            DiagnosticSeverity.Error,
            true
        );

        public bool Match(NamespaceDeclarationSyntax candidate)
        {
            if (candidate.Name is IdentifierNameSyntax)
            {
                return false;
            }

            return Match(candidate.Name);
        }

        public Diagnostic Diagnostic(NamespaceDeclarationSyntax candidate)
        {
            return Microsoft.CodeAnalysis.Diagnostic.Create(
                InvalidTemplateNamespaceDescriptor,
                candidate.Name.GetLocation(),
                candidate.Name.ToString()
            );
        }

        public NamespaceDeclarationSyntax Transform(NamespaceDeclarationSyntax candidate)
        {
            if (!Match(candidate))
            {
                return candidate;
            }

            return candidate.WithName(GetTransformedName(candidate.Name)
                .WithTriviaFrom(candidate.Name)
            );
        }

        private bool Match(NameSyntax sourceName)
        {
            if (sourceName is IdentifierNameSyntax)
            {
                if (sourceName.ToString() == TemplateFolderName)
                {
                    return true;
                }

                return false;
            }

            var qualifiedName = sourceName as QualifiedNameSyntax;
            if (qualifiedName != null)
            {
                var left = Match(qualifiedName.Left);
                
                if (qualifiedName.Right.ToString() == TemplateFolderName)
                {
                    return true;
                }

                return left;
            }

            return false;
        }

        private NameSyntax GetTransformedName(NameSyntax sourceName)
        {
            if (sourceName is IdentifierNameSyntax)
            {
                if (sourceName.ToString() == TemplateFolderName)
                {
                    return null;
                }

                return SyntaxFactory.IdentifierName(sourceName.ToString())
                    .WithTriviaFrom(sourceName);
            }

            var qualifiedName = sourceName as QualifiedNameSyntax;
            if (qualifiedName != null)
            {
                var left = GetTransformedName(qualifiedName.Left);

                if (left == null)
                {
                    return qualifiedName.Right;
                }

                if (qualifiedName.Right.ToString() == TemplateFolderName)
                {
                    return left;
                }

                return SyntaxFactory.QualifiedName(left, qualifiedName.DotToken, qualifiedName.Right)
                    .WithTriviaFrom(qualifiedName);
            }

            return null;
        }
    }
}