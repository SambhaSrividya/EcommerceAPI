using BackOffice.Masters.IService;
using BackOffice.Masters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BackOffice.Masters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly IRolesService _service;

        public RolesController(IRolesService service)
        {
            _service = service;
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            try { 
            var result = await _service.GetAllRolesAsync();
            return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new Error
                {
                    ErrorCode = 500,
                    ErrorDescription = ex.Message
                };
                Log.Error("ErrorCode: {ErrorCode}, ErrorDescription: {ErrorDescription}", error.ErrorCode, error.ErrorDescription);
                Log.Debug("Error object: {@Error}", error);
                return StatusCode(500, error);
            }
        }

        [HttpGet("GetRolesById/{id}")]
        public async Task<IActionResult> GetRolesById(int id)
        {
            try { 
            var result = await _service.GetRolesByIdAsync(id);
            return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new Error
                {
                    ErrorCode = 500,
                    ErrorDescription = ex.Message
                };
                Log.Error("ErrorCode: {ErrorCode}, ErrorDescription: {ErrorDescription}", error.ErrorCode, error.ErrorDescription);
                Log.Debug("Error object: {@Error}", error);
                return StatusCode(500, error);
            }
        }

        [HttpPost("AddRoles")]
        public async Task<IActionResult> CreateRoles([FromBody] Roles roles)
        {
            try { 
            var result = await _service.AddRolesAsync(roles);
            return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new Error
                {
                    ErrorCode = 500,
                    ErrorDescription = ex.Message
                };
                Log.Error("ErrorCode: {ErrorCode}, ErrorDescription: {ErrorDescription}", error.ErrorCode, error.ErrorDescription);
                Log.Debug("Error object: {@Error}", error);
                return StatusCode(500, error);
            }
        }

        [HttpPost("UpdateRoles/{id}")]
        public async Task<IActionResult> UpdateRoles(int id, [FromBody] Roles roles)
        {
            try { 
            roles.RoleId = id;
            var result = await _service.UpdateRolesAsync(roles);
            return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new Error
                {
                    ErrorCode = 500,
                    ErrorDescription = ex.Message
                };
                Log.Error("ErrorCode: {ErrorCode}, ErrorDescription: {ErrorDescription}", error.ErrorCode, error.ErrorDescription);
                Log.Debug("Error object: {@Error}", error);
                return StatusCode(500, error);
            }
        }

        [HttpDelete("DeleteRoles/{id}")]
        public async Task<IActionResult> DeleteRoles(int id)
        {
            try { 
            var result = await _service.DeleteRolesAsync(id);
            return Ok(result);
            }
            catch (Exception ex)
            {
                var error = new Error
                {
                    ErrorCode = 500,
                    ErrorDescription = ex.Message
                };
                Log.Error("ErrorCode: {ErrorCode}, ErrorDescription: {ErrorDescription}", error.ErrorCode, error.ErrorDescription);
                Log.Debug("Error object: {@Error}", error);
                return StatusCode(500, error);
            }
        }
    }
}
