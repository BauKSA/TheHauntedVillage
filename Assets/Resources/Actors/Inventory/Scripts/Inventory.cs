using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance { get; private set; }

    [Header("Items")]
    [SerializeField]
    private GameObject Axe;
    [SerializeField]
    private GameObject Boat;
    [SerializeField]
    private GameObject Bomb;

    public bool AxeActive { get; set; } = false;
    public bool BoatActive { get; set; } = false;
    public bool BombActive { get; set; } = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public void ActivateAxe()
    {
        AxeActive = true;
    }

    public void ActivateBoat()
    {
        BoatActive = true;
    }

    public void ActivateBomb()
    {
        BombActive = true;
    }
}
