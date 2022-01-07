namespace SQLServer
{
    public class UnitOfWork
    {
        private MicromobililtyContext dbContext;

        public UnitOfWork()
        {
            dbContext = new MicromobililtyContext();
        }
    }
}
