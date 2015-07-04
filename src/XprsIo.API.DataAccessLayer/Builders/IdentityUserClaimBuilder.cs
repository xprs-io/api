using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityUserClaimBuilder : FluentEntityBuilderBase<IdentityUserClaim, IdentityUserClaimBuilder>
    {
        private string _type;
        private string _value;

        public IdentityUserClaimBuilder(IdentityUserClaim defaultEntity = null)
            : base(b => new IdentityUserClaim(b._type, b._value))
        {
            if (defaultEntity == null)
            {
                defaultEntity = IdentityUserClaim.Empty;
            }

            _type = defaultEntity.Type;
            _value = defaultEntity.Value;
        }

        public IdentityUserClaimBuilder WithType(string value)
        {
            _type = value;
            return this;
        }

        public IdentityUserClaimBuilder WithValue(string value)
        {
            _value = value;
            return this;
        }
    }
}