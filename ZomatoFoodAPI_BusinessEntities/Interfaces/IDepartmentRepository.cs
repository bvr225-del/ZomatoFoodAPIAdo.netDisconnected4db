using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Models;

namespace ZomatoFoodAPI_BusinessEntities.Interfaces
{
    public interface IDepartmentRepository
    {
        //interface methodes does not contain method body.
        //by default interface methods are public abstract.it means inside interface we are writing abstarct methods only.
        //If you want to implement this interface methods inherit to child class and implement into child class.

        Task<List<Department>> GetAllDepartments();
        Task<Department> GetDepartmentById(int DepartmentId);
        //Task<Department> GetDepartmentByName(string DepartmentName);
        Task<bool> AddDepartment(Department Dept);
        Task<bool> UpdateDepartment(Department Dept);
        Task<bool> DeleteDepartment(int DepartmentId);

    }
}
