using BackOffice.Masters.Models;

namespace BackOffice.Masters.IRepository
{
    public interface ICompanyDetails
    {
        Task<CompanyResponse> GetAllCompanyDetailsAsync();
        Task<CompanyResponse> GetCompanyDetailsByIdAsync(int id);
        Task<CompanyResponse> AddCompanyDetailsAsync(CompanyDetails companyDetails);
        Task<CompanyResponse> UpdateCompanyDetailsAsync(CompanyDetails companydetails);
        Task<CompanyResponse> DeleteCompanyDetailsAsync(int id);

    }
}
