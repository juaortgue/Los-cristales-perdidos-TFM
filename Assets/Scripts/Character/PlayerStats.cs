using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    // Singleton instance
    public static PlayerStats Instance;

    //character progression
    [SerializeField] private int level = 1;
    [SerializeField] private int currentXP = 0;
    [SerializeField] private int xpToNextLevel = 10;
    [SerializeField] private int plusDefense = 2;
    [SerializeField] private int plusAttack = 2;
    [SerializeField] private int plusHP = 10;
    [SerializeField] private int maxLvl = 5;

    //character stats
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int currentHP;
    [SerializeField] private int attack = 10;
    [SerializeField] private int defense = 5;



    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {

        if (currentHP == 0)
        {
            currentHP = maxHP;
        }
    }

    public void GainExpFromEnemy(int exp)
    {
        if (level < maxLvl)
        {
            currentXP += exp;
            Debug.Log("Current XP: " + currentXP);
            Debug.Log("XP to next level: " + xpToNextLevel);

            if (currentXP >= xpToNextLevel)
            {
                LevelUp();
            }

            if (currentXP < 0 || currentXP > xpToNextLevel)
            {
                currentXP = 0;
            }
        }


    }

    private void LevelUp()
    {
        level++;
        currentXP = 0;
        xpToNextLevel = xpToNextLevel * 2;
        maxHP += plusHP;
        attack += plusAttack;
        defense += plusDefense;
        currentHP = maxHP;

        Debug.Log("Level Up! New Level: " + level);
        Debug.Log("New XP to next level: " + xpToNextLevel);
        Debug.Log("New Max HP: " + maxHP);
        Debug.Log("New Attack: " + attack);
        Debug.Log("New Defense: " + defense);
        Debug.Log("New Current HP: " + currentHP);
    }

    public int getPlusHP()
    {
        return plusHP;
    }

    public int getPlusAttack()
    {
        return plusAttack;
    }

    public int getPlusDefense()
    {
        return plusDefense;
    }

    public int getMaxLvl()
    {
        return maxLvl;
    }
    
    public int getCurrentHP()
    {
        return currentHP;
    }

    public int getMaxHP()
    {
        return maxHP;
    }

    public int getLevel()
    {
        return level;
    }

    public int getCurrentXP()
    {
        return currentXP;
    }

    public int getXPToNextLevel()
    {
        return xpToNextLevel;
    }

    public int getAttack()
    {
        return attack;
    }

    public int getDefense()
    {
        return defense;
    }

    public void setLevel(int newLevel)
    {
        level = newLevel;
    }

    public void setCurrentXP(int xp)
    {
        currentXP = xp;
    }

    public void setXPToNextLevel(int xp)
    {
        xpToNextLevel = xp;
    }

    public void setMaxHP(int hp)
    {
        maxHP = hp;
    }

    public void setAttack(int atk)
    {
        attack = atk;
    }

    public void setDefense(int def)
    {
        defense = def;
    }

    public void setCurrentHP(int hp)
    {
        currentHP = hp;
    }

}
