using Application.BusinessLayer.Models;
using Application.DataLayer.Interfaces;
using Application.BusinessLayer.Services;

namespace Application.BusinessLayer.Interfaces
{
    public interface IService<TRead, TCreate>
    where TRead : class
    where TCreate : class
    {
        Task<ServiceResponse<List<TRead>>> GetAllAsync();
        Task<ServiceResponse<TRead>> GetByIdAsync(int id);
        Task<ServiceResponse<TRead>> AddAsync(TCreate dto);
        Task<ServiceResponse<TRead>> DeleteAsync(int id);
      
    }

}





