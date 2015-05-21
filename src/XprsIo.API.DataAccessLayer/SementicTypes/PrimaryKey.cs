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
using JetBrains.Annotations;

namespace XprsIo.API.DataAccessLayer.SementicTypes
{
    public class PrimaryKey
    {
        private readonly string _str;
        private readonly ValueType _value;

        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null" />.</exception>
        public PrimaryKey([NotNull] string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _str = value;
        }

        /// <exception cref="ArgumentNullException"><paramref name="value"/> is <see langword="null" />.</exception>
        public PrimaryKey(ValueType value)
        {
            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _value = value;
        }

        public override string ToString()
        {
            return _str ?? _value.ToString();
        }

        public object ToObject()
        {
            return _str ?? (object)_value;
        }
    }
}