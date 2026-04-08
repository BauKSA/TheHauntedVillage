using UnityEngine;

public class GameOverInputController : MonoBehaviour
{
    private MainInput inputController;

    private void Awake()
    {
        inputController = new();
        inputController.Enable();

        inputController.Player.Action.started += gameObject.AddComponent<RestartEvent>().Execute;
    }

    private void OnDestroy()
    {
        inputController.Disable();
    }
}
