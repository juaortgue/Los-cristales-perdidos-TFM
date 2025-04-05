using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState {  PLAYERTURN, ENEMYTURN, WON, LOST }

public class BattleManagerScript : MonoBehaviour
{

    public GameObject attackGameObject,scapeGameObject, player, enemy;
       
    private PlayerBattle playerBattle;
    private EnemyBattle enemyBattle;
    private BattleState state;

    private Button attackButton, scapeButton;

    void Start()
    {
        attackButton = attackGameObject.GetComponent<Button>();
        scapeButton = scapeGameObject.GetComponent<Button>();
        playerBattle= player.GetComponent<PlayerBattle>();
        enemyBattle= enemy.GetComponent<EnemyBattle>();

        state = BattleState.PLAYERTURN;
        ChangeToEnemyTurn();
    }

    void ChangeToPlayerTurn()
    {
        ShowButtons(true);
    }

    void ChangeToEnemyTurn()
    {
        ShowButtons(false);
    }

    
    void ShowButtons(bool show)
    {
        attackButton.interactable=show;
        scapeButton.interactable=show;

    }

    void Update()
    {
        
    }

    
}
