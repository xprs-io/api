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
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven
{
    public class UserPhoneNumberService : IUserPhoneNumberService
    {
        private readonly IAsyncRavenContext _context;

        public UserPhoneNumberService(IAsyncRavenContext context)
        {
            _context = context;
        }

        public Task<string> GetPhoneNumberAsync(IdentityUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.PhoneNumber);

        public Task SetPhoneNumberAsync(IdentityUser user, string phoneNumber, CancellationToken cancellationToken)
        {
            user.PhoneNumber = phoneNumber;

            return TaskEx.Completed;
        }

        public Task<bool> GetPhoneNumberConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
            => Task.FromResult(user.IsPhoneNumberConfirmed);

        public Task SetPhoneNumberConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
        {
            user.IsPhoneNumberConfirmed = confirmed;

            return TaskEx.Completed;
        }
    }
}