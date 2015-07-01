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
using FluffIt;
using JetBrains.Annotations;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Providers.Raven.Extensions
{
    /// <summary>
    ///     A set of extension methods around the <see cref="IdentityUser" />
    ///     entity.
    /// </summary>
    public static class IdentityUserExtensions
    {
        /// <summary>
        ///     Extract the username from the <paramref name="user" /> and
        ///     returns it.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="user" /> is <see langword="null" /> .
        /// </exception>
        /// <returns>
        ///     Returns the <paramref name="user" /> 's <paramref name="user" />
        ///     name.
        /// </returns>
        /// <exception cref="InvalidOperationException">
        ///     There is no primary email address associated to this
        ///     <paramref name="user" />.
        /// </exception>
        public static string GetUserName([NotNull] this IdentityUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var primaryEmail = user.Emails.FirstOrDefault(e => e.IsPrimary);

            if (primaryEmail == null)
            {
                throw new InvalidOperationException("There is no primary email address associated to this user.");
            }

            return primaryEmail.Email;
        }

        /// <summary>
        ///     Sets the username of a <paramref name="user" /> by adding a new
        ///     primary email address.
        /// </summary>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="user" /> or <paramref name="value" /> is
        ///     <see langword="null" /> .
        /// </exception>
        public static void SetUserName([NotNull] this IdentityUser user, [NotNull] string value)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            if (value == null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            foreach (var email in user.Emails)
            {
                email.IsPrimary = false;
            }

            user.Emails.Add(new IdentityUserEmail { Email = value, IsPrimary = true });
        }
    }
}