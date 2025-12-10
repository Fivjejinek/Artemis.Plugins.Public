using Artemis.Core;
using Artemis.Core.Services;
using Artemis.Plugins.Nodes.Extra.MathNodes;

namespace Artemis.Plugins.Nodes.MathExtra
{
    [PluginFeature(Name = "Math Extra Nodes")]
    public class MathExtraPluginBootstrapper : PluginFeature
    {
        private readonly INodeService _nodeService;

        public MathExtraPluginBootstrapper(INodeService nodeService)
        {
            _nodeService = nodeService;
        }

        public override void Enable()
        {
            // Register your custom math nodes
            _nodeService.RegisterNode<DivideNumericsNode>();
            _nodeService.RegisterNode<FullLerpNode>();
            _nodeService.RegisterNode<MultiplyNode>();
            _nodeService.RegisterNode<PercentageOfNode>();
            _nodeService.RegisterNode<AbsNumericNode>();
        }

        public override void Disable()
        {
            // Nothing to clean up
        }
    }
}
