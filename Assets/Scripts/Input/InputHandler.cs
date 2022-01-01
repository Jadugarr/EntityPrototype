using System;
using Unity.Collections;
using Unity.Entities;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityTemplateProjects.Components;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private AssetReference _testCubeReference;

    private EndSimulationEntityCommandBufferSystem _ecbSystem;
    private float _currentSpawnedCubes = 0;

    private void Start()
    {
        _ecbSystem = World.DefaultGameObjectInjectionWorld.GetOrCreateSystem<EndSimulationEntityCommandBufferSystem>();
    }

    public async void OnSpawn(InputAction.CallbackContext inputAction)
    {
        if (inputAction.performed)
        {
            Debug.Log("On Spawn");
            GameObject instance = await Addressables.InstantiateAsync(_testCubeReference, new Vector3(_currentSpawnedCubes, 0f, _currentSpawnedCubes), Quaternion.identity).Task;
            _currentSpawnedCubes++;
        }
    }

    public async void OnMousePosition(InputAction.CallbackContext inputAction)
    {
        
    }
}
