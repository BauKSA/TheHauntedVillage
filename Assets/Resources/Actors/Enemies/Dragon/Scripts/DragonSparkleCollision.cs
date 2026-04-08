using UnityEngine;

public class DragonSparkleCollision : MonoBehaviour
{
    AnimationController animationController;
    MovementController movement;
    DragonState state;

    [SerializeField]


    private bool rightSide = false;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
        movement = GetComponent<MovementController>();
        state = GetComponent<DragonState>();

        if (!movement || !animationController || !state) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Sparkle")) return;
        Destroy(other.gameObject);

        if (!state.IsVulnerable) return;

        state.IsVulnerable = false;
        state.CanAttack = false;

        movement.Stop();
        if (animationController.GetCurrentAnimation().Contains("left"))
        {
            rightSide = false;
            animationController.StartAnimationWithDelay(
                "Dragon-left_damaged", ResetState, 2f);
        }
        else
        {
            rightSide = true;
            animationController.StartAnimationWithDelay(
                "Dragon_damaged", ResetState, 2f);
        }
    }

    private void ResetState()
    {
        state.IsVulnerable = true;
        state.CanAttack = true;

        state.Damage();

        if (rightSide) movement.SetMoveRight();
        else movement.SetMoveLeft();
    }
}
