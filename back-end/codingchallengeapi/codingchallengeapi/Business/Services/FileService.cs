using codingchallengeapi.Business.Builder;
using codingchallengeapi.Data.Models;
using codingchallengeapi.Utils;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace codingchallengeapi.Business.Services
{
    public class FileService : IFileService
    {
        public FileService()
        {
        }

        public RequestResult<IList<VehicleSalesData>> ImportVehicleSaleDataFromCsv(IFormCollection form)
        {
            var vehicleSalesDataList = new List<VehicleSalesData>();
            try
            {
                var file = form.Files.First();

                if (file.Length > 0)
                {
                    using (var stream = file.OpenReadStream())
                    {
                        var builder = new VehicleSalesCsvBuilder();
                        var items = builder.Build(stream);
                        vehicleSalesDataList.AddRange(items);
                    }
                }
                return new RequestResult<IList<VehicleSalesData>>()
                {
                    IsSuccess = true,
                    Data = vehicleSalesDataList,
                    Message = "Upload Successful"
                };

            }
            catch (Exception e)
            {
                return new RequestResult<IList<VehicleSalesData>>()
                {
                    IsSuccess = false,
                    Data = vehicleSalesDataList,
                    Message = $"Upload Failed: { e.Message}"
                };
            }
        }
    }
}
