using Unity.Entities;
using Unity.Rendering;
using UnityEngine;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects.Systems
{
    [UpdateAfter(typeof(ResetHighlightedSystem))]
    public class RemoveHighlightSystem : SystemBase
    {
        private static readonly int Selected = Shader.PropertyToID("_Selected");

        protected override void OnUpdate()
        {
            Entities.WithAll<CubeComponent>().WithNone<HighlightedComponent>().ForEach((in RenderMesh mesh) =>
            {
                mesh.material.SetInt(Selected, 0);
            }).WithoutBurst().Run();
        }
    }
}