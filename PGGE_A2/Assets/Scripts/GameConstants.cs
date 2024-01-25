using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PGGE
{
    public static class CameraConstants
    {
        public static Vector3 CameraAngleOffset { get; set; }
        public static Vector3 CameraPositionOffset { get; set; }
        public static float Damping { get; set; }
        public static float RotationSpeed { get; set; }
        public static float MinPitch { get; set; }
        public static float MaxPitch { get; set; }
    }

    public static class GameConstant
    {
        public static Dictionary<int, string> ModelReference { get; set; }
        public static string Character { get; set; }
        
    }
}
