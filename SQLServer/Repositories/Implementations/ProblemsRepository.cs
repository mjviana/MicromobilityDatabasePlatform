using SQLServer.Repositories.Interfaces;

namespace SQLServer.Repositories.Implementations
{
    public class ProblemsRepository : IProblemsRepository
    {
        private readonly MicromobililtyContext _micromobililtyContext;

        public ProblemsRepository(MicromobililtyContext micromobililtyContext)
        {
            _micromobililtyContext = micromobililtyContext;
        }
    }
}
