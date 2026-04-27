using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZomatoFoodAPI_BusinessEntities.Dtos;
using ZomatoFoodAPI_BusinessEntities.Interfaces;

namespace ZomatoFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        [HttpPost]//post is used to insert the data into the database and it is used to create a new resource/record in the database
        [Route("AddOrder")]
        public async Task<IActionResult> Post(OrdersDto objorder)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var ord = await _ordersService.AddOrder(objorder);
                    return StatusCode(StatusCodes.Status200OK, ord);

                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpPut]//put is used to update the data in the database and it is used to update an existing resource/record in the database
        [Route("UpdateOrder")]
        public async Task<IActionResult> Updateorder(OrdersDto objorder)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, ModelState);
                }
                else
                {
                    var ord = await _ordersService.UpdateOrder(objorder);
                    return StatusCode(StatusCodes.Status200OK, ord);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");

            }

        }
        [HttpDelete]
        [Route("DeleteOrder")]//delete is used to delete the data from the database and it is used to delete an existing resource/record from the database
        public async Task<IActionResult> Deleteorder(int OrderId)
        {

            if (OrderId < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
            }
            try
            {
                var order = await _ordersService.DeleteOrder(OrderId);
                if (order == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Order Not Found");
                }
                else
                {
                    return StatusCode(StatusCodes.Status200OK, "Order Deleted Successfully");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal Server Error");
            }
        }
        [HttpGet]
        [Route("GetOrder")]//get is used to retrieve the data from the database and it is used to retrieve an existing resource/record from the database
        public async Task<IActionResult> GetOrder()
        {
            var order = await _ordersService.GetallOrders();
            if (order == null)
            {
                return StatusCode(StatusCodes.Status404NotFound, "Order Details Not Fount");
            }
            else
            {
                return StatusCode(StatusCodes.Status200OK, order);
            }
        }
        [HttpGet]
        [Route("GetOrdersbyId")]//get is used to retrieve the data from the database and it is used to retrieve an existing resource/record from the database by using the id
        public async Task<IActionResult> GetorderbyId(int OrderId)
        {
            if (OrderId < 0)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad Request");
            }
            try
            {
                var res = await _ordersService.GetOrderById(OrderId);
                if (res == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Order Not Found");

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
