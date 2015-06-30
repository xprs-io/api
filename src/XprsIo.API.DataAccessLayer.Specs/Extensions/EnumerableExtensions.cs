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

using System.Collections.Generic;
using System.Linq;
using XprsIo.API.DataAccessLayer.Interfaces;

namespace XprsIo.API.DataAccessLayer.Specs.Extensions
{
    /// <summary>
    ///     A set of extension methods for
    ///     <see cref="System.Collections.Generic.IEnumerable`1" />
    /// </summary>
    public static class EnumerableExtensions
    {
        private class QueryableEnumerableRepository<T> : IQueryableRepository<T>
        {
            private readonly IEnumerable<T> _source;

            public QueryableEnumerableRepository(IEnumerable<T> source)
            {
                _source = source;
            }

            public IQueryable<T> Query()
                => _source.AsQueryable();
        }

        /// <summary>
        ///     Converts an instance of
        ///     <see cref="System.Collections.Generic.IEnumerable`1" /> to an
        ///     instance of
        ///     <see cref="XprsIo.API.DataAccessLayer.Interfaces.IQueryableRepository`1" />
        ///     .
        /// </summary>
        /// <typeparam name="T">
        ///     The type of entities stored in the IEnumerable.
        /// </typeparam>
        /// <param name="source">The instance to convert.</param>
        /// <returns>
        ///     Returns a new
        ///     <see cref="XprsIo.API.DataAccessLayer.Interfaces.IQueryableRepository`1" />
        ///     based on the provided
        ///     <see cref="System.Collections.Generic.IEnumerable`1" />
        /// </returns>
        public static IQueryableRepository<T> ToQueryableRepository<T>(this IEnumerable<T> source)
            => new QueryableEnumerableRepository<T>(source);
    }
}