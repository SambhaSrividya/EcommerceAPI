﻿using BackOffice.Masters.Models;

namespace BackOffice.Masters.IService
{
    public interface IServicesService
    {
        Task<ServicesResponse> GetAllServicesAsync();
        Task<ServicesResponse> GetServicesByIdAsync(int id);
        Task<ServicesResponse> AddServicesAsync(Services services);
        Task<ServicesResponse> UpdateServicesAsync(Services services);
        Task<ServicesResponse> DeleteServicesAsync(int id);
    }
}
