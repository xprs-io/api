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
using JetBrains.Annotations;

namespace XprsIo.API.BusinessLayer.Entities
{
    public class Member
    {
        public int Id { get; }
        public int UserId { get; }
        public IEnumerable<int> AliasIds { get; }
        public IEnumerable<int> DonationIds { get; }

        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }
        public string Culture { get; }

        public DateTimeOffset Birthdate { get; }

        public DateTimeOffset Created { get; }

        public User User { get; }
        public IEnumerable<Participant> Aliases { get;}
        public IEnumerable<Subscription> Donations { get; }

        /// <exception cref="ArgumentNullException"><paramref name="aliasIds"/> is <see langword="null" />.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="donationIds"/> is <see langword="null" />.</exception>
        public Member(
            int id,
            int userId,
            [NotNull] IEnumerable<int> aliasIds,
            [NotNull] IEnumerable<int> donationIds,
            string firstName,
            string lastName,
            string email,
            string culture,
            DateTimeOffset birthdate,
            DateTimeOffset created,
            User user = null,
            IEnumerable<Participant> aliases = null,
            IEnumerable<Subscription> donations = null)
        {
            if (aliasIds == null)
            {
                throw new ArgumentNullException(nameof(aliasIds));
            }

            if (donationIds == null)
            {
                throw new ArgumentNullException(nameof(donationIds));
            }
            
            Id = id;
            UserId = userId;
            AliasIds = aliasIds;
            DonationIds = donationIds;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Culture = culture;
            Birthdate = birthdate;
            Created = created;
            User = user;
            Aliases = aliases;
            Donations = donations;
        }
    }
}