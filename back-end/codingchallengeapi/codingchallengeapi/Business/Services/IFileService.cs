using codingchallengeapi.Data.Models;
using codingchallengeapi.Utils;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace codingchallengeapi.Business.Services
{
    public interface IFileService
    {
        RequestResult<IList<VehicleSalesData>> ImportVehicleSaleDataFromCsv(IFormCollection form);
    }
}
