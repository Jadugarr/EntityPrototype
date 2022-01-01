using Unity.Entities;
using Unity.Rendering;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects.Systems
{
    [UpdateAfter(typeof(SetHighlightedSystem))]
    public class HighlightSystem : SystemBase
    {
        private static readonly int Selected = Shader.PropertyToID("_Selected");
        private bool hasShownText = false;

        protected override void OnUpdate()
        {
            if (!hasShownText)
            {
                Addressables.InstantiateAsync(AssetReferencesForTesting.ValueTextReference);
                hasShownText = true;
            }
            
            Entities.WithAll<CubeComponent, HighlightedComponent>().ForEach((in RenderMesh mesh) =>
            {
                mesh.material.SetInt(Selected, 1);
            }).WithoutBurst().Run();
        }
    }
}