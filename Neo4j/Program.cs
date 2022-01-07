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
                using (var neo4jDriver = new Neo4jDriver("neo4j://localhost:7687", "neo4j", "test"))
                {
                    #region USERS
                    //for (int i = 1; i < 500000; i++)
                    //{
                    //    Console.WriteLine($"user #{i}");
                    //    await greeter.PopulateUsers();
                    //} 
                    #endregion

                    #region VEHICLES
                    Console.WriteLine("POPULATING AVAILABLE VEHICLES...");
                    for (int i = 0; i < 6000; i++)
                    {
                        Console.WriteLine($"vehicle #{i}");
                        await neo4jDriver.PopulateVehicles("available");
                    }

                    Console.WriteLine("POPULATING NOT AVAILABLE VEHICLES...");
                    for (int i = 0; i < 3000; i++)
                    {
                        Console.WriteLine($"vehicle #{i}");
                        await neo4jDriver.PopulateVehicles("not available");
                    }
                    #endregion

                    #region PAYMENT METHODS

                    //for (int i = 0; i < 35; i++)
                    //{
                    //    await neo4jDriver.PopulatePaymentMehots();
                    //}
                    #endregion

                    #region LOCATIONS

                    //for (int i = 0; i < 40; i++)
                    //{
                    //    Console.WriteLine($"Generating location # {i}");
                    //    await neo4jDriver.PopulateLocations();
                    //}

                    #endregion

                    #region TRIPS
                    //Console.WriteLine("Generating a trip...");

                    //await neo4jDriver.GenerateTripToUser(6, 1, 7);

                    #endregion
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.ReadLine();

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
                 ", share_location:" + Faker.Number.Bool() +
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
                 ",latitude: \"" + Faker.GeoLocation.Latitude() + "\"" +
                 ",longitude: \"" + Faker.GeoLocation.Longitude() + "\"" +
                 ",active:" + Faker.Number.Bool() +
                 "}) RETURN vehicle.model as model");

                var result = await cursor.SingleAsync(record => record["model"].As<string>());
                Console.WriteLine(result);
            }
        }

        public async Task PopulatePaymentMethods()
        {
            using (var session = _driver.AsyncSession())
            {
                IResultCursor cursor = await session.RunAsync("CREATE(pm:PAYMENT_METHOD {card_CVC:" + Faker.Number.RandomNumber(100, 999) +
                    ", card_active:" + Faker.Number.Bool() +
                    ", card_expire_date: \"" + Faker.Number.RandomNumber(1, 12) + "/" + Faker.Number.RandomNumber(22, 30) + "\"" +
                    ", card_number:" + Faker.Number.RandomNumber(1000000000000000, 9999999999999999) +
                    ", type: \"" + Faker.CreditCard.CreditCardType() + "\"}) RETURN pm.type AS card_type");

                var result = await cursor.SingleAsync(r => r["card_type"].As<string>());

                Console.WriteLine($"Card with type: {result} was generated!");
            }
        }

        public async Task PopulateLocations()
        {
            using (var session = _driver.AsyncSession())
            {
                IResultCursor cursor = await session.RunAsync("CREATE(l:LOCATION {latitude:\"" + Faker.GeoLocation.Latitude() + "\"" +
                    ", longitude:\"" + Faker.GeoLocation.Longitude() + "\"" +
                    ", name: \"" + Faker.Address.StreetName() + "\"}) RETURN l.name AS name");

                var result = await cursor.SingleAsync(r => r["name"].As<string>());

                Console.WriteLine($"Location with name: {result} was generated!");
            }
        }

        //For this I recommend going to the db and look for the ids that you want to use for each parameter
        public async Task GenerateTripToUser(int userId, int vehicleId, int paymentMethodId)
        {
            using (var session = _driver.AsyncSession())
            {
                IResultCursor cursor = await session.RunAsync("MATCH(u:USER), (v:VEHICLE)" +
                    $"WHERE ID(u) = {userId} AND ID(v) = {vehicleId}" +
                    " CREATE (u) -[rel:TRAVELED_USING {amount_paid: \"" + Faker.Commerce.Price() + "\"" +
                    ",route: \"" + Faker.Lorem.Paragraph(1) + "\"" +
                    $",payment_method_id: {paymentMethodId}" +
                    ",start_date_time: \"" + Faker.Date.Between(DateTime.Now.AddMinutes(-40), DateTime.Now) + "\"" +
                    ",end_date_time: \"" + Faker.Date.Between(DateTime.Now, DateTime.Now.AddMinutes(13)) + "\"" +
                    ",rating:" + Faker.Number.RandomNumber(0, 5) +
                    ",incidents: \"" + Faker.Lorem.Sentence(6) + "\""
                    + "}]-> (v) RETURN rel.id as id");

                var result = await cursor.SingleAsync(record => record["id"].As<string>());
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
