using UnityEngine;
using UnityEngine.InputSystem;

public abstract class InputEvent : MonoBehaviour
{
    public abstract void Execute(InputAction.CallbackContext context);
}