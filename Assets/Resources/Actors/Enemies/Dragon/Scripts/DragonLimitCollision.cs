using UnityEngine;

public class DragonLimitCollision : MonoBehaviour
{
    private MovementController movement;
    private AnimationController animController;

    private void Awake()
    {
        movement = GetComponent<MovementController>();
        animController = GetComponent<AnimationController>();

        if (!movement || !animController) Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("DragonLimit")) return;

        bool rightMovement = movement.MoveRight;
        movement.Stop();

        if (rightMovement)
        {
            animController.StartAnimation("Dragon-left_idle");
            movement.SetMoveLeft();
        }
        else
        {
            animController.StartAnimation("Dragon_idle");
            movement.SetMoveRight();
        }
    }

}
