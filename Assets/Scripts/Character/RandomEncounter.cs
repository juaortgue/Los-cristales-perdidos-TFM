using UnityEngine;
using UnityEngine.SceneManagement;


public class RandomEncounter : MonoBehaviour
{

    public float timeBetweenChecks = 1f;
    public float encounterChance = 0.05f;
    public string battleSceneName = "BattleScene";

    private float timer = 0f;
    private bool isWalking = false;

    private void Update()
    {
        if (isWalking)
        {
            timer += Time.deltaTime;
            
            if (timer >= timeBetweenChecks)
            {
                timer = 0f;

                if (Random.value < encounterChance)
                {
                    StartEncounter();
                }
            }
            
             
        }
    }

    private void StartEncounter()
    {
        SceneManager.LoadScene(battleSceneName);
    }

    public void SetWalking(bool walking)
    {
        isWalking = walking;
    }
}
