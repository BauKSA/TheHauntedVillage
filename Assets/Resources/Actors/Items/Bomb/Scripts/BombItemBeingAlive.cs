using UnityEngine;

public class BombItemBeingAlive : MonoBehaviour
{
    private AnimationController animationController;

    private void Awake()
    {
        animationController = GetComponent<AnimationController>();
    }

    private void Start()
    {
        if (Inventory.Instance.BombActive)
        {
            animationController.StartAnimation("Bomb_available");
        }
    }
}
