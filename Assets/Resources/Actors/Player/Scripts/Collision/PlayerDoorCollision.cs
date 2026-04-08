using UnityEngine;

public class PlayerDoorCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Door")) return;
        DoorState doorState = other.GetComponent<DoorState>();
        if (!doorState) return;

        if (!doorState.IsOpen) return;
        if (doorState.Used) return;

        PlayerActionState actionState = GetComponent<PlayerActionState>();
        if (!actionState) return;

        actionState.IsOnDoor = true;
        actionState.DoorRoom = doorState.GetRoom();
        Debug.Log("PlayerDoorCollision: Entered door to room " + actionState.DoorRoom);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Door")) return;
        DoorState doorState = other.GetComponent<DoorState>();
        if (!doorState) return;

        if (!doorState.IsOpen) return;
        if (doorState.Used) return;

        PlayerActionState actionState = GetComponent<PlayerActionState>();
        if (!actionState) return;

        actionState.IsOnDoor = false;
        actionState.DoorRoom = null;
    }
}
