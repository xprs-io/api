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
    /// <summary>Stores a user's email</summary>
    public interface IUserEmailService
    {
        /// <summary>
        ///     Set the <paramref name="user" /> <paramref name="email" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="email"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SetEmailAsync(IdentityUser user, string email, CancellationToken cancellationToken);

        /// <summary>Get the <paramref name="user" /> email</summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        ///     Returns <see langword="true" /> if the <paramref name="user" />
        ///     email is confirmed
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        ///     Sets whether the <paramref name="user" /> email is
        ///     <paramref name="confirmed" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="confirmed"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken);

        /// <summary>Returns the user associated with this email</summary>
        /// <param name="normalizedEmail"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<IdentityUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken);

        /// <summary>Returns the normalized email</summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<string> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>Set the normalized email</summary>
        /// <param name="user"></param>
        /// <param name="normalizedEmail"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SetNormalizedEmailAsync(IdentityUser user, string normalizedEmail, CancellationToken cancellationToken);
    }
}