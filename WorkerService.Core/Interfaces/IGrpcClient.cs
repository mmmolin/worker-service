using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkerService.Core.Interfaces
{
    public interface IGrpcClient
    {
        public void CallService();
    }
}
