using System;
using System.Collections.Generic;
using FluffIt;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityRoleBuilder : FluentEntityBuilderBase<IdentityRole, IdentityRoleBuilder>
    {
        private readonly Func<IdentityRoleClaimBuilder> _identityRoleClaimBuilderFactory;

        private int _id;
        private string _name;
        private readonly ICollection<IdentityRoleClaim> _claims;

        public IdentityRoleBuilder(Func<IdentityRoleClaimBuilder> identityRoleClaimBuilderFactory, IdentityRole defaultEntity = null)
            : base(b => new IdentityRole(b._id, b._name, b._claims))
        {
            if (defaultEntity == null)
            {
                defaultEntity = IdentityRole.Empty;
            }

            _identityRoleClaimBuilderFactory = identityRoleClaimBuilderFactory;

            _id = defaultEntity.Id;
            _name = defaultEntity.Name;
            _claims = defaultEntity.Claims;
        }

        public IdentityRoleBuilder WithId(int value)
        {
            _id = value;
            return this;
        }

        public IdentityRoleBuilder WithName(string value)
        {
            _name = value;
            return this;
        }

        public IdentityRoleBuilder WithClaim(Func<IdentityRoleClaimBuilder, IdentityRoleClaimBuilder> builder = null)
        {
            var claimBuilder = _identityRoleClaimBuilderFactory.Invoke();

            _claims.Add(builder.SelectOrDefault(b => b.Invoke(claimBuilder), claimBuilder));

            return this;
        }
    }
}