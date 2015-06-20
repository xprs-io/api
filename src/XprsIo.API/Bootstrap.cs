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
using Raven.Client;
using Raven.Client.Document;
using SimpleInjector;
using XprsIo.API.BusinessLayer.Interfaces;
using XprsIo.API.BusinessLayer.Services;
using XprsIo.API.DataAccessLayer.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;

namespace XprsIo.API
{
    public static class Bootstrap
    {
        public static void InitializeContainer(Container container, IApplicationBuilder app)
        {
            // RavenDB
            container.RegisterSingle<IDocumentStore>(() => new DocumentStore
            {
                // TODO: Configure store
            });
            container.RegisterSingle<IContextFactory<IRavenContext>, RavenContextFactory>();
            container.RegisterSingle<IAsyncContextFactory<IAsyncRavenContext>, AsyncRavenContextFactory>();

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