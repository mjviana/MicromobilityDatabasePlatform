using SQLServer.Repositories.Interfaces;

namespace SQLServer.Repositories.Implementations
{
    public class UnitsOfMeasureRepository : IUnitsOfMeasureRepository
    {
        private readonly MicromobililtyContext _micromobiltyContext;

        public UnitsOfMeasureRepository(MicromobililtyContext micromobililtyContext)
        {
            _micromobiltyContext = micromobililtyContext;
        }
    }
}
