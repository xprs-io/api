﻿// //////////////////////////////////////////////////////////////////////////////////&#xD;
// Licensed under the Apache License, Version 2.0 (the "License");&#xD;
// you may not use this file except in compliance with the License.&#xD;
// You may obtain a copy of the License at&#xD;
// &#xD;
//     http://www.apache.org/licenses/LICENSE-2.0&#xD;
// &#xD;
// Unless required by applicable law or agreed to in writing, software&#xD;
// distributed under the License is distributed on an "AS IS" BASIS,&#xD;
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.&#xD;
// See the License for the specific language governing permissions and&#xD;
// limitations under the License.&#xD;
// //////////////////////////////////////////////////////////////////////////////////

using System.Linq;
using JetBrains.Annotations;
using XprsIo.API.DataAccessLayer.SementicTypes;

namespace XprsIo.API.DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity>
    {
        TEntity Load(PrimaryKey key);

        IQueryable<TEntity> Query();

        void Store([NotNull] TEntity entity);

        void Delete([NotNull] TEntity entity);
        void Delete(PrimaryKey key);
    }
}