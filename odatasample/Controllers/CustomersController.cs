using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.OData;
using odatasample.Model;

namespace odatasample.Controllers
{
    [Route("[controller]")]
    [Produces("application/json")]
    public class CustomersController : ODataController
    {
        private readonly CustomerContext _dbContext;

        public CustomersController(CustomerContext context)
        {
            _dbContext = context;
            if (context.Customers.Any()) return;

            foreach (var b in DataSource.GetCustomers())
            {
                context.Customers.Add(b);
                foreach (var order in b.Orders)
                {
                    context.Orders.Add(order);
                }
            }

            context.SaveChanges();
        }

        [HttpGet("", Name = "GetCustomers")]
        [EnableQuery(AllowedQueryOptions = AllowedQueryOptions.Select | AllowedQueryOptions.OrderBy | AllowedQueryOptions.Filter)]
        [ProducesResponseType(statusCode: StatusCodes.Status200OK, Type = typeof(IEnumerable<Customer>))]
        public IActionResult Get()
        {
            // do something for the version
            return Ok(_dbContext.Customers.ToList());
        }
    }
}
