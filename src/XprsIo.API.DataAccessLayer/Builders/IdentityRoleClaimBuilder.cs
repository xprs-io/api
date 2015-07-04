using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityRoleClaimBuilder : FluentEntityBuilderBase<IdentityRoleClaim>
    {
        public IdentityRoleClaimBuilder(IdentityRoleClaim @default) : base(@default)
        {
        }

        public IdentityRoleClaimBuilder WithKey(string value = null)
        {
            Context.Type = value ?? Default.Type;
            return this;
        }

        public IdentityRoleClaimBuilder WithValue(string value = null)
        {
            Context.Value = value ?? Default.Value;
            return this;
        }
    }
}