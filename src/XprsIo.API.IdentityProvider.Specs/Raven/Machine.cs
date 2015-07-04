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
using XprsIo.API.IdentityProvider.Stores.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Raven;

namespace XprsIo.API.IdentityProvider.Specs.Raven
{
    /// <summary>Base context for all IdentityProvider specifications.</summary>
    public static class Machine
    {
        private static readonly Container BuilderContainer;
        private static readonly Container ServiceContainer;

        static Machine()
        {
            BuilderContainer = new Container();
            ServiceContainer = new Container();

            InitializeBuilderContainer(BuilderContainer);
            InitializeServiceContainer(ServiceContainer);

            BuilderContainer.Verify();
            ServiceContainer.Verify();
        }

        private static void InitializeBuilderContainer(Container container)
        {
            container.Register<IdentityRoleClaim>(() => new IdentityRoleClaimBuilder().WithType(DefaultKey));
            container.Register<IdentityUserEmail>(() => new IdentityUserEmailBuilder().WithEmail(DefaultEmail));
            container.Register<IdentityUserClaim>(() => new IdentityUserClaimBuilder().WithType(DefaultKey));
            container.Register<IdentityUserLogin>(() => new IdentityUserLoginBuilder().WithProviderKey(DefaultKey));
            container.Register<IdentityRole>(() => new IdentityRoleBuilder(null).WithId(DefaultId));
            container.Register<IdentityUser>(() => new IdentityUserBuilder(null, null, null, null).WithId(DefaultGuid));

            container.Register<IdentityRoleClaimBuilder>();
            container.Register<IdentityUserEmailBuilder>();
            container.Register<IdentityUserClaimBuilder>();
            container.Register<IdentityUserLoginBuilder>();
            container.Register<IdentityRoleBuilder>();
            container.Register<IdentityUserBuilder>();
        }

        private static void InitializeServiceContainer(Container container)
        {
            container.Register(() => Mock.Of<IAsyncRavenContext>());

            container.Register<IUserService, UserService>();
        }
        
        public static TService GetService<TService>() where TService : class
            => ServiceContainer.GetInstance<TService>();

        public static Guid DefaultGuid => new Guid("6574bd30-da34-4c90-9571-91c48e6a5c4c");
        public static string DefaultEmail => "specs@example.com";
        public static string DefaultKey => "key";
        public static int DefaultId => 1;
        
        public static IdentityUserBuilder IdentityUser
            => BuilderContainer.GetInstance<IdentityUserBuilder>();
    }
}