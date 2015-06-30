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

namespace XprsIo.API.DataAccessLayer.Interfaces
{
    /// <summary>
    ///     A generic factory that provides an instance of a data context. This
    ///     can be used by an DI container to inject an data context into other
    ///     services.
    /// </summary>
    /// <typeparam name="TContext">The type of the data context.</typeparam>
    public interface IContextFactory<out TContext> where TContext : IUnitOfWork
    {
        /// <summary>
        ///     Returns a new instance of a specialized
        ///     <see cref="IAsyncUnitOfWork" /> that can act as a data context.
        ///     This instance should be ready to be used and require no further
        ///     configuration.
        /// </summary>
        /// <returns>Returns a new data context.</returns>
        TContext GetContext();
    }
}