using AppCore.Services;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(ImageUploadFunction.Startup))]

namespace ImageUploadFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            //builder.Services.AddHttpClient();

            builder.Services.AddSingleton<IImageUploadService>((s) => {
                return new BlobUploader();
            });

            //builder.Services.AddSingleton<ILoggerProvider, MyLoggerProvider>();
        }
    }
}