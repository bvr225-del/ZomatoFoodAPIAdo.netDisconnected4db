using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZomatoFoodAPI_BusinessEntities.Dtos
{
    public class OrdersDto
    {
        public int OrderId { get; set; }
        public string OrderName { set; get; }
        public string OrderLocation { set; get; }

    }
}
