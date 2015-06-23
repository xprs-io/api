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

using System.Threading;
using System.Threading.Tasks;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.IdentityProvider.Stores.Interfaces
{
	/// <summary>
	/// Interface that exposes basic role management
	/// 
	/// </summary>
	public interface IRoleService
	{
		/// <summary>
		/// Insert a new role
		/// 
		/// </summary>
		/// <param name="role"/><param name="cancellationToken"/>
		/// <returns/>
		Task CreateAsync(IdentityRole role, CancellationToken cancellationToken);

		/// <summary>
		/// Update a role
		/// 
		/// </summary>
		/// <param name="role"/><param name="cancellationToken"/>
		/// <returns/>
		Task UpdateAsync(IdentityRole role, CancellationToken cancellationToken);

		/// <summary>
		/// DeleteAsync a role
		/// 
		/// </summary>
		/// <param name="role"/><param name="cancellationToken"/>
		/// <returns/>
		Task DeleteAsync(IdentityRole role, CancellationToken cancellationToken);

		/// <summary>
		/// Returns a role's id
		/// 
		/// </summary>
		/// <param name="role"/><param name="cancellationToken"/>
		/// <returns/>
		Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken);

		/// <summary>
		/// Returns a role's name
		/// 
		/// </summary>
		/// <param name="role"/><param name="cancellationToken"/>
		/// <returns/>
		Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken);

		/// <summary>
		/// Set a role's name
		/// 
		/// </summary>
		/// <param name="role"/><param name="roleName"/><param name="cancellationToken"/>
		/// <returns/>
		Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken);

		/// <summary>
		/// Get a role's normalized name
		/// 
		/// </summary>
		/// <param name="role"/><param name="cancellationToken"/>
		/// <returns/>
		Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken);

		/// <summary>
		/// Set a role's normalized name
		/// 
		/// </summary>
		/// <param name="role"/><param name="normalizedName"/><param name="cancellationToken"/>
		/// <returns/>
		Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken);

		/// <summary>
		/// Finds a role by id
		/// 
		/// </summary>
		/// <param name="roleId"/><param name="cancellationToken"/>
		/// <returns/>
		Task<IdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken);

		/// <summary>
		/// Find a role by normalized name
		/// 
		/// </summary>
		/// <param name="normalizedRoleName"/><param name="cancellationToken"/>
		/// <returns/>
		Task<IdentityRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken);
	}
}