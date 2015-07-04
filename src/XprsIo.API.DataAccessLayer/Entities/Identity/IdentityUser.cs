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
    /// <summary>Represents a user that can sign-in to the system.</summary>
    public class IdentityUser
    {
        public class MutableIdentityUserProxy
        {
            private readonly IdentityUser _instance;

            public MutableIdentityUserProxy(IdentityUser instance)
            {
                _instance = instance;
            }

            public IdentityUser Freeze()
            {
                return _instance;
            }

            public MutableIdentityUserProxy SetId(Guid value)
            {
                _instance.Id = value;
                return this;
            }

            public MutableIdentityUserProxy SetPasswordHash(string value)
            {
                _instance.PasswordHash = value;
                return this;
            }

            public MutableIdentityUserProxy SetPhoneNumber(string value)
            {
                _instance.PhoneNumber = value;
                return this;
            }

            public MutableIdentityUserProxy SetActive(bool value)
            {
                _instance.IsActive = value;
                return this;
            }

            public MutableIdentityUserProxy SetPhoneNumberConfirmed(bool value)
            {
                _instance.IsPhoneNumberConfirmed = value;
                return this;
            }

            public MutableIdentityUserProxy SetTwoFactorEnabled(bool value)
            {
                _instance.IsTwoFactorEnabled = value;
                return this;
            }

            public MutableIdentityUserProxy SetAccessFailedCount(int value)
            {
                _instance.AccessFailedCount = value;
                return this;
            }

            public MutableIdentityUserProxy SetLockoutEnabled(bool value)
            {
                _instance.IsLockoutEnabled = value;
                return this;
            }

            public MutableIdentityUserProxy SetLockedEndDateUtc(DateTimeOffset? value)
            {
                _instance.LockedEndDateUtc = value;
                return this;
            }

            public MutableIdentityUserProxy SetSecurityStamp(string value)
            {
                _instance.SecurityStamp = value;
                return this;
            }

            public MutableIdentityUserProxy SetRoles(ICollection<IdentityRole> value)
            {
                _instance.Roles = value;
                return this;
            }

            public MutableIdentityUserProxy SetEmails(ICollection<IdentityUserEmail> value)
            {
                _instance.Emails = value;
                return this;
            }

            public MutableIdentityUserProxy SetLogins(ICollection<IdentityUserLogin> value)
            {
                _instance.Logins = value;
                return this;
            }

            public MutableIdentityUserProxy SetClaims(ICollection<IdentityUserClaim> value)
            {
                _instance.Claims = value;
                return this;
            }
        }

        public static readonly IdentityUser Empty = new IdentityUser();

        public Guid Id { get; private set; }

        public string PasswordHash { get; private set; }
        public string PhoneNumber { get; private set; }

        public bool IsActive { get; private set; }
        public bool IsPhoneNumberConfirmed { get; private set; }
        public bool IsTwoFactorEnabled { get; private set; }

        public int AccessFailedCount { get; private set; }
        public bool IsLockoutEnabled { get; private set; }
        public DateTimeOffset? LockedEndDateUtc { get; private set; }

        public string SecurityStamp { get; private set; }

        public ICollection<IdentityRole> Roles { get; private set; }
        public ICollection<IdentityUserEmail> Emails { get; private set; }
        public ICollection<IdentityUserLogin> Logins { get; private set; }
        public ICollection<IdentityUserClaim> Claims { get; private set; }

        private IdentityUser()
        {
            PasswordHash = string.Empty;
            PhoneNumber = string.Empty;
            SecurityStamp = string.Empty;
            Roles = new List<IdentityRole>();
            Emails = new List<IdentityUserEmail>();
            Logins = new List<IdentityUserLogin>();
            Claims = new List<IdentityUserClaim>();
        }

        public IdentityUser(
            Guid id,
            string passwordHash,
            string phoneNumber,
            bool isActive,
            bool isPhoneNumberConfirmed,
            bool isTwoFactorEnabled,
            int accessFailedCount,
            bool isLockoutEnabled,
            DateTimeOffset? lockedEndDateUtc,
            string securityStamp,
            ICollection<IdentityRole> roles,
            ICollection<IdentityUserEmail> emails,
            ICollection<IdentityUserLogin> logins,
            ICollection<IdentityUserClaim> claims)
        {
            if (string.IsNullOrEmpty(passwordHash))
            {
                throw new ArgumentException("Value cannot be default or empty", nameof(passwordHash));
            }

            if (string.IsNullOrEmpty(securityStamp))
            {
                throw new ArgumentException("Value cannot be default or empty", nameof(securityStamp));
            }

            Id = id;
            PasswordHash = passwordHash;
            PhoneNumber = phoneNumber;
            IsActive = isActive;
            IsPhoneNumberConfirmed = isPhoneNumberConfirmed;
            IsTwoFactorEnabled = isTwoFactorEnabled;
            AccessFailedCount = accessFailedCount;
            IsLockoutEnabled = isLockoutEnabled;
            LockedEndDateUtc = lockedEndDateUtc;
            SecurityStamp = securityStamp;
            Roles = roles ?? new IdentityRole[0];
            Emails = emails ?? new IdentityUserEmail[0];
            Logins = logins ?? new IdentityUserLogin[0];
            Claims = claims ?? new IdentityUserClaim[0];
        }

        public MutableIdentityUserProxy Mutate()
        {
            if (this == Empty)
            {
                throw new InvalidOperationException("Cannot mutate the default Empty value");
            }

            return new MutableIdentityUserProxy(this);
        }
    }
}