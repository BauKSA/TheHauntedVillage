using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : MonoBehaviour
{
    private MainInput inputController;

    private void Awake()
    {
        inputController = new();
        inputController.Enable();

        //Move RIGHT
        inputController.Player.MoveRight.started += gameObject.AddComponent<PlayerMoveRight>().Execute;
        inputController.Player.MoveRight.canceled += gameObject.AddComponent<PlayerStopRight>().Execute;

        //Move LEFT
        inputController.Player.MoveLeft.started += gameObject.AddComponent<PlayerMoveLeft>().Execute;
        inputController.Player.MoveLeft.canceled += gameObject.AddComponent<PlayerStopLeft>().Execute;

        //Move UP
        inputController.Player.MoveUp.started += gameObject.AddComponent<PlayerMoveUp>().Execute;
        inputController.Player.MoveUp.canceled += gameObject.AddComponent<PlayerStopUp>().Execute;

        //Move DOWN
        inputController.Player.MoveDown.started += gameObject.AddComponent<PlayerMoveDown>().Execute;
        inputController.Player.MoveDown.canceled += gameObject.AddComponent<PlayerStopDown>().Execute;

        //ACTION
        inputController.Player.Action.started += gameObject.AddComponent<PlayerActionEvent>().Execute;
    }

    private void OnDestroy()
    {
        inputController.Disable();
    }
}