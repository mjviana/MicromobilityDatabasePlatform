using Autofac;

namespace SQLServer
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<Repositories.Implementations.HistoryRepository>().As<Repositories.Interfaces.IHistoryRepository>();
            builder.RegisterType<Repositories.Implementations.LanguagesRepository>().As<Repositories.Interfaces.ILanguagesRepository>();
            builder.RegisterType<Repositories.Implementations.PaymentMethodsRepository>().As<Repositories.Interfaces.IPaymentMethodsRepository>();
            builder.RegisterType<Repositories.Implementations.PaymentsRepository>().As<Repositories.Interfaces.IPaymentsRepository>();
            builder.RegisterType<Repositories.Implementations.ProblemsRepository>().As<Repositories.Interfaces.IProblemsRepository>();
            builder.RegisterType<Repositories.Implementations.TripsRepository>().As<Repositories.Interfaces.ITripsRepository>();
            builder.RegisterType<Repositories.Implementations.UnitsOfMeasureRepository>().As<Repositories.Interfaces.IUnitsOfMeasureRepository>();
            builder.RegisterType<Repositories.Implementations.UsersRepository>().As<Repositories.Interfaces.IUsersRepository>();
            builder.RegisterType<Repositories.Implementations.VehiclesRepository>().As<Repositories.Interfaces.IVehiclesRepository>();


            return builder.Build();
        }
    }
}
