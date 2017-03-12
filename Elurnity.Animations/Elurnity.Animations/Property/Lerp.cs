
using System;

namespace Elurnity.Animations
{
    public interface ILerp<T>
    {
        T Lerp(T src, T dst, float prog);
    }

    public delegate T LerpDelegate<T>(T src, T dst, float prog);

    public static class Lerps
    {
        public static T Lerp<T>(T src, T dst, float prog)
        {
            if (Cache<T>.instance != null)
            {
                return Cache<T>.instance(src, dst, prog);
            }

            if (src is ILerp<T>)
            {
                Register<T>(((ILerp<T>)src).Lerp);

                return Cache<T>.instance(src, dst, prog);
            }

            throw new Exception(typeof(T) + " doesn't implement the ILerp interface, please register a surrogate or implement the inteface");
        }

        private class Cache<T>
        {
            public static LerpDelegate<T> instance;
        }

        public static void Register<T>(LerpDelegate<T> @delegate)
        {
            Cache<T>.instance = @delegate;
        }
    }
}
