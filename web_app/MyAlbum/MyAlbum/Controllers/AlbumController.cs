using AppCore.Entities;
using AppCore.services.interfaces;
using Microsoft.AspNetCore.Mvc;
using MyAlbum.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MyAlbum.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IImageUploadService imageUploadService;

        public AlbumController(IImageUploadService imageUploadService)
        {
            this.imageUploadService = imageUploadService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Upload(ImageData imageData)
        {
            var imageDetails = new ImageDetails();
            imageDetails.Caption = imageData.Caption;
            imageDetails.ImageName = imageData.Image.FileName;

            var memoryStream = new MemoryStream();
            await imageData.Image.CopyToAsync(memoryStream);
            imageDetails.Image = memoryStream;

            var result = await this.imageUploadService.UploadImage(imageDetails);
            return new JsonResult(result);
        }


    }
}
