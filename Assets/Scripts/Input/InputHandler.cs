using System;
using Unity.Entities;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private AssetReference _testCubeReference;

    private EndSimulationEntityCommandBufferSystem _ecbSystem;

    private void Start()
    {
        
    }

    public async void OnSpawn(InputAction.CallbackContext inputAction)
    {
        if (inputAction.performed)
        {
            Debug.Log("On Spawn");
            GameObject instance = await Addressables.InstantiateAsync(_testCubeReference).Task;
        }
    }

    public async void OnMousePosition(InputAction.CallbackContext inputAction)
    {
        
    }
}
