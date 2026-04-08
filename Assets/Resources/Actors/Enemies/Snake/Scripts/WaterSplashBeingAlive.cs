using UnityEngine;

public class WaterSplashBeingAlive : MonoBehaviour
{
    [Header("Water Prefab")]
    [SerializeField]
    private GameObject Water;

    [Header("Target Area (Rectangle)")]
    public Vector2 bottomLeft;
    public Vector2 topRight;

    [Header("Parabola")]
    public float gravityScale = 1f; // gravedad del Rigidbody2D

    private Rigidbody2D rb;
    private Vector2 targetPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (!rb)
        {
            Debug.LogError("Rigidbody2D no encontrado!");
            Destroy(this);
            return;
        }
        rb.gravityScale = gravityScale;
    }

    private void Start()
    {
        float targetX = Random.Range(bottomLeft.x, topRight.x);
        float targetY = Random.Range(bottomLeft.y, topRight.y);
        targetPoint = new Vector2(targetX, targetY);

        // Calcular velocidad inicial para la parábola
        Vector2 velocity = CalculateLaunchVelocity(transform.position, targetPoint, Physics2D.gravity.y * rb.gravityScale);
        rb.linearVelocity = velocity;
    }

    private void Update()
    {
        float distanceToTarget = Vector2.Distance(transform.position, targetPoint);

        if (distanceToTarget <= 1f)
        {
            if (Water)
            {
                Vector2 gridPos = new(
                    Mathf.Round(transform.position.x / 4f) * 4f,
                    Mathf.Round(transform.position.y / 4f) * 4f
                );


                Instantiate(Water, gridPos, Quaternion.identity);
            }

            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
            rb.simulated = false;

            Collider2D col = GetComponent<Collider2D>();
            if (col) col.enabled = false;

            Destroy(gameObject, 0.05f);
        }
    }

    /// <summary>
    /// Calcula la velocidad inicial necesaria para lanzar un objeto desde start hacia end usando parábola
    /// </summary>
    /// <param name="start">Posición inicial</param>
    /// <param name="end">Posición final</param>
    /// <param name="gravity">Gravedad negativa (-9.81)</param>
    /// <returns>Vector2 velocidad inicial</returns>
    private Vector2 CalculateLaunchVelocity(Vector2 start, Vector2 end, float gravity)
    {
        float distanceX = end.x - start.x;
        float distanceY = end.y - start.y;

        // Elegimos altura máxima relativa (puede ajustarse)
        float maxHeight = Mathf.Max(start.y, end.y) + 3f;

        // Velocidad vertical inicial para alcanzar maxHeight
        float vyUp = Mathf.Sqrt(-2f * gravity * (maxHeight - start.y));

        // Tiempo para subir a la altura máxima
        float timeUp = vyUp / -gravity;

        // Tiempo para bajar de altura máxima hasta destino
        float timeDown = Mathf.Sqrt(2f * (maxHeight - end.y) / -gravity);

        float totalTime = timeUp + timeDown;

        // Velocidad horizontal necesaria
        float vx = distanceX / totalTime;

        return new Vector2(vx, vyUp);
    }
}