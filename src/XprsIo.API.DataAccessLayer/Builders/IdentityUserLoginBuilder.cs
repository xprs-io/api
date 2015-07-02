using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityUserLoginBuilder : FluentEntityBuilderBase<IdentityUserLogin>
    {
        public IdentityUserLoginBuilder(IdentityUserLogin @default) : base(@default)
        {
        }

        public IdentityUserLoginBuilder WithLoginProvider(string value = null)
        {
            Context.LoginProvider = value ?? Default.LoginProvider;
            return this;
        }

        public IdentityUserLoginBuilder WithProviderDisplayName(string value = null)
        {
            Context.ProviderDisplayName = value ?? Default.ProviderDisplayName;
            return this;
        }

        public IdentityUserLoginBuilder WithProviderKey(string value = null)
        {
            Context.ProviderKey = value ?? Default.ProviderKey;
            return this;
        }
    }
}