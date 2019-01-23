using codingchallengeapi.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace codingchallengeapi.Business.Interfaces
{
    public class CSVRuleBuilderService : ICSVRuleBuilder
    {
        public CSVRuleBuilderService()
        {

        }

        public IList<VehicleSalesData> VehicleSalesDataRule(Stream stream)
        {
            var vehicleSalesDataList = new List<VehicleSalesData>();

            using (StreamReader sr = new StreamReader(stream))
            {
                int line = 0;

                while (!sr.EndOfStream)
                {
                    var strLine = sr.ReadLine();
                    if (line != 0)
                    {
                        Regex regexParse = new Regex(",(?=(?:[^\"]*\"[^\"]*\")*(?![^\"]*\"))");
                        var fields = regexParse.Split(strLine).Select(s =>
                        {
                            return s = s.TrimStart(' ', '"').TrimEnd('"');
                        }).ToArray();


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

        private void VehicleSaleScheme()
        {
            //desenhar aqui o check para saber se o layout que entrou é correto
        }
    }
    
}
