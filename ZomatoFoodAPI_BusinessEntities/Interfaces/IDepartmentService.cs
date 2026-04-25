using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Dtos;

namespace ZomatoFoodAPI_BusinessEntities.Interfaces
{
    public interface IDepartmentService
    {
        Task<List<DepartmentDto>> GetAllDepartments();
        Task<DepartmentDto> GetDepartmentById(int DepartmentId);
        //Task<DepartmentDto> GetDepartmentByName(string DepartmentName);
        Task<bool> AddDepartment(DepartmentDto Dept);
        Task<bool> UpdateDepartment(DepartmentDto Dept);
        Task<bool> DeleteDepartment(int DepartmentId);

    }
}
