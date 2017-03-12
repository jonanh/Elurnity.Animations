
using UnityEngine;

namespace Elurnity.Animations
{
    public struct QuaternionProperty : Property<Quaternion>
    {
        public Quaternion Lerp(Quaternion src, Quaternion dst, float prog)
        {
            return Quaternion.Lerp(src, dst, prog);
        }

        public static implicit operator QuaternionProperty(Quaternion d)
        {
            return new QuaternionProperty();
        }
    }
}