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
	/// Stores user specific claims
	/// 
	/// </summary>
	public interface IUserClaimService
	{
		/// <summary>
		/// Returns the claims for the user
		/// 
		/// </summary>
		/// <param name="user"/><param name="cancellationToken"/>
		/// <returns/>
		Task<IList<Claim>> GetClaimsAsync(IdentityUser user, CancellationToken cancellationToken);

		/// <summary>
		/// Add a new user claim
		/// 
		/// </summary>
		/// <param name="user"/><param name="claims"/><param name="cancellationToken"/>
		/// <returns/>
		Task AddClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken);

		/// <summary>
		/// Updates the give claim information with the given new claim information
		/// 
		/// </summary>
		/// <param name="user"/><param name="claim"/><param name="newClaim"/><param name="cancellationToken"/>
		/// <returns/>
		Task ReplaceClaimAsync(IdentityUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken);

		/// <summary>
		/// Remove a user claim
		/// 
		/// </summary>
		/// <param name="user"/><param name="claims"/><param name="cancellationToken"/>
		/// <returns/>
		Task RemoveClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken);

		/// <summary>
		/// Get users having a specific claim
		/// 
		/// </summary>
		/// <param name="claim">Claim to look up</param><param name="cancellationToken"/>
		/// <returns/>
		Task<IList<IdentityUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken);
	}
}