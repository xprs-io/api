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
using System.Collections.Generic;

namespace XprsIo.API.BusinessLayer.Entities
{
    public class Participant
    {
        public int Id { get; }
        public int MemberId { get; }
        public int CommunityId { get; }

        public string Alias { get; }

        public int CurrentSubscriptionId { get; }
        public IEnumerable<int> PastSubscriptionIds { get; }

        public DateTimeOffset Created { get; }

        public Member Member { get; }
        public Community Community { get; }
        public Subscription CurrentSubscription { get; }
        public IEnumerable<Subscription> PastSubscriptions { get; }

        /// <exception cref="ArgumentNullException"><paramref name="pastSubscriptionIds"/> is <see langword="null" />.</exception>
        public Participant(
            int id,
            int memberId,
            int communityId,
            string @alias,
            int currentSubscriptionId,
            IEnumerable<int> pastSubscriptionIds,
            DateTimeOffset created,
            Member member = null,
            Community community = null,
            Subscription currentSubscription = null,
            IEnumerable<Subscription> pastSubscriptions = null)
        {
            if (pastSubscriptionIds == null)
            {
                throw new ArgumentNullException(nameof(pastSubscriptionIds));
            }

            Id = id;
            MemberId = memberId;
            CommunityId = communityId;
            Alias = alias;
            CurrentSubscriptionId = currentSubscriptionId;
            PastSubscriptionIds = pastSubscriptionIds;
            Created = created;
            Member = member;
            Community = community;
            CurrentSubscription = currentSubscription;
            PastSubscriptions = pastSubscriptions;
        }
    }
}