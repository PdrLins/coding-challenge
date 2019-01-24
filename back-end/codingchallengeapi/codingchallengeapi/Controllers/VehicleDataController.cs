using codingchallengeapi.Business.Services;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace codingchallengeapi.Controllers
{

    public class VehicleDataController : Controller
    {
        private readonly IFileService _fileService;
        public VehicleDataController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public ActionResult ImportSalesFromCsvFile()
        {
            var result = _fileService.ImportVehicleSaleDataFromCsv(Request.Form);
                var mostSold = result.Data.GroupBy(g => g.Vehicle)
                                      .Select(s => new { s.Key, Qty = s.Count() }).OrderByDescending(o => o.Qty).FirstOrDefault();
                return Json(new { result.IsSuccess, result.Message, result.Data, MostSold = mostSold });

          
        }
    }

}
