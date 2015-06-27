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
using JetBrains.Annotations;

namespace XprsIo.API.DataAccessLayer.Interfaces
{
    public interface IAsyncRepository<in TPrimaryKey, TEntity> : IQueryableRepository<TEntity>
    {
        Task<TEntity> LoadAsync([NotNull] TPrimaryKey key);
        Task<TEntity> LoadAsync([NotNull]TPrimaryKey key, CancellationToken cancellationToken);

        Task StoreAsync([NotNull] TEntity entity);
        Task StoreAsync([NotNull] TEntity entity, CancellationToken cancellationToken);

        void DeleteAsync([NotNull] TEntity entity);
        void DeleteAsync([NotNull] TPrimaryKey key);
    }
}