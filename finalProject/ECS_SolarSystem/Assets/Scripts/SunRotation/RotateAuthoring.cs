using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;
using Unity.Transforms;

[DisallowMultipleComponent]
[RequiresEntityConversion]
public class RotateAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    // Make it available for setting a value in the Unity Editor
    [SerializeField]
    private float degreesPerSecond;

    public void Convert(Entity entity, EntityManager dstManager, GameObjectConversionSystem conversionSystem)
    {
        // Add specified component data to the Converted Entity that this Authoring is attached to
        dstManager.AddComponentData(entity, new RotateComponent { radiansPerSecond = math.radians(degreesPerSecond) });
        dstManager.AddComponentData(entity, new RotationEulerXYZ());        
    }
}
