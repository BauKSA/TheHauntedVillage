using UnityEngine;

public enum PlayerInputKeys
{
    NONE,
    RIGHT,
    LEFT,
    DOWN,
    UP
}

public class PlayerInputFix : MonoBehaviour
{
    public bool MovementInputActive { get; set; } = false;
    public PlayerInputKeys CurrentInputKey { get; set; } = PlayerInputKeys.NONE;
}
