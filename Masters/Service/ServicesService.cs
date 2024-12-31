using BackOffice.Masters.IRepository;
using BackOffice.Masters.IService;
using BackOffice.Masters.Models;
using Serilog;

namespace BackOffice.Masters.Service
{
    public class ServicesService:IServicesService
    {
        private readonly IServices _repository;
        public ServicesService(IServices repository)
        {
            _repository = repository;
        }
        public async Task<ServicesResponse> AddServicesAsync(Services services)
        {
            var response=new ServicesResponse();
            try
            {
                var res= await _repository.AddServicesAsync(services);
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

        public async Task<ServicesResponse> DeleteServicesAsync(int id)
        {
            var response = new ServicesResponse();
            try
            {
                var res = await _repository.DeleteServicesAsync(id);
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

        public async Task<ServicesResponse> GetAllServicesAsync()
        {
            var response = new ServicesResponse();
            try
            {
                var res = await _repository.GetAllServicesAsync();
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

        public async Task<ServicesResponse> GetServicesByIdAsync(int id)
        {
            var response= new ServicesResponse();
            try
            {
                var res= await _repository.GetServicesByIdAsync(id);
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

        public async Task<ServicesResponse> UpdateServicesAsync(Services services)
        {
            var response = new ServicesResponse();
            try
            {
                var res= await _repository.UpdateServicesAsync(services);
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
