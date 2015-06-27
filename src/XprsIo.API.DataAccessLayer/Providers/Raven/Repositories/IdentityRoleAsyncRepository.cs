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
	public class IdentityRoleAsyncRepository : IAsyncRepository<int, IdentityRole>
	{
		private readonly IAsyncDocumentSession _session;

		public IdentityRoleAsyncRepository(IAsyncDocumentSession session)
		{
			_session = session;
		}

		public Task<IdentityRole> LoadAsync(int key)
		{
			return _session.LoadAsync<IdentityRole>(key);
		}

		public Task<IdentityRole> LoadAsync(int key, CancellationToken ct)
		{
			return _session.LoadAsync<IdentityRole>(key, ct);
		}

		public IQueryable<IdentityRole> Query()
		{
			return _session.Query<IdentityRole>();
		}

		public Task StoreAsync(IdentityRole entity)
		{
			return _session.StoreAsync(entity);
		}

		public Task StoreAsync(IdentityRole entity, CancellationToken ct)
		{
			return _session.StoreAsync(entity, ct);
		}

		public void DeleteAsync(IdentityRole entity)
		{
			_session.Delete(entity);
		}

		public void DeleteAsync(int key)
		{
			_session.Delete(key);
		}
	}
}