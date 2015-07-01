using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityUserClaimBuilder : EntityBuilderBase<IdentityUserClaim>
    {
        public IdentityUserClaimBuilder(IdentityUserClaim @default) : base(@default)
        {
        }

        public IdentityUserClaimBuilder WithKey(string value = null)
        {
            Context.Key = value ?? Default.Key;
            return this;
        }

        public IdentityUserClaimBuilder WithValue(string value = null)
        {
            Context.Value = value ?? Default.Value;
            return this;
        }
    }
}