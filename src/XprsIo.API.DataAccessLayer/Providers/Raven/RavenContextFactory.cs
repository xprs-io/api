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

using Raven.Client;
using XprsIo.API.DataAccessLayer.Interfaces;
using XprsIo.API.DataAccessLayer.Providers.Raven.Interfaces;

namespace XprsIo.API.DataAccessLayer.Providers.Raven
{
	/// <summary>
	/// A data context factory for the RavenDB data source.
	/// </summary>
	public class RavenContextFactory : IContextFactory<IRavenContext>
    {
        private readonly IDocumentStore _store;

        public RavenContextFactory(IDocumentStore store)
        {
            _store = store;
        }

        public IRavenContext GetContext()
        {
            return new RavenContext(_store.OpenSession());
        }
    }
}