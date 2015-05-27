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

namespace XprsIo.API.BusinessLayer.Entities
{
    public class Like
    {
        public int Id { get; } 
        public int ParticipantId { get; }
        public int ContributionId { get; }

        public DateTimeOffset Created { get; }

        public Participant Participant { get; }
        public Contribution Contribution { get; }

        public Like(
            int id,
            int participantId,
            int contributionId,
            DateTimeOffset created,
            Participant participant = null,
            Contribution contribution = null)
        {
            Id = id;
            ParticipantId = participantId;
            ContributionId = contributionId;
            Created = created;
            Participant = participant;
            Contribution = contribution;
        }
    }
}