using UnityEngine;

public class WorldSpawnPositionController : MonoBehaviour
{
    public static WorldSpawnPositionController Instance { get; private set; }

    public float SpawnPositionX { get; set; } = -46f;
    public float SpawnPositionY { get; set; } = -68f;

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

    public void Reset()
    {
        SpawnPositionX = -46f;
        SpawnPositionY = -68f;
    }
}
