using Unity.Entities;
using Unity.Physics;
using Unity.Physics.Systems;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityTemplateProjects.Components;
using RaycastHit = Unity.Physics.RaycastHit;

namespace UnityTemplateProjects.Systems
{
    [UpdateAfter(typeof(RemoveHighlightSystem))]
    public class SetHighlightedSystem : SystemBase
    {
        private InputAction _mousePositionAction;
        private Camera _camera;
        private BuildPhysicsWorld _buildPhysicsWorld;
        private EndSimulationEntityCommandBufferSystem _ecbSystem;

        protected override void OnCreate()
        {
            _ecbSystem = World.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
        }

        protected override void OnStartRunning()
        {
            _camera = Camera.main;
            _mousePositionAction = PlayerInput.all[0].actions.FindAction("MousePosition");
            _buildPhysicsWorld = World.GetOrCreateSystem<BuildPhysicsWorld>();
        }

        protected override void OnUpdate()
        {
            var ecb = _ecbSystem.CreateCommandBuffer();
            Entity hitEntity = default;
            
            CollisionWorld collisionWorld = _buildPhysicsWorld.PhysicsWorld.CollisionWorld;
            var ray = _camera.ScreenPointToRay(_mousePositionAction.ReadValue<Vector2>());
            var rayStart = ray.origin;
            var rayEnd = ray.GetPoint(1000f);
            if (collisionWorld.CastRay(new RaycastInput
                {
                    Start = rayStart,
                    End = rayEnd,
                    Filter = CollisionFilter.Default
                }, out RaycastHit hit))
            {
                hitEntity = hit.Entity;
                ecb.AddComponent<HighlightedComponent>(hitEntity);
            }
            
            /*Entities.WithAll<HighlightedComponent>().ForEach((Entity e) =>
            {
                if (e.Index == hitEntity.Index)
                {
                    return;
                }
                ecb.RemoveComponent<HighlightedComponent>(e);
            }).Run();*/
        }
    }
}