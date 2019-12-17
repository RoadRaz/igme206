using UnityEngine;
using Unity.Entities;
using Unity.Transforms;

public class TravelSystem : ComponentSystem
{
    protected override void OnUpdate()
    {
        // For each entity having the 'Translation' and 'TravelComponent' components,
        Entities.ForEach((ref Translation translation, ref TravelComponent travelComponent) =>
        {
            // update the translation values by adding the speed assigned
            translation.Value.x += travelComponent.travelSpeed * Time.deltaTime;
            translation.Value.y += travelComponent.travelSpeed * Time.deltaTime;
            translation.Value.z += travelComponent.travelSpeed * Time.deltaTime;
        });
    }
}
