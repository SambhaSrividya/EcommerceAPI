using BackOffice.Masters.IRepository;
using BackOffice.Masters.IService;
using BackOffice.Masters.Models;
using Serilog;

namespace BackOffice.Masters.Service
{
    public class RolesService : IRolesService
    {
        private readonly IRoles _repository;
        public RolesService(IRoles repository)
        {
            _repository = repository;
        }
        public async Task<RolesResponse> AddRolesAsync(Roles roles)
        {
            var response=new RolesResponse();
            try
            {
                var res = await _repository.AddRolesAsync(roles);
                response = res;
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
                var res = await _repository.DeleteRolesAsync(id);
                response = res;
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

        public async Task<RolesResponse> GetAllRolesAsync()
        {
            var response=new RolesResponse();
            try
            {
                var res = await _repository.GetAllRolesAsync();
                response = res;
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
                var res = await _repository.GetRolesByIdAsync(id);
                response = res;
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
            var response=new RolesResponse();
            try
            {
                var res = await _repository.UpdateRolesAsync(roles);
                response = res;
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
