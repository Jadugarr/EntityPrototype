using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects.Systems
{
    public class MoveCubeSystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _ecbSystem;

        protected override void OnCreate()
        {
            _ecbSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            Debug.Log("Moving cube...");
            var ecb = _ecbSystem.CreateCommandBuffer();
            var sin = (float)math.sin(Time.ElapsedTime);
            var timeDeltaTime = Time.DeltaTime;
            
            Entities.WithAll<CubeComponent>().ForEach((ref Translation translation) =>
            {
                translation.Value = new float3(0f, sin, 0f);
            }).Run();
        }
    }
}