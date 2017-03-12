using UnityEngine;

using Waylib.Serialization;
using Waylib.BehaviourTree;

namespace Waylib.Animations
{
    public struct AnimationCurveTransition : Transition
    {
        public AnimationCurve curve;
        private float time;

        public void Start(Container container)
        {
            this.time = 0;
        }

        public void Stop()
        {
            if (curve.length > 0)
            {
                this.time = curve[curve.length].time;
            }
        }

        public BehaviourTreeStatus Tick(float time)
        {
            this.time += time;

            return Progress >= 1 ? BehaviourTreeStatus.Success : BehaviourTreeStatus.Running;
        }

        public float Duration
        {
            get
            {
                var curveLenght = curve.length;
                return curve[curveLenght].time;
            }
        }

        public float Progress
        {
            get
            {
                var clampedTime = Mathf.Clamp(time, 0, Duration);
                return curve.Evaluate(clampedTime);
            }
        }
    }
}
