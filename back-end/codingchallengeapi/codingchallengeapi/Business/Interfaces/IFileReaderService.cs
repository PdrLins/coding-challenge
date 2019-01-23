using codingchallengeapi.Data.Models;
using codingchallengeapi.Utils;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace codingchallengeapi.Business.Interfaces
{
    public interface IFileService
    {
        RequestResult<IList<VehicleSalesData>> CsvReader(string fileName);
        RequestResult<bool> UploadFile(IFormCollection form);
        void LoadFile();
    }
}
