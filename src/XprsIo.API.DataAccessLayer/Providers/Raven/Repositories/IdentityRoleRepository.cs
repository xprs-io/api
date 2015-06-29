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
using Raven.Client;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Interfaces;

namespace XprsIo.API.DataAccessLayer.Providers.Raven.Repositories
{
	/// <summary>
	/// A repository for <see cref="IdentityRole"/> entities.
	/// </summary>
	public class IdentityRoleRepository : IRepository<int, IdentityRole>
	{
		private readonly IDocumentSession _session;

		/// <summary>
		/// Creates a new instance of an IdentityRoleRepository mapped to the provided
		/// RavenDB <paramref name="session" /> .
		/// </summary>
		/// <param name="session">A RavenDB session.</param>
		public IdentityRoleRepository(IDocumentSession session)
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
		/// Returns a new instance of a <see cref="IdentityRole"/> that will
		/// automatically be tracked for changes.
		/// </returns>
		public IdentityRole Load(int key)
		{
			return _session.Load<IdentityRole>(key);
		}

		/// <summary>
		/// Initialize a query object to fetch data off a data source.
		/// </summary>
		/// <returns>Returns an instance of a query that can be extended or executed
		/// at a later time.</returns>
		public IQueryable<IdentityRole> Query()
		{
			return _session.Query<IdentityRole>();
		}

		/// <summary>
		/// Store an instance of <see cref="IdentityRole"/> in the data source.
		/// </summary>
		/// <param name="entity">The entity to store.</param>
		public void Store(IdentityRole entity)
		{
			_session.Store(entity);
		}

		/// <summary>
		/// Remove an instance of <see cref="IdentityRole"/> from the data
		/// source.
		/// </summary>
		/// <param name="entity">The entity to remove.</param>
		public void Delete(IdentityRole entity)
		{
			_session.Delete(entity);
		}

		/// <summary>
		/// Remove an instance of <see cref="IdentityRole"/> from the data source
		/// based on its primary key.
		/// </summary>
		/// <param name="key">
		/// A unique identifier that represents the entity in the remote data source
		/// </param>
		public void Delete(int key)
		{
			_session.Delete(key);
		}
	}
}