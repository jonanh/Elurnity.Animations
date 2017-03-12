using UnityEngine;

namespace Waylib.Animations
{
    public struct SubjectTransform : ISubject<TransformProperty>
    {
        Transform transform;

        public SubjectTransform(Transform transform)
        {
            this.transform = transform;
        }

        public void Apply(TransformProperty data)
        {
            transform.localScale = data.localScale;
            transform.localPosition = data.localPosition;
            transform.localRotation = data.localRotation;
        }

        public static implicit operator SubjectTransform(Transform transform)
        {
            return new SubjectTransform(transform);
        }
    }
}
