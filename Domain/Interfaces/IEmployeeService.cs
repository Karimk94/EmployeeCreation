using Domain.Models;

namespace Domain.Services
{
    public interface IEmployeeService
    {
        Task<StatusResponse> CreateAsync(CreateEmployeeModel model);
    }
}