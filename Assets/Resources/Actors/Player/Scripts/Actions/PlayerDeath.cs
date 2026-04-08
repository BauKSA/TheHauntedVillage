using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private AnimationController animController;
    private PlayerState state;
    private MovementController movement;

    private void Awake()
    {
        animController = GetComponent<AnimationController>();
        state = GetComponent<PlayerState>();
        movement = GetComponent<MovementController>();

        if (!animController || !state || !movement) Destroy(this);
    }

    public void Execute()
    {
        movement.Stop();
        state.CanMove = false;
        state.IsVulnerable = false;

        animController.StartAnimationWithDelay("Player_death", GameOver, 2f, "Player_death");
    }

    private void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
