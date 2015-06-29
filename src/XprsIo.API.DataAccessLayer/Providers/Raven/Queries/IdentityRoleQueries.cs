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
	/// <summary>
	/// A set of queries for the <see cref="IdentityRole"/> entity.
	/// </summary>
	public static class IdentityRoleQueries
	{
		/// <summary>
		/// Query a <paramref name="repository" /> for all entities matching the
		/// provided <paramref name="name"/>.
		/// </summary>
		/// <param name="repository">The repository to query.</param>
		/// <param name="name">The role name to look for.</param>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="repository" /> or <paramref name="name" /> is null.
		/// </exception>
		/// <returns>
		/// Returns a query object that can be extended or executed later.
		/// </returns>
		public static IQueryable<IdentityRole> QueryByName(
			[NotNull] this IQueryableRepository<IdentityRole> repository,
			[NotNull] string name)
		{
			if (repository == null)
			{
				throw new ArgumentNullException(nameof(repository));
			}

			if (name == null)
			{
				throw new ArgumentNullException(nameof(name));
			}

			return repository.Query()
				.Where(r => r.Name == name);
		}
	}
}