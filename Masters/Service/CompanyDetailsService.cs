using BackOffice.Masters.IRepository;
using BackOffice.Masters.IService;
using BackOffice.Masters.Models;
using Serilog;

namespace BackOffice.Masters.Service
{
    public class CompanyDetailsService : ICompanyDetailsService
    {
        private readonly ICompanyDetails _repository;
        public CompanyDetailsService(ICompanyDetails repository)
        {
            _repository = repository;
        }
        public async Task<CompanyResponse> AddCompanyDetailsAsync(CompanyDetails companyDetails)
        {
            var response = new CompanyResponse();
            try {
                var res = await _repository.AddCompanyDetailsAsync(companyDetails);
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

        public async Task<CompanyResponse> DeleteCompanyDetailsAsync(int id)
        {
            var response = new CompanyResponse();
            try {
                var res = await _repository.DeleteCompanyDetailsAsync(id);
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

        public async Task<CompanyResponse> GetAllCompanyDetailsAsync()
        {
            var response = new CompanyResponse();
            try {
                var res = await _repository.GetAllCompanyDetailsAsync();
                response.companydetails = res.companydetails;
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
                return null;
            }
        }

        public async Task<CompanyResponse> GetCompanyDetailsByIdAsync(int id)
        {
            var response = new CompanyResponse();
            try
            {
                var res = await _repository.GetCompanyDetailsByIdAsync(id);
                response = res;
                return response;
            }
            catch (Exception ex)
            {
                response.Error = new Error
                {
                    ErrorCode = 500, ErrorDescription = ex.Message
                };
                Log.Error("{@Error}", response.Error);
                return response;
            }
        }

        public async Task<CompanyResponse> UpdateCompanyDetailsAsync(CompanyDetails companydetails)
        {
            var response = new CompanyResponse();
            try {
                    var res = await _repository.UpdateCompanyDetailsAsync(companydetails);
                    response.companydetails = res.companydetails;
                    return response;
                }
                catch (Exception ex) 
            { 
                response.Error = new Error 
                { 
                    ErrorCode = 500, ErrorDescription = ex.Message 
                }; 
                Log.Error("{@Error}", response.Error); 
                return response; 
            }
        }
    }
    } 
