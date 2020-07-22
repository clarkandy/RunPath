using Microsoft.Extensions.Logging;

namespace RunPath.Test.Services
{
    public abstract class ServiceBase
    {
        protected readonly ILogger _logger;

        public ServiceBase(ILogger logger)
            => _logger = logger;
    }
}
