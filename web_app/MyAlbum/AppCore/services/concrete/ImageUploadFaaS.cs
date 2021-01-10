using AppCore.Config;
using AppCore.Entities;
using AppCore.services.interfaces;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.services.concrete
{
    public class ImageUploadFaaS : IImageUploadService
    {
        private HttpClient httpClient;
        private CoreConfig config;
        public ImageUploadFaaS(HttpClient httpClient, IOptionsMonitor<CoreConfig> config)
        {
            this.httpClient = httpClient;
            this.config = config.CurrentValue;
        }

        public async Task<string> UploadImage(ImageDetails imageDetails)
        {
            var content = JsonConvert.SerializeObject(imageDetails);
            var data = new StringContent(content, Encoding.UTF8, "application/json");

            var form = new MultipartFormDataContent();

            form.Add(data, "imageDetails");
            imageDetails.Image.Position = 0;
            form.Add(new StreamContent(imageDetails.Image), "Image", imageDetails.ImageName);

            // TODO : Get URL from Environment URL
            var result = await httpClient.PostAsync(config.ImageUploaderFunctionURL, form);
            string resultContent = await result.Content.ReadAsStringAsync();
            return resultContent;
        }
    }
}
