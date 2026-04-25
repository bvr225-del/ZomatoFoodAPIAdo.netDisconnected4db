using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZomatoFoodAPI_BusinessEntities.Dtos;
using ZomatoFoodAPI_BusinessEntities.Interfaces;
using ZomatoFoodAPI_BusinessEntities.Models;

namespace ZomatoFoodAPI_ServiceLayer
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IDepartmentRepository _departmentRepository;
        //Don't create dirrect object of repository class here
        //create the onstructor of this service class and inject the repository interface into the constructor and assign it to the private readonly field of the repository interface type.
        public DepartmentService(IDepartmentRepository departmentRepository)
        {
            _departmentRepository = departmentRepository;
        }
        //we called this process as dependency injection and this is the best practice to achieve loose coupling between the service and repository layers of the application.
        public async Task<bool> AddDepartment(DepartmentDto Dept)
        {
            Department department = new Department();
            department.DepartmentName = Dept.DepartmentName;
            department.DepartmentLocation = Dept.DepartmentLocation;
            department.DepartmentId = Dept.DepartmentId;
            var res = await _departmentRepository.AddDepartment(department);
            return res;
        }

        public async Task<bool> DeleteDepartment(int DepartmentId)
        {
            await _departmentRepository.DeleteDepartment(DepartmentId);
            return true;
        }

        public async Task<List<DepartmentDto>> GetAllDepartments()
        {
            List<DepartmentDto> deptlist = new List<DepartmentDto>();
            var getdept = await _departmentRepository.GetAllDepartments();
            foreach (Department dept in getdept)
            {
                DepartmentDto deptobj = new DepartmentDto();
                deptobj.DepartmentId = dept.DepartmentId;
                deptobj.DepartmentName = dept.DepartmentName;
                deptobj.DepartmentLocation = dept.DepartmentLocation;
                deptlist.Add(deptobj);
            }
            return deptlist;
        }

        public async Task<DepartmentDto> GetDepartmentById(int DepartmentId)
        {
            var res = await _departmentRepository.GetDepartmentById(DepartmentId);
            DepartmentDto dept = new DepartmentDto();
            dept.DepartmentId = res.DepartmentId;
            dept.DepartmentName = res.DepartmentName;
            dept.DepartmentLocation = res.DepartmentLocation;
            return dept;
        }

        public async Task<bool> UpdateDepartment(DepartmentDto Dept)
        {
            Department department = new Department();
            department.DepartmentName = Dept.DepartmentName;
            department.DepartmentLocation = Dept.DepartmentLocation;
            department.DepartmentId = Dept.DepartmentId;
            await _departmentRepository.UpdateDepartment(department);
            return true;
        }
    }
}
