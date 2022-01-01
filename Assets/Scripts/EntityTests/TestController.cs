using Unity.Entities;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects.EntityTests
{
    public class TestController : MonoBehaviour
    {
        [SerializeField] private int amountOfEntities = 1;
        [SerializeField] private int baseValue = 100;
        [SerializeField] private AssetReference valueTextReference;
        
        private EndSimulationEntityCommandBufferSystem _ecbSystem;
        private void Start()
        {
            AssetReferencesForTesting.ValueTextReference = valueTextReference;
            
            _ecbSystem =
                World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
            EntityCommandBuffer ecb = _ecbSystem.CreateCommandBuffer();
            
            for (int i = 0; i < amountOfEntities; i++)
            {
                Entity entity = ecb.CreateEntity();
                CurrentCostComponent comp = new CurrentCostComponent
                {
                    Value = baseValue * (i + 1)
                };
                CubeIdComponent cubeIdComponent = new CubeIdComponent
                {
                    Value = i
                };
                ecb.AddComponent<CurrentCostComponent>(entity);
                ecb.SetComponent(entity, comp);
                ecb.AddComponent<CubeIdComponent>(entity);
                ecb.SetComponent(entity, cubeIdComponent);
            }
        }
    }
}