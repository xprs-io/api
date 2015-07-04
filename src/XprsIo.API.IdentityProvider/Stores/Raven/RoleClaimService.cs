using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FluffIt.StaticExtensions;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven
{
    public class RoleClaimService : IRoleClaimService
    {
        private readonly IAsyncRavenContext _context;

        public RoleClaimService(IAsyncRavenContext context)
        {
            _context = context;
        }

        public Task<IList<Claim>> GetClaimsAsync(IdentityRole role, CancellationToken cancellationToken)
            => Task.FromResult((IList<Claim>)role.Claims.Select(c => new Claim(c.Type, c.Value)).ToList());

        public Task AddClaimAsync(IdentityRole role, Claim claim, CancellationToken cancellationToken)
        {
            role.Claims.Add(new IdentityRoleClaim
            {
                Type = claim.Type,
                Value = claim.Value
            });

            return TaskEx.Completed;
        }

        public Task RemoveClaimAsync(IdentityRole role, Claim claim, CancellationToken cancellationToken)
        {
            var storedClaims = role.Claims
                .Where(c => c.Type == claim.Type);

            foreach (var storedClaim in storedClaims)
            {
                role.Claims.Remove(storedClaim);
            }

            return TaskEx.Completed;
        }
    }
}