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
    public class EmployeeService : IEmployeeService
    {
        public readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            this._mapper = mapper;
        }
        public async Task<int> AddEmployes(EmployeeDto empdetail)
        {//Here i am converting employeedto object data into employee clas object.
            Employee emp = new Employee();
            //destinationmodelclass object
            //This Code was replaced by above Automapper concept.
            // 1)Auto mapper is used to create a mapping between  to source model object to destination model object
            _mapper.Map(empdetail, emp);//sourceobject,destinationobject
                                        //Converting source modelobject to destination modelobject
                                        //Syntax:   _mapper.Map(SourceModelObject,DestinationModelObject)
                                        //once mapping is created, source model object can be converted to destination model object with less code and easy way.
            var res = await _employeeRepository.AddEmployes(emp);
            return res;
        }

        public async Task<bool> DeleteEmployesById(int empid)
        {
            await _employeeRepository.DeleteEmployesById(empid);
            return true;
        }

        public async Task<EmployeeDto> GetEmployeeById(int empid)
        {//if you are using any class as a return type of method,we must return the value of that class object.this is rule
            var res = await _employeeRepository.GetEmployeeById(empid);
            // 1)Auto mapper is used to create a mapping between  to source model object to destination model object        
            return _mapper.Map<EmployeeDto>(res);//entity to dto mapping
                                                      //in Service layer we are using Dto(Data transfer object) classes and return the data of Dto class object data.
        }

        public async Task<List<EmployeeDto>> GetEmployees()
        {
            var res = await _employeeRepository.GetEmployees();
            return _mapper.Map<List<EmployeeDto>>(res);//entity to dto mapping
        }

        public async Task<bool> UpdateEmploye(EmployeeDto empdetail)
        {//here we are transfer the data from employeedto object to employee object and pass to repository layer.
            Employee emp = new Employee();
            _mapper.Map(empdetail, emp);
            await _employeeRepository.UpdateEmploye(emp);
            return true;
        }
    }
}
