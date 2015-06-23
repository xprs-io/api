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
	public static class IdentityUserExtensions
	{
		private const string Index = nameof(IdentityUser) + "s";

		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="InvalidOperationException">Invalid user id</exception>
		public static string GetUserName([NotNull] this IdentityUser user)
		{
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return user.Id.FromIdentityUserId();
		}

		/// <exception cref="ArgumentNullException"><paramref name="user"/> or <paramref name="value"/> is <see langword="null" />.</exception>
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

		/// <exception cref="ArgumentNullException"><paramref name="userName"/> is <see langword="null" />.</exception>
		public static string ToIdentityUserId([NotNull] this string userName)
		{
			if (userName == null)
			{
				throw new ArgumentNullException(nameof(userName));
			}

			return Index + "/" + userName;
		}

		/// <exception cref="ArgumentNullException"><paramref name="userId"/> is <see langword="null" />.</exception>
		/// /// <exception cref="InvalidOperationException">Invalid user id</exception>
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