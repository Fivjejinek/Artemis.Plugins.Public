using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Artemis.Core;
using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using RGB.NET.Core;
using Serilog;

namespace Artemis.Plugins.ExtendedWebAPI.Controllers
{
    internal class ColorController : WebApiController
    {
        private readonly RGBSurface _surface;
        private readonly ILogger _logger;

        public ColorController(RGBSurface surface, ILogger logger)
        {
            _surface = surface;
            _logger = logger;
        }

        [Route(HttpVerbs.Get, "/extended-rest-api/get-led-color/{deviceName}/{ledId}")]
        public async Task GetLedColor(string deviceName, string ledId)
        {
            var device = _surface.Devices
                .OfType<ArtemisDevice>()
                .FirstOrDefault(d => d.RgbDevice.DeviceInfo.DeviceName == deviceName);

            if (device == null)
            {
                string message = $"Device {deviceName} doesn't exist";
                _logger.Information(message);
                throw HttpException.NotFound(message);
            }

            if (!Enum.TryParse(typeof(LedId), ledId, true, out object parsedLedId))
            {
                string message = $"Led Id {ledId} doesn't exist";
                _logger.Information(message);
                throw HttpException.NotFound(message);
            }

            var led = device.LedIds[(LedId)parsedLedId].RgbLed;

            if (led == null)
            {
                string message = $"Led Id {ledId} doesn't exist in device {deviceName}";
                _logger.Information(message);
                throw HttpException.NotFound(message);
            }

            HttpContext.Response.ContentType = "text/plain";
            await using var writer = HttpContext.OpenResponseText(new UTF8Encoding(false));
            await writer.WriteAsync(led.Color.AsRGBHexString());
        }
    }
}
