
using System;
using System.Collections;

using Elurnity.BehaviourTrees;

namespace Elurnity.Animations
{
    public abstract class Animation : Node
    {
        public Animation(string name) 
            : base(name)
        {
        }
    }

    public abstract class Animation<P, S, T> : Animation
        where P : Property<P>, new()
        where S : ISubject<P>
        where T : Transition
    {
        protected P property;
        protected S subject;
        protected T transition;

        public Animation(P property, S subject, T transition, string name = null) 
            : base(name)
        {
            this.subject = subject;
            this.property = property;
            this.transition = transition;
        }

        protected abstract P Value(float progress);

        public override Status Tick(Context context, float time)
        {
            transition.Tick(context, time);

            subject.Apply(Value(transition.Progress));

            return transition.Progress >= 1 ? Status.Success : Status.Running;
        }
    }
}
