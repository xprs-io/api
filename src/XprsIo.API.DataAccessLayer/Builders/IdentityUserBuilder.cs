using System;
using System.Collections.Generic;
using FluffIt;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityUserBuilder : FluentEntityBuilderBase<IdentityUser, IdentityUserBuilder>
    {
        private readonly Func<IdentityRoleBuilder> _identityRoleBuilderFactory;
        private readonly Func<IdentityUserEmailBuilder> _identityUserEmailBuilderFactory;
        private readonly Func<IdentityUserLoginBuilder> _identityUserLoginBuilderFactory;
        private readonly Func<IdentityUserClaimBuilder> _identityUserClaimBuilderFactory;

        private Guid _id;
        private string _passwordHash;
        private string _phoneNumber;
        private bool _isActive;
        private bool _isPhoneNumberConfirmed;
        private bool _isTwoFactorEnabled;
        private int _accessFailedCount;
        private bool _isLockoutEnabled;
        private DateTimeOffset? _lockedEndDateUtc;
        private string _securityStamp;
        private readonly ICollection<IdentityRole> _roles;
        private readonly ICollection<IdentityUserEmail> _emails;
        private readonly ICollection<IdentityUserLogin> _logins;
        private readonly ICollection<IdentityUserClaim> _claims;

        public IdentityUserBuilder(
            Func<IdentityRoleBuilder> identityRoleBuilderFactory,
            Func<IdentityUserEmailBuilder> identityUserEmailBuilderFactory,
            Func<IdentityUserLoginBuilder> identityUserLoginBuilderFactory,
            Func<IdentityUserClaimBuilder> identityUserClaimBuilderFactory,
            IdentityUser defaultEntity = null)
            : base(b => new IdentityUser(
                b._id,
                b._passwordHash,
                b._phoneNumber,
                b._isActive,
                b._isPhoneNumberConfirmed,
                b._isTwoFactorEnabled,
                b._accessFailedCount,
                b._isLockoutEnabled,
                b._lockedEndDateUtc,
                b._securityStamp,
                b._roles,
                b._emails,
                b._logins,
                b._claims
            ))
        {
            if (defaultEntity == null)
            {
                defaultEntity = IdentityUser.Empty;
            }

            _identityRoleBuilderFactory = identityRoleBuilderFactory;
            _identityUserEmailBuilderFactory = identityUserEmailBuilderFactory;
            _identityUserLoginBuilderFactory = identityUserLoginBuilderFactory;
            _identityUserClaimBuilderFactory = identityUserClaimBuilderFactory;

            _id = defaultEntity.Id;
            _passwordHash = defaultEntity.PasswordHash;
            _phoneNumber = defaultEntity.PhoneNumber;
            _isActive = defaultEntity.IsActive;
            _isPhoneNumberConfirmed = defaultEntity.IsPhoneNumberConfirmed;
            _isTwoFactorEnabled = defaultEntity.IsTwoFactorEnabled;
            _accessFailedCount = defaultEntity.AccessFailedCount;
            _isLockoutEnabled = defaultEntity.IsLockoutEnabled;
            _lockedEndDateUtc = defaultEntity.LockedEndDateUtc;
            _securityStamp = defaultEntity.SecurityStamp;
            _roles = defaultEntity.Roles;
            _emails = defaultEntity.Emails;
            _logins = defaultEntity.Logins;
            _claims = defaultEntity.Claims;
        }
        
        public IdentityUserBuilder WithId(Guid value)
        {
            _id = value;
            return this;
        }

        public IdentityUserBuilder WithPasswordHash(string value)
        {
            _passwordHash = value;
            return this;
        }

        public IdentityUserBuilder WithPhoneNumber(string value)
        {
            _phoneNumber = value;
            return this;
        }

        public IdentityUserBuilder WithActive(bool value)
        {
            _isActive = value;
            return this;
        }

        public IdentityUserBuilder WithPhoneNumberConfirmed(bool value)
        {
            _isPhoneNumberConfirmed = value;
            return this;
        }

        public IdentityUserBuilder WithTwoFactorAuthentication(bool value)
        {
            _isTwoFactorEnabled = value;
            return this;
        }

        public IdentityUserBuilder WithAccessFailedCount(int value)
        {
            _accessFailedCount = value;
            return this;
        }

        public IdentityUserBuilder WithLockoutEnabled(bool value)
        {
            _isLockoutEnabled = value;
            return this;
        }

        public IdentityUserBuilder WithLockedEndDateUtc(DateTimeOffset? value)
        {
            _lockedEndDateUtc = value;
            return this;
        }

        public IdentityUserBuilder WithSecurityStamp(string value)
        {
            _securityStamp = value;
            return this;
        }

        public IdentityUserBuilder WithRole(Func<IdentityRoleBuilder, IdentityRoleBuilder> builder = null)
        {
            var roleBuilder = _identityRoleBuilderFactory.Invoke();

            _roles.Add(builder.SelectOrDefault(b => b.Invoke(roleBuilder), roleBuilder));

            return this;
        }

        public IdentityUserBuilder WithEmail(Func<IdentityUserEmailBuilder, IdentityUserEmailBuilder> builder = null)
        {
            var emailBuilder = _identityUserEmailBuilderFactory.Invoke();

            _emails.Add(builder.SelectOrDefault(b => b.Invoke(emailBuilder), emailBuilder));

            return this;
        }

        public IdentityUserBuilder WithLogin(Func<IdentityUserLoginBuilder, IdentityUserLoginBuilder> builder = null)
        {
            var loginBuilder = _identityUserLoginBuilderFactory.Invoke();

            _logins.Add(builder.SelectOrDefault(b => b.Invoke(loginBuilder), loginBuilder));

            return this;
        }

        public IdentityUserBuilder WithClaim(Func<IdentityUserClaimBuilder, IdentityUserClaimBuilder> builder = null)
        {
            var claimBuilder = _identityUserClaimBuilderFactory.Invoke();

            _claims.Add(builder.SelectOrDefault(b => b.Invoke(claimBuilder), claimBuilder));

            return this;
        }
    }
}