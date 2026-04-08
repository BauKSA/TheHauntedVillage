using UnityEngine;

public class PlayerSnakeCollision : MonoBehaviour
{
    AnimationController animController;
    PlayerState state;

    private void Awake()
    {
        animController = GetComponent<AnimationController>();
        state = gameObject.GetComponent<PlayerState>();

        if (!state || !animController) Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Snake")) return;
        if (!state.IsVulnerable) return;
        if (state.IsAttacking) return;
        
        MovementController snakeMovement = other.GetComponent<MovementController>();
        if (!snakeMovement) return;

        snakeMovement.Stop();

        PlayerDeath death = GetComponent<PlayerDeath>();
        if (!death) return;

        death.Execute();
    }
}
