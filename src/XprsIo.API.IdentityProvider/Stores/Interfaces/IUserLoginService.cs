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
using Microsoft.AspNet.Identity;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.IdentityProvider.Stores.Interfaces
{
    /// <summary>
    /// Interface that maps users to login providers, i.e. Google, Facebook,
    /// Twitter, Microsoft
    /// 
    /// </summary>
    public interface IUserLoginService
    {
        /// <summary>
        /// Adds a user login with the specified provider and key
        /// 
        /// </summary>
        /// <param name="user"/><param name="login"/><param name="cancellationToken"/>
        /// <returns/>
        Task AddLoginAsync(IdentityUser user, UserLoginInfo login, CancellationToken cancellationToken);

        /// <summary>
        /// Removes the user login with the specified combination if it exists, returns true if found and removed
        /// 
        /// </summary>
        /// <param name="user"/><param name="loginProvider"/><param name="providerKey"/><param name="cancellationToken"/>
        /// <returns/>
        Task RemoveLoginAsync(
            IdentityUser user,
            string loginProvider,
            string providerKey,
            CancellationToken cancellationToken);

        /// <summary>
        /// Returns the linked accounts for this user
        /// 
        /// </summary>
        /// <param name="user"/><param name="cancellationToken"/>
        /// <returns/>
        Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        /// Returns the user associated with this login
        /// 
        /// </summary>
        /// <param name="loginProvider"/><param name="providerKey"/><param name="cancellationToken"/>
        /// <returns/>
        Task<IdentityUser> FindByLoginAsync(
            string loginProvider,
            string providerKey,
            CancellationToken cancellationToken);
    }
}