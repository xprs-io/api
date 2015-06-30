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

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Raven.Client;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Interfaces;

namespace XprsIo.API.DataAccessLayer.Providers.Raven.Repositories
{
    /// <summary>
    /// A repository for <see cref="IdentityUser"/> entities.
    /// </summary>
    public class IdentityUserAsyncRepository : IAsyncRepository<string, IdentityUser>
    {
        private readonly IAsyncDocumentSession _session;

        /// <summary>
        /// Creates a new instance of an IdentityUserAsyncRepository mapped to the provided
        /// RavenDB <paramref name="session" /> .
        /// </summary>
        /// <param name="session">A RavenDB session.</param>
        public IdentityUserAsyncRepository(IAsyncDocumentSession session)
        {
            _session = session;
        }

        /// <summary>
        /// Fetch a single entity from the data source based on its primary key.
        /// </summary>
        /// <param name="key">
        /// A unique identifier that represents the entity in the remote data source.
        /// </param>
        /// <returns>
        /// Returns a new instance of a <see cref="IdentityUser"/> that will
        /// automatically be tracked for changes.
        /// </returns>
        public Task<IdentityUser> LoadAsync(string key)
            => _session.LoadAsync<IdentityUser>(key);

        /// <summary>
        /// Fetch a single entity from the data source based on its primary key.
        /// </summary>
        /// <param name="key">
        /// A unique identifier that represents the entity in the remote data source.
        /// </param>
        /// <param name="cancellationToken">
        /// A cancellation token to stop the execution of the operation.
        /// </param>
        /// <returns>
        /// Returns a new instance of a <see cref="IdentityUser"/> that will
        /// automatically be tracked for changes.
        /// </returns>
        public Task<IdentityUser> LoadAsync(string key, CancellationToken cancellationToken)
            => _session.LoadAsync<IdentityUser>(key, cancellationToken);

        /// <summary>
        /// Initialize a query object to fetch data off a data source.
        /// </summary>
        /// <returns>Returns an instance of a query that can be extended or executed
        /// at a later time.</returns>
        public IQueryable<IdentityUser> Query()
            => _session.Query<IdentityUser>();

        /// <summary>
        /// Store an instance of <see cref="IdentityUser"/> in the data source.
        /// </summary>
        /// <param name="entity">The entity to store.</param>
        public Task StoreAsync(IdentityUser entity)
            => _session.StoreAsync(entity);

        /// <summary>
        /// Store an instance of <see cref="IdentityUser"/> in the data source.
        /// </summary>
        /// <param name="entity">The entity to store.</param>
        /// <param name="cancellationToken">
        /// A cancellation token to stop the execution of the operation.
        /// </param>
        public Task StoreAsync(IdentityUser entity, CancellationToken cancellationToken)
            => _session.StoreAsync(entity, cancellationToken);

        /// <summary>
        /// Remove an instance of <see cref="IdentityUser"/> from the data
        /// source.
        /// </summary>
        /// <param name="entity">The entity to remove.</param>
        public void DeleteAsync(IdentityUser entity)
            => _session.Delete(entity);

        /// <summary>
        /// Remove an instance of <see cref="IdentityUser"/> from the data source
        /// based on its primary key.
        /// </summary>
        /// <param name="key">
        /// A unique identifier that represents the entity in the remote data source
        /// </param>
        public void DeleteAsync(string key)
            => _session.Delete(key);
    }
}