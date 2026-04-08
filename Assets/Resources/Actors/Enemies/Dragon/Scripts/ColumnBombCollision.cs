using UnityEngine;

public class ColumnBombCollision : MonoBehaviour
{
    MovementController movement;
    Rigidbody2D rb;
    private readonly float limit = -44f;
    private readonly float bLimit = -100f;
    Collider2D bomb;

    private void Awake()
    {
        movement = GetComponentInParent<MovementController>();
        rb = GetComponentInParent<Rigidbody2D>();
        if (!movement || !rb) Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bomb")) return;
        
        AnimationController animController = other.gameObject.GetComponent<AnimationController>();
        if (!animController) return;

        if (animController.GetCurrentAnimation() == "Bomb_explosion") return;

        MovementController otherMovement = other.gameObject.GetComponent<MovementController>();
        if (!otherMovement) return;

        otherMovement.Stop();

        BombState bombState = other.gameObject.GetComponent<BombState>();
        if (!bombState) return;

        bombState.OnFloor = false;

        GetUp(other);
    }

    private void GetDown()
    {
        Debug.Log("Bomb released from column.");
        movement.Stop();
        movement.SetMoveDown();
        bomb.transform.SetParent(null);

        bomb = null;
    }

    private void GetUp(Collider2D other)
    {
        Rigidbody2D otherBody = other.gameObject.GetComponent<Rigidbody2D>();
        if (!otherBody) return;

        Collider2D myCollider = GetComponentInParent<Collider2D>();
        if (!myCollider) return;

        Vector2 pos = otherBody.position;
        pos.x = transform.position.x;
        float roofY = myCollider.bounds.max.y;
        float bombHalfHeight = other.bounds.extents.y;

        pos.y = roofY + bombHalfHeight;

        bomb = other;
        bomb.transform.position = pos;
        Transform bombTransform = other.transform;

        otherBody.linearVelocity = Vector2.zero;
        otherBody.angularVelocity = 0f;
        otherBody.gravityScale = 0f;
        otherBody.bodyType = RigidbodyType2D.Kinematic;

        bombTransform.SetParent(transform);

        movement.SetMoveUp();
    }

    private void Update()
    {
        if (rb.position.y >= limit && bomb)
        {
            movement.Stop();
            Vector2 pos = rb.position;
            pos.y = limit;
            rb.position = pos;
        }

        if (rb.position.y <= bLimit && movement.MoveDown)
        {
            movement.Stop();
            Vector2 pos = rb.position;
            pos.y = bLimit;
            rb.position = pos;
        }

        if (!bomb) return;

        AnimationController animation = bomb.gameObject.GetComponent<AnimationController>();
        if (!animation) return;

        if (animation.GetCurrentAnimation() != "Bomb_explosion") return;
        GetDown();
    }
}
