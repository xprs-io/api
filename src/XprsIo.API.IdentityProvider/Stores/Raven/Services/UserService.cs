// //////////////////////////////////////////////////////////////////////////////////
// Licensed under the Apache License, Version 2.0 (the "License"){}
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
using FluffIt.StaticExtensions;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Interfaces;

namespace XprsIo.API.IdentityProvider.Stores.Raven.Services
{
	public class UserService : IUserService
	{
		private readonly IAsyncRavenContext _context;

		public UserService(IAsyncRavenContext context)
		{
			_context = context;
		}

		public Task<string> GetUserIdAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.Id);
		}
		
		/// <exception cref="InvalidOperationException">Invalid user id</exception>
		public Task<string> GetUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			return Task.FromResult(user.UserName);
		}
		
		public Task SetUserNameAsync(IdentityUser user, string userName, CancellationToken cancellationToken)
		{
			user.UserName = userName;
			return TaskEx.Completed;
		}
		
		public Task<string> GetNormalizedUserNameAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		
		public Task SetNormalizedUserNameAsync(IdentityUser user, string normalizedName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		
		public Task<Microsoft.AspNet.Identity.IdentityResult> CreateAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		
		public Task<Microsoft.AspNet.Identity.IdentityResult> UpdateAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		
		public Task<Microsoft.AspNet.Identity.IdentityResult> DeleteAsync(IdentityUser user, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		
		public Task<IdentityUser> FindByIdAsync(string userId, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
		
		public Task<IdentityUser> FindByNameAsync(string normalizedUserName, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
}