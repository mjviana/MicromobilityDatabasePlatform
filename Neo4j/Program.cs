using Neo4j.Driver;
using System;
using System.Threading.Tasks;

namespace Neo4j
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                using (var greeter = new Neo4jDriver("neo4j://localhost:7687", "neo4j", "test"))
                {
                    #region USERS
                    //for (int i = 1; i < 500000; i++)
                    //{
                    //    Console.WriteLine($"user #{i}");
                    //    await greeter.PopulateUsers();
                    //} 
                    #endregion

                    #region VEHICLES
                    Console.WriteLine("STATIONARY");
                    for (int i = 0; i < 6000; i++)
                    {
                        Console.WriteLine($"vehicle #{i}");
                        await greeter.PopulateVehicles("stationary");
                    }

                    Console.WriteLine("ON THE MOVE");
                    for (int i = 0; i < 3000; i++)
                    {
                        Console.WriteLine($"vehicle #{i}");
                        await greeter.PopulateVehicles("on the move");
                    }
                    #endregion
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }

    public class Neo4jDriver : IDisposable
    {
        private bool _disposed = false;
        private readonly IDriver _driver;

        ~Neo4jDriver() => Dispose(false);

        public Neo4jDriver(string uri, string username, string password)
        {
            _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(username, password));
        }

        public async Task PopulateUsers()
        {
            using (var session = _driver.AsyncSession())
            {
                IResultCursor cursor = await session.RunAsync("CREATE (user:USER:ADMIN:MANAGER {name: \"" + Faker.Name.FirstName() + "\"" +
                 ",password: \"" + Faker.User.Password() + "\"" +
                 ", email: \"" + Faker.User.Email() + "\"" +
                 ", user_name: \"" + Faker.User.Username() + "\"" +
                 ",unit_of_measure: \"" + "KM" + "\"" +
                 ", share_location:" + Faker.Number.Bool()+
                 "}) RETURN user.name as name");

                var result = await cursor.SingleAsync(record => record["name"].As<string>());
                Console.WriteLine(result);
            }
        }

        public async Task PopulateVehicles(string status)
        {
            using (var session = _driver.AsyncSession())
            {
                IResultCursor cursor = await session.RunAsync("CREATE (vehicle:VEHICLE {model: \"Scooter " + Faker.Number.RandomNumber(10) + "\"" +
                 ",status: \"" + status + "\"" +
                 ", latitue: \"" + Faker.GeoLocation.Latitude() + "\"" +
                 ", longitude: \"" + Faker.GeoLocation.Longitude() + "\"" +
                 ",active: \"" + Faker.Number.Bool() + "\"" +
                 "}) RETURN vehicle.model as model");

                var result = await cursor.SingleAsync(record => record["model"].As<string>());
                Console.WriteLine(result);
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                _driver?.Dispose();
            }

            _disposed = true;
        }
    }
}
