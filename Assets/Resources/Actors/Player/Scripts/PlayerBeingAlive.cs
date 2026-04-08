using UnityEngine;

public class PlayerBeingAlive : MonoBehaviour
{
    private AnimationController animator;

    private void Awake()
    {
        animator = GetComponent<AnimationController>();
        if (!animator) return;
    }

    void Start()
    {
        animator.StartAnimation("Player_idle");
        GameObject SpawnController = GameObject.FindGameObjectWithTag("SpawnController");
        if (!SpawnController) return;

        WorldSpawnPositionController spawnPosition = SpawnController.GetComponent<WorldSpawnPositionController>();
        if (!spawnPosition) return;

        PositionController position = GetComponent<PositionController>();
        if (!position) return;

        position.SetPosition(spawnPosition.SpawnPositionX, spawnPosition.SpawnPositionY);
    }
}
