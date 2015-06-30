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
    /// <summary>Interface that exposes basic user management apis</summary>
    public interface IUserService
    {
        /// <summary>
        ///     Returns the <paramref name="user" /> id for a
        ///     <paramref name="user" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>Returns the user's name</summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>Set the <paramref name="user" /> name</summary>
        /// <param name="user"></param>
        /// <param name="userName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken);

        /// <summary>
        ///     Returns the normalized <paramref name="user" /> name
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>Set the normalized <paramref name="user" /> name</summary>
        /// <param name="user"></param>
        /// <param name="normalizedUserName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SetNormalizedUserNameAsync(
            IdentityUser user,
            string normalizedUserName,
            CancellationToken cancellationToken);

        /// <summary>Insert a new <paramref name="user" /></summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task CreateAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        ///     <see cref="UpdateAsync" /> a <paramref name="user" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task UpdateAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        ///     <see cref="DeleteAsync" /> a <paramref name="user" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task DeleteAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>Finds a user</summary>
        /// <param name="userId"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken);

        /// <summary>
        ///     Returns the user associated with this normalized user name
        /// </summary>
        /// <param name="normalizedUserName"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken);
    }
}