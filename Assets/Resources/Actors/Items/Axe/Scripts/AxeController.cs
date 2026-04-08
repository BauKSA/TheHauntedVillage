using UnityEngine;

public class AxeController : MonoBehaviour
{
    private AnimationController animationController;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        if (Inventory.Instance.AxeActive)
        {
            animationController.StartAnimation("Axe_available");
        }
    }
}