using System.Collections;
using UnityEngine;

public class BombSparkleBeingAlive : MonoBehaviour
{
    AnimationController animController;
    MovementController movementController;

    public bool rightSide = false;
    public bool canbeDestroyed = false;

    private void Awake()
    {
        animController = GetComponent<AnimationController>();
        movementController = GetComponent<MovementController>();

        if (!animController || !movementController) return;
    }

    private void Start()
    {
        animController.StartAnimation(
            "Bomb-sparkle_idle", true, SelfDestroy, "Bomb-sparkle_destroyed");

        StartCoroutine(CheckDestroyed());
    }

    private IEnumerator CheckDestroyed()
    {
        for (int i = 0; i < 2; i++)
            yield return null;

        canbeDestroyed = true;
    }

    private void SelfDestroy()
    {
        Destroy(gameObject);
    }

    public void Move()
    {
        if (rightSide) movementController.SetMoveRight();
        else movementController.SetMoveLeft();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("BombLimit")) return;
        if (!canbeDestroyed) return;
        Destroy(gameObject);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("BombLimit")) return;
        if (!canbeDestroyed) return;
        Destroy(gameObject);
    }
}