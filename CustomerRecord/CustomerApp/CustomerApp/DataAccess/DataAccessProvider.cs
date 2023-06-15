using CustomerApp.Model;

namespace CustomerApp.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgreSqlContext _context;

        public DataAccessProvider(PostgreSqlContext context)
        {
            _context = context;
        }

        public void AddCustomerRecord(Customer customer)
        {
            _context.customer.Add(customer);
            _context.SaveChanges();
        }

        public List<Customer> GetCustomerRecords()
        {
            var record = _context.customer.ToList();
            return record;
        }
    }
}
