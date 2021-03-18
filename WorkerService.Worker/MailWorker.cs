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
    class MailWorker : IHostedService, IDisposable
    {
        private Timer timer;
       
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timer = new Timer(RunGrpcClient, null, TimeSpan.Zero, TimeSpan.FromSeconds(30));
            return Task.CompletedTask;
        }

        private void RunGrpcClient(object state)
        {
            var mailClient = new GrpcMailClient();
            mailClient.RunService();
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            timer.Change(Timeout.Infinite, 0);
            return Task.CompletedTask;
        }
        public void Dispose()
        {
            timer.Dispose();
        }
    }
}
