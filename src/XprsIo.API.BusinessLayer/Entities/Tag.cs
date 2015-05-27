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
using System.Collections.Generic;

namespace XprsIo.API.BusinessLayer.Entities
{
    public class Tag
    {
        public int Id { get; }
        public int ParentId { get; }
        public IEnumerable<int> ChildIds { get; }

        public string Name { get; }

        public Tag Parent { get; }
        public IEnumerable<Tag> Children { get; }

        /// <exception cref="ArgumentNullException"><paramref name="childIds"/> is <see langword="null" />.</exception>
        public Tag(
            int id,
            int parentId,
            IEnumerable<int> childIds,
            string name,
            Tag parent = null,
            IEnumerable<Tag> children = null)
        {
            if (childIds == null)
            {
                throw new ArgumentNullException(nameof(childIds));
            }

            Id = id;
            ParentId = parentId;
            ChildIds = childIds;
            Name = name;
            Parent = parent;
            Children = children;
        }
    }
}