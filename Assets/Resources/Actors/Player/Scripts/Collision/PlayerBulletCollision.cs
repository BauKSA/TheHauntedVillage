using UnityEngine;

public class PlayerBulletCollision : MonoBehaviour
{
    PlayerState state;

    private void Awake()
    {
        state = GetComponent<PlayerState>();
        if (!state) Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bullet")) return;
        if (!state.IsVulnerable) return;

        if (!state.IsAttacking)
        {
            Destroy(other.gameObject);

            PlayerDeath death = GetComponent<PlayerDeath>();
            if (!death) return;

            death.Execute();
        }
        else
        {
            Vector2 dir = other.transform.up;
            other.transform.up = -dir;

            MovementController otherMovement = other.gameObject.GetComponent<MovementController>();
            if (!otherMovement) return;

            if (otherMovement.MoveDown)
            {
                otherMovement.SetMoveDown(false);
                otherMovement.SetMoveUp();
            }
            else if (otherMovement.MoveUp)
            {
                otherMovement.SetMoveUp(false);
                otherMovement.SetMoveDown();
            }
            else if (otherMovement.MoveLeft)
            {
                otherMovement.SetMoveLeft(false);
                otherMovement.SetMoveRight();
            }
            else if (otherMovement.MoveRight)
            {
                otherMovement.SetMoveRight(false);
                otherMovement.SetMoveLeft();
            }
        }
    }
}
