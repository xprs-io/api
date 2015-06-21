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
using Raven.Imports.Newtonsoft.Json;

namespace XprsIo.API.DataAccessLayer.Entities.Identity
{
	public class IdentityUser
	{
		private const string RavenIndexName = "IdentityUsers/";

		public string Id { get; set; }

		/// <exception cref="InvalidOperationException" accessor="get">Invalid user id</exception>
		[JsonIgnore]
		public string UserName
		{
			get
			{
				if (Id == null || !Id.StartsWith(RavenIndexName))
				{
					throw new InvalidOperationException("Invalid user id");
				}

				return Id.Remove(0, RavenIndexName.Length);
			}
			set { Id = value; }
		}

		public string PasswordHash { get; set; }
		public string PhoneNumber { get; set; }
		

		public bool IsActive { get; set; }
		public bool IsPhoneNumberConfirmed { get; set; }
		public bool IsTwoFactorEnabled { get; set; }

		public int AccessFailedCount { get; set; }
		public bool IsLockoutEnabled { get; set; }
		public DateTime? LockedEndDateUtc { get; set; }

		public string SecurityStamp { get; set; }

		public ICollection<IdentityUserLogin> Logins { get; set; }
		public ICollection<IdentityRole> Roles { get; set; }
		public ICollection<IdentityUserClaim> Claims { get; set; }
	}
}