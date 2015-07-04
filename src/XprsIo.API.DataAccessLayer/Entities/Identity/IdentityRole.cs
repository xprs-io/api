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

namespace XprsIo.API.DataAccessLayer.Entities.Identity
{
    /// <summary>
    ///     Regroup users under a common banner to manage access rights. For
    ///     instance, the "admin" role or the "user" role.
    /// </summary>
    public class IdentityRole
    {
        public class MutableIdentityRoleProxy
        {
            private readonly IdentityRole _instance;

            public MutableIdentityRoleProxy(IdentityRole instance)
            {
                _instance = instance;
            }

            public IdentityRole Freeze()
            {
                return _instance;
            }

            public MutableIdentityRoleProxy SetId(int value)
            {
                _instance.Id = value;
                return this;
            }

            public MutableIdentityRoleProxy SetName(string value)
            {
                _instance.Name = value;
                return this;
            }

            public MutableIdentityRoleProxy SetClaims(ICollection<IdentityRoleClaim> value)
            {
                _instance.Claims = value;
                return this;
            }
        }

        public static readonly IdentityRole Empty = new IdentityRole();

        public int Id { get; private set; }
        public string Name { get; private set; }

        public ICollection<IdentityRoleClaim> Claims { get; private set; }

        private IdentityRole()
        {
            Name = string.Empty;
            Claims = new List<IdentityRoleClaim>();
        }

        public IdentityRole(int id, string name, ICollection<IdentityRoleClaim> claims)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Value cannot be default or empty", nameof(name));
            }

            Id = id;
            Name = name;
            Claims = claims ?? new IdentityRoleClaim[0];
        }

        public MutableIdentityRoleProxy Mutate()
        {
            if (this == Empty)
            {
                throw new InvalidOperationException("Cannot mutate the default Empty value");
            }

            return new MutableIdentityRoleProxy(this);
        }
    }
}