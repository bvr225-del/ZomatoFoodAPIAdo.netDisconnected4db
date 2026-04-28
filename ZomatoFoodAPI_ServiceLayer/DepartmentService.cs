using AutoMapper;
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
        public readonly IDepartmentRepository _departmentRepository;
        private readonly IMapper _mapper;
        //Don't create dirrect object of repository class here
        //create the onstructor of this service class and inject the repository interface into the constructor and assign it to the private readonly field of the repository interface type.
        public DepartmentService(IDepartmentRepository departmentRepository,IMapper mapper)
        {
            _departmentRepository = departmentRepository;
            this._mapper = mapper;
        }
        //we called this process as dependency injection and this is the best practice to achieve loose coupling between the service and repository layers of the application.
        public async Task<bool> AddDepartment(DepartmentDto Dept)
        {
            Department department = new Department();
            _mapper.Map(Dept, department);
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
            var getdept = await _departmentRepository.GetAllDepartments();
            return _mapper.Map<List<DepartmentDto>>(getdept);
        }

        public async Task<DepartmentDto> GetDepartmentById(int DepartmentId)
        {
            var res = await _departmentRepository.GetDepartmentById(DepartmentId);
            return _mapper.Map<DepartmentDto>(res);
        }

        public async Task<bool> UpdateDepartment(DepartmentDto Dept)
        {
            Department department = new Department();
            _mapper.Map(Dept, department);
            await _departmentRepository.UpdateDepartment(department);
            return true;
        }
    }
}
