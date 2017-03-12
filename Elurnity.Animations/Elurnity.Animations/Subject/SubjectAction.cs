
using System;
using System.Collections;

namespace Elurnity.Animations
{
    public class SubjectAction<P> : ISubject<P>
        where P : Property<P>
    {
        private Action<P> fn;

        public SubjectAction(Action<P> fn)
        {
            this.fn = fn;
        }

        public void Apply(P data)
        {
            fn(data);
        }
    }
}