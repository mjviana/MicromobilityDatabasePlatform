using SQLServer.Models;
using SQLServer.Repositories.Interfaces;

namespace SQLServer.Repositories.Implementations
{
    public class UsersRepository : IUsersRepository
    {
        private readonly MicromobililtyContext _micromobiltyContext;

        public UsersRepository(MicromobililtyContext micromobililtyContext)
        {
            _micromobiltyContext = micromobililtyContext;
        }

        public void Add(User user)
        {
            _micromobiltyContext.users.Add(user);
        }
    }
}
