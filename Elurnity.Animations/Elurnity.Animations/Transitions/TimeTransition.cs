
using Elurnity.BehaviourTrees;

namespace Elurnity.Animations
{
    public struct TimeTransition : Transition
    {
        public float Duration;
        private float time;

        public void Start(Context context)
        {
            this.time = 0;
        }

		public void Stop(Context context)
        {
            this.time = this.Duration;
        }

		public Status Tick(Context context, float time)
        {
            this.time += time;

            return Progress >= 1 ? Status.Success : Status.Running;
        }

        public float Progress
        {
            get
            {
                if (Duration <= float.Epsilon) 
                    return 1;
                
                var result = this.time / Duration;

                if (result < 0)
                    return 0;

                if (result > 0)
                    return 1;

                return result;
            }
        }
    }
}
