using Microsoft.AspNetCore.Mvc;
using Project.Models.Models;
using Project.Services.Services;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UsersController(IUserServices userServices)
        {
            _userServices = userServices;
        }
        [HttpGet("userId")]
        public async Task<IActionResult> GetIdUser(int userId)
        {
            var user = await _userServices.GetIdUser(userId);
            if (user == null) return BadRequest("Cannot find user");
            return Ok(user);
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Create([FromForm] UserCreate userVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var userId = await _userServices.CreateUser(userVm);
            if (userId == 0) return BadRequest();
            var user = await _userServices.GetIdUser(userId);
            return CreatedAtAction(nameof(GetIdUser), new { id = userId }, user);
        }
        [HttpPut("{userId}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Update([FromRoute] int userId, [FromForm] UserVm userVm)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            userVm.Id = userId;
            var result = await _userServices.UpdateUser(userVm);
            if (result == 0) return BadRequest();
            return Ok();
        }
        [HttpDelete("{userId}")]
        public async Task<IActionResult> Delete(int userId)
        {
            var result = await _userServices.DeleteUser(userId);
            if (result == 0) return BadRequest();
            return Ok();
        }
    }
}