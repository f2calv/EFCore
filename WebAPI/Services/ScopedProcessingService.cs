using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using WebAPI.Data;

namespace WebAPI.Services
{
    internal interface IScopedProcessingService
    {
        Task DoWork(CancellationToken stoppingToken);
    }

    internal class ScopedProcessingService : IScopedProcessingService
    {
        //private int executionCount = 0;
        private readonly ILogger _logger;
        private readonly MyDbContext _context;

        public ScopedProcessingService(ILogger<ScopedProcessingService> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task DoWork(CancellationToken stoppingToken)
        {
            var id = 1;
            var student = await _context.Students.FindAsync(id);
            if (student is null)
                _logger.LogWarning("can't find student id={id} with ContextId={ContextId}", id, _context.ContextId);

            //while (!stoppingToken.IsCancellationRequested)
            //{
            //    executionCount++;

            //    _logger.LogInformation("Scoped Processing Service is working. Count: {Count}", executionCount);

            //    await Task.Delay(10000, stoppingToken);
            //}
        }
    }
}