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

using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Identity;
using Raven.Client;
using Raven.Client.Document;
using SimpleInjector;
using SimpleInjector.Extensions.ExecutionContextScoping;
using XprsIo.API.BusinessLayer.Interfaces;
using XprsIo.API.BusinessLayer.Services;
using XprsIo.API.DataAccessLayer.Entities.Identity;
using XprsIo.API.DataAccessLayer.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.IdentityProvider.Stores;
using XprsIo.API.IdentityProvider.Stores.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Raven;

namespace XprsIo.API
{
    public static class Bootstrap
    {
        public static void InitializeContainer(Container container, IApplicationBuilder app)
        {
            var executionContextLifestyle = new ExecutionContextScopeLifestyle();

            // RavenDB
            container.RegisterSingle<IDocumentStore>(() => new DocumentStore
            {
                Url = "http://localhost:8080",
                DefaultDatabase = "Exploration"
            }.Initialize());
            container.RegisterSingle<IContextFactory<IRavenContext>, RavenContextFactory>();
            container.RegisterSingle<IAsyncContextFactory<IAsyncRavenContext>, AsyncRavenContextFactory>();
            container.Register<IAsyncRavenContext>(() => container.GetInstance<IAsyncContextFactory<IAsyncRavenContext>>().GetAsyncContext(), executionContextLifestyle);

            container.RegisterSingle<IQueryableRoleService, QueryableRoleService>();
            container.RegisterSingle<IQueryableUserService, QueryableUserService>();
            container.RegisterSingle<IRoleClaimService, RoleClaimService>();
            container.RegisterSingle<IRoleService, RoleService>();
            container.RegisterSingle<IUserClaimService, UserClaimService>();
            container.RegisterSingle<IUserEmailService, UserEmailService>();
            container.RegisterSingle<IUserLockoutService, UserLockoutService>();
            container.RegisterSingle<IUserLoginService, UserLoginService>();
            container.RegisterSingle<IUserPasswordService, UserPasswordService>();
            container.RegisterSingle<IUserPhoneNumberService, UserPhoneNumberService>();
            container.RegisterSingle<IUserRoleService, UserRoleService>();
            container.RegisterSingle<IUserSecurityStampService, UserSecurityStampService>();
            container.RegisterSingle<IUserService, UserService>();
            container.RegisterSingle<IUserTwoFactorService, UserTwoFactorService>();

            container.RegisterSingle<IRoleStore<IdentityRole>, RoleStore>();
            container.RegisterSingle<IUserStore<IdentityUser>, UserStore>();

            // BusinessLayer
            container.RegisterSingle<ICommentsService, CommentsService>();
            container.RegisterSingle<ICommunitiesService, CommunitiesService>();
            container.RegisterSingle<IContributionsService, ContributionsService>();
            container.RegisterSingle<IMembersService, MembersService>();
            container.RegisterSingle<IParticipantsService, ParticipantsService>();
            container.RegisterSingle<ISubscriptionsService, SubscriptionsService>();
            container.RegisterSingle<ITagsService, TagsService>();
            container.RegisterSingle<IUsersService, UsersService>();
        }
    }
}