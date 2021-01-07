using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAlbum.Models
{
    public class ImageData
    {
        public string Caption { get; set; }
        public IFormFile Image { get; set; }
    }
}
