using UnityEngine;

public class PhantomBulletWallCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Wall")) return;
        Destroy(gameObject);
    }
}
