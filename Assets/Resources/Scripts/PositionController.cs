using UnityEngine;

public struct Position2D
{
    public float x;
    public float y;
}

[RequireComponent(typeof(Rigidbody2D))]
public class PositionController : MonoBehaviour
{
    [SerializeField] private Position2D _position = new();
    public Position2D Position => _position;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        _position.x = rb.position.x;
        _position.y = rb.position.y;
    }

    private void SyncPosition()
    {
        _position.x = rb.position.x;
        _position.y = rb.position.y;
    }

    public void Move(Vector2 delta)
    {
        rb.MovePosition(rb.position + delta);
        SyncPosition();
    }

    public void SetPosition(float x, float y)
    {
        Vector2 position = new(x, y);
        rb.position = position;
        SyncPosition();
    }
}