using AppCore.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.services.interfaces
{
    public interface IImageUploadService
    {
        Task<string> UploadImage(ImageDetails imageDetails);
    }
}
