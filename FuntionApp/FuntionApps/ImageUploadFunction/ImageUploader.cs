using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using AppCore.Entities;
using AppCore.Services;

namespace ImageUploadFunction
{
    public  class ImageUploader
    {
        IImageUploadService imageUplaodService = null;
        public ImageUploader(IImageUploadService imageUplaod)
        {
            this.imageUplaodService = imageUplaod;
        }

        [FunctionName("ImageUploader")]
        public  async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            

            var imageDetails = JsonConvert.DeserializeObject<ImageDetails>( req.Form["imageDetails"].ToString());

            //IImageUploadService imageUplaod = new BlobUploader();
            foreach (var file in req.Form.Files)
            {
                var fs = new MemoryStream();// (file.FileName, FileMode.Create);
                await file.CopyToAsync(fs);
                var result = await this.imageUplaodService.UploadImage(fs, file.FileName);

            }

            return new OkObjectResult("success");
        }
    }
}
