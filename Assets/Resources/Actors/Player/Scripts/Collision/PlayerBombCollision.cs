using UnityEngine;

public class PlayerBombCollision : MonoBehaviour
{
    PlayerState state;

    private void Awake()
    {
        state = GetComponentInParent<PlayerState>();
        if (!state) return;
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bomb")) return;

        Debug.Log($"Collision with Bomb with Attacking: {state.IsAttacking}");

        if (state.IsAttacking)
        {
            BombState bombState = other.gameObject.GetComponent<BombState>();
            if (!bombState) return;
            if (!bombState.OnFloor) return;

            MovementController otherMovement = other.gameObject.GetComponent<MovementController>();
            if (!otherMovement) return;

            Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
            if (!rb) return;

            float force = 25f;

            Vector2 dir = (other.transform.position.x > transform.position.x)
                ? Vector2.right
                : Vector2.left;

            rb.AddForce(dir * force, ForceMode2D.Impulse);
        }
        else
        {
            AnimationController animController = other.gameObject.GetComponent<AnimationController>();
            if (!animController) return;

            if (animController.GetCurrentAnimation() != "Bomb_explosion") return;
            PlayerDeath death = GetComponent<PlayerDeath>();
            if (!death) return;

            death.Execute();
        }
    }
}
