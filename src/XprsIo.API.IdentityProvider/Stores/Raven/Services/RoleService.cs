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

using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven.Services
{
	public class RoleService : IRoleService
	{
		private readonly IAsyncRavenContext _context;

		public RoleService(IAsyncRavenContext context)
		{
			_context = context;
		}

		public Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task<IdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}

		public Task<IdentityRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
}