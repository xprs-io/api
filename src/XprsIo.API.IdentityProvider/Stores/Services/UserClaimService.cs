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

using System.Collections.Generic;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Services
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
			throw new System.NotImplementedException();
		}

		public Task AddClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task ReplaceClaimAsync(IdentityUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task RemoveClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task<IList<IdentityUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
}