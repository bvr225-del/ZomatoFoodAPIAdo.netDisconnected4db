using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZomatoFoodAPI_BusinessEntities.Dtos;
using ZomatoFoodAPI_BusinessEntities.Interfaces;

namespace ZomatoFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        //inject the depencies into the controller class using constructor injection and assign it to the private readonly field of the service interface type.    
        private readonly IDepartmentService _departmentService;
        //we need to inject the depedencies into constructor.
        public DepartmentController(IDepartmentService departmentService)//constructor injection of the service interface into the controller class and assign it to the private readonly field of the service interface type.
        {
            _departmentService = departmentService;
        }
        [HttpPost]
        [Route("AddDepartment")]
        public async Task<IActionResult> Post(DepartmentDto department)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var Dept = await _departmentService.AddDepartment(department);
                    return StatusCode(StatusCodes.Status201Created, Dept);
                }

            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut]
        [Route("UpdateDepartment")]
        public async Task<IActionResult> Put(DepartmentDto department)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var Dept = await _departmentService.UpdateDepartment(department);
                    return StatusCode(StatusCodes.Status201Created, Dept);
                }

            }
            catch (Exception Ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpDelete]
        [Route("Deletedepartment")]
        public async Task<IActionResult> Delete(int deptId)
        {
            if (deptId < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "bad Request");
            }
            try
            {
                var deptdata = await _departmentService.DeleteDepartment(deptId);
                if (deptdata == null)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Department Not Found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "Department Deleted Successfully");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet]
        [Route("GetAllDepartments")]
        public async Task<IActionResult> Getalldepartments()
        {
            var res = await _departmentService.GetAllDepartments();
            if (res == null)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Department Data Not Found");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, res);
            }
        }
        [HttpGet]
        [Route("GetDepartmentbyid/{Deptid}")]
        public async Task<IActionResult> Getdepartmentbyid(int Deptid)
        {
            if (Deptid < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
            }
            try
            {
                var res = await _departmentService.GetDepartmentById(Deptid);
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Department Not Exists");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, res);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }

    }
}
