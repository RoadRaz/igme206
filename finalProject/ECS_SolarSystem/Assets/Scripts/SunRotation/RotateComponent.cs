using System;
using Unity.Entities;

[Serializable]
public struct RotateComponent : IComponentData
{
    // Data to be used for Rotation
    public float radiansPerSecond;
}


//public static float3 RotateAroundPoint(float3 position, float3 pivot, float3 axis, float delta) => math.mul(quaternion.axisAngle(axis, delta), position - pivot) + pivot;