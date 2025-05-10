using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject skeletonPrefab;
    [SerializeField] private GameObject flyEyePrefab;
    [SerializeField] private GameObject finalBossPrefab;
    [SerializeField] private GameObject enemiesParent;
    [SerializeField] private Transform spawnPoint;

    public static GameObject currentEnemy;

    public void Start()
    {
        SpawnEnemy();
    }

    public void SpawnEnemy()
    {
        Debug.Log("SpawnEnemy() called");
        GameObject enemyToSpawn;

        if (BattleContext.isFinalBattle)
        {
            enemyToSpawn = finalBossPrefab; 
        }
        else
        {
            if (PlayerStats.Instance.getLevel() >= 1 && PlayerStats.Instance.getLevel() <= 2)
            {
                enemyToSpawn = skeletonPrefab;
                Debug.Log("Spawned Skeleton Enemy");
            }
            else if (PlayerStats.Instance.getLevel() >= 3 && PlayerStats.Instance.getLevel() <= 5)
            {
                enemyToSpawn = flyEyePrefab;
                Debug.Log("Spawned Fly Eye Enemy");
            }
            else
            {
                Debug.LogWarning("Nivel no válido para generar enemigos.");
                return;
            }
        }

        if (enemyToSpawn != null && spawnPoint != null)
        {
            Debug.Log("Instantiating enemy: " + enemyToSpawn.name);
            GameObject currentEnemy = Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
            //currentEnemy.transform.SetParent(enemiesParent.transform);
            EnemySpawner.currentEnemy = currentEnemy;


        }
        else
        {
            Debug.LogError("No se pudo instanciar el enemigo"+ enemyToSpawn.name+"o el punto de aparición es nulo.");
        }
    }
}
