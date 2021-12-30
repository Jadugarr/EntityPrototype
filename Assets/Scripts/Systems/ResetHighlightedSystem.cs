using Unity.Entities;
using UnityEngine;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects.Systems
{
    public class ResetHighlightedSystem : SystemBase
    {
        private static readonly int Selected = Shader.PropertyToID("_Selected");

        private EndSimulationEntityCommandBufferSystem _ecbSystem;

        protected override void OnCreate()
        {
            _ecbSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }
        
        protected override void OnUpdate()
        {
            var ecb = _ecbSystem.CreateCommandBuffer();
            
            Entities.WithAll<CubeComponent, HighlightedComponent>().ForEach((Entity e) =>
            {
                ecb.RemoveComponent<HighlightedComponent>(e);
            }).Run();
        }
    }
}