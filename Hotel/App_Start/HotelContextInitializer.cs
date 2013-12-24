using HotelEden.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Devtalk.EF.CodeFirst;
using System.Data.Entity.Migrations;
using HotelEden.Migrations;

namespace HotelEden.App_Start
{
    public class HotelContextInitializer : MigrateDatabaseToLatestVersion<HotelContext, Configuration>
    //public class HotelContextInitializer : DropCreateDatabaseAlways<HotelContext>
    //public class HotelContextInitializer : DontDropDbJustCreateTablesIfModelChanged<HotelContext>
    {
    }
}