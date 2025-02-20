using ServiceLifetimesDemo.Services.Interfaces;

namespace ServiceLifetimesDemo.Services.Implementations
{
    public class TransientService : ITransientService
    {
        private readonly Guid _operationId;

        public TransientService()
        {
            _operationId = Guid.NewGuid();
        }

        public Guid GetOperationId() => _operationId;
    }
}
