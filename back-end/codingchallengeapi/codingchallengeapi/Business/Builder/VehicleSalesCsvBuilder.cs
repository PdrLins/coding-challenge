using codingchallengeapi.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace codingchallengeapi.Business.Builder
{
    public class VehicleSalesCsvBuilder : ICSVBuilder<VehicleSalesData>
    {
        public IList<VehicleSalesData> Build(Stream stream)
        {
            var vehicleSalesDataList = new List<VehicleSalesData>();
            using (StreamReader sr = new StreamReader(stream))
            {
                int line = 0;

                while (!sr.EndOfStream)
                {
                    Regex regexParse = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");

                    var strLine = sr.ReadLine();
                    var fields = regexParse.Split(strLine).Select(s =>
                    {
                        return s = s.TrimStart(' ', '"').TrimEnd('"');
                    }).ToArray();
                    if (line == 0)
                    {
                        VehicleSaleScheme(fields);
                    }
                    if (line != 0)
                    {
                        var vehicleSalesData = new VehicleSalesData()
                        {
                            DealNumber = Convert.ToInt32(fields[0]),
                            CustomerName = fields[1],
                            DealershipName = fields[2],
                            Vehicle = fields[3],
                            Price = Convert.ToDouble(fields[4]),
                            Date = Convert.ToDateTime(fields[5], new CultureInfo("en-ca", false))
                        };

                        vehicleSalesDataList.Add(vehicleSalesData);
                    }
                    line++;
                }
            }

            return vehicleSalesDataList;
        }

        public void VehicleSaleScheme(string[] columnsFile)
        {
            var schemeColumn = new List<string>() { "DealNumber", "CustomerName", "DealershipName", "Vehicle", "Price", "Date" };

            if (columnsFile.Length != schemeColumn.Count())
            {
                throw new ArgumentException("Different scheme accepted, ");
            }

            if (columnsFile.Any(a=> !schemeColumn.Contains(a)))
            {
                throw new ArgumentException("Different scheme accepted");
            }
        }
    }

}
