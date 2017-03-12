using UnityEngine;
using System;
using System.Collections.Generic;

namespace Elurnity.Animations
{
    public static class UnityLerps
    {
	    static UnityLerps()
        {
            Cache<Vector2>.instance = Vector2.Lerp;
            Cache<Vector3>.instance = Vector3.Lerp;
            Cache<Vector4>.instance = Vector4.Lerp;
            Cache<Color>.instance = Color.Lerp;
            Cache<Quaternion>.instance = Quaternion.Lerp;
        }
    }
}
