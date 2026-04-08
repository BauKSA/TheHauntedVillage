using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class RestartEvent : InputEvent
{
    public override void Execute(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene("World");
    }
}
