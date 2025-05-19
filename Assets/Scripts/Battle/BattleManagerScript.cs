using System.Collections;
using UnityEngine;

using UnityEngine.SceneManagement;


public class BattleManagerScript : MonoBehaviour
{

    public GameObject player;
    public BattleStateEnum state;
    public GameObject battleUIGameObject;
    public AudioSource audioSourceNormalBattle, audioSourceFinalBattle;


    private BattleUI battleUIScript;
    private PlayerBattle playerBattle;
    private EnemyBattle enemyBattle;
    private bool enemyPreparingCritical = false;




    void Start()
    {
        if (GameContext.isFinalBattle)
        {
            audioSourceNormalBattle.Stop();
            audioSourceFinalBattle.Play();
        }
        else
        {
            audioSourceFinalBattle.Stop();
            audioSourceNormalBattle.Play();
        }

        StartCoroutine(WaitForEnemyToBeReady());
    }

    IEnumerator WaitForEnemyToBeReady()
    {
        while (EnemySpawner.currentEnemy == null)
        {
            yield return null;
        }

        playerBattle = player.GetComponent<PlayerBattle>();
        enemyBattle = EnemySpawner.currentEnemy.GetComponent<EnemyBattle>();
        battleUIScript = battleUIGameObject.GetComponent<BattleUI>();
        battleUIScript.Init(enemyBattle);
        battleUIScript.UpdateLifeTexts();
        ChangeToPlayerTurn();
    }

    void Update()
    {
        if (state.Equals(BattleStateEnum.ENEMYTURN))
        {

            state = BattleStateEnum.WAITING;
            StartCoroutine(EnemyAttackPlayerAfterDelay(1f));
        }
    }

    void ChangeToPlayerTurn()
    {

        state = BattleStateEnum.PLAYERTURN;
        battleUIScript.UpdateTurnText(BattleStateEnum.PLAYERTURN);
        battleUIScript.ShowButtons(true);
    }

    void ChangeToEnemyTurn()
    {
        battleUIScript.UpdateTurnText(BattleStateEnum.ENEMYTURN);
        state = BattleStateEnum.ENEMYTURN;
        battleUIScript.ShowButtons(false);
    }
    public void EnemyChargeAttack()
    {
        battleUIScript.UpdateTurnText(BattleStateEnum.CHARGINGATTACK);
        enemyPreparingCritical = true;
        playerBattle.Undefending();
    }

    public void EnemyAttackPlayer()
    {
        int damage = 0;
        if (enemyBattle.attack > PlayerStats.Instance.getDefense())
        {
            damage = enemyBattle.attack - PlayerStats.Instance.getDefense();
        }

        if (playerBattle.isDefending)
        {
            damage = damage / 2;
            playerBattle.Undefending();
        }

        enemyBattle.PlayAttackAnimation();
        playerBattle.TakeDamage(damage);
        battleUIScript.UpdateLifeTexts();
        playerBattle.DoReceiveDamageAnimation();
    }

    public void Lost()
    {
        state = BattleStateEnum.LOST;
        battleUIScript.UpdateTurnText(BattleStateEnum.LOST);
        //StartCoroutine(EndBattleAfterDelay("MainMenuScene"));
        battleUIScript.ShowButtons(false);
        PlayerStats.Instance.RecoverHP();
        StartCoroutine(EndBattleAfterDelay("TownScene"));
    }

    public void EnemyAttackPlayerCritical()
    {
        int damage = (int)(PlayerStats.Instance.getMaxHP() * enemyBattle.enemyCriticalPercentageDamage);
        if (playerBattle.isDefending)
        {
            damage /= 3;
            playerBattle.Undefending();
        }

        enemyBattle.PlayAttackAnimation();
        playerBattle.TakeDamage(damage);
        battleUIScript.UpdateTurnText(BattleStateEnum.CRITICAL);
        battleUIScript.UpdateLifeTexts();
        playerBattle.DoReceiveDamageAnimation();

        
    }

    IEnumerator EnemyAttackPlayerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        if (enemyPreparingCritical)
        {
            if (Random.value < enemyBattle.enemyCriticalRateAttack)
            {
                Debug.Log("CRITICAL");
                EnemyAttackPlayerCritical();
                yield return new WaitForSeconds(1f);
            }else{
                Debug.Log("CRITICAL FAILED");
                battleUIScript.UpdateTurnText(BattleStateEnum.CRITICAL_FAILED);
                playerBattle.Undefending();
                yield return new WaitForSeconds(1.5f);

            }
            enemyPreparingCritical = false;
        }
        else
        {
            if (Random.value < enemyBattle.enemyCriticalRatePreparing)
            {
                Debug.Log("PREPARING");
                EnemyChargeAttack();
                yield return new WaitForSeconds(3f);
            }
            else
            {

                EnemyAttackPlayer();
                yield return new WaitForSeconds(1f);
            }
        }


        if (PlayerStats.Instance.getCurrentHP() <= 0)
        {
            Lost();
        }
        else
        {
            ChangeToPlayerTurn();
        }
    }

    public void PlayerAttackEnemy()
    {
        int damage = 1;

        if (PlayerStats.Instance.getAttack() > enemyBattle.defense)
        {
            damage = PlayerStats.Instance.getAttack() - enemyBattle.defense;
        }

        playerBattle.DoAttackAnimation();

        enemyBattle.DoReceiveDamageAnimation();
        enemyBattle.TakeDamage(damage);
        battleUIScript.UpdateLifeTexts();

        if (enemyBattle.currentHP <= 0)
        {
            battleUIScript.ShowButtons(false);
            state = BattleStateEnum.WON;
            int beforeLevel = PlayerStats.Instance.getLevel();
            PlayerStats.Instance.GainExpFromEnemy(enemyBattle.exp);
            PlayerStats.Instance.RecoverHP();
            int afterLevel = PlayerStats.Instance.getLevel();

            if (afterLevel > beforeLevel)
            {
                battleUIScript.UpdateTurnText(BattleStateEnum.LEVELUP);
            }
            else
            {
                battleUIScript.UpdateTurnText(BattleStateEnum.WON);
            }

            if (GameContext.isFinalBattle)
            {
                battleUIScript.UpdateTurnText(BattleStateEnum.WON);
                StartCoroutine(EndBattleAfterDelay("FinalBattleScene"));
            }
            else
            {
                StartCoroutine(EndBattleAfterDelay("TownScene"));
            }

        }
        else
        {
            ChangeToEnemyTurn();
        }
    }

    private void Defend()
    {

        battleUIScript.UpdateTurnText(state);
        playerBattle.Defend();
        ChangeToEnemyTurn();
    }

    public void OnPlayerDefend()
    {
        Defend();
    }

    IEnumerator EndBattleAfterDelay(string sceneName)
    {
        GameContext.previousScene = SceneEnum.BattleScene;
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(sceneName);
    }

    public void ScapeFromBattle()
    {
        int randomNumber = Random.Range(0, 3);
        if (randomNumber == 0)
        {
            battleUIScript.ShowButtons(false);
            state = BattleStateEnum.WAITING;
            PlayerStats.Instance.RecoverHP();
            StartCoroutine(EndBattleAfterDelay("TownScene"));

        }
        else
        {
            ChangeToEnemyTurn();
        }
    }



}
