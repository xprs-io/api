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
    public class Contribution
    {
        public int Id { get; }
        public int CommunityId { get; }
        public int CreatorId { get; }
        public IEnumerable<int> OwnerIds { get; }
        public IEnumerable<int> MilestoneIds { get; }
        public int DealId { get; }
        public IEnumerable<int> TagIds { get; }
        public IEnumerable<int> LikeIds { get; }
        public IEnumerable<int> CommentIds { get; }

        public string Name { get; }
        public string Description { get; }

        public DateTimeOffset Created { get; }
        public DateTimeOffset Modified { get; }

        public Community Community { get; }
        public Participant Creator { get; }
        public IEnumerable<Owner> Owners { get; }
        public IEnumerable<Milestone> Milestones { get; }
        public Subscription Deal { get; }
        public IEnumerable<Tag> Tags { get; }
        public IEnumerable<Like> Likes { get; }
        public IEnumerable<Comment> Comments { get; }

        /// <exception cref="ArgumentNullException"><paramref name="ownerIds"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="milestoneIds"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="tagIds"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="likeIds"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="commentIds"/> is <see langword="null" />.</exception>
        public Contribution(
            int id,
            int communityId,
            int creatorId,
            IEnumerable<int> ownerIds,
            IEnumerable<int> milestoneIds,
            int dealId,
            IEnumerable<int> tagIds,
            IEnumerable<int> likeIds,
            IEnumerable<int> commentIds,
            string name,
            string description,
            DateTimeOffset created,
            DateTimeOffset modified,
            Community community = null,
            Participant creator = null,
            IEnumerable<Owner> owners = null,
            IEnumerable<Milestone> milestones = null,
            Subscription deal = null,
            IEnumerable<Tag> tags = null,
            IEnumerable<Like> likes = null,
            IEnumerable<Comment> comments = null)
        {
            if (ownerIds == null)
            {
                throw new ArgumentNullException(nameof(ownerIds));
            }

            if (milestoneIds == null)
            {
                throw new ArgumentNullException(nameof(milestoneIds));
            }

            if (tagIds == null)
            {
                throw new ArgumentNullException(nameof(tagIds));
            }

            if (likeIds == null)
            {
                throw new ArgumentNullException(nameof(likeIds));
            }

            if (commentIds == null)
            {
                throw new ArgumentNullException(nameof(commentIds));
            }

            Id = id;
            CommunityId = communityId;
            CreatorId = creatorId;
            OwnerIds = ownerIds;
            MilestoneIds = milestoneIds;
            DealId = dealId;
            TagIds = tagIds;
            LikeIds = likeIds;
            CommentIds = commentIds;
            Name = name;
            Description = description;
            Created = created;
            Modified = modified;
            Community = community;
            Creator = creator;
            Owners = owners;
            Milestones = milestones;
            Deal = deal;
            Tags = tags;
            Likes = likes;
            Comments = comments;
        }
    }
}