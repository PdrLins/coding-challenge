using System;

namespace codingchallengeapi.Data.Models
{
    public class VehicleSalesData 
    {

        public int DealNumber { get; set; }
        public string CustomerName { get; set; }
        public string DealershipName { get; set; }
        public string Vehicle { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }

        public VehicleSalesData FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(",");
            VehicleSalesData vehicleSalesCsvData = new VehicleSalesData()
            {
                DealNumber = Convert.ToInt32(values[0]),
                CustomerName = values[1],
                DealershipName = values[2],
                Vehicle = values[3],
                Price = Convert.ToDouble(values[4]),
                Date = Convert.ToDateTime(values[5])
            };


            return vehicleSalesCsvData;
        }

    }
}
