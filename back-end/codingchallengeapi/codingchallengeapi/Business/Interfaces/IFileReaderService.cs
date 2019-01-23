using codingchallengeapi.Data.Models;
using codingchallengeapi.Utils;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace codingchallengeapi.Business.Interfaces
{
    public interface IFileService
    {
        RequestResult<IList<VehicleSalesData>> ReadVehicleSaleDataCsv(IFormCollection form);
    }
}
