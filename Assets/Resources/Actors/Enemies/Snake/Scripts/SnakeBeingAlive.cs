using UnityEngine;

public class SnakeBeingAlive : MonoBehaviour
{
    MovementController movement;
    AnimationController animationController;

    private void Awake()
    {
        movement = GetComponent<MovementController>();
        if (!movement) Destroy(this);

        animationController = GetComponent<AnimationController>();
        if (!animationController) Destroy(this);
    }

    private void Start()
    {
        if (UnityEngine.Random.Range(0, 1) < 0.5f)
        {
            movement.SetMoveRight();
            animationController.StartAnimation("Snake_idle");
        }
        else
        {
            movement.SetMoveLeft();
            animationController.StartAnimation("Snake-left_idle");
        }
    }
}
