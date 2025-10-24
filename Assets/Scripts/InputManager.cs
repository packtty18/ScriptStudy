using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    InputManager im;

    private void Start()
    {
        InputManager im = transform.GetComponent<InputManager>();
        
    }

    private void OnMove(InputValue value)
    {
        
    }
}
