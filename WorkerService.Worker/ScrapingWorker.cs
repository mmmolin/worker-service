using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WorkerService.Infrastructure.Grpc;

namespace WorkerService.Worker
{
    public class ScrapingWorker : IHostedService, IDisposable
    {
        private Timer timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Log start
            timer = new Timer(RunGrpcClient, null, TimeSpan.Zero, TimeSpan.FromSeconds(30)/*TimeSpan.FromHours(1)*/);
            return Task.CompletedTask;
        }

        private void RunGrpcClient(object state)
        {
            // Log Run
            var client = new GrpcScraperClient();
            client.CallScraperService();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //Log stop
            timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
