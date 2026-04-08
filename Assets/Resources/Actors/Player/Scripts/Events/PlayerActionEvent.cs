using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerActionEvent : InputEvent
{
    protected MovementController playerMovement;
    protected PlayerState playerState;
    protected AnimationController playerAnimation;

    private void Awake()
    {
        playerMovement = GetComponent<MovementController>();
        playerState = GetComponent<PlayerState>();
        playerAnimation = GetComponent<AnimationController>();
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        playerState.CanMove = false;
        playerState.IsAttacking = true;

        if (playerAnimation.GetCurrentAnimation() == "Player_idle" || playerAnimation.GetCurrentAnimation() == "Player_walking")
        {
            playerAnimation.StartAnimation("Player_action", true, EndAction);
        }
        else if(playerAnimation.GetCurrentAnimation() == "Player-left_idle" || playerAnimation.GetCurrentAnimation() == "Player-left_walking")
        {
            playerAnimation.StartAnimation("Player-left_action", true, EndAction);
        }

        DispatchAction();
    }

    private void EndAction()
    {
        playerMovement.Stop();
        playerState.CanMove = true;
        playerState.IsAttacking = false;
    }

    private void DispatchAction()
    {
        PlayerActionState actionState = GetComponent<PlayerActionState>();
        if(!actionState) return;

        if (actionState.IsOnTree)
        {
            PlayerCutDownTree cutDownTree = GetComponent<PlayerCutDownTree>();
            if (!cutDownTree) return;
            cutDownTree.Execute();
        }

        if (actionState.IsOnDoor)
        {
            if (actionState.DoorRoom.Equals("")) return;

            Debug.Log("Loading Room: " + actionState.DoorRoom);

            SceneManager.LoadScene(actionState.DoorRoom);
        }
        else
        {
            Debug.Log("Player is not on a door.");
        }
    }
}
