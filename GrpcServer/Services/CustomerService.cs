using Grpc.Core;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace GrpcServer.Services
{
    public class CustomerService : Customer.CustomerBase
    {
        public ILogger<CustomerService> Logger { get; }

        public CustomerService(ILogger<CustomerService> logger)
        {
            Logger = logger;
        }

        public override Task<CustomerModel> GetCustomerInfo(CustomerLookupModel request, ServerCallContext context)
        {
            CustomerModel output = null;// new CustomerModel();

            if (request.Userid == 1)
            {
                output = new CustomerModel
                {
                    FirstName = "Wolfgang",
                    LastName = "Mozart",
                    EmailAddress = "finance@deepanjannag.com",
                    IsAlive = false,
                    Age = 35
                };
            }
            else if (request.Userid == 2)
            {
                output = new CustomerModel
                {
                    FirstName = "Ludwig",
                    LastName = "Beethoven",
                    EmailAddress = "musician@deepanjannag.com",
                    IsAlive = true,
                    Age = 57
                };
            }
            else
            {
                output = new CustomerModel
                {
                    FirstName = "Peter",
                    LastName = "Tchaikovsky",
                    EmailAddress = "composer@deepanjannag.com",
                    IsAlive = false,
                    Age = 53
                };
            }

            return Task.FromResult(output);
        }
    }
}
