using Grpc.Net.Client;
using GrpcServer;
using System;
using System.Threading.Tasks;
using static GrpcServer.Customer;

namespace GrpcClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var reply = await client.SayHelloAsync(new HelloRequest { Name = "Deepanjan" });

            Console.WriteLine(reply.Message);*/

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var customerClient = new Customer.CustomerClient(channel);

            var clientRequested = new CustomerLookupModel { Userid = 2 };
            var customer = await customerClient.GetCustomerInfoAsync(clientRequested);

            Console.WriteLine($"{ customer.FirstName}, {customer.LastName}");

            Console.ReadLine();
        }
    }
}
