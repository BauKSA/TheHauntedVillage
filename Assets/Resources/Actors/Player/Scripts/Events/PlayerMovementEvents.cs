using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;

/* 
 * [-------------------]
 * [ PLAYER MOVE RIGHT ] 
 * [-------------------]
*/
public class PlayerMoveRight : InputEvent
{
    protected MovementController playerMovement;
    protected PlayerState playerState;
    protected AnimationController playerAnimation;
    protected PlayerInputFix inputFix;

    private void Awake()
    {
        playerMovement = GetComponent<MovementController>();
        playerState = GetComponent<PlayerState>();
        playerAnimation = GetComponent<AnimationController>();
        inputFix = GetComponent<PlayerInputFix>();
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        if (!playerMovement) return;
        if (!playerState.CanMove) return;
        if (inputFix.MovementInputActive) return;

        inputFix.CurrentInputKey = PlayerInputKeys.RIGHT;
        inputFix.MovementInputActive = true;
        playerMovement.SetMoveRight();

        string animation = playerState.IsOnWater ? "Player_boat" : "Player_walking";
        playerAnimation.StartAnimation(animation);
    }
}

public class PlayerStopRight : InputEvent
{
    protected MovementController playerMovement;
    protected PlayerState playerState;
    protected AnimationController playerAnimation;
    protected PlayerInputFix inputFix;

    private void Awake()
    {
        playerMovement = GetComponent<MovementController>();
        playerState = GetComponent<PlayerState>();
        playerAnimation = GetComponent<AnimationController>();
        inputFix = GetComponent<PlayerInputFix>();
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        if (!playerMovement) return;
        if (!playerState.CanMove) return;
        if (inputFix.CurrentInputKey != PlayerInputKeys.RIGHT) return;
        inputFix.CurrentInputKey = PlayerInputKeys.NONE;

        inputFix.MovementInputActive = false;

        playerMovement.SetMoveRight(false);

        string animation = playerState.IsOnWater ? "Player_boat" : "Player_idle";
        playerAnimation.StartAnimation(animation);
    }
}

/* 
 * [-------------------]
 * [ PLAYER MOVE LEFT  ] 
 * [-------------------]
*/
public class PlayerMoveLeft : InputEvent
{
    protected MovementController playerMovement;
    protected PlayerState playerState;
    protected AnimationController playerAnimation;
    protected PlayerInputFix inputFix;

    private void Awake()
    {
        playerMovement = GetComponent<MovementController>();
        playerState = GetComponent<PlayerState>();
        playerAnimation = GetComponent<AnimationController>();
        inputFix = GetComponent<PlayerInputFix>();
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        if (!playerMovement) return;
        if (!playerState.CanMove) return;
        if (inputFix.MovementInputActive) return;

        inputFix.CurrentInputKey = PlayerInputKeys.LEFT;
        inputFix.MovementInputActive = true;

        playerMovement.SetMoveLeft();

        string animation = playerState.IsOnWater ? "Player-left_boat" : "Player-left_walking";
        playerAnimation.StartAnimation(animation);
    }
}

public class PlayerStopLeft : InputEvent
{
    protected MovementController playerMovement;
    protected PlayerState playerState;
    protected AnimationController playerAnimation;
    protected PlayerInputFix inputFix;

    private void Awake()
    {
        playerMovement = GetComponent<MovementController>();
        playerState = GetComponent<PlayerState>();
        playerAnimation = GetComponent<AnimationController>();
        inputFix = GetComponent<PlayerInputFix>();
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        if (!playerMovement) return;
        if (!playerState.CanMove) return;
        if (inputFix.CurrentInputKey != PlayerInputKeys.LEFT) return;
        inputFix.CurrentInputKey = PlayerInputKeys.NONE;

        inputFix.MovementInputActive = false;

        playerMovement.SetMoveLeft(false);

        string animation = playerState.IsOnWater ? "Player-left_boat" : "Player-left_idle";
        playerAnimation.StartAnimation(animation);
    }
}

/* 
 * [-------------------]
 * [ PLAYER MOVE UP    ] 
 * [-------------------]
*/
public class PlayerMoveUp : InputEvent
{
    protected MovementController playerMovement;
    protected PlayerState playerState;
    protected AnimationController playerAnimation;
    protected PlayerInputFix inputFix;

    private void Awake()
    {
        playerMovement = GetComponent<MovementController>();
        playerState = GetComponent<PlayerState>();
        playerAnimation = GetComponent<AnimationController>();
        inputFix = GetComponent<PlayerInputFix>();
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        if (!playerMovement) return;
        if (!playerState.CanMove) return;
        if (inputFix.MovementInputActive) return;

        inputFix.CurrentInputKey = PlayerInputKeys.UP;
        inputFix.MovementInputActive = true;

        playerMovement.SetMoveUp();
        if (playerAnimation.GetCurrentAnimation() == "Player_idle")
        {
            string animation = playerState.IsOnWater ? "Player_boat" : "Player_walking";
            playerAnimation.StartAnimation(animation);
        }
        else if (playerAnimation.GetCurrentAnimation() == "Player-left_idle")
        {
            string animation = playerState.IsOnWater ? "Player-left_boat" : "Player-left_walking";
            playerAnimation.StartAnimation(animation);
        }
    }
}

public class PlayerStopUp : InputEvent
{
    protected MovementController playerMovement;
    protected PlayerState playerState;
    protected AnimationController playerAnimation;
    protected PlayerInputFix inputFix;

    private void Awake()
    {
        playerMovement = GetComponent<MovementController>();
        playerState = GetComponent<PlayerState>();
        playerAnimation = GetComponent<AnimationController>();
        inputFix = GetComponent<PlayerInputFix>();
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        if (!playerMovement) return;
        if (!playerState.CanMove) return;
        if (inputFix.CurrentInputKey != PlayerInputKeys.UP) return;
        inputFix.CurrentInputKey = PlayerInputKeys.NONE;

        inputFix.MovementInputActive = false;

        playerMovement.SetMoveUp(false);

        if (playerAnimation.GetCurrentAnimation() == "Player_walking")
        {
            string animation = playerState.IsOnWater ? "Player_boat" : "Player_idle";
            playerAnimation.StartAnimation(animation);
        }
        else if (playerAnimation.GetCurrentAnimation() == "Player-left_walking")
        {
            string animation = playerState.IsOnWater ? "Player-left_boat" : "Player-left_idle";
            playerAnimation.StartAnimation(animation);
        }
    }
}

/* 
 * [-------------------]
 * [ PLAYER MOVE DOWN  ] 
 * [-------------------]
*/
public class PlayerMoveDown : InputEvent
{
    protected MovementController playerMovement;
    protected PlayerState playerState;
    protected AnimationController playerAnimation;
    protected PlayerInputFix inputFix;

    private void Awake()
    {
        playerMovement = GetComponent<MovementController>();
        playerState = GetComponent<PlayerState>();
        playerAnimation = GetComponent<AnimationController>();
        inputFix = GetComponent<PlayerInputFix>();
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        if (!playerMovement) return;
        if (!playerState.CanMove) return;
        if (inputFix.MovementInputActive) return;

        inputFix.CurrentInputKey = PlayerInputKeys.DOWN;
        inputFix.MovementInputActive = true;

        playerMovement.SetMoveDown();

        if (playerAnimation.GetCurrentAnimation() == "Player_idle")
        {
            string animation = playerState.IsOnWater ? "Player_boat" : "Player_walking";
            playerAnimation.StartAnimation(animation);
        }
        else if (playerAnimation.GetCurrentAnimation() == "Player-left_idle")
        {
            string animation = playerState.IsOnWater ? "Player-left_boat" : "Player-left_walking";
            playerAnimation.StartAnimation(animation);
        }
    }
}

public class PlayerStopDown : InputEvent
{
    protected MovementController playerMovement;
    protected PlayerState playerState;
    protected AnimationController playerAnimation;
    protected PlayerInputFix inputFix;

    private void Awake()
    {
        playerMovement = GetComponent<MovementController>();
        playerState = GetComponent<PlayerState>();
        playerAnimation = GetComponent<AnimationController>();
        inputFix = GetComponent<PlayerInputFix>();
    }

    public override void Execute(InputAction.CallbackContext context)
    {
        if (!playerMovement) return;
        if (!playerState.CanMove) return;

        inputFix.MovementInputActive = false;
        if (inputFix.CurrentInputKey != PlayerInputKeys.DOWN) return;
        inputFix.CurrentInputKey = PlayerInputKeys.NONE;

        playerMovement.SetMoveDown(false);

        if (playerAnimation.GetCurrentAnimation() == "Player_walking")
        {
            string animation = playerState.IsOnWater ? "Player_boat" : "Player_idle";
            playerAnimation.StartAnimation(animation);
        }
        else if (playerAnimation.GetCurrentAnimation() == "Player-left_walking")
        {
            string animation = playerState.IsOnWater ? "Player-left_boat" : "Player-left_idle";
            playerAnimation.StartAnimation(animation);
        }
    }
}