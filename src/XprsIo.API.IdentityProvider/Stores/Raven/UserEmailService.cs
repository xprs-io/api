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
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using FluffIt;
using FluffIt.StaticExtensions;
using Raven.Client;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Extensions;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Queries;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven
{
    public class UserEmailService : IUserEmailService
    {
        private readonly IAsyncRavenContext _context;

        public UserEmailService(IAsyncRavenContext context)
        {
            _context = context;
        }

        public Task<string> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.GetUserName());

        public Task SetEmailAsync(IdentityUser user, string email, CancellationToken cancellationToken)
        {
            user.Mutate().SetUserName(email);

            return TaskEx.Completed;
        }

        public Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.Emails.FirstOrDefault(e => e.IsPrimary).SelectOrDefault(e => e.IsConfirmed));

        public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            var email = user.Emails.FirstOrDefault(e => e.IsPrimary);

            email?.Mutate().SetConfirmed(true);

            return TaskEx.Completed;
        }

        public Task<string> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.GetUserName());

        public Task SetNormalizedEmailAsync(
            IdentityUser user,
            string normalizedEmail,
            CancellationToken cancellationToken)
        {
            user.Mutate().SetUserName(normalizedEmail);

            return TaskEx.Completed;
        }

        public Task<IdentityUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
            => _context.IdentityUsers
                .QueryByEmail(normalizedEmail)
                .FirstOrDefaultAsync();
    }
}