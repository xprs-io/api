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
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven
{
	/// <summary>
	/// An ASP.NET Identity Framework 3.0 UserStore implementation for a
	/// RavenDB database. This class is only a facade. It handles boilerplate
	/// exception handling and delegates control over to a set of specialized
	/// services.
	/// </summary>
	public class UserStore :
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
		private readonly IUserService _userService;
		private readonly IRoleService _roleService;
		private readonly IUserRoleService _userRoleService;
		private readonly IUserClaimService _userClaimService;
		private readonly IUserPasswordService _userPasswordService;
		private readonly IUserSecurityStampService _userSecurityStampService;
		private readonly IUserEmailService _userEmailService;
		private readonly IUserPhoneNumberService _userPhoneNumberService;
		private readonly IQueryableRoleService _queryableRoleService;
		private readonly IQueryableUserService _queryableUserService;
		private readonly IUserLoginService _userLoginService;
		private readonly IUserTwoFactorService _userTwoFactorService;
		private readonly IUserLockoutService _userLockoutService;

		private bool _isDisposed;

		public UserStore(
			IRoleService roleService,
			IUserService userService,
			IUserRoleService userRoleService,
			IUserClaimService userClaimService,
			IUserPasswordService userPasswordService,
			IUserSecurityStampService userSecurityStampService,
			IUserEmailService userEmailService,
			IUserPhoneNumberService userPhoneNumberService,
			IQueryableRoleService queryableRoleService,
			IQueryableUserService queryableUserService,
			IUserLoginService userLoginService,
			IUserTwoFactorService userTwoFactorService,
			IUserLockoutService userLockoutService)
		{
			_userService = userService;
			_roleService = roleService;
			_userRoleService = userRoleService;
			_userClaimService = userClaimService;
			_userPasswordService = userPasswordService;
			_userSecurityStampService = userSecurityStampService;
			_userEmailService = userEmailService;
			_userPhoneNumberService = userPhoneNumberService;
			_queryableRoleService = queryableRoleService;
			_queryableUserService = queryableUserService;
			_userLoginService = userLoginService;
			_userTwoFactorService = userTwoFactorService;
			_userLockoutService = userLockoutService;
		}

		#region Implementation of IDisposable

		public void Dispose()
		{
			_isDisposed = true;
		}

		#endregion

		#region Implementation of IUserService<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userService.GetUserIdAsync(user, cancellationToken);
		}
		
		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userService.GetUserNameAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userService.SetUserNameAsync(user, userName, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userService.GetNormalizedUserNameAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userService.SetNormalizedUserNameAsync(user, normalizedName, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userService.CreateAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userService.UpdateAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userService.DeleteAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if(role == null)
            {
				throw new ArgumentNullException(nameof(role));
			}

			return _roleService.CreateAsync(role, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			return _roleService.UpdateAsync(role, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			return _roleService.DeleteAsync(role, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetRoleIdAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			return _roleService.GetRoleIdAsync(role, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			return _roleService.GetRoleNameAsync(role, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetRoleNameAsync(IdentityRole role, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			return _roleService.SetRoleNameAsync(role, roleName, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetNormalizedRoleNameAsync(IdentityRole role, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			return _roleService.GetNormalizedRoleNameAsync(role, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="role"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetNormalizedRoleNameAsync(IdentityRole role, string normalizedName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (role == null)
			{
				throw new ArgumentNullException(nameof(role));
			}

			return _roleService.SetNormalizedRoleNameAsync(role, normalizedName, cancellationToken);
		}
		
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		Task<IdentityRole> IRoleStore<IdentityRole>.FindByIdAsync(string roleId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			return _roleService.FindByIdAsync(roleId, cancellationToken);
		}

		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		Task<IdentityRole> IRoleStore<IdentityRole>.FindByNameAsync(string normalizedRoleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			return _roleService.FindByNameAsync(normalizedRoleName, cancellationToken);
		}

		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		Task<IdentityUser> IUserStore<IdentityUser>.FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			return _userService.FindByIdAsync(userId, cancellationToken);
		}

		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		Task<IdentityUser> IUserStore<IdentityUser>.FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			return _userService.FindByNameAsync(normalizedUserName, cancellationToken);
		}

		#endregion

		#region Implementation of IUserRoleService<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task AddToRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userRoleService.AddToRoleAsync(user, roleName, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task RemoveFromRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userRoleService.RemoveFromRoleAsync(user, roleName, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IList<string>> GetRolesAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userRoleService.GetRolesAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<bool> IsInRoleAsync(IdentityUser user, string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userRoleService.IsInRoleAsync(user, roleName, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IList<IdentityUser>> GetUsersInRoleAsync(string roleName, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			return _userRoleService.GetUsersInRoleAsync(roleName, cancellationToken);
		}

		#endregion

		#region Implementation of IUserClaimService<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IList<Claim>> GetClaimsAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userClaimService.GetClaimsAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="claims"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
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

			return _userClaimService.AddClaimsAsync(user, claims, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="claim"/> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="newClaim"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
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

			return _userClaimService.ReplaceClaimAsync(user, claim, newClaim, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="claims"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
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

			return _userClaimService.RemoveClaimsAsync(user, claims, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="claim"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IList<IdentityUser>> GetUsersForClaimAsync(Claim claim, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (claim == null)
			{
				throw new ArgumentNullException(nameof(claim));
			}

			return _userClaimService.GetUsersForClaimAsync(claim, cancellationToken);
		}

		#endregion

		#region Implementation of IUserPasswordService<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetPasswordHashAsync(IdentityUser user, string passwordHash, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userPasswordService.SetPasswordHashAsync(user, passwordHash, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetPasswordHashAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userPasswordService.GetPasswordHashAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<bool> HasPasswordAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userPasswordService.HasPasswordAsync(user, cancellationToken);
		}

		#endregion

		#region Implementation of IUserSecurityStampService<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetSecurityStampAsync(IdentityUser user, string stamp, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userSecurityStampService.SetSecurityStampAsync(user, stamp, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetSecurityStampAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userSecurityStampService.GetSecurityStampAsync(user, cancellationToken);
		}

		#endregion

		#region Implementation of IUserEmailService<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetEmailAsync(IdentityUser user, string email, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userEmailService.SetEmailAsync(user, email, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetEmailAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userEmailService.GetEmailAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<bool> GetEmailConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userEmailService.GetEmailConfirmedAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetEmailConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userEmailService.SetEmailConfirmedAsync(user, confirmed, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IdentityUser> FindByEmailAsync(string normalizedEmail, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			return _userEmailService.FindByEmailAsync(normalizedEmail, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetNormalizedEmailAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userEmailService.GetNormalizedEmailAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetNormalizedEmailAsync(IdentityUser user, string normalizedEmail, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userEmailService.SetNormalizedEmailAsync(user, normalizedEmail, cancellationToken);
		}

		#endregion

		#region Implementation of IUserPhoneNumberService<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetPhoneNumberAsync(IdentityUser user, string phoneNumber, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userPhoneNumberService.SetPhoneNumberAsync(user, phoneNumber, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<string> GetPhoneNumberAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userPhoneNumberService.GetPhoneNumberAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<bool> GetPhoneNumberConfirmedAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userPhoneNumberService.GetPhoneNumberConfirmedAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetPhoneNumberConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userPhoneNumberService.SetPhoneNumberConfirmedAsync(user, confirmed, cancellationToken);
		}

		#endregion

		#region Implementation of IQueryableRoleService<IdentityRole>
		
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public IQueryable<IdentityRole> Roles
		{
			get
			{
				ThrowIfDisposed();

				return _queryableRoleService.Roles;
			}
		}

		#endregion

		#region Implementation of IQueryableUserService<IdentityUser>

		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public IQueryable<IdentityUser> Users
		{
			get
			{
				ThrowIfDisposed();

				return _queryableUserService.Users;
			}
		}

		#endregion

		#region Implementation of IUserLoginService<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="login"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
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

			return _userLoginService.AddLoginAsync(user, login, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task RemoveLoginAsync(IdentityUser user, string loginProvider, string providerKey, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userLoginService.RemoveLoginAsync(user, loginProvider, providerKey, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IList<UserLoginInfo>> GetLoginsAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userLoginService.GetLoginsAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<IdentityUser> FindByLoginAsync(string loginProvider, string providerKey, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();

			return _userLoginService.FindByLoginAsync(loginProvider, providerKey, cancellationToken);
		}

		#endregion

		#region Implementation of IUserTwoFactorService<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetTwoFactorEnabledAsync(IdentityUser user, bool enabled, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userTwoFactorService.SetTwoFactorEnabledAsync(user, enabled, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<bool> GetTwoFactorEnabledAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userTwoFactorService.GetTwoFactorEnabledAsync(user, cancellationToken);
		}

		#endregion

		#region Implementation of IUserLockoutService<IdentityUser>

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<DateTimeOffset?> GetLockoutEndDateAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userLockoutService.GetLockoutEndDateAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userLockoutService.SetLockoutEndDateAsync(user, lockoutEnd, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<int> IncrementAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userLockoutService.IncrementAccessFailedCountAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task ResetAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userLockoutService.ResetAccessFailedCountAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<int> GetAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userLockoutService.GetAccessFailedCountAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task<bool> GetLockoutEnabledAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userLockoutService.GetLockoutEnabledAsync(user, cancellationToken);
		}

		/// <exception cref="OperationCanceledException">The token has had cancellation requested.</exception>
		/// <exception cref="ArgumentNullException"><paramref name="user"/> is <see langword="null" />.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:System.Threading.CancellationTokenSource" /> has been disposed.</exception>
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		public Task SetLockoutEnabledAsync(IdentityUser user, bool enabled, CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			ThrowIfDisposed();
			if (user == null)
			{
				throw new ArgumentNullException(nameof(user));
			}

			return _userLockoutService.SetLockoutEnabledAsync(user, enabled, cancellationToken);
		}

		#endregion
		
		/// <exception cref="ObjectDisposedException">The associated <see cref="T:XprsIO.API.IdentityProvider.Stores.UserService" /> has been disposed.</exception>
		private void ThrowIfDisposed()
		{
			if (_isDisposed)
			{
				throw new ObjectDisposedException(GetType().Name);
			}
		}
	}
}