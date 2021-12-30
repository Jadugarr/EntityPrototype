using Unity.Entities;
using Unity.Mathematics;
using Unity.Rendering;
using Unity.Transforms;
using UnityEngine;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects.Systems
{
    public class MoveCubeSystem : SystemBase
    {
        private float currentTime = 0f;

        protected override void OnUpdate()
        {
            var sin = (float)math.sin(Time.ElapsedTime);
            currentTime += Time.DeltaTime;
            bool switchSelection = false;
            if (currentTime >= 1f)
            {
                switchSelection = true;
                currentTime = 0f;
            }
            
            Entities.WithAll<CubeComponent>().ForEach((ref Translation translation, in RenderMesh renderMesh) =>
            {
                translation.Value = new float3(0f, sin, 0f);
                
                /*if (switchSelection)
                {
                    int currentValue = renderMesh.material.GetInt(Selected);
                    renderMesh.material.SetInt(Selected, currentValue == 1 ? 0 : 1);
                }*/
                
            }).WithoutBurst().Run();
        }
    }
}