using codingchallengeapi.Business.Builder;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestPerfectVehicleSalesCsvBuilder()
        {
            var schemeColumn = new List<string>() { "DealNumber", "CustomerName", "DealershipName", "Vehicle", "Price", "Date" };


            var builder = new VehicleSalesCsvBuilder();
            builder.VehicleSaleScheme(schemeColumn.ToArray());
            //var parser = new MessageTypeParser();

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestVeLessColumnhicleSalesCsvBuilder()
        {
            var schemeColumn = new List<string>() { "CustomerName", "DealershipName", "Vehicle", "Price", "Date" };
            var builder = new VehicleSalesCsvBuilder();
            builder.VehicleSaleScheme(schemeColumn.ToArray());

            //AssertionException

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void TestDifferentColumnVehicleSalesCsvBuilder()
        {
            var schemeColumn = new List<string>() { "xx", "DealershipName", "Vehicle", "Price", "Date" };
            var builder = new VehicleSalesCsvBuilder();
            builder.VehicleSaleScheme(schemeColumn.ToArray());
        }
    }
}
