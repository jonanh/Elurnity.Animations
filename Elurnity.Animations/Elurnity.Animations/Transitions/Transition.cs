
using Elurnity.BehaviourTrees;

namespace Elurnity.Animations
{
    public interface Transition : INode
    {
        float Progress
        {
            get;
        }
    }
}
