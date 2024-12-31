using BackOffice.Masters.Models;

namespace BackOffice.Masters.IRepository
{
    public interface IRoles
    {
        Task<RolesResponse> GetAllRolesAsync();
        Task<RolesResponse> GetRolesByIdAsync(int id);
        Task<RolesResponse> AddRolesAsync(Roles roles);
        Task<RolesResponse> UpdateRolesAsync(Roles roles);
        Task<RolesResponse> DeleteRolesAsync(int id);
    }
}
