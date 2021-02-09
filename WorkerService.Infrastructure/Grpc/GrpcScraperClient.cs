using Grpc.Net.Client;
using System;
using System.Net.Http;
using WorkerService.Core.Interfaces;
using WorkerService.Infrastructure.Grpc.Protos;

namespace WorkerService.Infrastructure.Grpc
{
    public class GrpcScraperClient : IGrpcClient
    {
        public GrpcScraperClient()
        {

        }

        public void CallService()
        {
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            using var channel = GrpcChannel.ForAddress("http://scraperservice:5001", new GrpcChannelOptions { HttpHandler = httpHandler});
            //using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Scrape.ScrapeClient(channel);
            client.RunService(new ScrapeRequest());
            Console.WriteLine("Called Service");
        }

    }
}
