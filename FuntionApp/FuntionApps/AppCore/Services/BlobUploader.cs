using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Services
{
    public class BlobUploader : IImageUploadService
    {

        public BlobUploader()
        {
        }

        public async  Task<bool> UploadImage(Stream stream , string filename)
        {
            return await AzureBlobUtil.UploadToBlob(stream, filename);
        }


    }
}
