using UnityEngine;
using UnityEngine.SceneManagement;

public class SnakePlayerDamage : MonoBehaviour
{
    [SerializeField]
    private GameObject hearthController;

    private void OnTriggerEnter2D(Collider2D other)
    {
        AnimationController animController;
        PlayerState playerState;

        animController = GetComponent<AnimationController>();

        if (!other.gameObject.CompareTag("Player")) return;

        playerState = other.gameObject.GetComponent<PlayerState>();
        if (!playerState.IsAttacking) return;

        if (animController.GetCurrentAnimation() == "Snake_idle")
        {
            animController.StartAnimation("Snake-left_damaged");
            animController.SetNextAnimation("Snake-left_damaged");
        }
        else
        {
            animController.StartAnimation("Snake_damaged");
            animController.SetNextAnimation("Snake_damaged");
        }

        MovementController movement = GetComponent<MovementController>();
        if (!movement) return;

        movement.Stop();
        movement.SetSpeed(45f);

        bool hitFromRight = other.transform.position.x > transform.position.x;

        if (hitFromRight) movement.SetMoveLeft();
        else movement.SetMoveRight();

        EnemyHearthController controller = hearthController.GetComponent<EnemyHearthController>();
        if (!controller)
        {
            Debug.Log("No hearth controller found");
            return;
        }

        controller.DestroyOneHearth();

        if (controller.GetEnemyHearthCount() <= 0)
        {
            Defeated();
        }
    }

    private void Defeated()
    {
        MovementController movement = GetComponent<MovementController>();
        if (!movement) return;

        movement.Stop();
        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (!collider) return;

        collider.enabled = false;

        AnimationController animController = GetComponent<AnimationController>();
        animController.StartAnimationWithDelay("Snake_death", EndRoom, 2f, "Phantom_death");
    }

    private void EndRoom()
    {
        GameObject SpawnController = GameObject.FindGameObjectWithTag("SpawnController");
        if (!SpawnController) return;

        WorldSpawnPositionController spawnPosition = SpawnController.GetComponent<WorldSpawnPositionController>();
        if (!spawnPosition) return;

        spawnPosition.SpawnPositionX = -36;
        spawnPosition.SpawnPositionY = -54;

        Inventory inventory = Inventory.Instance;
        inventory.ActivateBoat();

        SceneManager.LoadScene("World");
    }
}
