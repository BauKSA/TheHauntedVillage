using UnityEngine;

public class PlayerWaterCollision : MonoBehaviour
{
    Inventory inventory;
    AnimationController animController;
    PlayerState state;

    private int waterContacts = 0;

    private void Awake()
    {
        animController = GetComponent<AnimationController>();
        state = GetComponent<PlayerState>();

        if (!state || !animController) Destroy(this);
    }

    private void Start()
    {
        inventory = Inventory.Instance;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Water")) return;
        if (!inventory.BoatActive) return;

        waterContacts++;
        if (waterContacts > 1) return;

        state.IsOnWater = true;

        if (animController.GetCurrentAnimation() == "Player_idle"
            || animController.GetCurrentAnimation() == "Player_walking")
        {
            animController.StartAnimation("Player_boat");
        }
        else
        {
            animController.StartAnimation("Player-left_boat");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Water")) return;
        if (!inventory.BoatActive) return;

        waterContacts--;

        if (waterContacts > 0) return;

        state.IsOnWater = false;

        if (animController.GetCurrentAnimation() == "Player_boat")
        {
            animController.StartAnimation("Player_walking");
        }
        else
        {
            animController.StartAnimation("Player-left_walking");
        }
    }
}
