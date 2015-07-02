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
    ///     A set of queries for the <see cref="IdentityUser" /> entity.
    /// </summary>
    public static class IdentityUserQueries
    {
        /// <summary>
        ///     Query a <paramref name="repository" /> for all entities matching
        ///     the provided <paramref name="userName" /> .
        /// </summary>
        /// <param name="repository">The repository to query.</param>
        /// <param name="userName">The user name to look for.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="repository" /> or <paramref name="userName" /> is
        ///     <see langword="null" />.
        /// </exception>
        /// <returns>
        ///     Returns a query object that can be extended or executed later.
        /// </returns>
        public static IQueryable<IdentityUser> QueryByUserName(
            [NotNull] this IQueryableRepository<IdentityUser> repository,
            [NotNull] string userName)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (repository == null)
            {
                throw new ArgumentNullException(nameof(userName));
            }
           
            return repository.Query()
                .Where(u => u.Emails.Any(e => e.IsPrimary && e.Email == userName));
        }

        /// <summary>
        ///     Query a <paramref name="repository" /> for all entities matching
        ///     the provided claim <paramref name="key" /> .
        /// </summary>
        /// <param name="repository">The repository to query.</param>
        /// <param name="key">The claim to look for.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="repository" /> or <paramref name="key" /> is
        ///     <see langword="null" /> .
        /// </exception>
        /// <returns>
        ///     Returns a query object that can be extended or executed later.
        /// </returns>
        public static IQueryable<IdentityUser> QueryByClaim(
            [NotNull] this IQueryableRepository<IdentityUser> repository,
            [NotNull] string key)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (key == null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            
            return repository.Query()
                .Where(u => u.Claims.Any(c => c.Key == key));
        }

        /// <summary>
        ///     Query a <paramref name="repository" /> for all entities matching
        ///     the provided email <paramref name="email" /> .
        /// </summary>
        /// <param name="repository">The repository to query.</param>
        /// <param name="email">The email to look for.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="repository" /> or <paramref name="email" /> is
        ///     <see langword="null" /> .
        /// </exception>
        /// <returns>
        ///     Returns a query object that can be extended or executed later.
        /// </returns>
        public static IQueryable<IdentityUser> QueryByEmail(
            [NotNull] this IQueryableRepository<IdentityUser> repository,
            [NotNull] string email)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (email == null)
            {
                throw new ArgumentNullException(nameof(email));
            }

            return repository.Query()
                .Where(u => u.Emails.Any(e => e.Email == email));
        }

        /// <summary>
        ///     Query a <paramref name="repository" /> for all entities matching
        ///     the provided login <paramref name="loginProvider" /> and
        ///     <paramref name="providerKey"/>.
        /// </summary>
        /// <param name="repository">The repository to query.</param>
        /// <param name="loginProvider">The login provider to look for.</param>
        /// <param name="providerKey">The provider key to look for.</param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="repository" /> or <paramref name="loginProvider" />
        ///     or <paramref name="providerKey"/> is <see langword="null" /> .
        /// </exception>
        /// <returns>
        ///     Returns a query object that can be extended or executed later.
        /// </returns>
        public static IQueryable<IdentityUser> QueryByLogin(
            [NotNull] this IQueryableRepository<IdentityUser> repository,
            [NotNull] string loginProvider,
            [NotNull] string providerKey)
        {
            if (repository == null)
            {
                throw new ArgumentNullException(nameof(repository));
            }

            if (loginProvider == null)
            {
                throw new ArgumentNullException(nameof(loginProvider));
            }

            if (providerKey == null)
            {
                throw new ArgumentNullException(nameof(providerKey));
            }

            return repository.Query()
                .Where(u => u.Logins.Any(l =>
                    l.LoginProvider == loginProvider &&
                    l.ProviderKey == providerKey
                ));
        }
    }
}