using Autofac;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;

namespace SQLServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            using (var scope = container.BeginLifetimeScope())
            {
                var unitOfwork = scope.Resolve<IUnitOfWork>();

                var user = new Models.User
                {
                    email = Faker.User.Email(),
                    name = "Viana",
                };

                Console.WriteLine($"Addinng the user: {user}....");

                unitOfwork.UsersRepository.Add(user);
                unitOfwork.SaveChanges();
            }


            //try
            //{
            //    using (var db = new MicromobililtyContext())
            //    {
            //        var user = new Models.User
            //        {
            //            email = Faker.User.Email(),
            //            name = "Mário",

            //        };

            //        Console.WriteLine("Adding Mário to the database...");

            //        db.users.Add(user);

            //        db.SaveChanges();

            //        Console.WriteLine("Mário added!");
            //        Console.ReadLine();

            //    }
            //}
            //catch (DbEntityValidationException e)
            //{
            //    foreach (var eve in e.EntityValidationErrors)
            //    {
            //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //            eve.Entry.Entity.GetType().Name, eve.Entry.State);


            //        foreach (var ve in eve.ValidationErrors)
            //        {
            //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                ve.PropertyName, ve.ErrorMessage);
            //        }
            //    }
            //    Console.ReadLine();
            //}

            //using (var db = new MicromobililtyContext())
            //{
            //    #region RUN ONLY ONE TIME
            //    //#region UNITS OF MEASURE
            //    //var unitOfMeasurement = new Models.unit_measurements
            //    //{
            //    //    unit_measurement = "Km"
            //    //};

            //    //Console.WriteLine($"Inserting Unit of measurement: {unitOfMeasurement.unit_measurement}...");

            //    //db.unit_measurements.Add(unitOfMeasurement);
            //    //db.SaveChanges();

            //    //Console.WriteLine($"Unit of measurement {unitOfMeasurement.unit_measurement} was inserted successfully");
            //    //#endregion

            //    //#region PAYMENT METHODS
            //    //var paymentMethod = new Models.payment_method
            //    //{
            //    //    payment_type = "Card"
            //    //};

            //    //Console.WriteLine($"Inserting Payment method: {paymentMethod.payment_type}...");

            //    //db.payment_method.Add(paymentMethod);
            //    //db.SaveChanges();

            //    //Console.WriteLine($"Payment method {paymentMethod.payment_type} was inserted successfully");
            //    //#endregion

            //    //#region LANGUAGES

            //    //var language = new Models.Language
            //    //{
            //    //    language1 = "ENGLISH"
            //    //};

            //    //Console.WriteLine($"Inserting user: {language.language1}...");

            //    //db.Languages.Add(language);
            //    //db.SaveChanges();

            //    //Console.WriteLine($"User: {language.language1} was inserted successfully");

            //    //#endregion 
            //    #endregion

            //    //var users = new List<Models.user>();
            //    //try
            //    //{
            //    //    for (int i = 0; i < 399999; i++)
            //    //    {
            //    //        var user = new Models.user
            //    //        {
            //    //            email = Faker.User.Email(),
            //    //            name = Faker.Name.FirstName(),
            //    //            nome_utilizador = Faker.User.Username(),
            //    //            numero_conta = Faker.Number.RandomNumber(10).ToString(),
            //    //            password = Faker.User.Password(),
            //    //            id_language = 1,
            //    //            id_payment_method = 1,
            //    //            id_unit_measurement = 1
            //    //        };
            //    //        users.Add(user);

            //    //        //Console.WriteLine($"Inserting user: {user.name}...");

            //    //        //db.users.Add(user);
            //    //        //db.SaveChanges();

            //    //        //Console.WriteLine($"User #: {i} - {user.name} was inserted successfully");
            //    //    }
            //    //    Console.WriteLine("Inserting Users...");
            //    //    db.BulkInsert(users);
            //    //    db.SaveChanges();
            //    //}
            //    //catch (DbEntityValidationException e)
            //    //{
            //    //    foreach (var eve in e.EntityValidationErrors)
            //    //    {
            //    //        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //    //            eve.Entry.Entity.GetType().Name, eve.Entry.State);


            //    //        foreach (var ve in eve.ValidationErrors)
            //    //        {
            //    //            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //    //                ve.PropertyName, ve.ErrorMessage);
            //    //        }
            //    //    }
            //    //    Console.ReadLine();
            //    //}
            //    //catch (Exception ex)
            //    //{
            //    //    Console.WriteLine($"Message: {ex.Message}");
            //    //    Console.WriteLine($"StackTrace: {ex.StackTrace}");
            //    //    Console.ReadLine();
            //    //}

            //}
            PopulateVehicles(9940);
        }

        private static void PopulateVehicles(int numberOfVehicles)
        {
            try
            {
                using (var db = new MicromobililtyContext())
                {
                    var vehicles = new List<Models.Vehicle>();

                    for (int i = 0; i < numberOfVehicles; i++)
                    {
                        var vehicle = new Models.Vehicle
                        {
                            active = Faker.Number.Bool(),
                            latitude = Faker.GeoLocation.Latitude(),
                            longitude = Faker.GeoLocation.Longitude(),
                            status = Faker.Number.Bool() == true ? "on the move" : "stationary"
                        };

                        vehicles.Add(vehicle);
                    }

                    db.BulkInsert(vehicles);
                    db.SaveChanges();
                }
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);


                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Message: {ex.Message}");
                Console.WriteLine($"StackTrace: {ex.StackTrace}");
                Console.ReadLine();
            }

        }
    }
}
