using System;
namespace Elurnity.Animations
{
    public class SimpleAnimation<P, S, T> : Animation<P, S, T>
        where P : Property<P>, new()
        where S : ISubject<P>
        where T : Transition
    {
        public readonly P from;
        public readonly P to;

        public SimpleAnimation(P from, P to, S subject, T transition, string name = null)
            : base(from, subject, transition, name)
        {
            this.from = from;
            this.to = to;
        }

        protected override P Value(float progress)
        {
            return from.Lerp(from, to, progress);
        }

        public static SimpleAnimation<Prop, Sub, Trans> Create<Prop, Sub, Trans>(Prop from, Prop to, Sub subject, Trans transition, string name = null)
            where Prop : Property<Prop>, new()
            where Sub : ISubject<Prop>
            where Trans : Transition
        {
            return new SimpleAnimation<Prop, Sub, Trans>(from, to, subject, transition, name);
        }
    }
}
