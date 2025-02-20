using ServiceLifetimesDemo.Services.Interfaces;

namespace ServiceLifetimesDemo.Services.Implementations
{
    public class ScopedService : IScopedService
    {
        private readonly Guid _operationId;

        public ScopedService()
        {
            _operationId = Guid.NewGuid();
        }

        public Guid GetOperationId() => _operationId;
    }
}
