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
    /// <summary>Stores whether two factor is enabled for a user</summary>
    public interface IUserTwoFactorService
    {
        /// <summary>
        ///     Sets whether two factor is <paramref name="enabled" /> for the
        ///     <paramref name="user" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="enabled"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled, CancellationToken cancellationToken);

        /// <summary>
        ///     Returns whether two factor is enabled for the
        ///     <paramref name="user" />
        /// </summary>
        /// <param name="user"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<bool> GetTwoFactorEnabledAsync(IdentityUser user, CancellationToken cancellationToken);
    }
}