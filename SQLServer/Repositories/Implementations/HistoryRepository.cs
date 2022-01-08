using SQLServer.Repositories.Interfaces;

namespace SQLServer.Repositories.Implementations
{
    public class HistoryRepository : IHistoryRepository
    {
        private readonly MicromobililtyContext _micromobililtyContext;

        public HistoryRepository(MicromobililtyContext micromobililtyContext)
        {
            _micromobililtyContext = micromobililtyContext;
        }
    }
}
