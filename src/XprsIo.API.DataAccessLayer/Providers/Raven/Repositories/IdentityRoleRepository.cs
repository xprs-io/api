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
	public class IdentityRoleRepository : IRepository<int, IdentityRole>
	{
		private readonly IDocumentSession _session;

		public IdentityRoleRepository(IDocumentSession session)
		{
			_session = session;
		}

		public IdentityRole Load(int key)
		{
			return _session.Load<IdentityRole>(key);
		}

		public IQueryable<IdentityRole> Query()
		{
			return _session.Query<IdentityRole>();
		}

		public void Store(IdentityRole entity)
		{
			_session.Store(entity);
		}

		public void Delete(IdentityRole entity)
		{
			_session.Delete(entity);
		}

		public void Delete(int key)
		{
			_session.Delete(key);
		}
	}
}