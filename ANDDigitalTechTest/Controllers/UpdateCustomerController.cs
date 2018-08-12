using System.Net;
using System.Net.Http;
using System.Web.Http;
using ANDDigitalTechTest.Models;
using ANDDigitalTechTest.Services;

namespace ANDDigitalTechTest.Controllers
{
    public class UpdateCustomerController : ApiController
    {

        private readonly CustomerRepository _customerRepository;

        public UpdateCustomerController()
        {
            _customerRepository = new CustomerRepository();
        }

        public HttpResponseMessage Post(Customer customer)
        {
            var updateCustomer = _customerRepository.UpdateCustomer(customer);

            
            if (updateCustomer)
            {
                var response = Request.CreateResponse(HttpStatusCode.Created, customer);
                return response;
            }

            return Request.CreateResponse(HttpStatusCode.NotFound, $"Unable to update Customer with id = {customer.Id} not found");

            
        }
    }
}
