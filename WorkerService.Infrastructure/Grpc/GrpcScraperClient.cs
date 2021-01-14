using Grpc.Net.Client;
using System;
using System.Collections.Generic;
using System.Text;
using WorkerService.Infrastructure.Grpc.Protos;

namespace WorkerService.Infrastructure.Grpc
{
    public class GrpcScraperClient
    {
        public GrpcScraperClient()
        {

        }

        public void CallScraperService()
        {
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Scrape.ScrapeClient(channel);
            client.RunService(new ScrapeRequest());
            Console.WriteLine("Called Service");
        }

    }
}
