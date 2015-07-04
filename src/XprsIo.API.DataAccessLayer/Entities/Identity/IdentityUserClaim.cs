﻿// //////////////////////////////////////////////////////////////////////////////////
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

namespace XprsIo.API.DataAccessLayer.Entities.Identity
{
    /// <summary>
    ///     Represents a claim associated to a user. Claims are a lightweight
    ///     data structure to attach authentication-related information to a
    ///     user.
    /// </summary>
    public class IdentityUserClaim
    {
        public class MutableIdentityUserClaimProxy
        {
            private readonly IdentityUserClaim _instance;

            public MutableIdentityUserClaimProxy(IdentityUserClaim instance)
            {
                _instance = instance;
            }

            public IdentityUserClaim Freeze()
            {
                return _instance;
            }

            public MutableIdentityUserClaimProxy SetType(string value)
            {
                _instance.Type = value;
                return this;
            }

            public MutableIdentityUserClaimProxy SetValue(string value)
            {
                _instance.Value = value;
                return this;
            }
        }

        public static readonly IdentityUserClaim Empty = new IdentityUserClaim();

        public string Type { get; private set; }
        public string Value { get; private set; }

        private IdentityUserClaim()
        {
            Type = string.Empty;
            Value = string.Empty;
        }

        public IdentityUserClaim(string type, string value)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Value cannot be default or empty", nameof(type));
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value cannot be default or empty", nameof(value));
            }

            Type = type;
            Value = value;
        }

        public MutableIdentityUserClaimProxy Mutate()
        {
            if (this == Empty)
            {
                throw new InvalidOperationException("Cannot mutate the default Empty value");
            }

            return new MutableIdentityUserClaimProxy(this);
        }
    }
}