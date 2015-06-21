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
using System.Threading;
using System.Threading.Tasks;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.IdentityProvider.Stores.Interfaces
{
	/// <summary>
	/// Interface that maps users to their roles
	/// 
	/// </summary>
	public interface IUserRoleService
	{
		/// <summary>
		/// Adds a user to role
		/// 
		/// </summary>
		/// <param name="user"/><param name="roleName"/><param name="cancellationToken"/>
		/// <returns/>
		Task AddToRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken);

		/// <summary>
		/// Removes the role for the user
		/// 
		/// </summary>
		/// <param name="user"/><param name="roleName"/><param name="cancellationToken"/>
		/// <returns/>
		Task RemoveFromRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken);

		/// <summary>
		/// Returns the roles for this user
		/// 
		/// </summary>
		/// <param name="user"/><param name="cancellationToken"/>
		/// <returns/>
		Task<IList<string>> GetRolesAsync(IdentityUser user, CancellationToken cancellationToken);

		/// <summary>
		/// Returns true if a user is in a role
		/// 
		/// </summary>
		/// <param name="user"/><param name="roleName"/><param name="cancellationToken"/>
		/// <returns/>
		Task<bool> IsInRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken);

		/// <summary>
		/// Returns all users in given role
		/// 
		/// </summary>
		/// <param name="roleName"/><param name="cancellationToken"/>
		/// <returns/>
		Task<IList<IdentityUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken);
	}
}