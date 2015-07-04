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
    ///     Represents an external login provider (e.g. an OAuth-compatible
    ///     service like Facebook) associated to a user.
    /// </summary>
    public class IdentityUserLogin
    {
        public class MutableIdentityUserLoginProxy
        {
            private readonly IdentityUserLogin _instance;

            public MutableIdentityUserLoginProxy(IdentityUserLogin instance)
            {
                _instance = instance;
            }

            public IdentityUserLogin Freeze()
            {
                return _instance;
            }

            public MutableIdentityUserLoginProxy SetLoginProvider(string value)
            {
                _instance.LoginProvider = value;
                return this;
            }

            public MutableIdentityUserLoginProxy SetProviderDisplayName(string value)
            {
                _instance.ProviderDisplayName = value;
                return this;
            }

            public MutableIdentityUserLoginProxy SetProviderKey(string value)
            {
                _instance.ProviderKey = value;
                return this;
            }
        }

        public static readonly IdentityUserLogin Empty = new IdentityUserLogin();

        public string LoginProvider { get; private set; }
        public string ProviderDisplayName { get; private set; }
        public string ProviderKey { get; private set; }

        private IdentityUserLogin()
        {
            LoginProvider = string.Empty;
            ProviderDisplayName = string.Empty;
            ProviderKey = string.Empty;
        }

        public IdentityUserLogin(string loginProvider, string providerDisplayName, string providerKey)
        {
            if (string.IsNullOrEmpty(loginProvider))
            {
                throw new ArgumentException("Value cannot be default or empty", nameof(loginProvider));
            }

            if (string.IsNullOrEmpty(providerDisplayName))
            {
                throw new ArgumentException("Value cannot be default or empty", nameof(providerDisplayName));
            }

            if (string.IsNullOrEmpty(providerKey))
            {
                throw new ArgumentException("Value cannot be default or empty", nameof(providerKey));
            }
            
            LoginProvider = loginProvider;
            ProviderDisplayName = providerDisplayName;
            ProviderKey = providerKey;
        }

        public MutableIdentityUserLoginProxy Mutate()
        {
            if (this == Empty)
            {
                throw new InvalidOperationException("Cannot mutate the default Empty value");
            }

            return new MutableIdentityUserLoginProxy(this);
        }
    }
}