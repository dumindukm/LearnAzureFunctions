using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public interface IImageUploadService
    {
        Task<bool> UploadImage(Stream stream, string filename);

    }
}
