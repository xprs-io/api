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
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Queries;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven
{
    /// <summary>
    ///     A service that binds a RavenDB data context to a
    ///     <see cref="UserStore" /> for all generic operations related to an
    ///     <see cref="IdentityRole" /> entity.
    /// </summary>
    public class RoleService : IRoleService
    {
        private readonly IAsyncRavenContext _context;

        /// <summary>
        ///     Creates a new instance of a RoleService based on a RavenDB data
        ///     context.
        /// </summary>
        /// <param name="context">The RavenDB data context to use in this service.</param>
        public RoleService(IAsyncRavenContext context)
        {
            _context = context;
        }

        public Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
            => Task.FromResult(role.Id.ToString());

        public Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
            => Task.FromResult(role.Name);

        public Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken)
        {
            role.Mutate().SetName(roleName);

            return TaskEx.Completed;
        }

        public Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
            => Task.FromResult(role.Name);

        public Task SetNormalizedRoleNameAsync(
            IdentityRole role,
            string normalizedName,
            CancellationToken cancellationToken)
        {
            role.Mutate().SetName(normalizedName);

            return TaskEx.Completed;
        }

        public async Task CreateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            await _context.IdentityRoles.StoreAsync(role, cancellationToken).ConfigureAwait(false);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        public async Task DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            _context.IdentityRoles.DeleteAsync(role);

            await _context.SaveChangesAsync(cancellationToken).ConfigureAwait(false);
        }

        /// <exception cref="FormatException">
        ///     <paramref name="roleId" /> is not in the correct format. It should
        ///     be a valid <see cref="Int32" /> value.
        /// </exception>
        /// <exception cref="OverflowException">
        ///     <paramref name="roleId" /> represents a number less than
        ///     <see cref="Int32.MinValue" /> or greater than
        ///     <see cref="Int32.MaxValue" /> .
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="roleId" /> is null.
        /// </exception>
        public Task<IdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
            => _context.IdentityRoles
                .LoadAsync(int.Parse(roleId), cancellationToken);

        /// <exception cref="ArgumentNullException">
        ///     <paramref name="normalizedRoleName" /> is null.
        /// </exception>
        public Task<IdentityRole> FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
            => _context.IdentityRoles
                .QueryByName(normalizedRoleName)
                .FirstOrDefaultAsync(cancellationToken);
    }
}