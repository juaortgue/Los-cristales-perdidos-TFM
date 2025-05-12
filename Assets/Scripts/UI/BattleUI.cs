using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class BattleUI : MonoBehaviour
{

    
    public Slider enemyHealthSlider, playerHealthSlider;
    public TextMeshProUGUI playerLifeText;
    public TextMeshProUGUI enemyLifeText;
    public TextMeshProUGUI turnText;
    private EnemyBattle enemyBattle;
    private Button attackButton,defendButton, scapeButton;
    public GameObject attackGameObject,defendGameObject ,scapeGameObject;

    public void Init(EnemyBattle enemyBattle)
    {
        this.enemyBattle = enemyBattle;
        attackButton = attackGameObject.GetComponent<Button>();
        defendButton = defendGameObject.GetComponent<Button>();
        scapeButton = scapeGameObject.GetComponent<Button>();
        enemyHealthSlider.maxValue = enemyBattle.maxHP;
        enemyHealthSlider.value = enemyBattle.currentHP;
        playerHealthSlider.maxValue = PlayerStats.Instance.getMaxHP();
        playerHealthSlider.value = PlayerStats.Instance.getCurrentHP();
        UpdateLifeTexts();
    }

    public void ShowButtons(bool show)
    {
        attackButton.interactable = show;
        defendButton.interactable = show;
        if (GameContext.isFinalBattle)
        {
            scapeButton.interactable = false;
        }
        else
        {
            scapeButton.interactable = show;
        }

    }

    public void UpdateLifeTexts()
    {
        playerLifeText.text = PlayerStats.Instance.getCurrentHP() + "/" + PlayerStats.Instance.getMaxHP();
        enemyLifeText.text = enemyBattle.currentHP + "/" + enemyBattle.maxHP;
        enemyHealthSlider.value = enemyBattle.currentHP;
        playerHealthSlider.value = PlayerStats.Instance.getCurrentHP();
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
        }else if(state.Equals(BattleStateEnum.CHARGINGATTACK))
        {
            text = "Charging Attack...";
        }else if(state.Equals(BattleStateEnum.CRITICAL))
        {
            text = "Critical Hit!";
        }
        else if(state.Equals(BattleStateEnum.CRITICAL_FAILED))
        {
            text = "Critical Failed...";
        }

        turnText.text = text;

    }
}
