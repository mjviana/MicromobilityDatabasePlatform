using SQLServer.Repositories.Interfaces;

namespace SQLServer.Repositories.Implementations
{
    public class PaymentMethodsRepository : IPaymentMethodsRepository
    {
        private readonly MicromobililtyContext _micromobiltyContext;

        public PaymentMethodsRepository(MicromobililtyContext micromobililtyContext)
        {
            _micromobiltyContext = micromobililtyContext;
        }
    }
}
