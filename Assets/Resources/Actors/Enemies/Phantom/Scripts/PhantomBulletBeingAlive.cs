using UnityEngine;

public enum BulletDirection {
    UP,
    LEFT,
    DOWN,
    RIGHT
}

public class PhantomBulletBeingAlive : MonoBehaviour
{
    MovementController movement;

    private void Awake()
    {
        movement = GetComponent<MovementController>();
        if (!movement) Destroy(gameObject);
    }

    public void Move(BulletDirection direction)
    {
        switch (direction)
        {
            default:
                break;
            case BulletDirection.UP:
                movement.SetMoveUp();
                break;
            case BulletDirection.DOWN:
                movement.SetMoveDown();
                break;
            case BulletDirection.RIGHT:
                movement.SetMoveRight();
                break;
            case BulletDirection.LEFT:
                movement.SetMoveLeft();
                break;
        }
    }
}
