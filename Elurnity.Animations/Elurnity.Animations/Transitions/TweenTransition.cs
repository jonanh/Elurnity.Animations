
using Elurnity.BehaviourTrees;

namespace Elurnity.Animations
{
    public struct TweenTransition<T> : Transition where T : struct, Transition
    {
        public Tween.Function Tween;
        public T transition;

        public void Start(Context context)
        {
            transition.Start(context);
        }

        public void Stop(Context context)
        {
            transition.Stop(context);
        }

        public Status Tick(Context context, float time)
        {
            return transition.Tick(context, time);
        }

        public float Progress
        {
            get
            {
                return Tween(transition.Progress);
            }
        }
    }
}
