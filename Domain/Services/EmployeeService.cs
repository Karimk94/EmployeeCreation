using Domain.Data;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Domain.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly DBContext _dbContext;
        public EmployeeService(DBContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<StatusResponse> CreateAsync(CreateEmployeeModel model)
        {
            var response = new StatusResponse();

            if (await _dbContext.Employee.AnyAsync(e => e.Name.ToLower() == model.Name.ToLower()))
            {
                Error err = new Error { Field = "Name", Message = "already exists" };
                response.Errors.Add(err);
            }

            if (await _dbContext.Employee.AnyAsync(e => e.Phone.ToLower() == model.Phone.ToLower()))
            {
                Error err = new Error { Field = "Phone", Message = "already exists" };
                response.Errors.Add(err);
            }

            if (await _dbContext.Employee.AnyAsync(e => e.Department.ToLower() == model.Department.ToLower()))
            {
                Error err = new Error { Field = "Department", Message = "already exists" };
                response.Errors.Add(err);
            }

            if (Convert.ToInt32(model?.Salary) <= 0)
            {
                Error err = new Error { Field = "Salary", Message = "should be above zero" };
                response.Errors.Add(err);
            }

            if (response.Errors.Count == 0)
            {
                var entity = new Employee { Name = model.Name, Email = model.Email, Salary = model.Salary, Phone = model.Phone, Department = model.Department };

                await _dbContext.Employee.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
                response.Data = entity;
            }

            return response;
        }
    }
}
