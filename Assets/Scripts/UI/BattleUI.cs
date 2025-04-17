using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BattleUI : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;


    public TextMeshProUGUI playerLifeText;
    public TextMeshProUGUI enemyLifeText;
    public TextMeshProUGUI turnText;
    private PlayerBattle playerBattle;
    private EnemyBattle enemyBattle;
    private Button attackButton, scapeButton;
    public GameObject attackGameObject, scapeGameObject;

    void Start()
    {
        playerBattle = player.GetComponent<PlayerBattle>();
        enemyBattle = enemy.GetComponent<EnemyBattle>();
        attackButton = attackGameObject.GetComponent<Button>();
        scapeButton = scapeGameObject.GetComponent<Button>();
        UpdateLifeTexts();
    }

    public void ShowButtons(bool show)
    {
        attackButton.interactable = show;
        scapeButton.interactable = show;

    }

    public void UpdateLifeTexts()
    {
        playerLifeText.text = PlayerStats.Instance.getCurrentHP() + "/" + PlayerStats.Instance.getMaxHP();
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
        }else if (state.Equals(BattleStateEnum.WAITING))
        {
            text = "Waiting...";
        }else if (state.Equals(BattleStateEnum.LEVELUP))
        {
            text = "Level Up!";
        }

        turnText.text = text;

    }
}
