using BackOffice.Masters.IService;
using BackOffice.Masters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BackOffice.Masters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _service;

        public ServicesController(IServicesService service)
        {
            _service = service;
        }

        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            try { 
            var result = await _service.GetAllServicesAsync();
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

        [HttpGet("GetServicesById/{id}")]
        public async Task<IActionResult> GetServicesById(int id)
        {
            try { 
            var result = await _service.GetServicesByIdAsync(id);
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

        [HttpPost("AddServices")]
        public async Task<IActionResult> CreateServices([FromBody] Services services)
        {
            try { 
            var result = await _service.AddServicesAsync(services);
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

        [HttpPost("UpdateServices/{id}")]
        public async Task<IActionResult> UpdateServices(int id, [FromBody] Services services)
        {
            try { 
            services.ServiceId = id;
            var result = await _service.UpdateServicesAsync(services);
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

        [HttpDelete("DeleteServices/{id}")]
        public async Task<IActionResult> DeleteServices(int id)
        {
            try { 
            var result = await _service.DeleteServicesAsync(id);
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
