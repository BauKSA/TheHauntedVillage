using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyHearthController : MonoBehaviour
{
    List<GameObject> Hearths;

    [SerializeField]
    private int EnemyHearthCount;

    private readonly int MaxEnemyHearths = 10;

    private int GetHearthIndex(string name)
    {
        string[] parts = name.Split('-');
        return int.Parse(parts[1]);
    }

    void Start()
    {
        Hearths = GameObject.FindGameObjectsWithTag("Hearth")
            .OrderByDescending(hearth => GetHearthIndex(hearth.name))
            .ToList();

        int toDestroy = MaxEnemyHearths - EnemyHearthCount;

        for (int i = 0; i < toDestroy; i++)
        {
            Destroy(Hearths[i]);
        }
    }

    public void DestroyOneHearth()
    {
        EnemyHearthCount--;

        Debug.Log("Enemy hearths left: " + EnemyHearthCount);
        if (EnemyHearthCount < 0) return;

        for(int i = 0; i < Hearths.Count; i++)
        {
            if (Hearths[i] != null)
            {
                Debug.Log("Destroy hearth: " + Hearths[i].name);
                Destroy(Hearths[i]);
                break;
            }
        }
    }

    public int GetEnemyHearthCount()
    {
        return EnemyHearthCount;
    }
}