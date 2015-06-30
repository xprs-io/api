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
using Raven.Client;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Repositories;

namespace XprsIo.API.DataAccessLayer.Providers.Raven
{
    /// <summary>
    /// A data context for the RavenDB data source.
    /// </summary>
    public class AsyncRavenContext : IAsyncRavenContext
    {
        private readonly IAsyncDocumentSession _session;

        public AsyncRavenContext(IAsyncDocumentSession session)
        {
            _session = session;

            IdentityUsers = new IdentityUserAsyncRepository(_session);
            IdentityRoles = new IdentityRoleAsyncRepository(_session);
        }

        public Task SaveChangesAsync()
        {
            return _session.SaveChangesAsync();
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken)
        {
            return _session.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _session.Dispose();
        }

        public IAsyncRepository<string, IdentityUser> IdentityUsers { get; }
        public IAsyncRepository<int, IdentityRole> IdentityRoles { get; }
    }
}