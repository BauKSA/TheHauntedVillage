using UnityEngine;

public class PlayerActionState : MonoBehaviour
{
    public bool IsOnTree { get; set; } = false;
    public GameObject CurrentTree { get; set; } = null;

    public bool IsOnDoor { get; set; } = false;
    public string DoorRoom { get; set; } = null;
}
