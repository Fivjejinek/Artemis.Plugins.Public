using Artemis.Core.Services;
using Artemis.Core;
using Artemis.Plugins.Modules.Json.Controllers;

namespace Artemis.Plugins.Modules.Json
{
    [PluginFeature(Name = "Json Module")]
    public class JsonModule : Module<JsonDataModel>
    {
        private readonly IWebServerService _webServerService;
        private WebApiControllerRegistration? _controllerRegistration;

        public JsonModule(IWebServerService webServerService)
        {
            _webServerService = webServerService;
        }

        public override void Enable()
        {
            // Add controller with explicit path
            _controllerRegistration = _webServerService.AddController<JsonController>(this, "json");
        }

        public override void Disable()
        {
            if (_controllerRegistration != null)
                _webServerService.RemoveController(_controllerRegistration);
        }
    }
}
