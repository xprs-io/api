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
using System.Collections;
using System.Linq;
using FluffIt;
using JetBrains.Annotations;

namespace XprsIo.API.DataAccessLayer.SementicTypes
{
    public class PrimaryKey<TPrimaryKey>
    {
        public TPrimaryKey Value { get; }

        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentOutOfRangeException"><paramref name="value"/> is an IEnumerable and there is no element in the collection.</exception>
        public PrimaryKey([NotNull] TPrimaryKey value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }
            
            if (value.As<IEnumerable>()?.Cast<object>().None() ?? false)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "The value parameter must contain at least 1 element.");
            }
            
            Value = value;
        }
    }
}