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
    /// Stores a user's password hash
    /// 
    /// </summary>
    public interface IUserPasswordService
    {
        /// <summary>
        /// Set the user password hash
        /// 
        /// </summary>
        /// <param name="user"/><param name="passwordHash"/><param name="cancellationToken"/>
        /// <returns/>
        Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken);

        /// <summary>
        /// Get the user password hash
        /// 
        /// </summary>
        /// <param name="user"/><param name="cancellationToken"/>
        /// <returns/>
        Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        /// Returns true if a user has a password set
        /// 
        /// </summary>
        /// <param name="user"/><param name="cancellationToken"/>
        /// <returns/>
        Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken);
    }
}