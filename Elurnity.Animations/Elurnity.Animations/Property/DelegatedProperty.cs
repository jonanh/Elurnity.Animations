
using System;

namespace Elurnity.Animations
{
    public struct DelegatedProperty<T> : Property<T>
    {
        private Func<T, T, float, T> fn;

        public DelegatedProperty(Func<T, T, float, T> fn)
        {
            this.fn = fn;
        }

        public T Lerp(T src, T dst, float prog)
        {
            return fn(src, dst, prog);
        }
    }
}
