using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Transforms;
using UnityEngine;

public class RotateSystem : JobComponentSystem
{
    [BurstCompile]
    struct RotateSystemJob : IJobForEach<RotateComponent, RotationEulerXYZ>
    {
        // Add fields here that your job needs to do its work.
        public float DeltaTime;       
        
        public void Execute(ref RotateComponent rotSpeed, ref RotationEulerXYZ euler)
        {
            // Implementing the actual rotation
            euler.Value.y += rotSpeed.radiansPerSecond * DeltaTime;           
        }
    }
    
    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        // Assign values to the fields added
        var job = new RotateSystemJob { DeltaTime = Time.deltaTime };        

        // Schedule the job after setting the values for its fields
        return job.Schedule(this, inputDependencies);
    }
}