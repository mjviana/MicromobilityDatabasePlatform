using SQLServer.Repositories.Interfaces;

namespace SQLServer.Repositories.Implementations
{
    public class LanguagesRepository : ILanguagesRepository
    {
        private readonly MicromobililtyContext _micromobililtyContext;

        public LanguagesRepository(MicromobililtyContext micromobililtyContext)
        {
            _micromobililtyContext = micromobililtyContext;
        }
    }
}
