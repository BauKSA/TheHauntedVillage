using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PlayerCutDownTree : MonoBehaviour
{
    public void Execute()
    {
        PlayerActionState playerState = gameObject.GetComponent<PlayerActionState>();
        if (!playerState) return;

        if (!playerState.IsOnTree) return;

        GameObject tree = playerState.CurrentTree;
        if(!tree) return;

        AnimationController treeAnim = tree.GetComponent<AnimationController>();
        if (!treeAnim) return;

        if (treeAnim.GetCurrentAnimation() == "Tree_felled") return;

        Inventory inventory = Inventory.Instance;
        if (!inventory.AxeActive) return;

        treeAnim.StartAnimation("Tree-felled_idle");

        foreach (BoxCollider2D collider in tree.GetComponents<BoxCollider2D>())
        {
            if (collider.isTrigger) continue;
            collider.isTrigger = true;
        }

        foreach (Rigidbody2D collider in tree.GetComponents<Rigidbody2D>())
        {
            Destroy(collider);
        }

        playerState.IsOnTree = false;
        playerState.CurrentTree = null;
    }
}
