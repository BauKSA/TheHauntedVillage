using System;
using UnityEngine;

public class SnakeMovement : MonoBehaviour
{
    private MovementController movement;
    private AnimationController animationController;
    private SnakeState state;

    [SerializeField]
    private GameObject WaterSplash;
    private readonly Vector2 waterSplashHorizontalLimit = new(-59, 29);

    private float Timer = 0f;
    private float SwimTime = 5f;

    private bool SpawnInRound = false;

    private void Awake()
    {
        movement = GetComponent<MovementController>();
        if (!movement) Destroy(this);

        animationController = GetComponent<AnimationController>();
        if (!animationController) Destroy(this);

        state = GetComponent<SnakeState>();
        if (!state) Destroy(this);
    }

    private void Update()
    {
        if (state.IsOnWater) SwimmingLoop(Time.deltaTime);
    }

    private void SwimmingLoop(float delta)
    {
        Timer += delta;
        float temp_Timer = Timer;

        if (Math.Ceiling(temp_Timer) % 3f == 0 && !SpawnInRound)
        {
            Spawn();
        }

        if (Timer < SwimTime) return;

        SpawnInRound = false;
        Timer = 0f;
        SwimTime = UnityEngine.Random.Range(5f, 8f);

        movement.SetSpeed(18f);

        movement.Stop();

        if (animationController.GetCurrentAnimation() == "Snake-left_idle")
            movement.SetMoveLeft();
        else
            movement.SetMoveRight();
    }

    private void Spawn()
    {
        SpawnInRound = true;
        if (!WaterSplash) return;

        Instantiate(WaterSplash, transform.position, Quaternion.identity);
    }
}
