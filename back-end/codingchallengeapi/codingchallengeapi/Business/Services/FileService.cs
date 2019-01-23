using codingchallengeapi.Business.Interfaces;
using codingchallengeapi.Data.Models;
using codingchallengeapi.Utils;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace codingchallengeapi.Business.Services
{
    public class FileService : IFileService
    {
        private IHostingEnvironment _hostEnviroment;
        private AppSettings _appSettings;


        public FileService(IHostingEnvironment hostingEnvironment, AppSettings appSettings)
        {
            _hostEnviroment = hostingEnvironment;
            _appSettings = appSettings;
        }

        public RequestResult<IList<VehicleSalesData>> CsvReader(string fileName)
        {
            string newPath = Path.Combine(_hostEnviroment.WebRootPath, _appSettings.FileRepositoryFolderName);
            var file = Path.Combine(newPath, fileName);
            var vehicleSalesDataList = new List<VehicleSalesData>();
            StreamReader sr = new StreamReader(file);
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
            sr.Close();
            File.Delete(file);

            return new RequestResult<IList<VehicleSalesData>>()
            {
                Data = vehicleSalesDataList,
                IsSuccess = true
            };

        }

        public void LoadFile()
        {

        }

        public RequestResult<bool> UploadFile(IFormCollection form)
        {
            try
            {
                var file = form.Files.First();
                string newPath = Path.Combine(_hostEnviroment.WebRootPath, _appSettings.FileRepositoryFolderName);

                if (!Directory.Exists(newPath))
                {
                    Directory.CreateDirectory(newPath);
                }

                if (file.Length > 0)
                {
                    string fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    string fullPath = Path.Combine(newPath, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }

                return new RequestResult<bool>()
                {
                    IsSuccess = true,
                    Data = true,
                    Message = "Upload Successful"
                };

            }
            catch (Exception e)
            {
                return new RequestResult<bool>()
                {
                    IsSuccess = false,
                    Data = false,
                    Message = $"Upload Failed:{ e.Message}"
                };
            }
        }

    }
}
