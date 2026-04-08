using UnityEngine;

public class DragonBeingAlive : MonoBehaviour
{
    private MovementController movement;
    private AnimationController animController;
    private DragonState state;

    [SerializeField]
    private GameObject bomb;

    float bombTimer = 0f;
    float bombSpawnTime = 5f;

    private void Awake()
    {
        movement = GetComponent<MovementController>();
        animController = GetComponent<AnimationController>();
        state = GetComponent<DragonState>();

        if (!movement || !animController || !state) Destroy(this);
    }

    private void Start()
    {
        movement.SetMoveRight();
        animController.StartAnimation("Dragon_idle");
        Debug.Log("Dragon is alive and moving right.");
    }

    private void Update()
    {
        bombTimer += Time.deltaTime;
        if (bombTimer >= bombSpawnTime)
        {
            bombTimer = 0f;
            bombSpawnTime = UnityEngine.Random.Range(3f, 7f);
            SpawnBomb();
        }
    }

    private void SpawnBomb()
    {
        if (!bomb) return;
        if (!state.CanAttack) return;

        Instantiate(bomb, transform.position, Quaternion.identity);
    }
}