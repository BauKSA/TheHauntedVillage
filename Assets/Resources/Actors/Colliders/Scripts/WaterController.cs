using System.Collections;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    Inventory inventory;

    private void Start()
    {
        inventory = Inventory.Instance;
        StartCoroutine(WaitForItems());
    }

    private IEnumerator WaitForItems()
    {
        yield return new WaitForSeconds(0.75f);
        CheckCollision();

    }

    private void CheckCollision()
    {
        if (!inventory.BoatActive) return;
        GameObject[] waterColliders = GameObject.FindGameObjectsWithTag("Water");

        foreach (GameObject collider in waterColliders)
        {
            BoxCollider2D box = collider.GetComponent<BoxCollider2D>();
            if (!box) continue;

            box.isTrigger = true;
        }
    }
}
