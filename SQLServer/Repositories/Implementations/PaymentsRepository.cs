using SQLServer.Repositories.Interfaces;

namespace SQLServer.Repositories.Implementations
{
    public class PaymentsRepository : IPaymentsRepository
    {
        private readonly MicromobililtyContext _micromobiltyContext;
        public PaymentsRepository(MicromobililtyContext micromobililtyContext)
        {
            _micromobiltyContext = micromobililtyContext;
        }
    }
}
