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

namespace XprsIo.API.IdentityProvider.Stores
{
    public class RoleStore :
        IRoleStore<IdentityRole>,
        IRoleClaimStore<IdentityRole>,
        IQueryableRoleStore<IdentityRole>
    {
        private readonly IRoleService _roleService;

        private readonly IRoleClaimService _roleClaimService;
        private readonly IQueryableRoleService _queryableRoleService;

        private bool _isDisposed;

        public RoleStore(
            IRoleService roleService,
            IRoleClaimService roleClaimService,
            IQueryableRoleService queryableRoleService)
        {
            _roleService = roleService;
            _roleClaimService = roleClaimService;
            _queryableRoleService = queryableRoleService;
        }

        #region Implementation of IDisposable

        public void Dispose()
        {
            _isDisposed = true;
        }

        #endregion

        #region Implementation of IRoleStore<IdentityRole>

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> is <see langword="null" /> .
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="CancellationTokenSource" /> has been
        ///     disposed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated
        ///     <see cref="XprsIO.API.IdentityProvider.Stores.UserService" /> has
        ///     been disposed.
        /// </exception>
        public async Task<IdentityResult> CreateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            await _roleService.CreateAsync(role, cancellationToken).ConfigureAwait(false);

            return IdentityResult.Success;
        }

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> is <see langword="null" /> .
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="CancellationTokenSource" /> has been
        ///     disposed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated
        ///     <see cref="XprsIO.API.IdentityProvider.Stores.UserService" /> has
        ///     been disposed.
        /// </exception>
        public async Task<IdentityResult> UpdateAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            await _roleService.UpdateAsync(role, cancellationToken).ConfigureAwait(false);

            return IdentityResult.Success;
        }

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> is <see langword="null" /> .
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="CancellationTokenSource" /> has been
        ///     disposed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated
        ///     <see cref="XprsIO.API.IdentityProvider.Stores.UserService" /> has
        ///     been disposed.
        /// </exception>
        public async Task<IdentityResult> DeleteAsync(IdentityRole role, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            await _roleService.DeleteAsync(role, cancellationToken).ConfigureAwait(false);

            return IdentityResult.Success;
        }

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> is <see langword="null" /> .
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="CancellationTokenSource" /> has been
        ///     disposed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated
        ///     <see cref="XprsIO.API.IdentityProvider.Stores.UserService" /> has
        ///     been disposed.
        /// </exception>
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

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> is <see langword="null" /> .
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="CancellationTokenSource" /> has been
        ///     disposed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated
        ///     <see cref="XprsIO.API.IdentityProvider.Stores.UserService" /> has
        ///     been disposed.
        /// </exception>
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

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> is <see langword="null" /> .
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="CancellationTokenSource" /> has been
        ///     disposed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated
        ///     <see cref="XprsIO.API.IdentityProvider.Stores.UserService" /> has
        ///     been disposed.
        /// </exception>
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

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> is <see langword="null" /> .
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="CancellationTokenSource" /> has been
        ///     disposed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated
        ///     <see cref="XprsIO.API.IdentityProvider.Stores.UserService" /> has
        ///     been disposed.
        /// </exception>
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

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> is <see langword="null" /> .
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="CancellationTokenSource" /> has been
        ///     disposed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated
        ///     <see cref="XprsIO.API.IdentityProvider.Stores.UserService" /> has
        ///     been disposed.
        /// </exception>
        public Task SetNormalizedRoleNameAsync(
            IdentityRole role,
            string normalizedName,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            return _roleService.SetNormalizedRoleNameAsync(role, normalizedName, cancellationToken);
        }

        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="CancellationTokenSource" /> has been
        ///     disposed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated
        ///     <see cref="XprsIO.API.IdentityProvider.Stores.UserService" /> has
        ///     been disposed.
        /// </exception>
        public Task<IdentityRole> FindByIdAsync(string roleId, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            return _roleService.FindByIdAsync(roleId, cancellationToken);
        }

        /// <exception cref="ObjectDisposedException">
        ///     The associated <see cref="CancellationTokenSource" /> has been
        ///     disposed.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The associated
        ///     <see cref="XprsIO.API.IdentityProvider.Stores.UserService" /> has
        ///     been disposed.
        /// </exception>
        public Task<IdentityRole> FindByNameAsync(
            string normalizedRoleName,
            CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();

            return _roleService.FindByNameAsync(normalizedRoleName, cancellationToken);
        }
        
        #endregion

        #region Implementation of IRoleClaimStore<IdentityRole>

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The store as been marked as disposed and should be not used anymore.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> is <see langword="null" /> .
        /// </exception>
        public Task<IList<Claim>> GetClaimsAsync(IdentityRole role, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            return _roleClaimService.GetClaimsAsync(role, cancellationToken);
        }

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The store as been marked as disposed and should be not used anymore.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> or <paramref name="claim"/> is <see langword="null" /> .
        /// </exception>
        public Task AddClaimAsync(IdentityRole role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }

            return _roleClaimService.AddClaimAsync(role, claim, cancellationToken);
        }

        /// <exception cref="OperationCanceledException">
        ///     The token has had cancellation requested.
        /// </exception>
        /// <exception cref="ObjectDisposedException">
        ///     The store as been marked as disposed and should be not used anymore.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="role" /> or <paramref name="claim"/> is <see langword="null" /> .
        /// </exception>
        public Task RemoveClaimAsync(IdentityRole role, Claim claim, CancellationToken cancellationToken = new CancellationToken())
        {
            cancellationToken.ThrowIfCancellationRequested();
            ThrowIfDisposed();
            if (role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            if (claim == null)
            {
                throw new ArgumentNullException(nameof(claim));
            }

            return _roleClaimService.RemoveClaimAsync(role, claim, cancellationToken);
        }

        #endregion

        #region Implementation of IQueryableRoleStore<IdentityRole>

        /// <exception cref="ObjectDisposedException" accessor="get">
        ///     The store as been marked as disposed and should be not used anymore.
        /// </exception>
        public IQueryable<IdentityRole> Roles
        {
            get
            {
                ThrowIfDisposed();

                return _queryableRoleService.Roles;
            }
        }

        #endregion

        /// <exception cref="ObjectDisposedException">
        ///     The store as been marked as disposed and should be not used anymore.
        /// </exception>
        private void ThrowIfDisposed()
        {
            if (_isDisposed)
            {
                throw new ObjectDisposedException(GetType().Name);
            }
        }
    }
}