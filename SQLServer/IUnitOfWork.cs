using SQLServer.Repositories.Interfaces;

namespace SQLServer
{
    public interface IUnitOfWork
    {
        IHistoryRepository HistoryRepository { get; }
        ILanguagesRepository LanguagesRepository { get; }
        IPaymentMethodsRepository PaymentMethodsRepository { get; }
        IPaymentsRepository PaymentsRepository { get; }
        IProblemsRepository ProblemsRepository { get; }
        ITripsRepository TripsRepository { get; }
        IUnitsOfMeasureRepository UnitsOfMeasureRepository { get; }
        IUsersRepository UsersRepository { get; }
        IVehiclesRepository VehiclesRepository { get; }

        int SaveChanges();
    }
}