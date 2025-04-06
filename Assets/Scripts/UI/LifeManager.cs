using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LifeManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;

    
    public TextMeshProUGUI playerLifeText;
    public TextMeshProUGUI enemyLifeText;

    private PlayerBattle playerBattle;
    private EnemyBattle enemyBattle;


    void Start(){
        playerBattle = player.GetComponent<PlayerBattle>();
        enemyBattle = enemy.GetComponent<EnemyBattle>();

        UpdateLifeTexts(); 
    }

    void Update()
    {
        UpdateLifeTexts(); 
    }

    private void UpdateLifeTexts()
    {
        playerLifeText.text = playerBattle.currentHP+"/"+playerBattle.maxHP;
        enemyLifeText.text = enemyBattle.currentHP+"/"+enemyBattle.maxHP;
    }
}
