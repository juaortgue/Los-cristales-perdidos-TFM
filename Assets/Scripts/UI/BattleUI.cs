using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BattleUI : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;


    public TextMeshProUGUI playerLifeText;
    public TextMeshProUGUI enemyLifeText;
    public TextMeshProUGUI turnText;
    private PlayerBattle playerBattle;
    private EnemyBattle enemyBattle;


    void Start()
    {
        playerBattle = player.GetComponent<PlayerBattle>();
        enemyBattle = enemy.GetComponent<EnemyBattle>();
        UpdateLifeTexts();
    }

    

    public void UpdateLifeTexts()
    {
        playerLifeText.text = playerBattle.currentHP + "/" + playerBattle.maxHP;
        enemyLifeText.text = enemyBattle.currentHP + "/" + enemyBattle.maxHP;
    }

    public void UpdateTurnText(BattleStateEnum state)
    {

        string text = "";

        if (state.Equals(BattleStateEnum.PLAYERTURN))
        {
            text = "Player turn";
        }
        else if (state.Equals(BattleStateEnum.ENEMYTURN))
        {
            text = "Enemy turn";
        }
        else if (state.Equals(BattleStateEnum.WON))
        {
            text = "You have won!";
        }
        else if (state.Equals(BattleStateEnum.LOST))
        {
            text = "You have lost!";
        }

        turnText.text = text;

    }
}
