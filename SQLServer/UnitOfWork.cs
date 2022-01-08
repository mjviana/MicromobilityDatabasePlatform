using SQLServer.Repositories.Implementations;
using SQLServer.Repositories.Interfaces;

namespace SQLServer
{
    public class UnitOfWork : IUnitOfWork
    {
        private MicromobililtyContext dbContext;
        public IHistoryRepository HistoryRepository { get; }
        public ILanguagesRepository LanguagesRepository { get; }
        public IPaymentMethodsRepository PaymentMethodsRepository { get; }
        public IPaymentsRepository PaymentsRepository { get; }
        public IProblemsRepository ProblemsRepository { get; }
        public ITripsRepository TripsRepository { get; }
        public IUnitsOfMeasureRepository UnitsOfMeasureRepository { get; }
        public IUsersRepository UsersRepository { get; }
        public IVehiclesRepository VehiclesRepository { get; }

        public UnitOfWork()
        {
            dbContext = new MicromobililtyContext();
            HistoryRepository = new HistoryRepository(dbContext);
            LanguagesRepository = new LanguagesRepository(dbContext);
            PaymentMethodsRepository = new PaymentMethodsRepository(dbContext);
            PaymentsRepository = new PaymentsRepository(dbContext);
            ProblemsRepository = new ProblemsRepository(dbContext);
            TripsRepository = new TripsRepository(dbContext);
            UnitsOfMeasureRepository = new UnitsOfMeasureRepository(dbContext);
            UsersRepository = new UsersRepository(dbContext);
            VehiclesRepository = new VehiclesRepository(dbContext);
        }

        public int SaveChanges()
        {
            return dbContext.SaveChanges();
        }
    }
}
