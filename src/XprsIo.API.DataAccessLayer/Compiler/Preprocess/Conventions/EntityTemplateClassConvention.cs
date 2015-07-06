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
    internal class EntityTemplateClassConvention : IConvention<ClassDeclarationSyntax>
    {
        public static readonly EntityTemplateClassConvention Instance = new EntityTemplateClassConvention();

        private static readonly DiagnosticDescriptor InvalidEntityTemplateNameDescriptor = new DiagnosticDescriptor(
            "GFE1001",
            "Invalid entity template name.",
            "The class name for entity template {0} must end with \"Template\".",
            "FluentEntities.Structure",
            DiagnosticSeverity.Error,
            true
        );

        public bool Match(ClassDeclarationSyntax candidate)
        {
            return candidate.Identifier.ToString().EndsWith("Template");
        }

        public Diagnostic Diagnostic(ClassDeclarationSyntax candidate)
        {
            return Microsoft.CodeAnalysis.Diagnostic.Create(
                InvalidEntityTemplateNameDescriptor,
                candidate.Identifier.GetLocation(),
                candidate.Identifier.ToString()
            );
        }

        public ClassDeclarationSyntax Transform(ClassDeclarationSyntax candidate)
        {
            if (!Match(candidate))
            {
                return candidate;
            }

            var sourceIdentifier = candidate.Identifier.ToString();
            var targetIdentifier = sourceIdentifier.Substring(0, sourceIdentifier.Length - "Template".Length);

            return candidate.WithIdentifier(SyntaxFactory.Identifier(
                candidate.Identifier.LeadingTrivia,
                targetIdentifier,
                candidate.Identifier.TrailingTrivia
            ));
        }
    }
}