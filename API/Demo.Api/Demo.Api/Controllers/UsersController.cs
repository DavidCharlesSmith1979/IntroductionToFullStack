using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Api.Models;
using Demo.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger<UsersController> _logger;
        private readonly ICreateUserService _createUserService;
        private readonly IGetUserService _getUserService;
        private readonly IGetUsersService _getUsersService;
        private readonly IDeleteUserService _deleteUserService;
        private readonly IUpdateUserService _updateUserService;

        public UsersController(ILogger<UsersController> logger,
            ICreateUserService createUserService,
            IGetUserService getUserService,
            IGetUsersService getUsersService,
            IDeleteUserService deleteUserService,
            IUpdateUserService updateUserService)
        {
            _logger = logger;
            _createUserService = createUserService;
            _getUserService = getUserService;
            _getUsersService = getUsersService;
            _deleteUserService = deleteUserService;
            _updateUserService = updateUserService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _getUsersService.Get());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(long id)
        {
            return Ok(await _getUserService.Get(id));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            return Ok(await _deleteUserService.Delete(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]User user)
        {
            return Ok(await _createUserService.Create(user));
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] User user)
        {
            return Ok(await _updateUserService.Update(user));
        }
    }
}
