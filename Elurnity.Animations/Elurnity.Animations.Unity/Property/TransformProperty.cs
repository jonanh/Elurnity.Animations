
using UnityEngine;

namespace Elurnity.Animations
{
    public struct TransformProperty : Property<TransformProperty>
    {
        public Vector3 localPosition;
        public Vector3 localScale;
        public Quaternion localRotation;

        public TransformProperty(Vector3 localPosition, Vector3 localScale, Quaternion localRotation)
        {
            this.localPosition = localPosition;
            this.localScale = localScale;
            this.localRotation = localRotation;
        }

        public TransformProperty Lerp(TransformProperty src, TransformProperty dst, float prog)
        {
            return new TransformProperty()
            {
                localPosition = Vector3.Lerp(src.localPosition, dst.localPosition, prog),
                localScale = Vector3.Lerp(src.localScale, dst.localScale, prog),
                localRotation = Quaternion.Lerp(src.localRotation, dst.localRotation, prog),
            };
        }

        public static implicit operator TransformProperty(Transform d)
        {
            return new TransformProperty(
                localPosition: d.localPosition,
                localScale: d.localScale,
                localRotation: d.localRotation
            );
        }

        public static TransformProperty InverseTransformProperty(RectTransform transform, RectTransform target, Canvas transformCanvas = null, Canvas targetCanvas = null)
        {
            transformCanvas = transformCanvas ?? transform.CanvasRoot();
            targetCanvas = targetCanvas ?? target.CanvasRoot();

            var initialSize = transform.InScreenSize(transformCanvas);

            var targetSize = target.InScreenSize(targetCanvas);

            var finalScale = new Vector3(
                targetSize.x / initialSize.x * transform.localScale.x, 
                targetSize.y / initialSize.y * transform.localScale.y);

            var finalPosition = transform.InverseTransformPoint(target);

            return new TransformProperty(
                localPosition: finalPosition,
                localScale: finalScale,
                localRotation: target.localRotation
            );
        }
    }
}
