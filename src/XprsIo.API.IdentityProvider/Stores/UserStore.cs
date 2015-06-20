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
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores
{
	public class UserStore : IUserStore<IdentityUser>,
		IUserRoleStore<IdentityUser>,
		IUserClaimStore<IdentityUser>,
		IUserPasswordStore<IdentityUser>,
		IUserSecurityStampStore<IdentityUser>,
		IUserEmailStore<IdentityUser>,
		IUserPhoneNumberStore<IdentityUser>,
		IQueryableRoleStore<IdentityRole>,
		IQueryableUserStore<IdentityUser>,
		IUserLoginStore<IdentityUser>,
		IUserTwoFactorStore<IdentityUser>,
		IUserLockoutStore<IdentityUser>
	{
		private readonly IAsyncRavenContext _context;
		private bool _isDisposed;

		public UserStore(IAsyncRavenContext context)
		{
			_context = context;
		}

		#region Implementation of IDisposable

		public void Dispose()
		{
			_isDisposed = true;
		}

		#endregion

		#region Implementation of IUserStore<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return Task.FromResult(user.Id);
		}

		/// <exception cref="InvalidOperationException">Invalid user id</exception>
		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			var usernamePos = user.Id.IndexOf('/');

			if (usernamePos < 0)
			{
				throw new InvalidOperationException("Invalid user id");
			}

			var username = user.Id.Remove(0, usernamePos + 1);

			return Task.FromResult(username);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if(role == null)
            {
				throw new ArgumentNullException(nameof(role));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			throw new NotImplementedException();
		}
		
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		Task<IdentityRole> IRoleStore<IdentityRole>.FindByIdAsync(string roleId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			throw new NotImplementedException();
		}

		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		Task<IdentityRole> IRoleStore<IdentityRole>.FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			throw new NotImplementedException();
		}

		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		Task<IdentityUser> IUserStore<IdentityUser>.FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			throw new NotImplementedException();
		}

		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		Task<IdentityUser> IUserStore<IdentityUser>.FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IUserRoleStore<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task AddToRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task RemoveFromRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IList<string>> GetRolesAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<bool> IsInRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IList<IdentityUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IUserClaimStore<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IList<Claim>> GetClaimsAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="claims"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task AddClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			if (claims == null)
			{
				throw new ArgumentNullException(nameof(claims));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="claim"/> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="newClaim"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task ReplaceClaimAsync(IdentityUser user, Claim claim, Claim newClaim, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			if (claim == null)
			{
				throw new ArgumentNullException(nameof(claim));
			}
			if (newClaim == null)
			{
				throw new ArgumentNullException(nameof(newClaim));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="claims"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task RemoveClaimsAsync(IdentityUser user, IEnumerable<Claim> claims, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			if (claims == null)
			{
				throw new ArgumentNullException(nameof(claims));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="claim"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IList<IdentityUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (claim == null)
			{
				throw new ArgumentNullException(nameof(claim));
			}

			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IUserPasswordStore<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IUserSecurityStampStore<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetSecurityStampAsync(IdentityUser user, string stamp, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetSecurityStampAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IUserEmailStore<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetEmailAsync(IdentityUser user, string email, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IdentityUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetNormalizedEmailAsync(IdentityUser user, string normalizedEmail, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IUserPhoneNumberStore<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetPhoneNumberAsync(IdentityUser user, string phoneNumber, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<string> GetPhoneNumberAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<bool> GetPhoneNumberConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetPhoneNumberConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IQueryableRoleStore<IdentityRole>
		
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public IQueryable<IdentityRole> Roles
		{
			get
			{
				ThrowIfDisposed();

				throw new NotImplementedException();
			}
		}

		#endregion

		#region Implementation of IQueryableUserStore<IdentityUser>

		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public IQueryable<IdentityUser> Users
		{
			get
			{
				ThrowIfDisposed();

				throw new NotImplementedException();
			}
		}

		#endregion

		#region Implementation of IUserLoginStore<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="login"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task AddLoginAsync(IdentityUser user, UserLoginInfo login, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}
			if (login == null)
			{
				throw new ArgumentNullException(nameof(login));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task RemoveLoginAsync(IdentityUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<IdentityUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IUserTwoFactorStore<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		#endregion

		#region Implementation of IUserLockoutStore<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<DateTimeOffset?> GetLockoutEndDateAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<int> IncrementAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task ResetAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<int> GetAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task<bool> GetLockoutEnabledAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		public Task SetLockoutEnabledAsync(IdentityUser user, bool enabled, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			throw new NotImplementedException();
		}

		#endregion
		
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserStore" /> has been disposed.</exception>
		private void ThrowIfDisposed()
		{
			if (_isDisposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
		}
	}
}