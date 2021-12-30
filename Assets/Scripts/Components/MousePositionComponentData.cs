using Unity.Entities;
using UnityEngine;

namespace UnityTemplateProjects.Components
{
    public struct MousePositionComponentData : IComponentData
    {
        public Vector2 Value;
    }
}