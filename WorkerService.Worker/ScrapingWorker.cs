using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WorkerService.Worker
{
    public class ScrapingWorker : IHostedService, IDisposable
    {
        private Timer timer;
        public Task StartAsync(CancellationToken cancellationToken)
        {
            // Log start
            timer = new Timer(RunGrpcClient, null, TimeSpan.Zero, TimeSpan.FromHours(1));
            return Task.CompletedTask;
        }

        private void RunGrpcClient(object state)
        {
            // Log Run
            // Call client
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //Log stop
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
