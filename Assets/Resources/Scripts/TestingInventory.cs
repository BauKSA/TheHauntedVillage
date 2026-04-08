using UnityEngine;

public class TestingInventory : MonoBehaviour
{
    Inventory inventory;

    [SerializeField]
    private bool activateAxe;
    [SerializeField]
    private bool activateBoat;

    private void Start()
    {
        inventory = Inventory.Instance;

        if (activateAxe)
        {
            inventory.ActivateAxe();
        }

        if (activateBoat)
        {
            inventory.ActivateBoat();
        }
    }
}
