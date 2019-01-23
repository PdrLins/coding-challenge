using codingchallengeapi.Business.Interfaces;
using codingchallengeapi.Data.Models;
using codingchallengeapi.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace codingchallengeapi.Business.Services
{
    public class FileService : IFileService
    {
        private IHostingEnvironment _hostEnviroment;
        private readonly ICSVRuleBuilder _csvRuleBuilder;
        private AppSettings _appSettings;


        public FileService(ICSVRuleBuilder csvRuleBuilder, AppSettings appSettings, IHostingEnvironment hostingEnvironment)
        {
            _hostEnviroment = hostingEnvironment;
            _csvRuleBuilder = csvRuleBuilder;
            _appSettings = appSettings;
        }
        

        public RequestResult<IList<VehicleSalesData>> ReadVehicleSaleDataCsv(IFormCollection form)
        {
            var vehicleSalesDataList = new List<VehicleSalesData>();
            try
            {
                var file = form.Files.First();

                if (file.Length > 0)
                {

                    using (var stream = file.OpenReadStream())
                    {
                        vehicleSalesDataList.AddRange(_csvRuleBuilder.VehicleSalesDataRule(stream));
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
                    Message = $"Upload Failed:{ e.Message}"
                };
            }
        }
    }
}
