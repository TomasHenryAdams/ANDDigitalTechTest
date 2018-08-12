using System.Net;
using System.Net.Http;
using System.Web.Http;
using ANDDigitalTechTest.Services;

namespace ANDDigitalTechTest.Controllers
{
    public class GetCustomerByIdController : ApiController
    {
        private readonly CustomerRepository _customerRepository;

        public GetCustomerByIdController()
        {
            _customerRepository = new CustomerRepository();
        }
        public HttpResponseMessage Get(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);

            if (customer != null)
            {
                return Request.CreateResponse(HttpStatusCode.OK, customer);
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, $"Customer with id = {id} not found");
        }
    }
}
