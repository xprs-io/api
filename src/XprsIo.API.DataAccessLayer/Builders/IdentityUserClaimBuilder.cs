using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityUserClaimBuilder : FluentEntityBuilderBase<IdentityUserClaim>
    {
        public IdentityUserClaimBuilder(IdentityUserClaim @default) : base(@default)
        {
        }

        public IdentityUserClaimBuilder WithKey(string value = null)
        {
            Context.Type = value ?? Default.Type;
            return this;
        }

        public IdentityUserClaimBuilder WithValue(string value = null)
        {
            Context.Value = value ?? Default.Value;
            return this;
        }
    }
}