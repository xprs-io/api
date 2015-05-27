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
    public class Comment
    {
        public int Id { get; }
        public int ParticipantId { get; }
        public int ContributionId { get; }

        public string Title { get; }
        public string Text { get; }

        public DateTimeOffset Created { get; }
        public DateTimeOffset Modified { get; }

        public Participant Participant { get; }
        public Contribution Contribution { get; }

        public Comment(
            int id,
            int participantId,
            int contributionId,
            string title,
            string text,
            DateTimeOffset created,
            DateTimeOffset modified,
            Participant participant = null,
            Contribution contribution = null)
        {
            Id = id;
            ParticipantId = participantId;
            ContributionId = contributionId;
            Title = title;
            Text = text;
            Created = created;
            Modified = modified;
            Participant = participant;
            Contribution = contribution;
        }
    }
}