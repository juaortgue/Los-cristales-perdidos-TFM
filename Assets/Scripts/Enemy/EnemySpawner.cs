using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject flyEyePrefab;
    [SerializeField] private GameObject finalBossPrefab;
    [SerializeField] private Transform spawnPoint;

    public static GameObject currentEnemy;

    public void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        GameObject enemyToSpawn;

        if (GameContext.isFinalBattle)
        {
            enemyToSpawn = finalBossPrefab;
        }
        else
        {
            if (PlayerStats.Instance.getLevel() >= 1 && PlayerStats.Instance.getLevel() <= 2)
            {
                enemyToSpawn = skeletonPrefab;
            }
            else if (PlayerStats.Instance.getLevel() >= 3 && PlayerStats.Instance.getLevel() <= 5)
            {
                enemyToSpawn = flyEyePrefab;
            }
            else
            {
                return;
            }
        }

        if (enemyToSpawn != null && spawnPoint != null)
        {
            GameObject currentEnemy = Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
            EnemySpawner.currentEnemy = currentEnemy;


        }
        else
        {
            Debug.LogError("No se pudo instanciar el enemigo" + enemyToSpawn.name + "o el punto de aparición es nulo.");
        }
    }
}
