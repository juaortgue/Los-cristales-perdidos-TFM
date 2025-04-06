using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class BattleManagerScript : MonoBehaviour
{

    public GameObject attackGameObject, scapeGameObject, player, enemy;
    public BattleStateEnum state;
    public GameObject battleUIGameObject;

    private BattleUI battleUIScript;
    private PlayerBattle playerBattle;
    private EnemyBattle enemyBattle;
    

    private Button attackButton, scapeButton;

    void Start()
    {
        attackButton = attackGameObject.GetComponent<Button>();
        scapeButton = scapeGameObject.GetComponent<Button>();
        playerBattle = player.GetComponent<PlayerBattle>();
        enemyBattle = enemy.GetComponent<EnemyBattle>();
        battleUIScript = battleUIGameObject.GetComponent<BattleUI>();
        battleUIScript.UpdateLifeTexts();
        ChangeToPlayerTurn();
    }
    void Update()
    {
        if (state.Equals(BattleStateEnum.ENEMYTURN))
        {
            
            state = BattleStateEnum.WAITING;
            StartCoroutine(EnemyAttackPlayerAfterDelay(1.5f));
        }
    }

    void ChangeToPlayerTurn()
    {
        
        state = BattleStateEnum.PLAYERTURN;
        battleUIScript.UpdateTurnText(BattleStateEnum.PLAYERTURN);
        ShowButtons(true);
    }

    void ChangeToEnemyTurn()
    {
        battleUIScript.UpdateTurnText(BattleStateEnum.ENEMYTURN);
        state = BattleStateEnum.ENEMYTURN;
        ShowButtons(false);
    }


    void ShowButtons(bool show)
    {
        attackButton.interactable = show;
        scapeButton.interactable = show;

    }




    IEnumerator EnemyAttackPlayerAfterDelay(float delay)
    {

        yield return new WaitForSeconds(delay);

        int damage = 1;
        if (enemyBattle.attack > playerBattle.defense)
        {
            damage = enemyBattle.attack - playerBattle.defense;
        }
        playerBattle.TakeDamage(damage);
        battleUIScript.UpdateLifeTexts();
        if (playerBattle.currentHP <= 0)
        {
            state = BattleStateEnum.LOST;
            StartCoroutine(EndBattleAfterDelay("MainMenu"));
        }
        else
        {
            ChangeToPlayerTurn();
        }
    }

    public void PlayerAttackEnemy()
    {
        int damage = 1;
        if (playerBattle.attack > enemyBattle.defense)
        {
            damage = playerBattle.attack - enemyBattle.defense;
        }
        enemyBattle.TakeDamage(damage);
        battleUIScript.UpdateLifeTexts();
        if (enemyBattle.currentHP <= 0)
        {
            state = BattleStateEnum.WON;
            StartCoroutine(EndBattleAfterDelay("TownScene"));
        }
        else
        {
            ChangeToEnemyTurn();
        }
    }
    IEnumerator EndBattleAfterDelay(string sceneName)
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }



}
