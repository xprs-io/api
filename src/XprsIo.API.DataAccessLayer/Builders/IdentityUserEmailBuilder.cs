using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityUserEmailBuilder : FluentEntityBuilderBase<IdentityUserEmail>
    {
        public IdentityUserEmailBuilder(IdentityUserEmail @default) : base(@default)
        {
        }
        
        public IdentityUserEmailBuilder WithEmail(string email = null)
        {
            Context.Email = email ?? Default.Email;
            return this;
        }

        public IdentityUserEmailBuilder WithPrimary(bool isPrimary = true)
        {
            Context.IsPrimary = isPrimary;
            return this;
        }

        public IdentityUserEmailBuilder WithConfirmed(bool isConfirmed = true)
        {
            Context.IsConfirmed = isConfirmed;
            return this;
        }
    }
}