using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityUserLoginBuilder : FluentEntityBuilderBase<IdentityUserLogin, IdentityUserLoginBuilder>
    {
        private string _loginProvider;
        private string _providerDisplayName;
        private string _providerKey;

        public IdentityUserLoginBuilder(IdentityUserLogin defaultEntity = null)
            : base(b => new IdentityUserLogin(b._loginProvider, b._providerDisplayName, b._providerKey))
        {
            if (defaultEntity == null)
            {
                defaultEntity = IdentityUserLogin.Empty;
            }

            _loginProvider = defaultEntity.LoginProvider;
            _providerDisplayName = defaultEntity.ProviderDisplayName;
            _providerKey = defaultEntity.ProviderKey;
        }

        public IdentityUserLoginBuilder WithLoginProvider(string value)
        {
            _loginProvider = value;
            return this;
        }

        public IdentityUserLoginBuilder WithProviderDisplayName(string value)
        {
            _providerDisplayName = value;
            return this;
        }

        public IdentityUserLoginBuilder WithProviderKey(string value)
        {
            _providerKey = value;
            return this;
        }
    }
}