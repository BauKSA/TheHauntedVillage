using UnityEngine;

public class SnakeVerticalMovement : MonoBehaviour
{
    private MovementController movement;
    private AnimationController animationController;

    private void Awake()
    {
        movement = GetComponent<MovementController>();
        if (!movement) Destroy(this);

        animationController = GetComponent<AnimationController>();
        if (!animationController) Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("SnakeVerticalTrigger")) return;

        if (movement.MoveUp)
        {
            movement.Stop();
            movement.SetMoveDown();
        }
        else
        {
            movement.Stop();
            movement.SetMoveUp();
        }
    }
}
