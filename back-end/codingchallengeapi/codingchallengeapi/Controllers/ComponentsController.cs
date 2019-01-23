using codingchallengeapi.Business.Interfaces;
using codingchallengeapi.Controllers.Inputs;
using codingchallengeapi.Utils;
using Microsoft.AspNetCore.Mvc;

namespace codingchallengeapi.Controllers
{

    public class ComponentsController : Controller
    {
        private readonly IFileService _IfileService;

        public ComponentsController(IFileService fileService)
        {
            _IfileService = fileService;
        }

        [HttpPost, DisableRequestSizeLimit]
        public ActionResult UploadFile()
        {
            var result = _IfileService.UploadFile(Request.Form);
            return Json(result);
        }

        [HttpPost]
        public ActionResult LoadFile([FromBody] LoadFileInput input)
        {
            if (string.IsNullOrWhiteSpace(input.FileName))
                return Json(new RequestResult<bool>() {Data = false, IsSuccess = false, Message = "File Name was not informed"});

            var result = _IfileService.CsvReader(input.FileName);
            return Json(result);

        }
    }
}
