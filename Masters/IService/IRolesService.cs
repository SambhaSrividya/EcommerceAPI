using BackOffice.Masters.Models;

namespace BackOffice.Masters.IService
{
    public interface IRolesService
    {
        Task<RolesResponse> GetAllRolesAsync();
        Task<RolesResponse> GetRolesByIdAsync(int id);
        Task<RolesResponse> AddRolesAsync(Roles roles);
        Task<RolesResponse> UpdateRolesAsync(Roles roles);
        Task<RolesResponse> DeleteRolesAsync(int id);
    }
}
