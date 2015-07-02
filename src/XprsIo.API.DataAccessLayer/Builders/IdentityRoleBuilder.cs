using System;
using System.Collections.Generic;
using FluffIt;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityRoleBuilder : FluentEntityBuilderBase<IdentityRole>
    {
        private readonly Func<IdentityRoleClaimBuilder> _identityRoleClaimBuilderFactory;

        public IdentityRoleBuilder(
            IdentityRole @default,
            Func<IdentityRoleClaimBuilder> identityRoleClaimBuilderFactory)
            : base(@default)
        {
            _identityRoleClaimBuilderFactory = identityRoleClaimBuilderFactory;
        }

        public IdentityRoleBuilder WithId(int? value = null)
        {
            Context.Id = value ?? Default.Id;
            return this;
        }

        public IdentityRoleBuilder WithName(string value = null)
        {
            Context.Name = value ?? Default.Name;
            return this;
        }

        public IdentityRoleBuilder WithClaim(Func<IdentityRoleClaimBuilder, IdentityRoleClaimBuilder> builder = null)
        {
            if (Context.Claims == null)
            {
                Context.Claims = new List<IdentityRoleClaim>();
            }

            var claimBuilder = _identityRoleClaimBuilderFactory.Invoke();

            Context.Claims.Add(builder.SelectOrDefault(b => b.Invoke(claimBuilder), claimBuilder));

            return this;
        }
    }
}