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
using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using XprsIo.API.BusinessLayer.Entities;

namespace XprsIo.API.Controllers
{
    [Route("api/[controller]")]
    public class ContributionsController
    {
        private const string RouteById = "{id:int}";

        [HttpPost]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IEnumerable<Contribution> Read()
        {
            throw new NotImplementedException();
        }

        [HttpGet(RouteById)]
        public IEnumerable<Contribution> Read(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut(RouteById)]
        public IActionResult Update(int id, [FromBody] Contribution user)
        {
            throw new NotImplementedException();
        }

        [HttpDelete(RouteById)]
        public IActionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}