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
    public class Milestone
    {
        public int Id { get; }
        public int ContributionId { get; }
        public IEnumerable<int> VersionIds { get; }
        public IEnumerable<int> TagIds { get; }

        public string Name { get; }

        public DateTimeOffset Created { get; }
        public DateTimeOffset Modified { get; }

        public Contribution Contribution { get; }
        public IEnumerable<Version> Versions { get; }
        public IEnumerable<Tag> Tags { get; }

        /// <exception cref="ArgumentNullException"><paramref name="versionIds"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="tagIds"/> is <see langword="null" />.</exception>
        public Milestone(
            int id,
            int contributionId,
            IEnumerable<int> versionIds,
            IEnumerable<int> tagIds,
            string name,
            DateTimeOffset created,
            DateTimeOffset modified,
            Contribution contribution = null,
            IEnumerable<Version> versions = null,
            IEnumerable<Tag> tags = null)
        {
            if (versionIds == null)
            {
                throw new ArgumentNullException(nameof(versionIds));
            }

            if (tagIds == null)
            {
                throw new ArgumentNullException(nameof(tagIds));
            }

            Id = id;
            ContributionId = contributionId;
            VersionIds = versionIds;
            TagIds = tagIds;
            Name = name;
            Created = created;
            Modified = modified;
            Contribution = contribution;
            Versions = versions;
            Tags = tags;
        }
    }
}