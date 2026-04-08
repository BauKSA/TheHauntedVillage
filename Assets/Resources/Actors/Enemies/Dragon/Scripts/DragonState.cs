using UnityEngine;
using UnityEngine.SceneManagement;

public class DragonState : MonoBehaviour
{
    public bool IsVulnerable = true;
    public bool CanAttack = true;

    [SerializeField]
    private GameObject hearthController;

    public void Damage()
    {
        EnemyHearthController controller = hearthController.GetComponent<EnemyHearthController>();
        if (!controller)
        {
            Debug.Log("No hearth controller found");
            return;
        }

        controller.DestroyOneHearth();

        if (controller.GetEnemyHearthCount() <= 0)
        {
            Defeated();
        }
    }

    private void Defeated()
    {
        GameObject SpawnController = GameObject.FindGameObjectWithTag("SpawnController");
        if (!SpawnController) return;

        WorldSpawnPositionController spawnPosition = SpawnController.GetComponent<WorldSpawnPositionController>();
        if (!spawnPosition) return;

        spawnPosition.SpawnPositionX = -36;
        spawnPosition.SpawnPositionY = -54;

        Inventory inventory = Inventory.Instance;
        inventory.ActivateBomb();

        SceneManager.LoadScene("Building");
    }
}
