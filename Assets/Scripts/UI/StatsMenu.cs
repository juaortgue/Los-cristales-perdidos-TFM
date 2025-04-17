using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class StatsMenu : MonoBehaviour
{
    public GameObject statsPanel;
    
    public TextMeshProUGUI levelField;
    public TextMeshProUGUI expField;
    public TextMeshProUGUI nextLevelField;
    public TextMeshProUGUI attackField;
    public TextMeshProUGUI defenseField;
    public TextMeshProUGUI hpField;

    public void TogleStatsMenu(InputAction.CallbackContext context)
    {
        if (statsPanel != null && context.performed)
        {
            bool isActive = !statsPanel.activeSelf;
            
            statsPanel.SetActive(isActive);
            
            Time.timeScale = isActive ? 0 : 1;
        }
    }

    public void UpdateStats()
    {
        levelField.text = PlayerStats.Instance.getLevel().ToString();
        expField.text = PlayerStats.Instance.getCurrentXP().ToString();
        nextLevelField.text = PlayerStats.Instance.getXPToNextLevel().ToString();
        attackField.text = PlayerStats.Instance.getAttack().ToString();
        defenseField.text = PlayerStats.Instance.getDefense().ToString();
        hpField.text = PlayerStats.Instance.getCurrentHP().ToString()+ "/"+PlayerStats.Instance.getMaxHP().ToString();
    }

    private void Update()
    {
        if (statsPanel.activeSelf)
        {
            UpdateStats();
        }
    }
    
}
