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
	/// Stores a user's security stamp
	/// 
	/// </summary>
	public interface IUserSecurityStampService
	{
		/// <summary>
		/// Set the security stamp for the user
		/// 
		/// </summary>
		/// <param name="user"/><param name="stamp"/><param name="cancellationToken"/>
		/// <returns/>
		Task SetSecurityStampAsync(IdentityUser user, string stamp, CancellationToken cancellationToken);

		/// <summary>
		/// Get the user security stamp
		/// 
		/// </summary>
		/// <param name="user"/><param name="cancellationToken"/>
		/// <returns/>
		Task<string> GetSecurityStampAsync(IdentityUser user, CancellationToken cancellationToken);
	}
}