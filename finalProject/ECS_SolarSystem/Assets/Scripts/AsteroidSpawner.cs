using UnityEngine;
using Unity.Entities;
using Unity.Transforms;
using Unity.Collections;
using Unity.Rendering;

public class AsteroidSpawner : MonoBehaviour
{
    // Make assignable through Unity Editor
    [SerializeField] private Mesh asteroidMesh;
    [SerializeField] private Material asteroidMaterial;
    void Start()
    {
        // Create an EntityManger
        EntityManager entityManager = World.Active.EntityManager;

        // Create an ArcheType consisting of below 5 specified components
        EntityArchetype entityArcheType = entityManager.CreateArchetype(
            typeof(Translation), 
            typeof(RenderMesh),
            typeof(LocalToWorld),
            typeof(TravelComponent),
            typeof(Rotation)
        );

        // Creating a Native array containing 1000 Entities
        NativeArray<Entity> asteroidArray = new NativeArray<Entity>(1000, Allocator.Temp);

        // Create all entities
        entityManager.CreateEntity(entityArcheType, asteroidArray);

        // Loop through each entity
        for (int i = 0; i < asteroidArray.Length; i++)
        {
            Entity entity = asteroidArray[i];
            entityManager.SetSharedComponentData(entity, new RenderMesh { mesh = asteroidMesh, material = asteroidMaterial });
            entityManager.SetComponentData(entity, new TravelComponent { travelSpeed = Random.Range(-5f, 5f) });
            entityManager.SetComponentData(entity, new Translation { Value = new Unity.Mathematics.float3(Random.Range(-30,50), Random.Range(-30, 50), Random.Range(-30, 50)) });

            //entityManager.SetComponentData(entity, new Rotation { Value = new Unity.Mathematics.quaternion(Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f), Random.Range(-5f, 5f)) });
            //entityManager.SetComponentData(entity, new AstRotateComponent { rotSpeed = Random.Range(-5f, 5f) });
                       
        }
        // To avoid memory leak, dispose the Native Array
        asteroidArray.Dispose();
    }
}
