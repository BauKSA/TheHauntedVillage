using UnityEngine;

public class PlayerTreeCollision : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Tree")) return;

        PlayerActionState actionState = GetComponent<PlayerActionState>();
        if (!actionState) return;

        actionState.IsOnTree = true;
        actionState.CurrentTree = other.gameObject;
        Debug.Log("Player collided with tree");
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (!other.gameObject.CompareTag("Tree")) return;

        PlayerActionState actionState = GetComponent<PlayerActionState>();
        if (!actionState) return;

        actionState.IsOnTree = false;
        actionState.CurrentTree = null;
        Debug.Log("Player exited tree collision");
    }
}
