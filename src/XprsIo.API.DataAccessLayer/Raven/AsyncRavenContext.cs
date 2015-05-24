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