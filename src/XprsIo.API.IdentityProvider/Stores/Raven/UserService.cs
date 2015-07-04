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

using System;
using System.Threading;
using System.Threading.Tasks;
using FluffIt.StaticExtensions;
using Raven.Client;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Extensions;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Queries;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven
{
    /// <summary>
    ///     A service that binds a RavenDB data context to a
    ///     <see cref="UserStore" /> for all generic operations related to an
    ///     <see cref="IdentityUser" /> entity.
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IAsyncRavenContext _context;

        /// <summary>
        ///     Creates a new instance of a UserService based on a RavenDB data
        ///     context.
        /// </summary>
        /// <param name="context">The RavenDB data context to use in this service.</param>
        public UserService(IAsyncRavenContext context)
        {
            _context = context;
        }

        public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.Id.ToString());

        /// <exception cref="InvalidOperationException">
        ///     Invalid <paramref name="user" /> id
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="user" /> is <see langword="null" /> .
        /// </exception>
        public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.GetUserName());

        /// <exception cref="ArgumentNullException">
        ///     <paramref name="user" /> or <paramref name="userName" /> is
        ///     <see langword="null" /> .
        /// </exception>
        public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
        {
            user.Mutate().SetUserName(userName);

            return TaskEx.Completed;
        }

        /// <exception cref="InvalidOperationException">
        ///     Invalid <paramref name="user" /> id
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="user" /> is <see langword="null" /> .
        /// </exception>
        public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.GetUserName());

        /// <exception cref="ArgumentNullException">
        ///     <paramref name="user" /> or <paramref name="normalizedUserName" /> is
        ///     <see langword="null" /> .
        /// </exception>
        public Task SetNormalizedUserNameAsync(
            IdentityUser user,
            string normalizedUserName,
            CancellationToken cancellationToken)
        {
            user.Mutate().SetUserName(normalizedUserName);

            return TaskEx.Completed;
        }

        public async Task CreateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            await _context.IdentityUsers.StoreAsync(user, cancellationToken).ConfigureAwait(false);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            _context.IdentityUsers.DeleteAsync(user);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
            => _context.IdentityUsers
                .LoadAsync(userId, cancellationToken);

        /// <exception cref="ArgumentNullException">
        ///     <paramref name="normalizedUserName" /> is null.
        /// </exception>
        public Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
            => _context.IdentityUsers
                .QueryByUserName(normalizedUserName)
                .FirstOrDefaultAsync(cancellationToken);
    }
}