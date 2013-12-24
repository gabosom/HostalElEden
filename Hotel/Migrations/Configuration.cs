namespace HotelEden.Migrations
{
    using HotelEden.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    public class Configuration : DbMigrationsConfiguration<HotelEden.Models.HotelContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        //http://blogs.msdn.com/b/adonet/archive/2012/02/09/ef-4-3-code-based-migrations-walkthrough.aspx

        protected override void Seed(HotelEden.Models.HotelContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            //HotelContext context = new HotelContext();

            //Adding roomtypes
            List<RoomType> roomTypes = new List<RoomType>{
                                           new RoomType{
                                               Description = "Sencillo",
                                               Rate = 10,
                                               MaxGuestNo = 1,
                                               URL = "http://1"
                                           },
                                           new RoomType{
                                               Description = "Doble",
                                               Rate = 20,
                                               MaxGuestNo = 2,
                                               URL = "http://2"
                                           },
                                           new RoomType{
                                               Description = "Triple",
                                               Rate = 30,
                                               MaxGuestNo = 3,
                                               URL = "http://3"
                                           },
                                           new RoomType{
                                               Description = "Cuadruple",
                                               Rate = 40,
                                               MaxGuestNo = 4,
                                               URL = "http://4"
                                           }
                                       };

            foreach (RoomType rt in roomTypes)
            {
                context.RoomTypes.Add(rt);

            }
            context.SaveChanges();

            //adding rooms
            List<Room> rooms = new List<Room>
            {
                new Room{
                    Floor=1,
                    RoomNumber=01,
                    RoomTypeId=1
                },

                new Room{
                    Floor=1,
                    RoomNumber=02,
                    RoomTypeId=1
                },

                new Room{
                    Floor=2,
                    RoomNumber=10,
                    RoomTypeId=2
                },

                new Room{
                    Floor=2,
                    RoomNumber=11,
                    RoomTypeId=3
                },

                new Room{
                    Floor=2,
                    RoomNumber=12,
                    RoomTypeId=4
                }
            };

            foreach (Room r in rooms)
            {
                context.Rooms.Add(r);

            }
            context.SaveChanges();



                    }
    }
}
