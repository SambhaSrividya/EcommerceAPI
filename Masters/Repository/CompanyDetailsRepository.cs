using Azure;
using BackOffice.Masters.IRepository;
using BackOffice.Masters.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Serilog;
using System.Data;

namespace BackOffice.Masters.Repository
{
    public class CompanyDetailsRepository : ICompanyDetails
    {
       private readonly IConfiguration _configuration;

       public CompanyDetailsRepository(IConfiguration configuration)
       {
            _configuration = configuration;
       }

        public async Task<CompanyResponse> GetAllCompanyDetailsAsync()
        {
            var response=new CompanyResponse();
            try
            {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var StoredProcedure = "GetAllCompanyDetails";
                var res = await connection.QueryAsync<CompanyDetails>(StoredProcedure);
                response.companydetails = res.ToList();
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
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var result= await connection.QueryAsync<CompanyDetails>("GetCompanyDetailsById",
                    new { CompanyId = id }, commandType: System.Data.CommandType.StoredProcedure);
                response.companydetails = result.ToList();
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
        public async Task<CompanyResponse> AddCompanyDetailsAsync(CompanyDetails companyDetails)
        {
            var response = new CompanyResponse(); 
            try {
                using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
                var res = await connection.ExecuteAsync(
                    "CreateCompanyDetails",
                new
            {
                companyDetails.CompanyCode,
                companyDetails.CompanyName,
                companyDetails.CompanyGroup,
                companyDetails.Address1,
                companyDetails.Address2,
                companyDetails.City,
                companyDetails.State,
                companyDetails.Country,
                companyDetails.PostalCode,
                companyDetails.CurrencyId,
                companyDetails.ContactNumber,
                companyDetails.ContactPerson,
                companyDetails.Fax,
                companyDetails.Email,
                companyDetails.AccountSpecificCode,
                companyDetails.IsRoundOff,
                companyDetails.NoOfDigits,
                companyDetails.Logo,
                companyDetails.NumberDisplayType,
                companyDetails.CreatedDate,
                companyDetails.CreatedBy,
                companyDetails.UpdatedDate,
                companyDetails.UpdatedBy,
                companyDetails.TenantId
            },commandType: CommandType.StoredProcedure);
                response.companydetails = new List<CompanyDetails> { companyDetails };
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

        public async Task<CompanyResponse> UpdateCompanyDetailsAsync(CompanyDetails companydetails)
        {
            var response = new CompanyResponse();
            try { 
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var res= await connection.ExecuteAsync(
                "UpdateCompanyDetails",
                new
                {
                    companydetails.CompanyId,
                    companydetails.CompanyCode,
                    companydetails.CompanyName,
                    companydetails.CompanyGroup,
                    companydetails.Address1,
                    companydetails.Address2,
                    companydetails.City,
                    companydetails.State,
                    companydetails.Country,
                    companydetails.PostalCode,
                    companydetails.CurrencyId,
                    companydetails.ContactNumber,
                    companydetails.ContactPerson,
                    companydetails.Fax,
                    companydetails.Email,
                    companydetails.AccountSpecificCode,
                    companydetails.IsRoundOff,
                    companydetails.NoOfDigits,
                    companydetails.Logo,
                    companydetails.NumberDisplayType,
                    companydetails.UpdatedDate,
                    companydetails.UpdatedBy,
                    companydetails.TenantId
                },
                commandType: System.Data.CommandType.StoredProcedure);
                response.companydetails = new List<CompanyDetails> { companydetails };
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
            var response=new CompanyResponse();
            try { 
            using var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
            var res= await connection.ExecuteAsync(
                "DeleteCompanyDetails",
                new { CompanyId = id },
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
