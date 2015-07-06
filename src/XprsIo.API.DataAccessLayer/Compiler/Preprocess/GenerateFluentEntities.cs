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
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Framework.Runtime.Roslyn;

namespace XprsIo.API.DataAccessLayer.Compiler.Preprocess
{
    [UsedImplicitly]
    public class GenerateFluentEntities : ICompileModule
    {
        public void BeforeCompile(IBeforeCompileContext context)
        {
            var existingEntities = context.GetExistingEntities().ToArray();
            var newEntities = context.GetEntitiesFromTemplates().ToArray();

            foreach (var entity in newEntities)
            {
                ProcessEntity(context, entity, existingEntities);
            }
        }

        private static void ProcessEntity(
            IBeforeCompileContext context,
            KeyValuePair<ClassDeclarationSyntax, SyntaxTree> entity,
            IEnumerable<KeyValuePair<ClassDeclarationSyntax, SyntaxTree>> existingEntities)
        {
            var fileContent = entity.Value.ToString();

            if (!File.Exists(entity.Value.FilePath))
            {
                WriteToFile(entity.Value);

                context.Compilation = context.Compilation.AddSyntaxTrees(entity.Value);

                return;
            }
            
            using (var reader = new StreamReader(entity.Value.FilePath, entity.Value.Encoding))
            {
                if (reader.ReadToEnd() == fileContent)
                {
                    return;
                }
            }

            WriteToFile(entity.Value);

            var existingEntity = existingEntities
                .FirstOrDefault(e => e.Key.Identifier.ValueText == entity.Key.Identifier.ValueText);

            context.Compilation = context.Compilation
                .RemoveSyntaxTrees(existingEntity.Value)
                .AddSyntaxTrees(entity.Value);
        }

        private static void WriteToFile(SyntaxTree entity)
        {
            using (var writter = new StreamWriter(entity.FilePath, false, entity.Encoding))
            {
                writter.Write(entity.ToString());
            }
        }

        public void AfterCompile(IAfterCompileContext context)
        {
        }
    }
}