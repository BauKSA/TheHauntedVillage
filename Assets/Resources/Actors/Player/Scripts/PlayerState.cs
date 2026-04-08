using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerState : MonoBehaviour
{
    //GENERAL
    public bool IsVulnerable { get; set; } = true;
    public bool IsAttacking { get; set; } = false;
    public bool CanMove { get; set; } = true;
    public bool IsOnWater { get; set; } = false;
}
