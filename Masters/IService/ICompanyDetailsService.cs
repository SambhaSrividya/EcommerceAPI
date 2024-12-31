using BackOffice.Masters.Models;
using BackOffice.Masters.Repository;
namespace BackOffice.Masters.IService
{
    public interface ICompanyDetailsService
    {
        Task<CompanyResponse> GetAllCompanyDetailsAsync();
        Task<CompanyResponse> GetCompanyDetailsByIdAsync(int id);
        Task<CompanyResponse> AddCompanyDetailsAsync(CompanyDetails companyDetails);
        Task<CompanyResponse> UpdateCompanyDetailsAsync(CompanyDetails companydetails);
        Task<CompanyResponse> DeleteCompanyDetailsAsync(int id);
    }
}
