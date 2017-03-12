
using UnityEngine;

namespace Elurnity.Animations
{
    public struct Vector2Property : Property<Vector2>
    {
        public Vector2 Lerp(Vector2 src, Vector2 dst, float prog)
        {
            return Vector2.Lerp(src, dst, prog);
        }

        public static implicit operator Vector2Property(Vector2 d)
        {
            return new Vector2Property();
        }
    }
}