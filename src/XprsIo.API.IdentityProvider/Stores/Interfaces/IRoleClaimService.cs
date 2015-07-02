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
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.IdentityProvider.Stores.Interfaces
{
    /// <summary>
    /// Stores role specific claims
    /// 
    /// </summary>
    public interface IRoleClaimService
    {
        /// <summary>
        /// Returns the claims for the role
        /// 
        /// </summary>
        /// <param name="role"/><param name="cancellationToken"/>
        /// <returns/>
        Task<IList<Claim>> GetClaimsAsync(IdentityRole role, CancellationToken cancellationToken);

        /// <summary>
        /// Add a new role claim
        /// 
        /// </summary>
        /// <param name="role"/><param name="claim"/><param name="cancellationToken"/>
        /// <returns/>
        Task AddClaimAsync(IdentityRole role, Claim claim, CancellationToken cancellationToken);

        /// <summary>
        /// Remove a role claim
        /// 
        /// </summary>
        /// <param name="role"/><param name="claim"/><param name="cancellationToken"/>
        /// <returns/>
        Task RemoveClaimAsync(IdentityRole role, Claim claim, CancellationToken cancellationToken);
    }
}