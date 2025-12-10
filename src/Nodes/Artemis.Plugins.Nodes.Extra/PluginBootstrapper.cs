using Artemis.Core;
using Artemis.Core.Services;
using Artemis.Plugins.Nodes.Extra.MathNodes;

namespace Artemis.Plugins.Nodes.Extra
{
    [PluginFeature(Name = "Extra Nodes")]
    public class PluginBootstrapper : PluginFeature
    {
        private readonly INodeService _nodeService;

        public PluginBootstrapper(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        public override void Enable()
        {
            _nodeService.RegisterNodeType<DivideNumericsNode>();
            _nodeService.RegisterNodeType<FullLerpNode>();
            _nodeService.RegisterNodeType<MultiplyNode>();
            _nodeService.RegisterNodeType<PercentageOfNode>();
            _nodeService.RegisterNodeType<AbsNumericNode>();
        }

        public override void Disable()
        {
            // Nothing to clean up
        }
    }
}
