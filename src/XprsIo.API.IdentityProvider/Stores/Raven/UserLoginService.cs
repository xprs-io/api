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

using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluffIt.StaticExtensions;
using Microsoft.AspNet.Identity;
using Raven.Client;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Queries;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IAsyncRavenContext _context;

        public UserLoginService(IAsyncRavenContext context)
        {
            _context = context;
        }

        public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user, CancellationToken cancellationToken)
        {
            var logins = user.Logins
                .Select(l => new UserLoginInfo(l.LoginProvider, l.ProviderKey, l.ProviderDisplayName));

            return Task.FromResult((IList<UserLoginInfo>)logins.ToList());
        }

        public Task AddLoginAsync(IdentityUser user, UserLoginInfo login, CancellationToken cancellationToken)
        {
            var userLogin = new IdentityUserLogin
            {
                LoginProvider = login.LoginProvider,
                ProviderDisplayName = login.ProviderDisplayName,
                ProviderKey = login.ProviderKey
            };

            user.Logins.Add(userLogin);

            return TaskEx.Completed;
        }

        public Task RemoveLoginAsync(
            IdentityUser user,
            string loginProvider,
            string providerKey,
            CancellationToken cancellationToken)
        {
            var storedLogins = user.Logins
                .Where(l => l.LoginProvider == loginProvider && l.ProviderKey == providerKey);

            foreach (var login in storedLogins)
            {
                user.Logins.Remove(login);
            }

            return TaskEx.Completed;
        }

        public Task<IdentityUser> FindByLoginAsync(
            string loginProvider,
            string providerKey,
            CancellationToken cancellationToken)
            => _context.IdentityUsers
                .QueryByLogin(loginProvider, providerKey)
                .FirstOrDefaultAsync();
    }
}