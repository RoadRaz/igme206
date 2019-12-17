using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine.UI;
using Unity.Rendering;

public class Manager : MonoBehaviour
{
    public int NumberOfEntitiesToSpawn = 1000;
    
    public GameObject AsteroidEnt;

    //public Text EntityNumberText;
    int numberOfEntities = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SpawnAsteroids();
    }

    void SpawnAsteroids()
    {
        EntityManager entityManager = World.Active.EntityManager;
        entityManager.CreateEntity(typeof(AsteroidMoveSpeed),typeof(AsteroidRotationSpeed));

        NativeArray<Entity> asteroid = new NativeArray<Entity>(NumberOfEntitiesToSpawn, Allocator.Temp);
        entityManager.Instantiate(AsteroidEnt, asteroid);

        for (int i = 0; i < NumberOfEntitiesToSpawn; i++)
        {
            entityManager.AddComponentData(asteroid[i], new AsteroidRotationSpeed { RotationValue = 10.0f });
            entityManager.AddComponentData(asteroid[i], new AsteroidMoveSpeed { MoveSpeed = 1.0f });

            float3 startingPos = new float3(UnityEngine.Random.Range(0.1f, 100.0f));
            entityManager.SetComponentData(asteroid[i], new Translation { Value = startingPos });
        }
        asteroid.Dispose();
        numberOfEntities += NumberOfEntitiesToSpawn;
        //EntityNumberText.text = numberOfEntities.ToString();
    }
}
