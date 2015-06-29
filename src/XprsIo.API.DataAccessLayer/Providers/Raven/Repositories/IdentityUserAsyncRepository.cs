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

		public IdentityUserAsyncRepository(IAsyncDocumentSession session)
		{
			_session = session;
		}

		public Task<IdentityUser> LoadAsync(string key)
		{
			return _session.LoadAsync<IdentityUser>(key);
		}

		public Task<IdentityUser> LoadAsync(string key, CancellationToken cancellationToken)
		{
			return _session.LoadAsync<IdentityUser>(key, cancellationToken);
		}
		
		public IQueryable<IdentityUser> Query()
		{
			return _session.Query<IdentityUser>();
		}

		public Task StoreAsync(IdentityUser entity)
		{
			return _session.StoreAsync(entity);
		}

		public Task StoreAsync(IdentityUser entity, CancellationToken cancellationToken)
		{
			return _session.StoreAsync(entity, cancellationToken);
		}

		public void DeleteAsync(IdentityUser entity)
		{
			_session.Delete(entity);
		}

		public void DeleteAsync(string key)
		{
			_session.Delete(key);
		}
	}
}