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
	public class IdentityUserAsyncRepository : IAsyncRepository<string, IdentityUser>
	{
		private IAsyncDocumentSession _session;

		public IdentityUserAsyncRepository(IAsyncDocumentSession session)
		{
			_session = session;
		}

		public Task<IdentityUser> LoadAsync(string key)
		{
			throw new System.NotImplementedException();
		}

		public Task<IdentityUser> LoadAsync(string key, CancellationToken ct)
		{
			throw new System.NotImplementedException();
		}
		
		public IQueryable<IdentityUser> Query()
		{
			throw new System.NotImplementedException();
		}

		public Task StoreAsync(IdentityUser entity)
		{
			throw new System.NotImplementedException();
		}

		public Task StoreAsync(IdentityUser entity, CancellationToken ct)
		{
			throw new System.NotImplementedException();
		}

		public void DeleteAsync(IdentityUser entity)
		{
			throw new System.NotImplementedException();
		}

		public void DeleteAsync(string key)
		{
			throw new System.NotImplementedException();
		}
	}
}