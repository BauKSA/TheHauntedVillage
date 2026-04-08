using System.Collections;
using UnityEngine;

public class DoorState : MonoBehaviour
{
    public bool IsOpen { get; private set; } = false;
    public bool Used { get; set; } = false;

    [SerializeField]
    private string Room;

    [SerializeField]
    private GameObject RequiredItem;

    [SerializeField]
    private GameObject DisableItem;

    private void Start()
    {
        if (!RequiredItem)
        {
            OpenDoor();
        }

        StartCoroutine(AwaitCheckState());
    }

    private IEnumerator AwaitCheckState()
    {
        for (int i = 0; i < 2; i++)
            yield return null;

        CheckStatus();
    }

    private void CheckStatus()
    {
        UpdateState();

        if (!DisableItem) return;

        AnimationController itemAnim = DisableItem.GetComponent<AnimationController>();
        if (!itemAnim) return;

        if (!itemAnim.GetCurrentAnimation().Contains("_available")) return;

        BoxCollider2D collider = GetComponent<BoxCollider2D>();
        if (!collider) return;

        AnimationController doorAnim = GetComponent<AnimationController>();
        doorAnim.StartAnimation("Door_disabled");

        collider.isTrigger = false;
        collider.size = new Vector2(8, 8);
    }

    public void OpenDoor()
    {
        IsOpen = true;
        AnimationController animationController = GetComponent<AnimationController>();
        if (!animationController) return;

        animationController.StartAnimation("Door_open");
    }

    public string GetRoom() { return Room; }

    public void UpdateState()
    {
        if (IsOpen) return;
        if (!RequiredItem) return;

        AnimationController itemAnim = RequiredItem.GetComponent<AnimationController>();
        if (!itemAnim) return;

        if (!itemAnim.GetCurrentAnimation().Contains("_available")) return;

        OpenDoor();
    }
}
