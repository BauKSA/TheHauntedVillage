using UnityEngine;

public class PlayerSplashCollision : MonoBehaviour
{
    PlayerState state;

    private void Awake()
    {
        state = GetComponent<PlayerState>();
        if (!state) Destroy(this);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Splash")) return;
        if (!state.IsVulnerable) return;


        Destroy(other.gameObject);

        PlayerDeath death = GetComponent<PlayerDeath>();
        if (!death) return;

        death.Execute();
    }
}
