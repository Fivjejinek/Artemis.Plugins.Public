using Artemis.Core;
using Artemis.Core.Services;
using Artemis.Plugins.ExtendedWebAPI.Controllers;

namespace Artemis.Plugins.ExtendedWebAPI.Features
{
    [PluginFeature(Name = "Artemis Windows caller Web Api", Description = "Offers a web API to show specific Artemis Windows or UIs", Icon = "Application")]
    public class WindowsWebApi : PluginFeature
    {
        private readonly IWebServerService _webServerService;

        public WindowsWebApi(IWebServerService webServerService)
        {
            _webServerService = webServerService;
        }

        public override void Enable()
        {
            // Supply a base path string for each controller
            _webServerService.AddController<WindowsController>(this, "/extended-rest-api/windows");
            _webServerService.AddController<ColorController>(this, "/extended-rest-api/colors");
        }

        public override void Disable()
        {
        }
    }
}
