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
using System.Threading;
using System.Threading.Tasks;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.IdentityProvider.Stores.Interfaces
{
    /// <summary>
    /// Stores information which can be used to implement account lockout,
    /// including access failures and lockout status
    /// 
    /// </summary>
    public interface IUserLockoutService
    {
        /// <summary>
        /// Returns the DateTimeOffset that represents the end of a user's lockout, any time in the past should be
        ///             considered not locked out.
        /// 
        /// </summary>
        /// <param name="user"/><param name="cancellationToken"/>
        /// <returns/>
        Task<DateTimeOffset?> GetLockoutEndDateAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        /// Locks a user out until the specified end date (set to a past date, to unlock a user)
        /// 
        /// </summary>
        /// <param name="user"/><param name="lockoutEnd"/><param name="cancellationToken"/>
        /// <returns/>
        Task SetLockoutEndDateAsync(IdentityUser user, DateTimeOffset? lockoutEnd, CancellationToken cancellationToken);

        /// <summary>
        /// Used to record when an attempt to access the user has failed
        /// 
        /// </summary>
        /// <param name="user"/><param name="cancellationToken"/>
        /// <returns/>
        Task<int> IncrementAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        /// Used to reset the account access count, typically after the account is successfully accessed
        /// 
        /// </summary>
        /// <param name="user"/><param name="cancellationToken"/>
        /// <returns/>
        Task ResetAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        /// Returns the current number of failed access attempts.  This number usually will be reset whenever the
        ///             password is verified or the account is locked out.
        /// 
        /// </summary>
        /// <param name="user"/><param name="cancellationToken"/>
        /// <returns/>
        Task<int> GetAccessFailedCountAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        /// Returns whether the user can be locked out.
        /// 
        /// </summary>
        /// <param name="user"/><param name="cancellationToken"/>
        /// <returns/>
        Task<bool> GetLockoutEnabledAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        /// Sets whether the user can be locked out.
        /// 
        /// </summary>
        /// <param name="user"/><param name="enabled"/><param name="cancellationToken"/>
        /// <returns/>
        Task SetLockoutEnabledAsync(IdentityUser user, bool enabled, CancellationToken cancellationToken);
    }
}