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

namespace XprsIo.API.DataAccessLayer.Entities.Identity
{
    /// <summary>
    /// Represents a user that can sign-in to the system.
    /// </summary>
    public class IdentityUser
    {
        public string Id { get; set; }

        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }


        public bool IsActive { get; set; }
        public bool IsPhoneNumberConfirmed { get; set; }
        public bool IsTwoFactorEnabled { get; set; }

        public int AccessFailedCount { get; set; }
        public bool IsLockoutEnabled { get; set; }
        public DateTime? LockedEndDateUtc { get; set; }

        public string SecurityStamp { get; set; }

        public ICollection<IdentityUserLogin> Logins { get; set; }
        public ICollection<IdentityRole> Roles { get; set; }
        public ICollection<IdentityUserClaim> Claims { get; set; }
    }
}