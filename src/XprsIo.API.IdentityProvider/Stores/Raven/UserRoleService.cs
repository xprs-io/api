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
using System.Collections.Generic;
using System.Linq;
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
    public class UserRoleService : IUserRoleService
    {
        private readonly IAsyncRavenContext _context;

        public UserRoleService(IAsyncRavenContext context)
        {
            _context = context;
        }

        public Task<IList<string>> GetRolesAsync(IdentityUser user, CancellationToken cancellationToken)
            => Task.FromResult((IList<string>)user.Roles.Select(r => r.Name).ToList());

        public Task AddToRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            user.Roles.Add(new IdentityRole(0, roleName, new List<IdentityRoleClaim>()));

            return TaskEx.Completed;
        }

        public Task RemoveFromRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
        {
            var roles = user.Roles
                .Where(r => r.Name == roleName);

            foreach (var role in roles)
            {
                user.Roles.Remove(role);
            }

            return TaskEx.Completed;
        }

        public Task<bool> IsInRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
            => Task.FromResult(user.Roles.Any(r => r.Name == roleName));

        public Task<IList<IdentityUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
            => _context.IdentityUsers
                .QueryByRole(roleName)
                .ToListAsync(cancellationToken);
    }
}