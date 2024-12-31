using BackOffice.Masters.IRepository;
using BackOffice.Masters.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Serilog;
using System.Data;

namespace BackOffice.Masters.Repository
{
    public class ServicesRepository:IServices
    {
        private readonly IConfiguration _configuration;

        public ServicesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ServicesResponse> GetAllServicesAsync()
        {
            var response=new ServicesResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var StoredProcedure = "GetAllServices";
                var res = await connection.QueryAsync<Services>(StoredProcedure);
                response.services=res.ToList();
                return response;
            }
            catch (Exception ex)
            {
                response.Error = new Error
                {
                    ErrorCode = 500,
                    ErrorDescription = ex.Message
                };
                Log.Error("{@Error}", response.Error);
                return response;
            }
        }

        public async Task<ServicesResponse> GetServicesByIdAsync(int id)
        {
            var response = new ServicesResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var res = await connection.QueryAsync<Services>("GetServicesById",
                    new { ServiceId = id }, commandType: System.Data.CommandType.StoredProcedure);
                response.services = res.ToList();
                return response;
            }
            catch (Exception ex)
            {
                response.Error = new Error
                {
                    ErrorCode = 500,
                    ErrorDescription = ex.Message
                };
                Log.Error("{@Error}", response.Error);
                return response;
            }
        }
        public async Task<ServicesResponse> AddServicesAsync(Services services)
        {
            var response= new ServicesResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var res = await connection.ExecuteAsync(
                "CreateServices",
                new
                {
                    services.Name,
                    services.Status,
                    services.CreatedDate,
                    services.CreatedBy,
                    services.UpdateDate,
                    services.UpdatedBy,
                    services.TenantId
                },
                    commandType: System.Data.CommandType.StoredProcedure);
                response.services = new List<Services> { services };
                return response;
            }
            catch (Exception ex)
            {
                response.Error = new Error
                {
                    ErrorCode = 500,
                    ErrorDescription = ex.Message
                };
                Log.Error("{@Error}", response.Error);
                return response;
            }
        }
        public async Task<ServicesResponse> UpdateServicesAsync(Services services)
        {
            var response= new ServicesResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var res = await connection.ExecuteAsync(
                    "UpdateServices",
                    new
                    {
                        services.ServiceId,
                        services.Name,
                        services.Status,
                        services.UpdateDate,
                        services.UpdatedBy,
                        services.TenantId
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
                response.services = new List<Services> { services };
                return response;
            }
            catch (Exception ex)
            {
                response.Error = new Error
                {
                    ErrorCode = 500,
                    ErrorDescription = ex.Message
                };
                Log.Error("{@Error}", response.Error);
                return response;
            }
        }
        public async Task<ServicesResponse> DeleteServicesAsync(int id)
        {
            var response = new ServicesResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var res = await connection.ExecuteAsync(
                    "DeleteServices",
                    new { ServiceId = id },
                    commandType: System.Data.CommandType.StoredProcedure);
                return response;
            }
            catch (Exception ex)
            {
                response.Error = new Error
                {
                    ErrorCode = 500,
                    ErrorDescription = ex.Message
                };
                Log.Error("{@Error}", response.Error);
                return response;
            }
        }
    }
}
