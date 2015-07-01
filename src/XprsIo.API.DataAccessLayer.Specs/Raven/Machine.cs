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
using Moq;
using SimpleInjector;
using XprsIo.API.DataAccessLayer.Builders;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;

namespace XprsIo.API.DataAccessLayer.Specs.Raven
{
    /// <summary>Base context for all IdentityProvider specifications.</summary>
    public static class Machine
    {
        private static readonly Container Container;

        static Machine()
        {
            Container = new Container();

            InitializeContainer(Container);

            Container.Verify();
        }

        private static void InitializeContainer(Container container)
        {
            container.Register(() => Mock.Of<IAsyncRavenContext>());
        }

        /// <summary>
        ///     Gets an instance of the given <typeparamref name="TService" /> .
        /// </summary>
        /// <exception cref="ActivationException">
        ///     Thrown when there are errors resolving the service instance.
        /// </exception>
        /// <returns>
        ///     Returns an instance of <typeparamref name="TService" />
        ///     according to the registration lifetime.
        /// </returns>
        public static TService GetInstance<TService>() where TService : class
            => Container.GetInstance<TService>();
        
        public static Guid DefaultGuid => new Guid("6574bd30-da34-4c90-9571-91c48e6a5c4c");
        public static string DefaultEmail => "specs@example.com";
        public static string DefaultKey => "key";
        public static int DefaultId => 1;

        public static IdentityUserEmailBuilder IdentityUserEmail
            => new IdentityUserEmailBuilder(new IdentityUserEmail { Email = DefaultEmail });
        public static IdentityUserClaimBuilder IdentityUserClaim
            => new IdentityUserClaimBuilder(new IdentityUserClaim { Key = DefaultKey });
        public static IdentityUserLoginBuilder IdentityUserLogin
            => new IdentityUserLoginBuilder(new IdentityUserLogin { ProviderKey = DefaultKey });
        public static IdentityRoleBuilder IdentityRole
            => new IdentityRoleBuilder(new IdentityRole { Id = DefaultId });
        public static IdentityUserBuilder IdentityUser
            => new IdentityUserBuilder(
                () => IdentityUserEmail,
                () => IdentityUserLogin,
                () => IdentityRole,
                () => IdentityUserClaim,
                new IdentityUser { Id = DefaultGuid }
            );
    }
}