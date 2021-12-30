using Unity.Entities;
using Unity.Rendering;
using UnityEngine;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects.Systems
{
    [UpdateAfter(typeof(SetHighlightedSystem))]
    public class HighlightSystem : SystemBase
    {
        private static readonly int Selected = Shader.PropertyToID("_Selected");

        protected override void OnUpdate()
        {
            Entities.WithAll<CubeComponent, HighlightedComponent>().ForEach((in RenderMesh mesh) =>
            {
                mesh.material.SetInt(Selected, 1);
            }).WithoutBurst().Run();
        }
    }
}