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

using Moq;
using SimpleInjector;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Interfaces;
using XprsIo.API.IdentityProvider.Stores.Raven.Services;

namespace XprsIo.API.IdentityProvider.Specs.Raven
{
    /// <summary>
    /// Base context for all IdentityProvider specifications.
    /// </summary>
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
            container.Register<IAsyncRavenContext>(() => Mock.Of<IAsyncRavenContext>());

            container.Register<IUserService, UserService>();
        }

        /// <summary>
        /// Gets an instance of the given <typeparamref name="TService" /> .
        /// </summary>
        /// <exception cref="ActivationException">
        /// Thrown when there are errors resolving the service instance.
        /// </exception>
        /// <returns>
        /// Returns an instance of <typeparamref name="TService" /> according
        /// to the registration lifetime.
        /// </returns>
        public static TService GetInstance<TService>() where TService : class
        {
            return Container.GetInstance<TService>();
        }
    }
}