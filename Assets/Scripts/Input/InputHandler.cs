using Unity.Entities;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.InputSystem;
using UnityTemplateProjects.Components;

public class InputHandler : MonoBehaviour
{
    [SerializeField] private AssetReference _testCubeReference;
    
    public async void OnSpawn(InputAction.CallbackContext inputAction)
    {
        if (inputAction.performed)
        {
            Debug.Log("On Spawn");
            GameObject instance = await Addressables.InstantiateAsync(_testCubeReference).Task;
        }
    }
}
