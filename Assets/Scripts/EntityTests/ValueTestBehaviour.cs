using System;
using TMPro;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityTemplateProjects.Components;

namespace UnityTemplateProjects.EntityTests
{
    public class ValueTestBehaviour : MonoBehaviour
    {
        [SerializeField] private TMP_Text textField;

        private EntityQuery _highlightedCubeQuery;
        private EntityQuery _costQuery;
        private EndSimulationEntityCommandBufferSystem _ecbSystem;
        private EntityManager _manager;

        private void Start()
        {
            _manager = World.DefaultGameObjectInjectionWorld.EntityManager;
            _ecbSystem =
                World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
            _highlightedCubeQuery = _manager.CreateEntityQuery(typeof(CubeComponent), typeof(CubeIdComponent), typeof(HighlightedComponent));
            _costQuery = _manager.CreateEntityQuery(typeof(CubeIdComponent), typeof(CurrentCostComponent));
            
            ShowText();
        }

        private void ShowText()
        {
            var cubeArray = _highlightedCubeQuery.ToEntityArray(Allocator.Temp);
            var costArray = _costQuery.ToEntityArray(Allocator.Temp);

            foreach (Entity cube in cubeArray)
            {
                int cubeId = _manager.GetComponentData<CubeIdComponent>(cube).Value;

                foreach (Entity costEntity in costArray)
                {
                    if (cubeId != _manager.GetComponentData<CubeIdComponent>(costEntity).Value)
                    {
                        continue;
                    }

                    textField.text = _manager.GetComponentData<CurrentCostComponent>(costEntity).Value.ToString();
                    return;
                }
            }
        }
    }
}