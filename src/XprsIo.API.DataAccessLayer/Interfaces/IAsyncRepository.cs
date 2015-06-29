﻿// //////////////////////////////////////////////////////////////////////////////////
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
using JetBrains.Annotations;

namespace XprsIo.API.DataAccessLayer.Interfaces
{
	/// <summary>
	/// A generic repository for CRUD operations on data sources that do no require
	/// any special handling for update operations.
	/// </summary>
	/// <typeparam name="TPrimaryKey">
	/// The type of the primary key used by the entity.
	/// </typeparam>
	/// <typeparam name="TEntity">
	/// The type of the entity supported by the repository.
	/// </typeparam>
	public interface IAsyncRepository<in TPrimaryKey, TEntity> : IQueryableRepository<TEntity>
    {
		/// <summary>
		/// Fetch a single entity from the data source based on its primary key.
		/// </summary>
		/// <param name="key">
		/// A unique identifier that represents the entity in the remote data source.
		/// </param>
		/// <returns>
		/// Returns a new instance of a <typeparamref name="TEntity" /> that will
		/// automatically be tracked for changes.
		/// </returns>
		Task<TEntity> LoadAsync([NotNull] TPrimaryKey key);

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
		/// Returns a new instance of a <typeparamref name="TEntity" /> that will
		/// automatically be tracked for changes.
		/// </returns>
		Task<TEntity> LoadAsync([NotNull]TPrimaryKey key, CancellationToken cancellationToken);

		/// <summary>
		/// Store an instance of <typeparamref name="TEntity"/> in the data source.
		/// </summary>
		/// <param name="entity">The entity to store.</param>
		Task StoreAsync([NotNull] TEntity entity);

		/// <summary>
		/// Store an instance of <typeparamref name="TEntity" /> in the data source.
		/// </summary>
		/// <param name="entity">The entity to store.</param>
		/// <param name="cancellationToken">
		/// A cancellation token to stop the execution of the operation.
		/// </param>
		Task StoreAsync([NotNull] TEntity entity, CancellationToken cancellationToken);

		/// <summary>
		/// Remove an instance of <typeparamref name="TEntity" /> from the data
		/// source.
		/// </summary>
		/// <param name="entity">The entity to remove.</param>
		void DeleteAsync([NotNull] TEntity entity);

		/// <summary>
		/// Remove an instance of <typeparamref name="TEntity" /> from the data source
		/// based on its primary key.
		/// </summary>
		/// <param name="key">
		/// A unique identifier that represents the entity in the remote data source
		/// </param>
		void DeleteAsync([NotNull] TPrimaryKey key);
    }
}