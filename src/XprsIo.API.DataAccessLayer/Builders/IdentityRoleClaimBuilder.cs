using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityRoleClaimBuilder : FluentEntityBuilderBase<IdentityRoleClaim, IdentityRoleClaimBuilder>
    {
        private string _type;
        private string _value;

        public IdentityRoleClaimBuilder(IdentityRoleClaim defaultEntity = null)
            : base(b => new IdentityRoleClaim(b._type, b._value))
        {
            if (defaultEntity == null)
            {
                defaultEntity = IdentityRoleClaim.Empty;
            }

            _type = defaultEntity.Type;
            _value = defaultEntity.Value;
        }

        public IdentityRoleClaimBuilder WithType(string value = null)
        {
            _type = value;
            return this;
        }

        public IdentityRoleClaimBuilder WithValue(string value = null)
        {
            _value = value;
            return this;
        }
    }
}