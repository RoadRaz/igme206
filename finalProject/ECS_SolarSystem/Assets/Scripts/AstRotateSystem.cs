using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Mathematics;

public class AstRotateSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        // For each entity having the 'AstRotateComponent' and 'Rotation' components,
        Entities.ForEach((ref AstRotateComponent astRotateComponent, ref Rotation rotation) =>
        {
            // do this (not working)
            rotation.Value = math.mul(math.normalize(rotation.Value), quaternion.Euler(0, astRotateComponent.rotSpeed * Time.deltaTime, 0, 0));
        });
    }
}
