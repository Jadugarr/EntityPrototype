using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects.Systems
{
    public class MoveCubeSystem : SystemBase
    {
        protected override void OnUpdate()
        {
            var sin = (float)math.sin(Time.ElapsedTime);
            
            Entities.WithAll<CubeComponent>().ForEach((ref Translation translation, in RenderMesh renderMesh) =>
            {
                translation.Value = new float3(translation.Value.x, sin, translation.Value.z);
            }).WithoutBurst().Run();
        }
    }
}