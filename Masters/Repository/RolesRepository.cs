using BackOffice.Masters.IRepository;
using BackOffice.Masters.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Serilog;

namespace BackOffice.Masters.Repository
{
    public class RolesRepository : IRoles
    {
        private readonly IConfiguration _configuration;

        public RolesRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<RolesResponse> GetAllRolesAsync()
        {
            var response=new RolesResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var StoredProcedure = "GetAllRoles";
                var res = await connection.QueryAsync<Roles>(StoredProcedure);
                response.roles=res.ToList();
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

        public async Task<RolesResponse> GetRolesByIdAsync(int id)
        {
            var response=new RolesResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var res = await connection.QueryAsync<Roles>("GetRolesById",
                    new { RoleId = id }, commandType: System.Data.CommandType.StoredProcedure);
                response.roles = res.ToList();
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
        public async Task<RolesResponse> AddRolesAsync(Roles roles)
        {
            var response=new RolesResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var res = await connection.ExecuteAsync(
                "CreateRoles",
                new
                {
                    roles.Name,
                    roles.Description,
                    roles.CreatedDate,
                    roles.CreatedBy,
                    roles.UpdateDate,
                    roles.UpdatedBy,
                    roles.TenantId
                },
                    commandType: System.Data.CommandType.StoredProcedure);
                response.roles = new List<Roles> { roles };
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
        public async Task<RolesResponse> UpdateRolesAsync(Roles roles)
        {
            var response = new  RolesResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var res = await connection.ExecuteAsync(
                    "UpdateRoles",
                    new
                    {
                        roles.RoleId,
                        roles.Name,
                        roles.Description,
                        roles.UpdateDate,
                        roles.UpdatedBy,
                        roles.TenantId
                    },
                    commandType: System.Data.CommandType.StoredProcedure);
                response.roles = new List<Roles> {roles };
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
        public async Task<RolesResponse> DeleteRolesAsync(int id)
        {
            var response=new RolesResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var res = await connection.ExecuteAsync(
                    "DeleteRoles",
                    new { RoleId = id },
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
