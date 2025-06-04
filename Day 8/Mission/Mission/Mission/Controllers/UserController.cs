using Microsoft.AspNetCore.Mvc;
using Mission.Entities;
using Mission.Services.IServices;
using Mission.Entities.Models;

namespace Mission.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;

        [HttpDelete]
        public async Task<IActionResult> DeleteUser([FromQuery] int id)
        {
            try
            {
                var res = await _userService.DeleteUser(id);
                return Ok(new ResponseResult() { Data = "User deleted successfully.", Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to delete user." });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetUserById([FromQuery] int id)
        {
            try
            {
                var res = await _userService.GetUserById(id);
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "" });
            }
            catch
            {
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = "Failed to find user." });
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser([FromQuery] int id, [FromBody] UserRequestModel model)
        {
            try
            {
                var res = await _userService.UpdateUser(id, model);
                return Ok(new ResponseResult() { Data = res, Result = ResponseStatus.Success, Message = "User updated successfully." });
            }
            catch (Exception ex)
            {
                // Show detailed error message for debugging (remove in production)
                return BadRequest(new ResponseResult() { Data = null, Result = ResponseStatus.Error, Message = $"Failed to update user: {ex.Message}" });
            }
        }
    }
}
