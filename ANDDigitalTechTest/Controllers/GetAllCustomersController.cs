using System.Web.Http;
using ANDDigitalTechTest.Models;
using ANDDigitalTechTest.Services;

namespace ANDDigitalTechTest.Controllers
{
    public class GetAllCustomersController : ApiController
    {
        private readonly CustomerRepository _customerRepository;

        public GetAllCustomersController()
        {
            _customerRepository = new CustomerRepository();
        }

        public Customer[] Get()
        {
            return _customerRepository.GetAllCustomers();
        }
    }
}
