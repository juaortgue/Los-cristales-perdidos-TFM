using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum BattleState { PLAYERTURN, ENEMYTURN, WON, LOST, WAITING }

public class BattleManagerScript : MonoBehaviour
{

    public GameObject attackGameObject, scapeGameObject, player, enemy;
    public TextMeshProUGUI turnText;

    private PlayerBattle playerBattle;
    private EnemyBattle enemyBattle;
    private BattleState state;

    private Button attackButton, scapeButton;

    void Start()
    {
        attackButton = attackGameObject.GetComponent<Button>();
        scapeButton = scapeGameObject.GetComponent<Button>();
        playerBattle = player.GetComponent<PlayerBattle>();
        enemyBattle = enemy.GetComponent<EnemyBattle>();


        ChangeToPlayerTurn();
    }
    void Update()
    {
        if (state.Equals(BattleState.ENEMYTURN))
        {
            state = BattleState.WAITING;
            StartCoroutine(EnemyAttackPlayerAfterDelay(1.5f));
        }
    }

    void ChangeToPlayerTurn()
    {
        turnText.text = "Player turn";
        state = BattleState.PLAYERTURN;
        ShowButtons(true);
    }

    void ChangeToEnemyTurn()
    {
        turnText.text = "Enemy turn";
        state = BattleState.ENEMYTURN;
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

        if (playerBattle.currentHP <= 0)
        {
            state = BattleState.LOST;
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
        if (enemyBattle.currentHP <= 0)
        {
            state = BattleState.WON;
            StartCoroutine(EndBattleAfterDelay("TownScene"));
        }
        else
        {
            ChangeToEnemyTurn();
        }
    }
    IEnumerator EndBattleAfterDelay(string sceneName)
    {
        turnText.text = (sceneName == "TownScene") ? "¡Has ganado!" : "Has perdido...";
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }



}
