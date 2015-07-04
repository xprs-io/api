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

namespace XprsIo.API.DataAccessLayer.Entities.Identity
{
    /// <summary>
    /// Represents an email associated to a user
    /// </summary>
    public class IdentityUserEmail
    {
        public class MutableIdentityUserEmailProxy
        {
            private readonly IdentityUserEmail _instance;

            public MutableIdentityUserEmailProxy(IdentityUserEmail instance)
            {
                _instance = instance;
            }

            public IdentityUserEmail Freeze()
            {
                return _instance;
            }

            public MutableIdentityUserEmailProxy SetEmail(string value)
            {
                _instance.Email = value;
                return this;
            }

            public MutableIdentityUserEmailProxy SetConfirmed(bool value)
            {
                _instance.IsConfirmed = value;
                return this;
            }

            public MutableIdentityUserEmailProxy SetPrimary(bool value)
            {
                _instance.IsPrimary = value;
                return this;
            }
        }

        public static readonly IdentityUserEmail Empty = new IdentityUserEmail();

        public string Email { get; private set; }
        public bool IsConfirmed { get; private set; }
        public bool IsPrimary { get; private set; }

        private IdentityUserEmail()
        {
            Email = string.Empty;
        }

        public IdentityUserEmail(string email, bool isConfirmed, bool isPrimary)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Value cannot be default or empty", nameof(email));
            }

            Email = email;
            IsConfirmed = isConfirmed;
            IsPrimary = isPrimary;
        }

        public MutableIdentityUserEmailProxy Mutate()
        {
            if (this == Empty)
            {
                throw new InvalidOperationException("Cannot mutate the default Empty value");
            }

            return new MutableIdentityUserEmailProxy(this);
        }
    }
}