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
    ///     Interface that maps users to login providers, i.e. Google, Facebook,
    ///     Twitter, Microsoft
    /// </summary>
    public interface IUserLoginService
    {
        /// <summary>
        ///     Adds a <paramref name="user" /> <paramref name="login" /> with the
        ///     specified provider and key
        /// </summary>
        /// <param name="user"></param>
        /// <param name="login"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task AddLoginAsync(IdentityUser user, UserLoginInfo login, CancellationToken cancellationToken);

        /// <summary>
        ///     Removes the <paramref name="user" /> login with the specified
        ///     combination if it exists, returns <see langword="true" /> if
        ///     found and removed
        /// </summary>
        /// <param name="user"></param>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task RemoveLoginAsync(
            IdentityUser user,
            string loginProvider,
            string providerKey,
            CancellationToken cancellationToken);

        /// <summary>
        ///     Returns the linked accounts for this <paramref name="user" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>Returns the user associated with this login</summary>
        /// <param name="loginProvider"></param>
        /// <param name="providerKey"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IdentityUser> FindByLoginAsync(
            string loginProvider,
            string providerKey,
            CancellationToken cancellationToken);
    }
}