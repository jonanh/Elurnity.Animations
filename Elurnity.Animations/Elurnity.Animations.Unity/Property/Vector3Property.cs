
using UnityEngine;

namespace Elurnity.Animations
{
    public struct Vector3Property : Property<Vector3>
    {
        public Vector3 Lerp(Vector3 src, Vector3 dst, float prog)
        {
            return Vector3.Lerp(src, dst, prog);
        }

        public static implicit operator Vector3Property(Vector3 d)
        {
            return new Vector3Property();
        }
    }
}
