using SQLServer.Repositories.Interfaces;

namespace SQLServer.Repositories.Implementations
{
    public class TripsRepository : ITripsRepository
    {
        private readonly MicromobililtyContext _micromobiltyContext;

        public TripsRepository(MicromobililtyContext micromobililtyContext)
        {
            _micromobiltyContext = micromobililtyContext;
        }
    }
}
