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

using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace XprsIo.API.DataAccessLayer.Compiler.Preprocess.Conventions
{
    internal class EntityTemplateFilePathConvention : IConvention<string>
    {
        public static readonly EntityTemplateFilePathConvention Instance = new EntityTemplateFilePathConvention();

        private static readonly DiagnosticDescriptor InvalidEntityTemplateFilePathDescriptor = new DiagnosticDescriptor(
            "GFE0002",
            "Invalid entity template file path.",
            "The entity template file path {0} must contain a folder named \"FluentTemplates\" and the file name must end with \"Template\".",
            "FluentEntities.Structure",
            DiagnosticSeverity.Error,
            true
        );

        public bool Match(string candidate)
        {
            var directories = Path.GetDirectoryName(candidate)
                .Split('\\');

            var fileName = Path.GetFileNameWithoutExtension(candidate);

            return
                directories.Any(d => d.Equals("FluentTemplates")) &&
                fileName.EndsWith("Template");
        }

        public Diagnostic Diagnostic(string candidate)
        {
            return Microsoft.CodeAnalysis.Diagnostic.Create(
                InvalidEntityTemplateFilePathDescriptor,
                null,
                candidate
            );
        }

        public string Transform(string candidate)
        {
            if (!Match(candidate))
            {
                return candidate;
            }

            var directories = Path.GetDirectoryName(candidate)
                .Split('\\')
                .Skip(1)
                .Where(d => !d.Equals("FluentTemplates"));

            var fileName = Path.GetFileNameWithoutExtension(candidate);
            var ext = Path.GetExtension(candidate);

            return Path.Combine(
                Path.GetPathRoot(candidate),
                Path.Combine(directories.ToArray()),
                fileName.Substring(0, fileName.Length - "Template".Length) + ext
            );
        }
    }
}