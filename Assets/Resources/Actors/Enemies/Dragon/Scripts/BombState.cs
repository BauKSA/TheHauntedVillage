using UnityEngine;

public class BombState : MonoBehaviour
{
    public bool OnFloor { get; set; } = false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Wall") || OnFloor) return;
        OnFloor = true;
    }
}
