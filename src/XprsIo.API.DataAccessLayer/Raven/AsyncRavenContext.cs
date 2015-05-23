﻿// //////////////////////////////////////////////////////////////////////////////////&#xD;
// Licensed under the Apache License, Version 2.0 (the "License");&#xD;
// you may not use this file except in compliance with the License.&#xD;
// You may obtain a copy of the License at&#xD;
// &#xD;
//     http://www.apache.org/licenses/LICENSE-2.0&#xD;
// &#xD;
// Unless required by applicable law or agreed to in writing, software&#xD;
// distributed under the License is distributed on an "AS IS" BASIS,&#xD;
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.&#xD;
// See the License for the specific language governing permissions and&#xD;
// limitations under the License.&#xD;
// //////////////////////////////////////////////////////////////////////////////////

using System.Threading;
using System.Threading.Tasks;
using Raven.Client;
using XprsIo.API.DataAccessLayer.Interfaces;

namespace XprsIo.API.DataAccessLayer.Raven
{
    public class AsyncRavenContext : IAsyncRavenContext
    {
        private readonly IAsyncDocumentSession _session;

        public AsyncRavenContext(IAsyncDocumentSession session)
        {
            _session = session;
        }

        public Task SaveChangesAsync()
        {
            return _session.SaveChangesAsync();
        }

        public Task SaveChangesAsync(CancellationToken ct)
        {
            return _session.SaveChangesAsync(ct);
        }

        public void Dispose()
        {
            _session.Dispose();
        }
    }
}