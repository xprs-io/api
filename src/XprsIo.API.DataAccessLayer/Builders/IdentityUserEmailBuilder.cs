using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityUserEmailBuilder : FluentEntityBuilderBase<IdentityUserEmail, IdentityUserEmailBuilder>
    {
        private string _email;
        private bool _isPrimary;
        private bool _isConfirmed;

        public IdentityUserEmailBuilder(IdentityUserEmail defaultEntity = null)
            : base(b => new IdentityUserEmail(b._email, b._isPrimary, b._isConfirmed))
        {
            if (defaultEntity == null)
            {
                defaultEntity = IdentityUserEmail.Empty;
            }

            _email = defaultEntity.Email;
            _isPrimary = defaultEntity.IsPrimary;
            _isConfirmed = defaultEntity.IsConfirmed;
        }
        
        public IdentityUserEmailBuilder WithEmail(string value)
        {
            _email = value;
            return this;
        }

        public IdentityUserEmailBuilder WithPrimary(bool value)
        {
            _isPrimary = value;
            return this;
        }

        public IdentityUserEmailBuilder WithConfirmed(bool value)
        {
            _isConfirmed = value;
            return this;
        }
    }
}