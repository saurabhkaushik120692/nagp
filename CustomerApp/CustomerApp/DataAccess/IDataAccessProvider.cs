using CustomerApp.Model;

namespace CustomerApp.DataAccess
{
    public interface IDataAccessProvider
    {
        void AddCustomerRecord(Customer customer);
        List<Customer> GetCustomerRecords();
    }
}
