using BackOffice.Masters.IService;
using BackOffice.Masters.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace BackOffice.Masters.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyDetailsController : ControllerBase
    {
        private readonly ICompanyDetailsService _service;

        public CompanyDetailsController(ICompanyDetailsService service)
        {
            _service = service;
        }

        [HttpGet("GetAllCompanyDetails")]
        public async Task<IActionResult> GetAllCompanyDetails()
        {
            try { 
            var result = await _service.GetAllCompanyDetailsAsync();
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

        [HttpGet("GetCompanyDetailsById/{id}")]
        public async Task<IActionResult> GetCompanyDetailsById(int id)
        {
            try { 
            var result=await _service.GetCompanyDetailsByIdAsync(id);
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

        [HttpPost("AddCompanyDetails")]
        public async Task<IActionResult> CreateCompanyDetails([FromBody]CompanyDetails companyDetails)
        {
            try { 
            var result=await _service.AddCompanyDetailsAsync(companyDetails);
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

        [HttpPost("UpdateCompanyDetails/{id}")]
        public async Task<IActionResult> UpdateCompanyDetails(int id, [FromBody] CompanyDetails companydetails)
        {
            try { 
            companydetails.CompanyId=id;
            var result=await _service.UpdateCompanyDetailsAsync(companydetails);
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

        [HttpDelete("DeleteCompanyDetails/{id}")]
        public async Task<IActionResult> DeleteCompanyDetails(int id)
        {
            try { 
            var result=await _service.DeleteCompanyDetailsAsync(id);
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
