using UnityEngine;

public class BombBeingAlive : MonoBehaviour
{
    private AnimationController animController;

    [SerializeField]
    private float aliveTime = 5f;

    [SerializeField]
    private GameObject Sparkle;

    bool blink = false;
    bool explosion = false;

    private void Awake()
    {
        animController = GetComponent<AnimationController>();
        if (!animController) Destroy(this);
    }

    private void Update()
    {
        aliveTime -= Time.deltaTime;
        if (aliveTime <= 2f && !blink)
        {
            Debug.Log("Start before explosion animation");
            animController.StartAnimation("Bomb_before-explosion");
            blink = true;
        }

        if (aliveTime <= 0f && !explosion)
        {
            BombSparkle();

            animController.StartAnimationWithDelay(
                "Bomb_explosion", ExplosionDestroy, 1f, "Bomb_explosion");

            explosion = true;
        }
    }

    private void BombSparkle()
    {
        if (!Sparkle) return;

        GameObject leftBomb = Instantiate(Sparkle, transform.position, Quaternion.identity);
        BombSparkleBeingAlive leftBombState = leftBomb.GetComponent<BombSparkleBeingAlive>();
        if (!leftBombState) return;

        leftBombState.rightSide = false;
        leftBombState.Move();

        Quaternion rotRight = Quaternion.Euler(0f, 180f, 0f);
        GameObject rightBomb = Instantiate(Sparkle, transform.position, rotRight);
        BombSparkleBeingAlive rightBombState = rightBomb.GetComponent<BombSparkleBeingAlive>();
        if (!rightBombState) return;

        rightBombState.rightSide = true;
        rightBombState.Move();
    }

    private void ExplosionDestroy()
    {
        Destroy(gameObject);
    }
}