using CustomerApp.DataAccess;
using CustomerApp.Model;
using Microsoft.AspNetCore.Mvc;

namespace CustomerApp.Controller
{
    public class CustomerController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public CustomerController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [Route("~/api/customers")]
        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _dataAccessProvider.GetCustomerRecords();
        }

        [Route("~/api/addcustomer")]
        [HttpPost]
        public IActionResult Create([FromBody] Customer customer)
        {
            if (ModelState.IsValid)
            {
                _dataAccessProvider.AddCustomerRecord(customer);
                return Ok();
            }
            return BadRequest();
        }
    }
}
