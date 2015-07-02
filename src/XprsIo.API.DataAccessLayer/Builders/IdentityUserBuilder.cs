using System;
using System.Collections.Generic;
using FluffIt;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityUserBuilder : FluentEntityBuilderBase<IdentityUser>
    {
        private readonly Func<IdentityRoleBuilder> _identityRoleBuilderFactory;
        private readonly Func<IdentityUserEmailBuilder> _identityUserEmailBuilderFactory;
        private readonly Func<IdentityUserLoginBuilder> _identityUserLoginBuilderFactory;
        private readonly Func<IdentityUserClaimBuilder> _identityUserClaimBuilderFactory;

        public IdentityUserBuilder(
            Func<IdentityRoleBuilder> identityRoleBuilderFactory,
            Func<IdentityUserEmailBuilder> identityUserEmailBuilderFactory,
            Func<IdentityUserLoginBuilder> identityUserLoginBuilderFactory,
            Func<IdentityUserClaimBuilder> identityUserClaimBuilderFactory,
            IdentityUser @default)
            : base(@default)
        {
            _identityRoleBuilderFactory = identityRoleBuilderFactory;
            _identityUserEmailBuilderFactory = identityUserEmailBuilderFactory;
            _identityUserLoginBuilderFactory = identityUserLoginBuilderFactory;
            _identityUserClaimBuilderFactory = identityUserClaimBuilderFactory;
        }
        
        public IdentityUserBuilder WithId(Guid? value = null)
        {
            Context.Id = value ?? Default.Id;
            return this;
        }

        public IdentityUserBuilder WithPasswordHash(string value = null)
        {
            Context.PasswordHash = value ?? Default.PasswordHash;
            return this;
        }

        public IdentityUserBuilder WithPhoneNumber(string value = null)
        {
            Context.PhoneNumber = value ?? Default.PhoneNumber;
            return this;
        }

        public IdentityUserBuilder WithActive(bool value = true)
        {
            Context.IsActive = value;
            return this;
        }

        public IdentityUserBuilder WithPhoneNumberConfirmed(bool value = true)
        {
            Context.IsPhoneNumberConfirmed = value;
            return this;
        }

        public IdentityUserBuilder WithTwoFactorAuthentication(bool value = true)
        {
            Context.IsTwoFactorEnabled = value;
            return this;
        }

        public IdentityUserBuilder WithAccessFailedCount(int? value = null)
        {
            Context.AccessFailedCount = value ?? Default.AccessFailedCount;
            return this;
        }

        public IdentityUserBuilder WithLockoutEnabled(bool value = true)
        {
            Context.IsLockoutEnabled = value;
            return this;
        }

        public IdentityUserBuilder WithLockedEndDateUtc(DateTime? value = null)
        {
            Context.LockedEndDateUtc = value ?? Default.LockedEndDateUtc;
            return this;
        }

        public IdentityUserBuilder WithSecurityStamp(string value = null)
        {
            Context.SecurityStamp = value ?? Default.SecurityStamp;
            return this;
        }

        public IdentityUserBuilder WithRole(Func<IdentityRoleBuilder, IdentityRoleBuilder> builder = null)
        {
            if (Context.Roles == null)
            {
                Context.Roles = new List<IdentityRole>();
            }

            var roleBuilder = _identityRoleBuilderFactory.Invoke();

            Context.Roles.Add(builder.SelectOrDefault(b => b.Invoke(roleBuilder), roleBuilder));

            return this;
        }

        public IdentityUserBuilder WithEmail(Func<IdentityUserEmailBuilder, IdentityUserEmailBuilder> builder = null)
        {
            if (Context.Emails == null)
            {
                Context.Emails = new List<IdentityUserEmail>();
            }

            var emailBuilder = _identityUserEmailBuilderFactory.Invoke();

            Context.Emails.Add(builder.SelectOrDefault(b => b.Invoke(emailBuilder), emailBuilder));

            return this;
        }

        public IdentityUserBuilder WithLogin(Func<IdentityUserLoginBuilder, IdentityUserLoginBuilder> builder = null)
        {
            if (Context.Logins == null)
            {
                Context.Logins = new List<IdentityUserLogin>();
            }

            var loginBuilder = _identityUserLoginBuilderFactory.Invoke();

            Context.Logins.Add(builder.SelectOrDefault(b => b.Invoke(loginBuilder), loginBuilder));

            return this;
        }

        public IdentityUserBuilder WithClaim(Func<IdentityUserClaimBuilder, IdentityUserClaimBuilder> builder = null)
        {
            if (Context.Claims == null)
            {
                Context.Claims = new List<IdentityUserClaim>();
            }

            var claimBuilder = _identityUserClaimBuilderFactory.Invoke();

            Context.Claims.Add(builder.SelectOrDefault(b => b.Invoke(claimBuilder), claimBuilder));

            return this;
        }
    }
}