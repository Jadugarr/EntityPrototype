using Unity.Entities;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects.Systems
{
    public class SetSpawnedCubeIdSystem : SystemBase
    {
        private EndSimulationEntityCommandBufferSystem _ecbSystem;
        private int _nextCubeId = 0;

        protected override void OnCreate()
        {
            _ecbSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnUpdate()
        {
            EntityCommandBuffer ecb = _ecbSystem.CreateCommandBuffer();
            int idToUse = _nextCubeId;
            _nextCubeId++;
            
            Entities.WithAll<CubeComponent>().WithNone<CubeIdComponent>().ForEach((Entity e) =>
            {
                CubeIdComponent cubeIdComponent = new CubeIdComponent
                {
                    Value = idToUse
                };
                ecb.AddComponent<CubeIdComponent>(e);
                ecb.SetComponent(e, cubeIdComponent);
            }).Run();
        }
    }
}