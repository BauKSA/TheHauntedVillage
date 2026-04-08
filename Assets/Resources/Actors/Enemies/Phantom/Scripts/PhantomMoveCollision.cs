using UnityEngine;

public class PhantomMoveCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet")) return;

        PhantomMovementController movement = GetComponent<PhantomMovementController>();
        if (!movement) return;

        movement.Move();
    }
}