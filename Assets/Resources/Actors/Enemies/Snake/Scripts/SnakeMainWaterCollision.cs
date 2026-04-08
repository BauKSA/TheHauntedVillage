using UnityEngine;

public class SnakeMainWaterCollision : MonoBehaviour
{
    MovementController movement;
    AnimationController animationController;
    SnakeState state;

    private void Awake()
    {
        movement = GetComponent<MovementController>();
        if (!movement) Destroy(this);

        animationController = GetComponent<AnimationController>();
        if (!animationController) Destroy(this);

        state = GetComponent<SnakeState>();
        if (!state) Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {  
        if (!other.gameObject.CompareTag("SnakeRoomWater")) return;

        state.IsOnWater = true;

        movement.Stop();

        movement.SetSpeed(35f);

        Debug.Log("Collision with animation: " + animationController.GetCurrentAnimation());

        if (animationController.GetCurrentAnimation() == "Snake_idle"
            || animationController.GetCurrentAnimation() == "Snake_damaged")
        {
            animationController.StartAnimation("Snake-left_idle");
            state.RightSided = false;
            movement.SetMoveUp();
        }
        else
        {
            animationController.StartAnimation("Snake_idle");
            state.RightSided = true;
            movement.SetMoveDown();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("SnakeRoomWater")) return;

        state.IsOnWater = false;
    }
}
