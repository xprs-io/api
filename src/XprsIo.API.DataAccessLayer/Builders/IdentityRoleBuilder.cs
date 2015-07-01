using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Builders
{
    public class IdentityRoleBuilder : EntityBuilderBase<IdentityRole>
    {
        public IdentityRoleBuilder(IdentityRole @default) : base(@default)
        {
        }

        public IdentityRoleBuilder WithId(int? value = null)
        {
            Context.Id = value ?? Default.Id;
            return this;
        }

        public IdentityRoleBuilder WithName(string value = null)
        {
            Context.Name = value ?? Default.Name;
            return this;
        }
    }
}