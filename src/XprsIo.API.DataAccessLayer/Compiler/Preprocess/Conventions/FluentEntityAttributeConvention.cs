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
using Microsoft.CodeAnalysis.CSharp.Syntax;
using XprsIo.API.DataAccessLayer.Compiler.Preprocess.Attributes;

namespace XprsIo.API.DataAccessLayer.Compiler.Preprocess.Conventions
{
    internal class FluentEntityAttributeConvention : IConvention<AttributeSyntax>
    {
        public static readonly FluentEntityAttributeConvention Instance = new FluentEntityAttributeConvention();

        private static readonly string AttributeName =
            nameof(FluentEntityAttribute).Replace("Attribute", string.Empty);

        public bool Match(AttributeSyntax candidate)
        {
            return candidate.Name.ToString() == AttributeName;
        }

        public Diagnostic Diagnostic(AttributeSyntax candidate)
        {
            // This convention is used as a filter and not a validation.
            throw new System.NotImplementedException();
        }

        public AttributeSyntax Transform(AttributeSyntax candidate)
        {
            // This convention is used as a filter and not a validation.
            throw new System.NotImplementedException();
        }
    }
}