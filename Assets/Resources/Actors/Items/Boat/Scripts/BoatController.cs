using UnityEngine;

public class BoatController : MonoBehaviour
{
    private AnimationController animationController;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        if (Inventory.Instance.BoatActive)
        {
            animationController.StartAnimation("Boat_available");
        }
    }
}