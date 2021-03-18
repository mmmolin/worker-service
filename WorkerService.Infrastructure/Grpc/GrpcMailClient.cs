using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WorkerService.Infrastructure.Grpc.Protos;

namespace WorkerService.Infrastructure.Grpc
{
    public class GrpcMailClient
    {
        public void RunService()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            using var channel = GrpcChannel.ForAddress("http://localhost:5009", new GrpcChannelOptions { HttpHandler = httpHandler });
            var client = new SendMail.SendMailClient(channel);
            client.RunService(new SendMailRequest());
            Console.WriteLine("Called Mail Service");
        }
    }
}
