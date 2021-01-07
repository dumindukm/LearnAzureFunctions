using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AppCore.Entities
{
    public class ImageDetails
    {
        public string Caption { get; set; }
        public string ImageName { get; set; }
        [JsonIgnore]
        public Stream Image { get; set; }
    }
}
