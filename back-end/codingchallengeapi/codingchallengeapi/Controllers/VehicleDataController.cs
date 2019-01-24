using codingchallengeapi.Business.Services;
using Microsoft.AspNetCore.Mvc;

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
            return Json(result);
        }
    }
        
}
