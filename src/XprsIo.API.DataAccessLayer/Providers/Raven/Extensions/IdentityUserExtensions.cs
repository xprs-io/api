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
using JetBrains.Annotations;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.DataAccessLayer.Providers.Raven.Extensions
{
	/// <summary>
	/// A set of extension methods around the <see cref="IdentityUser"/> entity.
	/// </summary>
	public static class IdentityUserExtensions
	{
		private const string Index = nameof(IdentityUser) + "s";

		/// <summary>
		/// Extract the user name from the <paramref name="user"/> and returns it.
		/// </summary>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="user" /> is <see langword="null" /> .
		/// </exception>
		/// <exception cref="InvalidOperationException">
		/// Invalid <paramref name="user" /> id.
		/// </exception>
		/// <returns>
		/// Returns the <paramref name="user"/>'s user name,
		/// </returns>
		public static string GetUserName([NotNull] this IdentityUser user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return user.Id.FromIdentityUserId();
		}

		/// <summary>
		/// Sets the user name of a <paramref name="user"/> by overriding its Id.
		/// </summary>
		/// <remarks>
		/// This method should not be called if the <paramref name="user"/> is already
		/// stored as unique identifiers should remain constant.
		/// </remarks>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="user" /> or <paramref name="value" /> is 
		/// <see langword="null" /> .
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

			user.Id = value.ToIdentityUserId();
		}

		/// <summary>
		/// Builds a <see cref="IdentityUser" /> unique identifier from a user name.
		/// </summary>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="userName" /> is <see langword="null" /> .
		/// </exception>
		/// <returns>
		/// Returns a valid <see cref="IdentityUser"/> identifier.
		/// </returns>
		public static string ToIdentityUserId([NotNull] this string userName)
		{
			if (userName == null)
			{
				throw new ArgumentNullException(nameof(userName));
			}

			return Index + "/" + userName;
		}

		/// <summary>
		/// Converts an <see cref="IdentityUser" /> -compatible unique identifier to a
		/// user name.
		/// </summary>
		/// <exception cref="ArgumentNullException">
		/// <paramref name="userId" /> is <see langword="null" /> .
		/// </exception>
		/// <exception cref="InvalidOperationException">Invalid user id</exception>
		/// <returns>
		/// Returns the user name portion of the identifier.
		/// </returns>
		public static string FromIdentityUserId([NotNull] this string userId)
		{
			if (userId == null)
			{
				throw new ArgumentNullException(nameof(userId));
			}

			if (!userId.StartsWith(Index))
			{
				throw new InvalidOperationException("Invalid user id");
			}

			return userId.Remove(0, Index.Length);
		}
	}
}