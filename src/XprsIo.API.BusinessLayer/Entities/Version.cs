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
    public class Version
    {
        public int Id { get; }
        public int MilestoneId { get; }

        public string Description { get; }
        public string FileDescriptor { get; }

        public DateTimeOffset Created { get; }

        public Milestone Milestone { get; }

        public Version(
            int id,
            int milestoneId,
            string description,
            string fileDescriptor,
            DateTimeOffset created,
            Milestone milestone = null)
        {
            Id = id;
            MilestoneId = milestoneId;
            Description = description;
            FileDescriptor = fileDescriptor;
            Created = created;
            Milestone = milestone;
        }
    }
}