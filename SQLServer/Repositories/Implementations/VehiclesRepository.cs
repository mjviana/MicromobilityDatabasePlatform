using SQLServer.Repositories.Interfaces;

namespace SQLServer.Repositories.Implementations
{
    public class VehiclesRepository : IVehiclesRepository
    {
        private readonly MicromobililtyContext _micromobiltyContext;

        public VehiclesRepository(MicromobililtyContext micromobililtyContext)
        {
            _micromobiltyContext = micromobililtyContext;
        }
    }
}
