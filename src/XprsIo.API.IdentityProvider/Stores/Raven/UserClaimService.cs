// //////////////////////////////////////////////////////////////////////////////////
// Licensed under the Apache License, Version 2.0 (the "License"){}
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// //////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FluffIt.StaticExtensions;
using Raven.Client;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Queries;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven
{
    public class UserClaimService : IUserClaimService
    {
        private readonly IAsyncRavenContext _context;

        public UserClaimService(IAsyncRavenContext context)
        {
            _context = context;
        }

        public Task<IList<Claim>> GetClaimsAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var claims = user.Claims
                .Select(c => new Claim(c.Type, c.Value));

            return Task.FromResult((IList<Claim>)claims.ToList());
        }

        /// <exception cref="NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="claims" /> is null.</exception>
        public Task AddClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            var identityUserClaims = claims
                .Select(c => new IdentityUserClaim
                {
                    Type = c.Type,
                    Value = c.Value
                });

            foreach (var claim in identityUserClaims)
            {
                user.Claims.Add(claim);
            }

            return TaskEx.Completed;
        }
        
        public Task ReplaceClaimAsync(
            IdentityUser user,
            Claim claim,
            Claim newClaim,
            CancellationToken cancellationToken)
        {
            var storedClaim = user.Claims
                .FirstOrDefault(c => c.Type == claim.Type);

            if (storedClaim == null)
            {
                return TaskEx.Completed;
            }

            storedClaim.Value = newClaim.Value;

            return TaskEx.Completed;
        }

        /// <exception cref="NotSupportedException">The <see cref="T:System.Collections.Generic.ICollection`1" /> is read-only.</exception>
        /// <exception cref="ArgumentNullException"><paramref name="claims" /> is null.</exception>
        public Task RemoveClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
        {
            var storedClaims = claims
                .SelectMany(claim => user.Claims.Where(c => c.Type == claim.Type));

            foreach (var storedClaim in storedClaims)
            {
                user.Claims.Remove(storedClaim);
            }

            return TaskEx.Completed;
        }

        public Task<IList<IdentityUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
            => _context.IdentityUsers
                .QueryByClaim(claim.Type)
                .ToListAsync(cancellationToken);
    }
}