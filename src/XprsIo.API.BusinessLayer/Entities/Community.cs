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
    public class Community
    {
        public int Id { get; }
        public int ParentId { get; }
        public IEnumerable<int> ChildIds { get; }
        public IEnumerable<int> OwnerIds { get; }

        public string Name { get; }
        public string Url { get; }
        public string Description { get; }

        public IEnumerable<int> TagIds { get; }

        public DateTimeOffset Created { get; }
        public DateTimeOffset Modified { get; }

        public Community Parent { get; }
        public IEnumerable<Community> Children { get; }
        public IEnumerable<Owner> Owners { get; }
        public IEnumerable<Tag> Tags { get; }

        /// <exception cref="ArgumentNullException"><paramref name="childIds"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="ownerIds"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="tagIds"/> is <see langword="null" />.</exception>
        public Community(
            int id,
            int parentId,
            IEnumerable<int> childIds,
            IEnumerable<int> ownerIds,
            string name,
            string url,
            string description,
            IEnumerable<int> tagIds,
            DateTimeOffset created,
            DateTimeOffset modified,
            Community parent = null,
            IEnumerable<Community> children = null,
            IEnumerable<Owner> owners = null,
            IEnumerable<Tag> tags = null)
        {
            if (childIds == null)
            {
                throw new ArgumentNullException(nameof(childIds));
            }

            if (ownerIds == null)
            {
                throw new ArgumentNullException(nameof(ownerIds));
            }

            if (tagIds == null)
            {
                throw new ArgumentNullException(nameof(tagIds));
            }

            Id = id;
            ParentId = parentId;
            ChildIds = childIds;
            OwnerIds = ownerIds;
            Name = name;
            Url = url;
            Description = description;
            TagIds = tagIds;
            Created = created;
            Modified = modified;
            Parent = parent;
            Children = children;
            Owners = owners;
            Tags = tags;
        }
    }
}