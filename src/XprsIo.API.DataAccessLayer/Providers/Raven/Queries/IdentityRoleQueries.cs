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

using System;
using System.Linq;
using JetBrains.Annotations;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Interfaces;

namespace XprsIo.API.DataAccessLayer.Providers.Raven.Queries
{
	public static class IdentityRoleQueries
	{
		/// <exception cref="ArgumentNullException"><paramref name="repository" /> or <paramref name="name" /> is null.</exception>
		public static IQueryable<IdentityRole> QueryByName(
			[NotNull] this IQueryableRepository<IdentityRole> repository,
			[NotNull] string name)
		{
			if (repository == null)
			{
				throw new ArgumentNullException(nameof(repository));
			}

			if (repository == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			return repository.Query()
				.Where(r => r.Name == name);
		}
	}
}