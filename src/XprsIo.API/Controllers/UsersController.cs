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
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Mvc;
using XprsIo.API.BusinessLayer.Entities;
using XprsIo.API.DataAccessLayer.Entities.Identity;

namespace XprsIo.API.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private const string RouteById = "{id:int}";

        public readonly UserManager<IdentityUser> _userManager;
        public readonly SignInManager<IdentityUser> _signInManager;

        public UsersController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> SignIn()
        {
            var result = await _signInManager.PasswordSignInAsync("debug@example.com", "no password", false, false);

            if (result.Succeeded)
            {
                return Json(true);
            }

            return Json(false);
        }

        [HttpPost]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<User> Read()
        {
            throw new NotImplementedException();
        }

        [HttpGet(RouteById)]
        public IEnumerable<User> Read(int id)
        {
            throw new NotImplementedException();
        }

        [HttpPut(RouteById)]
        public IActionResult Update(int id, [FromBody] User user)
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