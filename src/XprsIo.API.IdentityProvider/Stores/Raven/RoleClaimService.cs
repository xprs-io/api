// //////////////////////////////////////////////////////////////////////////////////
// Licensed under the Apache License, Version 2.0 (the "License");
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

using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using FluffIt.StaticExtensions;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven
{
    public class RoleClaimService : IRoleClaimService
    {
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