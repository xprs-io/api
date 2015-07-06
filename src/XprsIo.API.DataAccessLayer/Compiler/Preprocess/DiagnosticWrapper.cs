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
using Microsoft.Framework.Runtime.Roslyn;

namespace XprsIo.API.DataAccessLayer.Compiler.Preprocess
{
    internal class DiagnosticWrapper<T>
    {
        public Diagnostic Diagnostic { get; }
        public T Value { get; }

        private DiagnosticWrapper(Diagnostic diagnostic, T value)
        {
            Diagnostic = diagnostic;
            Value = value;
        }

        public static DiagnosticWrapper<T> Pass(T value)
        {
            return new DiagnosticWrapper<T>(null, value);
        }

        public static DiagnosticWrapper<T> Fail(Diagnostic diagnostic)
        {
            return new DiagnosticWrapper<T>(diagnostic, default(T));
        }

        public bool IsFailed()
        {
            return Diagnostic != null;
        }

        public bool IsPassed()
        {
            return Diagnostic == null;
        }

        public void Publish(IBeforeCompileContext context)
        {
            if (IsFailed())
            {
                context.Diagnostics.Add(Diagnostic);
            }
        }
    }
}