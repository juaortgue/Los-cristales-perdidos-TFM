using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int level = 1;
    public int currentXP = 0;
    public int xpToNextLevel = 100;

    public int maxHP = 100;
    public int currentHP;
    public int attack = 10;
    public int defense = 5;

    void Start()
    {
        currentHP = maxHP;
    }

    public void GainXP(int amount)
    {
        currentXP += amount;
        while (currentXP >= xpToNextLevel)
        {
            currentXP -= xpToNextLevel;
            LevelUp();
        }
    }

    void LevelUp()
    {
        level++;
        xpToNextLevel = Mathf.RoundToInt(xpToNextLevel * 1.2f); 

        maxHP += 10;
        attack += 2;
        defense += 1;

        currentHP = maxHP;

        Debug.Log($"¡Subiste a nivel {level}!");
    }
}
