using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionFixed : MonoBehaviour
{
    MovementController movement;

    private void Awake()
    {
        movement = GetComponent<MovementController>();
        if (!movement) Destroy(this);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        foreach (ContactPoint2D contact in collision.contacts)
        {
            Vector2 normal = contact.normal; // Normal apunta *desde la pared hacia el objeto*

            // Por ejemplo, si la pared está arriba, normal será (0, -1)
            // Si la pared está a la derecha, normal será (-1, 0)
            // Si querés frenar solo movimiento hacia arriba:
            if (normal.y < 0 && movement.MoveUp)
            {
                movement.SetMoveUp(false);
            }
            if (normal.y > 0 && movement.MoveDown)
            {
                movement.SetMoveDown(false);
            }
            if (normal.x < 0 && movement.MoveRight)
            {
                movement.SetMoveRight(false);
            }
            if (normal.x > 0 && movement.MoveLeft)
            {
                movement.SetMoveLeft(false);
            }
        }
    }
}
