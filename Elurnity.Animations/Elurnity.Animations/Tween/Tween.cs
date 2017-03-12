using System;

namespace Elurnity.Animations
{
    /// <summary>
    /// Defines a set of premade scale functions for use with tweens.
    /// </summary>
    /// <remarks>
    /// To avoid excess allocations of delegates, the public members of ScaleFuncs are already
    /// delegates that reference private methods.
    ///
    /// Implementations based on http://theinstructionlimit.com/flash-style-tweeneasing-functions-in-c
    /// which are based on http://www.robertpenner.com/easing/
    /// </remarks>
    public static class Tween
    {
        public delegate float Function(float progress);

        public enum Functions
        {
            Linear,
            QuadraticEaseIn,
            QuadraticEaseOut,
            QuadraticEaseInOut,
            CubicEaseIn,
            CubicEaseOut,
            CubicEaseInOut,
            QuarticEaseIn,
            QuarticEaseOut,
            QuarticEaseInOut,
            QuinticEaseIn,
            QuinticEaseOut,
            QuinticEaseInOut,
            SineEaseIn,
            SineEaseOut,
            SineEaseInOut,
        }

        public static Function GetFunction(Functions function)
        {
            switch (function)
            {
                case Functions.Linear:
                    return Linear;
                
                case Functions.QuadraticEaseIn:
                    return QuadraticEaseIn;
                case Functions.QuadraticEaseOut:
                    return QuadraticEaseOut;
                case Functions.QuadraticEaseInOut:
                    return QuadraticEaseInOut;
                
                case Functions.CubicEaseIn:
                    return CubicEaseIn;
                case Functions.CubicEaseOut:
                    return CubicEaseOut;
                case Functions.CubicEaseInOut:
                    return CubicEaseInOut;
                
                case Functions.QuarticEaseIn:
                    return QuarticEaseIn;
                case Functions.QuarticEaseOut:
                    return QuarticEaseOut;
                case Functions.QuarticEaseInOut:
                    return QuarticEaseInOut;

                case Functions.QuinticEaseIn:
                    return QuinticEaseIn;
                case Functions.QuinticEaseOut:
                    return QuinticEaseOut;
                case Functions.QuinticEaseInOut:
                    return QuinticEaseInOut;

                case Functions.SineEaseIn:
                    return SineEaseIn;
                case Functions.SineEaseOut:
                    return SineEaseOut;
                case Functions.SineEaseInOut:
                    return SineEaseInOut;
            }
            return Linear;
        }

        public static float CallFunction(Functions function, float value)
        {
            return GetFunction(function)(value);
        }

        public interface Transition
        {
            float Update(float progress);
        }

        public struct LinearTransition : Transition
        {
            public float Update(float progress)
            {
                return progress;
            }
        }

        public struct QuadraticEaseInTransition : Transition
        {
            public float Update(float progress)
            {
                return EaseInPower(progress, 2);
            }
        }

        public static readonly Function Linear = progress => progress;

        public static readonly Function QuadraticEaseIn = progress => EaseInPower(progress, 2);

        public static readonly Function QuadraticEaseOut = progress => EaseOutPower(progress, 2);

        public static readonly Function QuadraticEaseInOut = progress => EaseInOutPower(progress, 2);

        public static readonly Function CubicEaseIn = progress => EaseInPower(progress, 3);

        public static readonly Function CubicEaseOut = progress => EaseOutPower(progress, 3);

        public static readonly Function CubicEaseInOut = progress => EaseInOutPower(progress, 3);

        public static readonly Function QuarticEaseIn = progress => EaseInPower(progress, 4);

        public static readonly Function QuarticEaseOut = progress => EaseOutPower(progress, 4);

        public static readonly Function QuarticEaseInOut = progress => EaseInOutPower(progress, 4);

        public static readonly Function QuinticEaseIn = progress => EaseInPower(progress, 5);

        public static readonly Function QuinticEaseOut = progress => EaseOutPower(progress, 5);

        public static readonly Function QuinticEaseInOut = progress => EaseInOutPower(progress, 5);

        public static readonly Function SineEaseIn = SineEaseInImpl;

        public static readonly Function SineEaseOut = SineEaseOutImpl;

        public static readonly Function SineEaseInOut = SineEaseInOutImpl;

        private const float Pi = (float)Math.PI;
        private const float HalfPi = Pi / 2f;

        private static float EaseInPower(float progress, int power)
        {
            return (float)Math.Pow(progress, power);
        }

        private static float EaseOutPower(float progress, int power)
        {
            int sign = power % 2 == 0 ? -1 : 1;
            return (float)(sign * (Math.Pow(progress - 1, power) + sign));
        }

        private static float EaseInOutPower(float progress, int power)
        {
            progress *= 2;
            if (progress < 1)
            {
                return (float)Math.Pow(progress, power) / 2f;
            }
            else
            {
                int sign = power % 2 == 0 ? -1 : 1;
                return (float)(sign / 2.0 * (Math.Pow(progress - 2, power) + sign * 2));
            }
        }

        private static float SineEaseInImpl(float progress)
        {
            return (float)Math.Sin(progress * HalfPi - HalfPi) + 1;
        }

        private static float SineEaseOutImpl(float progress)
        {
            return (float)Math.Sin(progress * HalfPi);
        }

        private static float SineEaseInOutImpl(float progress)
        {
            return (float)(Math.Sin(progress * Pi - HalfPi) + 1) / 2;
        }
    }
}