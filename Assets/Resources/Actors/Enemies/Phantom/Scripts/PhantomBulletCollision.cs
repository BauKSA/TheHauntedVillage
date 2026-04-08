using System.Collections;
using UnityEngine;

public class PhantomBulletCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bullet")) return;

        PhantomState state = GetComponent<PhantomState>();
        if (!state) return;

        if (!state.IsVulnerable) return;

        Destroy(other.gameObject);

        PhantomMovementController controller = GetComponent<PhantomMovementController>();
        if (!controller) return;

        controller.Damage();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Bullet")) return;
        StartCoroutine(Wait(2));
    }

    private void SetVulnerable()
    {
        PhantomState state = GetComponent<PhantomState>();
        if (!state) return;

        state.IsVulnerable = true;
    }

    private IEnumerator Wait(int frames = 1)
    {
        for (int i = 0; i < frames; i++)
            yield return null;

        SetVulnerable();
    }
}
