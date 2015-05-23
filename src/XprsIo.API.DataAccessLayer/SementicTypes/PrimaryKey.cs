// //////////////////////////////////////////////////////////////////////////////////&#xD;
// Licensed under the Apache License, Version 2.0 (the "License");&#xD;
// you may not use this file except in compliance with the License.&#xD;
// You may obtain a copy of the License at&#xD;
// &#xD;
//     http://www.apache.org/licenses/LICENSE-2.0&#xD;
// &#xD;
// Unless required by applicable law or agreed to in writing, software&#xD;
// distributed under the License is distributed on an "AS IS" BASIS,&#xD;
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.&#xD;
// See the License for the specific language governing permissions and&#xD;
// limitations under the License.&#xD;
// //////////////////////////////////////////////////////////////////////////////////
using System;
using System.Collections;
using System.Linq;
using FluffIt;
using JetBrains.Annotations;

namespace XprsIo.API.DataAccessLayer.SementicTypes
{
    public struct PrimaryKey<TPrimaryKey>
    {
        private TPrimaryKey Value { get; }

        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is an IEnumerable and there is no element in the collection.</exception>
        public PrimaryKey([NotNull] TPrimaryKey value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            
            if (value.As<IEnumerable>()?.Cast<object>().Any() ?? false)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The value parameter must contain at least 1 element.");
            }
            
            Value = value;
        }
    }
}