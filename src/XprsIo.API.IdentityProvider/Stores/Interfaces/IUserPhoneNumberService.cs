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

using System.Threading;
using System.Threading.Tasks;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.IdentityProvider.Stores.Interfaces
{
    /// <summary>
    /// Stores a user's phoneNumber
    /// 
    /// </summary>
    public interface IUserPhoneNumberService
    {
        /// <summary>
        /// Set the user PhoneNumber
        /// 
        /// </summary>
        /// <param name="user"/><param name="phoneNumber"/><param name="cancellationToken"/>
        /// <returns/>
        Task SetPhoneNumberAsync(IdentityUser user, string phoneNumber, CancellationToken cancellationToken);

        /// <summary>
        /// Get the user phoneNumber
        /// 
        /// </summary>
        /// <param name="user"/><param name="cancellationToken"/>
        /// <returns/>
        Task<string> GetPhoneNumberAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        /// Returns true if the user phone number is confirmed
        /// 
        /// </summary>
        /// <param name="user"/><param name="cancellationToken"/>
        /// <returns/>
        Task<bool> GetPhoneNumberConfirmedAsync(IdentityUser user, CancellationToken cancellationToken);

        /// <summary>
        /// Sets whether the user phone number is confirmed
        /// 
        /// </summary>
        /// <param name="user"/><param name="confirmed"/><param name="cancellationToken"/>
        /// <returns/>
        Task SetPhoneNumberConfirmedAsync(IdentityUser user, bool confirmed, CancellationToken cancellationToken);
    }
}